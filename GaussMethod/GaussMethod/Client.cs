using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaussMethod
{
    class Client
    {
        const int PORT = 50001;
        const string ADDRESS = "127.0.0.1";
        //private bool done = false; // true когда игра заканчивается
        private TcpClient client;
        private NetworkStream stream;
        private BinaryWriter writer;
        private BinaryReader reader;

        public void GetElements(int varQuantity, Matrix m, bool done)
        {
            try
            {
                client = new TcpClient(ADDRESS, PORT);
                stream = client.GetStream();

                // отправляем сообщение
                writer = new BinaryWriter(stream);

                reader = new BinaryReader(stream);
                writer.Write(done);
                if (done == false)
                {
                    Run(varQuantity, m);
                }
                reader.Close();
                writer.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Сервер не отвечает...",
                    "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (client != null)
                    client.Close();
            }
        }

        public void Run(int varQuantity, Matrix m)
        {
            string message = "Начать автозаполение.";
            writer.Write(message);
            writer.Write(varQuantity);

            if (reader.ReadString() == "Количество неизвестных в СЛАУ получено.")
            {
                for (int i = 0; i < varQuantity; i++)
                {
                    for (int j = 0; j < varQuantity + 1; j++)
                    {
                        m.matrix[i, j] = reader.ReadDouble();
                    }
                }
            }
            writer.Write("Матрица получена.");
        }
    }
}
