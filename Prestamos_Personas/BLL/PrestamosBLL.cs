using Prestamos_Personas.DAL;
using Prestamos_Personas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prestamos_Personas.BLL
{
    public class PrestamosBLL
    {
        public static bool Guardar(Prestamos Prestamo)
        {
            if (!Existe(Prestamo.PrestamosId))
                return Insertar(Prestamo);
            else
                return Modificar(Prestamo);
        }

        public static bool Insertar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (PersonasBLL.Buscar(prestamo.PersonaId) != null)
                {
                    var persona = PersonasBLL.Buscar(prestamo.PersonaId);
                    persona.Balance += prestamo.Monto;
                    PersonasBLL.Modificar(persona);
                }

                db.Prestamos.Add(prestamo);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Prestamos prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                if (PersonasBLL.Buscar(prestamo.PersonaId) != null)
                {
                    var persona = PersonasBLL.Buscar(prestamo.PersonaId);
                    persona.Balance = prestamo.Monto;
                    PersonasBLL.Modificar(persona);
                }

                db.Entry(prestamo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var prestamo = db.Prestamos.Find(id);

                if (prestamo != null)
                {
                    if (PersonasBLL.Buscar(prestamo.PersonaId) != null)
                    {
                        var persona = PersonasBLL.Buscar(prestamo.PersonaId);
                        persona.Balance -= prestamo.Monto;
                        PersonasBLL.Modificar(persona);
                    }
                    prestamo.Balance = prestamo.Monto;
                    db.Prestamos.Remove(prestamo);
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Prestamos Buscar(int id)
        {
            Prestamos persona = new Prestamos();
            Contexto db = new Contexto();

            try
            {
                persona = db.Prestamos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return persona;
        }

        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto db = new Contexto();

            try
            {
                encontrado = db.Prestamos.Any(p => p.PrestamosId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> Lista = new List<Prestamos>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Prestamos.Where(criterio).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }



    }
}
