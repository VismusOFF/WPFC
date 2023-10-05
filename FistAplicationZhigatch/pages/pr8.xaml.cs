using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data.SQLite;

namespace FistAplicationZhigatch.pages
{
    /// <summary>
    /// Логика взаимодействия для pr8.xaml
    /// </summary>
    public partial class pr8 : Page
    {
        private DatabaseHelper _dbHelper;
        private List<Item> _items;

        public pr8()
        {
            InitializeComponent();
            _dbHelper = new DatabaseHelper();
            _items = _dbHelper.GetItems();
            dataGrid.ItemsSource = _items;
        }

        public class Item
        {
            public int Id { get; set; }
            public string CompanyName { get; set; }
            public string ProductName { get; set; }
            public string UnitOfMeasurement { get; set; }
            public double PurchasePrice { get; set; }
            public DateTime DeliveryDate { get; set; }
            public double Volume { get; set; }
            public double Cost { get; set; }
        }

        public class DatabaseHelper
        {
            private string _connectionString = "Data Source=F:\\Приложение на WPF\\database\\PR1SQL.db;Version=3;";

            public List<Item> GetItems()
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM products";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    List<Item> items = new List<Item>();
                    while (reader.Read())
                    {
                        items.Add(new Item
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            CompanyName = reader["company_name"].ToString(),
                            ProductName = reader["product_name"].ToString(),
                            UnitOfMeasurement = reader["unit_of_measurement"].ToString(),
                            PurchasePrice = Convert.ToDouble(reader["purchase_price"]),
                            DeliveryDate = DateTime.Parse(reader["delivery_date"].ToString()),
                            Volume = Convert.ToDouble(reader["volume"]),
                            Cost = Convert.ToDouble(reader["cost"])
                        });
                    }

                    return items;
                }
            }

            public void AddItem(Item item)
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Получите максимальный индекс
                    string maxIdQuery = "SELECT MAX(id) FROM products";
                    SQLiteCommand maxIdCommand = new SQLiteCommand(maxIdQuery, connection);
                    int maxId = Convert.ToInt32(maxIdCommand.ExecuteScalar());

                    // Увеличьте максимальный индекс на 1 и добавьте новый элемент
                    item.Id = maxId + 1;

                    string query = "INSERT INTO products (id, company_name, product_name, unit_of_measurement, purchase_price, delivery_date, volume, cost) VALUES (@Id, @CompanyName, @ProductName, @UnitOfMeasurement, @PurchasePrice, @DeliveryDate, @Volume, @Cost)";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                    command.Parameters.AddWithValue("@ProductName", item.ProductName);
                    command.Parameters.AddWithValue("@UnitOfMeasurement", item.UnitOfMeasurement);
                    command.Parameters.AddWithValue("@PurchasePrice", item.PurchasePrice);
                    command.Parameters.AddWithValue("@DeliveryDate", item.DeliveryDate);
                    command.Parameters.AddWithValue("@Volume", item.Volume);
                    command.Parameters.AddWithValue("@Cost", item.Cost);
                    command.ExecuteNonQuery();
                }
            }

            public void DeleteItem(int itemId)
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM products WHERE id = @Id";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", itemId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Item newItem = new Item
            {
                CompanyName = "Новая компания",
                ProductName = "Новый продукт",
                UnitOfMeasurement = "шт.",
                PurchasePrice = 0.0,
                DeliveryDate = DateTime.Now,
                Volume = 0.0,
                Cost = 0.0
            };

            // Вызовите метод для добавления элемента в базу данных
            _dbHelper.AddItem(newItem);

            // Обновите отображение данных
            _items = _dbHelper.GetItems();
            dataGrid.ItemsSource = _items;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Item selectedItem = (Item)dataGrid.SelectedItem;
                int itemId = selectedItem.Id;

                // Вызовите метод для удаления элемента из базы данных
                _dbHelper.DeleteItem(itemId);

                // Обновите отображение данных
                _items = _dbHelper.GetItems();
                dataGrid.ItemsSource = _items;
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.");
            }
        }
    }
}
