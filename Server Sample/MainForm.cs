using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Sample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            TCPServer.onConnect += connected;
            TCPServer.onDisconnect += disconnected;
            TCPServer.onDataReceive += received;
        }


        private void send_btn_Click(object sender, EventArgs e)
        {
            if (send_cbox.Checked)
            {
                TCPServer.broadcastln(send_txt.Text);
                console_txt.AppendText("Server: " + send_txt.Text + Environment.NewLine + Environment.NewLine);
            }
            else
            {
                TCPServer.broadcast(send_txt.Text);
                console_txt.AppendText("Server: " + send_txt.Text + Environment.NewLine);
            }
        }

        private void appendData(string data)
        {
            Func<int> l = delegate ()
            {
                console_txt.AppendText(data + Environment.NewLine);
                return 0;
            };
            try
            {
                Invoke(l);
            }
            catch (Exception) { }

        }

        private void updateUIOnConnect(Boolean connected)
        {
            Func<int> l = delegate ()
            {
                if (connected)
                {
                    connect_btn.Text = "Server closed";
                    Connection_lbl.Text = "Server listening";
                    Connection_lbl.ForeColor = Color.LawnGreen;
                    port_txt.Enabled = false;

                    broadcast_btn.Enabled = true;
                    send_txt.Enabled = true;
                }
                else
                {
                    connect_btn.Text = "Server listening";
                    Connection_lbl.Text = "Server closed";
                    Connection_lbl.ForeColor = Color.Red;
                    port_txt.Enabled = true;

                    broadcast_btn.Enabled = false;
                    send_txt.Enabled = false;
                }
                return 0;
            };
            Invoke(l);
        }

        private void connect_btn_Click(object sender, EventArgs e)
        {
            if (connect_btn.Text.Equals("Server closed"))
            {
                updateUIOnConnect(false);
                try
                {
                    TCPServer.closeServer();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
            else
            {
                TCPServer.startListeningInSeperateThread(Int32.Parse(port_txt.Text), 10);
                updateUIOnConnect(true);
            }
        }


        private void received(string message, byte[] receivedBytes, int count)
        {
            appendData("Client: " + message);
        }

        private void connected(Socket socket)
        {
            appendData("Client " + socket.LocalEndPoint + " Connected.");
        }

        private void disconnected(Socket socket)
        {
            appendData("Client " + socket.LocalEndPoint + " Disconnected.");
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            TCPServer.closeServer();

            base.OnFormClosing(e);
        }
    }
}
