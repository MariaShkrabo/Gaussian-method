using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussMethod
{
    class Matrix
    {
        public double[,] matrix = null;  //объявление объекта матрицы

        public int Column { get; private set; } //свойство, обозначающее строки
        public int Row { get; private set; } //свойство, обозначающее столбцы

        public Matrix(int x = 1, int y = 1) //конструктор
        {
            matrix = new double[x, y];
            Column = y;
            Row = x;
        }

        public double this[int x, int y] //свойство, позволяющее получить или задать элемент матрицы
        {
            get { return matrix[x, y]; }
            set { matrix[x, y] = value; }
        }

        //метод, возвращающий массив чисел (результатов расчетов методом Гаусса) из библиотеки GaussLibrary.dll
        public double[] getUnknownValues()
        {
            return GaussLibrary.GaussLibrary.GaussCalculation(matrix, Row);
        }
        

        /*
        public double[] GaussCalculation()
        {
            int n = Row; //Размерность начальной матрицы (строки)
            double[,] matrix_Clone = new double[n, n + 1]; //Матрица-дублер
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n + 1; j++)
                    matrix_Clone[i, j] = matrix[i, j];

            //Прямой ход (Зануление нижнего левого угла)
            for (int k = 0; k < n; k++) //k-номер строки
            {
                for (int i = 0; i < n + 1; i++) //i-номер столбца
                    matrix_Clone[k, i] = matrix_Clone[k, i] / matrix[k, k]; //Деление k-строки на первый член !=0 для преобразования его в единицу
                for (int i = k + 1; i < n; i++) //i-номер следующей строки после k
                {
                    double K = matrix_Clone[i, k] / matrix_Clone[k, k]; //Коэффициент
                    for (int j = 0; j < n + 1; j++) //j-номер столбца следующей строки после k
                        matrix_Clone[i, j] = matrix_Clone[i, j] - matrix_Clone[k, j] * K; //Зануление элементов матрицы ниже первого члена, преобразованного в единицу
                }
                for (int i = 0; i < n; i++) //Обновление, внесение изменений в начальную матрицу
                    for (int j = 0; j < n + 1; j++)
                        matrix[i, j] = matrix_Clone[i, j];
            }

            //Обратный ход (Зануление верхнего правого угла)
            for (int k = n - 1; k > -1; k--) //k-номер строки
            {
                for (int i = n; i > -1; i--) //i-номер столбца
                    matrix_Clone[k, i] = matrix_Clone[k, i] / matrix[k, k];
                for (int i = k - 1; i > -1; i--) //i-номер следующей строки после k
                {
                    double K = matrix_Clone[i, k] / matrix_Clone[k, k];
                    for (int j = n; j > -1; j--) //j-номер столбца следующей строки после k
                        matrix_Clone[i, j] = matrix_Clone[i, j] - matrix_Clone[k, j] * K;
                }
            }

            //Отделяем от общей матрицы ответы
            double[] Answer = new double[n];
            for (int i = 0; i < n; i++)
                Answer[i] = matrix_Clone[i, n];

            return Answer;
        }
        */
    }
}
