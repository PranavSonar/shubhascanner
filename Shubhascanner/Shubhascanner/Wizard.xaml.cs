﻿using System;
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
using Microsoft.Win32;
using System.IO;

namespace Shubhascanner
{
    /// <summary>
    /// Interaction logic for Wizard.xaml
    /// </summary>
    public partial class Wizard : Window
    {
        int nextcount = 0;
        public Wizard()
        {
            InitializeComponent();
        }

        private void nextButtonforterminal_Click(object sender, RoutedEventArgs e)
        {
            if (nextcount == 0)
            {
                agree.Visibility = Visibility.Visible;
                notagree.Visibility = Visibility.Visible;


                try
                {
                    stackcontainer.Children.RemoveAt(0);
                }
                catch (Exception ex)
                {
                   
                }
                Shubhascanner.GNUGPL  G = new GNUGPL ();
                stackcontainer.Children.Add(G );
                nextcount++;
                backButton.IsEnabled = true;


                return;

            }



            if (nextcount == 1)
            {

                if (agree.IsChecked == false)
                {
                    Rsult_lbl.Foreground = Brushes.Red;
                    Rsult_lbl.Content = "Please accept license agreement else Click  Cancel to exit. ";

                    return;

                }

                agree.Visibility = Visibility.Hidden;
                notagree.Visibility = Visibility.Hidden;


                try
                {
                    stackcontainer.Children.RemoveAt(0);
                }
                catch (Exception ex)
                {
                   
                }
                Shubhascanner.Amibrokerpath A = new Amibrokerpath();
                stackcontainer.Children.Add(A );
                finish.IsEnabled = true;
                cancelButton.IsEnabled = false;
                nextButtonforterminal.IsEnabled = false;
                nextcount++;



                return;
            }

        


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                //Shubhalabha123.Regidtartion r = new Shubhalabha123.Regidtartion();
                //stackcontainer.Children.Add(r);

                Shubhascanner.Welcome w = new Welcome();
                stackcontainer.Children.Add(w);
            }
            catch (Exception ex)
            {
               
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            cancelButton.IsEnabled = true;

            Rsult_lbl.Content = "";

            if (nextcount == 2)
            {

                try
                {
                    stackcontainer.Children.RemoveAt(0);
                }
                catch (Exception ex)
                {
                   
                }
                Shubhascanner.Amibrokerpath A = new Amibrokerpath();
                stackcontainer.Children.Add(A);
                nextcount--;
                nextButtonforterminal.IsEnabled = true;
                finish.IsEnabled = false;
                return;
            }
            if (nextcount == 1)
            {

                try
                {
                    stackcontainer.Children.RemoveAt(0);
                }
                catch (Exception ex)
                {

                }
                Shubhascanner.GNUGPL G = new GNUGPL();
                stackcontainer.Children.Add(G );
                nextcount--;
                return;
            }
            if (nextcount == 0)
            {

                try
                {
                    stackcontainer.Children.RemoveAt(0);
                }
                catch (Exception ex)
                {

                }
                Shubhascanner.Welcome w = new Welcome();
                stackcontainer.Children.Add(w );
              
                return;
            }
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey(@"amis\");

            var amiexepath = regKey.GetValue("Amiexepath");
            string filepath = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
            string processtostart = "";



            if (!Directory.Exists("C:\\myshubhalabha\\Scanner\\Donotdelete"))
            {
                Directory.CreateDirectory("C:\\myshubhalabha\\Scanner\\Donotdelete");
            }

            if (!Directory.Exists("C:\\myshubhalabha\\Scanner\\Report"))
            {
                Directory.CreateDirectory("C:\\myshubhalabha\\Scanner\\Report");
            }

            processtostart = filepath.Substring(0, filepath.Length - 17) + "afltodll.afl";


            File.Copy(processtostart, "C:\\myshubhalabha\\Scanner\\Donotdelete\\scanner.afl", true);
            
            
           
            regKey.SetValue("Wizart", "done");
            this.Hide();
            Shubhascanner.Registartion r = new Registartion();
            r.ShowDialog();






        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
