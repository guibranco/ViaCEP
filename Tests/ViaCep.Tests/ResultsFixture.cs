namespace ViaCep.Tests
{
    using System.Collections.Generic;

    /// <summary>
    /// Class ResultsFixture.
    /// </summary>
    internal static class ResultsFixture
    {
        /// <summary>
        /// Retrieves a sample collection of <see cref="ViaCepResult"/> objects.
        /// </summary>
        /// <returns>A collection of sample <see cref="ViaCepResult"/> instances representing address information.</returns>
        /// <remarks>
        /// This method creates and returns a list of <see cref="ViaCepResult"/> objects, each containing various properties such as
        /// Unit, City, Complement, GIACode, IBGECode, Neighborhood, StateInitials, Street, and ZipCode.
        /// The sample data includes multiple entries for the city of São Paulo, demonstrating different combinations of
        /// address attributes. This can be useful for testing or demonstration purposes where mock data is needed.
        /// </remarks>
        public static ICollection<ViaCepResult> GetSampleResults() =>
            new List<ViaCepResult>
            {
                new ViaCepResult
                {
                    Unit = "Any",
                    City = "São Paulo",
                    Complement = "",
                    GIACode = 1,
                    IBGECode = 1,
                    Neighborhood = "Centro",
                    StateInitials = "SP",
                    Street = "Rua Direita",
                    ZipCode = "12345-678",
                },
                new ViaCepResult
                {
                    Unit = "",
                    City = "São Paulo",
                    Complement = "",
                    GIACode = null,
                    IBGECode = 1,
                    Neighborhood = "Centro",
                    StateInitials = "SP",
                    Street = "Rua Direita",
                    ZipCode = "45632-870",
                },
                new ViaCepResult
                {
                    Unit = "",
                    City = "São Paulo",
                    Complement = "",
                    GIACode = 12,
                    IBGECode = 123,
                    Neighborhood = "Centro",
                    StateInitials = "SP",
                    Street = "Rua Direita",
                    ZipCode = "98765-432",
                },
            };
    }
}
