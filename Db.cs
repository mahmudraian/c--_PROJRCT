﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PharmacyManagement
{
    class Db
    {
        MySqlConnection connection = new MySqlConnection("datasource = localhost; port=3306;username=root;password=;database=pharmacy management");
        MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM `login`");
        public void openconnection() {
            if (connection.State == System.Data.ConnectionState.Closed) {
                connection.Open();
            }
        }
        public void clozeconnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection GetConnection() {

            return connection;
        }
    }
}
