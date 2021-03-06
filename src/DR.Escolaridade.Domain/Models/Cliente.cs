﻿using DR.Escolaridade.Domain.Validation.Clientes;
using System;
using System.Collections.Generic;

namespace DR.Escolaridade.Domain.Models
{
    public class Cliente : Entity
    {
        public Cliente()
        {
            Enderecos = new List<Endereco>();
        }

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

        public void AdicionarEndereco(Endereco endereco)
        {
            if (!endereco.EhValido())
            {
                AdicionarErrosValidacao(endereco.ValidationResult);
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
            Ativo = true;
            Excluido = false;
        }

        public override bool EhValido()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}