using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Windows.Resources;

namespace WhatToWork
{
    /// <summary>
    /// Interaction logic for LoginSuccessful.xaml
    /// </summary>
    public partial class LoginSuccessful : Window
    {
        public LoginSuccessful()
        {
            InitializeComponent();
        }
        String dbConnectionStringLSPage = @"Data Source=database.db;Version=3;";

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionStringLSPage);
           
            try
            {
                sqliteCon.Open();
                
                 int generated_Wrk_ID;
                Random randomNumber= new Random();
                generated_Wrk_ID = randomNumber.Next(111111,999999);

               // int generated_Wrk_ID=randomNumber.Next(1000,9999);

                bool radioValue=false;
                bool radioYesVariable=radio_Yes.IsEnabled;
               bool radioNoVariable=radio_No.IsEnabled;

                if(radioYesVariable)
                {
                radioValue=radioYesVariable;
                }
                else
                {
                radioValue=radioNoVariable;
                }


               // String queryToInsert="Insert into EmployeeInfo(Work_ID,Work_Name,Level,Immediate_Impact,Deadline) values('Wrk_ID','"+this.txt_Work_Name.Text +"','"+this.txt_Level.Text+"','radioValue','"+this.txt_Deadline.Text+"')";
                String queryToInsert = "Insert into EmployeeInfo(Work_ID,Work_Name,Level,Immediate_Impact,Deadline,Rank) values("+generated_Wrk_ID+",'Work',"+3+","+"'false'"+",'tomorrow',"+5+")";

                SQLiteCommand createCommand = new SQLiteCommand(queryToInsert, sqliteCon);
               
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Saved");
             sqliteCon.Close();             
             

                }

            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_Level_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    


        }
    }

