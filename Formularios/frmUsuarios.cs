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
        {//Agregado el estado del usuario al combo box de estado

            InsertKeyMode.Insert.ToString();
            cbestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cbestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo"});
            cbestado.DisplayMember = "Texto";
            cbestado.ValueMember = "Valor";
            cbestado.SelectedIndex = 0;


            List<Rol> listRol = new Cn_Rol().listar();

            foreach (Rol item in listRol)
            {//Agregado los roles al combo box
                cbrol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cbrol.DisplayMember = "Texto";
            cbrol.ValueMember = "Valor";
            cbrol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dvgdata.Columns)
            {//Agregado las columnas al combo box de busqueda

                if (columna.Visible == true && columna.Name !="btnseleccionar" )
                {
                    cbbusqueda.Items.Add(new OpcionCombo() { Valor=columna.Name, Texto= columna.HeaderText });
                }
            }

            cbbusqueda.DisplayMember = "Texto";
            cbbusqueda.ValueMember = "Valor";
            cbbusqueda.SelectedIndex = 0;


            List<Usuario> listaUsuari = new Cn_Usuario().listar();

            foreach (Usuario item in listaUsuari)
            {//Agregado los usuarios al datagridview

                dvgdata.Rows.Add(new object[] {"",item.IdUsuario,item.Documento,item.NombreCompleto,item.Correo,item.Clave,
            item.oRol.IdRol,
            item.oRol.Descripcion,
            item.Estado ==true ?1 :0,
            item.Estado== true ? " Activo": "No Activo",
            });
            }
            

        }

        private void btnguarda_Click(object sender, EventArgs e)
        {//Agregado nuevo usuario al datagridview

            dvgdata.Rows.Add(new object[] {"",txtid.Text,txtdocumento.Text,txtnombrecompleto.Text,txtcorreo.Text,txtcontraseña.Text,
            ((OpcionCombo)cbrol.SelectedItem).Valor.ToString(),
            ((OpcionCombo)cbrol.SelectedItem).Texto.ToString(),
            ((OpcionCombo)cbestado.SelectedItem).Valor.ToString(),
            ((OpcionCombo)cbestado.SelectedItem).Texto.ToString(),
            });
            Limpiar();

        }
        private void Limpiar()
        {//Limpiar los controles del formulario
            txtindice.Text = "-1";
            txtid.Text = "";
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txtcontraseña.Text = "";
            confirmarContraseña.Text = "";
            cbrol.SelectedIndex = 0;
            cbestado.SelectedIndex = 0;
        }

        private void dvgdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {//Pintar el encabezado del datagridview
                return;
            }

            if (e.ColumnIndex ==0)
            {//Pintar el boton de seleccionar

                e.Paint(e.CellBounds,DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            
        }

        private void dvgdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {//Agregar la funcionalidad del boton de seleccionar

            if (dvgdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {//Agregado los datos del usuario seleccionado a los controles

                    txtindice.Text = indice.ToString();

                    txtid.Text = dvgdata.Rows[indice].Cells["Id"].Value.ToString();
                    txtdocumento.Text = dvgdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombrecompleto.Text = dvgdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtcorreo.Text = dvgdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtcontraseña.Text = dvgdata.Rows[indice].Cells["Clave"].Value.ToString();
                    confirmarContraseña.Text = dvgdata.Rows[indice].Cells["Clave"].Value.ToString();
                    

                    foreach (OpcionCombo oc in cbrol.Items)
                    {//Agregado el rol seleccionado a los controles

                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dvgdata.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = cbrol.Items.IndexOf(oc);
                            cbrol.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cbestado.Items)
                    {//Agregado el estado seleccionado a los controles
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dvgdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cbestado.Items.IndexOf(oc);
                            cbestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                }

            }
            
            
        }
    }
}
