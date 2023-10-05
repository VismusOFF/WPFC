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
using System.IO;
using System.Globalization;
using System.Threading;

namespace FistAplicationZhigatch.pages
{
    /// <summary>
    /// Логика взаимодействия для pr6.xaml
    /// </summary>
    public partial class pr6 : Page
    {
        public pr6()
        {
            InitializeComponent();
        }

        private void btnRezult_Click(object sender, RoutedEventArgs e)
        {
           Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string filePath = "строки.txt";
            try
            {
                string text = File.ReadAllText(filePath);
                string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (!string.IsNullOrEmpty(words[i]))
                    {
                        char[] wordChars = words[i].ToCharArray();
                        wordChars[0] = char.ToUpper(wordChars[0]);
                        words[i] = new string(wordChars);
                    }
                }
                string updatedText = string.Join(" ", words);
                File.WriteAllText(filePath, updatedText);
                txbRezult.Text ="" + updatedText;
            }
            catch (IOException ex)
            {
                txbRezult.Text = "Первая буква каждого слова была заменена на прописную" + ex.Message;
            }
        }
        private void btnListFromFile_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader(@"Строки.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                lstInput.Items.Add(sr.ReadLine());
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            pr7 page = new pr7();
            NavigationService.Navigate(page);
        }
    }
}
