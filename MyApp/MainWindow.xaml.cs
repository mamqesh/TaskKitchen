using MyApp.Database;
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

namespace MyApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KitchenEntities connection = new KitchenEntities();

        public MainWindow()
        {
            InitializeComponent();
            var orders = connection.OrderDishes.ToList();
            PendingOrders.DisplayMemberPath = "Dish";
            foreach (var order in orders)
            {
                PendingOrders.Items.Add(order);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PendingOrders.SelectedIndex != -1)
            {

                var nameDishes = connection.Dish.ToList();
                YouAccept.DisplayMemberPath = "NameDish";
                foreach (var nameDish in nameDishes)
                {
                    YouAccept.Items.Add(nameDish);
                    
                }
                MessageBox.Show("Order accepted!");
            }   
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            YouAccept.Items.Clear();
            MessageBox.Show("Order canceled!");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
