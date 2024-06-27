namespace KOLEGIO
{
    partial class frmPeritosEdicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeritosEdicion));
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreColegiado = new Framework.UserControls.txtNormal();
            this.txtNumColegiado = new Framework.UserControls.txtNormal();
            this.cmbTipo = new Framework.UserControls.cmbSaseg();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInstitucion = new Framework.UserControls.txtNormal();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombreInstitucion = new Framework.UserControls.txtNormal();
            this.txtCobrador = new Framework.UserControls.txtNormal();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCobradorNombre = new Framework.UserControls.txtNormal();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSesionAprob = new Framework.UserControls.txtNormal();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpAprobacion = new Framework.UserControls.dtpSaseg();
            this.dtpRenovacion = new Framework.UserControls.dtpSaseg();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSesionRenov = new Framework.UserControls.txtNormal();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpPerdida = new Framework.UserControls.dtpSaseg();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSesionPerdida = new Framework.UserControls.txtNormal();
            this.label16 = new System.Windows.Forms.Label();
            this.rtbObservaciones = new Framework.UserControls.rtbSaseg();
            this.label17 = new System.Windows.Forms.Label();
            this.chkCurso = new Framework.UserControls.chkSaseg();
            this.txtNColegiado = new Framework.UserControls.txtNormal();
            this.tpLibProtocolos = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.btnNuevoLibro = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarLibro = new System.Windows.Forms.ToolStripButton();
            this.dgvProtocolos = new System.Windows.Forms.DataGridView();
            this.colCodigoProtocolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAsiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLibCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaApertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObservacionesProtocolo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tpBasicos.SuspendLayout();
            this.tpAdmin.SuspendLayout();
            this.panelBasicos.SuspendLayout();
            this.tpAdjuntos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
            this.tpLibProtocolos.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.toolStrip8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProtocolos)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpLibProtocolos);
            this.tabControl.Size = new System.Drawing.Size(885, 400);
            this.tabControl.Controls.SetChildIndex(this.tpLibProtocolos, 0);
            this.tabControl.Controls.SetChildIndex(this.tpAdjuntos, 0);
            this.tabControl.Controls.SetChildIndex(this.tpAdmin, 0);
            this.tabControl.Controls.SetChildIndex(this.tpBasicos, 0);
            // 
            // tpBasicos
            // 
            this.tpBasicos.Controls.Add(this.txtNColegiado);
            this.tpBasicos.Controls.Add(this.chkCurso);
            this.tpBasicos.Controls.Add(this.label17);
            this.tpBasicos.Controls.Add(this.rtbObservaciones);
            this.tpBasicos.Controls.Add(this.dtpPerdida);
            this.tpBasicos.Controls.Add(this.label15);
            this.tpBasicos.Controls.Add(this.txtSesionPerdida);
            this.tpBasicos.Controls.Add(this.label16);
            this.tpBasicos.Controls.Add(this.dtpRenovacion);
            this.tpBasicos.Controls.Add(this.label13);
            this.tpBasicos.Controls.Add(this.txtSesionRenov);
            this.tpBasicos.Controls.Add(this.label14);
            this.tpBasicos.Controls.Add(this.dtpAprobacion);
            this.tpBasicos.Controls.Add(this.label12);
            this.tpBasicos.Controls.Add(this.txtSesionAprob);
            this.tpBasicos.Controls.Add(this.label11);
            this.tpBasicos.Controls.Add(this.txtCobrador);
            this.tpBasicos.Controls.Add(this.label10);
            this.tpBasicos.Controls.Add(this.txtCobradorNombre);
            this.tpBasicos.Controls.Add(this.txtInstitucion);
            this.tpBasicos.Controls.Add(this.label9);
            this.tpBasicos.Controls.Add(this.txtNombreInstitucion);
            this.tpBasicos.Controls.Add(this.label8);
            this.tpBasicos.Controls.Add(this.cmbTipo);
            this.tpBasicos.Controls.Add(this.txtNumColegiado);
            this.tpBasicos.Controls.Add(this.label7);
            this.tpBasicos.Controls.Add(this.txtNombreColegiado);
            this.tpBasicos.Size = new System.Drawing.Size(877, 374);
            this.tpBasicos.Controls.SetChildIndex(this.txtNombreColegiado, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label7, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNumColegiado, 0);
            this.tpBasicos.Controls.SetChildIndex(this.cmbTipo, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label8, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNombreInstitucion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label9, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtInstitucion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCobradorNombre, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtCobrador, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label11, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtSesionAprob, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label12, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dtpAprobacion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label14, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtSesionRenov, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label13, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dtpRenovacion, 0);
            this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label16, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtSesionPerdida, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label15, 0);
            this.tpBasicos.Controls.SetChildIndex(this.dtpPerdida, 0);
            this.tpBasicos.Controls.SetChildIndex(this.rtbObservaciones, 0);
            this.tpBasicos.Controls.SetChildIndex(this.label17, 0);
            this.tpBasicos.Controls.SetChildIndex(this.chkCurso, 0);
            this.tpBasicos.Controls.SetChildIndex(this.txtNColegiado, 0);
            // 
            // tpAdmin
            // 
            this.tpAdmin.Size = new System.Drawing.Size(877, 374);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Size = new System.Drawing.Size(871, 21);
            // 
            // panelBasicos
            // 
            this.panelBasicos.Size = new System.Drawing.Size(871, 21);
            // 
            // tpAdjuntos
            // 
            this.tpAdjuntos.Size = new System.Drawing.Size(877, 374);
            // 
            // panelAdjuntos
            // 
            this.panelAdjuntos.Size = new System.Drawing.Size(871, 21);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(168, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nº Colegiado:";
            // 
            // txtNombreColegiado
            // 
            this.txtNombreColegiado.FormatearNumero = false;
            this.txtNombreColegiado.Location = new System.Drawing.Point(373, 69);
            this.txtNombreColegiado.Longitud = 30;
            this.txtNombreColegiado.Multilinea = false;
            this.txtNombreColegiado.Name = "txtNombreColegiado";
            this.txtNombreColegiado.Password = '\0';
            this.txtNombreColegiado.ReadOnly = true;
            this.txtNombreColegiado.Size = new System.Drawing.Size(300, 21);
            this.txtNombreColegiado.TabIndex = 5;
            this.txtNombreColegiado.Valor = "";
            // 
            // txtNumColegiado
            // 
            this.txtNumColegiado.FormatearNumero = false;
            this.txtNumColegiado.Location = new System.Drawing.Point(259, 42);
            this.txtNumColegiado.Longitud = 30;
            this.txtNumColegiado.Multilinea = false;
            this.txtNumColegiado.Name = "txtNumColegiado";
            this.txtNumColegiado.Password = '\0';
            this.txtNumColegiado.ReadOnly = false;
            this.txtNumColegiado.Size = new System.Drawing.Size(112, 21);
            this.txtNumColegiado.TabIndex = 7;
            this.txtNumColegiado.Valor = "";
            this.txtNumColegiado.Visible = false;
            this.txtNumColegiado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumColegiado_KeyDown);
            this.txtNumColegiado.Leave += new System.EventHandler(this.txtNumColegiado_Leave);
            this.txtNumColegiado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtNumColegiado_MouseDoubleClick);
            // 
            // cmbTipo
            // 
            this.cmbTipo.Habilitar = true;
            this.cmbTipo.Index = -1;
            this.cmbTipo.Location = new System.Drawing.Point(259, 96);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(112, 22);
            this.cmbTipo.TabIndex = 8;
            this.cmbTipo.Texto = "";
            this.cmbTipo.Valor = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(217, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tipo:";
            // 
            // txtInstitucion
            // 
            this.txtInstitucion.FormatearNumero = false;
            this.txtInstitucion.Location = new System.Drawing.Point(259, 123);
            this.txtInstitucion.Longitud = 30;
            this.txtInstitucion.Multilinea = false;
            this.txtInstitucion.Name = "txtInstitucion";
            this.txtInstitucion.Password = '\0';
            this.txtInstitucion.ReadOnly = false;
            this.txtInstitucion.Size = new System.Drawing.Size(112, 21);
            this.txtInstitucion.TabIndex = 12;
            this.txtInstitucion.Valor = "";
            this.txtInstitucion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInstitucion_KeyDown);
            this.txtInstitucion.Leave += new System.EventHandler(this.txtInstitucion_Leave);
            this.txtInstitucion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtInstitucion_MouseDoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(183, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Institución:";
            // 
            // txtNombreInstitucion
            // 
            this.txtNombreInstitucion.FormatearNumero = false;
            this.txtNombreInstitucion.Location = new System.Drawing.Point(373, 123);
            this.txtNombreInstitucion.Longitud = 30;
            this.txtNombreInstitucion.Multilinea = false;
            this.txtNombreInstitucion.Name = "txtNombreInstitucion";
            this.txtNombreInstitucion.Password = '\0';
            this.txtNombreInstitucion.ReadOnly = true;
            this.txtNombreInstitucion.Size = new System.Drawing.Size(300, 21);
            this.txtNombreInstitucion.TabIndex = 10;
            this.txtNombreInstitucion.Valor = "";
            // 
            // txtCobrador
            // 
            this.txtCobrador.FormatearNumero = false;
            this.txtCobrador.Location = new System.Drawing.Point(259, 149);
            this.txtCobrador.Longitud = 30;
            this.txtCobrador.Multilinea = false;
            this.txtCobrador.Name = "txtCobrador";
            this.txtCobrador.Password = '\0';
            this.txtCobrador.ReadOnly = false;
            this.txtCobrador.Size = new System.Drawing.Size(112, 21);
            this.txtCobrador.TabIndex = 15;
            this.txtCobrador.Valor = "";
            this.txtCobrador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCobrador_KeyDown);
            this.txtCobrador.Leave += new System.EventHandler(this.txtCobrador_Leave);
            this.txtCobrador.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCobrador_MouseDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(191, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Cobrador:";
            // 
            // txtCobradorNombre
            // 
            this.txtCobradorNombre.FormatearNumero = false;
            this.txtCobradorNombre.Location = new System.Drawing.Point(373, 149);
            this.txtCobradorNombre.Longitud = 30;
            this.txtCobradorNombre.Multilinea = false;
            this.txtCobradorNombre.Name = "txtCobradorNombre";
            this.txtCobradorNombre.Password = '\0';
            this.txtCobradorNombre.ReadOnly = true;
            this.txtCobradorNombre.Size = new System.Drawing.Size(300, 21);
            this.txtCobradorNombre.TabIndex = 13;
            this.txtCobradorNombre.Valor = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(154, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Sesión Aprobación:";
            // 
            // txtSesionAprob
            // 
            this.txtSesionAprob.FormatearNumero = false;
            this.txtSesionAprob.Location = new System.Drawing.Point(259, 184);
            this.txtSesionAprob.Longitud = 30;
            this.txtSesionAprob.Multilinea = false;
            this.txtSesionAprob.Name = "txtSesionAprob";
            this.txtSesionAprob.Password = '\0';
            this.txtSesionAprob.ReadOnly = false;
            this.txtSesionAprob.Size = new System.Drawing.Size(112, 21);
            this.txtSesionAprob.TabIndex = 17;
            this.txtSesionAprob.Valor = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(377, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Fecha Aprobación:";
            // 
            // dtpAprobacion
            // 
            this.dtpAprobacion.Checked = true;
            this.dtpAprobacion.Location = new System.Drawing.Point(480, 184);
            this.dtpAprobacion.mostrarCheckBox = false;
            this.dtpAprobacion.mostrarUpDown = false;
            this.dtpAprobacion.Name = "dtpAprobacion";
            this.dtpAprobacion.Size = new System.Drawing.Size(96, 22);
            this.dtpAprobacion.TabIndex = 19;
            this.dtpAprobacion.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
            // 
            // dtpRenovacion
            // 
            this.dtpRenovacion.Checked = false;
            this.dtpRenovacion.Location = new System.Drawing.Point(480, 212);
            this.dtpRenovacion.mostrarCheckBox = true;
            this.dtpRenovacion.mostrarUpDown = false;
            this.dtpRenovacion.Name = "dtpRenovacion";
            this.dtpRenovacion.Size = new System.Drawing.Size(96, 22);
            this.dtpRenovacion.TabIndex = 23;
            this.dtpRenovacion.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(373, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Fecha Renovación:";
            // 
            // txtSesionRenov
            // 
            this.txtSesionRenov.FormatearNumero = false;
            this.txtSesionRenov.Location = new System.Drawing.Point(259, 211);
            this.txtSesionRenov.Longitud = 30;
            this.txtSesionRenov.Multilinea = false;
            this.txtSesionRenov.Name = "txtSesionRenov";
            this.txtSesionRenov.Password = '\0';
            this.txtSesionRenov.ReadOnly = false;
            this.txtSesionRenov.Size = new System.Drawing.Size(112, 21);
            this.txtSesionRenov.TabIndex = 21;
            this.txtSesionRenov.Valor = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(150, 214);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Sesión Renovación:";
            // 
            // dtpPerdida
            // 
            this.dtpPerdida.Checked = false;
            this.dtpPerdida.Location = new System.Drawing.Point(480, 237);
            this.dtpPerdida.mostrarCheckBox = true;
            this.dtpPerdida.mostrarUpDown = false;
            this.dtpPerdida.Name = "dtpPerdida";
            this.dtpPerdida.Size = new System.Drawing.Size(96, 22);
            this.dtpPerdida.TabIndex = 27;
            this.dtpPerdida.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(395, 241);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Fecha Pérdida:";
            // 
            // txtSesionPerdida
            // 
            this.txtSesionPerdida.FormatearNumero = false;
            this.txtSesionPerdida.Location = new System.Drawing.Point(259, 238);
            this.txtSesionPerdida.Longitud = 30;
            this.txtSesionPerdida.Multilinea = false;
            this.txtSesionPerdida.Name = "txtSesionPerdida";
            this.txtSesionPerdida.Password = '\0';
            this.txtSesionPerdida.ReadOnly = false;
            this.txtSesionPerdida.Size = new System.Drawing.Size(112, 21);
            this.txtSesionPerdida.TabIndex = 25;
            this.txtSesionPerdida.Valor = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(172, 241);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Sesión Pérdida:";
            // 
            // rtbObservaciones
            // 
            this.rtbObservaciones.Location = new System.Drawing.Point(259, 265);
            this.rtbObservaciones.Longitud = 2147483647;
            this.rtbObservaciones.Mayusculas = false;
            this.rtbObservaciones.Name = "rtbObservaciones";
            this.rtbObservaciones.ReadOnly = false;
            this.rtbObservaciones.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Microsoft S" +
    "ans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17\\par\r\n}\r\n";
            this.rtbObservaciones.Size = new System.Drawing.Size(414, 66);
            this.rtbObservaciones.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(172, 274);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "Observaciones:";
            // 
            // chkCurso
            // 
            this.chkCurso.Checked = false;
            this.chkCurso.Location = new System.Drawing.Point(380, 98);
            this.chkCurso.Name = "chkCurso";
            this.chkCurso.Size = new System.Drawing.Size(139, 17);
            this.chkCurso.TabIndex = 30;
            this.chkCurso.Texto = "Curso Avalúos Peritaje";
            // 
            // txtNColegiado
            // 
            this.txtNColegiado.FormatearNumero = false;
            this.txtNColegiado.Location = new System.Drawing.Point(259, 69);
            this.txtNColegiado.Longitud = 30;
            this.txtNColegiado.Multilinea = false;
            this.txtNColegiado.Name = "txtNColegiado";
            this.txtNColegiado.Password = '\0';
            this.txtNColegiado.ReadOnly = false;
            this.txtNColegiado.Size = new System.Drawing.Size(112, 21);
            this.txtNColegiado.TabIndex = 31;
            this.txtNColegiado.Valor = "";
            this.txtNColegiado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumColegiado_KeyDown);
            this.txtNColegiado.Leave += new System.EventHandler(this.txtNumColegiado_Leave);
            this.txtNColegiado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtNumColegiado_MouseDoubleClick);
            // 
            // tpLibProtocolos
            // 
            this.tpLibProtocolos.Controls.Add(this.groupBox6);
            this.tpLibProtocolos.Controls.Add(this.panel8);
            this.tpLibProtocolos.Location = new System.Drawing.Point(4, 22);
            this.tpLibProtocolos.Name = "tpLibProtocolos";
            this.tpLibProtocolos.Size = new System.Drawing.Size(877, 374);
            this.tpLibProtocolos.TabIndex = 3;
            this.tpLibProtocolos.Text = "Libros Protocolo";
            this.tpLibProtocolos.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.panel9);
            this.groupBox6.Controls.Add(this.dgvProtocolos);
            this.groupBox6.Location = new System.Drawing.Point(0, 58);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(874, 307);
            this.groupBox6.TabIndex = 49;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Libros Protocolo";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.toolStrip8);
            this.panel9.Location = new System.Drawing.Point(6, 17);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(135, 28);
            this.panel9.TabIndex = 45;
            // 
            // toolStrip8
            // 
            this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoLibro,
            this.btnEliminarLibro});
            this.toolStrip8.Location = new System.Drawing.Point(0, 0);
            this.toolStrip8.Name = "toolStrip8";
            this.toolStrip8.Size = new System.Drawing.Size(135, 25);
            this.toolStrip8.TabIndex = 0;
            this.toolStrip8.Text = "toolStrip8";
            // 
            // btnNuevoLibro
            // 
            this.btnNuevoLibro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevoLibro.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoLibro.Image")));
            this.btnNuevoLibro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoLibro.Name = "btnNuevoLibro";
            this.btnNuevoLibro.Size = new System.Drawing.Size(23, 22);
            this.btnNuevoLibro.Text = "Nuevo";
            this.btnNuevoLibro.Click += new System.EventHandler(this.btnNuevoLibro_Click);
            // 
            // btnEliminarLibro
            // 
            this.btnEliminarLibro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarLibro.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarLibro.Image")));
            this.btnEliminarLibro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarLibro.Name = "btnEliminarLibro";
            this.btnEliminarLibro.Size = new System.Drawing.Size(23, 22);
            this.btnEliminarLibro.Text = "Eliminar";
            this.btnEliminarLibro.Click += new System.EventHandler(this.btnEliminarLibro_Click);
            // 
            // dgvProtocolos
            // 
            this.dgvProtocolos.AllowUserToAddRows = false;
            this.dgvProtocolos.AllowUserToDeleteRows = false;
            this.dgvProtocolos.AllowUserToResizeRows = false;
            this.dgvProtocolos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProtocolos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProtocolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProtocolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoProtocolo,
            this.colLibro,
            this.colFolio,
            this.colAsiento,
            this.colLibCol,
            this.colFechaApertura,
            this.colFechaCierre,
            this.colObservacionesProtocolo});
            this.dgvProtocolos.Location = new System.Drawing.Point(3, 44);
            this.dgvProtocolos.Name = "dgvProtocolos";
            this.dgvProtocolos.RowHeadersVisible = false;
            this.dgvProtocolos.Size = new System.Drawing.Size(871, 257);
            this.dgvProtocolos.TabIndex = 0;
            this.dgvProtocolos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProtocolos_CellClick);
            this.dgvProtocolos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvProtocolos_CurrentCellDirtyStateChanged);
            // 
            // colCodigoProtocolo
            // 
            this.colCodigoProtocolo.FillWeight = 94.52837F;
            this.colCodigoProtocolo.HeaderText = "Código";
            this.colCodigoProtocolo.Name = "colCodigoProtocolo";
            // 
            // colLibro
            // 
            this.colLibro.FillWeight = 100.8535F;
            this.colLibro.HeaderText = "Libro";
            this.colLibro.Name = "colLibro";
            // 
            // colFolio
            // 
            this.colFolio.FillWeight = 70.89241F;
            this.colFolio.HeaderText = "Folio";
            this.colFolio.Name = "colFolio";
            // 
            // colAsiento
            // 
            this.colAsiento.FillWeight = 70.89241F;
            this.colAsiento.HeaderText = "Asiento";
            this.colAsiento.Name = "colAsiento";
            // 
            // colLibCol
            // 
            this.colLibCol.FillWeight = 70.89241F;
            this.colLibCol.HeaderText = "Lib. Col";
            this.colLibCol.Name = "colLibCol";
            // 
            // colFechaApertura
            // 
            this.colFechaApertura.FillWeight = 70.89241F;
            this.colFechaApertura.HeaderText = "Fecha Apertura";
            this.colFechaApertura.Name = "colFechaApertura";
            // 
            // colFechaCierre
            // 
            this.colFechaCierre.FillWeight = 70.89241F;
            this.colFechaCierre.HeaderText = "Fecha Cierre";
            this.colFechaCierre.Name = "colFechaCierre";
            // 
            // colObservacionesProtocolo
            // 
            this.colObservacionesProtocolo.FillWeight = 240.8075F;
            this.colObservacionesProtocolo.HeaderText = "Observaciones";
            this.colObservacionesProtocolo.Name = "colObservacionesProtocolo";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.DarkGray;
            this.panel8.Controls.Add(this.label18);
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(871, 24);
            this.panel8.TabIndex = 47;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label18.Location = new System.Drawing.Point(3, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(206, 14);
            this.label18.TabIndex = 0;
            this.label18.Text = "Información de Libros de Protocolo";
            // 
            // frmPeritosEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 491);
            this.Name = "frmPeritosEdicion";
            this.Text = "frmPeritosEdicion";
            this.Load += new System.EventHandler(this.frmPeritosEdicion_Load);
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
            this.tpLibProtocolos.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.toolStrip8.ResumeLayout(false);
            this.toolStrip8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProtocolos)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private Framework.UserControls.txtNormal txtNombreColegiado;
        private Framework.UserControls.txtNormal txtNumColegiado;
        private System.Windows.Forms.Label label8;
        private Framework.UserControls.cmbSaseg cmbTipo;
        private Framework.UserControls.txtNormal txtInstitucion;
        private System.Windows.Forms.Label label9;
        private Framework.UserControls.txtNormal txtNombreInstitucion;
        private Framework.UserControls.txtNormal txtCobrador;
        private System.Windows.Forms.Label label10;
        private Framework.UserControls.txtNormal txtCobradorNombre;
        private System.Windows.Forms.Label label11;
        private Framework.UserControls.dtpSaseg dtpAprobacion;
        private System.Windows.Forms.Label label12;
        private Framework.UserControls.txtNormal txtSesionAprob;
        private Framework.UserControls.dtpSaseg dtpPerdida;
        private System.Windows.Forms.Label label15;
        private Framework.UserControls.txtNormal txtSesionPerdida;
        private System.Windows.Forms.Label label16;
        private Framework.UserControls.dtpSaseg dtpRenovacion;
        private System.Windows.Forms.Label label13;
        private Framework.UserControls.txtNormal txtSesionRenov;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private Framework.UserControls.rtbSaseg rtbObservaciones;
        private Framework.UserControls.chkSaseg chkCurso;
        private Framework.UserControls.txtNormal txtNColegiado;
        private System.Windows.Forms.TabPage tpLibProtocolos;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton btnNuevoLibro;
        private System.Windows.Forms.ToolStripButton btnEliminarLibro;
        private System.Windows.Forms.DataGridView dgvProtocolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoProtocolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLibCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaApertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacionesProtocolo;
    }
}