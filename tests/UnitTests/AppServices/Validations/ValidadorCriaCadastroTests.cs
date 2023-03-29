using AppServices.Validations;
using FluentValidation.TestHelper;
using UnitTests.Fixtures;

namespace UnitTests.AppServices.Validations
{
    public class ValidadorCriaCadastroTests
    {
        private readonly ValidadorCriaCadastro _validadorCriaCadastro = new();

        [Fact]
        public void Deveria_Passar_Quando_Executar_ValidadorCriaCadastro()
        {
            // Arrange
            var criaCadastroFake = CriaCadastroFixture.CriaCadastroFake();

            // Act
            var result = _validadorCriaCadastro.TestValidate(criaCadastroFake);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Deveria_Falhar_Quando_ValidaCriaCadastro_Porque_Cpf_Eh_Invalido()
        {
            // Arrange
            var criaCadastroFake = CriaCadastroFixture.CriaCadastroFake();
            criaCadastroFake.Cpf = "11111111111";

            // Act
            var result = _validadorCriaCadastro.TestValidate(criaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Cpf);
        }

        [Fact]
        public void Deveria_Falhar_Quando_Executar_ValidaCriaCadastro_Porque_Nome_Esta_Em_Branco()
        {
            // Arrange
            var criaCadastroFake = CriaCadastroFixture.CriaCadastroFake();
            criaCadastroFake.Nome = "";

            // Act
            var result = _validadorCriaCadastro.TestValidate(criaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void Deveria_Falhar_Quando_Executar_ValidaCriaCadastro_Porque_Nome_Nao_Tem_Um_Sobrenome()
        {
            // Arrange
            var criaCadastroFake = CriaCadastroFixture.CriaCadastroFake();
            criaCadastroFake.Nome = "José";

            // Act
            var result = _validadorCriaCadastro.TestValidate(criaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void Deveria_Falhar_Quando_Executar_ValidaCriaCadastro_Porque_Nome_Contem_Caracteres_Invalidos()
        {
            // Arrange
            var criaCadastroFake = CriaCadastroFixture.CriaCadastroFake();
            criaCadastroFake.Nome = "Jo@o Conceição";

            // Act
            var result = _validadorCriaCadastro.TestValidate(criaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void Deveria_Falhar_Quando_Executar_ValidaCriaCadastro_Porque_Nome_Contem_Espacos_Desnecessarios()
        {
            // Arrange
            var criaCadastroFake = CriaCadastroFixture.CriaCadastroFake();
            criaCadastroFake.Nome = "Solange  Braga";

            // Act
            var result = _validadorCriaCadastro.TestValidate(criaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void Deveria_Falhar_Quando_Executar_ValidaCriaCadastro_Porque_Sobrenome_Tem_Formato_Invalido()
        {
            // Arrange
            var criaCadastroFake = CriaCadastroFixture.CriaCadastroFake();
            criaCadastroFake.Nome = "Maria A Santos";

            // Act
            var result = _validadorCriaCadastro.TestValidate(criaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void Deveria_Fahar_Quando_Executar_ValidaCriaCadastro_Porque_Cep_Tem_Formato_Invalido()
        {
            // Arrange
            var criaCadastroFake = CriaCadastroFixture.CriaCadastroFake();
            criaCadastroFake.Cep = "48280000";

            // Act
            var result = _validadorCriaCadastro.TestValidate(criaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Cep);
        }
    }
}
