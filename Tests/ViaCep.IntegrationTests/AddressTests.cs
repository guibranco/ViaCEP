using Xunit;

namespace ViaCep.IntegrationTests
{
    public class AddressTests : IntegrationTest
    {
        [Fact]
        public async Task Search_WithValidAddress_ReturnsExpectedResult()
        {
            //Arrange
            var validState = "SP";
            var validCity = "São Paulo";
            var validAddress = "Rua Direita";
            var validZipCodeOne = "01002-902"; //Corresponds to the above city and state
            var validZipCodeTwo = "01002-000"; //Another valid zip code for the same city and state

            //Act
            var results = (await Client.SearchAsync(validState, validCity, validAddress, default)).ToList();

            //Assert
            Assert.NotNull(results);
            Assert.Contains(results, r => r.ZipCode == validZipCodeOne);
            Assert.Contains(results, r => r.ZipCode == validZipCodeTwo);
        }

        [Fact]
        public async Task Search_WithNonexistentAddress_ReturnsEmptyResults()
        {
            //Arrange
            var nonExistentAddress = "Non-existent Street";
            var nonExistentCity = "Non-existent City";

            //Act
            var results = await Client.SearchAsync("XX", nonExistentCity, nonExistentAddress, default);

            //Assert
            Assert.Empty(results);
        }

        [Fact]
        public async Task Search_WithCanceledToken_ThrowsTaskCanceledException()
        {
            //Arrange
            var validState = "SP";
            var validCity = "São Paulo";
            var validAddress = "Rua Direita";
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            //Act and Assert
            await Assert.ThrowsAsync<TaskCanceledException>(() =>
                Client.SearchAsync(validState, validCity, validAddress, cancellationTokenSource.Token));
        }
    }
}
