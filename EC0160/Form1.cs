using System;
using System.Windows.Forms;
using Negociocliente; // Usamos el namespace de la capa de Negocio

namespace EC0160.Presentation
{
    // El modificador 'partial' es crucial para que el código se fusione con el diseño visual.
    public partial class Form1 : Form
    {
        private TextBox txtCustomerID;
        private TextBox txtCompanyName;
        private TextBox txtContactTitle;
        private TextBox txtContactName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtCountry;
        private TextBox txtPostalCode;
        private TextBox txtRegion;
        private TextBox txtCity;
        private TextBox txtFax;
        private Button btnInsertar;
        private Button btnConsultar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;

        // Instancia de la clase de negocio. 
        private Negociocliente.Negociocliente negocio = new Negociocliente.Negociocliente();

        public Form1()
        {
        }

        // --- MÉTODOS AUXILIARES ---

        // Mapea los datos del formulario a las propiedades del objeto de Negocio
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

        // Mapea los datos del objeto de Negocio (después de una consulta) al formulario
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

        // Limpia todos los campos del formulario
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

        // --- EVENTOS DE LOS BOTONES (CRUD) ---

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

        private void InitializeComponent()
        {
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtContactTitle = new System.Windows.Forms.TextBox();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(280, 30);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(100, 22);
            this.txtCustomerID.TabIndex = 0;
            this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(280, 67);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(100, 22);
            this.txtCompanyName.TabIndex = 1;
            // 
            // txtContactTitle
            // 
            this.txtContactTitle.Location = new System.Drawing.Point(280, 145);
            this.txtContactTitle.Name = "txtContactTitle";
            this.txtContactTitle.Size = new System.Drawing.Size(100, 22);
            this.txtContactTitle.TabIndex = 3;
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(280, 105);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(100, 22);
            this.txtContactName.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(280, 186);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 22);
            this.txtAddress.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(518, 186);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 22);
            this.txtPhone.TabIndex = 9;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(518, 145);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(100, 22);
            this.txtCountry.TabIndex = 8;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(518, 105);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(100, 22);
            this.txtPostalCode.TabIndex = 7;
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(518, 67);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(100, 22);
            this.txtRegion.TabIndex = 6;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(518, 30);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(100, 22);
            this.txtCity.TabIndex = 5;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(692, 30);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(100, 22);
            this.txtFax.TabIndex = 10;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(876, 17);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 11;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(876, 57);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 12;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(876, 95);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 13;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(876, 144);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "ID Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Compañia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Nombre de contacto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Titulo de contacto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Dirección";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ciudad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Región";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(421, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Código postal";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(454, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "País";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(454, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Teléfono";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(657, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "Fax";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1087, 253);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtContactTitle);
            this.Controls.Add(this.txtContactName);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.txtCustomerID);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}