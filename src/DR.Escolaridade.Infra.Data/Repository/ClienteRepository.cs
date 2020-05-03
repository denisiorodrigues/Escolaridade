using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using DR.Escolaridade.Domain.Interfaces;
using DR.Escolaridade.Domain.Models;
using DR.Escolaridade.Infra.Data.Contex;

namespace DR.Escolaridade.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(EscolaridadeContext context) : base(context){}

        public IEnumerable<Cliente> ObterAtivos()
        {
            //return Buscar(c => c.Ativo);
            //Transferir a consulta para outro arquivo como:
            //Resource ou xml (qualquer arquivo para náo ficar hardcode)
            const string sql = @"SELECT * FROM Clientes c "+
                                "WHERE c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente>(sql);
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
            const string sql = @"SELECT * FROM Clientes c " +
                                "LEFT JOIN Enderecos e ON c.Id = e.ClienteId" +
                                " WHERE c.Id = @uid AND c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) => {
                    c.AdicionarEndereco(e);
                    return c;
                }, new { uid = id}).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.DefinirComoExcluido();
            Atualizar(cliente);
        }
    }
}