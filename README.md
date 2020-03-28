# ViaCEP

A .NET client wrapper for both .NET Core & .NET Framework projects of [Via CEP API](https://viacep.com.br)

![Via CEP](https://raw.githubusercontent.com/guibranco/viacep/master/logo.png)

## CI/CD

[![Build status](https://ci.appveyor.com/api/projects/status/9jnsy1e08jhyxl7j?svg=true)](https://ci.appveyor.com/project/guibranco/9jnsy1e08jhyxl7j)
[![SMSDev NuGet Version](https://img.shields.io/nuget/v/ViaCEP.svg?style=flat)](https://www.nuget.org/packages/ViaCEP/)
[![SMSDev NuGet Downloads](https://img.shields.io/nuget/dt/ViaCEP.svg?style=flat)](https://www.nuget.org/packages/ViaCEP/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/ViaCEP/total.svg?style=flat)](https://github.com/guibranco/ViaCEP)
[![Last release](https://img.shields.io/github/release-date/guibranco/ViaCEP.svg?style=flat)](https://github.com/guibranco/ViaCEP)

## Code Quality

[![codecov](https://codecov.io/gh/guibranco/SMSDev/branch/master/graph/badge.svg)](https://codecov.io/gh/guibranco/SMSDev)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=alert_status)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=coverage)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)

[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=ncloc)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=sqale_index)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)

[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=security_rating)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=code_smells)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=bugs)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=guibranco_ViaCEP&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=guibranco_ViaCEP)

---

NuGet package: https://www.nuget.org/packages/ViaCEP

```ps
Install-Package ViaCEP
```

---

## Usage

The package has two classes:

- [ViaCEPClient](https://github.com/guibranco/ViaCEP/blob/master/ViaCEP/ViaCEPClient.cs) - The main class (methods)
- [ViaCEPResult](https://github.com/guibranco/ViaCEP/blob/master/ViaCEP/VIaCEPResult.cs) - The result class (data)

You can search using the zip code/postal code (AKA CEP) or using the address data (state initials - UF, city name and location name - street, avenue, park, square). Both methods support async and sync!

## Querying by zip code / postal code (single result)

```cs
var result = ViaCEPClient.Search("01234567"); //searches for the postal code 01234-567
var address = result.Address;
var neighborhood = result.Neighborhood
//do what you need with 'result' instance of ViaCEPResult.
```

## Querying by address (list result)

```cs
var results = ViaCEPClient.Search("SP", "São Paulo", "Avenida Paulista"); //search for the Avenida Paulista in São Paulo / SP
foreach(var result in results){
    var address = result.Address;
    var neighborhood = result.Neighborhood;
    var zipCode = result.ZipCode;
    //do what you need with 'result' instance of ViaCEPResult.
}
```
