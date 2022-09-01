using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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


//Задача: Создать удобное приложение учета посещаемости студентов с графическим интерфейсом.
//1 Создайте проект WPF.OK
//2 Добавьте к проекту EF Core с СУБД SQLite OK
//3 Добавьте в БД таблицу со студентами и таблицу посещаемость OK
//4 Выведите список всех студентов на форму  OK
//5 Добавьте возможность добавлять новых студентов в БД  Ok
//6 Реализуйте отображение посещаемости студентов для выбранной даты
//7 Добавьте возможность отмечать посещения студентов в приложении

namespace EF_Core_posgrest
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
        private void button1_Click(object sender, RoutedEventArgs e)
        {
             var idTables = int.Parse(texbox.Text);
            using (var db = new ApplicationContext())
            {
                db.Student.AddRange(new Students() { Id = idTables, Name = texbox1.Text, DataPosechenia = textbox4.Text });
                db.SaveChanges();
                db.Visiting.AddRange(new DateOfVisit() { Id = idTables, Visit = texbox2.Text, IdKey = idTables });
                db.SaveChanges();
                MessageBox.Show($"Информация успешно добавлена");
            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
           using (ApplicationContext db = new ApplicationContext())
           {               
                var students = db.Student.ToList();
                datagrid.ItemsSource = students;
            }
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var itog = db.Visiting.Join(db.Student, 
                        u => u.IdKey, 
                        c => c.Id,          
                        (u,c) => new 
                        {
                            Id = u.Id,
                            Name = c.Name,
                            DataPosechenia = c.DataPosechenia,
                            Visit = u.Visit
                        }).ToList();
                datagrid.ItemsSource = itog;
            }
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            texbox.Text = null;
            texbox1.Text = null;
            texbox2.Text=null;
            textbox4.Text = null;          
        }      
    }
}
