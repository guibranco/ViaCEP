namespace ViaCep.Tests
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Xunit;

    /// <summary>
    /// The address tests class.
    /// </summary>
    public class AddressTests
    {
        /// <summary>
        /// Validates the search by full address.
        /// </summary>
        [Fact]
        public void ValidateSearchByFullAddress()
        {
            var fixtureResults = ResultsFixture.GetSampleResults();
            var clientMock = new Mock<IViaCepClient>();
            clientMock
                .Setup(c => c.Search(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(fixtureResults);

            var results = clientMock.Object.Search(
                fixtureResults.First().StateInitials,
                fixtureResults.First().City,
                fixtureResults.First().Street
            );
            Assert.NotNull(results);

            var list = results.ToList();
            Assert.True(list.Any());
            Assert.Contains(
                list,
                r => r.ZipCode.Equals("12345-678", StringComparison.InvariantCultureIgnoreCase)
            );
            Assert.Contains(
                list,
                r => r.ZipCode.Equals("98765-432", StringComparison.InvariantCultureIgnoreCase)
            );
        }

        /// <summary>
        /// Validates the search by full address asynchronous.
        /// </summary>
        [Fact]
        public async Task ValidateSearchByFullAddressAsync()
        {
            var fixtureResults = ResultsFixture.GetSampleResults();
            var clientMock = new Mock<IViaCepClient>();
            clientMock
                .Setup(c =>
                    c.SearchAsync(
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<string>(),
                        It.IsAny<CancellationToken>()
                    )
                )
                .ReturnsAsync(fixtureResults);

            var results = await clientMock.Object.SearchAsync(
                fixtureResults.First().StateInitials,
                fixtureResults.First().City,
                fixtureResults.First().Street,
                CancellationToken.None
            );
            Assert.NotNull(results);

            var list = results.ToList();
            Assert.True(list.Any());
            Assert.Contains(
                list,
                r => r.ZipCode.Equals("12345-678", StringComparison.InvariantCultureIgnoreCase)
            );
            Assert.Contains(
                list,
                r => r.ZipCode.Equals("98765-432", StringComparison.InvariantCultureIgnoreCase)
            );
        }
    }
}
