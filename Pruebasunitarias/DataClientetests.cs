using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datacliente;
using System;
using System.Linq;

[TestClass]
public class DataClienteTests
{
    private DataCliente _dataCliente;

    [TestInitialize]
    public void Setup()
    {
        _dataCliente = new DataCliente();
    }

    // --- PRUEBA 1: Verificar la Inserción de un Cliente Válido ---

    [TestMethod]
    public void InsertarCustomer_DebeInsertarClienteValido_YRetornarTrue()
    {
        // ARRANGE (Preparación): Usamos una ID con fecha/hora para garantizar unicidad
        // Tomamos solo los primeros 5 caracteres para respetar el nchar(5)
        string testId = "TEST" + DateTime.Now.Ticks.ToString().Substring(0, 1);

        var clienteValido = new Customer
        {
            CustomerID = testId,
            CompanyName = "Compañia Prueba FINAL", // Campo NOT NULL
            ContactName = "Tester", // Campo llenado para mayor seguridad
        };

        // ACT (Acción): Llamar al método a probar
        bool resultado = _dataCliente.insertarCustomer(clienteValido);

        // ASSERT (Verificación): Confirmar que la inserción fue exitosa
        Assert.IsTrue(resultado, "La Capa de Datos falló al insertar el cliente. El problema es una restricción DB.");

        // LIMPIEZA: Eliminar el registro para que la prueba pueda repetirse
        _dataCliente.eliminarCustomer(testId);
    }

    // --- PRUEBA 2: Verificar la Eliminación (CRUD - Delete) ---

    [TestMethod]
    public void EliminarCustomer_DebeEliminarRegistro_YRetornarTrue()
    {
        // ARRANGE (Preparación): Creamos un registro temporal con una ID específica
        string testId = "TESTZ";

        // Primero, aseguramos que el registro no exista para evitar duplicidad
        _dataCliente.eliminarCustomer(testId);

        // Insertamos el registro que vamos a borrar
        _dataCliente.insertarCustomer(new Customer { CustomerID = testId, CompanyName = "Temporal para Borrar" });

        // ACT (Acción): Llamar al método a probar (eliminar)
        bool resultado = _dataCliente.eliminarCustomer(testId);

        // Verificación Adicional: Intentar cargar el cliente para asegurar que ya no existe
        Customer clienteEliminado = _dataCliente.cargarCustomer(testId);

        // ASSERT (Verificación): Confirmar que la eliminación fue exitosa
        Assert.IsTrue(resultado, "La eliminación falló, el registro no pudo ser borrado.");
        Assert.IsNull(clienteEliminado, "El registro todavía existe en la base de datos.");
    }
}