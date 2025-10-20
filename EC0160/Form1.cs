using System;
using System.Windows.Forms;
using Negociocliente;

namespace EC0160.Presentation
{
    public partial class Form1 : Form
    {
        // Instancia de la clase de negocio (usando el nombre de clase completo)
        private Negociocliente.Negociocliente negocio = new Negociocliente.Negociocliente();

        public Form1()
        {
            // Esta es la ÚNICA llamada a la inicialización de controles
            InitializeComponent();
        }

        // --- MÉTODOS AUXILIARES ---

        private void MapControlsToNegocio()
        {
            negocio.CustomerID = txtCustomerID.Text;
            negocio.CompanyName = txtCompanyName.Text;
            negocio.ContactName = txtContactName.Text;
            negocio.ContactTitle = txtContactTitle.Text;
            negocio.Address = txtAddress.Text;
            negocio.City = txtCity.Text;
            negocio.Region = txtRegion.Text;
            negocio.PostalCode = txtPostalCode.Text;
            negocio.Country = txtCountry.Text;
            negocio.Phone = txtPhone.Text;
            negocio.Fax = txtFax.Text;
        }

        private void MapNegocioToControls()
        {
            txtCustomerID.Text = negocio.CustomerID;
            txtCompanyName.Text = negocio.CompanyName;
            txtContactName.Text = negocio.ContactName;
            txtContactTitle.Text = negocio.ContactTitle;
            txtAddress.Text = negocio.Address;
            txtCity.Text = negocio.City;
            txtRegion.Text = negocio.Region;
            txtPostalCode.Text = negocio.PostalCode;
            txtCountry.Text = negocio.Country;
            txtPhone.Text = negocio.Phone;
            txtFax.Text = negocio.Fax;
        }

        private void ClearControls()
        {
            txtCustomerID.Clear();
            txtCompanyName.Clear();
            txtContactName.Clear();
            txtContactTitle.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtRegion.Clear();
            txtPostalCode.Clear();
            txtCountry.Clear();
            txtPhone.Clear();
            txtFax.Clear();
        }

        // --- Eventos de los Botones (CRUD) ---

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            MapControlsToNegocio();
            if (string.IsNullOrEmpty(negocio.CustomerID))
            {
                MessageBox.Show("El ID del cliente no puede estar vacío.", "Error de Inserción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (negocio.insertar())
            {
                MessageBox.Show("Cliente agregado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls();
            }
            else
            {
                MessageBox.Show("Error: El cliente ya existe o faltan datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            negocio.CustomerID = txtCustomerID.Text;
            if (negocio.cargar())
            {
                MapNegocioToControls();
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearControls();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MapControlsToNegocio();
            if (negocio.actualizar())
            {
                MessageBox.Show("Cambio exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: El ID del cliente no existe.", "Error de Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            negocio.CustomerID = txtCustomerID.Text;
            if (negocio.eliminar())
            {
                MessageBox.Show("Cliente borrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearControls();
            }
            else
            {
                MessageBox.Show("Error: ID inexistente o el cliente tiene órdenes asociadas.", "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}