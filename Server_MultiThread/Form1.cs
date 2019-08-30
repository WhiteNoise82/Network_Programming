using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Server_MultiThread
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void AcceptClient()
        {
            /// 네트웍 접속 대시 구현
            /// 접속이 이루어진 후에도 다른 클라이언트가 붙을때를 위해 반복문 안에 구현
            /// 클라이언트가 붙을때 클라이언트의 주소를 리스트박스에 기록

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                if (tcpClient.Connected)
                {
                    string str = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    lboxClientList.Items.Add(str);
                }

                /// 접속이 이루어 진 후 데이터를 보내고 받는 부분을 또 하나의 스레드로 구현
                /// EchoServer 라는 클래스 객체가 TcpClient 객체를 받아 NetworkStream 수행
                /// EchoServer의 객체를 생성할때 tcpClient를 EchoServer 객체의 생성자로 넘김
                /// EchoServer 클래스의 Process 메소드를 스레드로 돌림
                /// echoServer.Process 메소드는 NetworkStream이 구현됨 

                EchoServer echoServer = new EchoServer(tcpClient);
                Thread th = new Thread(new ThreadStart(echoServer.Process));
                th.IsBackground = true;
                th.Start();

                //EchoServer echoServer = new EchoServer();
                //Thread th = new Thread(new ThreadStart(echoServer.Process));
                //th.IsBackground = true;
                //th.Start(tcpClient);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(3000);
            tcpListener.Start();

            #region
            //현재 서버의 ip주소 검색

            IPHostEntry iPHost = Dns.GetHostEntry(Dns.GetHostName());

            for (int i = 0; i < iPHost.AddressList.Length; i++)
            {
                if (iPHost.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    txtServerIP.Text = iPHost.AddressList[i].ToString();
                    break;
                }
            }

            #endregion
        }

        private void BtnServerStart_Click(object sender, EventArgs e)
        {
            /// 버튼을 클릭하면 하나의 스레드를 돌림 (스레드함수: AcceptClient)
            /// AcceptClient에서 네트웍 접속 대기 구현
            
            Thread th = new Thread(new ThreadStart(AcceptClient));
            th.IsBackground = true;
            th.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tcpListener!=null)
            {
                tcpListener.Stop();
                tcpListener = null;
            }
        }
    }

    class EchoServer
    {
        /// <summary>
        /// 데이터 전송 기능 구현
        /// </summary>
        /// EchoServer사 생성될때 받는 TcpClient를 RefClient로 전역 설정
        /// try...catch를 사용하여 데이터 읽고 쓰기 간의 예외 처리
        /// 데이터를 주고 받기를 반복
        /// SocketException은 연결이 끊어졌을때의 예외
        /// IOException은 데이터 전송간 오류가 생겼을때의 예외

        TcpClient RefClient;

        private BinaryReader br = null;
        private BinaryWriter bw = null;

        int iValue;
        float fValue;
        string sValue;

        public EchoServer(TcpClient client)
        {
            RefClient = client;
        }

        public void Process()
        {
            NetworkStream ns = RefClient.GetStream();

            try
            {
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);

                while (true)
                {
                    iValue = br.ReadInt32();
                    fValue = br.ReadSingle();
                    sValue = br.ReadString();

                    bw.Write(iValue);
                    bw.Write(fValue);
                    bw.Write(sValue);
                }
            }
            catch(SocketException se)
            {
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                RefClient.Close();
                Thread.CurrentThread.Abort();
                MessageBox.Show("전송이 완료되었습니다.");
            }
            catch(IOException ex)
            {
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                RefClient.Close();
                Thread.CurrentThread.Abort();
                MessageBox.Show("연결이 끊어졌습니다.");
            }
        }
    }
}
