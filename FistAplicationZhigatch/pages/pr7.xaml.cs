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
    /// Логика взаимодействия для pr7.xaml
    /// </summary>
    public partial class pr7 : Page
    {
        public pr7()
        {
            InitializeComponent();
        }

        private void btnRezult_Click(object sender, RoutedEventArgs e)
        {
            int[] inputArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] Z = new int[inputArray.Length];

            for (int i = 0; i < Z.Length; i++)
            {
                if (i==0 || i % 2 != 0)
                {
                    Z[i] = i * i + 1; // Если i нечетное
                }
                else
                {
                    Z[i] = 2 * i - 1; // Если i четное
                }
            }

            double[] D = new double[inputArray.Length];

            for (int i = 0; i < Z.Length; i++)
            {
                if (Z[i] < 2.5)
                {
                    D[i] = 2.5 * Z[i];
                }
                else
                {
                    D[i] = Z[i] / 2.5;
                }
            }

            // Очистить ListBox Rezult перед выводом новых результатов
            Rezult.Items.Clear();

            // Вывести элементы массивов Z и D в ListBox Rezult
            for (int i = 0; i < Z.Length; i++)
            {
                Rezult.Items.Add($"Z[{i}] = {Z[i]}, D[{i}] = {D[i]}");
            }

            // Проверить, есть ли выбранный элемент, и отобразить информацию о нем
            if (Rezult.SelectedIndex >= 0 && Rezult.SelectedIndex < Rezult.Items.Count)
            {
                string selectedText = (string)Rezult.Items[Rezult.SelectedIndex];
                MessageBox.Show($"Выбранный элемент: {selectedText}");
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            pr8 page = new pr8();
            NavigationService.Navigate(page);
        }
    }
}
