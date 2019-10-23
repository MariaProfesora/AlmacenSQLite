
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Datos
    {
        private string cadConexion = "Data Source =BDAlmacen.db;Version=3;";
        public List<Producto> Productos(out string mensaje)
        {
            mensaje = "";
            List<Producto> lista = new List<Producto>();
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cadConexion))
                {
                    string sql = "Select * From Productos";
                    SQLiteCommand cmdProductos = new SQLiteCommand(sql, con);
                    con.Open();
                    SQLiteDataReader dr = cmdProductos.ExecuteReader();
                    while (dr.Read())
                    {

                        Producto prod = new Producto();
                        prod.Id = dr.GetInt32(dr.GetOrdinal("Id"));//
                        prod.Id = int.Parse(dr["Id"].ToString()); 
                      //  prod.Id = (int)dr["Id"]; // Dará error, porque se considera un Int32
                        prod.Descripcion = dr["Descripcion"].ToString();

                        prod.Precio = (double)dr["Precio"];
                        prod.Stock = dr.GetInt32(dr.GetOrdinal("Stock")); // Así da error prod.Stock = (int)dr["Stock"]; debería ponerConvert.ToInt32((long)dr["Stock"]);               
                        lista.Add(prod);           
                    }
                }
            }

            catch (Exception exc)
            {
                mensaje = exc.Message;
            }
            return lista;
        }
        public string AñadirEmpleado(Empleado empleado)
        {
            string mens = "";
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cadConexion))
                {
                    string sql = "Select Id From Empleados Where Id = ?";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", empleado.Id);
                    con.Open();
                    if (cmd.ExecuteScalar() != null) return $"Ya existe un@ emplead@ con el identificador {empleado.Id}";
                    sql = "Insert INTO Empleados (Id, Nombre) Values (@id, @nombre)";
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@nombre", empleado.Nombre);
                    int nf = cmd.ExecuteNonQuery();
                    if (nf == 0) mens = "No ha grabado, aunque sin error de ejecución";


                }
            }
            catch (Exception exc)
            {
                mens = exc.Message;
            }
            return mens;
        }
        public string AñadirPedido(Pedido ped)
        {
            string mens = "";
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cadConexion))
                {

                    string sql = "Insert INTO Pedidos (NumPedido, Fecha, IdEmpleado) Values (@numPedido, @fecha, @idEmpleado)";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@numPedido", ped.NumPedido);
                    cmd.Parameters.AddWithValue("@fecha", ped.Fecha);

                    cmd.Parameters.AddWithValue("@idEmpleado", ped.IdEmpleado);
                    int nf = cmd.ExecuteNonQuery();
                    if (nf == 0) mens = "No ha grabado, aunque sin error de ejecución";


                }
            }
            catch (Exception exc)
            {
                mens = exc.Message;
            }
            return mens;
        }

        public int UltimoNumPedido(out string mens)
        {
            mens = "";
            int ultNumPedido = 0;
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cadConexion))
                {
                    string sql = "Select Max(NumPedido) From Pedidos";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    con.Open();
                    var valor = cmd.ExecuteScalar();
                    if (valor != null)
                        ultNumPedido = Convert.ToInt32(valor); // int.Parse(valor.ToString()); // sino pongo lo trabaja como long
                    else
                        ultNumPedido = 0;
                }
            }
            catch (Exception exc)
            {
                mens = exc.Message;
            }
            return ultNumPedido;
        }

        public List<Empleado> Empleados(out string mens)
        {
            mens = "";
            List<Empleado> lista = new List<Empleado>();
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(cadConexion))
                {
                    string sql = "Select * From Empleados";
                    SQLiteCommand cmd = new SQLiteCommand(sql, con);
                    con.Open();
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        Empleado empl = new Empleado();
                        empl.Id = dr.GetInt32(dr.GetOrdinal("Id"));// prod.Id = int.Parse(dr["Id"].ToString()); 
                        empl.Nombre = dr["Nombre"].ToString();
                        lista.Add(empl);
                    }
                }
            }

            catch (Exception exc)
            {
                mens = exc.Message;
            }
            return lista;
        }
    }
}
