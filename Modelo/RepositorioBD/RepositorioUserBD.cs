using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Modelo
{
    public class RepositorioUserBD:Singleton<RepositorioUserBD>
    {
        private List<User> UserList = new List<User>();
        static RepositorioUserBD instance = null;

        SqlConnection conexion = new SqlConnection(@"Server=LAPTOP-4RC7FOER;Database=Usuarios;Trusted_Connection=True;");

        public User Agregar(User oUser)
        {
            conexion.Open();
            SqlCommand c = conexion.CreateCommand();
            c.Connection = conexion;
            c.CommandType = CommandType.StoredProcedure;
            c.CommandText = "Agregar_Usuario";


            c.Parameters.AddWithValue("nombre", oUser.Name);
            c.Parameters.AddWithValue("apellido", oUser.LastName);
            c.Parameters.AddWithValue("email", oUser.Email);
            c.Parameters.AddWithValue("pass", oUser.Password);
            c.Parameters.AddWithValue("fechaAlta", oUser.AccessLast);
            c.Parameters.AddWithValue("UltimoAcceso", oUser.CreationTime);
            c.Parameters.AddWithValue("NivelAcceso", oUser.LevelAccess1);

            SqlDataReader dn = c.ExecuteReader();
            if (dn.Read())
                oUser.Id = dn.GetInt32(0);
            return oUser;
            dn.Close();
            conexion.Close();
        }

        public int EliminarPorEmail(string email)
        {
            conexion.Open();
            SqlCommand c = conexion.CreateCommand();
            c.CommandType = CommandType.StoredProcedure;
            c.CommandText = "Eliminar_Usuario";

            SqlParameter emailParamentro = c.CreateParameter();
            emailParamentro.ParameterName = "@email";
            emailParamentro.SqlDbType = SqlDbType.VarChar;
            emailParamentro.Value = email;
            c.Parameters.Add(emailParamentro);

            int affectedRows = c.ExecuteNonQuery();
            conexion.Close();
            return affectedRows;
        }

        public List<User> BuscarUsuarioPorApellido(string lastname)
        {
            conexion.Open();
            SqlCommand c = conexion.CreateCommand();
            c.Connection = conexion;
            c.CommandText = "select * from Users WHERE apellido=@lastname";

            SqlParameter apellidoParamentro = c.CreateParameter();
            apellidoParamentro.ParameterName = "@lastname";
            apellidoParamentro.SqlDbType = SqlDbType.VarChar;
            apellidoParamentro.Value = lastname;
            c.Parameters.Add(apellidoParamentro);

            SqlDataReader dn = c.ExecuteReader();
            while (dn.Read())
            {
                string apellido = dn.GetString(1);
                string nombre = dn.GetString(2);
                string email = dn.GetString(3);
                string pass = dn.GetString(4);
                DateTime fechaAlt = dn.GetDateTime(5);
                DateTime ultimoAcc = dn.GetDateTime(6);
                int nivel = dn.GetInt32(7);
                User oUsuario= new User(apellido, nombre, pass, email, nivel, fechaAlt, ultimoAcc);
                UserList.Add(oUsuario);

            }
            dn.Close();
            conexion.Close();
            return UserList;
        }

        public User BuscarPorMails(string emails)
        {
            User oUser = null;
            conexion.Open();
            SqlCommand c = conexion.CreateCommand();
            c.Connection = conexion;
            c.CommandType = CommandType.StoredProcedure;
            c.CommandText = "BuscarPorMails";

            SqlParameter emailParemtro = c.CreateParameter();
            emailParemtro.ParameterName = "@email";
            emailParemtro.SqlDbType = SqlDbType.VarChar;
            emailParemtro.Value = emails;
            c.Parameters.Add(emailParemtro);

            SqlDataReader dn = c.ExecuteReader();
            while (dn.Read())
            {
                int id = dn.GetInt32(0);
                string apellido = dn.GetString(1);
                string nombre = dn.GetString(2);
                string email = dn.GetString(3);
                string pass = dn.GetString(4);
                DateTime fechaAlt = dn.GetDateTime(5);
                DateTime ultimoAcc = dn.GetDateTime(6);
                int nivel = dn.GetInt32(7);
                User oUsuarios = new User(apellido, nombre, pass, email, nivel, fechaAlt, ultimoAcc);
               
            }
            dn.Close();
            conexion.Close();
            return oUser;
        }

        public List<User> DevolverTodos()
        { 
                    conexion.Open();
                    SqlCommand c = conexion.CreateCommand();
                    c.Connection = conexion;
                     c.CommandType = CommandType.StoredProcedure;
                     c.CommandText = "DevolverTodos";
                     c.Prepare();
                    SqlDataReader dn = c.ExecuteReader();
                    while (dn.Read())
                    {
                        int id = dn.GetInt32(0);
                        string apellido = dn.GetString(1);
                        string nombre = dn.GetString(2);
                        string email = dn.GetString(3);
                        string pass = dn.GetString(4);
                        DateTime fechaAlt = dn.GetDateTime(5);
                        DateTime ultimoAcc = dn.GetDateTime(6);
                        int nivel = dn.GetInt32(7);
                        User oUsuarios = new User(apellido, nombre, pass, email, nivel, fechaAlt, ultimoAcc);
                        oUsuarios.Id = id;
                        UserList.Add(oUsuarios);                   
                    }
                dn.Close();    
            conexion.Close();
            return UserList;
        }
    }
}
