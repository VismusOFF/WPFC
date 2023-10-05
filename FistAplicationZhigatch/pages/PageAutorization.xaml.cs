﻿using System;
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
    /// Логика взаимодействия для PageAutorization.xaml
    /// </summary>
    public partial class PageAutorization : Page
    {
        public PageAutorization()
        {
            InitializeComponent();
        }
        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            // Получаем введенный логин и пароль
            string login = Txtlogin.Text;
            string password = PsbPassword.Password;

            // Проверяем, если учетные данные верны
            if (Authenticate(login, password))
            {
                // Успешная аутентификация
                MessageBox.Show("Аутентификация успешна!");
                // Здесь вы можете перейти на другую страницу или выполнить другие действия.
            }
            else
            {
                // Неверный логин или пароль
                MessageBox.Show("Неверный логин или пароль. Пожалуйста, попробуйте еще раз.");
            }
        }

        private bool Authenticate(string login, string password)
        {
            // Replace with your actual authentication logic.
            // For this example, we're using hardcoded values.
            return login == "1" && password == "1";
        }
    }
}
