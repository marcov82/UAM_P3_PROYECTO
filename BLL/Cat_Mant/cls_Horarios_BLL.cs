using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.BD;
using BLL.BD;
using DAL.Cat_Mant;

namespace BLL.Cat_Mant
{
    public class cls_Horarios_BLL
    {
        public void Listar_Horarios(ref cls_Horarios_DAL Obj_Horarios_DAL)
        {
            try
            {
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();

                Obj_BD_DAL.SNomb_Sp = "sp_Listar_Horarios";
                Obj_BD_DAL.SNombTabla = "Horarios";

                Obj_BD_BLL.Exec_DataAdapter(ref Obj_BD_DAL);

                if (Obj_BD_DAL.SMsjError == string.Empty)
                {
                    Obj_Horarios_DAL.Obj_DT = Obj_BD_DAL.Obj_DS.Tables[0];
                    Obj_Horarios_DAL.sMsjError = string.Empty;
                }
                else
                {
                    Obj_Horarios_DAL.sMsjError = Obj_BD_DAL.SMsjError;
                }

            }
            catch (Exception ex)
            {
                Obj_Horarios_DAL.sMsjError = ex.Message.ToString();
            }
        }
        public void Filtrar_Horarios(ref cls_Horarios_DAL Obj_Horarios_DAL, string sFiltro)
        {
            try
            {
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();

                Obj_BD_DAL.SNomb_Sp = "sp_Filtrar_Horarios";
                Obj_BD_DAL.SNombTabla = "Horarios";

                Obj_BD_BLL.Crear_DT_Parametros(ref Obj_BD_DAL);

                Obj_BD_DAL.dt_Parametros.Rows.Add("@filtro", "3", sFiltro);

                Obj_BD_BLL.Exec_DataAdapter(ref Obj_BD_DAL);

                if (Obj_BD_DAL.SMsjError == string.Empty)
                {
                    Obj_Horarios_DAL.Obj_DT = Obj_BD_DAL.Obj_DS.Tables[0];
                    Obj_Horarios_DAL.sMsjError = string.Empty;
                }
                else
                {
                    Obj_Horarios_DAL.sMsjError = Obj_BD_DAL.SMsjError;
                }
            }
            catch (Exception ex)
            {
                Obj_Horarios_DAL.sMsjError = ex.Message.ToString();
            }
        }
        public void Insertar_Horarios(ref cls_Horarios_DAL Obj_Horarios_DAL)
        {
            try
            {

            }
            catch (Exception)
            {


            }
        }
        public void Modificar_Horarioss(ref cls_Horarios_DAL Obj_Horarios_DAL)
        {
            try
            {

            }
            catch (Exception)
            {


            }
        }
        public void Eliminar_Horarios(ref cls_Horarios_DAL Obj_Horarios_DAL, string sFiltro)
        {
            try
            {
                cls_BD_BLL Obj_BD_BLL = new cls_BD_BLL();
                cls_BD_DAL Obj_BD_DAL = new cls_BD_DAL();

                Obj_BD_DAL.SNomb_Sp = "sp_Eliminar_Horarios";
                Obj_BD_DAL.SNombTabla = "Horarios";

                Obj_BD_BLL.Crear_DT_Parametros(ref Obj_BD_DAL);

                Obj_BD_DAL.dt_Parametros.Rows.Add("@filtro", "3", sFiltro);

                Obj_BD_BLL.Exec_NonQuery(ref Obj_BD_DAL);

                if (Obj_BD_DAL.SMsjError == string.Empty)
                {
                    Obj_Horarios_DAL.sMsjError = string.Empty;
                }
                else
                {
                    Obj_Horarios_DAL.sMsjError = Obj_BD_DAL.SMsjError;
                }
            }
            catch (Exception ex)
            {
                Obj_Horarios_DAL.sMsjError = ex.Message.ToString();
            }
        }

    }
}
