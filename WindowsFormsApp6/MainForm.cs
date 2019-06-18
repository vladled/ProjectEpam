using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp6
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Английский алфавит
        /// </summary>
        char[,] LatinAlphabet = {
            {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' },
            {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'} };
        /// <summary>
        /// Русский алфавит
        /// </summary>
        char[,] RussiansmalAlphabet = {
            { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' },
            { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' } };
        /// <summary>
        /// Украинский алфавит
        /// </summary>
        char[,] UkrainesmalAlphabet ={
            { 'а', 'б', 'в', 'г', 'ґ', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я' },
            { 'А', 'Б', 'В', 'Г', 'Ґ', 'Д', 'Е', 'Є', 'Ж', 'З', 'И', 'І', 'Ї', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ю', 'Я' }};
        Classmath math = new Classmath();
        Author author;
        string  mainText;
        /// <summary>
        /// Главная форма
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Загрузить с файла
        /// </summary>
        private void Open_Click_1(object sender, EventArgs e)
        {
            try
            {
                string fname = @"C:\s.txt";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.Title = "Открыть файл";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fname = openFileDialog1.FileName;
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                FileStream fileStream = new FileStream(fname, FileMode.Open);
                StreamReader file = new StreamReader(fileStream, Encoding.Default);
                string[] text = file.ReadToEnd().Split(' ');
            }
            catch (Exception ex) // если исключение, то выводим ошибку 
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        /// <summary>
        /// Запуск частотного анализа
        /// </summary>
        private void Analize_Click(object sender, EventArgs e)
        {
            
                string text = richTextBox1.Text;
                char[] chars = mainText.ToCharArray();
                Series series = new Series();
                int[] freq = new int[0];
                char[,] CurrentAlphabet = null;
                int lenght = 0;
                int c = 0;
                listView1.Items.Clear();

                if (checkedListBox2.SelectedIndex == 0)
                {
                    CurrentAlphabet = LatinAlphabet; ;
                    lenght = 23;

                }
                else if (checkedListBox2.SelectedIndex == 1)
                {
                    CurrentAlphabet = UkrainesmalAlphabet;
                    lenght = 33;

                }
                else if (checkedListBox2.SelectedIndex == 2)
                {

                    CurrentAlphabet = RussiansmalAlphabet;
                    lenght = 33;
                }

                freq = new int[lenght];
                for (int i = 0; i < lenght; i++)
                {
                    c = 0;
                    for (int k = 0; k < chars.Length; k++)
                    {
                        if (CurrentAlphabet[0, i] == chars[k] || CurrentAlphabet[1, i] == chars[k])
                        {
                            c++;
                        }

                    }
                    freq[i] = c;
                
               
            double p = Convert.ToDouble(c) / Convert.ToDouble(chars.Length);
                    listView1.Items.Add(new ListViewItem(new string[] { CurrentAlphabet[1, i].ToString(), Convert.ToString(c), Convert.ToString(Math.Round(p, 4)) }));
                    series.Points.AddXY(CurrentAlphabet[1, i] + "", p);
                }
                label1.Text = "Число знаков в тексте : " + mainText.Length;
                label2.Text = "Mатематическое ожидание : " + math.Math_exp(freq)/*freq.Sum() / lenght*/;
                label3.Text = "Наиболее часто встречающихся символ " + CurrentAlphabet[1, math.Symbol(freq)] + " ( " + math.MAxKol(freq) + " раз )";
                label4.Text = "Дисперсия: " + math.Dispersion(freq);
                label5.Text = "СКО: " + math.StandardDeviation(freq);
                string[] words = mainText.Split(' ');
                label6.Text = "Средняя длина слова: " + math.CountWords(words) /*SumWords / countWords*/;
                DiagramForm diagramForm = new DiagramForm(series);
                diagramForm.Show();
            
           
        }








        /// <summary>
        /// Выбор  алфавита
        /// </summary>
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        { 
                int sel = checkedListBox2.SelectedIndex;
                checkedListBox2.SetItemChecked(0, false);
                checkedListBox2.SetItemChecked(1, false);
                checkedListBox2.SetItemChecked(2, false);
                checkedListBox2.SetItemChecked(sel, true);
            
            
        }

        /// <summary>
        /// Сохранение в файл
        /// </summary>
        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)

            {

                StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);

                foreach (ListViewItem item in listView1.Items)
                {
                    streamWriter.WriteLine(item.SubItems[0].Text + " " + item.SubItems[1].Text + " " + item.SubItems[2].Text);

                }

                streamWriter.Close();

            }
        }




        /// <summary>
        /// Вызов окна об авторе
        /// </summary>
        private void aboutauthor_Click(object sender, EventArgs e)
        {
            author = new Author();
            author.Show();
        }

        /// <summary>
        /// Поле ввода вывода
        /// </summary>
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            mainText = richTextBox1.Text;
        }
    }
}
