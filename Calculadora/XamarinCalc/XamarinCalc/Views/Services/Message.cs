using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinCalc.Views.Services
{
    public class Message : ViewModels.Services.IMessage
    {
        public async Task MostraMensagemErro(string mensagem)
        {
            await XamarinCalc.App.Current.MainPage.DisplayAlert("ERRO", mensagem, "OK");
        }
    }
}
