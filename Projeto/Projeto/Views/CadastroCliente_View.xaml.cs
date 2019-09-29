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
    
    public partial class CadastroCliente_View : ContentPage
    {
        private FirebaseHelper firebaseHelper = new FirebaseHelper();
        public CadastroCliente_View()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();           
        }

        async private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            long id = DateTime.Now.Ticks;
            DateTime data = Convert.ToDateTime(entData.Text);
            int nota = Convert.ToInt32(entNota.Text);

            if (entNome.Text == null || entData.Text == null || entResNome.Text == null)
            {
                await DisplayAlert("Aviso", "Campo não pode ser nulo", "OK");
            }
            else
            {
                await firebaseHelper.addCliente(id, entNome.Text, entResNome.Text, data, nota);
                entNome.Text = string.Empty;
                entData.Text = string.Empty;
                entNota.Text = string.Empty;
                entResNome.Text = string.Empty;
                await DisplayAlert("Aviso", "Cliente cadastrado com sucesso", "OK");
            }
        }
    }
}