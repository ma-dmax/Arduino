using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;


namespace Arduino
{
    /// <summary>
    /// Логика взаимодействия для SettingWindow.xaml
    /// </summary>
    /// 



    public partial class SettingWindow : Window
    {


        SerialPort sp = new SerialPort();
        string[] ports = SerialPort.GetPortNames();


        Dictionary<string, string> my_settings = new Dictionary<string, string>();
        static string fileContent;
        
        public void ReadFileContent()
        {
            fileContent = File.ReadAllText(@"D:\ArduinoSetting.txt");
            char[] delimiterChars = { '/' };

            string[] words = fileContent.Split(delimiterChars);

            for (int i = 0; i < words.Length; i += 2)
            {
                my_settings.Add(words[i], words[i + 1]);
            }
        }

        public SettingWindow()
        {   

            InitializeComponent();
            ReadFileContent();

            try
            {
                count.Text = my_settings["LED_COUNT"];
                pin.Text = my_settings["LED_DT"];
                unknow.Text = my_settings["NEW"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            COM.ItemsSource = ports;

            grid.Children.Clear();

            int buttonCount = 100; // зчитування кількості кнопок з файлу
            int rows = 5; // кількість рядків
            int columns = (int)Math.Ceiling((double)buttonCount / rows); // кількість стовпців
            

            // додавання стовпців до Grid контейнеру
            for (int i = 0; i < columns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // додавання рядків до Grid контейнеру
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            // створення кнопок і додавання їх до Grid контейнеру
            for (int i = 0; i < buttonCount; i++)
            {


                CheckBox button = new CheckBox();
                button.Content = $"{(i + 1)}";
                button.Name = $"btn{(i)}";
                button.FontSize = 10;   
                button.Margin = new Thickness(3, 0, 0, 0);
                button.Padding = new Thickness(0,0,0,0);
                Color color = Color.FromRgb((byte)0, (byte)255, (byte)255);
                if (i > 50)
                {
                    button.Name = $"btn1";
                    color = Color.FromRgb((byte)55, (byte)56, (byte)255);
                }
                button.Background = new SolidColorBrush(color);
                button.Foreground = new SolidColorBrush(color);
                int row = i / columns;
                int column = i % columns;
                grid.Children.Add(button);
                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);
            }

        }
        
        private void To_Setting(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void create(object sender, RoutedEventArgs e)
        {
      
        }

        private void Clear_choise(object sender, RoutedEventArgs e)
        {
            try {

                grid.Children.Clear();
                int buttonCount = 100; // зчитування кількості кнопок з файлу
                int rows = 5; // кількість рядків
                int columns = (int)Math.Ceiling((double)buttonCount / rows); // кількість стовпців



                // додавання стовпців до Grid контейнеру
                for (int i = 0; i < columns; i++)
                {
                    //grid.ColumnDefinitions.Add(new ColumnDefinition());
                }

                // додавання рядків до Grid контейнеру
                for (int i = 0; i < rows; i++)
                {
                    //grid.RowDefinitions.Add(new RowDefinition());
                }

                // створення кнопок і додавання їх до Grid контейнеру
                for (int i = 0; i < buttonCount; i++)
                {


                    CheckBox button = new CheckBox();
                    button.Content = $"{(i + 1)}";
                    button.Name = $"btn{(i)}";
                    button.FontSize = 10;
                    button.Margin = new Thickness(3, 0, 0, 0);
                    button.Padding = new Thickness(0, 0, 0, 0);
                    button.SetAttribute("Checked", "true");
                    Color color = Color.FromRgb((byte)0, (byte)255, (byte)255);
                    if (i > 50)
                    {
                        button.Name = $"btn1";
                        color = Color.FromRgb((byte)55, (byte)56, (byte)255);
                    }
                    button.Background = new SolidColorBrush(color);
                    button.Foreground = new SolidColorBrush(color);
                    int row = i / columns;
                    int column = i % columns;
                    grid.Children.Add(button);
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, column);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void COM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sp.IsOpen)
                    sp.Close();
                sp.PortName = COM.SelectedItem as string;
                sp.BaudRate = 9600;
                sp.Open();
             }
             catch (Exception ex)
             {
               MessageBox.Show(ex.Message);
             }
            }

        private void Send_colors(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        private void Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Send_colors(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
    }

