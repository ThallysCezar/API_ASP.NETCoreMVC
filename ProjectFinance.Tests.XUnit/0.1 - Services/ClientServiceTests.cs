using Moq;
using Bogus;
using ProjectFinance.Infrastructure.Repositories;
using ProjectFinance.Services.Services;
using Client = ProjectFinance.Domain.Entities.Client;
using Bogus.DataSets;

namespace ProjectFinance.Tests.XUnit._0._1___Services
{
    public class ClientServiceTests
    {
        #region Props/ID

        private readonly Mock<IRepositoryClient> _clientRepositoryMock;
        private readonly ClientService _clientService;

        #endregion

        #region Constructor
        public ClientServiceTests()
        {
            _clientRepositoryMock = new Mock<IRepositoryClient>();
            _clientService = new ClientService(_clientRepositoryMock.Object);
        }

        #endregion

        #region Get

        [Fact(DisplayName = "Valid List Customer")]
        [Trait("Categoria", "Client Trait Tests")]
        public void Get_ReturningAListOfCustomers()
        {
            Faker faker = new Faker();
            var genero = new Faker().PickRandom<Name.Gender>();


            //Arrange
            var expectedClientsForList = new List<Client>
            {
                new Client { ClientId = faker.Random.Int(), Name = faker.Name.FirstName(genero) },
                new Client { ClientId = 2, Name = "Jane" }
            };

            _clientRepositoryMock.Setup(repo => repo.Read()).Returns(expectedClientsForList);
            var _clientService = new ClientService(_clientRepositoryMock.Object);

            // Act
            var result = _clientService.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        #endregion

        #region Search

        [Fact(DisplayName = "Valid Search")]
        [Trait("Categoria", "Client Trait Tests")]
        public void Search_ReturnById()
        {
            Faker faker = new Faker();

            //Arrange
            int clientId = 2;
            var expectedClient = new Client { ClientId = clientId, Name = "Jane" };

            _clientRepositoryMock.Setup(repo => repo.Search(clientId)).Returns(expectedClient);

            var clientService = new ClientService(_clientRepositoryMock.Object);

            // Act
            var result = clientService.Search(clientId);

            // Assert
            Assert.Equal(expectedClient, result);
        }

        #endregion

        #region Update

        [Fact(DisplayName = "Valid Update")]
        [Trait("Categoria", "Client Trait Tests")]
        public void Update_ValidClient_CallsClientRepositoryUpdate()
        {

            // Arrange
            var client = new Client();

            // Act
            _clientService.Update(client);

            // Assert
            _clientRepositoryMock.Verify(repo => repo.Update(client), Times.Once);
        }

        #endregion

        #region Save

        [Fact(DisplayName = "Valid Save")]
        [Trait("Categoria", "Client Trait Tests")]
        public void Save_ValidClient_CallsClientsRepositorySave()
        {
            //Arrange
            var client = new Client();

            //Act
            _clientService.Save(client);

            //Asserts
            _clientRepositoryMock.Verify(repo => repo.Save(client), Times.Once);
        }

        #endregion

        #region Delete

        [Fact(DisplayName = "Valid Delete")]
        [Trait("Categoria", "Client Trait Tests")]
        public void Delete_NonZeroId_CallsClientRepositoryDelete()
        {
            // Arrange
            int id = 1;

            // Act
            _clientService.Delete(id);

            // Assert
            _clientRepositoryMock.Verify(repo => repo.Delete(id), Times.Once);
        }

        [Fact(DisplayName = "Delete Throw")]
        [Trait("Categoria", "Client Trait Tests")]
        public void Delete_ZeroId_ThrowsException()
        {
            // Arrange
            int id = 0;

            // Act & Assert
            Assert.Throws<Exception>(() => _clientService.Delete(id));
        }

        #endregion
    }
}
