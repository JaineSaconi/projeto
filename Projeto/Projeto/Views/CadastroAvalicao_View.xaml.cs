using Projeto.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroAvalicao_View : ContentPage
    {
        private FirebaseHelper firebaseHelper = new FirebaseHelper();
        private FireBaseHelperAvaliacao firebaseHelperAvaliacao = new FireBaseHelperAvaliacao();
        List<Cliente> cliente;
        Avaliacao avaliacao;
        public CadastroAvalicao_View()
        {
            InitializeComponent();

            DataAvaliacao.Text = (DateTime.Now).ToString();
            cliente = new List<Cliente>();
            avaliacao = new Avaliacao();
            avaliacao.Clientes = new List<Cliente>();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            cliente = await firebaseHelper.GetAllCliente();

            ListCliente.ItemsSource = cliente;
            DateTime data = Convert.ToDateTime(DataAvaliacao.Text);

        }


        async private void Handle_Clicked(object sender, EventArgs e)
        {

            Cliente cli = new Cliente();
            var btn = (Xamarin.Forms.Button)sender;

            var item = (Cliente)btn.CommandParameter;
            cli.ClienteId = item.ClienteId;
            cli.DataCliente = item.DataCliente;
            cli.Nome = item.Nome;
            cli.NotaCategoria = item.NotaCategoria;
            cli.UltimaNota = item.UltimaNota;


            await DisplayAlert("Aviso", "Cliente adicionado", "OK");
        }

        async private void btncadastrar_clicked(object sender, EventArgs e)
        {
            List<Avaliacao> ava = new List<Avaliacao>();
            ava = await firebaseHelperAvaliacao.GetAllAvaliacao();
            DateTime data = Convert.ToDateTime(DataAvaliacao.Text);

            long id = DateTime.Now.Ticks;

            foreach (var item in ava)
            {
                if (data.Month == item.Data.Month)
                {
                    await DisplayAlert("Aviso", "Avaliação ja realizada esse mes", "OK");
                    await Navigation.PushAsync(new MainPage());
                    
                }
            }
            if (data == null)
            {
                await DisplayAlert("Aviso", "Data obrigatória", "OK");

            }

            else if (avaliacao.Clientes == null)
            {
                await DisplayAlert("Aviso", "Clientes obrigatórios", "OK");

            }
            else
            {
                await firebaseHelperAvaliacao.addAvalicao(id, data, avaliacao.Clientes);
                await DisplayAlert("Aviso", "Avaliação adicionado", "OK");
            }

        }
    }
}