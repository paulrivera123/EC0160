using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datacliente;
using System;

// [TestClass] - Indica que esta clase contiene métodos de prueba
[TestClass]
public class DataClienteTests
{
    private DataCliente _dataCliente;

    // [TestInitialize] - Se ejecuta antes de cada método de prueba
    [TestInitialize]
    public void Setup()
    {
        // Inicializamos la clase de acceso a datos para cada prueba
        _dataCliente = new DataCliente();
    }

    // --- PRUEBA 1: Verificar la Inserción de un Cliente Válido (CRUD - Create) ---

    // [TestMethod] - Indica que este es un método de prueba ejecutable
    [TestMethod]
    public void InsertarCustomer_DebeInsertarClienteValido_YRetornarTrue()
    {
        // ARRANGE (Preparación): Crear una entidad válida
        string testId = "TEST1"; // Usa un ID que sabes que no existe

        var clienteValido = new Customer
        {
            CustomerID = testId,
            CompanyName = "Compañia Test",
            ContactName = "Tester",
            // Los demás campos son opcionales
        };

        // ACT (Acción): Llamar al método a probar
        bool resultado = _dataCliente.insertarCustomer(clienteValido);

        // ASSERT (Verificación): Confirmar que la inserción fue exitosa
        Assert.IsTrue(resultado, "La inserción del cliente válido falló inesperadamente.");

        // LIMPIEZA: Eliminar el registro para que la prueba pueda repetirse
        _dataCliente.eliminarCustomer(testId);
    }
}