using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Framework
{
    public partial class frmFiltro : Form
    {
        public string filtro = "";
        public bool aplicar = false;

        public frmFiltro()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            armarFiltro();
            aplicar = true;
            Close();
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual void armarFiltro()
        {

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            aplicar = true;
            Close();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            armarFiltro();
            aplicar = true;
            Close();
        }

        private void btnTod_Click(object sender, EventArgs e)
        {
            aplicar = true;
            Close();
        }
    }
}
