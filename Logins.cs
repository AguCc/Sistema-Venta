using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Inicio form = new Inicio();
            form.Show();
            this.Hide();
            form.FormClosing += frm_closing;



        }
        private void frm_closing(Object sender,FormClosingEventArgs e)
        {
            txtDocumento.Clear();
            TxtContraseña.Clear();
            this.Show();
        }
    }
}
