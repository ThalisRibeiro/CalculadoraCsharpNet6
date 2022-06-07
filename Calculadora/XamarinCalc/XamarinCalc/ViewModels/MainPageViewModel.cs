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


        public MainPageViewModel()
        {
            AdicionaNumeroComando = new Command<string>(AdicionaNumero);
            ExcluiUltimoComando = new Command(ExcluiUltimo);
            ExcluiTodasComando = new Command(ExcluiTodas);
        }

        void AdicionaNumero(string botao)
        {
            Entrada+=botao;
        }
        void ExcluiUltimo()
        {
            Entrada = Entrada.Remove(Entrada.Length-1);
        }
        void ExcluiTodas()
        {
            Entrada = Entrada.Remove(0);
        }
    }
}
 
