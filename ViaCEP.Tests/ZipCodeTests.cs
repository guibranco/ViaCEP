namespace ViaCEP.Tests
{
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
            var result = ViaCEPClient.Search("03177010");
            Assert.NotNull(result);
            Assert.Equal("Rua Doutor João Batista de Lacerda", result.Street);
            Assert.Equal("Quarta Parada", result.Neighborhood);
            Assert.Equal("São Paulo", result.City);
            Assert.Equal("SP", result.StateInitials);
        }
    }
}
