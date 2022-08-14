using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinCalc.ViewModels.Services
{
    public interface IMessage
    {
        Task MostraMensagemErro(string mensagem);
    }
}
