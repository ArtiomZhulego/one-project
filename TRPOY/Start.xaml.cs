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
using System.Windows.Shapes;

namespace TRPOY
{
    /// <summary>
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Auto_Click(object sender, RoutedEventArgs e)
        {

            TB1.Text = "Email";
            TB2.Text = "Login";
            Email.Visibility = Visibility.Visible;

            StartButton.Content = "Регистрация";
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {

            TB1.Text = "Login";
            TB2.Text = "Password";

            Email.Visibility = Visibility.Collapsed;


            StartButton.Content = "Авторизация";
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            if (StartButton.Content.ToString() != "Авторизация")
            {
                if ((Email.Text.IndexOf("@") != -1) & (Email.Text.IndexOf(".") != -1) & (Email.Text.Length < 20))
                {
                    Email.Foreground = Brushes.Black;
                    if (Login.Text.Length > 4)
                    {
                        Login.Foreground = Brushes.Black;
                        if (Password.Password.Length > 7)
                        {
                            ToolTip = null;
                            MainWindow win1 = new MainWindow();
                            win1.Show();
                            workBD.Query($"Insert into serS values (N'{Email.Text}',N'{Password.Password}',N'{Login.Text}')");
                            Close();
                        }
                        else { Password.Foreground = Brushes.OrangeRed; ToolTip = "Введите данные корректно"; }
                    }
                    else { Login.Foreground = Brushes.OrangeRed; ToolTip = "Введите данные корректно"; }
                }
                else { Email.Foreground = Brushes.OrangeRed; ToolTip = "Введите данные корректно"; }
            }
            else
            {
                if (Login.Text.Length > 4)
                {
                    Login.Foreground = Brushes.Black;
                    if (Password.Password.Length > 7)
                    {
                        ToolTip = null;
                        if (workBD.Search($"Select Id From serS Where Login=N'{Login.Text}'") != 0)
                        {
                            if (workBD.Search($"Select Id From serS Where UPassword=N'{Password.Password}'") != 0)
                            {
                                MainWindow win1 = new MainWindow();
                                win1.Show();
                                Close();
                            }
                            else { Password.Foreground = Brushes.OrangeRed; ToolTip = "Введите данные корректно"; }
                        }
                        else { Login.Foreground = Brushes.OrangeRed; ToolTip = "Введите данные корректно"; }

                    }
                    else { Password.Foreground = Brushes.OrangeRed; ToolTip = "Введите данные корректно"; }
                }
                else { Login.Foreground = Brushes.OrangeRed; ToolTip = "Введите данные корректно"; }
            }
        }

    }
}
    
