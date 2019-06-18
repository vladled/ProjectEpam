using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp6;
namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        int[] array;
        double expected, actual;
        Classmath cm = new Classmath();
        /// <summary>
        /// Проверка математического ожидания
        /// </summary>
        [TestMethod]
        public void Mathexptest()
        {
            array = new int[4] { 1, 4, 3, 12 };
            expected = 5.0;
            actual = cm.Math_exp(array);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка Дисперсии
        /// </summary>
        [TestMethod]
        public void Dispersiontest()
        {
            array = new int[4] { 1, 4, 3, 12 };
            expected = 17.5;
            actual = cm.Dispersion(array);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка СКО
        /// </summary>
        [TestMethod]
        public void StandardDeviationtest()
        {
            array = new int[4] { 1, 4, 3, 12 };
            expected = 4.183;
            actual = Math.Round(cm.StandardDeviation(array), 3);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка среднее количество слов
        /// </summary>
        [TestMethod]
        public void CountWords()
        {
            string[] word = new string[4] { "hello", "word", "my", "young" };
            expected = 4.00;
            actual = cm.CountWords(word);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Проверка  на работоспосбность  алфавита
        /// </summary>
        [TestMethod]
        public void Symboltest()
        {
            char[,] LatinAlphabet = {
            {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' },
            {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'} };
            array = new int[4] { 1, 4, 3, 12 };
            char[,] CurrentAlphabet = LatinAlphabet;
            char act = CurrentAlphabet[1, cm.Symbol(array)];
            char expect = 'D';
            actual = cm.Symbol(array);
            Assert.AreEqual(expect, act);
        }
        /// <summary>
        /// Проверка на максимальное количество символов
        /// </summary>
        [TestMethod]
        public void MaxKoltest()
        {
            array = new int[4] { 1, 4, 3, 12 };
            expected = 12.00;
            actual = cm.MAxKol(array);
            Assert.AreEqual(expected, actual);
        }
    }
}
