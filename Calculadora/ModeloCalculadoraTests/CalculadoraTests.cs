using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModeloCalculadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloCalculadora.Tests
{
    [TestClass()]
    public class CalculadoraTests
    {
        [TestMethod()]
        public void ComecaAlgoritimoTestMultiplicacao()
        {
            Calculadora calc = new();
            string retorno = calc.ComecaAlgoritimo("10*2");

            string esperado = "20";
            Assert.AreEqual(esperado, retorno);
        }
        [TestMethod]
        public void TestMultiplicaSoma()
        {
            Calculadora calc = new();
            string retorno = calc.ComecaAlgoritimo("5+10*2");

            string esperado = "25";
            Assert.AreEqual(esperado, retorno);
        }
    }
}