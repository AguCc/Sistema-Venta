using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CpNegocio;
using Cp_Entidad;
using Entidad;

namespace Sistema_Venta
{
    public partial class Logins : Form
    {
        public Logins()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new Cn_Usuario().listar();
            Usuario ousuario = new Cn_Usuario().listar().Where(u => u.Documento == txtDocumento.Text && u.Clave == TxtContraseña.Text).FirstOrDefault();

            if (ousuario!= null)
            {
                Inicio form = new Inicio(ousuario);
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;

            }
            else
            {
                MessageBox.Show("No se encontro el usuario","Atencion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }



        }
        private void frm_closing(Object sender,FormClosingEventArgs e)
        {
            txtDocumento.Clear();
            TxtContraseña.Clear();
            this.Show();
        }
    }
}
