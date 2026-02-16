using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cp_Entidad;
using FontAwesome.Sharp;
using CpNegocio;

namespace Sistema_Venta
{

    public partial class Inicio : Form
    {
        private static Entidad.Categoria usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public Inicio(Entidad.Categoria usuario =null)
        {
            //if(usuario== null)
            //    usuarioActual = new Usuario() { NombreCompleto = "Empleado",IdUsuario=1};
            //else { usuarioActual = usuario; }

            usuarioActual = usuario;

            InitializeComponent();

        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new Cn_Permiso().listar(usuarioActual.IdUsuario);
            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(p => p.NombreMenu == iconmenu.Name);
                if (encontrado==false)
                {
                    iconmenu.Visible = false;
                }
            }

            lblUsuario.Text = usuarioActual.NombreCompleto;
        }
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }

            menu.BackColor = Color.LightSteelBlue;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close(); // ← acá está la corrección
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.AliceBlue;

            Contenedor.Controls.Clear(); // recomendable para evitar duplicados
            Contenedor.Controls.Add(formulario);
            formulario.Show();
        }
        private void MenuUsuario_Click(object sender, EventArgs e)
        {
            
            AbrirFormulario((IconMenuItem)sender,new frmUsuarios());
        }

        private void subMenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new FrmCategoria());
        }

        private void subMenuProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new FrmProducto());
        }

        private void subMenuRegistrar_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmVenta());
        }

        private void SubMenuVerDetalleDeVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventa, new FrmDetalleVenta());
        }

        private void SubMenuResgistrarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmCompra());
        }

        private void subMenuDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmDetalleCompra());
        }

        private void MenuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmClientes());
        }

        private void MenuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new Proveedor());
        }

        private void MenuReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new Reportes());
        }
    }
}
