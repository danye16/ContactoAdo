using System.Data.SqlClient;
namespace ContactoAdo.Models.Datos
{
    public class Conexion
    {
        private string cadenaSql=string.Empty; //Esto es para que acepte valores nullos
        public Conexion() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();//Esto es para obtener los datos de la conexcion
            cadenaSql = builder.GetSection("ConnectionStrings:cadenaSql").Value;
        }
        public string getCadenaSql()
        {
            return cadenaSql;
        }
    }
}
