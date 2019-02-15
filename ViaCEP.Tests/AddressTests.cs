namespace ViaCEP.Tests
{
    using System.Linq;
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
            var result = ViaCEPClient.Search("SP", "São Paulo", "Avenida Paulista");
            Assert.NotNull(result);
            var list = result.ToList();
            Assert.True(list.Any());
            var first = list.First();
            Assert.Equal("SP", first.StateInitials);
            Assert.Equal("São Paulo", first.City);
            Assert.Equal("01310-905", first.ZipCode);

        }
    }
}