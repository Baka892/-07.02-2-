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
    public partial class Form3: Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double r) || r <= 0)
            {
                MessageBox.Show("Введите корректное положительное значение для радиуса 'r'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Чтение угла в градусах
            if (!double.TryParse(textBox2.Text, out double thetaDeg) || thetaDeg <= 0 || thetaDeg >= 360)
            {
                MessageBox.Show("Угол θ должен быть в диапазоне (0°, 360°).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем градусы в радианы
            double thetaRad = thetaDeg * Math.PI / 180.0;

            // Формулы:
            double area = 0.5 * r * r * thetaRad;   // Площадь
            double arcLength = r * thetaRad;        // Периметр = длина дуги (как в формуле)

            string result = $"Площадь: {area:F4}\n" +
                           $"Периметр (длина дуги): {arcLength:F4}";

            MessageBox.Show(result, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
        
