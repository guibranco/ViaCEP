// ***********************************************************************
// Assembly         : ViaCep.Tests
// Author           : Guilherme Branco Stracini
// Created          : 10-23-2020
//
// Last Modified By : Guilherme Branco Stracini
// Last Modified On : 10-23-2020
// ***********************************************************************
// <copyright file="ResultsFixture.cs" company="Guilherme Branco Stracini ME">
//     Copyright (c) Guilherme Branco Stracini ME. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace ViaCep.Tests
{
    /// <summary>
    /// Class ResultsFixture.
    /// </summary>
    internal static class ResultsFixture
    {
        /// <summary>
        /// Gets the sample results.
        /// </summary>
        /// <returns>ICollection&lt;ViaCepResult&gt;.</returns>
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
                    ZipCode = "12345-678"
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
                    ZipCode = "45632-870"
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
                    ZipCode = "98765-432"
                }
            };
    }
}