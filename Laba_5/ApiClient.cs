using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Laba_5;


namespace Laba_5
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.chucknorris.io/jokes";

        public ApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ApiResponse<string>> GetJokes()
        {
            var response = new ApiResponse<string>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/random");
                var result = await _httpClient.SendAsync(request);

                response.StatusCode = (int)result.StatusCode;
                response.Message = result.IsSuccessStatusCode ? "Success" : "Error";
                if (result.IsSuccessStatusCode)
                {
                    var joke = await result.Content.ReadAsStringAsync();
                    response.Data = new List<string> { joke };
                }
            }
            catch (Exception e)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ApiResponse<string>> SearchJokes(string query)
        {
            var response = new ApiResponse<string>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/search?query={query}");
                var result = await _httpClient.SendAsync(request);

                response.StatusCode = (int)result.StatusCode;
                response.Message = result.IsSuccessStatusCode ? "Success" : "Error";
                if (result.IsSuccessStatusCode)
                {
                    var joke = await result.Content.ReadAsStringAsync();
                    response.Data = new List<string> { joke };
                }
            }
            catch (Exception e)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
