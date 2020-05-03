using System;
using System.Collections.Generic;
using AutoMapper;
using DomainValidation.Validation;
using DR.Escolaridade.Application.Interfaces;
using DR.Escolaridade.Application.ViewModels;
using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Domain.Models;
using DR.Escolaridade.Infra.Data.Repository;

namespace DR.Escolaridade.Application.Services
{
    public class ClienteAppService : AppServiceBase, IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteRepository clienteRepository, 
                                 IClienteService clienteService,
                                 IUnitOfWork uow) : base(uow)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCPF(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco= Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.DefinirComoAtivo();
            cliente.AdicionarEndereco(endereco);

            var clienteReturn = _clienteService.Adicionar(cliente);

            //BeginTransaction();
            ////BllaBLaBLa
            //try
            //{
            //    Commit();
            //}
            //catch (Exception)
            //{
            //    Rollback();
            //}

            if (clienteReturn.ValidationResult.IsValid)
            {
                if (!SaveChanges())
                {
                    AdicionarErroValidacao(clienteReturn.ValidationResult, "Ocorreu um erro ao salvar os dados no banco de dados");
                }
            }

            clienteEnderecoViewModel.Cliente.ValidationResult = clienteReturn.ValidationResult;

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            //TODO: Faltou atualizar o endereço
            var cliente = Mapper.Map<Cliente>(clienteViewModel);

            cliente.DefinirComoAtivo();

            if (!cliente.EhValido()) return clienteViewModel;

            _clienteService.Atualizar(cliente);
            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public void Dispose()
        {
            _clienteService.Dispose();
        }
    }
}