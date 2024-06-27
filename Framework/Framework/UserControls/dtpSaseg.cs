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
    public partial class dtpSaseg : UserControl
    {
        public ManejoEventos evento = new ManejoEventos();

        public dtpSaseg()
        {
            InitializeComponent();
        }

        private void dtpNormal_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNormal.FindForm().GetType().BaseType.Name == "frmEdicion")
            {
                frmEdicion form = (frmEdicion)dtpNormal.FindForm();
                form.evento.FireEventFormEdited(true);
            }
        }

        public void ValueChanged(EventHandler handler)
        {
            this.dtpNormal.ValueChanged += handler;
        }

        public bool mostrarCheckBox
        {
            set { dtpNormal.ShowCheckBox = value; }
            get { return this.dtpNormal.ShowCheckBox; }
        }

        public bool mostrarUpDown
        {
            set { dtpNormal.ShowUpDown = value; }
            get { return this.dtpNormal.ShowUpDown; }
        }

        public DateTime Value
        {
            set { dtpNormal.Value = value; }
            get { return dtpNormal.Value; }
        }

        public bool Checked
        {
            set { dtpNormal.Checked = value; }
            get { return dtpNormal.Checked; }
        }

        public void Format(string format)
        {
            dtpNormal.Format = DateTimePickerFormat.Custom;
            dtpNormal.CustomFormat = format;
        }
    }
}
