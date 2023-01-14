namespace ViaCep
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The Via CEP client class.
    /// </summary>
    public class ViaCepClient : IViaCepClient
    {
        #region Private fields

        /// <summary>
        /// The base URL
        /// </summary>
        private const string _baseUrl = "https://viacep.com.br";

        /// <summary>
        /// The HTTP client
        /// </summary>
        private readonly HttpClient _httpClient;

        #endregion

        #region ~Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViaCepClient"/> class.
        /// </summary>
        public ViaCepClient()
        {
            _httpClient = HttpClientFactory.Create();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViaCepClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public ViaCepClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Searches the specified zip code.
        /// </summary>
        /// <param name="zipCode">The zip code.</param>
        /// <returns></returns>
        public ViaCepResult Search(string zipCode)
        {
            return SearchAsync(zipCode, CancellationToken.None).Result;
        }

        /// <summary>
        /// Searches the specified state initials.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public IEnumerable<ViaCepResult> Search(string stateInitials, string city, string address)
        {
            return SearchAsync(stateInitials, city, address, CancellationToken.None).Result;
        }

        /// <summary>
        /// Searches the asynchronous.
        /// </summary>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="cancellationToken">The token.</param>
        /// <returns></returns>
        public async Task<ViaCepResult> SearchAsync(string zipCode, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"/ws/{zipCode}/json", cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ViaCepResult>(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Searches the asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="address">The address.</param>
        /// <param name="cancellationToken">The token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ViaCepResult>> SearchAsync(
            string stateInitials, string city, string address, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"/ws/{stateInitials}/{city}/{address}/json", cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<ViaCepResult>>(cancellationToken).ConfigureAwait(false);
        }

        #endregion
    }
}
