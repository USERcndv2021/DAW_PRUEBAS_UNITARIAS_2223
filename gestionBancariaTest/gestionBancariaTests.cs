using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionBancariaAppNS;
using System;
namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTests
    {   //Equivalencias
        //Reintegro < saldo
        [TestMethod]
        public void ValidarReintegro()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 250;
            double saldoEsperado = 750;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarReintegro(reintegro);
            double actualCNDV = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado,actualCNDV , 0.001, "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }
        
        //Reintegro == saldo
        [TestMethod]//
        public void reintegroIgual_Al_saldo()
        {
            //arrange
            double saldoInicial = 1000;
            double reintegro = 1000;
            double saldoEsperado = 0;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //act
            miApp.realizarReintegro(reintegro);

            //assert
            double actualCNDV = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actualCNDV, 0.001, "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }

        //Probando valores límites 
        [TestMethod]
        public void reintegroLimite_Al_Saldo()
        {
            //arrange
            double saldoInicial = 1000;
            double reintegro = 999;
            double saldoEsperado = 1.00;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //act
            miApp.realizarReintegro(reintegro);

            //assert
            double actualCNDV = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actualCNDV, 0.001, "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }

        
        [TestMethod]
        public void reintegroLimiteAl_Saldo2()
        {
            //arrange
            double saldoInicial = 1000;
            double reintegro = 1.00;
            double saldoEsperado = 999;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //act
            miApp.realizarReintegro(reintegro);

            //assert
            double actualCNDV = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actualCNDV, 0.001, "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }


        [TestMethod]
        public void reintegroLimite_Al_Saldo3()
        {
            //arrange
            double saldoInicial = 1000;
            double reintegro = 500;
            double saldoEsperado = 500;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //act
            miApp.realizarReintegro(reintegro);
            //assert
            double actualCNDV = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actualCNDV, 0.001, "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");

        }

        //Pruebas que esperan excepciones

        //Reintegro < 0
        [TestMethod]
        public void validarReintegroCantidadNoValida()
        {
            double saldoInicial = 1000;
            double reintegroCNDV = -250;
            double saldoFinal = saldoInicial - reintegroCNDV;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarReintegro(reintegroCNDV);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // assert
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }


        //Reintegro > saldo
        [TestMethod]
        public void validarReintegroCantidadMayor_A_saldo()
        {
            double saldoInicial = 1000;
            double reintegroCNDV = 1250;
            double saldoFinal = saldoInicial - reintegroCNDV;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarReintegro(reintegroCNDV);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }



        //Reintegro == 0
        [TestMethod]
        public void validarReintegroCantidadIgual_Cero()
        {
            double saldoInicial = 1000;
            double reintegroCNDV = 0;
            double saldoFinal = saldoInicial - reintegroCNDV;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarReintegro(reintegroCNDV);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // assert
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");


        }

        //-------------///----------------//////--------------------//////------------------///////------------------------///
        //Equivalencias
        //Ingreso < saldo
        [TestMethod]
        public void ValidarIngresoMenorSaldo()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 250;
            double saldoEsperado = 1250;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarIngreso(ingreso);
            //assert
            double actualCNDV = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actualCNDV, 0.001, "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");

        }

        // Ingreso >= saldo 
        [TestMethod]
        public void ingresoSuperiorIgual_Al_Saldo()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 1250;
            double saldoEsperado = 2250;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarIngreso(ingreso);
            //assert
            double actualCNDV = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actualCNDV, 0.001, "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }


        //Pruebas que esperan excepciones

        //ingreso < 0
        [TestMethod]
        public void ingresoCantidadNoValida()
        {
            double saldoInicial = 1000;
            double ingresoCNDV = -250;
            double saldoFinal = saldoInicial + ingresoCNDV;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarIngreso(ingresoCNDV);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // assert
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");

            
        }

        //Ingreso == 0
        [TestMethod]
        public void ingresoIgual_A_Cero()
        {
            double saldoInicial = 1000;
            double ingresoCNDV = 0;
            double saldoFinal = saldoInicial + ingresoCNDV;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.realizarIngreso(ingresoCNDV);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // assert
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }


        //Probando valores límites
        [TestMethod]
        public void ingresosConValoresLimites()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 1.00;
            double saldoEsperado = 1001;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarIngreso(ingreso);
            //assert
            double actualCNDV = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actualCNDV, 0.001, "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }

        [TestMethod]
        public void ingresosConValoresLimites2()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 500;
            double saldoEsperado = 1500;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarIngreso(ingreso);
            //assert
            double actualCNDV = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actualCNDV, 0.001, "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }

        [TestMethod]
        public void ingresosConValoresLimites3()//Consultar
        {
            // preparación del caso de prueba
            double saldoInicial = 1000; 
            double ingreso = double.MaxValue;
            double saldoEsperado = double.MaxValue;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarIngreso(ingreso);
            //assert
            double actualCNDV = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actualCNDV, 0.001, "Se produjo un error al realizar el reintegro, saldo" +
            "incorrecto.");
        }


        //Probando todos los valores
        [TestMethod]
        public void RootedValueRangeCNDV() 
        {
            double saldoInicial = 1000;
            double reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            for (reintegro = 0; reintegro < 1000; reintegro++)
            {
                RootedValueCNDV(miApp, reintegro);
            }

        }

        public void RootedValueCNDV(GestionBancariaApp miApp, double cantidad)
        {
            if (cantidad > miApp.obtenerSaldo())

                throw new Exception("La cantidad " + cantidad + " no es correcta");

        }



    }
}
