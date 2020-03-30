using System;
using System.Collections.Generic;
using System.Linq;
using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Domain.Models;

namespace DR.Escolaridade.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public IEnumerable<Cliente> ObterAtivo()
        {
            return Buscar(c => c.Ativo);
        }

        public Cliente ObterPorCPF(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override Cliente ObterPorId(Guid id)
        {
            return Db.Clientes
                .AsNoTracking()
                .Include("Enderecos")
                .FirstOrDefault(c => c.Id == id);
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.DefinirComoExcluido();
            Atualizar(cliente);
        }
    }
}