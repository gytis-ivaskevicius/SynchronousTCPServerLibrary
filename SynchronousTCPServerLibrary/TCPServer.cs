using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class TCPServer
{
    private static volatile bool _run = true;
    private static Socket _listener;
    public static List<Socket> clients = new List<Socket>();

    public delegate void onConnectEvent(Socket socket);
    public delegate void onDataReceivedEvent(string message, byte[] receivedBytes, int count);
    public delegate void onDisconnectEvent(Socket socket);

    public static event onDataReceivedEvent onDataReceive;
    public static event onConnectEvent onConnect;
    public static event onDisconnectEvent onDisconnect;

    public static void startListeningInSeperateThread(int port, int backlog)
    {
        new Thread(() => StartListening(port, backlog)).Start();
    }

    public static void StartListening(int port, int backlog)
    {
        _run = true;
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, port);

        _listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

        try
        {
            _listener.Bind(localEndPoint);
            _listener.Listen(backlog);

            while (_run)
            {
                Debug.WriteLine("Waiting for a connection...");
                Socket socket = null;
                try
                {
                    socket = _listener.Accept();

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
        _run = false;
        try
        {
            _listener.Close();
            kickAll();
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.ToString());
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
        foreach (Socket socket in clients)
            send(socket, message);
    }

    public static void broadcastln(string message)
    {
        foreach (Socket socket in clients)
            sendln(socket, message);
    }

    public static void kick(Socket socket)
    {
        try
        {
            socket.Shutdown(SocketShutdown.Both);
        }
        catch (Exception) { }
        socket.Close();
        clients.Remove(socket);
    }

    public static void kickAll()
    {
        foreach (Socket socket in clients)
            kick(socket);
    }

    private static void receive(Socket socket)
    {
        byte[] bytes = new byte[1024];
        while (_run)
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
                if (onDataReceive != null)
                    onDataReceive.Invoke(Encoding.ASCII.GetString(bytes, 0, rec),bytes, rec);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                if (onDisconnect != null)
                    onDisconnect.Invoke(socket);
                kick(socket);
                break;
            }
        }
    }
}