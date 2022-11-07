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
    /// Логика взаимодействия для add1.xaml
    /// </summary>
    public partial class add1 : Window
    {
        public add1()
        {
            InitializeComponent();
        }
        public static bool Fields(string FirstName, string LastName, string SecondName, string Age, string PassportNum)
        {
            bool b = false;
            if ((FirstName != "") && (NCheck(FirstName) != -1))
            {
                if ((LastName != "") && (NCheck(LastName) != -1))
                {
                    if ((SecondName != "") && (NCheck(SecondName) != -1))
                    {
                        if ((Age != "") && (int.Parse(Age) > 15))
                        {
                            if (PassportNum != "")
                            {
                                b = true;
                            }
                            else { MessageBox.Show("В поле специальность не может быть цифр и длинна должна быть больше 0"); }
                        }
                        else { MessageBox.Show("В поле возраст можно вводить только цифры а так же возраст должен быть больше 15"); }
                    }
                    else { MessageBox.Show("В поле отчество не может быть цифр и длинна должна быть больше 0"); }
                }
                else { MessageBox.Show("В поле фамилия не может быть цифр и длинна должна быть больше 0"); }
            }
            else { MessageBox.Show("В поле имя не может быть цифр и длинна должна быть больше 0"); }

            return b;
        }
        public static int NCheck(string text)
        {
            int n = 0;
            if (text.IndexOf("1") == -1)
            {
                if (text.IndexOf("2") == -1)
                {
                    if (text.IndexOf("3") == -1)
                    {
                        if (text.IndexOf("4") == -1)
                        {
                            if (text.IndexOf("5") == -1)
                            {
                                if (text.IndexOf("6") == -1)
                                {
                                    if (text.IndexOf("7") == -1)
                                    {
                                        if (text.IndexOf("8") == -1)
                                        {
                                            if (text.IndexOf("9") == -1)
                                            {
                                                if (text.IndexOf("0") == -1)
                                                {
                                                    n = 0;
                                                }
                                                else { n = -1; }
                                            }
                                            else { n = -1; }
                                        }
                                        else { n = -1; }
                                    }
                                    else { n = -1; }
                                }
                                else { n = -1; }
                            }
                            else { n = -1; }
                        }
                        else { n = -1; }
                    }
                    else { n = -1; }
                }
                else { n = -1; }
            }
            else { n = -1; }


            return n;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Fields(FirstName.Text, LastName.Text, SecondName.Text, Age.Text, PassportNum.Text) == true)
            {
                workBD.Query($"Insert into Client (FirstName,LastName,SecondName,Age,PassportNumber) values (N'{FirstName.Text}',N'{LastName.Text}',N'{SecondName.Text}',{int.Parse(Age.Text)},N'{PassportNum.Text}')");

            }
            Close();
        }
    }
}
