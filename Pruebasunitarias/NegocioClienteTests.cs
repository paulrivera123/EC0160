using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data;
using System.Collections.Generic;

namespace Pruebasunitarias
{
    [TestClass]
    public class NegocioClienteTests
    {
        private Mock<IDataCliente> _mockDataCliente;
        private NegocioCliente _negocioCliente;

        [TestInitialize]
        public void Setup()
        {
            _mockDataCliente = new Mock<IDataCliente>();
            _negocioCliente = new NegocioCliente(_mockDataCliente.Object);
        }

        [TestMethod]
        public void ObtenerClientes_WhenDataExists_ReturnsClientList()
        {
            // Arrange
            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add("Id", typeof(int));
            expectedDataTable.Columns.Add("Nombre", typeof(string));
            expectedDataTable.Columns.Add("Apellido", typeof(string));
            expectedDataTable.Columns.Add("Email", typeof(string));
            expectedDataTable.Columns.Add("Telefono", typeof(string));
            expectedDataTable.Columns.Add("Direccion", typeof(string));

            expectedDataTable.Rows.Add(1, "Juan", "Perez", "juan@email.com", "123456789", "Dirección 1");

            _mockDataCliente
                .Setup(x => x.ObtenerClientes())
                .Returns(expectedDataTable);

            // Act
            var result = _negocioCliente.ObtenerClientes();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Juan", result[0].Nombre);
        }

        [TestMethod]
        public void CrearCliente_ValidCliente_ReturnsSuccess()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nombre = "Test",
                Apellido = "User",
                Email = "test@email.com",
                Telefono = "123456789",
                Direccion = "Test Address"
            };

            _mockDataCliente
                .Setup(x => x.CrearCliente(It.IsAny<Cliente>()))
                .Returns(1);

            // Act
            var result = _negocioCliente.CrearCliente(cliente);

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}