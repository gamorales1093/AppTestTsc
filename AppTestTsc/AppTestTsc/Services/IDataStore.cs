using AppTestTsc.Complements;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTestTsc.Services
{
    public interface IDataStoreCountries<T>
    {
        Task<Reply> AddCountrieAsync(T countrie);
        Task<Reply> UpdateCountrieAsync(T countrie);
        Task<Reply> DeleteItemAsync(int id);
        Task<Reply> GetCountriesAsync();

    }

    public interface IDataStoreSubdivisions<T>
    {
        Task<Reply> AddSubdivisioAsync(T subdivisio, int id);
        Task<Reply> UpdateSubdivisioAsync(T subdivisio, int id);
        Task<Reply> DeleteSubdivisiomAsync(int id, int idCountrie);
        Task<Reply> GetSubdivisiosAsync(int id);
    }
}
