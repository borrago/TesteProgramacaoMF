using TesteProgramacaoMF.Core.DomainObjects;

namespace TesteProgramacaoMF.Profissionais.Domain.Tests
{
    public class FuncionarioTests
    {
        [Fact]
        public void Funcionario_Validar_ValidacoesDevemRetornarExceptions()
        {
            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() => new Funcionario(null, DateTime.Now.Date, "123456789", 10000, Guid.NewGuid()));
            Assert.Equal("O campo Nome não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Funcionario("dgfhdfghdfghdfghdfghdfghdfgdgfhdfghdfghdfghdfghdfghdfgdgfhdfghdfghdfghdfghdfghdfgdgfhdfghdfghdfghdfgh", DateTime.Now.Date, "123456789", 10000, Guid.NewGuid()));
            Assert.Equal("O campo Nome não pode ser maior que 100 caracteres", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Funcionario("Teste", DateTime.Now.Date, null, 10000, Guid.NewGuid()));
            Assert.Equal("O campo Nome não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Funcionario("Teste", DateTime.Now.Date, "12345678900", 10000, Guid.NewGuid()));
            Assert.Equal("O campo Nome não pode ser maior que 9 caracteres", ex.Message);

        }
    }
}