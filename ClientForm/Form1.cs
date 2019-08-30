using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Form1 : Form
    {
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

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtServerIP.Text.Length == 0)
                {
                    MessageBox.Show("서버의 IP주소가 입력되지 않았습니다.\n서버의 IP주소를 입력하여 주세요.");
                    return;
                }

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
            catch (SocketException se)
            {
                MessageBox.Show("서버 연결이 거부되었습니다.\n서버의 상태 또는 서버 IP 주소의 확인이 필요합니다.");
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
            if (bw != null)
            {
                bw.Write(-1);
                bw.Close();
            }

            if (br != null)
            {
                br.Close();
            }

            if (ns != null)
            {
                ns.Close();
            }

            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }
    }
}
