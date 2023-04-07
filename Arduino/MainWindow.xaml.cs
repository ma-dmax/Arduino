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
using System.IO.Ports;

namespace Arduino
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public void my_send(int x)
        {
            try
            {
                sp.Write($"{x}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
        }

        SerialPort sp = new SerialPort();
        string[] ports = SerialPort.GetPortNames();



        public MainWindow()
        {
            InitializeComponent();
            COM.ItemsSource = ports;
        }



        private void COM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (sp.IsOpen)
                    sp.Close();
                else
                {
                    //btn.IsEnabled = true;
                    btn.Visibility = Visibility.Visible;
                    btn1.Visibility = Visibility.Visible;
                    btn2.Visibility = Visibility.Visible;
                    btn3.Visibility = Visibility.Visible;
                    btn4.Visibility = Visibility.Visible;
                    btn5.Visibility = Visibility.Visible;
                    btn6.Visibility = Visibility.Visible;
                    btn7.Visibility = Visibility.Visible;
                    btn8.Visibility = Visibility.Visible;
                    one_clr_screen.Visibility = Visibility.Visible;
                    one_clr_all.Visibility = Visibility.Visible;
                    red_sl_.Visibility = Visibility.Visible;
                    red_sl.Visibility = Visibility.Visible;
                    blue_sl.Visibility = Visibility.Visible;
                    green_sl_.Visibility = Visibility.Visible;
                    green_sl.Visibility = Visibility.Visible;
                    blue_sl_.Visibility = Visibility.Visible;
                    bright.Visibility = Visibility.Visible;
                    bright_one.Visibility = Visibility.Visible;
                    delay.Visibility = Visibility.Visible;
                    delay_one.Visibility = Visibility.Visible;
                }
                sp.PortName = COM.SelectedItem as string;
                sp.BaudRate = 9600;
                sp.Open();
                
                //MessageBox.Show("Port is open!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void To_Setting(object sender, RoutedEventArgs e)
        {
            SettingWindow setting = new SettingWindow();
            setting.Show();
            sp.Close();
            this.Close();
            
        }


        private void Button_one_color_all(object sender, RoutedEventArgs e)
        {
            my_send(0);
        }               // 0 
        private void Button_ukraine(object sender, RoutedEventArgs e)
        {
            my_send(1);
        }                     // 1 
        private void Button_ukraine_spin(object sender, RoutedEventArgs e)
        {
            my_send(2);
        }                // 2 
        private void Button_rainbow(object sender, RoutedEventArgs e)
        {
            my_send(3);
        }                     // 3 
        private void Button_rainbow_2(object sender, RoutedEventArgs e)
        {
            my_send(4);
        }                   // 4 
        private void Button_rainbow_beatiful(object sender, RoutedEventArgs e)
        {
            my_send(5);
        }            // 5 
        private void Button_one_color_aroundscreen(object sender, RoutedEventArgs e)
        {
            my_send(6);
        }      // 6 
        private void Button_rainbow_around(object sender, RoutedEventArgs e)
        {
            my_send(7);
        }              // 7
        private void Konfeti(object sender, RoutedEventArgs e)
        {
            my_send(8);
        }                            // 8
        private void Straboskope(object sender, RoutedEventArgs e)
        {
            my_send(9);
        }                        // 9

        private void Clear(object sender, RoutedEventArgs e)
        {
            my_send(850);
        }                              // 85



        private void Send_colors(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (red_sl != null && green_sl != null && blue_sl != null && bright != null && delay != null && one_clr_screen != null && one_clr_all != null)
                {
                    Color color = Color.FromRgb((byte)red_sl.Value, (byte)green_sl.Value, (byte)blue_sl.Value);
                    one_clr_screen.Background = new SolidColorBrush(color);
                    one_clr_all.Background = new SolidColorBrush(color);
                    
                    String[] all = { red_sl_.Text.ToString(), green_sl_.Text.ToString(), blue_sl_.Text.ToString(), bright_one.Text.ToString(), delay_one.Text.ToString() };
                    sp.Write($"65;{all[0]};{all[2]};{all[1]};{all[4]};{all[3]};");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void Send_colors(object sender, RoutedEventArgs e)
        {
            try
            {
                if (red_sl != null && green_sl != null && blue_sl != null && bright != null && delay != null && one_clr_screen != null && one_clr_all != null)
                {
                    Color color = Color.FromRgb((byte)red_sl.Value, (byte)green_sl.Value, (byte)blue_sl.Value);
                    one_clr_screen.Background = new SolidColorBrush(color);
                    one_clr_all.Background = new SolidColorBrush(color);

                    String[] all = { red_sl_.Text.ToString(), green_sl_.Text.ToString(), blue_sl_.Text.ToString(), bright_one.Text.ToString(), delay_one.Text.ToString() };
                    sp.Write($"65;{all[0]};{all[2]};{all[1]};{all[4]};{all[3]};");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
        }


        
    }
}
