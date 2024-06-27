using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOLEGIO.Edicion
{
	public partial class frmRegCursos : frmEdicion
	{
		public frmRegCursos()
		{
			InitializeComponent();
		}
        public frmRegCursos(List<string> valoresPk, string NColegiado = "")
            : base(valoresPk)
        {
            //this.fInternas = new FuncsInternas();
            //Nconsecutivo = NColegiado;
            armarFiltroPK(valoresPk);
            InitializeComponent();
            //listaTipos();
            //if (cmbTipo.Count > 0)
            //    cmbTipo.Index = 0;
            //cargarDatos();

            //if (fInternas.registroDeshabilitado(txtNumColegiado.Valor, ref error))
            //{
            //    btnGuardar.Visible = false;
            //    btnGuardarSalir.Visible = false;
            //    toolStripSeparator4.Visible = false;
            //}
        }
    }
}
