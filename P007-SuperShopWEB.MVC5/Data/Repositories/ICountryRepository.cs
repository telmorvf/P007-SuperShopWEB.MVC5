﻿using P007_SuperShopWEB.MVC5.Data.Entities;

namespace P007_SuperShopWEB.MVC5.Data.Repositories
{
    public interface ICountryRepository
    {
        public interface ICountryRepository : IGenericRepository<Country>
        {
            //IQueryable GetCountriesWithCities();

            //Task<Country> GetCountryWithCitiesAsync(int id);

            //Task<City> GetCityAsync(int id);

            //Task AddCityAsync(CityViewModel model);

            //Task<int> UpdateCityAsync(City city);

            //Task<int> DeleteCityAsync(City city);

            //IEnumerable<SelectListItem> GetComboCountries();

            //IEnumerable<SelectListItem> GetComboCities(int countryId);

            //Task<Country> GetCountryAsync(City city);

        }
    }
}
