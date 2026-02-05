using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double a) || a <= 0)
            {
                MessageBox.Show("Введите корректное положительное значение для 'a'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(textBox2.Text, out double b) || b <= 0)
            {
                MessageBox.Show("Введите корректное положительное значение для 'b'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(textBox3.Text, out double h) || h <= 0)
            {
                MessageBox.Show("Введите корректное положительное значение для 'h'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(textBox4.Text, out double thetaDeg) || thetaDeg <= 0 || thetaDeg >= 180)
            {
                MessageBox.Show("Угол θ должен быть в диапазоне (0°, 180°).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(textBox5.Text, out double phiDeg) || phiDeg <= 0 || phiDeg >= 180)
            {
                MessageBox.Show("Угол φ должен быть в диапазоне (0°, 180°).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем углы в радианы
            double thetaRad = thetaDeg * Math.PI / 180.0;
            double phiRad = phiDeg * Math.PI / 180.0;

            // Проверка sin(θ) и sin(φ) ≠ 0
            double sinTheta = Math.Sin(thetaRad);
            double sinPhi = Math.Sin(phiRad);

            if (Math.Abs(sinTheta) < 1e-10 || Math.Abs(sinPhi) < 1e-10)
            {
                MessageBox.Show("Углы не могут быть 0° или 180° — деление на ноль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Формулы с изображения:
            double area = 0.5 * h * (a + b);                          // Площадь
            double perimeter = a + b + h / sinTheta + h / sinPhi;     // Периметр

            // Вывод результата
            string message = $"Площадь трапеции: {area:F4}\n" +
                             $"Периметр трапеции: {perimeter:F4}";

            MessageBox.Show(message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
       
