using System;

namespace ConsoleApp1
{
    public delegate void SortingHandler();
    public class Sorting
    {
        int typeOfSorting; // Тип сортировки 
        int[,] matrix; // Матрица
        int[] arr; // Вспомогательный массив (для разных сортировок будет разный массив)

        public Sorting(int typeOfSorting, int[,] matrix)
        {
            this.typeOfSorting = typeOfSorting;
            this.matrix = matrix;

            arr = new int[matrix.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                arr[i] = 0;
            }
        }

        public void SelectSort()
        {
            switch(typeOfSorting)
            {
                case 1: // В порядке возрастания сумм элементов строк матрицы
                    arr = CreateArraySum(matrix);
                    SortIncrease(arr, matrix);
                    break;
                case 2: // В порядке убывания сумм элементов строк матрицы
                    arr = CreateArraySum(matrix);
                    SortDecrease(arr, matrix);
                    break;
                case 3: // По возрастанию максимального элемента в строке матрицы
                    arr = CreateArrayMax(matrix);
                    SortIncrease(arr, matrix);
                    break;
                case 4: // По убыванию максимального элемента в строке матрицы
                    arr = CreateArrayMax(matrix);
                    SortDecrease(arr, matrix);
                    break;
                case 5: // В порядке возрастания минимального элемента в строке матрицы
                    arr = CreateArrayMin(matrix);
                    SortIncrease(arr, matrix);
                    break;
                case 6: // В порядке убывания минимального элемента в строке матрицы
                    arr = CreateArrayMin(matrix);
                    SortDecrease(arr, matrix);
                    break;
            }
        }

        private void SortIncrease(int[] anArray, int[,] matrix)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                for (int j = 0; j < anArray.Length - 1 - i; j++)
                {
                    if (anArray[j] > anArray[j + 1])
                    {
                        Swap(ref anArray[j], ref anArray[j + 1]);

                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            SwapTwoDimensional(ref matrix, j, k);
                        }
                    }
                }
            }
        }
        private void SortDecrease(int[] anArray, int[,] matrix)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                for (int j = 0; j < anArray.Length - 1 - i; j++)
                {
                    if (anArray[j] < anArray[j + 1])
                    {
                        Swap(ref anArray[j], ref anArray[j + 1]);
                        
                        for (int k = 0; k < matrix.GetLength(1); k++)
                        {
                            SwapTwoDimensional(ref matrix, j, k);
                        }
                    }
                }
            }
        }

        public static void SwapTwoDimensional(ref int[,] anArg, int j, int k)
        {
            var tmpParam = anArg[j, k];
            anArg[j, k] = anArg[j + 1, k];
            anArg[j + 1, k] = tmpParam;
        }

        private void Swap(ref int aFirstArg, ref int aSecondArg)
        {
            int tmpParam = aFirstArg;
            aFirstArg = aSecondArg;
            aSecondArg = tmpParam;
        }
        private int[] CreateArraySum(int[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    arr[j] += matrix[j, k];
                }
            }
            return arr;
        }
        private int[] CreateArrayMax(int[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[j, k] > arr[j])
                    {
                        arr[j] = matrix[j, k];
                        
                    }
                }
            }
            return arr;
        }

        private int[] CreateArrayMin(int[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[j, k] < arr[j])
                    {
                        arr[j] = matrix[j, k];
                    }
                }
            }
            return arr;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int rows = 5;
            int cols = 6;

            int[,] matrix = CreateMatrix(rows, cols); // Матрица заполняется рандомными числами
            
            PrintMatrix(matrix);

            Sorting mySort = new Sorting(1, matrix); // Входной параметр от 1 до 6 включительно
                                                     // 1 - В порядке возрастания сумм элементов строк матрицы
                                                     // 2 - В порядке убывания сумм элементов строк матрицы
                                                     // 3 - По возрастанию максимального элемента в строке матрицы
                                                     // 4 - По убыванию максимального элемента в строке матрицы
                                                     // 5 - В порядке возрастания минимального элемента в строке матрицы
                                                     // 6 - В порядке убывания минимального элемента в строке матрицы
            SortingHandler sortingHandler = new SortingHandler(mySort.SelectSort);
            sortingHandler();
            
            Console.WriteLine("");
            PrintMatrix(matrix);
        }

        public static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            var rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(0, 10);
                }
            }
            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write((matrix[i, j]) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}