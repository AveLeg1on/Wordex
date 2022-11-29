using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Wordex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Field_KeyDown(object sender, KeyEventArgs e)
        {
            helps.Content = null;
            if (e.Key == Key.Enter)
            {
                LB.Items.Add(Field.Text);
                Field.Text = null;
            }
        }

        private void Modernization_Click(object sender, RoutedEventArgs e)
        {
            helps.Content = null;
            Regex regex = new Regex(@"[23]\+*[23]");
            Regex regex1 = new Regex(@"\*\w+\+");
            MatchCollection matches;
            int i;
            string tmp;

            if (LB.SelectedItem != null)
            {
                if (regex.IsMatch(LB.SelectedItem.ToString()))
                {
                    matches = null;
                    tmp = null;
                    tmp = LB.SelectedItem.ToString();
                    matches = regex.Matches(tmp);
                    if (matches.Count > 0)
                    {
                        //tmp = null;
                        //for (int z = 0; z < matches.Count; z++)
                        //{
                        //    tmp += matches[z].ToString() + " ";
                        //}


                        i = LB.SelectedIndex;
                        LB.Items.RemoveAt(i);
                        LB.Items.Insert(i, string.Join(" ",regex.Matches(tmp)));

                    }
                }
                else
                {
                    if (regex1.IsMatch(LB.SelectedItem.ToString()))
                    {
                        matches = null;
                        tmp = null;
                        tmp = LB.SelectedItem.ToString();
                        matches = regex1.Matches(tmp);
                        if (matches.Count > 0)
                        {
                            tmp = null;
                            for (int z = 0; z < matches.Count; z++)
                            {
                                tmp += matches[z].ToString() + " ";
                            }

                            i = LB.SelectedIndex;
                            LB.Items.RemoveAt(i);
                            LB.Items.Insert(i, tmp);
                        }
                    }


                }


            }
        }

        private void Destroy_Click(object sender, RoutedEventArgs e)
        {
            LB = null;

        }

        private void FAQ(object sender, RoutedEventArgs e)
        {
            
            helps.Content = " Разработчик: Денисов Олег. 1) Дана строка '23 2+3 2++3 2+++3 445 677'. Напишите \nрегулярное выражение, которое найдет строки 23, 2+3, 2++3, 2+++3, не захватив остальные.\r\n2)Дана строка '*+ *q+ *qq+ *qqq+ *qqq qqq+'.+ Напишите регулярное выражение, \r\nкоторое найдет строки *q+, *qq+, *qqq+, не захватив остальные";
        }
    }
}
