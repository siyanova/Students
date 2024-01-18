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

namespace Students
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
               connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog= Students; Integrated Security= SSPI;");
                connection.Open();
                ConnectionText.Text = " ";
                ConnectionText.Text = "Сервер подключен";
                ConnectionBack.Background = new SolidColorBrush(Colors.LightGreen);
            }
            catch
            {
                ConnectionText.Text = " ";
                ConnectionText.Text = "Ошибка подключения к серверу";
                ConnectionBack.Background = new SolidColorBrush(Colors.LightPink);
            }
        }

        private void FullTable_Checked(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string fulltable = @"SELECT*FROM Marks";
            SqlCommand cmd = new SqlCommand(fulltable, connection);

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Close();
                ConnectionText.Text = " ";
                ConnectionText.Text = "Сервер отключен";
                ConnectionBack.Background = new SolidColorBrush(Colors.LightGray);

            }
            catch
            {
                ConnectionText.Text = " ";
                ConnectionText.Text = "Ошибка отключения к серверу";
                ConnectionBack.Background = new SolidColorBrush(Colors.LightPink);
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string FIOStudent = @"SELECT FIO FROM Marks ";
            SqlCommand cmd = new SqlCommand(FIOStudent, connection);

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }

        private void AllAvgMaks_Checked(object sender, RoutedEventArgs e)
        {
            output.Text = "";
            string AllAvgMarks = @"SELECT AverageMarks FROM Marks";
            AllAvgMarks = @"SELECT AverageMarks FROM Marks";
            AllAvgMarks = @"SELECT AverageMarks FROM Marks";
            SqlCommand cmd = new SqlCommand(AllAvgMarks, connection);

            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    output.Text += sqlDataReader[i] + "\t";
                }
                output.Text += "\n";
            }
            sqlDataReader.Close();
        }
    }
    }

