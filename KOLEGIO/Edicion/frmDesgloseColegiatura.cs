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
    public partial class frmDesgloseColegiatura : frmEdicion
    {
        public frmDesgloseColegiatura(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
        }
    }
}
