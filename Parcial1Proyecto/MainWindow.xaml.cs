using Parcial1Proyecto.BLL;
using Parcial1Proyecto.Entidades;
using Parcial1Proyecto.UI;
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

namespace Parcial1Proyecto
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

     /*   private void Calcular(Articulos articulos)
        {
            Articulos articulos;

            int Exis, Cos, total;

            Exis = Convertarticulos.Existencia;
            Cos = articulos.Costo;

            total = Exis * Cos;

            return total;
        } */

        private void Limpiar()
        {
            Id_Text.Text = "0";
            Descripcion_Text.Text = String.Empty;
            Existencia_Text.Text = "0";
            Costo_Text.Text = "0";
            ValorInventario_Text.Text = "0";
        }

        private bool Validar()
        {
            bool paso = true;

            if(Id_Text.Text == String.Empty)
            {
                MessageBox.Show("El Id esta Vacio");
                Id_Text.Focus();
                paso = false;
            }

            if(Descripcion_Text.Text == String.Empty)
            {
                MessageBox.Show("La Descripcion esta Vacia");
                Descripcion_Text.Focus();
                paso = false;
            }

            if(Existencia_Text.Text == String.Empty)
            {
                MessageBox.Show("La Existencia esta Vacia");
                Existencia_Text.Focus();
                paso = false;
            }

            if(Costo_Text.Text == String.Empty)
            {
                MessageBox.Show("El Costo esta Vacio");
                Costo_Text.Focus();
                paso = false;
            }

            if (ValorInventario_Text.Text == String.Empty)
            {
                MessageBox.Show("El ValorInventario esta Vacio");
                ValorInventario_Text.Focus();
                paso = false;
            }

            return paso;
        }

        private Articulos LlenaClase()
        {
            Articulos articulos = new Articulos();

            articulos.ProductoId = Convert.ToInt32(Id_Text.Text);
            articulos.Descripcion = Descripcion_Text.Text;
            articulos.Existencia = Convert.ToInt32(Existencia_Text.Text);
            articulos.Costo = Convert.ToInt32(Costo_Text.Text);
            articulos.ValorInventario = Convert.ToInt32(ValorInventario_Text.Text);

            return articulos;
        }

        private void LlenaCampo(Articulos articulos)
        {
            Id_Text.Text = Convert.ToString(articulos.ProductoId);
            Descripcion_Text.Text = articulos.Descripcion;
            Existencia_Text.Text = Convert.ToString(articulos.Existencia);
            Costo_Text.Text = Convert.ToString(articulos.Costo);
            ValorInventario_Text.Text = Convert.ToString(articulos.ValorInventario);
        }

        private bool ExisteBase()
        {
            Articulos articulos = ArticulosBLL.Buscar((int)Convert.ToInt32(Id_Text.Text));

            return (articulos != null);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int Id;
            int.TryParse(Id_Text.Text, out Id);

            Articulos articulos = new Articulos();
            articulos = ArticulosBLL.Buscar(Id);

            Limpiar();

            if(articulos != null)
            {
                LlenaCampo(articulos);
                MessageBox.Show("Encontrado");
            }
            else
            {
                MessageBox.Show("No Encontrado");
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Articulos articulos;

            if (!Validar())
            {
                return;
            }

            articulos = LlenaClase();

            if (Id_Text.Text == "0")
            {
                paso = ArticulosBLL.Guardar(articulos);
            }
            else
            {
                if (!ExisteBase())
                {
                    MessageBox.Show("No existe en la Base de Datos");
                    return;
                }
                paso = ArticulosBLL.Modificar(articulos);
            }

            Limpiar();

            if (paso)
            {
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("ERROR");
            }

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int Id;
            int.TryParse(Id_Text.Text, out Id);

            Limpiar();

            if (ArticulosBLL.Eliminar(Id))
            {
                MessageBox.Show("Eliminado");
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
        private void Consultar_Click(object sender, RoutedEventArgs e)
        {
            ConsultaWindow cw = new ConsultaWindow();
            cw.ShowDialog();
        }

        private void Existencia_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValorInventario_Text.Text = "50";
        }

        private void Costo_Text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
