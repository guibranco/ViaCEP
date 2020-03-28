namespace ViaCEP
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// The Via CEP result class.
    /// </summary>
    public sealed class ViaCEPResult
    {
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        [JsonProperty("cep")]
        public String ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        [JsonProperty("logradouro")]
        public String Street { get; set; }

        /// <summary>
        /// Gets or sets the complement.
        /// </summary>
        /// <value>
        /// The complement.
        /// </value>
        [JsonProperty("complemento")]
        public String Complement { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood.
        /// </summary>
        /// <value>
        /// The neighborhood.
        /// </value>
        [JsonProperty("bairro")]
        public String Neighborhood { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [JsonProperty("localidade")]
        public String City { get; set; }

        /// <summary>
        /// Gets or sets the state initials.
        /// </summary>
        /// <value>
        /// The state initials.
        /// </value>
        [JsonProperty("uf")]
        public String StateInitials { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        [JsonProperty("unidade")]
        public String Unit { get; set; }

        /// <summary>
        /// Gets or sets the ibge code.
        /// </summary>
        /// <value>
        /// The ibge code.
        /// </value>
        [JsonProperty("ibge")]
        public Int32 IBGECode { get; set; }

        /// <summary>
        /// Gets or sets the gia code.
        /// </summary>
        /// <value>
        /// The gia code.
        /// </value>
        [JsonProperty("gia")]
        public Int32? GIACode { get; set; }
    }
}
