using DR.Escolaridade.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DR.Escolaridade.Domain.Test.Models
{
    [TestClass]
    public class ClienteTests
    {
        //AAA => Arrang, Act, Assert
        //Arranjo (Classe), ação(método) e assertação(O que eu quero testar)

        [TestMethod]
        public void Cliente_EstaConsistente_DeveRetornarTrue()
        {
            //Arrang
            var cliente = new Cliente()
            {
                Nome = "Marcela",
                CPF = "15633485602",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            //Act
            var result = cliente.EhValido();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Cliente_EstaConsistente_DeveRetornarFalse()
        {
            //Arrang
            var cliente = new Cliente()
            {
                Nome = "M",
                CPF = "12345678900",
                Email = "testeteste.com",
                DataNascimento = DateTime.Now
            };

            //Act
            var result = cliente.EhValido();

            //Assert
            Assert.IsFalse(result);
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(x => x.Message == "Cliente informou um e-amil inválido."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(x => x.Message == "Cliente não tem maioridade para cadastro."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(x => x.Message == "Nome do cliente precisa ter mais de 2 caracteres."));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(x => x.Message == "Cliente informou um CPF inválido."));
        }
    }
}
