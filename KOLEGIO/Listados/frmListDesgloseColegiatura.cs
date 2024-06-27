using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework;

namespace KOLEGIO
{
    public partial class frmListDesgloseColegiatura : frmListado
    {
        public frmListDesgloseColegiatura()
        {
            InitializeComponent();
        }

        protected override void abrirEdicionNuevo()
        {
            if (Utilitario.BuscaForm("frmDesgloseColegiatura"))
            {
                frmDesgloseColegiatura frm = new frmDesgloseColegiatura(new List<string>());
                frm.Show();
            }
        }
    }
}
