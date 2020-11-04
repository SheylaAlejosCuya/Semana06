using Bussines;
using Entity;
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

namespace Semana06
{
   
    public partial class ManProducto : Window
    {
        public int ID { get; set; }
        public ManProducto(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BtnEliminar.Opacity = 100;
                BtnEliminar.IsEnabled = true;

                BProducto bProducto = new BProducto();
                List<Producto> productos = new List<Producto>();
                productos = bProducto.Listar(ID);
                if (productos.Count > 0)
                {
                    lblID.Content = productos[0].IdProducto;
                    txtNombre.Text = productos[0].NombreProducto;
                    txtCantidad.Text = productos[0].CantidadPorUnidad;
                    txtPrecio.Text = productos[0].PrecioUnidad.ToString();
                }

            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto BProducto = null;
            bool result = true;
            try
            {
                BProducto = new BProducto();
                if (this.ID > 0)
                {
                    result = BProducto.Actualizar(new Producto { IdProducto = this.ID, NombreProducto = txtNombre.Text, CantidadPorUnidad = txtCantidad.Text, PrecioUnidad = Convert.ToInt32(txtPrecio.Text) });
                }
                else
                {
                    result = BProducto.Insertar(new Producto { NombreProducto = txtNombre.Text, CantidadPorUnidad = txtCantidad.Text, PrecioUnidad = Convert.ToInt32(txtPrecio.Text) });
                }

                if (!result)
                {
                    MessageBox.Show("Error");
                }

                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Comunicarse con el administrador");
            }
            finally
            {
                BProducto = null;
            }
        }
        private void BtnEliminar_Click(Object sender, RoutedEventArgs e)
        {
            BProducto BProducto = null;
            bool result = true;
            try
            {
                BProducto = new BProducto();
                if (this.ID > 0)
                {
                    result = BProducto.Eliminar(this.ID);
                }

                if (!result)
                {
                    MessageBox.Show("Error al eliminar");
                }

                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Comunicarse con el administrador");
            }
            finally
            {
                BProducto = null;
            }
        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
