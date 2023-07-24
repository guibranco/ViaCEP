namespace ViaCep.Tests
{
    using Moq;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    /// <summary>
    /// The zip code tests class.
    /// </summary>
    public class ZipCodeTests
    {
        /// <summary>
        /// Validates the search by zip code.
        /// </summary>
        [Fact]
        public void ValidateSearchByZipCode()
        {
            var fixtureResults = ResultsFixture.GetSampleResults();
            var clientMock = new Mock<IViaCepClient>();
            clientMock
                .Setup(c => c.Search(It.IsAny<string>()))
                .Returns(fixtureResults.First(r => r.ZipCode.Equals("12345-678")));

            var result = clientMock.Object.Search("12345678");
            Assert.NotNull(result);
            Assert.Equal("Any", result.Unit);
            Assert.Equal("Rua Direita", result.Street);
            Assert.Equal(string.Empty, result.Complement);
            Assert.Equal(1, result.GIACode);
            Assert.Equal(1, result.IBGECode);
            Assert.Equal("Centro", result.Neighborhood);
            Assert.Equal("São Paulo", result.City);
            Assert.Equal("SP", result.StateInitials);
        }

        /// <summary>
        /// Validates the search by zip code asynchronous.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ValidateSearchByZipCodeAsync()
        {
            var fixtureResults = ResultsFixture.GetSampleResults();
            var clientMock = new Mock<IViaCepClient>();
            clientMock
                .Setup(c => c.SearchAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fixtureResults.First(r => r.ZipCode.Equals("12345-678")));

            var result = await clientMock.Object.SearchAsync("12345678", CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal("Any", result.Unit);
            Assert.Equal("Rua Direita", result.Street);
            Assert.Equal(string.Empty, result.Complement);
            Assert.Equal(1, result.GIACode);
            Assert.Equal(1, result.IBGECode);
            Assert.Equal("Centro", result.Neighborhood);
            Assert.Equal("São Paulo", result.City);
            Assert.Equal("SP", result.StateInitials);
        }

        /// <summary>
        /// Validates if the search by zip code don't throw a exception if the address doesn't have a gia code
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ValidateSearchByZipCodeWithoutGiaCode()
        {
            var fixtureResults = ResultsFixture.GetSampleResults();
            var clientMock = new Mock<IViaCepClient>();
            clientMock
                .Setup(c => c.Search(It.IsAny<string>()))
                .Returns(fixtureResults.First(r => !r.GIACode.HasValue));

            var result = clientMock.Object.Search("12345678");
            Assert.NotNull(result);
            Assert.Equal("", result.Unit);
            Assert.Equal("Rua Direita", result.Street);
            Assert.Equal(string.Empty, result.Complement);
            Assert.Null(result.GIACode);
            Assert.Equal(1, result.IBGECode);
            Assert.Equal("Centro", result.Neighborhood);
            Assert.Equal("São Paulo", result.City);
            Assert.Equal("SP", result.StateInitials);
        }

        /// <summary>
        /// Validates the search by zip code without gia code asynchronous.
        /// </summary>
        [Fact]
        public async Task ValidateSearchByZipCodeWithoutGiaCodeAsync()
        {
            var fixtureResults = ResultsFixture.GetSampleResults();
            var clientMock = new Mock<IViaCepClient>();
            clientMock
                .Setup(c => c.SearchAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fixtureResults.First(r => !r.GIACode.HasValue));

            var result = await clientMock.Object.SearchAsync("12345678", CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal("", result.Unit);
            Assert.Equal("Rua Direita", result.Street);
            Assert.Equal(string.Empty, result.Complement);
            Assert.Null(result.GIACode);
            Assert.Equal(1, result.IBGECode);
            Assert.Equal("Centro", result.Neighborhood);
            Assert.Equal("São Paulo", result.City);
            Assert.Equal("SP", result.StateInitials);
        }
    }
}
