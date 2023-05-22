using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Data.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.DataNascimento)
                .IsRequired();

            builder.Property(c => c.Rg)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(c => c.Salario)
                .IsRequired()
                .HasPrecision(18,2);

            builder.Property(c => c.CargoId)
                .IsRequired();

            builder.HasOne(c => c.Cargo)
                .WithMany(p => p.Funcionarios)
                .HasForeignKey(p => p.CargoId);
        }
    }
}
