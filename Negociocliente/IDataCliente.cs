using System.Data;
using Datacliente;

namespace Negociocliente
{
    public interface IDataCliente
    {
        DataTable ObtenerClientes();
        int CrearCliente(Customer cliente);
        int ActualizarCliente(Customer cliente);
        int EliminarCliente(string customerID);
    }
}