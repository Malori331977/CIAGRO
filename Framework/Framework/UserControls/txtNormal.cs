using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Framework.UserControls
{
    public partial class txtNormal : UserControl
    {
        public ManejoEventos evento = new ManejoEventos();
        bool formato = false;
        bool agregarCero = false;
        bool formatoListo = false;
        bool agregarCeroAlfinal = false;

        public txtNormal()
        {
            InitializeComponent();
        }

        public bool FormatearNumero
        {
            set { formato = value; }
            get { return formato; }
        }

        public bool Focused()
        {
            if (this.txtCustom.Focused)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtCustom_TextChanged(object sender, EventArgs e)
        {
            if (txtCustom.FindForm().GetType().BaseType.Name == "frmEdicion")
            {
                frmEdicion form = (frmEdicion)txtCustom.FindForm();
                form.evento.FireEventFormEdited(true);
            }

            if (formato&&!formatoListo)
            {
                if (Utilitario.EsNumero(txtCustom.Text))
                {
                    if (txtCustom.Text.Contains("."))
                    {
                        string[] aux = txtCustom.Text.Split('.');
                        if (aux[1].Length == 3)
                        {
                            txtCustom.Text = txtCustom.Text.Remove(txtCustom.Text.Length - 1);
                            return;
                        }
                        else
                            if (aux[1] == "")
                                return;
                        
                    }

                    // txtCustom.Text += "1";
                    var text = txtCustom.Text;
                    text = text.Replace(",", "");

                    string[] dec = txtCustom.Text.Split('.');
                    

                    if (dec.Length > 1)
                    {
                        if (decimal.Parse(dec[1]) == 0)
                            agregarCero = true;
                        
                            if (dec[1].Length > 1)
                            {
                                if (dec[1][1] == '0')
                                    agregarCeroAlfinal = true;
                            }
                    }

                    decimal dato = decimal.Parse(text);
                    if (dato != 0)
                    {
                       
                        if (dato < 1 && dato > 0)
                        {
                            txtCustom.Text = dato.ToString();
                            formatoListo = true;

                            if (agregarCero || agregarCeroAlfinal)
                            {
                                if (agregarCero)
                                    txtCustom.Text += ".0";

                                if (agregarCeroAlfinal)
                                    txtCustom.Text += "0";
                            }
                        }
                        else
                        {
                            txtCustom.Text = dato.ToString("###,###.##");
                            formatoListo = true;

                            if (agregarCero || agregarCeroAlfinal)
                            {
                                if (agregarCero)
                                    txtCustom.Text += ".0";

                                if (agregarCeroAlfinal)
                                    txtCustom.Text += "0";
                            }
                        }
                    }
                       

                    txtCustom.SelectionStart = txtCustom.Text.Length;
                    txtCustom.SelectionLength = 0;
                }
                else
                    if(txtCustom.Text!="")
                    txtCustom.Text = txtCustom.Text.Remove(txtCustom.Text.Length - 1);

                formatoListo = false;
                agregarCero = false;
                agregarCeroAlfinal = false;
            }
        }

        public void ValueChanged(EventHandler handler)
        {
            this.txtCustom.TextChanged += handler;
        }

        public void WhiteSpaces()
        {
            this.txtCustom.Text = this.txtCustom.Text.Replace(" ", string.Empty);
        }

        public void Right()
        {
            this.txtCustom.TextAlign = HorizontalAlignment.Right;
        }

        public String Valor
        {
            set { this.txtCustom.Text = value; }
            get { return this.txtCustom.Text; }
        }

        public int Longitud
        {
            set { this.txtCustom.MaxLength = value; }
            get { return this.txtCustom.MaxLength; }
        }

        public bool Multilinea
        {
            set { this.txtCustom.Multiline = value; }
            get { return this.txtCustom.Multiline; }
        }

        public void Mayusculas()
        {
            this.txtCustom.CharacterCasing = CharacterCasing.Upper; 
        }

        public void Minusculas()
        {
            this.txtCustom.CharacterCasing = CharacterCasing.Lower;
        }

        public int Count()
        {
           return this.txtCustom.Text.Length; 
        }

        public bool ReadOnly
        {
            set { this.txtCustom.ReadOnly = value; }
            get { return this.txtCustom.ReadOnly; }
        }

        public char Password
        {
            set { this.txtCustom.PasswordChar = value; }
            get { return this.txtCustom.PasswordChar; }
        }

        public void Clear()
        {
            this.txtCustom.Clear();
        }

        private void txtCustom_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.OnMouseDoubleClick(e);
        }

        private void txtCustom_KeyDown(object sender, KeyEventArgs e)
        {
            this.OnKeyDown(e);
        }

        private void txtCustom_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void txtCustom_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }
    }
}
