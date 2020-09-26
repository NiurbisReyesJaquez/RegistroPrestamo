using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prestamos_Personas.BLL;
using Prestamos_Personas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestamos_Personas.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Personas persona = new Personas();
            bool paso = false;

            persona.PersonaId = 0;
            persona.Nombre = "Niurbis";
            persona.Telefono = "8098789505";
            persona.Cedula = "40115115201";
            persona.Direccion = "SFM";
            persona.FechaNacimiento = DateTime.Now;

            paso = PersonasBLL.Guardar(persona);
            Assert.AreEqual(paso, true);
        }

       
        public void ModificarTest()
        {
            Personas persona = new Personas();
            bool paso = false;

            persona.Nombre = "Niurbis";
            persona.Telefono = "8098789505";
            persona.Cedula = "40115115201";
            persona.Direccion = "SFM";
            persona.FechaNacimiento = DateTime.Now;

            paso = PersonasBLL.Modificar(persona);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = PersonasBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            bool paso = false;
            Personas persona = PersonasBLL.Buscar(1);

            if (persona != null)
                paso = true;
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool paso = false;
            paso = PersonasBLL.Existe(1);
            Assert.AreEqual(paso, true);
        }

       
    }
}