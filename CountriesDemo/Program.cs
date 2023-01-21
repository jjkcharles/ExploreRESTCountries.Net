// See https://aka.ms/new-console-template for more information
using RESTCountries.NET;
using RESTCountries.NET.Services;

//Total # of countries
Console.WriteLine("There are {0} countries in the world", RestCountriesService.GetAllCountries().Where(x=>x.Independent==true).Count());

//Countries using a specific currency
var curreny = "INR";
Console.WriteLine("\nCountries that use {0} as currency:", curreny);
foreach(var x in RestCountriesService.GetCountriesByCurrency(curreny))
{
    Console.WriteLine("{0} (Capital: {1})", x.Name.Common, x.Capital.First());
}

//Country by code
var code = "IN";
Console.WriteLine("\nCountry with code {0}:", code);
Console.WriteLine("{0} (Capital: {1})", RestCountriesService.GetCountryByCode(code)?.Name.Common, RestCountriesService.GetCountryByCode(code)?.Capital.First());
Console.WriteLine("In French:");
Console.WriteLine("{0} (Capital: {1})", RestCountriesService.GetCountryByCode(code)?.Translations["fra"].Common, RestCountriesService.GetCountryByCode(code)?.Capital.First());
//TODO: Looks like there is no way to tranlsate Capital of the Country

//Countries that share land borders with specified country
var inputCountryCode="NZ";
var inputCountry = RestCountriesService.GetCountryByCode(inputCountryCode);
if(inputCountry != null)
{
    var borderingCountries = RestCountriesService.GetAllCountries().Where(x=>x.Borders!=null && x.Borders.Contains(inputCountryCode));
    if(borderingCountries.Count()>0) 
    {
        Console.WriteLine("\n{0} shares borders with following countries:", inputCountry?.Name.Common);
    }
    else
    {
        Console.WriteLine("\n{0} shares borders with no other countries.", inputCountry?.Name.Common);
    }
    foreach(var borderCountry in borderingCountries)
    {
        Console.WriteLine("{0} (Capital: {1})", borderCountry.Name.Common, borderCountry.Capital.First());
    }
}