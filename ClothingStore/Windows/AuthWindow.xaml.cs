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
using static ClothingStore.ClassHelper.EFClass;

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // поиск пользователя
            var userAuth = Context.User.ToList()
                .Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password)
                .FirstOrDefault();

            // проверка на работника
            if (userAuth != null)
            {
                // сохранияем данные входа
                ClassHelper.UserDataClass.User = userAuth;

                var emplAuth = Context.Employee.Where(i => i.IDUser == userAuth.IDUser).FirstOrDefault();
                if (emplAuth != null)
                {
                    // если не пустой то Работник

                    // сохранияем данные входа

                    ClassHelper.UserDataClass.Employee = emplAuth;

                    // проверка роли 

                    switch (emplAuth.IDPosition)
                    {
                        case 1:
                            // переход на страницу директора
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                            break;

                        case 2:
                            // переход на страницу администратора
                            break;
                        case 3:
                            // переход на страницу продавца
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    // Client

                    // сохраняем клиента
                    ClassHelper.UserDataClass.Client = userAuth;


                    ProductListWindow productListWindow = new ProductListWindow();
                    productListWindow.Show();
                    this.Close();

                }


            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}

/////////////////////
