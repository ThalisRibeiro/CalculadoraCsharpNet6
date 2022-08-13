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
        public ICommand AdicionaVirgulaComando { get; }
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
            AdicionaVirgulaComando = new Command<string>(AdicionaVirgula);
            ComecaCalcularComando = new Command(ComecaCalcular);
            canUseSpecialButtons = false;
            calculadora = new ModeloCalculadora();
        }
        int ReturnLastIndex()
        {
            return Entrada.Length - 1;
        }
        void AdicionaVirgula(string botao)
        {

            if (canUseSpecialButtons == false || Entrada.Length == 0)
                return;

            if (CanUseVirgula() == false)
                return;
            string lastIndex = entrada[ReturnLastIndex()].ToString();
            if (VerificaEspeciais(lastIndex))
            return;
            Entrada += botao;

        }
        void AdicionaBotao(string botao)
        {
            if (canUseSpecialButtons == false || Entrada.Length == 0)
                return;
            string lastIndex = entrada[ReturnLastIndex()].ToString();

            if (VerificaEspeciais(lastIndex))
                entrada = entrada.Remove(ReturnLastIndex());
            Entrada += botao;
        }


        bool VerificaEspeciais(string lastIndex)
        {
            if (lastIndex.Contains(calculadora.especiais[0]) || lastIndex.Contains(calculadora.especiais[1])|| lastIndex.Contains(calculadora.especiais[2]) || 
                lastIndex.Contains(calculadora.especiais[3]) || lastIndex.Contains(calculadora.pontuacao) || lastIndex.Contains("%"))
                return true;
            return false;
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
            if (VerificaEspeciais(lastIndex))
                return;
                Entrada = calculadora.ComecaAlgoritimo(Entrada);
        }
        bool CanUseVirgula()
        {
            if (entrada.Contains(",") == false)
            {
                //Entrada += ",";
                return true;
            }
            var lastVirgula = entrada.LastIndexOf(",");
            var sub = entrada.Substring(lastVirgula);
            if (sub.Contains(calculadora.especiais[0]) || sub.Contains(calculadora.especiais[1])
                || sub.Contains(calculadora.especiais[2]) || sub.Contains(calculadora.especiais[3]))
                return true;
            return false;
        }
    }
}

