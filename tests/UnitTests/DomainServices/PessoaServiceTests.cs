using Castle.Core.Resource;
using DomainModels.Entities;
using DomainServices.Exceptions;
using DomainServices.Services;
using EntityFrameworkCore.QueryBuilder.Interfaces;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using FluentAssertions;
using Infrastructure.Data.Context;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnitTests.Fixtures;

namespace UnitTests.DomainServices
{
    public class PessoaServiceTests
    {
        private readonly PessoaService _pessoaService;
        private readonly Mock<IUnitOfWork<DataContext>> _mockUnitOfWork;
        private readonly Mock<IRepositoryFactory<DataContext>> _mockRepositoryFactory;

        public PessoaServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork<DataContext>>();
            _mockRepositoryFactory = new Mock<IRepositoryFactory<DataContext>>();
            _pessoaService = new PessoaService(_mockUnitOfWork.Object, _mockRepositoryFactory.Object);
        }

        [Fact]
        public async Task Deveria_Passar_Quando_Tentar_Executar_CadastraPessoa()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockUnitOfWork.Setup(x => x.Repository<Pessoa>().Add(pessoaFake))
                .Returns(pessoaFake);

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .Any(It.IsAny<Expression<Func<Pessoa, bool>>>()));

            // Act
            var result = await _pessoaService.CadastraPessoa(pessoaFake);

            // Assert
            result.Should().Be(pessoaFake.Id);

            _mockUnitOfWork.Verify(x => x.Repository<Pessoa>().Add(pessoaFake), Times.Once());

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .Any(It.IsAny<Expression<Func<Pessoa, bool>>>()), Times.Once());
        }

        [Fact]
        public async Task Deveria_Falhar_Quando_Tentar_Executar_CadastraPessoa()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockUnitOfWork.Setup(x => x.Repository<Pessoa>().Add(pessoaFake))
                .Returns(pessoaFake);

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .Any(It.IsAny<Expression<Func<Pessoa, bool>>>()))
                .Returns(true);

            // Act
            var result = async () => await _pessoaService.CadastraPessoa(pessoaFake);

            // Assert
            await result.Should().ThrowAsync<BadRequestException>()
                .WithMessage($"Pessoa com o Cpf: {pessoaFake.Cpf} já esta cadastrada.");

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .Any(It.IsAny<Expression<Func<Pessoa, bool>>>()), Times.Once());
        }

        [Fact]
        public void Deveria_Retornar_Todos_Os_Cadastrados_Com_Sucesso()
        {
            // Arrange
            var pessoasFake = PessoaFixture.PessoasFakes(1);

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .MultipleResultQuery())
                .Returns(It.IsAny<IMultipleResultQuery<Pessoa>>());

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .Search(It.IsAny<IMultipleResultQuery<Pessoa>>()))
                .Returns((IList<Pessoa>)pessoasFake);

            // Act
            var result = _pessoaService.MostraTodosCadastrados();

            // Assert
            result.Should().HaveCount(1);

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .MultipleResultQuery(), Times.Once());

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .Search(It.IsAny<IMultipleResultQuery<Pessoa>>()), Times.Once());
        }

        [Fact]
        public async Task Deveria_Passar_Quando_Executar_BuscaPessoaPeloCpf()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()))
                .Returns(It.IsAny<IQuery<Pessoa>>());

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default))
                .ReturnsAsync(pessoaFake);

            // Act
            var result = await _pessoaService.BuscaPessoaPeloCpf(pessoaFake.Cpf);

            // Assert
            result.Cpf.Should().Be(pessoaFake.Cpf);

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()), Times.Once());

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default), Times.Once());
        }

        [Fact]
        public async Task Deveria_Falhar_Quando_Executar_BuscaPessoaPeloCpf()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()));

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default));

            // Act
            var result = await _pessoaService.BuscaPessoaPeloCpf(pessoaFake.Cpf);

            // Assert
            result.Should().BeNull();

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()), Times.Once());

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default), Times.Once());
        }

        [Fact]
        public async Task Deveria_Passar_Quando_Tentar_Executar_BuscaPessoaPeloId()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()))
                .Returns(It.IsAny<IQuery<Pessoa>>());

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default))
                .ReturnsAsync(pessoaFake);

            // Act
            var result = await _pessoaService.BuscaPessoaPorId(pessoaFake.Id);

            // Assert
            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()), Times.Once());

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default), Times.Once());
        }

        [Fact]
        public async Task Deveria_Falhar_Quando_Tentar_Executar_BuscaPessoaPeloId()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()));

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default));

            // Act
            var result =  await _pessoaService.BuscaPessoaPorId(pessoaFake.Id);

            // Assert
            result.Should().BeNull();

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()), Times.Once());

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default), Times.Once());
        }

        [Fact]
        public async Task Deveria_Passar_Quando_Tentar_Executar_BuscaPessoaPeloNome()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockRepositoryFactory.Setup(X => X.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()))
                .Returns(It.IsAny<IQuery<Pessoa>>());

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default))
                .ReturnsAsync(pessoaFake);

            // Act
            var result = await _pessoaService.BuscaPessoaPeloNome(pessoaFake.Nome);

            // Assert
            result.Nome.Should().Be(pessoaFake.Nome);

            _mockRepositoryFactory.Verify(X => X.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()), Times.Once());

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default), Times.Once());
        }

        [Fact]
        public async Task Deveria_Falhar_Quando_Tentar_Executar_BuscaPessoaPeloNome()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockRepositoryFactory.Setup(X => X.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()));

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default));

            // Act
            var result = await _pessoaService.BuscaPessoaPeloNome(pessoaFake.Nome);

            // Assert
            result.Should().BeNull();

            _mockRepositoryFactory.Verify(X => X.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()), Times.Once());

            _mockRepositoryFactory.Verify(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default), Times.Once());
        }

        [Fact]
        public void Deveria_Executar_AtualizaCadastro_Com_Sucesso()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockUnitOfWork.Setup(x => x.Repository<Pessoa>()
                .Update(It.IsAny<Pessoa>()));

            // Act
            _pessoaService.AtualizCadastro(pessoaFake.Id, pessoaFake);

            // Assert
            _mockUnitOfWork.Verify(x => x.Repository<Pessoa>()
                .Update(It.IsAny<Pessoa>()), Times.Once());

            _mockUnitOfWork.Verify(x => x.SaveChanges(true, false), Times.Once());
        }

        [Fact]
        public void Deveria_Passar_Quando_Tentar_Executar_ExcluiPessoa()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockUnitOfWork.Setup(x => x.Repository<Pessoa>()
                .Remove(It.IsAny<Pessoa>()));

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()))
                .Returns(It.IsAny<IQuery<Pessoa>>());

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleOrDefaultAsync(It.IsAny<IQuery<Pessoa>>(), default))
                .ReturnsAsync(pessoaFake);

            // Act
            _pessoaService.ExcluiPessoa(pessoaFake.Id);

            // Assert
            _mockUnitOfWork.Verify(x => x.Repository<Pessoa>()
                .Remove(It.IsAny<Pessoa>()), Times.Once());

            _mockUnitOfWork.Verify(x => x.SaveChanges(true, false), Times.Once());
        }

        [Fact]
        public void Deveria_Falhar_Quando_Tentar_Executar_ExcluiPessoa()
        {
            // Arrange
            var pessoaFake = PessoaFixture.PessoaFake();

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>().SingleResultQuery()
                .AndFilter(It.IsAny<Expression<Func<Pessoa, bool>>>()))
                .Returns(It.IsAny<IQuery<Pessoa>>());

            _mockRepositoryFactory.Setup(x => x.Repository<Pessoa>()
                .SingleOrDefault(It.IsAny<IQuery<Pessoa>>()));

            // Act
            Action act = () => _pessoaService.ExcluiPessoa(pessoaFake.Id);

            // Assert
            act.Should().ThrowExactly<NotFoundException>($"Pessoa com o Id: {pessoaFake.Id} não localizada.");
        }
    }
}
