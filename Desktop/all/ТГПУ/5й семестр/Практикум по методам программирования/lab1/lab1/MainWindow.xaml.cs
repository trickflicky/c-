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
using Microsoft.Win32;
using System.Collections;

namespace lab1
{
    
    public partial class MainWindow : Window
    {
        int k;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btex_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btsave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Текст(*.TXT)|*.TXT" + "|Все файлы (*.*)|*.* ";

            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    foreach (Object item in lbResult.Items)
                    {
                        file.WriteLine(item);
                    }
                }
            }
        }

        private void btmath1_Click(object sender, RoutedEventArgs e)
        {
            int res1 = 0;
            
            lbResult.Items.Clear();
            int n = Convert.ToInt32(tbInput.Text);
            int[] mass = new int[n];
            Random rand = new Random();
            int num;
            for(int i = 0; i< n; i++)
            {
                num = -100 + rand.Next(200);
                lbResult.Items.Add(num);
                mass[i] = num;
            }
            //---Задание 1---//

            
            for (int i = 0; i < n; i++)
            {
                if (i != 0 && i != n - 1)
                {
                   if(mass[i] > mass[i-1] && mass[i] > mass[i+1])
                    {
                        res1++;
                        lbResult.Items[i + 1] += " - больше предыдущего";
                        lbResult.Items[i - 1] += " - меньше следущего";
                    }
                }
            }
            tbz1.Text = Convert.ToString(res1);
            //---Задание 2---//
                for (int i = 0; i < n; i++)
                {
                    if (mass[i] > 25)
                    {
                        tbz2.Text = Convert.ToString(i);
                        break;
                    }
                }
            //---Задание 3---//
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                int t = mass[1];
                
                if (mass[i] > t)
                {
                    res += mass[i];
                }
            }
            tbz3.Text = Convert.ToString(res);
            //---Задание 4---//
                for (int i = 0; i < n; i++)
                {
                    if (mass[i] > k)
                    {
                        tbz4.Text = Convert.ToString(i);
                    break;
                    }
                }
            //---Задание 5---//
            int ress1 = 0;
            for (int i = 0; i < n; i++)
            {

                if (mass[i] > k)
                {
                    ress1 += mass[i];
                }
            }
            tbz5.Text = Convert.ToString(ress1);
        }
        

        private void btmath2_Click(object sender, RoutedEventArgs e)
        {
            lbResult.Items.Clear();

            ArrayList arrlist = new ArrayList();

            int n = Convert.ToInt32(tbInput.Text);
            Random rand = new Random();
            int num;
            lbResult.Items.Add("Исходный массив: ");
            for (int i = 1; i < n; i++)
            {
                num = -100 + rand.Next(200);
                arrlist.Add(num);
                lbResult.Items.Add(num);
            }
            lbResult.Items.Add("Отсортированный массив: ");
            arrlist.Sort();
            foreach (int elem in arrlist)
            {
                lbResult.Items.Add(elem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 inpK = new Window1();
            inpK.ShowDialog();
            if (inpK.flag == 1)
            {
                k = Convert.ToInt32(inpK.tbK.Text);

            }
            if (inpK.flag == 0)
            {
                MessageBox.Show("Вы не ввели К!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
