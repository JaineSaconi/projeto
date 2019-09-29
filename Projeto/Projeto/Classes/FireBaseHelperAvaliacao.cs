using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Classes
{
    class FireBaseHelperAvaliacao
    {
        FirebaseClient fireBase = new FirebaseClient("https://projeto-4devs.firebaseio.com/");

        public async Task addAvalicao(long Id, DateTime data, List<Cliente> CLientes)
        {

            await fireBase.Child("Avaliacao").PostAsync(new Avaliacao()
            {
                id = Id,
                Data = data,
                Clientes = CLientes
            });
           
        }
        public async Task<List<Avaliacao>> GetAllAvaliacao()
        {

            return (await fireBase.Child("Avaliacao").OnceAsync<Avaliacao>()).Select(item => new Avaliacao
            {
                id = item.Object.id,
                Data = item.Object.Data,
                Clientes = item.Object.Clientes
            }).ToList();

        }



        //public async Task<Cliente> GetClient(int clienteId)
        //{
        //    var allCliente = await GetAllCliente();
        //    await fireBase.Child("CLiente").OnceAsync<Cliente>();

        //    return allCliente.Where(a => a.ClienteId == clienteId).FirstOrDefault();

        //}
    }
}
