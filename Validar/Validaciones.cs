using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos;

namespace Validar
{
    public class Validaciones
    {
        Conexion con = new Conexion();
     
        public List<EntPersona> Mostrar()
        {
            try
            {
                List<EntPersona> Lista = new List<EntPersona>();
                DataTable Tabla = con.Mostrar();

                foreach (DataRow val in Tabla.Rows)
                {
                    EntPersona p = new EntPersona();

                    p.Id = Convert.ToInt32(val["Id"]);
                    p.Nombre = val["Nombre"].ToString();
                    p.Nacionalidad = val["Nacionalidad"].ToString();
                    p.Fecha = Convert.ToDateTime(val["Fecha"]);

                    Lista.Add(p);
                }

                return Lista;
            }
            catch (Exception)
            {
                return new List<EntPersona>();
            }           
        }


        public EntPersona BuscarById(int Id)
        {
            try
            {
                DataTable Tabla = con.BuscarById(Id);
                EntPersona p = new EntPersona();
                foreach (DataRow val in Tabla.Rows)
                {
                    p.Id = Convert.ToInt32(val["Id"]);
                    p.Nombre = val["Nombre"].ToString();
                    p.Nacionalidad = val["Nacionalidad"].ToString();
                    p.Fecha = Convert.ToDateTime(val["Fecha"]);
                    string fecha = p.Fecha.ToString().Substring(0, 10);
                    p.FechaString = fecha;
                }

                return p;
            }
            catch (Exception)
            {
                return new EntPersona();
            }
        }

        public string Insertar(EntPersona p)
        {
            try
            {
                int FilasAfectadas = con.Insertar(p.Nombre,p.Nacionalidad,p.Fecha);
                if (FilasAfectadas!=1)
                {
                    return "Error al Insertar";
                }

                return "Insertado Correctamente";
            }
            catch (Exception)
            {

                return "Error al Insertar";
            }
        }

        public string Editar(EntPersona p)
        {
            try
            {
                int FilasAfectadas = con.Editar(p.Id,p.Nombre, p.Nacionalidad, p.Fecha);
                if (FilasAfectadas != 1)
                {
                    return "Error al Editar";
                }

                return "Editado Correctamente";
            }
            catch (Exception)
            {

                return "Error al Editar";
            }
        }

        public string Eliminar(EntPersona p)
        {
            try
            {
                int FilasAfectadas = con.Eliminar(p.Id);
                if (FilasAfectadas != 1)
                {
                    return "Error al Eliminar";
                }

                return "Eliminado Correctamente";
            }
            catch (Exception)
            {

                return "Error al Eliminar";
            }
        }
    }
}
