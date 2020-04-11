using DR.Escolaridade.Domain.Models;
using System.Collections.Generic;

namespace DR.Escolaridade.Domain.Interfaces
{
    public interface IClienteRepository: IRepositoryRead<Cliente>, IRepositoryWrite<Cliente>
    {
        Cliente ObterPorCPF(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterAtivos();
    }
}