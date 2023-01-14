namespace ViaCep
{
    using Newtonsoft.Json;

    /// <summary>
    /// The Via CEP result class.
    /// </summary>
    public sealed class ViaCepResult
    {
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        [JsonProperty("cep")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        [JsonProperty("logradouro")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the complement.
        /// </summary>
        /// <value>
        /// The complement.
        /// </value>
        [JsonProperty("complemento")]
        public string Complement { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood.
        /// </summary>
        /// <value>
        /// The neighborhood.
        /// </value>
        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [JsonProperty("localidade")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state initials.
        /// </summary>
        /// <value>
        /// The state initials.
        /// </value>
        [JsonProperty("uf")]
        public string StateInitials { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        [JsonProperty("unidade")]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the ibge code.
        /// </summary>
        /// <value>
        /// The ibge code.
        /// </value>
        [JsonProperty("ibge")]
        public int IBGECode { get; set; }

        /// <summary>
        /// Gets or sets the gia code.
        /// </summary>
        /// <value>
        /// The gia code.
        /// </value>
        [JsonProperty("gia")]
        public int? GIACode { get; set; }
    }
}
