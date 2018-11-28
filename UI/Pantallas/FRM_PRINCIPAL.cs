using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UI.Pantallas
{
    public partial class FRM_PRINCIPAL : Form
    {
        public FRM_PRINCIPAL()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwmd, int wmsg, int wparam, int lparam);
    

        private void FRM_PRINCIPAL_Load(object sender, EventArgs e)
        {

        }
        //Evento para abrir ventana seleccionada
        private void AbrirVentana(object VentanaHija) 
        {
            if (PanelVentana.Controls.Count > 0)
                PanelVentana.Controls.RemoveAt(0);
            Form vh = VentanaHija as Form;
            vh.TopLevel = false;
            vh.Dock = DockStyle.Fill;
            PanelVentana.Controls.Add(vh);
            PanelVentana.Tag = vh;
            vh.Show();

        }   //Evento para abrir ventana seleccionada
        private void btnMenuSlide_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEstados_Click(object sender, EventArgs e)
        {
            AbrirVentana(new Pantallas.Listar.FRM_Listar_Estados());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirVentana(new Pantallas.Listar.FRM_Listar_Productos());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirVentana(new Pantallas.Listar.FRM_Listar_Usuarios());
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            AbrirVentana(new Pantallas.Listar.FRM_Listar_Horarios());
        }
    }
}
