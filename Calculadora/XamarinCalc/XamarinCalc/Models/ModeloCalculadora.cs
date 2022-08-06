using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinCalc.Models
{
    public class ModeloCalculadora
    {

        public string digitado = "";
        public string[] especiais = { "x", "/", "+", "-" };
        public string pontuacao = ",";
        public int contador = 0;
        bool finalizadorNegativo = false;
        bool usouNegativo;
        int lastIndex, firstIndex;


        public string ComecaAlgoritimo(string recebido)
        {
            finalizadorNegativo = false;
            digitado = recebido;
            do
            {
                BuscaMultiDiv();
                if (finalizadorNegativo == true)
                    break;
            } while (digitado.Contains(especiais[0]) == true || digitado.Contains(especiais[1]) == true || digitado.Contains(especiais[2]) == true || digitado.Contains(especiais[3]) == true);
            return digitado;
        }

        private void BuscaMultiDiv()
        {
            if (digitado.Contains(especiais[0]) || digitado.Contains(especiais[1]))
            {
                //caso a multiplicacao vier primeiro que a divisao e o valor nao seja menos 1, ele rodara a multiplicacao primeiro, se nao, rodara a divisao
                int indexMulti = digitado.IndexOf(especiais[0]), indexDiv = digitado.IndexOf(especiais[1]);

                if ((indexMulti < indexDiv && indexMulti > -1) || indexDiv < 0)
                {
                    BuscaPm_Sm_(indexMulti);
                }
                else
                {
                    BuscaPm_Sm_(indexDiv);
                }

            }
            else if (digitado.Contains(especiais[2]) || digitado.Contains(especiais[3]))
            {
                int indexSoma = digitado.LastIndexOf(especiais[2]), indexSub = digitado.LastIndexOf(especiais[3]);

                if (indexSoma > indexSub && indexSoma > -1 || indexSub < 0)
                {
                    BuscaPm_Sm_(indexSoma);
                }
                else
                {
                    if (indexSub ==0)
                    {
                        finalizadorNegativo = true;
                        return;
                    }
                    BuscaPm_Sm_Sub(indexSub);
                }
            }
        }


        public double FazConta(double pm, char simbol, double sm)
        {
            double resultado = 0;
            switch (simbol)
            {
                case 'x':
                    resultado = pm * sm;
                    break;
                case '/':
                    resultado = pm / sm;
                    break;
                case '+':
                    resultado = pm + sm;
                    break;
                case '-':
                    resultado = pm - sm;
                    break;
                default:
                    break;
            }
            return resultado;
        }

        private double RetornaNumero(int indexSimboloPrincipal, bool sentidoReverso)
        {
            string numeroEncontrado = "";
            switch (sentidoReverso)
            {
                //busca o segundo numero: sm
                case false:
                    for (int i = indexSimboloPrincipal + 1; i < digitado.Length; i++)
                    {

                        if (digitado[i].ToString() == especiais[0] || digitado[i].ToString() == (especiais[1]) || 
                            digitado[i].ToString() == (especiais[2]) || digitado[i].ToString() == (especiais[3]))
                        {
                            break;
                        }
                        else
                        {
                            numeroEncontrado = numeroEncontrado + digitado[i].ToString();
                            lastIndex = i;
                        }
                    }

                    break;

                //busca o primeiro numero: pm
                default:
                    for (int i = indexSimboloPrincipal - 1; i > -1; i--)
                    {
                        if (digitado[i].ToString() == especiais[0] || digitado[i].ToString() == (especiais[1]) ||
                            digitado[i].ToString() == (especiais[2]) || digitado[i].ToString() == (especiais[3]))
                        {
                            break;
                        }
                        else
                        {
                            numeroEncontrado = digitado[i].ToString() + numeroEncontrado;
                            firstIndex = i;
                        }
                    }
                    break;
            }
            return Convert.ToDouble(numeroEncontrado);
        }

        public void BuscaPm_Sm_(int indexSimbolo)
         {
            bool foiApagado = false;
            double pm = RetornaNumero(indexSimbolo, true);
            if (firstIndex >0 && digitado[firstIndex-1] == '-')
            {
                digitado = digitado.Remove(firstIndex-1, 1);
                pm = pm * (-1);
                firstIndex -= 1;
                lastIndex -= 1;
                indexSimbolo -= 1;
                foiApagado = true;
            }
            double sm = RetornaNumero(indexSimbolo, false);
            double resultado = FazConta(pm, digitado[indexSimbolo], sm);
            //string troca = ($"{pm.ToString() + digitado[indexSimbolo] + sm.ToString()}");
            //string troca = digitado.Substring(firstIndex, lastIndex - firstIndex + 1);

            digitado = digitado.Remove(firstIndex, lastIndex - firstIndex + 1);
            digitado = digitado.Insert(firstIndex, $"{resultado.ToString()}");

            if (resultado >= 0 && foiApagado == true && firstIndex>0)
                digitado = digitado.Insert(firstIndex, "+");
            //digitado = digitado.Replace(troca, $"{resultado.ToString()}");
        }


        void NegativoNoInicio(string substrg)
        {
            digitado = substrg;
            while (digitado.Contains(especiais[2]) || digitado.Contains(especiais[3]))
            {
                int indexSoma = digitado.LastIndexOf(especiais[2]), indexSub = digitado.LastIndexOf(especiais[3]);

                if (indexSoma > indexSub && indexSoma > -1 || indexSub < 0)
                {
                    BuscaPm_Sm_Sub(indexSoma);
                }
                else
                {
                    BuscaPm_Sm_Sub(indexSub);
                }

                if (usouNegativo == true)
                    break;
            }
            if (usouNegativo == false)
                digitado.Insert(0, "-");
            finalizadorNegativo = true;

        }

        void BuscaPm_Sm_Sub(int indexSimbolo)
        {
            bool foiApagado = false;
            string troca;
            double pm = RetornaNumero(indexSimbolo, true);
            if(firstIndex>0 && digitado[firstIndex-1] == '-')
            {
                pm = pm * -1;
                digitado = digitado.Remove(firstIndex-1,1);

                firstIndex -= 1;
                lastIndex -= 1;
                indexSimbolo -= 1;
                foiApagado = true;
            }
            double sm = RetornaNumero(indexSimbolo, false);
            double resultado = FazConta(pm, digitado[indexSimbolo], sm);

            digitado = digitado.Remove(firstIndex, lastIndex - firstIndex + 1);
            digitado = digitado.Insert(firstIndex, $"{resultado.ToString()}");

            if (resultado >= 0 && foiApagado == true)
            {                
                    digitado = digitado.Insert(firstIndex, "+");
            }
        }
    }
}

