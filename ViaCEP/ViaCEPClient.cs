namespace ViaCEP
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The Via CEP client class.
    /// </summary>
    public static class ViaCEPClient
    {
        #region Private fields

        /// <summary>
        /// The base URL
        /// </summary>
        private const String BaseUrl = "https://viacep.com.br/ws/";

        #endregion


        #region Public methods

        /// <summary>
        /// Searches the specified zip code.
        /// </summary>
        /// <param name="zipCode">The zip code.</param>
        /// <returns></returns>
        public static ViaCEPResult Search(String zipCode)
        {
            return SearchAsync(zipCode, CancellationToken.None).Result;
        }

        /// <summary>
        /// Searches the asynchronous.
        /// </summary>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public static async Task<ViaCEPResult> SearchAsync(String zipCode, CancellationToken token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = await client.GetAsync($"{zipCode}/json", token).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<ViaCEPResult>(token).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Searches the specified state initials.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public static IEnumerable<ViaCEPResult> Search(String stateInitials, String city, String address)
        {
            return SearchAsync(stateInitials, city, address, CancellationToken.None).Result;
        }

        /// <summary>
        /// Searches the asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="address">The address.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public static async Task<IEnumerable<ViaCEPResult>> SearchAsync(
            String stateInitials,
            String city,
            String address,
                    CancellationToken token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var response = await client.GetAsync($"{stateInitials}/{city}/{address}/json", token).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<List<ViaCEPResult>>(token).ConfigureAwait(false);
            }
        }

        #endregion
    }
}
