using prueba.Models;
using Newtonsoft.Json;

namespace prueba.servicio
{
    public class UsuarioServicio
    {
        private readonly HttpClient _httpClient;

        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Usuario> ObtenerUsuarioDeUrl()
        {
            var response = await _httpClient.GetAsync("https://examentecnico.azurewebsites.net/v3/api/Test/Customer=Y2hyaXN0b3BoZXJAZGV2ZWxvcC5teDpUZXN0aW5nRGV2ZWxvcDEyM0AuLi4");
            response.EnsureSuccessStatusCode();

            var jsonData = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(jsonData);
            return usuario;
        }

    }
}
