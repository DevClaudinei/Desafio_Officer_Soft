using AppServices.Validations;
using FluentValidation.TestHelper;
using UnitTests.Fixtures;

namespace UnitTests.AppServices.Validations
{
    public class ValidadorAtualizaCadastroTests
    {
        private readonly ValidadorAtualizaCadastro _validadorAtualizaCadastro = new();

        [Fact]
        public void Deveria_Passar_Quando_Executar_ValidadorAtualizaCadastro()
        {
            // Arrange
            var atualizaCadastroFake = AtualizaCadastroFixture.AtualizaCadastroFake();

            // Act
            var result = _validadorAtualizaCadastro.TestValidate(atualizaCadastroFake);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Deveria_Falhar_Quando_ValidadorAtualizaCadastro_Porque_Cpf_Eh_Invalido()
        {
            // Arrange
            var atualizaCadastroFake = AtualizaCadastroFixture.AtualizaCadastroFake();
            atualizaCadastroFake.Cpf = "11111111111";

            // Act
            var result = _validadorAtualizaCadastro.TestValidate(atualizaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Cpf);
        }

        [Fact]
        public void Deveria_Falhar_Quando_Executar_ValidadorAtualizaCadastro_Porque_Nome_Esta_Em_Branco()
        {
            // Arrange
            var atualizaCadastroFake = AtualizaCadastroFixture.AtualizaCadastroFake();
            atualizaCadastroFake.Nome = "";

            // Act
            var result = _validadorAtualizaCadastro.TestValidate(atualizaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void Deveria_Falhar_Quando_Executar_ValidadorAtualizaCadastro_Porque_Nome_Nao_Tem_Um_Sobrenome()
        {
            // Arrange
            var atualizaCadastroFake = AtualizaCadastroFixture.AtualizaCadastroFake();
            atualizaCadastroFake.Nome = "José";

            // Act
            var result = _validadorAtualizaCadastro.TestValidate(atualizaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void Deveria_Falhar_Quando_Executar_ValidadorAtualizaCadastro_Porque_Nome_Contem_Caracteres_Invalidos()
        {
            // Arrange
            var atualizaCadastroFake = AtualizaCadastroFixture.AtualizaCadastroFake();
            atualizaCadastroFake.Nome = "Jo@o Conceição";

            // Act
            var result = _validadorAtualizaCadastro.TestValidate(atualizaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void Deveria_Falhar_Quando_Executar_ValidadorAtualizaCadastro_Porque_Nome_Contem_Espacos_Desnecessarios()
        {
            // Arrange
            var atualizaCadastroFake = AtualizaCadastroFixture.AtualizaCadastroFake();
            atualizaCadastroFake.Nome = "Solange  Braga";

            // Act
            var result = _validadorAtualizaCadastro.TestValidate(atualizaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void Deveria_Falhar_Quando_Executar_ValidadorAtualizaCadastro_Porque_Sobrenome_Tem_Formato_Invalido()
        {
            // Arrange
            var atualizaCadastroFake = AtualizaCadastroFixture.AtualizaCadastroFake();
            atualizaCadastroFake.Nome = "Maria A Santos";

            // Act
            var result = _validadorAtualizaCadastro.TestValidate(atualizaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [Fact]
        public void Deveria_Fahar_Quando_Executar_ValidadorAtualizaCadastro_Porque_Cep_Tem_Formato_Invalido()
        {
            // Arrange
            var atualizaCadastroFake = AtualizaCadastroFixture.AtualizaCadastroFake();
            atualizaCadastroFake.Cep = "48280000";

            // Act
            var result = _validadorAtualizaCadastro.TestValidate(atualizaCadastroFake);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Cep);
        }
    }
}
