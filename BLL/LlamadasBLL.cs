using _2doParcial.DAL;
using _2doParcial.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _2doParcial.BLL
{
    public class LlamadasBLL
    {
        public static bool Guardar(Llamadas llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Llamadas.Add(llamada) != null)
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

        public static bool Modificar(Llamadas llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM LlamadasDetalle where id = {llamada.LlamadaId}");
                foreach (var item in llamada.Detalles)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(llamada).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);

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
                var eliminar = db.Llamadas.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
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

        public static Llamadas Buscar(int id)
        {
           Llamadas llamadas = new Llamadas();
            Contexto db = new Contexto();

            try
            {
                llamadas = db.Llamadas.Where(x => x.LlamadaId == id).
                     Include(y => y.Detalles).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return llamadas;
        }

        public static List<Llamadas> GetList(Expression<Func<Llamadas, bool>> llamada)
        {
            List<Llamadas> lista = new List<Llamadas>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Llamadas.Where(llamada).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}
