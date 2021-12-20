using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;


namespace GaussServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpListener listener; // создаём объект класса TcpListener, чтобы слушать соединение с клиентом
        private TcpClient client;
        private NetworkStream stream;
        private BinaryReader reader;
        private BinaryWriter writer;
        private bool done = false; // true если клиент отключился

        private void Form1_Load(object sender, EventArgs e)
        {
            box.Text = "Данные будут доступны после завершения соединения...\r\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // создаем экземпляр класса TcpListener
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 50001);
                listener.Start();
                      
                while (!done)
                {
                    client = listener.AcceptTcpClient();
                    stream = client.GetStream();
                    writer = new BinaryWriter(stream);
                    reader = new BinaryReader(stream);
                    done = reader.ReadBoolean();
                    if (!done)
                    {
                        Run();
                    }
                }
                writer.Close();
                reader.Close();
            }
            catch
            {
                box.Text += "Соединение прервано.\r\n";
            }
        }

        public void Run()
        {
            double number;
            string message = reader.ReadString();
            box.Text += message + "\r\n";
            int varQuantity = reader.ReadInt32();
            box.Text += "Количество неизвестных в СЛАУ = " + varQuantity.ToString() + "\r\n";
            writer.Write("Количество неизвестных в СЛАУ получено.");

            Random x = new Random();
            box.Text += "Отправляем матрицу:\r\n";
            for (int i = 0; i < varQuantity; i++)
            {               
                for (int j = 0; j < varQuantity + 1; j++)
                {
                    number = Convert.ToDouble(x.Next(-100, 100) / 10.0);
                    writer.Write(number);
                    box.Text += number + "\t";
                }
                box.Text += "\r\n";
            }
            box.Text += "Матрица получена.\r\n";
        }

    }
}
