using System;
using System.Collections.Generic;

namespace DR.Escolaridade.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            ValidationResult = new Dictionary<string, string>();
        }

        public Guid Id { get; set; }

        public IDictionary<string, string> ValidationResult { get; set; }

        public void AdicionarErroValidacao(string erro, string mensagem)
        {
            ValidationResult.Add(erro, mensagem);
        }

        public DateTime DataCadastro { get; set; }

        //Obriga quem herdar, implementar esse método
        public abstract bool EhValido();
    }
}
