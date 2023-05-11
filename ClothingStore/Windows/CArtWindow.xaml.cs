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

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для CArtWindow.xaml
    /// </summary>
    public partial class CArtWindow : Window
    {
        public CArtWindow()
        {
            InitializeComponent();
            GetListProduct();
        }

        private void GetListProduct()
        {
            LvCartProduct.ItemsSource = ClassHelper.CartClass.products;
        }
    }
}
