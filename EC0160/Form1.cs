using System;
using System.Windows.Forms;
using Negociocliente;  
using Datacliente;


namespace EC0160.Presentation
{
    public partial class Form1 : Form
    {
        private NegocioCliente _negocioCliente;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _negocioCliente = new NegocioCliente();
                var clientes = _negocioCliente.ObtenerClientes();
                MessageBox.Show($"Clientes cargados: {clientes.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}