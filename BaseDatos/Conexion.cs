using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos
{
    public class Conexion
    {
        private SqlConnection con = new SqlConnection("Server=.;DataBase=Curso;User Id=sa;Password=12345");

        public void Conectar()
        {
            con.Open();
        }

        public void Desconectar()
        {
            con.Close();
        }

        public DataTable Mostrar()
        {
            try
            {
                Conectar();
                DataTable Tabla = new DataTable();
                string Query = "SELECT * FROM Persona ORDER BY Id ASC";
                SqlDataAdapter GuardarInfo = new SqlDataAdapter(Query, con);
                GuardarInfo.Fill(Tabla);
                Desconectar();
                return Tabla;
            }
            catch (Exception Error)
            {

                Desconectar();
                return new DataTable();
            }
           
        }

        public DataTable BuscarById(int Id)
        {
            try
            {
                Conectar();
                DataTable Tabla = new DataTable();
                string Query = $"SELECT * FROM Persona WHERE Id={Id}";
                SqlDataAdapter GuardarInfo = new SqlDataAdapter(Query, con);
                GuardarInfo.Fill(Tabla);
                Desconectar();
                return Tabla;
            }
            catch (Exception Error)
            {

                Desconectar();
                return new DataTable();
            }

        }

        public int Insertar(string Nombre,string Nacionalidad,DateTime Fecha)
        {
            try
            {
                Conectar();
                string fecha = $"{Fecha.ToString().Substring(6, 4)}/{Fecha.ToString().Substring(3,2)}/{Fecha.ToString().Substring(0, 2)}";
                string Query = $"insert into Persona values('{Nombre}','{Nacionalidad}','{fecha}')";
                SqlCommand InsertarInfo = new SqlCommand(Query, con);
                int FilasAfectadas = InsertarInfo.ExecuteNonQuery();
                Desconectar();
                return FilasAfectadas;
            }
            catch (Exception Error)
            {

                Desconectar();
                return 0;
            }

        }

        public int Editar(int Id,string Nombre, string Nacionalidad, DateTime Fecha)
        {
            try
            {
                Conectar();
                string fecha = $"{Fecha.ToString().Substring(6, 4)}/{Fecha.ToString().Substring(3, 2)}/{Fecha.ToString().Substring(0, 2)}";
                string Query = $"UPDATE Persona SET Nombre='{Nombre}',Nacionalidad='{Nacionalidad}',Fecha='{fecha}' WHERE ID={Id}";
                SqlCommand InsertarInfo = new SqlCommand(Query, con);
                int FilasAfectadas = InsertarInfo.ExecuteNonQuery();
                Desconectar();
                return FilasAfectadas;
            }
            catch (Exception Error)
            {

                Desconectar();
                return 0;
            }

        }

        public int Eliminar(int Id)
        {
            try
            {
                Conectar();               
                string Query = $"DELETE Persona WHERE ID={Id}";
                SqlCommand InsertarInfo = new SqlCommand(Query, con);
                int FilasAfectadas = InsertarInfo.ExecuteNonQuery();
                Desconectar();
                return FilasAfectadas;
            }
            catch (Exception Error)
            {

                Desconectar();
                return 0;
            }

        }
    }
}
