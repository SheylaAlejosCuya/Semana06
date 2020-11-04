







using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
    public class BCategoria
    {
        private DCategoria DCategoria = null;

        public List<Categoria> Listar(int IdCategoria)
        {
            List<Categoria> categorias = null;
            try
            {
                DCategoria = new DCategoria();
                categorias = DCategoria.Listar(new Categoria { IdCategoria = IdCategoria });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categorias;
        }
        public bool Insertar(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Insertar(categoria);
            } catch (Exception ex)
            {
                //escribir en el log
                result = false;
            }
            return result;
        }
        public bool Actualizar(Categoria categoria)
        {
            bool result = true;
            try
            {
                DCategoria = new DCategoria();
                DCategoria.Actualizar(categoria);
            } catch (Exception ex) { 
            result = false;
            }
            //en el log
            return result;

        }
        public bool Elimimar(int IdCategoria)
        {
            bool result = true;
            try {
                DCategoria = new DCategoria();
                DCategoria.Eliminar(IdCategoria);

            } catch (Exception ex)
            {

                result = false;
            }
            return result;
        }
    }
}
