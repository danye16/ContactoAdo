using ContactoAdo.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace ContactoAdo.Models.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            List<ContactoModel> lista = new List<ContactoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ContactoModel
                        {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Nombre"].ToString(),
                            Correo = dr["Nombre"].ToString(),
                            Clave = dr["Nombre"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }
        public ContactoModel ObtenerContacto(int IdContacto)
        {
            ContactoModel _contacto = new ContactoModel();


            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        _contacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        _contacto.Nombre = dr["Nombre"].ToString();
                        _contacto.Telefono = dr["Telefono"].ToString();
                        _contacto.Correo = dr["Correo"].ToString();
                        _contacto.Clave = dr["Clave"].ToString();
                    }
                }

            }
            return _contacto;
        }
        public bool GuardarContacto(ContactoModel model) //PRocedimiento almacenado guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", model.Telefono);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Clave", model.Clave);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool EditarContacto(ContactoModel model) //PRocedimiento almacenado guardar
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", model.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", model.Telefono);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Clave", model.Clave);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;


        }
    }
}
