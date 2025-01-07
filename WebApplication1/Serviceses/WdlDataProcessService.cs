using Azure;
using System;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Serviceses
{
    public class WdlDataProcessService : IWdldataprocessingService
    {
        private readonly HttpClient _httpClient;

        public WdlDataProcessService(HttpClient httpClient)
        {
     
            _httpClient = httpClient;
        }
        public async Task<bool> WdldataprocessInterface(List<WdlcompleteDataEntity> wdlcompleteDataEntities)
        {
            try
            {
                string url = "https://localhost:44352/api/learningDataInfo/WdlComputeddata";


                var response = await _httpClient.PostAsJsonAsync(url, wdlcompleteDataEntities);
               
                // Ensure the response is successful
                response.EnsureSuccessStatusCode();

                // Read the response content
                var result = await response.Content.ReadFromJsonAsync<bool>();
                return result;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
