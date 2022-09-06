using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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


//1.Переделайте тип Id записей в таблице на Guid (выполнено)
//2. Выполните первичную миграцию (Code First) (выполнено)
//3.Добавьте в БД таблицу с дисциплинами (предметами) по Code First (выполнено)
//4. Реализуйте функционал редактирования списка предметов (выполнено)
//5. Добавьте возможность указывать предмет в таблице посещаемости студентов (пока достаточно только ID)

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
        private async void button1_Click(object sender, RoutedEventArgs e)
        {    
            using (var db = new ApplicationContext())
            {
                await db.Students.AddAsync(new Student() { Id = Guid.NewGuid(), Name = texbox1.Text, DataPosechenia = textbox4.Text });
                await db.Visiting.AddAsync(new DateOfVisit() { Id = Guid.NewGuid(), Visit = texbox2.Text, IdKey = Guid.NewGuid() });
                db.SaveChanges();
                MessageBox.Show($"Информация успешно добавлена");
            }
        }
        private async void button2_Click(object sender, RoutedEventArgs e)
        {
           using (ApplicationContext db = new ApplicationContext())
           {
                var list = await db.Disciplines.Include(it => it.DateOfVisit).ToListAsync();
                datagrid.ItemsSource = list; 
            }

        }
        private async void button3_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new ApplicationContext())
            {
                await db.Disciplines.AddAsync(new TableOfDiscipline() { Id = Guid.NewGuid(), Discipline= texbox.Text });
                db.SaveChanges();
                MessageBox.Show($"Информация успешно добавлена");
            }


            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    var itog = db.Visiting.Join(db.Student, 
            //            u => u.IdKey, 
            //            c => c.Id,          
            //            (u,c) => new 
            //            {
            //                Id = u.Id,
            //                Name = c.Name,
            //                DataPosechenia = c.DataPosechenia,
            //                Visit = u.Visit
            //            }).ToList();
            //    datagrid.ItemsSource = itog;
            //}
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
