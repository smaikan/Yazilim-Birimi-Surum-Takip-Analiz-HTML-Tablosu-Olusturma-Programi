using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proje.Models;

namespace Proje
{
    public class APIService
    {
        private readonly HttpClient _client;

        public APIService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:1881/")
            };
        }

        public async Task<List<SourceModel>> GetAllAPIsAsync()
        {
            try
            {
                var response = await _client.GetAsync("api/data");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<SourceModel>>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API'den veri alınamadı.\n\n" + ex.Message);
            }

            return new List<SourceModel>(); 
        }

        public async Task<bool> AddAPIAsync(SourceModel model)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("api/data", model);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("API'ye bağlanılamadı. Veri ekleme işlemi başarısız");
                return false;
            }
        }

        public async Task<bool> DeleteAPIAsync(int id)
        {
            try
            {
                var response = await _client.DeleteAsync($"api/data/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi başarısız: ");
                return false;
            }
        }

        public async Task<bool> ClearAPIAsync()
        {
            try
            {
                var response = await _client.DeleteAsync("api/data/clear");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("API verilerini temizleme başarısız: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAPIAsync(SourceModel model)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"api/data/{model.Id}", model);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme işlemi başarısız: " + ex.Message);
                return false;
            }
        }

        public async Task<int> GetCountAsync()
        {
            try
            {
                var response = await _client.GetAsync("api/data/count");
                if (response.IsSuccessStatusCode)
                {
                    var count = await response.Content.ReadFromJsonAsync<int>();
                    return count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API bağlantısı kurulamadı. Lütfen API'nin çalıştığından emin olun.\n\n" + ex.Message);
            }

            return 0;
        }
    }
}
