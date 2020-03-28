namespace ViaCep.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Moq;
    using System.Threading;
    using System.Threading.Tasks;

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

            var result = clientMock.Object.Search(fixtureResults.First().StateInitials, fixtureResults.First().City, fixtureResults.First().Street);
            Assert.NotNull(result);

            var list = result.ToList();
            Assert.True(list.Any());
            Assert.Contains(list, r => r.ZipCode.Equals("12345-678", StringComparison.InvariantCultureIgnoreCase));
            Assert.Contains(list, r => r.ZipCode.Equals("98765-432", StringComparison.InvariantCultureIgnoreCase));
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
                .Setup(c => c.SearchAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fixtureResults);

            var result = await clientMock.Object.SearchAsync(fixtureResults.First().StateInitials, fixtureResults.First().City, fixtureResults.First().Street, CancellationToken.None);
            Assert.NotNull(result);

            var list = result.ToList();
            Assert.True(list.Any());
            Assert.Contains(list, r => r.ZipCode.Equals("12345-678", StringComparison.InvariantCultureIgnoreCase));
            Assert.Contains(list, r => r.ZipCode.Equals("98765-432", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}