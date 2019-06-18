using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class Classmath
    {
        public int[] arr;
        /// <summary>
        /// математическое ожидание
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public double Math_exp(int [] arr)
        {
            return arr.Sum() / arr.Length;
        }

        /// <summary>
        /// дисперсия
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public double Dispersion(int [] arr)
        {
            double SumD = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                SumD += Math.Pow((arr[i] - arr.Sum() / arr.Length), 2.0);
            }
            return SumD / arr.Length;
        }
        /// <summary>
        /// среднеквадратическое отклонение 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
       public double StandardDeviation(int [] arr)
        {
            double SumD = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                SumD += Math.Pow((arr[i] - arr.Sum() / arr.Length), 2.0);

            }
            return Math.Sqrt(SumD / arr.Length);
        }
        /// <summary>
        /// Средняя длина слова
        /// </summary>
        public int CountWords(string[] words)
        {
            int SumWords = 0;
            int countWords = 0;
            foreach (var word in words)
            {
                if (word == " ") { }
                else if (word.Contains(" ")) { SumWords += word.Length - 1; countWords++; }
                else
                {
                    countWords++;
                    SumWords += word.Length;
                }
            }
            return SumWords / countWords;
        }
        /// <summary>
        /// наиболее повторяющийся символ
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int Symbol(int [] arr)
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    index = i;
                }
            }
            return index;
        }
        /// <summary>
        /// Максимальное количество повторяния символа
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MAxKol (int[] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }
    }
}
