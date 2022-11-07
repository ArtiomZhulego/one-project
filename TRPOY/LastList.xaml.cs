using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TRPOY
{
    /// <summary>
    /// Логика взаимодействия для LastList.xaml
    /// </summary>
    public partial class LastList : Window
    {
        public LastList()
        {
            InitializeComponent();
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
            workBD.Query($"Insert into Room (idroom,idClient,FData,LData) values (N'{idroom.Text}',N'{idClient.Text}',N'{FData.Text}',N'{LData.Text}')");
            Close();
        }
    }
}
