using AppTestTsc.Complements;
using AppTestTsc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppTestTsc.Services
{
    public class MockDataStore : IDataStoreCountries<Countries>, IDataStoreSubdivisions<Subdivisions>
    {

        #region Fields


        #endregion Fields

        #region Constructor
        public MockDataStore()
        {

        }

        #endregion Constructor

        #region Properties

        #endregion Properties

        public string UrlWebAppi { get {

                return "https://exam-api.tsc-dev.xyz/api/countries";
            }
        
        }



        #region Methods

        //GET
        //GET all Countries
        public async Task<Reply> GetCountriesAsync()
        {
            Reply countriesObject = new Reply();
            try
            {                            
                using (var client = new HttpClient())
                {

                    var getCountriesRequest = await client.GetAsync(UrlWebAppi);

                    var getCountriesResponse = await getCountriesRequest.Content.ReadAsStringAsync();

                    if (getCountriesRequest.IsSuccessStatusCode)
                    {
                        
                        var result = JsonConvert.DeserializeObject<Root>(getCountriesResponse);

                        if (result.data.Any())
                        {
                            countriesObject.Data = result.data.ToList();
                            countriesObject.Result = 1;
                            countriesObject.Message = "OK";

                        }

                        return countriesObject;
                    }
                    else
                    {
                        countriesObject.Message = getCountriesResponse;
                        countriesObject.Result = 1;
                    }
                }

               
            }
            catch (Exception ex)
            {
                countriesObject.Message = ex.Message;
                countriesObject.Result = 0;

                return countriesObject;
            }

            return countriesObject;
        }

        //PATCH
        //PATCH exist countrie
        public async Task<Reply> UpdateCountrieAsync(Countries countrie)
        {
            Reply countriesObject = new Reply();
            try
            {
                using (var client = new HttpClient())
                {

                    var jsonSerializerSettings = new JsonSerializerSettings
                    {
                        Formatting = Newtonsoft.Json.Formatting.Indented,
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    };

                    string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(countrie, jsonSerializerSettings);

                    HttpContent httpContent = new StringContent(jsonStr, Encoding.UTF8);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var PatchCountrieRequest = await Complements.HttpClientExtensions.PatchAsync(client,new Uri(UrlWebAppi + "/" + countrie.Id), httpContent);

                    var PathCountrieResponse = await PatchCountrieRequest.Content.ReadAsStringAsync();

                    if (PatchCountrieRequest.IsSuccessStatusCode)
                    {
                        countriesObject.Message = "OK";
                        countriesObject.Result = 1;

                        return countriesObject;

                    }
                    else
                    {
                        countriesObject.Message = PathCountrieResponse;
                        countriesObject.Result = 1;
                    }
                }

                return countriesObject;
            }
            catch (Exception ex)
            {
                countriesObject.Message = ex.Message;
                countriesObject.Result = 0;

                return countriesObject;
            }
        }

        //POST
        //POST add new Countrie
        public async Task<Reply> AddCountrieAsync(Countries countrie)
        {

            Reply countriesObject = new Reply();
            try
            {
                using (var client = new HttpClient())
                {

                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(countrie), Encoding.UTF8);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var AddCountrieRequest = await client.PostAsync(UrlWebAppi, httpContent);

                    var AddCountrieResponse = await AddCountrieRequest.Content.ReadAsStringAsync();

                    if (AddCountrieRequest.IsSuccessStatusCode)
                    {
                        countriesObject.Message = "OK";
                        countriesObject.Result = 1;
                    }
                    else
                    {
                        countriesObject.Message = AddCountrieResponse;
                        countriesObject.Result = 0;
                    }
                }
                return countriesObject;
            }
            catch (Exception ex)
            {
                countriesObject.Message = ex.Message;
                countriesObject.Result = 0;

                return countriesObject;
            }
        }

        //DELETE
        //DELETE COUNTRIE
        public async Task<Reply> DeleteItemAsync(int id)
        {
            Reply countriesObject = new Reply();
            try
            {
                using (var client = new HttpClient())
                {
                    var DeleteCountrieRequest = await client.DeleteAsync(UrlWebAppi + "/"+id);

                    var AddCountrieResponse = await DeleteCountrieRequest.Content.ReadAsStringAsync();

                    if (DeleteCountrieRequest.IsSuccessStatusCode)
                    {
                        countriesObject.Message = "OK";
                        countriesObject.Result = 1;
                    }
                    else
                    {
                        countriesObject.Message = AddCountrieResponse;
                        countriesObject.Result = 0;
                    }
                }
                return countriesObject;
            }
            catch (Exception ex)
            {
                countriesObject.Message = ex.Message;
                countriesObject.Result = 0;

                return countriesObject;
            }
        }

        //POST
        //POST add new subdivision
        public async Task<Reply> AddSubdivisioAsync(Subdivisions subdivisio, int idCountrie)
        {
            Reply subdivisionObject = new Reply();
            try
            {
                using (var client = new HttpClient())
                {

                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(subdivisio), Encoding.UTF8);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var AddSubdivisionRequest = await client.PostAsync(UrlWebAppi +"/"+idCountrie.ToString() + "/subdivisions", httpContent);

                    var AddSubdivisionResponse = await AddSubdivisionRequest.Content.ReadAsStringAsync();

                    if (AddSubdivisionRequest.IsSuccessStatusCode)
                    {
                        subdivisionObject.Message = "OK";
                        subdivisionObject.Result = 1;
                    }
                    else
                    {
                        subdivisionObject.Message = AddSubdivisionResponse;
                        subdivisionObject.Result = 0;
                    }
                }
                return subdivisionObject;
            }
            catch (Exception ex)
            {
                subdivisionObject.Message = ex.Message;
                subdivisionObject.Result = 0;

                return subdivisionObject;
            }
        }

        //PATCH
        //PATCH update subdivision
        public async Task<Reply> UpdateSubdivisioAsync(Subdivisions subdivisio, int idCountrie)
        {
            Reply subdivisionObject = new Reply();
            try
            {
                using (var client = new HttpClient())
                {

                    var jsonSerializerSettings = new JsonSerializerSettings
                    {
                        Formatting = Newtonsoft.Json.Formatting.Indented,
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    };

                    string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(subdivisio, jsonSerializerSettings);

                    HttpContent httpContent = new StringContent(jsonStr, Encoding.UTF8);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var PatchSubdivisionRequest = await Complements.HttpClientExtensions.PatchAsync(client, new Uri(UrlWebAppi + "/" + idCountrie + "/subdivisions/"+subdivisio.Id), httpContent);

                    var PathSubdivisionResponse = await PatchSubdivisionRequest.Content.ReadAsStringAsync();

                    if (PatchSubdivisionRequest.IsSuccessStatusCode)
                    {
                        subdivisionObject.Message = "OK";
                        subdivisionObject.Result = 1;

                        return subdivisionObject;

                    }
                    else
                    {
                        subdivisionObject.Message = PathSubdivisionResponse;
                        subdivisionObject.Result = 1;
                    }
                }

                return subdivisionObject;
            }
            catch (Exception ex)
            {
                subdivisionObject.Message = ex.Message;
                subdivisionObject.Result = 0;

                return subdivisionObject;
            }
        }

        //PATCH
        //PATCH delete a subdivision
        public async Task<Reply> DeleteSubdivisiomAsync(int id, int idCountrie)
        {
            Reply subdivisionObject = new Reply();
            try
            {
                using (var client = new HttpClient())
                {
                    var DeletesubdivisionRequest = await client.DeleteAsync(UrlWebAppi + "/" + idCountrie +"/subdivisions/" + id);

                    var DeletesubdivisionResponse = await DeletesubdivisionRequest.Content.ReadAsStringAsync();

                    if (DeletesubdivisionRequest.IsSuccessStatusCode)
                    {
                        subdivisionObject.Message = "OK";
                        subdivisionObject.Result = 1;
                    }
                    else
                    {
                        subdivisionObject.Message = DeletesubdivisionResponse;
                        subdivisionObject.Result = 0;
                    }
                }
                return subdivisionObject;
            }
            catch (Exception ex)
            {
                subdivisionObject.Message = ex.Message;
                subdivisionObject.Result = 0;

                return subdivisionObject;
            }
        }

        //GET
        //GET  subdivision By id
        public async  Task<Reply> GetSubdivisiosAsync(int id)
        {
            try
            {
                Reply countriesObject = new Reply();
                try
                {
                    using (var client = new HttpClient())
                    {

                        var GetSubdivisionRequest = await client.GetAsync(UrlWebAppi + "/"+id+ "/subdivisions");

                        var GetSubdivisionResponse = await GetSubdivisionRequest.Content.ReadAsStringAsync();

                        if (GetSubdivisionRequest.IsSuccessStatusCode)
                        {

                            var result = JsonConvert.DeserializeObject<RootSubdivisions>(GetSubdivisionResponse);

                            if (result.data.Any())
                            {
                                countriesObject.Data = result.data.ToList();
                                countriesObject.Result = 1;
                                countriesObject.Message = "OK";

                            }

                            return countriesObject;
                        }
                        else
                        {
                            countriesObject.Message = GetSubdivisionResponse;
                            countriesObject.Result = 1;
                        }
                    }


                }
                catch (Exception ex)
                {
                    countriesObject.Message = ex.Message;
                    countriesObject.Result = 0;

                    return countriesObject;
                }

                return countriesObject;
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion Methods
    }
}