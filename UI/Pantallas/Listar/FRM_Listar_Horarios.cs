using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Cat_Mant;
using BLL.Cat_Mant;

namespace UI.Pantallas.Listar
{
    public partial class FRM_Listar_Horarios : Form
    {
        cls_Horarios_BLL Obj_horarios_BLL = new cls_Horarios_BLL();
        cls_Horarios_DAL Obj_horarios_DAL = new cls_Horarios_DAL();

        public FRM_Listar_Horarios()
        {
            InitializeComponent();
        }

        private void FRM_Listar_Horarios_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void tsbtnRefrescar_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void tstxtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarDatos();
        }

        public void cargarDatos()
        {
            if (tstxtBuscar.Text == string.Empty)
            {
                Obj_horarios_BLL.Listar_Horarios(ref Obj_horarios_DAL);
            }
            else
            {
                Obj_horarios_BLL.Filtrar_Horarios(ref Obj_horarios_DAL, tstxtBuscar.Text.Trim());
            }
            //Obj_categorias_BLL.Listar_Categorias(ref Obj_categorias_DAL);

            if (Obj_horarios_DAL.sMsjError == string.Empty)
            {
                //MessageBox.Show("Categorias Listada Exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvHorarios.DataSource = null;
                dgvHorarios.DataSource = Obj_horarios_DAL.Obj_DT;
            }
            else
            {
                MessageBox.Show("Se presento un error a la hora de listar horarios: [" + Obj_horarios_DAL.sMsjError + "].", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.RowCount > 0)
            {

                Obj_horarios_BLL.Eliminar_Horarios(ref Obj_horarios_DAL, dgvHorarios.SelectedRows[0].Cells[0].Value.ToString());

                if (Obj_horarios_DAL.sMsjError == string.Empty)
                {
                    MessageBox.Show("Registros Eliminado Correctamente",
                                    "Eliminar",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    cargarDatos();

                }
                else
                {
                    MessageBox.Show("Se Generó un Error al tratar de Eliminar un registro",
                                    "Elimnar",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Debe Seleccionar datos",
                                    "Elimnar",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.Rows.Count > 0)
            {
                Obj_horarios_DAL = new cls_Horarios_DAL();
                Obj_horarios_DAL.cAx = 'U';
                Obj_horarios_DAL.cIdHorarios = Convert.ToChar(dgvHorarios.SelectedRows[0].Cells[0].Value.ToString());
                //Obj_horarios_DAL.SDescEstado = dgvHorarios.SelectedRows[0].Cells[1].Value.ToString();




                Pantallas.Editar.FRM_Editar_Estados Pant_Modif_Estados = new Editar.FRM_Editar_Estados();
                //Pant_Modif_Estados.Obj_Estados_Editar_DAL = Obj_horarios_DAL;
                Pant_Modif_Estados.ShowDialog();

                cargarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Estado", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
