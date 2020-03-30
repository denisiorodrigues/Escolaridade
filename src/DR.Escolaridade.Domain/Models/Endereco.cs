﻿using System;

namespace DR.Escolaridade.Domain.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public Guid ClienteId { get; set; }

        // Propriedade de Navegação do EF
        public virtual Cliente Cliente { get; set; }

        public override bool EhValido()
        {
            if (string.IsNullOrWhiteSpace(Logradouro))
                AdicionarErroValidacao("Logradouro", "O logradouro não pode estar vazio!");

            if (string.IsNullOrWhiteSpace(CEP))
                AdicionarErroValidacao("CEP", "O CEP não pode estar vazio!");

            return ValidationResult.Count == 0;
        }
    }
}