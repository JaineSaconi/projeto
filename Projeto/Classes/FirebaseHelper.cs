using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Classes
{
    public class FirebaseHelper 
    {
        FirebaseClient fireBase = new FirebaseClient("https://projeto-4devs.firebaseio.com/");
        public async Task<List<Cliente>> GetAllCliente()
        {
            
            return (await fireBase.Child("Cliente").OnceAsync<Cliente>()).Select(item => new Cliente
            {
                Nome = item.Object.Nome,
                ClienteId = item.Object.ClienteId,
                DataCliente = item.Object.DataCliente,
                ResponsavelNome = item.Object.NotaCategoria,
                UltimaNota = item.Object.UltimaNota,
                NotaCategoria = item.Object.NotaCategoria
            }).ToList();

        }

        public async Task addCliente(long Id, string nome, string nomeRes, DateTime data, int nota)
        {
            string  categoria;
            
                if (nota >= 9)
                {
                    categoria =  "Promotor";
                }
                else if (nota == 7 || nota == 8)
                {
                categoria = "Neutro";
                }
                else if (nota <= 6)
                {
                categoria = "Detrator";
                }
                else
                categoria = null;
            
            await fireBase.Child("Cliente").PostAsync(new Cliente(){ ClienteId = Id, Nome = nome, ResponsavelNome = nomeRes,
                DataCliente = data, UltimaNota = nota, NotaCategoria = categoria });
        }

        public async Task<Cliente> GetClient(int clienteId)
        {
            var allCliente = await GetAllCliente();
            await fireBase.Child("CLiente").OnceAsync<Cliente>();

            return allCliente.Where(a => a.ClienteId == clienteId).FirstOrDefault();

        }
    }

   
}
