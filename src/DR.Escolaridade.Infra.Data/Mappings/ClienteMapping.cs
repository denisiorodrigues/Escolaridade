using DR.Escolaridade.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DR.Escolaridade.Infra.Data.Mappings
{
    //FLuent API
    public class ClienteMapping : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapping()
        {
            HasKey(c => c.Id);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(p => p.CPF)
                .IsRequired()
                .HasMaxLength(11) // O tamanho é de onze
                .IsFixedLength()  // e é fixo
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_CPF") { IsUnique = true })); //(é mais performático)

            Property(p => p.DataCadastro)
                .IsRequired();

            Property(p => p.Ativo)
                .IsRequired();

            Property(p => p.Excluido)
                .IsRequired();

            ToTable("Clientes");
        }
    }
}
