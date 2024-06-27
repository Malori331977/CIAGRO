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
    public partial class clbSaseg : UserControl
    {
        public ManejoEventos evento = new ManejoEventos();
        bool seleccionUnica = false;

        public clbSaseg()
        {
            InitializeComponent();
        }

        private void clbNormal_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (clbNormal.FindForm().GetType().BaseType.Name == "frmEdicion")
            {
                frmEdicion form = (frmEdicion)clbNormal.FindForm();
                form.evento.FireEventFormEdited(true);
            }

            if (seleccionUnica)
            {
                for (int i = 0; i < clbNormal.Items.Count; i++)
                {
                    if (i != e.Index)
                        clbNormal.SetItemChecked(i, false);
                }
            }
        }

        public void ItemCheck(ItemCheckEventHandler handler)
        {
            this.clbNormal.ItemCheck += handler;
        }

        public void SetItemChecked(int index,bool estado)
        {
            this.clbNormal.SetItemChecked(index,estado);
        }

        public CheckedListBox.ObjectCollection Items
        {
            get { return this.clbNormal.Items; }
        }

        public CheckedListBox.CheckedItemCollection CheckedItems
        {
            get { return this.clbNormal.CheckedItems; }
        }

        public void agregarItems(string item)
        {
            this.Items.Add(item);
        }

         public void DataSource(DataTable dt, string value, string display)
        {
            ((ListBox)clbNormal).DataSource = dt;
            ((ListBox)clbNormal).DisplayMember = display;
            ((ListBox)clbNormal).ValueMember = value;
        }
       

        public bool GetItemChecked(int index)
        {
            return this.clbNormal.GetItemChecked(index);
        }


        public bool SeleccionUnica
        {
            set { seleccionUnica = value; }
            get { return this.seleccionUnica; }
        }

        public string ValueMember(DataRow r)
        {
            return (r[this.clbNormal.ValueMember]).ToString();
        }

        public string DisplayMember(DataRow r)
        {
            return (r[this.clbNormal.DisplayMember]).ToString();
        }

        public int Index
        {
            set { clbNormal.SelectedIndex = value; }
            get { return clbNormal.SelectedIndex; }
        }
    }
}
