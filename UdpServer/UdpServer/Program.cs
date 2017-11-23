using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.IO;

using DigitalIO;
using AnalogIO;
using MccDaq;
using ErrorDefs;

namespace UDP
{
    class Program
    {

        static MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(0);

        private int str_temp;
        private static MccDaq.Range Range;        //定义A/D和D/A转换范围

        const int NumPoints = 5000;     //  Number of data points to collect
        const int ArraySize = 5000;       //  size of data array
        private ushort[] DataBuffer;    //  declare data array
        string FileName;                //  name of file in which data will be stored

        AnalogIO.clsAnalogIO AIOProps = new AnalogIO.clsAnalogIO();


        int Count = NumPoints;
        //  it may be necessary to add path to file name for data file to be found
        int Rate = 1000;
        int LowChan = 0;
        int HighChan = 0;
        MccDaq.ScanOptions Options = MccDaq.ScanOptions.Default;
       


        static void Main(string[] args)
        {
            MccDaq.ErrorInfo ULStat;
            int recv;
            byte[] data = new byte[1024];

            //得到本机IP，设置TCP端口号         
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 8001);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //绑定网络地址
            newsock.Bind(ip);

            Console.WriteLine("This is a Server, host name is {0}", Dns.GetHostName());

            //等待客户机连接
            Console.WriteLine("Waiting for a client");

            //得到客户机IP
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);
            recv = newsock.ReceiveFrom(data, ref Remote);
            Console.WriteLine("Message received from {0}: ", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            int NumPorts, NumBits, FirstBit;
            int PortType, ProgAbility;
            string PortName;
            DigitalIO.clsDigitalIO DioProps = new DigitalIO.clsDigitalIO();
            //determine if digital port exists, its capabilities, etc
            PortType = clsDigitalIO.PORTOUT;
            MccDaq.DigitalPortType PortNum;
            MccDaq.DigitalPortDirection Direction;
            NumPorts = DioProps.FindPortsOfType(DaqBoard, PortType, out ProgAbility,
                out PortNum, out NumBits, out FirstBit);
            Direction = MccDaq.DigitalPortDirection.DigitalOut;
            ULStat = DaqBoard.DConfigPort(PortNum, Direction);
            if (Encoding.ASCII.GetString(data, 0, recv) == "H")
            {
                ushort VValue = 1;
                MccDaq.ErrorInfo UULStat = DaqBoard.DOut(PortNum, VValue);
                Console.WriteLine("1");
            }
            if (Encoding.ASCII.GetString(data, 0, recv) == "L")
            {
                ushort VValue = 0;
                MccDaq.ErrorInfo UULStat = DaqBoard.DOut(PortNum, VValue);
                Console.WriteLine("0");
            }

            while (true)
            {
                data = new byte[1024];
                //发送接收信息
                recv = newsock.ReceiveFrom(data, ref Remote);
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
                if (Encoding.ASCII.GetString(data, 0, recv) == "H")
                {
                    ushort VValue = 1;
                    MccDaq.ErrorInfo UULStat = DaqBoard.DOut(PortNum, VValue);
                    Console.WriteLine("1");
                }
                if (Encoding.ASCII.GetString(data, 0, recv) == "L")
                {
                    ushort VValue = 0;
                    MccDaq.ErrorInfo UULStat = DaqBoard.DOut(PortNum, VValue);
                    Console.WriteLine("0");
                }
               
            }
        }

    }
}