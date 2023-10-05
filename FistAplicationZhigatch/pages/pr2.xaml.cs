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
    /// Логика взаимодействия для pr2.xaml
    /// </summary>
    public partial class pr2 : Page
    {
        public pr2()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            lstResult.Items.Clear();
            double x = double.Parse(txtX.Text);
            double y = double.Parse(txtY.Text);
            double z = double.Parse(txtZ.Text);
            double u;
            lstResult.Items.Add("Лаб.раб.№2. Выполнил Жигач Д. Н.");
            lstResult.Items.Add($"X={x}");
            lstResult.Items.Add($"Y={y}");
            lstResult.Items.Add($"Z={z}");
            int n = 0;
            if (rbtCos.IsChecked == true) n = 1;
            else if (rbtExp.IsChecked == true) n = 2;
            switch (n)
            {
                case 0:
                    if (x > Math.Abs(z)) u = 2 * Math.Sin(x) * Math.Sin(x) * Math.Sin(x) + (3 * (z * z));
                    else if (x == Math.Abs(z)) u = (Math.Sin(x) - z) * (Math.Sin(x) - z);
                    else u = Math.Abs(Math.Sin(x) - z);
                    lstResult.Items.Add($"Результат U={Math.Round(u, 3)}");
                    break;
                case 1:
                    if (x > Math.Abs(z)) u = 2 * Math.Cos(x) * Math.Cos(x) * Math.Cos(x) + (3 * (z * z));
                    else if (x == Math.Abs(z)) u = (Math.Cos(x) - z) * (Math.Cos(x) - z);
                    else u = Math.Abs(Math.Cos(x) - z);
                    lstResult.Items.Add($"Результат U={Math.Round(u, 3)}");
                    break;
                case 2:
                    if (x > Math.Abs(z)) u = 2 * Math.Exp(x) * Math.Exp(x) * Math.Exp(x) + (3 * (z * z));
                    else if (x == Math.Abs(z)) u = (Math.Exp(x) - z) * (Math.Exp(x) - z);
                    else u = Math.Abs(Math.Exp(x) - z);
                    lstResult.Items.Add($"Результат U={Math.Round(u, 3)}");
                    break;
                default:
                    lstResult.Items.Add("Решение не найдено");
                    break;
            }




        }
        /// <summary>
        /// Очистить поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtX.Clear();
            txtY.Clear();
            txtZ.Clear();
            lstResult.Items.Clear();
        }

        private void btnpr3_Click(object sender, RoutedEventArgs e)
        {
            pr3 page = new pr3();
            NavigationService.Navigate(page);
        }
    }
}
