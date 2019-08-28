using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ServerForm
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;
        private TcpClient tcpClient = null;
        private NetworkStream ns = null;
        private BinaryReader br = null;
        private BinaryWriter bw = null;

        int intValue;
        float floatValue;
        string strValue;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(3000);
            tcpListener.Start();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    txtServerIP.Text = host.AddressList[i].ToString();
                    break;
                }
            }
        }

        private void BtnConnectStart_Click(object sender, EventArgs e)
        {
            tcpClient = tcpListener.AcceptTcpClient();
            if (tcpClient.Connected)
            {
                txtConnectIP.Text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            }

            ns = tcpClient.GetStream();
            bw = new BinaryWriter(ns);
            br = new BinaryReader(ns);
        }

        private void BtnTransferStart_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (tcpClient.Connected)
                {
                    if (DataReceive() == -1)
                    {
                        break;
                    }
                    DataSend();
                }
                else
                {
                    AllClose();
                    break;
                }
            }
            AllClose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AllClose();
            tcpListener.Stop();
        }

        private int DataReceive()
        {
            intValue = br.ReadInt32();
            if (intValue == -1)
            {
                return -1;
            }

            floatValue = br.ReadSingle();
            strValue = br.ReadString();
            string str = intValue + "/" + floatValue + "/" + strValue;
            MessageBox.Show(str);
            return 0;
        }

        private void DataSend()
        {
            bw.Write(intValue);
            bw.Write(floatValue);
            bw.Write(strValue);

            MessageBox.Show("보냈습니다.");
        }

        private void AllClose()
        {
            if (bw != null)
            {
                bw.Close();
                bw = null;
            }

            if (br != null)
            {
                br.Close();
                br = null;
            }

            if (ns != null)
            {
                ns.Close();
                ns = null;
            }

            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
            }
        }
    }
}