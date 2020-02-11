using Parcial1Proyecto.BLL;
using Parcial1Proyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Parcial1Proyecto.UI
{
    /// <summary>
    /// Interaction logic for ConsultaWindow.xaml
    /// </summary>
    public partial class ConsultaWindow : Window
    {
        public ConsultaWindow()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Articulos> listado = new List<Articulos>();
            listado = ArticulosBLL.GetList(articulo => true);

            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = listado;
        }
    }
}
