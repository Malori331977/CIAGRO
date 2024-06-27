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
    public partial class rbSaseg : UserControl
    {
        public ManejoEventos evento = new ManejoEventos();
        public bool onChanged = true;

        public rbSaseg()
        {
            InitializeComponent();
        }

        public bool Checked
        {
            set { this.rbNormal.Checked = value; }
            get { return this.rbNormal.Checked; }
        }


        public String Texto
        {
            set { this.rbNormal.Text = value; }
            get { return this.rbNormal.Text; }
        }

        private void rbNormal_MouseClick(object sender, MouseEventArgs e)
        {
            onChanged = false;
            foreach (Control myBut in Parent.Controls)
            {
                if (myBut.GetType().Name.Contains("rb"))
                    ((rbSaseg)myBut).Checked = false;
            }
            rbNormal.Checked = true;
            OnMouseClick(e);
            onChanged = true;
        }

        public void CheckChanged(EventHandler handler)
        {
            this.rbNormal.CheckedChanged += handler;
        }

        private void rbNormal_Click(object sender, EventArgs e)
        {
            if (onChanged)
            if (rbNormal.FindForm().GetType().BaseType.Name == "frmEdicion")
            {
                frmEdicion form = (frmEdicion)rbNormal.FindForm();
                form.evento.FireEventFormEdited(true);
            }

            OnClick(e);
        }
    }
}
