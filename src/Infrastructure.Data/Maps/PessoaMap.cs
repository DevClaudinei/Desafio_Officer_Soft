using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Maps
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Cep)
                .HasColumnType("varchar(9)")
                .IsRequired();

            builder.Property(x => x.Endereco)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Numero)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Bairro)
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property(x => x.Complemento)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Uf)
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.Property(x => x.Rg)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(x => x.DataDeCriacao)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
