using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using _2doParcial.Entidades;
using _2doParcial.BLL;


namespace _2doParcial.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRegistro.xaml
    /// </summary>
    public partial class rRegistro : Window
    {
        public List<LlamadasDetalle> Detalles { get; set; }
        Llamadas llamadas = new Llamadas(); /// Instancia para Bindings <summary>
        /// 
        /// </summary>
        public rRegistro()
        {
            InitializeComponent();
            this.Detalles = new List<LlamadasDetalle>();
            this.DataContext = llamadas;
            CargarGrid();

        }

        private void Refrescar()
        {
            this.DataContext = null;
            this.DataContext = llamadas;
        }
        private void Limpiar()
        {
            IdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            this.Detalles = new List<LlamadasDetalle>();
            CargarGrid();

        }

       /* private Llamadas LlenaClase()
        {
            Llamadas llamadas = new Llamadas();
            llamadas.LlamadaId = Convert.ToInt32(IdTextBox.Text);
            llamadas.Descripcion = DescripcionTextBox.Text;

            llamadas.Detalles = this.Detalles;

            return llamadas;
        }*/

       /* private void LlenaCampo(Llamadas llamadas)
        {
            IdTextBox.Text = Convert.ToString(llamadas.LlamadaId);
            DescripcionTextBox.Text = llamadas.Descripcion;
            this.Detalles = llamadas.Detalles;
            CargarGrid();
        }*/


        private void CargarGrid()
        {
            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = this.Detalles;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Llamadas llamadas;
            bool paso = false;

           // if (!Validar())
            //    return;

           // llamadas = LlenaClase ();
            Limpiar();

            //Determinar si es guardar o modificar

            if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                paso = LlamadasBLL.Guardar(llamadas);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = LlamadasBLL.Modificar(llamadas);
            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Llamadas llamadas = LlamadasBLL.Buscar((int)IdTextBox.Text.ToInt());
           return (llamadas != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                MessageBox.Show("EL campo Descripcion no puede estar vacio", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                DescripcionTextBox.Focus();
                paso = false;
            }
            if (this.Detalles.Count == 0)
            {
                MessageBox.Show("Debe agregar una Llamada", "Aviso", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                ProblemaTextBox.Focus();
                SolucionTextBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.ItemsSource != null)
            {
                this.Detalles = (List<LlamadasDetalle>)DetalleDataGrid.ItemsSource;
            }

            //Agregar un nuevo detalle con los datos introducidos
            this.Detalles.Add(new LlamadasDetalle
            {
                id = IdTextBox.Text.ToInt(),
                Problema = ProblemaTextBox.Text,
                Solucion = SolucionTextBox.Text,
                


            });
            CargarGrid();
            ProblemaTextBox.Focus();
            ProblemaTextBox.Clear();
            SolucionTextBox.Clear();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Llamadas llamadaAnterior = LlamadasBLL.Buscar(llamadas.LlamadaId);

            if (llamadaAnterior != null)
            {
                llamadas = llamadaAnterior;
                Refrescar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Llamada no encontrada");
            }
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count > 0 && DetalleDataGrid.SelectedItem != null)
            {
                //remover la fila
                Detalles.RemoveAt(DetalleDataGrid.SelectedIndex);
                CargarGrid();
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);

            Limpiar();

            if (LlamadasBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(IdTextBox.Text, "No se puede eliminar una llamada que no existe");
        }
    }
}
