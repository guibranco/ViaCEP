namespace ViaCep.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    /// <summary>
    /// Common test helper methods to reduce code duplication
    /// </summary>
    internal static class TestHelpers
    {
        /// <summary>
        /// Validates the common assertions for address search results
        /// </summary>
        /// <param name="results">The results to validate</param>
        public static void ValidateAddressSearchResults(IEnumerable<ViaCepResult> results)
        {
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
        /// Validates the common assertions for zip code search results with GIA code
        /// </summary>
        /// <param name="result">The result to validate</param>
        public static void ValidateZipCodeSearchResultWithGiaCode(ViaCepResult result)
        {
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
        /// Validates the common assertions for zip code search results without GIA code
        /// </summary>
        /// <param name="result">The result to validate</param>
        public static void ValidateZipCodeSearchResultWithoutGiaCode(ViaCepResult result)
        {
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