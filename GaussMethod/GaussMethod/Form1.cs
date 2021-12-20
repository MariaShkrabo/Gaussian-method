using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GaussMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread splashThread = new Thread(new ThreadStart(StartSplashForm));
            splashThread.Start();
            Thread.Sleep(5000);
            splashThread.Abort();
            InitializeComponent();
        }

        private bool serverAccesing = false;
        private bool done = false;
        private string msg = "";

        private void StartSplashForm()
        {
            Application.Run(new SplashForm());
        }

        Matrix m;
        FormShowAnswer answerForm;
        saveForm save = new saveForm();

        private void buttonCheck(int varQuantity)
        {
            if (varQuantity <= 2)
            {
                lessButton.Enabled = false;
            }
            if (varQuantity > 2 && varQuantity < 6)
            {
                lessButton.Enabled = true;
                moreButton.Enabled = true;
            }
            if (varQuantity >= 6)
            {
                moreButton.Enabled = false;
            }
        }

        private void drawBracket(int varQuantity)
        {
            PictureBox picture = new PictureBox();
            picture.Image = Properties.Resources.brack;
            picture.Location = new Point(20, 20);
            picture.SizeMode = PictureBoxSizeMode.StretchImage; //масштабируем изображение
            //с увеличением количества строк должна увеличиваться в высоту фигурная скобка
            //аналогичная завись представлена в комментарии ниже
            picture.Size = new Size(25, 80 + (varQuantity - 2) * 50);
            /*
            if (varQuantity == 2)
            {
                picture.Size = new Size(25, 80);
            }else if (varQuantity == 3)
            {
                picture.Size = new Size(25, 130);
            }
            else if (varQuantity == 4)
            {
                picture.Size = new Size(25, 180);
            }
            else if (varQuantity == 5)
            {
                picture.Size = new Size(25, 230);
            }
            else if (varQuantity == 6)
            {
                picture.Size = new Size(25, 280);
            }
            */
            panel2.Controls.Add(picture);
        }

        private void moreButton_Click(object sender, EventArgs e)
        {
            int varQuantity;
            int.TryParse(varNumber.Text, out varQuantity);
            varQuantity++;
            buttonCheck(varQuantity);
            varNumber.Text = varQuantity.ToString();
            buildSystem(varQuantity);
        }

        private void lessButton_Click(object sender, EventArgs e)
        {
            int varQuantity;
            int.TryParse(varNumber.Text, out varQuantity);
            varQuantity--;
            buttonCheck(varQuantity);
            varNumber.Text = varQuantity.ToString();
            buildSystem(varQuantity);
        }

        private void buildSystem(int varQuantity)
        {
            int rows, columns;
            rows = varQuantity;
            byte x = 120;
            byte y = 50;
            columns = varQuantity + 1;
            TextBox[,] tb = new TextBox[rows, columns];
            Label[,] lb = new Label[rows, columns];

            panel2.Controls.Clear();//очищает панель


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //последнему значению не нужен коэффициент
                    if (j < columns - 2)
                    {
                        lb[i, j] = new Label()
                        {
                            Name = "cellName" + (i + 1).ToString() + (j + 1).ToString(),
                            Location = new Point(117 + x * j, 25 + y * i),
                            Size = new Size(53, 27),
                            Text = "X" + (j + 1).ToString() + "     +  ",
                            //Text = "X" + (i + 1).ToString() + (j + 1).ToString() + "     +  ",
                            BackColor = Color.Transparent,
                            
                        };
                    }
                    else if (j == columns - 2) // предпоследний коэффициен - со знаком равно
                    {
                        lb[i, j] = new Label()
                        {
                            Name = "cellName" + (i + 1).ToString() + (j + 1).ToString(),
                            Location = new Point(117 + x * j, 25 + y * i),
                            Size = new Size(53, 27),
                            Text = "X" + varQuantity.ToString() + "     =  ",
                            //Text = "X" + (i + 1).ToString() + (j + 1).ToString() + "     =  ",
                            BackColor = Color.Transparent
                        };
                    }

                    tb[i, j] = new TextBox()
                    {
                        Name = "cell" + (i + 1).ToString() + (j + 1).ToString(),
                        Location = new Point(60 + x * j, 23 + y * i),
                        Size = new Size(50, 30),
                        Text = "0",

                    };
                    panel2.Controls.Add(lb[i, j]);
                    panel2.Controls.Add(tb[i, j]);
                    drawBracket(varQuantity);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //убираем границы у всех кнопок
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.BackColor = Color.Transparent;

            buttonHelp.FlatAppearance.BorderSize = 0;
            buttonHelp.FlatStyle = FlatStyle.Flat;
            buttonHelp.BackColor = Color.Transparent;

            lessButton.FlatAppearance.BorderSize = 0;
            lessButton.FlatStyle = FlatStyle.Flat;
            lessButton.BackColor = Color.Transparent;

            moreButton.FlatAppearance.BorderSize = 0;
            moreButton.FlatStyle = FlatStyle.Flat;
            moreButton.BackColor = Color.Transparent;

            calculateButton.FlatAppearance.BorderSize = 0;
            calculateButton.FlatStyle = FlatStyle.Flat;
            calculateButton.BackColor = Color.Transparent;

            autoFill.FlatAppearance.BorderSize = 0;
            autoFill.FlatStyle = FlatStyle.Flat;
            autoFill.BackColor = Color.Transparent;

            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.BackColor = Color.Transparent;

            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.BackColor = Color.Transparent;

            buttonShow.FlatAppearance.BorderSize = 0;
            buttonShow.FlatStyle = FlatStyle.Flat;
            buttonShow.BackColor = Color.Transparent;

            buildSystem(2);
            varNumber.BackColor = Color.Transparent;
        }

        private void matrixFill(int varQuantity, int rows, int columns, Matrix m, double[,] tempMatrix)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    m.matrix[i, j] = double.Parse(panel2.Controls["cell" + (i + 1).ToString() + (j + 1).ToString()].Text); //заполняем матрицу значениями из textbox 
                    tempMatrix[i, j] = m.matrix[i, j];
                }
            }
        }

        private void serverFill(int varQuantity, int rows, int columns)
        {
            m = new Matrix(rows, columns);//создаём объект матрица
            Client client = new Client();
            //вызываем из клиента метод, который заполняет значениями матрицу
            client.GetElements(varQuantity, m, false);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    //заполняем textbox-ы значениями из автоматически заполненной матрицы
                    panel2.Controls["cell" + (i + 1).ToString() + (j + 1).ToString()].Text = m.matrix[i, j].ToString();
                }
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            int varQuantity;
            int.TryParse(varNumber.Text, out varQuantity);
            int rows, columns;
            rows = varQuantity;
            columns = (varQuantity + 1);

            TextBox[,] tb = new TextBox[rows, columns];
            double [,] tempMatrix = new double[rows, columns];

            m = new Matrix(rows, columns);//создаём объект матрица
            try
            {
                matrixFill(varQuantity, rows, columns, m, tempMatrix);

                if (serverAccesing)
                {
                    serverAccesing = false;
                }
                showAnswer(varQuantity, m);
            }
            catch (Exception)
            {
                MessageBox.Show("Некорректное заполнение полей.", "Сообщение");
                return;
            }
            buttonSave.Visible = true;
            buttonShow.Visible = true;
            this.BackgroundImage = Properties.Resources.finalBack;
        }

        private void showAnswer(int varQuantity, Matrix m)
        {
            answerForm = new FormShowAnswer();
            msg = "Система:\r\n";
            double[] Answer = new double[varQuantity];
            Answer = m.getUnknownValues();

            //вывод системы
            for (int i = 0; i < varQuantity; i++)
            {
                for (int j = 0; j < varQuantity + 1; j++)
                {
                    if (j == varQuantity)
                    {
                        //только значение без коэфициента
                        msg += panel2.Controls["cell" + (i + 1).ToString() + (j + 1).ToString()].Text;
                    }
                    //после предпоследнего значения нужен знак равно, а не плюс
                    else if (j == varQuantity-1)
                    {
                        msg += panel2.Controls["cell" + (i + 1).ToString() + (j + 1).ToString()].Text + " X" + (j + 1) + "  =  ";
                    }
                    //если следующее число без знака минус, то просто ставим плюс, чтобы не получилос +-число
                    else if (double.Parse(panel2.Controls["cell" + (i + 1).ToString() + (j + 2).ToString()].Text) >= 0)
                    {
                        msg += panel2.Controls["cell" + (i + 1).ToString() + (j + 1).ToString()].Text + " X" + (j+1) + "  +  ";
                    }
                    //если следующее число со знаком минус, то ничего не ставим 
                    else if (double.Parse(panel2.Controls["cell" + (i + 1).ToString() + (j + 2).ToString()].Text) < 0)
                    {
                        msg += panel2.Controls["cell" + (i + 1).ToString() + (j + 1).ToString()].Text + " X" + (j + 1) + "  ";
                    }
                }
                msg += "\r\n";
            }

            msg += "\r\nОтветы:";

            //вывод ответов
            for (int i = 0; i < varQuantity; i++)
            {
                //выводим ответ, если число неравно NaN
                if (!(Double.IsNaN(Answer[i])))
                {
                    msg += " \nX" + (i + 1) + " = " + Answer[i];
                }
                else
                {
                    msg += " \nX" + (i + 1) + " не имеет корректного значения ";
                }               
            }
            answerForm.labelText = msg;
            answerForm.Show();
        }

        private void autoFill_Click(object sender, EventArgs e)
        {
            serverAccesing = true;
            int varQuantity, rows, columns;
            int.TryParse(varNumber.Text, out varQuantity);
            rows = varQuantity;
            columns = varQuantity + 1;
            serverFill(varQuantity, rows, columns);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            done = true;
            int varQuantity;
            Client client = new Client();
            int.TryParse(varNumber.Text, out varQuantity);
            //если мы не использовали автозаполнение(не подключались к серверу), то нет смысла вызывать клиент
            /*
            if (serverAccesing)
            {
                client.GetElements(varQuantity, m, done);
            }
            */
            client.GetElements(varQuantity, m, done);
            this.Close();
            
        }

        //функция для того, чтобы двигать форму курсором, так как FormBorderStyle = None
        private Point MouseHook;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            int varQuantity;
            int.TryParse(varNumber.Text, out varQuantity);
            for (int i = 0; i < varQuantity; i++)
            {
                for (int j = 0; j < varQuantity + 1; j++)
                {
                    panel2.Controls["cell" + (i + 1).ToString() + (j + 1).ToString()].Text = "";
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int varQuantity;
            int.TryParse(varNumber.Text, out varQuantity);
            int rows, columns;
            rows = varQuantity;
            columns = (varQuantity + 1);

            m = new Matrix(rows, columns);//создаём объект матрица
            double[,] tempMatrix = new double[rows, columns];
            matrixFill(varQuantity, rows, columns, m, tempMatrix);


            save = new saveForm();
            //передаем результаты для сохранения
            save.getText(msg);
            save.getVarQuantity(varQuantity);

            //передаем матрицу для сохранения в Excel
            save.getMatrix(tempMatrix);

            double[] Answer = new double[varQuantity];
            Answer = m.getUnknownValues();
            save.getResultArray(Answer);

            save.Show();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            answerForm = new FormShowAnswer();
            answerForm.labelText = msg;
            answerForm.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Files\\2 курс\\Разработка приложений\\4 семестр\\Курсовая работа\\FinalCourseWork\\GaussMethod\\Helper.pdf");
            
        }
    }
}
