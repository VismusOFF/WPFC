using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FistAplicationZhigatch.pages
{
    /// <summary>
    /// Логика взаимодействия для pr3.xaml
    /// </summary>

    public partial class pr3 : Page
    {
        public pr3()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            // Получаем значения x0, xK, dx и a из TextBox'ов
            double x0 = double.Parse(txtx0.Text);
            double xK = double.Parse(txtXk.Text);
            double dx = double.Parse(txtDx.Text);
            double a = double.Parse(txtA.Text);

            // Очищаем ListBox
            lstResult.Items.Clear();

            // Вычисляем и выводим таблицу значений
            lstResult.Items.Add("Значения функции y = 0.0025 * a * (x * x * x) + Math.Sqrt(x + Math.Pow(Math.E, 0.82)):");
            lstResult.Items.Add($"x\t\t|\ty");

            for (double x = x0; x <= xK; x += dx)
            {
                double y = 0.0025 * a * (x * x * x) + Math.Sqrt(x + Math.Pow(Math.E, 0.82));
                lstResult.Items.Add($"{x:F2}\t\t|\t{y:F4}");
            }
        }
        private void btnpr6_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр страницы
            pr6 page = new pr6();

            // Навигируемся на новую страницу
            NavigationService.Navigate(page);
        }
    }
}
