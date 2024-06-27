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
    public partial class rtbSaseg : UserControl
    {
        public ManejoEventos evento = new ManejoEventos();
        public bool Mayuscula = false;

        public rtbSaseg()
        {
            InitializeComponent();
        }

        private void rtbNormal_TextChanged(object sender, EventArgs e)
        {
            frmEdicion form = (frmEdicion)rtbNormal.FindForm();
            form.evento.FireEventFormEdited(true);
           
        }

        public String Text
        {
            set { this.rtbNormal.Text = value; }
            get { return this.rtbNormal.Text; }
        }

        public String RTF
        {
            set { this.rtbNormal.Rtf = value; }
            get { return this.rtbNormal.Rtf; }
        }

        public bool ReadOnly
        {
            set { this.rtbNormal.ReadOnly = value; }
            get { return this.rtbNormal.ReadOnly; }
        }

        public bool Mayusculas
        {
            set { Mayuscula = value; }
            get { return Mayuscula; }
        }

        public int Longitud
        {
            set { this.rtbNormal.MaxLength = value; }
            get { return this.rtbNormal.MaxLength; }
        }

        public void Clear()
        {
            this.rtbNormal.Clear();
        }

        public void SelectText()
        {
            this.rtbNormal.SelectionStart = 0;
            this.rtbNormal.SelectionLength = this.rtbNormal.Text.Length;
        }

        private void rtbNormal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Mayuscula)
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
