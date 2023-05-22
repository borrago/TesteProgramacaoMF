using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteProgramacaoMF.Profissionais.Domain;

namespace TesteProgramacaoMF.Profissionais.Data.Mappings
{
    public class FuncionariObraoMapping : IEntityTypeConfiguration<FuncionarioObra>
    {
        public void Configure(EntityTypeBuilder<FuncionarioObra> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Obra)
                .WithMany(p => p.FuncionarioObras)
                .HasForeignKey(p => p.ObraId);

            builder.HasOne(c => c.Funcionario)
                .WithMany(p => p.FuncionarioObras)
                .HasForeignKey(p => p.FuncionarioId);

            builder.Property(c => c.DtInicio)
                .IsRequired();

            builder.Property(c => c.DtFim)
                .IsRequired();
        }
    }
}
