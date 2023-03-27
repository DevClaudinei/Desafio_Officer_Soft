using AppServices.Profiles;
using AppServices.Services;
using AutoMapper;
using DomainModels.Entities;
using DomainServices.Exceptions;
using DomainServices.Services.Interfaces;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using UnitTests.Fixtures;

namespace UnitTests.Aplicacao
{
    public class PessoaAppServiceTests
    {
        private readonly IMapper _mapper;
        private readonly PessoaAppService _pessoaAppService;
        private readonly Mock<IPessoaService> _pessoaService;

        public PessoaAppServiceTests()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new PessoaProfile());
            });

            _mapper = config.CreateMapper();
            _pessoaService = new();
            _pessoaAppService = new(_pessoaService.Object, _mapper);
        }

        [Fact]
        public async Task Deveria_Cadastrar_Uma_Pessoa_Com_Sucesso()
        {
            // Arrange
            var criaCadastro = CriaCadastroFixture.CriaCadastroFake();
            var id = 12L;

            _pessoaService.Setup(x => x.CadastraPessoa(It.IsAny<Pessoa>()))
                .ReturnsAsync(id);

            // Act
            var result = await _pessoaAppService.CadastraPessoa(criaCadastro);

            // Assert
            result.Should().Be(id);

            _pessoaService.Verify(x => x.CadastraPessoa(It.IsAny<Pessoa>()), Times.Once());
        }

        [Fact]
        public void Deveria_Mostrar_Todos_Os_Cadastrados_Com_Sucesso()
        {
            // Arrange
            var pessoasFakes = PessoaFixture.PessoasFakes(1);

            _pessoaService.Setup(x => x.MostraTodosCadastrados())
                .Returns(pessoasFakes);

            // Act
            var result = _pessoaAppService.MostraTodosCadastrados();

            // Assert
            result.Should().HaveCount(1);

            _pessoaService.Verify(x => x.MostraTodosCadastrados(), Times.Once());
        }

        [Fact]
        public async Task Deveria_Passar_Quando_Tentar_Buscar_Pessoa_Por_Cpf()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _pessoaService.Setup(x => x.BuscaPessoaPeloCpf(It.IsAny<string>()))
                .ReturnsAsync(pessoaFake);

            // Act
            var result = await _pessoaAppService.BuscaPessoaPeloCpf(pessoaFake.Cpf);

            // Assert
            result.Cpf.Should().Be(pessoaFake.Cpf);

            _pessoaService.Verify(x => x.BuscaPessoaPeloCpf(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task Deveria_Falhar_Quando_Tentar_Buscar_Pessoa_Por_Cpf()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _pessoaService.Setup(x => x.BuscaPessoaPeloCpf(It.IsAny<string>()));

            // Act
            var result = async () => await _pessoaAppService.BuscaPessoaPeloCpf(pessoaFake.Cpf);

            // Assert
            await result.Should().ThrowAsync<NotFoundException>()
                .WithMessage($"Pessoa com o Cpf: {pessoaFake.Cpf} não localizada.");

            _pessoaService.Verify(x => x.BuscaPessoaPeloCpf(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task Deveria_Passar_Quando_Tentar_Buscar_Pessoa_Por_Id()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _pessoaService.Setup(x => x.BuscaPessoaPorId(It.IsAny<long>()))
                .ReturnsAsync(pessoaFake);

            // Act
            var result = await _pessoaAppService.BuscaPessoaPorId(pessoaFake.Id);

            // Assert
            result.Id.Should().Be(pessoaFake.Id);

            _pessoaService.Verify(x => x.BuscaPessoaPorId(It.IsAny<long>()), Times.Once());
        }

        [Fact]
        public async Task Deveria_Falhar_Quando_Tentar_Buscar_Pessoa_Por_Id()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _pessoaService.Setup(x => x.BuscaPessoaPorId(It.IsAny<long>()));

            // Act
            var result = async () => await _pessoaAppService.BuscaPessoaPorId(pessoaFake.Id);

            // Assert
            await result.Should().ThrowAsync<NotFoundException>()
                .WithMessage($"Pessoa com o Id: {pessoaFake.Id} não localizada.");

            _pessoaService.Verify(x => x.BuscaPessoaPorId(It.IsAny<long>()), Times.Once());
        }

        [Fact]
        public async Task Deveria_Passar_Quando_Tentar_Buscar_Pessoa_Por_Nome()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _pessoaService.Setup(x => x.BuscaPessoaPeloNome(It.IsAny<string>()))
                .ReturnsAsync(pessoaFake);

            // Act
            var result = await _pessoaAppService.BuscaPessoaPeloNome(pessoaFake.Nome);

            // Assert
            result.Nome.Should().Be(pessoaFake.Nome);

            _pessoaService.Verify(x => x.BuscaPessoaPeloNome(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task Deveria_Falhar_Quando_Tentar_Buscar_Pessoa_Por_Nome()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _pessoaService.Setup(x => x.BuscaPessoaPeloNome(It.IsAny<string>()));

            // Act
            var result = async () => await _pessoaAppService.BuscaPessoaPeloNome(pessoaFake.Nome);

            // Assert
            await result.Should().ThrowAsync<NotFoundException>()
                .WithMessage($"Pessoa com o nome: {pessoaFake.Nome} não localizada.");

            _pessoaService.Verify(x => x.BuscaPessoaPeloNome(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task Deveria_Retornar_Pessoa_Quando_Tentar_Mostrar_Pessoa_Por_Id()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _pessoaService.Setup(x => x.BuscaPessoaPorId(It.IsAny<long>()))
                .ReturnsAsync(pessoaFake);

            // Act
            var result = await _pessoaAppService.MostraPessoaPorId(pessoaFake.Id);

            // Asser
            result.Id.Should().Be(pessoaFake.Id);

            _pessoaService.Verify(x => x.BuscaPessoaPorId(It.IsAny<long>()), Times.Once());
        }

        [Fact]
        public void Deveria_Atualizar_Cadastro_Com_Sucesso()
        {
            // Arrange
            var atualizaCadastroFake = AtualizaCadastroFixture.AtualizaCadastroFake();
             
            _pessoaService.Setup(x => x.AtualizCadastro(It.IsAny<long>(), It.IsAny<Pessoa>()));

            // Act
            _pessoaAppService.AtualizCadastro(atualizaCadastroFake.Id, atualizaCadastroFake);

            // Assert
            _pessoaService.Verify(x => x.AtualizCadastro(It.IsAny<long>(), It.IsAny<Pessoa>()), Times.Once());

        }

        [Fact]
        public void Deveria_Excluir_Cadastro_Com_Sucesso()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _pessoaService.Setup(x => x.ExcluiPessoa(It.IsAny<long>()));

            // Act
            _pessoaAppService.ExcluiPessoa(pessoaFake.Id);

            // Assert
            _pessoaService.Verify(x => x.ExcluiPessoa(It.IsAny<long>()), Times.Once());
        }
    }
}
