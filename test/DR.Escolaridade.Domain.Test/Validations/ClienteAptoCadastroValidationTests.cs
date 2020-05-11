using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Domain.Models;
using DR.Escolaridade.Domain.Validation.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Escolaridade.Domain.Test.Validations
{
    [TestClass]
    public class ClienteAptoCadastroValidationTests
    {
        [TestMethod]
        public void ClienteAptoCadastro_Validation_DeveRetornarTrue()
        {
            //Arrang
            var cliente = new Cliente()
            {
                Nome = "Marcela",
                CPF = "15633485602",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            //MOQ
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(null);
            repo.Stub(s => s.ObterPorEmail(cliente.CPF)).Return(null);

            var clienteValidation = new ClienteEstaAptoParaCadastroValidation(repo);

            //Act
            var result = clienteValidation.Validate(cliente);

            //Assert
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ClienteAptoCadastro_Validation_DeveRetornarFalse()
        {
            //Arrang
            var cliente = new Cliente()
            {
                Nome = "Marcela",
                CPF = "15633485602",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            //MOQ
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(cliente);
            repo.Stub(s => s.ObterPorCPF(cliente.CPF)).Return(cliente);

            var clienteValidation = new ClienteEstaAptoParaCadastroValidation(repo);

            //Act
            var result = clienteValidation.Validate(cliente);

            //Assert
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Erros.Any(x => x.Message == "Já existe um cliente com esse CPF."));
            Assert.IsTrue(result.Erros.Any(x => x.Message == "Já existe um cliente com esse E-mail."));
        }
    }
}