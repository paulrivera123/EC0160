using System;
using System.Collections.Generic;
using System.Data;
using EC0160.Data;  // ← AGREGAR este using

namespace EC0160.Business
{
    public class NegocioCliente
    {
        private readonly IDataCliente _dataCliente;

        // Constructor para la Interfaz de Usuario
        public NegocioCliente()
        {
            _dataCliente = new DataCliente();
        }

        // Constructor para Pruebas Unitarias (Inyección de Dependencias)
        public NegocioCliente(IDataCliente dataCliente)
        {
            _dataCliente = dataCliente ?? throw new ArgumentNullException(nameof(dataCliente));
        }

        public List<Cliente> ObtenerClientes()
        {
            try
            {
                var dataTable = _dataCliente.ObtenerClientes();
                var clientes = new List<Cliente>();

                foreach (DataRow row in dataTable.Rows)
                {
                    clientes.Add(new Cliente
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Nombre = row["Nombre"].ToString(),
                        Apellido = row["Apellido"].ToString(),
                        Email = row["Email"].ToString(),
                        Telefono = row["Telefono"].ToString(),
                        Direccion = row["Direccion"].ToString()
                    });
                }

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener clientes: {ex.Message}", ex);
            }
        }

        public int CrearCliente(Cliente cliente)
        {
            try
            {
                return _dataCliente.CrearCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear cliente: {ex.Message}", ex);
            }
        }

        public int ActualizarCliente(Cliente cliente)
        {
            try
            {
                return _dataCliente.ActualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar cliente: {ex.Message}", ex);
            }
        }

        public int EliminarCliente(int id)
        {
            try
            {
                return _dataCliente.EliminarCliente(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar cliente: {ex.Message}", ex);
            }
        }
    }
}