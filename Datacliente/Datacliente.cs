using System;
using System.Data;
using System.Data.SqlClient;

namespace Datacliente
{ 
      public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
}

    public interface IDataCliente
    {
        DataTable ObtenerClientes();
        int CrearCliente(Cliente cliente);
        int ActualizarCliente(Cliente cliente);
        int EliminarCliente(int id);
    }

    public class DataCliente : IDataCliente
    {
        private readonly string _connectionString;

        public DataCliente()
        {
            _connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=True";
        }

        public DataTable ObtenerClientes()
        {
            var dataTable = new DataTable();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("SELECT * FROM Customers", connection))
                using (var adapter = new SqlDataAdapter(command))
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener clientes: {ex.Message}", ex);
            }

            return dataTable;
        }

        public int CrearCliente(Cliente cliente)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(
                    "INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) " +
                    "VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)", connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", cliente.Id.ToString());
                    command.Parameters.AddWithValue("@CompanyName", cliente.Nombre);
                    command.Parameters.AddWithValue("@ContactName", cliente.Apellido);
                    command.Parameters.AddWithValue("@ContactTitle", DBNull.Value);
                    command.Parameters.AddWithValue("@Address", cliente.Direccion);
                    command.Parameters.AddWithValue("@City", DBNull.Value);
                    command.Parameters.AddWithValue("@Region", DBNull.Value);
                    command.Parameters.AddWithValue("@PostalCode", DBNull.Value);
                    command.Parameters.AddWithValue("@Country", DBNull.Value);
                    command.Parameters.AddWithValue("@Phone", cliente.Telefono);
                    command.Parameters.AddWithValue("@Fax", DBNull.Value);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
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
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(
                    "UPDATE Customers SET CompanyName = @CompanyName, ContactName = @ContactName, " +
                    "Address = @Address, Phone = @Phone WHERE CustomerID = @CustomerID", connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", cliente.Id.ToString());
                    command.Parameters.AddWithValue("@CompanyName", cliente.Nombre);
                    command.Parameters.AddWithValue("@ContactName", cliente.Apellido);
                    command.Parameters.AddWithValue("@Address", cliente.Direccion);
                    command.Parameters.AddWithValue("@Phone", cliente.Telefono);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
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
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @CustomerID", connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", id.ToString());

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar cliente: {ex.Message}", ex);
            }
        }
    }
}