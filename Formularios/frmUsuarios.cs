using Sistema_Venta.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using CpNegocio;
using System.Windows.Controls;

namespace Sistema_Venta
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cbestado.Items.Add(new OpcionCombo() { Texto = "Activo", Valor = 1 });
            cbestado.Items.Add(new OpcionCombo() { Texto = "No Activo", Valor = 0 });
            cbestado.DisplayMember = "Texto";
            cbestado.ValueMember = "Valor";
            cbestado.SelectedIndex = 0;

            List<Rol> listRol = new Cn_Rol().listar();

            foreach (Rol item in listRol)
            {
                cbrol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cbrol.DisplayMember = "Texto";
            cbrol.ValueMember = "Valor";
            cbrol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dvgdata.Columns)
            {
                if (columna.Visible == true )
                {
                    cbbusqueda.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
                }
            }



        }

        private void btnguarda_Click(object sender, EventArgs e)
        {
            dvgdata.Rows.Add(new object[] {"",txtid.Text,txtdocumento.Text,txtnombrecompleto.Text,txtcorreo.Text,txtcontraseña.Text,
            ((OpcionCombo)cbrol.SelectedItem).Valor.ToString(),
            ((OpcionCombo)cbrol.SelectedItem).Texto.ToString(),
            ((OpcionCombo)cbestado.SelectedItem).Valor.ToString(),
            ((OpcionCombo)cbestado.SelectedItem).Texto.ToString(),
            });
            Limpiar();

        }
        private void Limpiar()
        {
            txtid.Text = "";
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txtcontraseña.Text = "";
            confirmarContraseña.Text = "";
            cbrol.SelectedIndex = 0;
            cbestado.SelectedIndex = 0;
        }

    }
}
