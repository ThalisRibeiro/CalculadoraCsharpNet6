using MvvmHelpers;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinCalc.Models;

namespace XamarinCalc.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand AdicionaNumeroComando { get; }
        public ICommand ExcluiUltimoComando { get; }
        public ICommand ExcluiTodasComando { get; }
        public ICommand AdicionaBotaoComando { get; }
        public ICommand ComecaCalcularComando { get; }

        public string Entrada { get => entrada; set => SetProperty(ref entrada, value); }
        string entrada;
        ModeloCalculadora calculadora;
        bool canUseSpecialButtons;
        public MainPageViewModel()
        {
            AdicionaNumeroComando = new Command<string>(AdicionaNumero);
            ExcluiUltimoComando = new Command(ExcluiUltimo);
            ExcluiTodasComando = new Command(ExcluiTodas);
            AdicionaBotaoComando = new Command<string>(AdicionaBotao);
            ComecaCalcularComando = new Command(ComecaCalcular);
            canUseSpecialButtons = false;
            calculadora = new ModeloCalculadora();
        }
        int ReturnLastIndex()
        {
            return Entrada.Length - 1;
        }

        void AdicionaBotao(string botao)
        {
            if (canUseSpecialButtons == false || Entrada.Length == 0)
                return;
            string lastIndex = entrada[ReturnLastIndex()].ToString();

            if (lastIndex.Contains(calculadora.especiais[0])|| lastIndex.Contains(calculadora.especiais[1])
                || lastIndex.Contains(calculadora.especiais[2])|| lastIndex.Contains(calculadora.especiais[3]) || lastIndex.Contains(calculadora.pontuacao))            
                entrada = entrada.Remove(ReturnLastIndex());
            Entrada += botao;
        }
        void AdicionaNumero(string botao)
        {
            canUseSpecialButtons = true;
            Entrada += botao;
        }
        void ExcluiUltimo()
        {
            if (canUseSpecialButtons == false || Entrada.Length == 0)
                return;
            Entrada = Entrada.Remove(Entrada.Length - 1);
        }
        void ExcluiTodas()
        {
            if (canUseSpecialButtons == false || Entrada.Length == 0)
                return;
            Entrada = Entrada.Remove(0);
        }
        void ComecaCalcular()
        {
            if (canUseSpecialButtons == false || Entrada.Length < 3)
                return;

            string lastIndex = entrada[ReturnLastIndex()].ToString();
            if (lastIndex.Contains(calculadora.especiais[0]) || lastIndex.Contains(calculadora.especiais[1])
                || lastIndex.Contains(calculadora.especiais[2]) || lastIndex.Contains(calculadora.especiais[3]) || lastIndex.Contains(calculadora.pontuacao))
                return;
                Entrada = calculadora.ComecaAlgoritimo(Entrada);
        }
    }
}

