# Calculadora DotNet
Um pequeno projeto que implementa c# e xamarin.forms.

# Operações
Ela aceita todas as quatro operações, podendo usar tanto números inteiros como quebrados, além de estar preparada para lidar também com números negativos.
## Como funciona
### view/viewmodel
Com relação a view e viewmodel, ela possui alguns verificadores para que não haja erro no programa.
Por exemplo, ele só irá começar uma operação caso haja números o suficiente.
Outros verificadores estão relacionados com a vírgula, que verifica qual a ultima vírgula usada e se foi no ultimo número, caso o ultimo número já tenha uma vírgula, o algoritmo não irá adicionar outra.
### model
É na model que está todo o algoritmo da calculadora, ele começa.
Ele roda num loop do while tiver alguma operação a ser feita.
Caso tenha operações ele verifica primeiro as de multiplicação e divisão e faz a que vier primeiro
Caso não haja essas operações, ele busca as de soma e multiplicação
Essa ele faz a que vier por ultimo até chegar na primeira