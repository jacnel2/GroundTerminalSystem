﻿using GroundTerminalSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace GroundTerminalSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <value>Thread to update the RealTimeInformation screen.</value>
        //private Thread ScreenUpdater;
        /// <value>Controls thread to update the RealTimeInformation screen.</value>
        private bool RunScreenUpdater = true;

        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            RealTimeFlightData.ItemsSource = Director.DisplayFlightDataInMemory();
            RunScreenUpdater = true;
            UpdateScreen();
        }

        /// <summary>
        /// Provides the ability to switch between the Real Time Information System tab and the Database Search tab.
        /// </summary>
        /// <param name="sender">Object which called this method.</param>
        /// <param name="e">Calling event args.</param>
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Add code to change between tabs here.
        }

        /// <summary>
        /// Calls the Director to start the Server upon button click.
        /// </summary>
        private void StartServerBtn_Click(object sender, RoutedEventArgs e)
        {
            Director.StartServer();
            RunScreenUpdater = true;
        }

        /// <summary>
        /// Calls the Director to STOP the Server upon button click.
        /// </summary>
        private void StopServerBtn_Click(object sender, RoutedEventArgs e)
        {
            Director.StopServer();
            RunScreenUpdater = false;
        }

        /// <summary>
        /// Updates the RealTimeInformation screen every set number of seconds. 
        /// </summary>
        private async Task UpdateScreen()
        {
            while (RunScreenUpdater)
            {
                await Task.Delay(Commons.THREAD_SCREEN_UPDATE_WAIT);
                RealTimeFlightData.Items.Refresh();
            }
        }


        /// <summary>
        /// Updates the gforce parameter Datagrid, and displays ALL the data from the database table. 
        /// </summary>
        private void DisplayGForceGrid_Click(object sender, RoutedEventArgs e)
        {
            gforceDatagrid.ItemsSource = Director.GetGForceGrid().DefaultView;
        }


        /// <summary>
        /// Updates the attitude parameter Datagrid, and displays ALL the data from the database table. 
        /// </summary>
        private void DisplayAttitudeGrid_Click(object sender, RoutedEventArgs e)
        {
            attitudeDatagrid.ItemsSource = Director.GetAttitudeGrid().DefaultView;
        }


        /// <summary>
        /// Updates the gforce parameter Datagrid, and deletes all the data from the database table. 
        /// </summary>
        private void ClearGForceGrid_Click(object sender, RoutedEventArgs e)
        {
            gforceDatagrid.ItemsSource = Director.ClearGForceGrid().DefaultView;
        }


        /// <summary>
        /// Updates the Attitude parameter Datagrid, and deletes all the data from the database table. 
        /// </summary>
        private void ClearAttitudeGrid_Click(object sender, RoutedEventArgs e)
        {
            attitudeDatagrid.ItemsSource = Director.ClearAttitudeGrid().DefaultView;
        }

        /// <summary>
        /// Updates the gforce parameter Datagrid, and displays ALL the data found within date range. 
        /// </summary>
        private void GForceSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            gforceDatagrid.ItemsSource = Director.SearchData("gForceParameters", gForceStartDate.SelectedDate.ToString(), gForceEndDate.SelectedDate.ToString()).DefaultView;
        }


        /// <summary>
        /// Updates the attitude parameter Datagrid, and displays ALL the data found within date range. 
        /// </summary>
        private void AttitudeSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            attitudeDatagrid.ItemsSource = Director.SearchData("attitudeParameters", attitudeStartDate.SelectedDate.ToString(), attitudeEndDate.SelectedDate.ToString()).DefaultView;
        }
    }
}
