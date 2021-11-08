﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using GroundTerminalSystem.Data;

namespace GroundTerminalSystem
{
    //  This class manages: 
    //      a) - the Database connection
    //      b) - the Database data insertion
    //      c) - the Database data deletion
    //      c) - the Database data retrieval
    //      d) - the Database data search
    public static class databaseManager
    {

        private static string server = "aircraftdb.cdnao8zlugzc.us-west-2.rds.amazonaws.com";
        private static string database = "aircraft_DB";
        private static string dbUsername = "sqAdmin";
        private static string dbPasscode = "group1sq";
        private static string connectionStr = $"Data Source={server};Persist Security Info=False;Password={dbPasscode};User ID={dbUsername};Initial Catalog={database}";
        private static string sqlQuery = "";
        public static DataTable dt = null;



        //insert AST data into tables
        public static void insertData(string flightDataTail, G_ForceParams GForce, AttitudeParams attitude)
        {

            using (SqlConnection sqlConn = new SqlConnection(connectionStr))
            {
                sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                //add new entry in G-Force Parameters table
                sqlQuery = $"INSERT INTO gForceParameters (aircraftTail_PK,timeStamp, Accel_X, Accel_Y, Accel_Z, Weight) VALUES('{flightDataTail}', GETDATE(), {GForce.AccelX}, {GForce.AccelY}, {GForce.AccelZ}, {GForce.Weight}); ";
                adapter.InsertCommand = new SqlCommand(sqlQuery, sqlConn);
                adapter.InsertCommand.ExecuteNonQuery();

                //add new entry in Attitude Parameters table
                sqlQuery = $"INSERT INTO attitudeParameters (aircraftTail_PK,timeStamp, Altitude, Pitch, Bank) VALUES('{flightDataTail}', GETDATE(), {attitude.Altitude}, {attitude.Pitch}, {attitude.Bank}); ";
                adapter.InsertCommand = new SqlCommand(sqlQuery, sqlConn);
                adapter.InsertCommand.ExecuteNonQuery();

                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }

            }
            Console.WriteLine("Data inserted in Database");


        }

        //retrieve all data from table
        public static DataTable retrieveData(string dbTable)
        {
            //connectionStr = $"Data Source={server};Initial Catalog={database};Integrated Security=True";
            using (SqlConnection sqlConn = new SqlConnection(connectionStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                dt = new DataTable();

                //retrieve data from table
                sqlQuery = $"SELECT * from {dbTable}";
                adapter.SelectCommand = new SqlCommand(sqlQuery, sqlConn);
                adapter.Fill(dt);
                return dt;

            }
        }

        //delete content from table
        public static DataTable deleteData(string dbTable)
        {
            //connectionStr = $"Data Source={server};Initial Catalog={database};Integrated Security=True";
            using (SqlConnection sqlConn = new SqlConnection(connectionStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                dt = new DataTable();

                sqlQuery = $"DELETE FROM {dbTable}";
                adapter.SelectCommand = new SqlCommand(sqlQuery, sqlConn);
                adapter.Fill(dt);
                return dt;

            }
        }


        //retrieve  data from table, between date range
        public static DataTable searchDataBetweenDates(string dbTable, string startDate, string endDate)
        {
            //connectionStr = $"Data Source={server};Initial Catalog={database};Integrated Security=True";
            using (SqlConnection sqlConn = new SqlConnection(connectionStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                dt = new DataTable();

                sqlQuery = $"SELECT * from {dbTable} WHERE timeStamp BETWEEN '{startDate}'AND '{endDate}'";
                adapter.SelectCommand = new SqlCommand(sqlQuery, sqlConn);
                adapter.Fill(dt);
                return dt;

            }
        }



    }
}