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
            Assert.Equal("Rua Doutor Jo�o Batista de Lacerda", result.Street);
            Assert.Equal("Quarta Parada", result.Neighborhood);
            Assert.Equal("S�o Paulo", result.City);
            Assert.Equal("SP", result.StateInitials);
        }
        
        
        /// <summary>
        /// Validates if the search by zip code don't throw a exception if the address doesn't have a gia code 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void ValidateSearchByZipCodeWithoutGiaCode()
        {
            var result = ViaCEPClient.Search("22795641");
            Assert.NotNull(result);
            Assert.Null(result.GIACode);
        }
    }
}
