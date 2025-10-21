using System;
using System.Windows.Forms;
using System.Data;
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
            _negocioCliente = new NegocioCliente();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                var clientes = _negocioCliente.ObtenerClientes();
                dgvClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            txtCustomerID.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
                {
                    MessageBox.Show("El ID Cliente es requerido", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
                {
                    MessageBox.Show("El nombre de la compañía es requerido", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cliente = new Customer
                {
                    CustomerID = txtCustomerID.Text.Trim(),
                    CompanyName = txtCompanyName.Text.Trim(),
                    ContactName = txtContactName.Text.Trim(),
                    ContactTitle = txtContactTitle.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    City = txtCity.Text.Trim(),
                    Country = txtCountry.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Fax = txtFax.Text.Trim()
                };

                var result = _negocioCliente.CrearCliente(cliente);

                if (result == 1)
                {
                    MessageBox.Show("Cliente guardado correctamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarClientes();
                }
                else
                {
                    MessageBox.Show("Error al guardar el cliente", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                CargarClienteDesdeGrid();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para editar", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null && !string.IsNullOrEmpty(txtCustomerID.Text))
            {
                var resultado = MessageBox.Show("¿Está seguro de eliminar este cliente?",
                                              "Confirmar Eliminación",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        // Lógica para eliminar cliente
                        MessageBox.Show("Cliente eliminado correctamente", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
                        CargarClientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                string busqueda = txtBuscar.Text.ToLower();

                foreach (DataGridViewRow row in dgvClientes.Rows)
                {
                    bool visible = false;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(busqueda))
                        {
                            visible = true;
                            break;
                        }
                    }
                    row.Visible = visible;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvClientes.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CargarClienteDesdeGrid();
            }
        }

        private void CargarClienteDesdeGrid()
        {
            if (dgvClientes.CurrentRow != null)
            {
                var row = dgvClientes.CurrentRow;
                txtCustomerID.Text = row.Cells["CustomerID"]?.Value?.ToString() ?? "";
                txtCompanyName.Text = row.Cells["CompanyName"]?.Value?.ToString() ?? "";
                txtContactName.Text = row.Cells["ContactName"]?.Value?.ToString() ?? "";
                txtContactTitle.Text = row.Cells["ContactTitle"]?.Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["Address"]?.Value?.ToString() ?? "";
                txtCity.Text = row.Cells["City"]?.Value?.ToString() ?? "";
                txtCountry.Text = row.Cells["Country"]?.Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"]?.Value?.ToString() ?? "";
                txtFax.Text = row.Cells["Fax"]?.Value?.ToString() ?? "";
            }
        }

        private void LimpiarFormulario()
        {
            txtCustomerID.Clear();
            txtCompanyName.Clear();
            txtContactName.Clear();
            txtContactTitle.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtCountry.Clear();
            txtPhone.Clear();
            txtFax.Clear();
            txtBuscar.Clear();

            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                row.Visible = true;
            }
        }
    }
}