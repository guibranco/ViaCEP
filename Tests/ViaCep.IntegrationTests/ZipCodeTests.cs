using Xunit;

namespace ViaCep.IntegrationTests
{
    public class ZipCodeTests : IntegrationTest
    {
        [Fact]
        public async Task Search_WithValidZipCode_ReturnsExpectedResult()
        {
            //Arrange
            var validZipCode = "01001-000";

            //Act
            var result = await Client.SearchAsync(validZipCode, default);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(validZipCode, result.ZipCode);
            Assert.NotNull(result.City);
            Assert.NotNull(result.StateInitials);
        }

        [Fact]
        public async Task Search_WithInvalidZipCode_ThrowsHttpRequestException()
        {
            //Arrange
            var invalidZipCode = "invalid";

            //Act and Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => Client.SearchAsync(invalidZipCode, default));
        }

        [Fact]
        public async Task Search_WithCanceledToken_ThrowsTaskCanceledException()
        {
            //Arrange
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            //Act and Assert
            await Assert.ThrowsAsync<TaskCanceledException>(() =>
                Client.SearchAsync("01001-000", cancellationTokenSource.Token));
        }
    }
}
