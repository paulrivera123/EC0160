partial class Form1
{
    /// <summary>
    /// Variable del diseñador necesaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpiar los recursos que se estén usando.
    /// </summary>
    /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de componentes

    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
        this.txtCustomerID = new System.Windows.Forms.TextBox();
        this.txtCompanyName = new System.Windows.Forms.TextBox();
        this.txtContactName = new System.Windows.Forms.TextBox();
        this.txtContactTitle = new System.Windows.Forms.TextBox();
        this.txtAddress = new System.Windows.Forms.TextBox();
        this.txtCity = new System.Windows.Forms.TextBox();
        this.txtRegion = new System.Windows.Forms.TextBox();
        this.txtPostalCode = new System.Windows.Forms.TextBox();
        this.txtCountry = new System.Windows.Forms.TextBox();
        this.txtPhone = new System.Windows.Forms.TextBox();
        this.txtFax = new System.Windows.Forms.TextBox();
        this.btnInsertar = new System.Windows.Forms.Button();
        this.btnConsultar = new System.Windows.Forms.Button();
        this.btnActualizar = new System.Windows.Forms.Button();
        this.btnEliminar = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(600, 450);
        this.Name = "Form1";
        this.ResumeLayout(false);

    }

    #endregion

    // DECLARACIÓN DE CONTROLES (Crucial para el código-behind)
    private System.Windows.Forms.TextBox txtCustomerID;
    private System.Windows.Forms.TextBox txtCompanyName;
    private System.Windows.Forms.TextBox txtContactName;
    private System.Windows.Forms.TextBox txtContactTitle;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.TextBox txtCity;
    private System.Windows.Forms.TextBox txtRegion;
    private System.Windows.Forms.TextBox txtPostalCode;
    private System.Windows.Forms.TextBox txtCountry;
    private System.Windows.Forms.TextBox txtPhone;
    private System.Windows.Forms.TextBox txtFax;
    private System.Windows.Forms.Button btnInsertar;
    private System.Windows.Forms.Button btnConsultar;
    private System.Windows.Forms.Button btnActualizar;
    private System.Windows.Forms.Button btnEliminar;
}
}