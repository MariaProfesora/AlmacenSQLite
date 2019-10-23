using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {
            string mens;
            var lisProd = Program.misDatos.Productos(out mens);
            if (mens == "")
                dgv.DataSource = lisProd;
            else
                MessageBox.Show(mens);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarComboEmpleados();
            string mens;
            int ultPedido = Program.misDatos.UltimoNumPedido(out mens);
            lblNumPedido.Text = (ultPedido + 1).ToString();
            cboEmpleados.SelectedIndex = 0;

        }
        
        private void CargarComboEmpleados()
        {
            string mens;
            List<Empleado> listaEmpleados = Program.misDatos.Empleados(out mens);
            if (mens == "")
            {
                cboEmpleados.Items.Clear();
                cboEmpleados.Items.AddRange(listaEmpleados.ToArray());
                cboEmpleados.DisplayMember = "Nombre";
            }
            else
                MessageBox.Show(mens);
        }
        private void btnAñadirPedido_Click(object sender, EventArgs e)
        {
            int numPedi = int.Parse(lblNumPedido.Text);
            DateTime fecha = dtpFecha.Value;
            Empleado empleado = (Empleado)(cboEmpleados.SelectedItem);
            Pedido ped = new Pedido(numPedi, fecha, empleado.Id);
            string mens = Program.misDatos.AñadirPedido(ped);
            if (mens != "") MessageBox.Show(mens);

        }

        private void btnAñadirEmpleado_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado(int.Parse(txtIdEmpleado.Text), txtNombreEmpleado.Text);
            string mens = Program.misDatos.AñadirEmpleado(empleado);
            if (mens == "")
                CargarComboEmpleados();
            else
                MessageBox.Show(mens);
        }

        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIdProducto.Text);
            string descripcion = txtDescripcion.Text;
            Producto prod = new Producto(id, descripcion, double.Parse(txtPrecio.Text), int.Parse(txtStock.Text));
            string mens = Program.misDatos.AñadirProducto(prod);
            if (mens!="") MessageBox.Show(mens);
        }
    }
}
