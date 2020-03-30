using System;
using System.Collections.Generic;

namespace DR.Escolaridade.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public bool Ativo { get; set; }
        //Exclusão lógica
        public bool Excluido { get; set; }
        //Vai virar uma classe de proxy para o RF
        public virtual ICollection<Endereco> Enderecos { get; set; }

        //Está na entidade
        //public DateTime DataCadastro { get; set; }

        public void AdicioanrEndereco(Endereco endereco)
        {
            if (!endereco.EhValido())
            {
                this.ValidationResult = endereco.ValidationResult;
                //Retorno só para parar a aplicação
                return;
            }

            Enderecos.Add(endereco);
        }

        public void DefinirComoExcluido()
        {
            Ativo = false;
            Excluido = true;
        }

        public void DefinirComoAtivo()
        {
            Ativo = false;
            Excluido = true;
        }

        public override bool EhValido()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                AdicionarErroValidacao("Nome", "O Nome não pode está vazio");
            }

            if (string.IsNullOrEmpty(Email))
            {
                AdicionarErroValidacao("Email", "O E-mail não pode está vazio");
            }

            return ValidationResult.Count == 0;
        }
    }
}