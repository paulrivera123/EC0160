using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datacliente;
using Moq;
using System;
using Negocio = Negociocliente;

[TestClass]
public class NegocioClienteTests
{
    // Usamos el alias en la declaración de la variable
    private Negocio.Negociocliente _negocioCliente;
    private Mock<DataCliente> _mockDataCliente;
    private Customer _clienteDePrueba;

    [TestInitialize]
    public void Setup()
    {
        // 1. Preparamos el simulador (Mock) de la Capa de Datos
        _mockDataCliente = new Mock<DataCliente>();

        // 2. Creamos el objeto Cliente (entidad POCO) que usaremos en las simulaciones
        _clienteDePrueba = new Customer
        {
            CustomerID = "TESTX",
            CompanyName = "Compañia Simulada",
            ContactName = "Tester"
        };

        // 3. Creamos una instancia de la clase de Negocio, inyectándole el simulador
        // NOTA: Usamos Negocio.Negociocliente para resolver la ambigüedad.
        _negocioCliente = new Negocio.Negociocliente(_mockDataCliente.Object);
    }

    // --- PRUEBA 1: Verificar la Inserción Exitosa ---

    [TestMethod]
    public void Insertar_DebeRetornarTrue_CuandoLaCapaDeDatosEsExitosa()
    {
        // ARRANGE: Configuramos el simulador para que siempre devuelva TRUE al insertar.
        _mockDataCliente.Setup(dc => dc.insertarCustomer(It.IsAny<Customer>()))
                        .Returns(true);

        // Mapeamos los datos de prueba a la Capa de Negocio
        _negocioCliente.CustomerID = _clienteDePrueba.CustomerID;
        _negocioCliente.CompanyName = _clienteDePrueba.CompanyName;

        // ACT: Llamamos al método de negocio
        bool resultado = _negocioCliente.insertar();

        // ASSERT: Verificamos que la Capa de Negocio retorne True
        Assert.IsTrue(resultado, "La inserción falló, aunque el simulador retornó True.");
    }

    // --- PRUEBA 2: Verificar la Carga Exitosa (Consultar) ---

    [TestMethod]
    public void Cargar_DebeRetornarTrue_YPopularPropiedades_CuandoElClienteExiste()
    {
        // ARRANGE: Configuramos el simulador para que devuelva nuestro objeto Cliente
        _mockDataCliente.Setup(dc => dc.cargarCustomer("TESTX"))
                        .Returns(_clienteDePrueba);

        _negocioCliente.CustomerID = "TESTX";

        // ACT: Llamamos al método de negocio
        bool resultado = _negocioCliente.cargar();

        // ASSERT: Verificamos que la carga fue exitosa y que los datos se copiaron al Negocio
        Assert.IsTrue(resultado, "La carga del cliente falló.");
        Assert.AreEqual("Compañia Simulada", _negocioCliente.CompanyName, "Las propiedades de la Capa de Negocio no se llenaron correctamente.");
    }
}