using System;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Xceed.Words.NET;

namespace GaussMethod
{
    public partial class saveForm : Form
    {
        public saveForm()
        {
            InitializeComponent();
        }

        private string msg;
        private int varNumber;
        private double[,] matrix1 = new double[2, 3];
        private double[,] matrix2 = new double[3, 4];
        private double[,] matrix3 = new double[4, 5];
        private double[,] matrix4 = new double[5, 6];
        private double[,] matrix5 = new double[6, 7];

        private double[] array1 = new double[2];
        private double[] array2 = new double[3];
        private double[] array3 = new double[4];
        private double[] array4 = new double[5];
        private double[] array5 = new double[6];

        //функция для того, чтобы двигать форму курсором, так как FormBorderStyle = None
        private Point MouseHook;

        private void saveForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void saveForm_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonWord_Click(object sender, EventArgs e)
        {
            //Сохранение в WORD
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Документы Word(*. docx)|*.docx|Все файлы (*.*)|*.*";
            sfd.ShowDialog();
            string path = sfd.FileName;

            DocX document = DocX.Create(path);

            // вставляем параграф и передаём текст
            document.InsertParagraph(msg).
                     // устанавливаем шрифт
                     Font("Calibri").
                     // устанавливаем размер шрифта
                     FontSize(15).
                     // устанавливаем цвет
                     Color(Color.Black).
                     // делаем текст жирн ым
                     Bold().
                     // устанавливаем интервал между символами
                     Spacing(1).
                     // выравниваем текст по центру
                     Alignment = Alignment.left;
            // сохраняем документ
            document.Save();
            MessageBox.Show("Результаты сохранены", "Сообщение");
        }

        public string getText(string textFromMainForm)
        {
            msg = textFromMainForm;
            return msg;
        }

        public int getVarQuantity(int varFromMainForm)
        {
            varNumber = varFromMainForm;
            return varNumber;
        }

        public void getMatrix(double[,] matrixFromMainForm)
        {
            for (int i = 0; i < varNumber; i++)
            {
                for (int j = 0; j < varNumber+1; j++)
                {
                    if (varNumber == 2)
                        matrix1[i, j] = matrixFromMainForm[i, j];
                    else if (varNumber == 3)
                        matrix2[i, j] = matrixFromMainForm[i, j];
                    else if (varNumber == 4)
                        matrix3[i, j] = matrixFromMainForm[i, j];
                    else if (varNumber == 5)
                        matrix4[i, j] = matrixFromMainForm[i, j];
                    else if (varNumber == 6)
                        matrix5[i, j] = matrixFromMainForm[i, j];
                }
            }
        }

        public void getResultArray(double[] arrayFromMainForm)
        {
            for (int i = 0; i < varNumber; i++)
            {
                if (varNumber == 2)
                    array1[i] = arrayFromMainForm[i];
                else if (varNumber == 3)
                    array2[i] = arrayFromMainForm[i]; 
                else if (varNumber == 4)
                    array3[i] = arrayFromMainForm[i]; 
                else if (varNumber == 5)
                    array4[i] = arrayFromMainForm[i];
                else if (varNumber == 6)
                    array5[i] = arrayFromMainForm[i];
            }
        }

        private void buttonExel_Click(object sender, EventArgs e)
        {
            //Сохранение в EXCEL
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Документы Excel(*. xls)|*.xls|Все файлы (*.*)|*.*";
            sfd.ShowDialog();
            string path = sfd.FileName;
            
            // Создаём экземпляр нашего приложения
            Excel.Application excelApp = new Excel.Application();

            // Создаём экземпляр рабочий книги Excel
            Excel.Workbook workBook;
            // Создаём экземпляр листа Excel
            Excel.Worksheet workSheet;

            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            workSheet.Cells[1, 1] = "Матрица:";

            for (int i = 0, exel_i = 2; i < varNumber; i++, exel_i++)
            {
                for (int j = 0, exel_j = 1; j < varNumber + 1; j++, exel_j++)
                {
                    if (varNumber == 2)
                        workSheet.Cells[exel_i, exel_j] = matrix1[i, j];
                    else if (varNumber == 3)
                        workSheet.Cells[exel_i, exel_j] = matrix2[i, j];
                    else if (varNumber == 4)
                        workSheet.Cells[exel_i, exel_j] = matrix3[i, j];
                    else if (varNumber == 5)
                        workSheet.Cells[exel_i, exel_j] = matrix4[i, j];
                    else if (varNumber == 6)
                        workSheet.Cells[exel_i, exel_j] = matrix5[i, j];
                }
            }

            workSheet.Cells[varNumber + 2, 1] = "Ответ:";
            for (int i = 0, exel_i = varNumber + 3; i < varNumber; i++, exel_i++)
            {
                workSheet.Cells[exel_i, 1] = "X" + (i+1).ToString();
                if (varNumber == 2)
                    workSheet.Cells[exel_i, 2] = array1[i];
                else if (varNumber == 3)
                    workSheet.Cells[exel_i, 2] = array2[i];
                else if (varNumber == 4)
                    workSheet.Cells[exel_i, 2] = array3[i];
                else if (varNumber == 5)
                    workSheet.Cells[exel_i, 2] = array4[i];
                else if (varNumber == 6)
                    workSheet.Cells[exel_i, 2] = array5[i];
            }

            excelApp.DefaultFilePath = path;
            excelApp.DisplayAlerts = false;
            workBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Excel.XlSaveAsAccessMode.xlExclusive,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing);
            excelApp.Quit();
            MessageBox.Show("Результаты сохранены", "Сообщение");
        }
    }
}
