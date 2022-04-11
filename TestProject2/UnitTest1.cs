using NUnit.Framework;
using ConsoleApp1;

namespace TestProject2
{
    public class Tests
    {
        [Test]
        public void Test1() 
        {
            int[,] matrix = { { 3, 4, 5 }, { 0, 1, 2 }, { 6, 7, 8 } };

            Sorting mySort1 = new Sorting(1, matrix); // В порядке возрастания сумм элементов строк матрицы
            int[,] expectedResul1 = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            SortingHandler sortingHandler1 = new SortingHandler(mySort1.SelectSort);
            sortingHandler1();
            Assert.AreEqual(expectedResul1, matrix);
        }
        [Test]
        public void Test2()
        {
            int[,] matrix = { { 3, 4, 5 }, { 0, 1, 2 }, { 6, 7, 8 } };

            Sorting mySort2 = new Sorting(2, matrix); // В порядке убывания сумм элементов строк матрицы
            int[,] expectedResult2 = { { 6, 7, 8 }, { 3, 4, 5 }, { 0, 1, 2 } };
            SortingHandler sortingHandler2 = new SortingHandler(mySort2.SelectSort);
            sortingHandler2();
            Assert.AreEqual(expectedResult2, matrix);
        }
        [Test]
        public void Test3()
        {
            int[,] matrix = { { 3, 4, 5 }, { 0, 1, 2 }, { 6, 7, 8 } };

            Sorting mySort3 = new Sorting(3, matrix); // По возрастанию максимального элемента в строке матрицы
            int[,] expectedResult3 = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            SortingHandler sortingHandler3 = new SortingHandler(mySort3.SelectSort);
            sortingHandler3();
            Assert.AreEqual(expectedResult3, matrix);
        }
        [Test]
        public void Test4()
        {
            int[,] matrix = { { 3, 4, 5 }, { 0, 1, 2 }, { 6, 7, 8 } };

            Sorting mySort4 = new Sorting(4, matrix); // По убыванию максимального элемента в строке матрицы
            int[,] expectedResult4 = { { 6, 7, 8 }, { 3, 4, 5 }, { 0, 1, 2 } };
            SortingHandler sortingHandler4 = new SortingHandler(mySort4.SelectSort);
            sortingHandler4();
            Assert.AreEqual(expectedResult4, matrix);
        }
        [Test]
        public void Test5()
        {
            int[,] matrix = { { 3, 4, 5 }, { 0, 1, 2 }, { 6, 7, 8 } };

            Sorting mySort5 = new Sorting(5, matrix); // В порядке возрастания минимального элемента в строке матрицы
            int[,] expectedResult5 = { { 3, 4, 5 }, { 0, 1, 2 },{ 6, 7, 8 }  };
            SortingHandler sortingHandler5 = new SortingHandler(mySort5.SelectSort);
            sortingHandler5();
            Assert.AreEqual(expectedResult5, matrix);
        }
        [Test]
        public void Test6()
        {
            int[,] matrix = { { 3, 4, 5 }, { 0, 1, 2 }, { 6, 7, 8 } };

            Sorting mySort6 = new Sorting(6, matrix); // В порядке убывания минимального элемента в строке матрицы
            int[,] expectedResult6 = {  { 3, 4, 5 }, { 0, 1, 2 }, { 6, 7, 8 } };
            SortingHandler sortingHandler6 = new SortingHandler(mySort6.SelectSort);
            sortingHandler6();
            Assert.AreEqual(expectedResult6, matrix);
        }
    }
}