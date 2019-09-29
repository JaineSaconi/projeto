using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Classes
{
    public class APIConnect
    {
        HttpClient client = new HttpClient();
        public void Conectar()
        {
            client.DefaultRequestHeaders.Add("Authorization", "projeto-4devs");

            client.BaseAddress = new Uri("http://desafio4devs.forlogic.net/api/");
        }

        public async Task<List<Cliente>> GetAllCliente()
        {
            client.DefaultRequestHeaders.Add("Authorization", "projeto-4devs");
            try
            {
                string url = "http://desafio4devs.forlogic.net/api/customers";
                var response = await client.GetStringAsync(url);
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(response);
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            client.DefaultRequestHeaders.Add("Authorization", "projeto-4devs");
            try
            {
                string url = "http://desafio4devs.forlogic.net/api/customers";
                var uri = new Uri(string.Format(url, cliente.ClienteId));
                var data = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir cliente");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
