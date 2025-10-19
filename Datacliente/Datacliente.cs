using System;
using System.Linq;
using NorthwindModel;

namespace Datacliente
{
    public class DataCliente
    {
        public bool insertarCustomer(Customer customer)
        {
            try
            {
                using (var contexto = new NorthwindEntities1())
                {
                    contexto.Customers.Add(customer);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public bool actualizarCustomer(Customer customer)
        {
            try
            {
                using (var contexto = new NorthwindEntities1())
                {
                    var clienteExistente = contexto.Customers.Find(customer.CustomerID);
                    if (clienteExistente == null) return false;

                    contexto.Entry(clienteExistente).CurrentValues.SetValues(customer);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public bool eliminarCustomer(string customerID)
        {
            try
            {
                using (var contexto = new NorthwindEntities1())
                {
                    var clienteAEliminar = contexto.Customers.Find(customerID);
                    if (clienteAEliminar == null) return false;

                    contexto.Customers.Remove(clienteAEliminar);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public Customer cargarCustomer(string customerID)
        {
            try
            {
                using (var contexto = new NorthwindEntities1())
                {
                    var clienteEncontrado = contexto.Customers.Find(customerID);
                    return clienteEncontrado;
                }
            }
            catch (Exception) { return null; }
        }
    }
}