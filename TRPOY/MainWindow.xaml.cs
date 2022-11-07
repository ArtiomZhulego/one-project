using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
using Xceed.Document.NET;
using Xceed.Words.NET;
using Image = Xceed.Document.NET.Image;
using Paragraph = Xceed.Document.NET.Paragraph;

namespace TRPOY
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        public static bool Fields(string FirstName,string LastName,string SecondName,string Age,string PassportNum)
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add1 win3 = new add1();
            win3.ShowDialog();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DB1.Visibility = Visibility.Visible;
            DB2.Visibility = Visibility.Visible;
            DB3.Visibility = Visibility.Visible;
            workBD.Select(DB1, "Select FirstName,LastName,SecondName,Age,PassportNumber From Client");
            workBD.Select(DB2, "Select idroom,IdClient,FData,LData From Room");
            workBD.Select(DB3, "Select Type,Sostav,Many From list");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (DB1.SelectedItem != null)
            {
                workBD.Query($"Delete From Client Where FirstName=N'{((DataRowView)DB1.SelectedItem).Row[0]}'");
                workBD.Select(DB1,"Select FirstName,LastName,SecondName,Age,PassportNumber From Client");
            }
            if (DB2.SelectedItem != null)
            {
                workBD.Query($"Delete From Room Where idroom={((DataRowView)DB2.SelectedItem).Row[0]}");
                workBD.Select(DB2, "Select idroom,IdClient,FData,LData From Room");
            }
            if (DB3.SelectedItem != null)
            {
                workBD.Query($"Delete From list Where Type=N'{((DataRowView)DB3.SelectedItem).Row[0]}'");
                workBD.Select(DB3, "Select Type,Sostav,Many From list");
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            workBD.Select(DB1, $"Select FirstName,LastName,SecondName,Age,PassportNumber From Client Where (FirstName LIKE N'{Search.Text}%') OR (LastName LIKE N'{Search.Text}%') OR (SecondName LIKE N'{Search.Text}%') OR (Age LIKE N'{Search.Text}%') OR (PassportNumber LIKE N'{Search.Text}%')");
            workBD.Select(DB2, $"Select idroom,IdClient,FData,LData From Room Where (idroom LIKE N'{Search.Text}%') OR (IdClient LIKE N'{Search.Text}%') OR (FData LIKE N'{Search.Text}%') OR (LData LIKE N'{Search.Text}%')");
            workBD.Select(DB3, $"Select Type,Sostav,Many From list Where (Type LIKE N'{Search.Text}%') OR (Sostav LIKE N'{Search.Text}%') OR (Many LIKE N'{Search.Text}%')");

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LastList win1 = new LastList();
            win1.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win1.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Add win4 = new Add();
            win4.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
            int count_row = DB1.Items.Count;
            int count_col = DB1.Columns.Count;


            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Open(String.Format(@"{0}\qqq" + ".xlsx", Environment.CurrentDirectory));
            //Таблица.
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            var Excelcells = ExcelWorkSheet.get_Range("B4", "D" + (2 + count_row).ToString());
            Excelcells.Borders.ColorIndex = 0;
            Excelcells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            Excelcells.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            Excelcells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            DataTable dataTable= workBD.Select("Select FirstName,LastName,SecondName,Age,PassportNumber From Client");


            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    DataColumn column = dataTable.Columns[j];
                   /* ExcelApp.Cells[3 + i, 1 + j] = column.ColumnName[j];*/
                    ExcelApp.Cells[4 + i, 2 + j] = dataRow[column].ToString();
                }

            }

            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (DB1.SelectedItem != null)
            {
                Change win = new Change();
                win.FirstName.Text = workBD.Change($"Select FirstName From Client Where FirstName=N'{((DataRowView)DB1.SelectedItem).Row[0]}'");
                win.ShowDialog();    
            }
            if (DB2.SelectedItem != null)
            {
                Change win = new Change();
                win.Room.Visibility = Visibility.Visible;
                win.Client.Visibility = Visibility.Collapsed;
                /* win.FirstName.Text = workBD.Change($"Select FirstName From Client Where FirstName=N'{((DataRowView)DB1.SelectedItem).Row[0]}'");*/
                win.ShowDialog();
            }
            if (DB2.SelectedItem != null)
            {
                Change win = new Change();
                win.list.Visibility = Visibility.Visible;
                win.Client.Visibility = Visibility.Collapsed;
                /* win.FirstName.Text = workBD.Change($"Select FirstName From Client Where FirstName=N'{((DataRowView)DB1.SelectedItem).Row[0]}'");*/
                win.ShowDialog();
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            CL1.Visibility = Visibility.Collapsed;
            BR2.Visibility = Visibility.Visible;
            DBN.Visibility = Visibility.Collapsed;
            DB1.Visibility = Visibility.Collapsed;
            DB2.Visibility = Visibility.Collapsed;
            DB3.Visibility = Visibility.Visible;
            workBD.Select(DB3, "Select Type,Sostav,Many From list");

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            CL1.Visibility = Visibility.Visible;
            BR2.Visibility = Visibility.Collapsed;
            DBN.Visibility = Visibility.Collapsed;
            DB1.Visibility = Visibility.Visible;
            workBD.Select(DB1, "Select FirstName,LastName,SecondName,Age,PassportNumber From Client");
            DB2.Visibility = Visibility.Collapsed;
            DB3.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            CL1.Visibility = Visibility.Collapsed;
            BR2.Visibility = Visibility.Collapsed;
            DBN.Visibility = Visibility.Visible;
            DB1.Visibility = Visibility.Collapsed;
            DB2.Visibility = Visibility.Visible;
            workBD.Select(DB2, "Select idroom,IdClient,FData,LData From Room");
            DB3.Visibility = Visibility.Collapsed;
        }

        private void word_Click(object sender, RoutedEventArgs e)
        {
            if (DB1.SelectedItem != null)
            {
                string pathDocument = AppDomain.CurrentDomain.BaseDirectory + "example.docx";
                string pathImage = AppDomain.CurrentDomain.BaseDirectory + "1.png";

                // создаём документ
                DocX document = DocX.Create(pathDocument);
                document.InsertParagraph("Гостиница «Старый город»                          Форма 3-Г").
                         // устанавливаем шрифт
                         Font("Courier New").
                         // устанавливаем размер шрифта
                         FontSize(12).
                         // устанавливаем цвет

                         // делаем текст жирным
                         Italic().
                         // устанавливаем интервал между символами

                         // выравниваем текст по центру
                         Alignment = Alignment.left;
                document.InsertParagraph("                                ").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;
                document.InsertParagraph("Город: Гомель                                               Утв. Приказом Минфин. ").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;
                document.InsertParagraph("                                ").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;
                document.InsertParagraph($"Клиент_____________{((DataRowView)DB1.SelectedItem).Row[0]}______{((DataRowView)DB1.SelectedItem).Row[1]}_____________{((DataRowView)DB1.SelectedItem).Row[2]}________").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;
                document.InsertParagraph("                                ").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;
              
                document.InsertParagraph("                                ").
                        // устанавливаем шрифт
                        Font("Courier New").
                        // устанавливаем размер шрифта
                        FontSize(12).
                        // устанавливаем цвет

                        // делаем текст жирным
                        Italic().
                        // устанавливаем интервал между символами

                        // выравниваем текст по центру
                        Alignment = Alignment.left;

                // загрузка изображения
                Image image = document.AddImage(pathImage);

                // создание параграфа
                Paragraph paragraph = document.InsertParagraph();
                // вставка изображения в параграф
                paragraph.AppendPicture(image.CreatePicture());
                // выравнивание параграфа по центру
                paragraph.Alignment = Alignment.center;
                paragraph.FontSize(10);

                // сохраняем документ
                document.Save();
            }
            else { MessageBox.Show("Выберите элемент из первой таблицы"); }
        }
        
    }
}
