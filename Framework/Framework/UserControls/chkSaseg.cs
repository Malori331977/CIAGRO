using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Framework.UserControls
{
    public partial class chkSaseg : UserControl
    {
        public ManejoEventos evento = new ManejoEventos();

        public chkSaseg()
        {
            InitializeComponent();
        }

        private void chbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNormal.FindForm().GetType().BaseType.Name == "frmEdicion")
            {
                frmEdicion form = (frmEdicion)chbNormal.FindForm();
                form.evento.FireEventFormEdited(true);
            }
        }

        public void CheckedChanged(EventHandler handler)
        {
            this.chbNormal.CheckedChanged += handler;
        }

        public String Texto
        {
            set { this.chbNormal.Text = value; }
            get { return this.chbNormal.Text; }
        }

        public bool Checked
        {
            set { this.chbNormal.Checked = value; }
            get { return this.chbNormal.Checked; }
        }

        private void chbNormal_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(e);
        }

    }
}
