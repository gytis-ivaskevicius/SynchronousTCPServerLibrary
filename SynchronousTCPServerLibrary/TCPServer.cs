using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SynchronousTCPServerLibrary
{
    public class TCPServer
    {
        public delegate void onConnectEvent(Socket socket);
        public delegate void onDataReceivedEvent(string message);
        public delegate void onDisconnectEvent(Socket socket);

        private static volatile bool run = true;
        private static Socket listener;

        public static HashSet<Socket> clients = new HashSet<Socket>();

        public static event onDataReceivedEvent onDataReceived;
        public static event onConnectEvent onConnect;
        public static event onDisconnectEvent onDisconnect;


        public static void startListeningInSeperateThread(int port, int backlog)
        {
            new Thread(() => StartListening(port, backlog)).Start();
        }

        public static void StartListening(int port, int backlog)
        {
            run = true;
            var localEndPoint = new IPEndPoint(IPAddress.Any, port);

            listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(backlog);

                while (run)
                {
                    Debug.WriteLine("Waiting for a connection...");
                    Socket socket = null;
                    try
                    {
                        socket = listener.Accept();

                        clients.Add(socket);
                        new Thread(() => receive(socket)).Start();
                        if (onConnect != null)
                            onConnect.Invoke(socket);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public static void closeServer()
        {
            run = false;
            try
            {
                listener.Close();
                kickAll();
            }
            catch (Exception)
            {
            }
        }

        public static void send(Socket socket, string message)
        {
            socket.Send(Encoding.ASCII.GetBytes(message));
        }

        public static void sendln(Socket socket, string message)
        {
            send(socket, message + Environment.NewLine);
        }

        public static void broadcast(string message)
        {
            foreach (var socket in clients)
                send(socket, message);
        }

        public static void broadcastln(string message)
        {
            foreach (var socket in clients)
                sendln(socket, message);
        }

        public static void kick(Socket socket)
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception)
            {
            }
            socket.Close();
        }

        public static void kickAll()
        {
            foreach (var socket in clients)
                kick(socket);
        }

        private static void receive(Socket socket)
        {
            var bytes = new byte[1024];
            while (run)
            {
                int rec;
                try
                {
                    rec = socket.Receive(bytes);

                    if (rec == 0)
                    {
                        if (onDisconnect != null)
                            onDisconnect.Invoke(socket);
                        kick(socket);

                        break;
                    }
                    if (onDataReceived != null)
                        onDataReceived.Invoke(Encoding.ASCII.GetString(bytes, 0, rec));
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
    }
}