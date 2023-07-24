namespace ViaCep
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The ViaCEP client interface.
    /// </summary>
    public interface IViaCepClient
    {
        /// <summary>
        /// Searches the specified zip code.
        /// </summary>
        /// <param name="zipCode">The zip code.</param>
        /// <returns></returns>
        ViaCepResult Search(string zipCode);

        /// <summary>
        /// Searches the specified address by state initials (UF), city and address name.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        IEnumerable<ViaCepResult> Search(string stateInitials, string city, string address);

        /// <summary>
        /// Searches the specified zip code asynchronous.
        /// </summary>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<ViaCepResult> SearchAsync(string zipCode, CancellationToken cancellationToken);

        /// <summary>
        /// Searches the specified address by state initials (UF), city and address name asynchronous.
        /// </summary>
        /// <param name="stateInitials">The state initials.</param>
        /// <param name="city">The city.</param>
        /// <param name="address">The address.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<ViaCepResult>> SearchAsync(
            string stateInitials,
            string city,
            string address,
            CancellationToken cancellationToken
        );
    }
}
