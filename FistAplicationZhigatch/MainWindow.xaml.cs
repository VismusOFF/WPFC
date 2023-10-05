using FistAplicationZhigatch.pages;
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

namespace FistAplicationZhigatch
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            classes.ClassFrame.frmObj = FrameMain;
            classes.ClassFrame.frmObj.Navigate(new pages.PageAutorization());
        }

        private void BtnHello_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр страницы
            pr1 page = new pr1();

            // Навигируемся на новую страницу
            FrameMain.NavigationService.Navigate(page);
        }
    }
}
