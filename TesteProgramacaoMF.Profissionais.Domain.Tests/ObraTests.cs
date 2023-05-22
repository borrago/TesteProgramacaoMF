using TesteProgramacaoMF.Core.DomainObjects;

namespace TesteProgramacaoMF.Profissionais.Domain.Tests
{
    public class ObraTests
    {
        [Fact]
        public void Obra_Validar_ValidacoesDevemRetornarExceptions()
        {
            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() => new Obra(null));
            Assert.Equal("O campo Nome não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Obra("dgfhdfghdfghdfghdfghdfghdfgdgfhdfghdfghdfghdfghdfghdfgdgfhdfghdfghdfghdfghdfghdfgdgfhdfghdfghdfghdfgh"));
            Assert.Equal("O campo Nome não pode ser maior que 100 caracteres", ex.Message);
        }
    }
}