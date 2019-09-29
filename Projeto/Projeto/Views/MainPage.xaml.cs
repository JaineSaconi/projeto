using Projeto.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projeto
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void BtnCliente_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroCliente_View());
        }

        async private void btn_Avaliacao_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroAvalicao_View());
        }


        async private void btnResultado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Resultados_View());
        }
    }
}
