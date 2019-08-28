using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        private TcpClient tcpClient = null;
        private NetworkStream ns;
        private BinaryReader br;
        private BinaryWriter bw;

        int intValue;
        float floatValue;
        string strValue;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient(txtServerIP.Text, 3000);
            if (tcpClient.Connected)
            {
                ns = tcpClient.GetStream();
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);
                MessageBox.Show("서버 접속 성공");
            }
            else
            {
                MessageBox.Show("서버 접속 실패");
            }
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            bw.Write(int.Parse(txtInt.Text));
            bw.Write(float.Parse(txtFloat.Text));
            bw.Write(txtString.Text);

            intValue = br.ReadInt32();
            floatValue = br.ReadSingle();
            strValue = br.ReadString();

            string str = intValue + "/" + floatValue + "/" + strValue;
            MessageBox.Show(str);

            lboxReceivedData.Items.Add(intValue);
            lboxReceivedData.Items.Add(floatValue);
            lboxReceivedData.Items.Add(strValue);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bw.Write(-1);
            bw.Close();
            br.Close();
            ns.Close();
            tcpClient.Close();
        }
    }
}
