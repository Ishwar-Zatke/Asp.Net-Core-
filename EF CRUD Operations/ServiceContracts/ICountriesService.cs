using ServiceContracts.DTO;

namespace ServiceContracts
{
  /// <summary>
  /// Represents business logic for manipulating Country entity
  /// </summary>
  public interface ICountriesService
  {
    /// <summary>
    /// Adds a country object to the list of countries
    CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

    /// <summary>
    /// Returns all countries from the list
    List<CountryResponse> GetAllCountries();


    /// <summary>
    /// Returns a country object based on the given country id
    CountryResponse? GetCountryByCountryID(Guid? countryID);
  }
}
