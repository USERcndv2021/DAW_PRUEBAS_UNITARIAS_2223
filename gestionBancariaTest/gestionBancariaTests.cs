using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionBancariaAppNS;
using System;
namespace gestionBancariaTest
{
    [TestClass]
    public class gestionBancariaTests
    {
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
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001,
            "Se produjo un error al realizar el reintegro, saldo" +
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
            double actual = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actual, "El balance de la cuenta es correcto");
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
            double actual = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actual, "El balance de la cuenta es correcto");
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
            double actual = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actual, "El balance de la cuenta es correcto");
        }


        [TestMethod]
        public void reintegroLimiteAl_Saldo3()
        {
            //arrange
            double saldoInicial = 1000;
            double reintegro = 500;
            double saldoEsperado = 500;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            //act
            miApp.realizarReintegro(reintegro);
            //assert
            double actual = miApp.obtenerSaldo();
            Assert.AreEqual(saldoEsperado, actual, "El balance de la cuenta es correcto");

        }

        //Pruebas que esperan excepciones

        //Reintegro < 0
        [TestMethod]
        public void validarReintegroCantidadNoValida()
        {
            double saldoInicial = 1000;
            double reintegro = -250;
            double saldoFinal = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarReintegro(reintegro);
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
            double reintegro = 1250;
            double saldoFinal = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarReintegro(reintegro);
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
            double reintegro = 0;
            double saldoFinal = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarReintegro(reintegro);
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

        //Ingreso < saldo
        [TestMethod]
        public void ValidarIngreso()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 250;
            double saldoEsperado = 1250;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarIngreso(ingreso);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo());
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
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo());
        }

        

        //Pruebas que esperan excepciones

        //ingreso < 0
        [TestMethod]
        public void ingresoCantidadNoValida()
        {
            double saldoInicial = 1000;
            double ingreso = -250;
            double saldoFinal = saldoInicial + ingreso;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarIngreso(ingreso);
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
            double ingreso = 0;
            double saldoFinal = saldoInicial + ingreso;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.realizarIngreso(ingreso);
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
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo());
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
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo());
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
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo());
        }


        //Probando todos los valores
        [TestMethod]
        public void RootedValueRange() 
        {
            double saldoInicial = 1000;
            double reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            for (reintegro = 0; reintegro < 1000; reintegro++)
            {
                RootedValue(miApp, reintegro);
            }

        }

        public void RootedValue(GestionBancariaApp miApp, double cantidad)
        {
            if (cantidad > miApp.obtenerSaldo())

                throw new Exception("La cantidad " + cantidad + " no es correcta");

        }








    }
}
