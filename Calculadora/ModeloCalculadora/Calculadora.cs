namespace ModeloCalculadora
{
    public class Calculadora

    {

        public string digitado="";
        public char[] especiais = { '*', '/', '+', '-' };
        public char pontuacao = '.';
        public int contador = 0;

        public string ComecaAlgoritimo(string recebido)
        {
            digitado = recebido;
            do{
            BuscaMultiDiv();
            } while (digitado.Contains(especiais[0]) == true || digitado.Contains(especiais[1]) == true || digitado.Contains(especiais[2]) == true || digitado.Contains(especiais[3]) == true);
            return digitado;
        }

        private void BuscaMultiDiv()
        {
            if (digitado.Contains(especiais[0]) || digitado.Contains(especiais[1]))
            {
                //caso a multiplicacao vier primeiro que a divisao e o valor nao seja menos 1, ele rodara a multiplicacao primeiro, se nao, rodara a divisao
                int indexMulti = digitado.IndexOf(especiais[0]), indexDiv = digitado.IndexOf(especiais[1]);

                if ((indexMulti < indexDiv && indexMulti > -1 ) || indexDiv <0)
                {
                    BuscaPm_Sm_(indexMulti);
                }
                else if (indexDiv < indexMulti && indexDiv > -1)
                {
                    BuscaPm_Sm_(indexDiv);
                }

            }
            else if (digitado.Contains(especiais[2]) || digitado.Contains(especiais[3]))
            {
                int indexSoma = digitado.IndexOf(especiais[2]), indexSub = digitado.IndexOf(especiais[3]);

                if (indexSoma < indexSub && indexSoma > -1 || indexSub < 0)
                {
                    BuscaPm_Sm_(indexSoma);
                }
                else
                {
                    BuscaPm_Sm_(indexSub);
                }
            }
        }


        public double FazConta(double pm, char simbol, double sm)
        {
            double resultado = 0;
            switch (simbol)
            {
                case '*':
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

                        if (digitado[i].Equals(especiais[0]) || digitado[i].Equals(especiais[1]) || digitado[i].Equals(especiais[2]) || digitado[i].Equals(especiais[3]))
                        {
                            break;
                        }
                        else
                        {
                            numeroEncontrado = numeroEncontrado + digitado[i].ToString();
                        }
                    }

                    break;

                //busca o primeiro numero: pm
                default:
                    for (int i = indexSimboloPrincipal - 1; i > -1; i--)
                    {
                        if (digitado[i].Equals(especiais[0]) || digitado[i].Equals(especiais[1]) || digitado[i].Equals(especiais[2]) || digitado[i].Equals(especiais[3]))
                        {
                            break;
                        }
                        else
                        {
                            numeroEncontrado = digitado[i].ToString() + numeroEncontrado;
                        }
                    }
                    break;
            }
            return Convert.ToDouble(numeroEncontrado);
        }

        public void BuscaPm_Sm_(int indexSimbolo)
        {
            double pm = RetornaNumero(indexSimbolo, true);
            double sm = RetornaNumero(indexSimbolo, false);
            double resultado = FazConta(pm, digitado[indexSimbolo], sm);
            string troca = ($"{pm.ToString() + digitado[indexSimbolo] + sm.ToString()}");

            digitado =digitado.Replace(troca, $"{resultado.ToString()}");
        }
    }
}
