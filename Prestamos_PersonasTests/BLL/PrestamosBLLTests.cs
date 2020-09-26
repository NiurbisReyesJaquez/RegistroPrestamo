using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prestamos_Personas.BLL;
using Prestamos_Personas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamos_Personas.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Prestamos Prestamo = new Prestamos();

            Prestamo.PrestamosId = 0;
            Prestamo.Fecha = DateTime.Now;
            Prestamo.PersonaId = 1;
            Prestamo.Concepto = "Compra de Carro";
            Prestamo.Monto = 60000;
            Prestamo.Balance = 0;

            paso = PrestamosBLL.Guardar(Prestamo);
            Assert.AreEqual(paso, true);
        }

       

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Prestamos Prestamo = new Prestamos();

            Prestamo.PrestamosId = 1;
            Prestamo.Fecha = DateTime.Now;
            Prestamo.PersonaId = 1;
            Prestamo.Concepto = "Compra de Carro";
            Prestamo.Monto = 90000;
            Prestamo.Balance = 0;

            paso = PrestamosBLL.Modificar(Prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = PrestamosBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Prestamos prestamo = PrestamosBLL.Buscar(1);
            bool paso = false;

            if (prestamo != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = PrestamosBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

        

        [TestMethod()]
        public void GuardarBalanceTest()
        {
            Prestamos prestamo = new Prestamos();
            bool paso = false;

            prestamo.PrestamosId = 1;
            prestamo.PersonaId = 1;
            prestamo.Balance = 600;

            PrestamosBLL.Guardar(prestamo);

            Personas persona = PersonasBLL.Buscar(1);

            if (persona.Balance == prestamo.Balance)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarBalanceTest()
        {
            Prestamos prestamo = new Prestamos();
            bool paso = false;

            prestamo.PrestamosId = 1;
            prestamo.PersonaId = 1;
            prestamo.Balance = 500;

            PrestamosBLL.Modificar(prestamo);

            Personas persona = PersonasBLL.Buscar(1);

            if (persona.Balance == prestamo.Balance)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarBalanceTest()
        {
            Prestamos prestamo = new Prestamos();
            Personas persona = PersonasBLL.Buscar(1);
            bool paso = false;

            PrestamosBLL.Eliminar(1);

            if (persona.Balance == prestamo.Balance)
                paso = true;

            Assert.AreEqual(paso, true);
        }


    }
}