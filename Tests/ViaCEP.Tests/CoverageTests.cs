using System;
using System.Linq;
using System.Net.Http;
using RichardSzalay.MockHttp;
using Xunit;

namespace ViaCep.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class CoverageTests
    {
        /// <summary>
        /// The base URL
        /// </summary>
        private readonly Uri _baseUrl = new Uri("https://viacep.com.br/");

        /// <summary>
        /// Validates the create new instance.
        /// </summary>
        [Fact]
        public void ValidateCreateNewInstance()
        {
            var client = new ViaCepClient();
            Assert.NotNull(client);
        }

        /// <summary>
        /// Validates the search by zip code coverage.
        /// </summary>
        [Fact]
        public void ValidateSearchByZipCodeCoverage()
        {
            const string resultData = "{'cep': '01001-000','logradouro': 'Praça da Sé','complemento': 'lado ímpar','bairro': 'Sé','localidade': 'São Paulo','uf': 'SP','unidade': '','ibge': '3550308','gia': '1004'}";
            var httpClientMock = new MockHttpMessageHandler();
            httpClientMock.When("https://viacep.com.br/ws/*/json")
                          .Respond("application/json", resultData);
                                   
            var httpClient = new HttpClient(httpClientMock) {BaseAddress = _baseUrl};
            var client = new ViaCepClient(httpClient);

            var result = client.Search("01001000");
            Assert.NotNull(result);
            Assert.Equal("01001-000", result.ZipCode);
            Assert.Equal("Praça da Sé", result.Street);
            Assert.Equal("lado ímpar", result.Complement);
            Assert.Equal("Sé", result.Neighborhood);
            Assert.Equal("São Paulo", result.City);
            Assert.Equal("SP", result.StateInitials);
            Assert.Equal(string.Empty, result.Unit);
            Assert.Equal(3550308, result.IBGECode);
            Assert.True(result.GIACode.HasValue);
            Assert.Equal(1004, result.GIACode);
        }

        /// <summary>
        /// Validates the search by address coverage.
        /// </summary>
        [Fact]
        public void ValidateSearchByAddressCoverage()
        {
            const string resultData =
                "[ { 'cep': '91790-072', 'logradouro': 'Rua Domingos José Poli', 'complemento': '', 'bairro': 'Restinga', 'localidade': 'Porto Alegre', 'uf': 'RS', 'unidade': '', 'ibge': '4314902', 'gia': '' }, { 'cep': '91910-420', 'logradouro': 'Rua José Domingos Varella', 'complemento': '', 'bairro': 'Cavalhada', 'localidade': 'Porto Alegre', 'uf': 'RS', 'unidade': '', 'ibge': '4314902', 'gia': '' }, { 'cep': '90420-200', 'logradouro': 'Rua Domingos José de Almeida', 'complemento': '', 'bairro': 'Rio Branco', 'localidade': 'Porto Alegre', 'uf': 'RS', 'unidade': '', 'ibge': '4314902', 'gia': '' } ]";
            var httpClientMock = new MockHttpMessageHandler();
            httpClientMock.When("https://viacep.com.br/ws/*/*/*/json")
                          .Respond("application/json", resultData);

            var httpClient = new HttpClient(httpClientMock) { BaseAddress = _baseUrl };
            var client = new ViaCepClient(httpClient);

            var results = client.Search("RS", "Porto Alegre", "Domingos Jose");
            Assert.NotNull(results);

            var list = results.ToList();
            Assert.Equal(3, list.Count);
            Assert.All(list, result => Assert.False(result.GIACode.HasValue));
            Assert.All(list, result => Assert.Empty(result.Complement));
            Assert.All(list, result => Assert.Equal("Porto Alegre", result.City));
            Assert.All(list, result => Assert.Equal("RS", result.StateInitials));
            Assert.All(list, result => Assert.Equal(4314902, result.IBGECode));
            
        }

    }
}
