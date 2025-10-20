using Datacliente;
using System;

namespace Negociocliente
{
    // Clase pública para que la Capa de Presentación pueda verla
    public class Negociocliente
    {
        private DataCliente dataCliente; // Variable para almacenar la instancia

        // --- PROPIEDADES PÚBLICAS ---
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

        // --- CONSTRUCTOR 1: Para la Interfaz de Usuario (usa el objeto real) ---
        // Este constructor es necesario para que Form1 pueda inicializar la clase.
        public Negociocliente()
        {
            dataCliente = new DataCliente();
        }

        // --- CONSTRUCTOR 2: Para las Pruebas Unitarias (Inyección de Dependencia) ---
        // Este constructor es necesario para que las pruebas puedan inyectar un simulador (Mock).
        public Negociocliente(DataCliente dc)
        {
            dataCliente = dc;
        }

        // --- MÉTODOS DE NEGOCIO (CRUD) ---

        public bool insertar()
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