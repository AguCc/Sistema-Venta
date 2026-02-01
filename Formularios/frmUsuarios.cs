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
using Sistema_Venta.Utilidades;
using Entidad;
using CpNegocio;

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
            OpcionCombo opcionCombo;
            // TODO: esta línea de código carga datos en la tabla 'dataUsuario.USUARIO' Puede moverla o quitarla según sea necesario.
            this.uSUARIOTableAdapter.Fill(this.dataUsuario.USUARIO);
            cbestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cbestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cbestado.DisplayMember = "Texto";
            cbestado.ValueMember = "Valor";
            cbestado.SelectedIndex = 0;

            List<Rol> listaRol = new Cn_Rol().listar();
            foreach (Rol item in listaRol)
            {
                cbrol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
                cbestado.DisplayMember = "Texto";
                cbestado.ValueMember = "Valor";
                cbestado.SelectedIndex = 0;
            }



        }
    }
}
