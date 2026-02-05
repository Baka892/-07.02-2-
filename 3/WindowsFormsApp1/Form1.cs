using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        // ===============================================

        private string GetSelectedString()
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите строку из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return listBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null)
            {
                return;
            }

            int zeros = s.Count(c => c == '0');
            int ones = s.Count(c => c == '1');
            labelResult.Text = $"Нулей: {zeros}, Единиц: {ones}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string[] words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            labelResult.Text = $"Количество слов: {words.Length}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            int count = s.Count(c => char.IsPunctuation(c));
            labelResult.Text = $"Знаков препинания: {count}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string digits = new string(s.Where(c => c >= '0' && c <= '9').ToArray());

            if (string.IsNullOrEmpty(digits))
                labelResult.Text = "Цифры в строке отсутствуют";
            else
                labelResult.Text = $"Цифры: {digits}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string[] parts = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int evenCount = parts.Count(part => int.TryParse(part, out int num) && num % 2 == 0);
            labelResult.Text = $"Чётных чисел: {evenCount}";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            int count = s.Count(c => c >= 'а' && c <= 'я');
            labelResult.Text = $"Строчных русских букв: {count}";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string letters = new string(s.Where(c => c >= 'а' && c <= 'я').ToArray());
            labelResult.Text = $"Строчные русские буквы: {(letters.Length > 0 ? letters : "отсутствуют")}";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string[] words = s.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            labelResult.Text = string.Join(" ", words);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string[] words = s.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                    words[i] = words[i].Substring(1);
            }
            labelResult.Text = string.Join(" ", words);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            if (!int.TryParse(textBoxI.Text, out int i) || !int.TryParse(textBoxJ.Text, out int j))
            {
                MessageBox.Show("Введите корректные числа для i и j!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            i--; j--; // Перевод в 0-индексацию

            if (i < 0 || j < 0 || i >= s.Length || j >= s.Length)
            {
                MessageBox.Show("Индексы i и j выходят за границы строки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            char[] chars = s.ToCharArray();
            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;

            labelResult.Text = new string(chars);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string[] words = s.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 1)
                {
                    // ИСПРАВЛЕНО: замена [^1] на [words[i].Length - 1]
                    char first = words[i][0];
                    char last = words[i][words[i].Length - 1];
                    char[] chars = words[i].ToCharArray();
                    chars[0] = last;
                    chars[chars.Length - 1] = first;
                    words[i] = new string(chars);
                }
            }
            labelResult.Text = string.Join(" ", words);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string result = Regex.Replace(s, "[a-zA-Z]", "+");
            labelResult.Text = result;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string result = s.Replace('А', '*');
            labelResult.Text = result;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string cleaned = new string(s.ToLower().Where(c => char.IsLetter(c)).ToArray());
            string reversed = new string(cleaned.Reverse().ToArray());

            bool isPalindrome = cleaned == reversed;
            labelResult.Text = $"Это {(isPalindrome ? "" : "НЕ ")}палиндром.\nОчищенная строка: \"{cleaned}\"";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string s = GetSelectedString();
            if (s == null) return;

            string[] words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string lengths = string.Join(" ", words.Select(w => w.Length));
            labelResult.Text = $"Длины слов: {lengths}";
        }
    }
}
