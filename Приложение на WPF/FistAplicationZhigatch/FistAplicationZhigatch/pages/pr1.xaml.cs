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
    /// Логика взаимодействия для pr1.xaml
    /// </summary>
    public partial class pr1 : Page
    {
        public pr1()
        {
            InitializeComponent();
        }

        private void BtnSolve_Click(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToDouble(TxtX.Text);
            double y = Convert.ToDouble(TxtY.Text);
            double z = Convert.ToDouble(TxtZ.Text);

            double a = Math.Log(Math.Pow(y, (-Math.Sqrt(Math.Abs(x))))) * (x - (y / 2)) + Math.Pow(Math.Sin(Math.Atan(z)), 2);

            LstResult.Items.Add("ИСП21.1А ПР1 Вариант 5 Селянский Жигач");
            LstResult.Items.Add($"x={x}");
            LstResult.Items.Add($"y={y}");
            LstResult.Items.Add($"z={z}");
            LstResult.Items.Add($"Результат a={a}");
        }

        private void Btnpr2_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр страницы
            pr2 page = new pr2();

            // Навигируемся на новую страницу
            NavigationService.Navigate(page);
        }
    }
}
