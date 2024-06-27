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
    public partial class cmbSaseg : UserControl
    {
        public ManejoEventos evento = new ManejoEventos();

        public cmbSaseg()
        {
            InitializeComponent();
        }

        private void cmbNormal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNormal.FindForm().GetType().BaseType.Name == "frmEdicion")
            {
                frmEdicion form = (frmEdicion)cmbNormal.FindForm();
                form.evento.FireEventFormEdited(true);
            }
        }

        public void SelectedValueChanged(EventHandler handler)
        {
            this.cmbNormal.SelectedValueChanged += handler;
        }

        public void agregarItems(string item)
        {
            cmbNormal.Items.Add(item);
        }

        

        public void DataSource(DataTable dt, string value, string display)
        {
            if (dt != null)
            {
                cmbNormal.DataSource = dt;
                cmbNormal.ValueMember = value;
                cmbNormal.DisplayMember = display;
            }
            else
            {
                cmbNormal.DataSource = dt;
                cmbNormal.DropDownHeight = 106;
            }
        }

        public void limpiarDataSource()
        {
            cmbNormal.DataSource = null;
        }

        public void limpiarComboBox()
        {
            cmbNormal.Items.Clear();
        }

        public String Valor
        {
            set { this.cmbNormal.SelectedValue = value; }
            get { return "" + this.cmbNormal.SelectedValue; }
        }

        public String Texto
        {
            set { this.cmbNormal.Text = value; }
            get { return "" + this.cmbNormal.Text; }
        }

        public  bool Habilitar
        {
            set { this.cmbNormal.Enabled = value; }
            get { return this.cmbNormal.Enabled; }
        }

        public int Index
        {
            set { this.cmbNormal.SelectedIndex = value; }
            get { return this.cmbNormal.SelectedIndex; }
        }

        public int Count
        {
            get { return this.cmbNormal.Items.Count; }
        }

    }
}
