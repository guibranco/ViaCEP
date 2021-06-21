# ViaCEP

A .NET client wrapper for both .NET Core & .NET Framework projects of [Via CEP API](https://viacep.com.br)

[![GitHub license](https://img.shields.io/github/license/guibranco/ViaCep)](https://github.com/guibranco/ViaCep)
[![time tracker](https://wakatime.com/badge/github/guibranco/ViaCEP.svg)](https://wakatime.com/badge/github/guibranco/ViaCEP)

![Via CEP](https://raw.githubusercontent.com/guibranco/viacep/master/logo.png)

## CI/CD

| Branch | Build status | Last commit | Tests |
|--------|--------------|-------------|-------|
| Master | [![Build status](https://ci.appveyor.com/api/projects/status/9jnsy1e08jhyxl7j/branch/master?svg=true)](https://ci.appveyor.com/project/guibranco/ViaCEP) | [![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/ViaCEP/master)](https://github.com/guibranco/ViaCEP) | ![AppVeyor tests (branch)](https://img.shields.io/appveyor/tests/guibranco/ViaCEP/master?compact_message) |
| Develop | [![Build status](https://ci.appveyor.com/api/projects/status/9jnsy1e08jhyxl7j/branch/develop?svg=true)](https://ci.appveyor.com/project/guibranco/ViaCEP/branch/develop) | [![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/ViaCEP/develop)](https://github.com/guibranco/ViaCEP) | ![AppVeyor tests (branch)](https://img.shields.io/appveyor/tests/guibranco/ViaCEP/develop?compact_message) |

## Code Quality

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/483c4901f0ea4a0d99e69be931ced362)](https://www.codacy.com/gh/guibranco/ViaCEP/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=guibranco/ViaCEP&amp;utm_campaign=Badge_Grade)
[![codecov](https://codecov.io/gh/guibranco/ViaCEP/branch/master/graph/badge.svg)](https://codecov.io/gh/guibranco/ViaCEP)
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

## Installation

### Github Releases

[![GitHub last release](https://img.shields.io/github/release-date/guibranco/ViaCEP.svg?style=flat)](https://github.com/guibranco/ViaCEP) [![Github All Releases](https://img.shields.io/github/downloads/guibranco/ViaCEP/total.svg?style=flat)](https://github.com/guibranco/ViaCEP)

Download the latest zip file from the [Release](https://github.com/GuiBranco/ViaCEP/releases) page.

### Nuget package manager

| Package | Version | Downloads |
|------------------|:-------:|:-------:|
| **ViaCEP** | [![ViaCEP NuGet Version](https://img.shields.io/nuget/v/ViaCEP.svg?style=flat)](https://www.nuget.org/packages/ViaCEP/) | [![ViaCEP NuGet Downloads](https://img.shields.io/nuget/dt/ViaCEP.svg?style=flat)](https://www.nuget.org/packages/ViaCEP/) |

---

## Usage

The package has two classes:

-  [ViaCepClient](https://github.com/guibranco/ViaCEP/blob/master/ViaCEP/ViaCepClient.cs): The main class (methods)
-  [ViaCepResult](https://github.com/guibranco/ViaCEP/blob/master/ViaCEP/ViaCepResult.cs): The result class (data)

This package is fully compatible with Dependency Injection. Use the interface *IViaCepClient* and the constructor with HttpClient parameter with a IHttpClientFactory instance.

```cs
//your DI container
services.AddHttpClient<IViaCepClient, ViaCepClient>(client => { client.BaseAddress = new Uri("https://viacep.com.br/"); });

//then use in your domain service, handler, controller...
var viaCepClient = container.GetService<IViaCepClient>();
var result = await viaCepClient.SearchAsync("01001000", cancellationToken);
```

You can search using the zip code/postal code (AKA CEP) or using the address data (state initials - UF, city name and location name - street, avenue, park, square). Both methods support async and sync!

### Querying by zip code / postal code (single result)

```cs
var result = new ViaCepClient().Search("01001000"); //searches for the postal code 01001-000
var address = result.Address; //Praça da Sé
var city = reuslt.City; //São Paulo
//do what you need with 'result' instance of ViaCEPResult.
```

### Querying by address (list result)

```cs
var results = new ViaCepClient().Search("SP", "São Paulo", "Avenida Paulista"); //search for the Avenida Paulista in São Paulo / SP
foreach(var result in results){
    var address = result.Address;
    var neighborhood = result.Neighborhood;
    var zipCode = result.ZipCode;
    //do what you need with 'result' instance of ViaCEPResult.
}
```

## Changelog

-  2021-06-21 - Version 3.2:
  -  Update dependencies version. [@guibranco](https://github.com/guibranco) 

-  2020-10-23 - Version 3.1:
  -  Add support to .NET Standard 2.0 and .NET Framework v4.6.1 and above. [@guibranco](https://github.com/guibranco) 