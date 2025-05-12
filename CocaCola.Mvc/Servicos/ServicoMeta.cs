using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using CocaCola.Mvc.Models.Entidades;
using CocaCola.Mvc.Models.Interfaces;

namespace CocaCola.Mvc.Servicos
{
    public class ServicoMeta : IServicoMeta
    {
        private readonly IConfiguration _configuration;
        private string WhatsAppApiUrl; 
        private string WhatsAppApiToken; 

        public ServicoMeta(IConfiguration configuration)
        {
            _configuration = configuration;
            WhatsAppApiUrl = _configuration.GetSection("Meta").GetValue<string>("ApiUrl") ?? "";
            WhatsAppApiToken = _configuration.GetSection("Meta").GetValue<string>("Token") ?? "";
        }

        public async Task<bool> EnviarFechamentoMensalASync(Contato contato, ArquivoMensal arquivo)
        {
            using(HttpClient client = new HttpClient()){
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WhatsAppApiToken); 
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                using StringContent jsonContent = new(
                    JsonSerializer.Serialize(new
                    {
                        messaging_product = "whatsapp",
                        recipient_type = "individual",
                        to = $"{contato.Telefone}",
                        type = "document",
                        document = new {
                            id = "123",
                            link = $"{arquivo.ArquivoPdf}", 
                            caption = "Fechamento Mensal",
                            filename = "Fechamento Mensal",
                            caption2 = "Fechamento Mensal"
                        }
                    }), Encoding.UTF8, "application/json");
                var jsonS = await jsonContent.ReadAsStringAsync();
                using (var response = await client.PostAsync(WhatsAppApiUrl, jsonContent))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            };
            return true;
        }

        public async Task<bool> EnviarSolitacaoAceiteContatoASync(Contato contato)
        {
            using(HttpClient client = new HttpClient()){
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WhatsAppApiToken); 
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                using StringContent jsonContent = new(
                    JsonSerializer.Serialize(new
                    {
                        messaging_product = "whatsapp",
                        recipient_type = "individual",
                        to= $"{contato.Telefone}",
                        type = "interactive",
                        interactive = new {
                            type = "cta_url",
                            header =  new {
                                text = "Aceite"
                            },
                            body = new {
                                text = "Clique aqui para aceitar receber os documentos."
                            },
                            footer = new {
                                text = "Aceite CocaCola"
                            },
                            action = new {
                                name = "cta_url",
                                parameters = new {
                                    display_text = "See Dates",
                                    url = "https://www.luckyshrub.com?clickID=kqDGWd24Q5TRwoEQTICY7W1JKoXvaZOXWAS7h1P76s0R7Paec4"
                                }
                            }
                        }
                    }), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(WhatsAppApiUrl, jsonContent))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            };
            return true;
        }

        public async Task<bool> EnviarTesteASync(Contato contato)
        {
            StringContent jsonContent = new (
                JsonSerializer.Serialize(
                    new 
                    {
                        messaging_product = "whatsapp",
                        to = "5511977515914",
                        type = "template", 
                        template = new {
                            name = "hello_world", 
                            language = new { 
                                code = "en_US" 
                            },
                        }
                    }), Encoding.UTF8, "application/json");
            using(HttpClient client = new HttpClient()){
                var request = new HttpRequestMessage() {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(WhatsAppApiUrl),
                    //Headers = {{"Authorization", $"Bearer {WhatsAppApiToken}"}},
                    Content = jsonContent
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WhatsAppApiToken); 
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                string recal = await request.Content.ReadAsStringAsync();
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                }
            };
            return true;
        }
    }
}