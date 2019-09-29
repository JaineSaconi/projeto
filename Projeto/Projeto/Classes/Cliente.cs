using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms.MultiSelectListView;

namespace Projeto.Classes
{
   
    public class Cliente
    {
        public long ClienteId { get; set; }

        public string Nome { get; set; }

        public string ResponsavelNome { get; set; }
        public DateTime DataCliente { get; set; }
        public int UltimaNota { get; set; }   
        public string NotaCategoria { get; set; }

    }
    
}
