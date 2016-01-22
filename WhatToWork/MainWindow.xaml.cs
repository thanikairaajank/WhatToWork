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
using System.Windows.Media.Animation;

using System.Data.SQLite;
namespace WhatToWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbconnectionString = @"Data Source=database.db;Version=3;";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbconnectionString);
            // MessageBox.Show("Ha ha ha ha Clicked");
            try
            {
                sqliteCon.Open();
                String query = "select * from Login_Credentials where username='" + this.txt_Username.Text + "'and password='" + this.txt_Password.Password + "' ";
                SQLiteCommand createCommand = new SQLiteCommand(query, sqliteCon);

                createCommand.ExecuteNonQuery();
                SQLiteDataReader dataReader = createCommand.ExecuteReader();

                int count = 0;
                while (dataReader.Read())
                {
                    count++;
                }

                if (count == 1)
                {
                    MessageBox.Show("Credentials are correct!");
                    sqliteCon.Close();
                    this.Hide();
                    LoginSuccessful loginSuccessful = new LoginSuccessful();
                    loginSuccessful.ShowDialog();
                
                
                }

                if (count > 1)
                {
                    MessageBox.Show("Credentials already exist, try again please!");
                }

                if (count < 1)
                {
                    MessageBox.Show("Credentials are incorrect!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
