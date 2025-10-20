using Datacliente;
using System;

namespace Negociocliente
{
    // Esta clase debe ser pública para que la Capa de Presentación la vea
    public class Negociocliente
    {
        // Declara el campo sin inicializar para que pueda ser inyectado (mocked)
        private DataCliente dataCliente;

        // --- PROPIEDADES PÚBLICAS --- (Usadas por la Capa de Presentación)
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        // --- CONSTRUCTOR 1: Para la Capa de Presentación (Usa el objeto real) ---
        public Negociocliente()
        {
            dataCliente = new DataCliente();
        }

        // --- CONSTRUCTOR 2: Para las Pruebas Unitarias (Usa el objeto inyectado/simulado) ---
        public Negociocliente(DataCliente dc)
        {
            dataCliente = dc;
        }

        // --- MÉTODOS DE NEGOCIO (CRUD) ---

        public bool insertar()
        {
            // Mapeamos las propiedades de esta clase a la entidad Customer (POCO)
            var customer = new Customer
            {
                CustomerID = this.CustomerID,
                CompanyName = this.CompanyName,
                ContactName = this.ContactName,
                ContactTitle = this.ContactTitle,
                Address = this.Address,
                City = this.City,
                Region = this.Region,
                PostalCode = this.PostalCode,
                Country = this.Country,
                Phone = this.Phone,
                Fax = this.Fax
            };

            // Llamada a la Capa de Datos
            return dataCliente.insertarCustomer(customer);
        }

        public bool actualizar()
        {
            var customer = new Customer
            {
                CustomerID = this.CustomerID,
                CompanyName = this.CompanyName,
                ContactName = this.ContactName,
                ContactTitle = this.ContactTitle,
                Address = this.Address,
                City = this.City,
                Region = this.Region,
                PostalCode = this.PostalCode,
                Country = this.Country,
                Phone = this.Phone,
                Fax = this.Fax
            };
            return dataCliente.actualizarCustomer(customer);
        }

        public bool eliminar()
        {
            return dataCliente.eliminarCustomer(this.CustomerID);
        }

        public bool cargar()
        {
            // La capa de datos devuelve la entidad, y llenamos las propiedades de esta clase
            Customer customerEncontrado = dataCliente.cargarCustomer(this.CustomerID);

            if (customerEncontrado != null)
            {
                this.CustomerID = customerEncontrado.CustomerID;
                this.CompanyName = customerEncontrado.CompanyName;
                this.ContactName = customerEncontrado.ContactName;
                this.ContactTitle = customerEncontrado.ContactTitle;
                this.Address = customerEncontrado.Address;
                this.City = customerEncontrado.City;
                this.Region = customerEncontrado.Region;
                this.PostalCode = customerEncontrado.PostalCode;
                this.Country = customerEncontrado.Country;
                this.Phone = customerEncontrado.Phone;
                this.Fax = customerEncontrado.Fax;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}