using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Cat_Mant
{
    public class cls_Horarios_DAL
    {
        private char _cIdHorarios, _cAx;
        private string _sMsjError;
        public DataTable Obj_DT = new DataTable();

        public string sMsjError
        {
            get
            {
                return _sMsjError;
            }

            set
            {
                _sMsjError = value;
            }
        }

        public char cIdHorarios
        {
            get
            {
                return _cIdHorarios;
            }

            set
            {
                _cIdHorarios = value;
            }
        }

        public char cAx
        {
            get
            {
                return _cAx;
            }

            set
            {
                _cAx = value;
            }
        }
    }
}
