using System.Data;
using Datacliente;

namespace Negociocliente
{
    public class NegocioCliente
    {
        private readonly IDataCliente _dataCliente;

        // Constructor que acepta IDataCliente (para pruebas)
        public NegocioCliente (IDataCliente dataCliente)
        {
            _dataCliente = dataCliente;
        }

        // Constructor sin parámetros (para el formulario)
        public NegocioCliente() : this(new DataCliente())
        {
        }

        public DataTable ObtenerClientes()
        {
            if (_dataCliente != null)
                return _dataCliente.ObtenerClientes();

            // Implementación temporal
            var dt = new DataTable();
            dt.Columns.Add("CustomerID", typeof(string));
            dt.Columns.Add("CompanyName", typeof(string));
            return dt;
        }

        public int CrearCliente(Customer cliente)
        {
            if (_dataCliente != null)
                return _dataCliente.CrearCliente(cliente);

            return 1;
        }

        public int CrearCliente(Customer cliente, IDataCliente dataCliente)
        {
            return dataCliente.CrearCliente(cliente);
        }
    }
}