using FIAP.EdTech.API.Models.Enums;
using FIAP.EdTech.API.Models.Payloads;
using Newtonsoft.Json;

namespace FIAP.EdTech.API.Clients
{
    public class InvertextoClient
    {
        public async Task<IList<FeriadoResponse>> GetFeriadosNacionais(UF uf)
        {
            string token = Environment.GetEnvironmentVariable("INVERTEXTO_TOKEN")!;

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.invertexto.com/v1/holidays/2023?token={token}&state={uf}"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                return JsonConvert.DeserializeObject<IList<FeriadoResponse>>(body);
            }
        }
    }
}
