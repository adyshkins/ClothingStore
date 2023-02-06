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

using ClothingStore.ClassHelper;
using ClothingStore.Windows;
using ClothingStore.DB;

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EFClass.Context.Gender.ToList();
            CmbGender.SelectedIndex = 0;
            CmbGender.DisplayMemberPath = "GenderName";
        }

        private void BtnAdduser_Click(object sender, RoutedEventArgs e)
        {
            EFClass.Context.User.Add(new User() 
            { 
                Login = TbLogin.Text,
                Password = PbPassword.Password,
                LastName = TbLName.Text,
                FirstName = TbFName.Text,
                Patronymic = TbPatronymic.Text,
                Email = TbEmail.Text,
                PhoneNumber = TbPhone.Text,
                Birthday = DPDateOfBirth.SelectedDate.Value,
                IDGender = (CmbGender.SelectedItem as Gender).IDGender,

            });

            EFClass.Context.SaveChanges();

            MessageBox.Show("Ok");


        }
    }
}
