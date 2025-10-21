using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data;
using System.Collections.Generic;
using Datacliente;
using Negociocliente;

namespace Pruebasunitarias
{
    [TestClass]
    public class NegocioClienteTests
    {
        private Mock<IDataCliente> _mockDataCliente; 
        private Negociocliente _negocioCliente;  

        [TestInitialize]
        public void Setup()
        {
            _mockDataCliente = new Mock<IDataCliente>();
            _negocioCliente = NegocioCliente(_mockDataCliente.Object);
        }

        [TestMethod]
        public void ObtenerClientes_WhenDataExists_ReturnsClientList()
        {
            // Arrange
            var expectedDataTable = new DataTable();
            expectedDataTable.Columns.Add("CustomerID", typeof(string));
            expectedDataTable.Columns.Add("CompanyName", typeof(string));
            expectedDataTable.Columns.Add("ContactName", typeof(string));
            expectedDataTable.Columns.Add("ContactTitle", typeof(string));
            expectedDataTable.Columns.Add("Address", typeof(string));
            expectedDataTable.Columns.Add("City", typeof(string));
            expectedDataTable.Columns.Add("Country", typeof(string));
            expectedDataTable.Columns.Add("Phone", typeof(string));
            expectedDataTable.Columns.Add("Fax", typeof(string));

            expectedDataTable.Rows.Add("ALFKI", "Alfreds", "Maria", "Manager", "Address", "Berlin", "Germany", "123", "456");

            _mockDataCliente
                .Setup(x => x.ObtenerClientes())
                .Returns(expectedDataTable);

            // Act
            var result = _negocioCliente.ObtenerClientes();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Rows.Count);
            Assert.AreEqual("Alfreds", result.Rows[0]["CompanyName"]?.ToString());
        }

        [TestMethod]
        public void CrearCliente_ValidCliente_ReturnsSuccess()
        {
            // Arrange
            var cliente = new Customer 
            {
                CustomerID = "TEST1",
                CompanyName = "Test Company",
                ContactName = "Test Contact",
                ContactTitle = "Manager",
                Address = "Test Address",
                City = "Test City",
                Country = "Test Country",
                Phone = "123456789",
                Fax = "987654321"
            };

            // _mockDataCliente
            //    .Setup(x => x.CrearCliente(It.IsAny<Datacliente.Customer>()))  // CORREGIDA
            //    .Returns(1);

            // Act
            //var result = _negocioCliente.CrearCliente(cliente);

            // Assert
            //Assert.AreEqual(1, result);
        }
    }
}