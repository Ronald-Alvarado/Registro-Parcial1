using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Parcial1Proyecto.DAL;
using Parcial1Proyecto.Entidades;

namespace Parcial1Proyecto.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Articulos.Add(articulos) != null)
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

        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(articulos).State = EntityState.Modified;
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

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Articulos.Find(Id);
                db.Entry(eliminar).State = EntityState.Deleted;
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

        public static Articulos Buscar(int Id)
        {
            Articulos articulos = new Articulos();
            Contexto db = new Contexto();

            try
            {
                articulos = db.Articulos.Find(Id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return articulos;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos,bool>> articulos)
        {
            List<Articulos> lista = new List<Articulos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Articulos.Where(articulos).ToList();
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
