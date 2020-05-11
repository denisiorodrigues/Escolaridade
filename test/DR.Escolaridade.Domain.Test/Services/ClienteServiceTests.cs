using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Domain.Models;
using DR.Escolaridade.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;

namespace DR.Escolaridade.Domain.Test.Services
{
    [TestClass]
    public class ClienteServiceTests
    {
        [TestMethod]
        public void ClienteService_AdicionarCliente_RetornarComSucesso()
        {
            //Arrang
            var cliente = new Cliente
            {
                Nome = "Marcela",
                CPF = "15633485602",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            var repo = MockRepository.GenerateMock<IClienteRepository>();
            repo.Stub(s => s.Adicionar(cliente));

            var clienteService = new ClienteService(repo);

            //Act
            var result = clienteService.Adicionar(cliente);

            //Assert
            Assert.IsTrue(result.ValidationResult.IsValid);
        }
    }
}