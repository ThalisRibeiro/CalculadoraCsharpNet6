using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCalc.Models;

namespace XamarinCalc.ViewModels
{
    public class MainPageViewModel: BaseViewModel
    {
        public ICommand AdicionaNumeroComando { get; }
        public ICommand ExcluiUltimoComando { get; }
        public ICommand ExcluiTodasComando { get; }

        public string Entrada { get => entrada; set => SetProperty(ref entrada, value); }
        string entrada;
        ModeloCalculadora calculadora;
        bool canUseSpecialButtons;
        public MainPageViewModel()
        {
            AdicionaNumeroComando = new Command<string>(AdicionaNumero);
            ExcluiUltimoComando = new Command(ExcluiUltimo);
            ExcluiTodasComando = new Command(ExcluiTodas);
            canUseSpecialButtons = false;
        }

        void AdicionaNumero(string botao)
        {
            canUseSpecialButtons = true;
            Entrada+=botao;
        }
        void ExcluiUltimo()
        {
            if (canUseSpecialButtons == false || Entrada.Length == 0 )
                return;
            Entrada = Entrada.Remove(Entrada.Length-1);
        }
        void ExcluiTodas()
        {
            if (canUseSpecialButtons == false || Entrada.Length == 0)
                return;
            Entrada = Entrada.Remove(0);
        }
    }
}
 
