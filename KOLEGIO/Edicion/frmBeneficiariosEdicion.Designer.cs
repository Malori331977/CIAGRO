namespace KOLEGIO
{
    partial class frmBeneficiariosEdicion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBeneficiariosEdicion));
			this.dtpFechaNacimiento = new Framework.UserControls.dtpSaseg();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtNombre = new Framework.UserControls.txtNormal();
			this.txtCedula = new Framework.UserControls.txtNormal();
			this.txt2Apellido = new Framework.UserControls.txtNormal();
			this.txt1Apellido = new Framework.UserControls.txtNormal();
			this.label33 = new System.Windows.Forms.Label();
			this.txtParentesco = new Framework.UserControls.txtNormal();
			this.label19 = new System.Windows.Forms.Label();
			this.txtEdad = new Framework.UserControls.txtNormal();
			this.label54 = new System.Windows.Forms.Label();
			this.cmbSexo = new Framework.UserControls.cmbSaseg();
			this.label22 = new System.Windows.Forms.Label();
			this.txtPorcentaje = new Framework.UserControls.txtNormal();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.chkRenunciaAjusteFondo = new Framework.UserControls.chkSaseg();
			this.tpDocumento = new System.Windows.Forms.TabPage();
			this.dtpEntrega = new Framework.UserControls.dtpSaseg();
			this.label17 = new System.Windows.Forms.Label();
			this.dtpEmision = new Framework.UserControls.dtpSaseg();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtMonto = new Framework.UserControls.txtNormal();
			this.label14 = new System.Windows.Forms.Label();
			this.txtDocumento = new Framework.UserControls.txtNormal();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label12 = new System.Windows.Forms.Label();
			this.label74 = new System.Windows.Forms.Label();
			this.rtbObservaciones = new Framework.UserControls.rtbSaseg();
			this.txtConsecutivo = new Framework.UserControls.txtNormal();
			((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tpBasicos.SuspendLayout();
			this.tpAdmin.SuspendLayout();
			this.panelBasicos.SuspendLayout();
			this.tpAdjuntos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
			this.tpDocumento.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tpDocumento);
			this.tabControl.Size = new System.Drawing.Size(682, 289);
			this.tabControl.Controls.SetChildIndex(this.tpAdjuntos, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAdmin, 0);
			this.tabControl.Controls.SetChildIndex(this.tpDocumento, 0);
			this.tabControl.Controls.SetChildIndex(this.tpBasicos, 0);
			// 
			// tpBasicos
			// 
			this.tpBasicos.Controls.Add(this.txtConsecutivo);
			this.tpBasicos.Controls.Add(this.label74);
			this.tpBasicos.Controls.Add(this.rtbObservaciones);
			this.tpBasicos.Controls.Add(this.chkRenunciaAjusteFondo);
			this.tpBasicos.Controls.Add(this.label9);
			this.tpBasicos.Controls.Add(this.txtPorcentaje);
			this.tpBasicos.Controls.Add(this.label7);
			this.tpBasicos.Controls.Add(this.txtEdad);
			this.tpBasicos.Controls.Add(this.label54);
			this.tpBasicos.Controls.Add(this.cmbSexo);
			this.tpBasicos.Controls.Add(this.label22);
			this.tpBasicos.Controls.Add(this.label19);
			this.tpBasicos.Controls.Add(this.txtParentesco);
			this.tpBasicos.Controls.Add(this.dtpFechaNacimiento);
			this.tpBasicos.Controls.Add(this.label8);
			this.tpBasicos.Controls.Add(this.label10);
			this.tpBasicos.Controls.Add(this.label11);
			this.tpBasicos.Controls.Add(this.label13);
			this.tpBasicos.Controls.Add(this.txtNombre);
			this.tpBasicos.Controls.Add(this.txtCedula);
			this.tpBasicos.Controls.Add(this.txt2Apellido);
			this.tpBasicos.Controls.Add(this.txt1Apellido);
			this.tpBasicos.Controls.Add(this.label33);
			this.tpBasicos.Size = new System.Drawing.Size(674, 263);
			this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label33, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txt1Apellido, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txt2Apellido, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtCedula, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtNombre, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label13, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label11, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
			this.tpBasicos.Controls.SetChildIndex(this.dtpFechaNacimiento, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtParentesco, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label19, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label22, 0);
			this.tpBasicos.Controls.SetChildIndex(this.cmbSexo, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label54, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtEdad, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label7, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtPorcentaje, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label9, 0);
			this.tpBasicos.Controls.SetChildIndex(this.chkRenunciaAjusteFondo, 0);
			this.tpBasicos.Controls.SetChildIndex(this.rtbObservaciones, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label74, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtConsecutivo, 0);
			// 
			// tpAdmin
			// 
			this.tpAdmin.Size = new System.Drawing.Size(674, 263);
			// 
			// tpAdjuntos
			// 
			this.tpAdjuntos.Size = new System.Drawing.Size(674, 263);
			// 
			// dtpFechaNacimiento
			// 
			this.dtpFechaNacimiento.Checked = false;
			this.dtpFechaNacimiento.Location = new System.Drawing.Point(138, 140);
			this.dtpFechaNacimiento.mostrarCheckBox = false;
			this.dtpFechaNacimiento.mostrarUpDown = false;
			this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
			this.dtpFechaNacimiento.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaNacimiento.TabIndex = 6;
			this.dtpFechaNacimiento.Value = new System.DateTime(2016, 9, 20, 13, 40, 18, 332);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(78, 91);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 13);
			this.label8.TabIndex = 56;
			this.label8.Text = "Nombre:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(37, 35);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(95, 13);
			this.label10.TabIndex = 58;
			this.label10.Text = "Primer Apellido:";
			this.label10.Visible = false;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(296, 35);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(93, 13);
			this.label11.TabIndex = 60;
			this.label11.Text = "Segundo Apellido:";
			this.label11.Visible = false;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(82, 63);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(50, 13);
			this.label13.TabIndex = 63;
			this.label13.Text = "Cédula:";
			// 
			// txtNombre
			// 
			this.txtNombre.FormatearNumero = false;
			this.txtNombre.Location = new System.Drawing.Point(138, 86);
			this.txtNombre.Longitud = 20;
			this.txtNombre.Multilinea = false;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Password = '\0';
			this.txtNombre.ReadOnly = false;
			this.txtNombre.Size = new System.Drawing.Size(220, 21);
			this.txtNombre.TabIndex = 2;
			this.txtNombre.Valor = "";
			// 
			// txtCedula
			// 
			this.txtCedula.FormatearNumero = false;
			this.txtCedula.Location = new System.Drawing.Point(138, 59);
			this.txtCedula.Longitud = 20;
			this.txtCedula.Multilinea = false;
			this.txtCedula.Name = "txtCedula";
			this.txtCedula.Password = '\0';
			this.txtCedula.ReadOnly = false;
			this.txtCedula.Size = new System.Drawing.Size(155, 21);
			this.txtCedula.TabIndex = 1;
			this.txtCedula.Valor = "";
			this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
			this.txtCedula.Leave += new System.EventHandler(this.txtCedula_Leave);
			// 
			// txt2Apellido
			// 
			this.txt2Apellido.FormatearNumero = false;
			this.txt2Apellido.Location = new System.Drawing.Point(395, 30);
			this.txt2Apellido.Longitud = 30;
			this.txt2Apellido.Multilinea = false;
			this.txt2Apellido.Name = "txt2Apellido";
			this.txt2Apellido.Password = '\0';
			this.txt2Apellido.ReadOnly = false;
			this.txt2Apellido.Size = new System.Drawing.Size(155, 21);
			this.txt2Apellido.TabIndex = 4;
			this.txt2Apellido.Valor = "";
			this.txt2Apellido.Visible = false;
			// 
			// txt1Apellido
			// 
			this.txt1Apellido.FormatearNumero = false;
			this.txt1Apellido.Location = new System.Drawing.Point(138, 31);
			this.txt1Apellido.Longitud = 30;
			this.txt1Apellido.Multilinea = false;
			this.txt1Apellido.Name = "txt1Apellido";
			this.txt1Apellido.Password = '\0';
			this.txt1Apellido.ReadOnly = false;
			this.txt1Apellido.Size = new System.Drawing.Size(155, 21);
			this.txt1Apellido.TabIndex = 3;
			this.txt1Apellido.Valor = "";
			this.txt1Apellido.Visible = false;
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(32, 145);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(100, 13);
			this.label33.TabIndex = 64;
			this.label33.Text = "Fecha de Inclusión:";
			// 
			// txtParentesco
			// 
			this.txtParentesco.FormatearNumero = false;
			this.txtParentesco.Location = new System.Drawing.Point(138, 114);
			this.txtParentesco.Longitud = 30;
			this.txtParentesco.Multilinea = false;
			this.txtParentesco.Name = "txtParentesco";
			this.txtParentesco.Password = '\0';
			this.txtParentesco.ReadOnly = false;
			this.txtParentesco.Size = new System.Drawing.Size(220, 21);
			this.txtParentesco.TabIndex = 9;
			this.txtParentesco.Valor = "";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label19.Location = new System.Drawing.Point(57, 118);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(75, 13);
			this.label19.TabIndex = 84;
			this.label19.Text = "Parentesco:";
			// 
			// txtEdad
			// 
			this.txtEdad.FormatearNumero = false;
			this.txtEdad.Location = new System.Drawing.Point(433, 140);
			this.txtEdad.Longitud = 4;
			this.txtEdad.Multilinea = false;
			this.txtEdad.Name = "txtEdad";
			this.txtEdad.Password = '\0';
			this.txtEdad.ReadOnly = true;
			this.txtEdad.Size = new System.Drawing.Size(47, 21);
			this.txtEdad.TabIndex = 7;
			this.txtEdad.Valor = "";
			this.txtEdad.Visible = false;
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.Location = new System.Drawing.Point(392, 144);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(35, 13);
			this.label54.TabIndex = 277;
			this.label54.Text = "Edad:";
			this.label54.Visible = false;
			// 
			// cmbSexo
			// 
			this.cmbSexo.Habilitar = true;
			this.cmbSexo.Index = -1;
			this.cmbSexo.Location = new System.Drawing.Point(433, 86);
			this.cmbSexo.Name = "cmbSexo";
			this.cmbSexo.Size = new System.Drawing.Size(101, 22);
			this.cmbSexo.TabIndex = 5;
			this.cmbSexo.Texto = "";
			this.cmbSexo.Valor = "";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(382, 91);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(45, 13);
			this.label22.TabIndex = 276;
			this.label22.Text = "Género:";
			// 
			// txtPorcentaje
			// 
			this.txtPorcentaje.FormatearNumero = true;
			this.txtPorcentaje.Location = new System.Drawing.Point(433, 114);
			this.txtPorcentaje.Longitud = 5;
			this.txtPorcentaje.Multilinea = false;
			this.txtPorcentaje.Name = "txtPorcentaje";
			this.txtPorcentaje.Password = '\0';
			this.txtPorcentaje.ReadOnly = false;
			this.txtPorcentaje.Size = new System.Drawing.Size(65, 21);
			this.txtPorcentaje.TabIndex = 8;
			this.txtPorcentaje.Valor = "";
			this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(366, 119);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 13);
			this.label7.TabIndex = 279;
			this.label7.Text = "Porcentaje:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(504, 118);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(15, 13);
			this.label9.TabIndex = 280;
			this.label9.Text = "%";
			// 
			// chkRenunciaAjusteFondo
			// 
			this.chkRenunciaAjusteFondo.Checked = false;
			this.chkRenunciaAjusteFondo.Location = new System.Drawing.Point(369, 59);
			this.chkRenunciaAjusteFondo.Name = "chkRenunciaAjusteFondo";
			this.chkRenunciaAjusteFondo.Size = new System.Drawing.Size(195, 17);
			this.chkRenunciaAjusteFondo.TabIndex = 281;
			this.chkRenunciaAjusteFondo.Texto = "Renuncia al ajuste del fondo";
			this.chkRenunciaAjusteFondo.Visible = false;
			// 
			// tpDocumento
			// 
			this.tpDocumento.Controls.Add(this.dtpEntrega);
			this.tpDocumento.Controls.Add(this.label17);
			this.tpDocumento.Controls.Add(this.dtpEmision);
			this.tpDocumento.Controls.Add(this.label16);
			this.tpDocumento.Controls.Add(this.label15);
			this.tpDocumento.Controls.Add(this.txtMonto);
			this.tpDocumento.Controls.Add(this.label14);
			this.tpDocumento.Controls.Add(this.txtDocumento);
			this.tpDocumento.Controls.Add(this.panel2);
			this.tpDocumento.Location = new System.Drawing.Point(4, 22);
			this.tpDocumento.Name = "tpDocumento";
			this.tpDocumento.Size = new System.Drawing.Size(674, 263);
			this.tpDocumento.TabIndex = 3;
			this.tpDocumento.Text = "Documento";
			this.tpDocumento.UseVisualStyleBackColor = true;
			// 
			// dtpEntrega
			// 
			this.dtpEntrega.Checked = false;
			this.dtpEntrega.Location = new System.Drawing.Point(249, 152);
			this.dtpEntrega.mostrarCheckBox = true;
			this.dtpEntrega.mostrarUpDown = false;
			this.dtpEntrega.Name = "dtpEntrega";
			this.dtpEntrega.Size = new System.Drawing.Size(101, 22);
			this.dtpEntrega.TabIndex = 67;
			this.dtpEntrega.Value = new System.DateTime(2016, 9, 20, 13, 40, 18, 332);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(148, 155);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(95, 13);
			this.label17.TabIndex = 68;
			this.label17.Text = "Fecha de Entrega:";
			// 
			// dtpEmision
			// 
			this.dtpEmision.Checked = false;
			this.dtpEmision.Location = new System.Drawing.Point(249, 124);
			this.dtpEmision.mostrarCheckBox = true;
			this.dtpEmision.mostrarUpDown = false;
			this.dtpEmision.Name = "dtpEmision";
			this.dtpEmision.Size = new System.Drawing.Size(101, 22);
			this.dtpEmision.TabIndex = 65;
			this.dtpEmision.Value = new System.DateTime(2016, 9, 20, 13, 40, 18, 332);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(149, 127);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(94, 13);
			this.label16.TabIndex = 66;
			this.label16.Text = "Fecha de Emisión:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(203, 101);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 13);
			this.label15.TabIndex = 64;
			this.label15.Text = "Monto:";
			// 
			// txtMonto
			// 
			this.txtMonto.FormatearNumero = true;
			this.txtMonto.Location = new System.Drawing.Point(249, 97);
			this.txtMonto.Longitud = 30;
			this.txtMonto.Multilinea = false;
			this.txtMonto.Name = "txtMonto";
			this.txtMonto.Password = '\0';
			this.txtMonto.ReadOnly = false;
			this.txtMonto.Size = new System.Drawing.Size(155, 21);
			this.txtMonto.TabIndex = 63;
			this.txtMonto.Valor = "";
			this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(178, 75);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(65, 13);
			this.label14.TabIndex = 62;
			this.label14.Text = "Documento:";
			// 
			// txtDocumento
			// 
			this.txtDocumento.FormatearNumero = false;
			this.txtDocumento.Location = new System.Drawing.Point(249, 70);
			this.txtDocumento.Longitud = 30;
			this.txtDocumento.Multilinea = false;
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Password = '\0';
			this.txtDocumento.ReadOnly = false;
			this.txtDocumento.Size = new System.Drawing.Size(155, 21);
			this.txtDocumento.TabIndex = 61;
			this.txtDocumento.Valor = "";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.DarkGray;
			this.panel2.Controls.Add(this.label12);
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(668, 21);
			this.panel2.TabIndex = 42;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label12.Location = new System.Drawing.Point(3, 4);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(142, 14);
			this.label12.TabIndex = 0;
			this.label12.Text = "Información Documento";
			// 
			// label74
			// 
			this.label74.Location = new System.Drawing.Point(51, 168);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(81, 13);
			this.label74.TabIndex = 305;
			this.label74.Text = "Observaciones:";
			// 
			// rtbObservaciones
			// 
			this.rtbObservaciones.Location = new System.Drawing.Point(138, 168);
			this.rtbObservaciones.Longitud = 2147483647;
			this.rtbObservaciones.Mayusculas = false;
			this.rtbObservaciones.Name = "rtbObservaciones";
			this.rtbObservaciones.ReadOnly = false;
			this.rtbObservaciones.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.18362}\\viewkind4\\uc1 \r\n\\par" +
    "d\\f0\\fs17\\par\r\n}\r\n";
			this.rtbObservaciones.Size = new System.Drawing.Size(418, 66);
			this.rtbObservaciones.TabIndex = 304;
			// 
			// txtConsecutivo
			// 
			this.txtConsecutivo.FormatearNumero = false;
			this.txtConsecutivo.Location = new System.Drawing.Point(579, 30);
			this.txtConsecutivo.Longitud = 20;
			this.txtConsecutivo.Multilinea = false;
			this.txtConsecutivo.Name = "txtConsecutivo";
			this.txtConsecutivo.Password = '\0';
			this.txtConsecutivo.ReadOnly = false;
			this.txtConsecutivo.Size = new System.Drawing.Size(75, 21);
			this.txtConsecutivo.TabIndex = 306;
			this.txtConsecutivo.Valor = "";
			this.txtConsecutivo.Visible = false;
			// 
			// frmBeneficiariosEdicion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(682, 380);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmBeneficiariosEdicion";
			this.Text = "frmDependientesEdicion";
			this.Load += new System.EventHandler(this.frmDependientesEdicion_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tpBasicos.ResumeLayout(false);
			this.tpBasicos.PerformLayout();
			this.tpAdmin.ResumeLayout(false);
			this.tpAdmin.PerformLayout();
			this.panelBasicos.ResumeLayout(false);
			this.panelBasicos.PerformLayout();
			this.tpAdjuntos.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.flvListado)).EndInit();
			this.tpDocumento.ResumeLayout(false);
			this.tpDocumento.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Framework.UserControls.dtpSaseg dtpFechaNacimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private Framework.UserControls.txtNormal txtNombre;
        private Framework.UserControls.txtNormal txtCedula;
        private Framework.UserControls.txtNormal txt2Apellido;
        private Framework.UserControls.txtNormal txt1Apellido;
        private System.Windows.Forms.Label label33;
        private Framework.UserControls.txtNormal txtParentesco;
        private System.Windows.Forms.Label label19;
        private Framework.UserControls.txtNormal txtEdad;
        private System.Windows.Forms.Label label54;
        private Framework.UserControls.cmbSaseg cmbSexo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label9;
        private Framework.UserControls.txtNormal txtPorcentaje;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.chkSaseg chkRenunciaAjusteFondo;
        private System.Windows.Forms.TabPage tpDocumento;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private Framework.UserControls.dtpSaseg dtpEntrega;
        private System.Windows.Forms.Label label17;
        private Framework.UserControls.dtpSaseg dtpEmision;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private Framework.UserControls.txtNormal txtMonto;
        private System.Windows.Forms.Label label14;
        private Framework.UserControls.txtNormal txtDocumento;
        private System.Windows.Forms.Label label74;
        private Framework.UserControls.rtbSaseg rtbObservaciones;
		private Framework.UserControls.txtNormal txtConsecutivo;
	}
}