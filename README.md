# ViaCEP
The [ViaCEP](https://viacep.com.br) web service client for .NET projects

[![Build status](https://ci.appveyor.com/api/projects/status/9jnsy1e08jhyxl7j?svg=true)](https://ci.appveyor.com/project/guibranco/viacep)
[![LatLongNet NuGet Version](https://img.shields.io/nuget/v/ViaCEP.svg?style=flat)](https://www.nuget.org/packages/ViaCEP/)
[![LatLongNet NuGet Downloads](https://img.shields.io/nuget/dt/ViaCEP.svg?style=flat)](https://www.nuget.org/packages/ViaCEP/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/ViaCEP/total.svg?style=flat)](https://github.com/guibranco/ViaCEP)

![Last release](https://img.shields.io/github/release-date/guibranco/viacep.svg?style=flat)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=alert_status)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=ncloc)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_CEPAberto&metric=security_rating)](https://sonarcloud.io/dashboard?id=guibranco_CEPAberto)

<img src="https://raw.githubusercontent.com/guibranco/ViaCEP/master/logo.png" alt="ViaCEP"  width="287" height="72">


The ViaCEP service is exclusive for Brazil! No zipcode data  available for other countries (Feb/2019)!

---
NuGet package: https://www.nuget.org/packages/ViaCEP

```
Install-Package ViaCEP
```

---
## Usage

The package has two classes:
- ViaCEPClient - The main class (methods)
- ViaCEPResult - The result class (data)

## Querying by zip code / postal code (single result)

```cs
var result = ViaCEPClient.Search("01234567"); //searches for the postal code 01234-567
var address = result.Address;
var neighborhood = result.Neighborhood
//do what you need with 'result' instance of ViaCEPResult.
```


## Querying by addres (list result)

```cs
var results = ViaCEPClient.Search("SP", "São Paulo", "Avenida Paulista"); //search for the Avenida Paulista in São Paulo / SP
foreach(var result in results){
    var address = result.Address;
    var neighborhood = result.Neighborhood;
    var zipCode = result.ZipCode;
    //do what you need with 'resul' instance of ViaCEPResult.
}
```