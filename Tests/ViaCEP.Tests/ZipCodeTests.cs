using System.Threading;
using System.Threading.Tasks;

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
            Assert.Equal(string.Empty, result.Complement);
            Assert.Equal("Quarta Parada", result.Neighborhood);
            Assert.Equal("São Paulo", result.City);
            Assert.Equal("SP", result.StateInitials);
            Assert.Equal(3550308, result.IBGECode);
            Assert.Equal(1004, result.GIACode);
            Assert.Equal(string.Empty, result.Unit);
        }

        /// <summary>
        /// Validates the search by zip code asynchronous.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ValidateSearchByZipCodeAsync()
        {
            var result = await ViaCEPClient.SearchAsync("03165970", CancellationToken.None);
            Assert.NotNull(result);
            Assert.Equal("Rua da Mooca 3107", result.Street);
            Assert.Equal(string.Empty, result.Complement);
            Assert.Equal("Mooca", result.Neighborhood);
            Assert.Equal("São Paulo", result.City);
            Assert.Equal("SP", result.StateInitials);
            Assert.Equal(3550308, result.IBGECode);
            Assert.Equal(1004, result.GIACode);
            Assert.Equal(string.Empty, result.Unit);
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
            Assert.Equal("Avenida Henfil", result.Street);
            Assert.Equal("até 600/601", result.Complement);
            Assert.Equal("Recreio dos Bandeirantes", result.Neighborhood);
            Assert.Equal("Rio de Janeiro", result.City);
            Assert.Equal("RJ", result.StateInitials);
            Assert.Equal(3304557, result.IBGECode);
            Assert.Null(result.GIACode);
            Assert.Equal(string.Empty, result.Unit);
        }
    }
}
