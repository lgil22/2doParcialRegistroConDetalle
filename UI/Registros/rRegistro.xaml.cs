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




        private void CargarGrid()
        {
            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = this.Detalles;
        }

    }
}
