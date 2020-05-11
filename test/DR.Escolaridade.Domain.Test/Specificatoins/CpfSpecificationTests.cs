using DR.Escolaridade.Domain.Models;
using DR.Escolaridade.Domain.Specification.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DR.Escolaridade.Domain.Test.Specificatoins
{
    [TestClass]
    public class CpfSpecificationTests
    {
        [TestMethod]
        public void CpfSpecification_Valido_True()
        {
            //Arrang
            var cliente = new Cliente()
            {
                Nome = "Marcela",
                CPF = "15633485602",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            var cpfSpec = new ClienteDeveTerCpfValidoSpecification();

            //Act
            var result = cpfSpec.IsSatisfiedBy(cliente);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CpfSpecification_Valido_False()
        {
            //Arrang
            var cliente = new Cliente()
            {
                Nome = "Marcela",
                CPF = "15633485601",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            var cpfSpec = new ClienteDeveTerCpfValidoSpecification();

            //Act
            var result = cpfSpec.IsSatisfiedBy(cliente);

            //Assert
            Assert.IsFalse(result);
        }
    }
}