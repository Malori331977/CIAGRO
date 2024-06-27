namespace KOLEGIO
{
    partial class frmRegentesEdicion
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegentesEdicion));
			this.chkCurso = new Framework.UserControls.chkSaseg();
			this.dtpPerdida = new Framework.UserControls.dtpSaseg();
			this.label15 = new System.Windows.Forms.Label();
			this.txtSesionPerdida = new Framework.UserControls.txtNormal();
			this.label16 = new System.Windows.Forms.Label();
			this.dtpAprobacion = new Framework.UserControls.dtpSaseg();
			this.label12 = new System.Windows.Forms.Label();
			this.txtSesionAprob = new Framework.UserControls.txtNormal();
			this.label11 = new System.Windows.Forms.Label();
			this.txtCobrador = new Framework.UserControls.txtNormal();
			this.label10 = new System.Windows.Forms.Label();
			this.txtCobradorNombre = new Framework.UserControls.txtNormal();
			this.txtNumColegiado = new Framework.UserControls.txtNormal();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNombreColegiado = new Framework.UserControls.txtNormal();
			this.tpEstablecimientos = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.toolStrip6 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoVisita = new System.Windows.Forms.ToolStripButton();
			this.btnEliminaVisita = new System.Windows.Forms.ToolStripButton();
			this.dgvVisitasFisc = new System.Windows.Forms.DataGridView();
			this.colIdVisitas = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaFisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colObservacionFisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.toolStrip5 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoInforme = new System.Windows.Forms.ToolStripButton();
			this.btnEliminaInforme = new System.Windows.Forms.ToolStripButton();
			this.dgvInformes = new System.Windows.Forms.DataGridView();
			this.colIdInforme = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaInf = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colObservacionInf = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.toolStrip4 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoHorario = new System.Windows.Forms.ToolStripButton();
			this.btnEliminaHorario = new System.Windows.Forms.ToolStripButton();
			this.dgvHorarios = new System.Windows.Forms.DataGridView();
			this.colIdHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDia = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colHoraInicio = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colMinInicio = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colTipoInicio = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colHoraFin = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colMinFin = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colTipoFin = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoEst = new System.Windows.Forms.ToolStripButton();
			this.btnEliminaEst = new System.Windows.Forms.ToolStripButton();
			this.dgvEstablecimientos = new System.Windows.Forms.DataGridView();
			this.colCodigoEstablecimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreEstablecimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSesionApEst = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaAprobacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoCobrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCobradorRegencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEstado = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.panel10 = new System.Windows.Forms.Panel();
			this.label35 = new System.Windows.Forms.Label();
			this.tpLibroProtocolo = new System.Windows.Forms.TabPage();
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
			this.label9 = new System.Windows.Forms.Label();
			this.tpSanciones = new System.Windows.Forms.TabPage();
			this.txtIdSancion = new Framework.UserControls.txtNormal();
			this.rtbObservacionSancion = new Framework.UserControls.rtbSaseg();
			this.label21 = new System.Windows.Forms.Label();
			this.grbFechas = new System.Windows.Forms.GroupBox();
			this.label55 = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.dtpFechaHastaSancion = new Framework.UserControls.dtpSaseg();
			this.dtpFechaSesionSancion = new Framework.UserControls.dtpSaseg();
			this.label18 = new System.Windows.Forms.Label();
			this.txtSesionSancion = new Framework.UserControls.txtNormal();
			this.txtCategoriaSancionDesc = new Framework.UserControls.txtNormal();
			this.label17 = new System.Windows.Forms.Label();
			this.txtCategoriaSancion = new Framework.UserControls.txtNormal();
			this.txtNumRegistroSancionDesc = new Framework.UserControls.txtNormal();
			this.label43 = new System.Windows.Forms.Label();
			this.txtNumRegistroSancion = new Framework.UserControls.txtNormal();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.toolStrip7 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoSancion = new System.Windows.Forms.ToolStripButton();
			this.btnBorrarSancion = new System.Windows.Forms.ToolStripButton();
			this.btnModificarSancion = new System.Windows.Forms.ToolStripButton();
			this.btnAjustarCol = new System.Windows.Forms.ToolStripButton();
			this.dgvSanciones = new System.Windows.Forms.DataGridView();
			this.colIdSancion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoEstable = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEstable = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoCategoriaS = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCategoriaS = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSesionSancion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaSancion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colObservacionesSancion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtNColegiado = new Framework.UserControls.txtNormal();
			this.label13 = new System.Windows.Forms.Label();
			this.cmbTipo = new Framework.UserControls.cmbSaseg();
			this.dtpVencimiento = new Framework.UserControls.dtpSaseg();
			this.lblVencimiento = new System.Windows.Forms.Label();
			this.txtMonto = new Framework.UserControls.txtNormal();
			this.lblMonto = new System.Windows.Forms.Label();
			this.dtpFecha = new Framework.UserControls.dtpSaseg();
			this.LblFecha = new System.Windows.Forms.Label();
			this.txtNPoliza = new Framework.UserControls.txtNormal();
			this.lblNPoliza = new System.Windows.Forms.Label();
			this.tpHistorialRegencias = new System.Windows.Forms.TabPage();
			this.dgvHistorialRegencias = new System.Windows.Forms.DataGridView();
			this.colNumRegistroR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEstablecimientoR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoCategoriaR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCategoriaR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSesionAprobacionR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaAprobacionR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEstadoPrevio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel11 = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.gbVidaSilvestre = new System.Windows.Forms.GroupBox();
			this.toolStrip9 = new System.Windows.Forms.ToolStrip();
			this.btnAgregarCampo = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarCampo = new System.Windows.Forms.ToolStripButton();
			this.dgvVidaSilvestre = new System.Windows.Forms.DataGridView();
			this.colCodigoSilvestre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreSilvestre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDescripcionSilvestre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label19 = new System.Windows.Forms.Label();
			this.rtbObservaciones = new Framework.UserControls.rtbSaseg();
			((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tpBasicos.SuspendLayout();
			this.tpAdmin.SuspendLayout();
			this.panelBasicos.SuspendLayout();
			this.tpAdjuntos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
			this.tpEstablecimientos.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.toolStrip6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVisitasFisc)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.toolStrip5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvInformes)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.toolStrip4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEstablecimientos)).BeginInit();
			this.panel10.SuspendLayout();
			this.tpLibroProtocolo.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.panel9.SuspendLayout();
			this.toolStrip8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProtocolos)).BeginInit();
			this.panel8.SuspendLayout();
			this.tpSanciones.SuspendLayout();
			this.grbFechas.SuspendLayout();
			this.panel7.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.toolStrip7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSanciones)).BeginInit();
			this.tpHistorialRegencias.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHistorialRegencias)).BeginInit();
			this.panel11.SuspendLayout();
			this.gbVidaSilvestre.SuspendLayout();
			this.toolStrip9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVidaSilvestre)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tpEstablecimientos);
			this.tabControl.Controls.Add(this.tpLibroProtocolo);
			this.tabControl.Controls.Add(this.tpSanciones);
			this.tabControl.Controls.Add(this.tpHistorialRegencias);
			this.tabControl.Size = new System.Drawing.Size(1233, 573);
			this.tabControl.Controls.SetChildIndex(this.tpHistorialRegencias, 0);
			this.tabControl.Controls.SetChildIndex(this.tpSanciones, 0);
			this.tabControl.Controls.SetChildIndex(this.tpLibroProtocolo, 0);
			this.tabControl.Controls.SetChildIndex(this.tpEstablecimientos, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAdjuntos, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAdmin, 0);
			this.tabControl.Controls.SetChildIndex(this.tpBasicos, 0);
			// 
			// tpBasicos
			// 
			this.tpBasicos.Controls.Add(this.label19);
			this.tpBasicos.Controls.Add(this.rtbObservaciones);
			this.tpBasicos.Controls.Add(this.gbVidaSilvestre);
			this.tpBasicos.Controls.Add(this.dtpVencimiento);
			this.tpBasicos.Controls.Add(this.lblVencimiento);
			this.tpBasicos.Controls.Add(this.txtMonto);
			this.tpBasicos.Controls.Add(this.lblMonto);
			this.tpBasicos.Controls.Add(this.dtpFecha);
			this.tpBasicos.Controls.Add(this.LblFecha);
			this.tpBasicos.Controls.Add(this.txtNPoliza);
			this.tpBasicos.Controls.Add(this.lblNPoliza);
			this.tpBasicos.Controls.Add(this.label13);
			this.tpBasicos.Controls.Add(this.cmbTipo);
			this.tpBasicos.Controls.Add(this.txtNColegiado);
			this.tpBasicos.Controls.Add(this.chkCurso);
			this.tpBasicos.Controls.Add(this.dtpPerdida);
			this.tpBasicos.Controls.Add(this.label15);
			this.tpBasicos.Controls.Add(this.txtSesionPerdida);
			this.tpBasicos.Controls.Add(this.label16);
			this.tpBasicos.Controls.Add(this.dtpAprobacion);
			this.tpBasicos.Controls.Add(this.label12);
			this.tpBasicos.Controls.Add(this.txtSesionAprob);
			this.tpBasicos.Controls.Add(this.label11);
			this.tpBasicos.Controls.Add(this.txtCobrador);
			this.tpBasicos.Controls.Add(this.label10);
			this.tpBasicos.Controls.Add(this.txtCobradorNombre);
			this.tpBasicos.Controls.Add(this.txtNumColegiado);
			this.tpBasicos.Controls.Add(this.label7);
			this.tpBasicos.Controls.Add(this.txtNombreColegiado);
			this.tpBasicos.Size = new System.Drawing.Size(1225, 547);
			this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtNombreColegiado, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label7, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtNumColegiado, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtCobradorNombre, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label10, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtCobrador, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label11, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtSesionAprob, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label12, 0);
			this.tpBasicos.Controls.SetChildIndex(this.dtpAprobacion, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label16, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtSesionPerdida, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label15, 0);
			this.tpBasicos.Controls.SetChildIndex(this.dtpPerdida, 0);
			this.tpBasicos.Controls.SetChildIndex(this.chkCurso, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtNColegiado, 0);
			this.tpBasicos.Controls.SetChildIndex(this.cmbTipo, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label13, 0);
			this.tpBasicos.Controls.SetChildIndex(this.lblNPoliza, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtNPoliza, 0);
			this.tpBasicos.Controls.SetChildIndex(this.LblFecha, 0);
			this.tpBasicos.Controls.SetChildIndex(this.dtpFecha, 0);
			this.tpBasicos.Controls.SetChildIndex(this.lblMonto, 0);
			this.tpBasicos.Controls.SetChildIndex(this.txtMonto, 0);
			this.tpBasicos.Controls.SetChildIndex(this.lblVencimiento, 0);
			this.tpBasicos.Controls.SetChildIndex(this.dtpVencimiento, 0);
			this.tpBasicos.Controls.SetChildIndex(this.gbVidaSilvestre, 0);
			this.tpBasicos.Controls.SetChildIndex(this.rtbObservaciones, 0);
			this.tpBasicos.Controls.SetChildIndex(this.label19, 0);
			// 
			// tpAdmin
			// 
			this.tpAdmin.Size = new System.Drawing.Size(1225, 525);
			// 
			// panelAdmin
			// 
			this.panelAdmin.Size = new System.Drawing.Size(1219, 21);
			// 
			// panelBasicos
			// 
			this.panelBasicos.Size = new System.Drawing.Size(1219, 21);
			// 
			// tpAdjuntos
			// 
			this.tpAdjuntos.Size = new System.Drawing.Size(1225, 525);
			// 
			// panelAdjuntos
			// 
			this.panelAdjuntos.Size = new System.Drawing.Size(1219, 21);
			// 
			// flvListado
			// 
			this.flvListado.Size = new System.Drawing.Size(1005, 451);
			// 
			// chkCurso
			// 
			this.chkCurso.Checked = false;
			this.chkCurso.Location = new System.Drawing.Point(455, 227);
			this.chkCurso.Name = "chkCurso";
			this.chkCurso.Size = new System.Drawing.Size(139, 17);
			this.chkCurso.TabIndex = 54;
			this.chkCurso.Texto = "Curso de Regencias";
			// 
			// dtpPerdida
			// 
			this.dtpPerdida.Checked = false;
			this.dtpPerdida.Location = new System.Drawing.Point(555, 196);
			this.dtpPerdida.mostrarCheckBox = true;
			this.dtpPerdida.mostrarUpDown = false;
			this.dtpPerdida.Name = "dtpPerdida";
			this.dtpPerdida.Size = new System.Drawing.Size(96, 22);
			this.dtpPerdida.TabIndex = 53;
			this.dtpPerdida.Value = new System.DateTime(2019, 5, 23, 0, 0, 0, 0);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(470, 199);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(79, 13);
			this.label15.TabIndex = 52;
			this.label15.Text = "Fecha Pérdida:";
			// 
			// txtSesionPerdida
			// 
			this.txtSesionPerdida.FormatearNumero = false;
			this.txtSesionPerdida.Location = new System.Drawing.Point(334, 197);
			this.txtSesionPerdida.Longitud = 30;
			this.txtSesionPerdida.Multilinea = false;
			this.txtSesionPerdida.Name = "txtSesionPerdida";
			this.txtSesionPerdida.Password = '\0';
			this.txtSesionPerdida.ReadOnly = false;
			this.txtSesionPerdida.Size = new System.Drawing.Size(112, 21);
			this.txtSesionPerdida.TabIndex = 51;
			this.txtSesionPerdida.Valor = "";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(248, 201);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(81, 13);
			this.label16.TabIndex = 50;
			this.label16.Text = "Sesión Pérdida:";
			// 
			// dtpAprobacion
			// 
			this.dtpAprobacion.Checked = true;
			this.dtpAprobacion.Location = new System.Drawing.Point(555, 169);
			this.dtpAprobacion.mostrarCheckBox = false;
			this.dtpAprobacion.mostrarUpDown = false;
			this.dtpAprobacion.Name = "dtpAprobacion";
			this.dtpAprobacion.Size = new System.Drawing.Size(96, 22);
			this.dtpAprobacion.TabIndex = 45;
			this.dtpAprobacion.Value = new System.DateTime(2019, 5, 23, 0, 0, 0, 0);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(452, 172);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(97, 13);
			this.label12.TabIndex = 44;
			this.label12.Text = "Fecha Aprobación:";
			// 
			// txtSesionAprob
			// 
			this.txtSesionAprob.FormatearNumero = false;
			this.txtSesionAprob.Location = new System.Drawing.Point(334, 169);
			this.txtSesionAprob.Longitud = 30;
			this.txtSesionAprob.Multilinea = false;
			this.txtSesionAprob.Name = "txtSesionAprob";
			this.txtSesionAprob.Password = '\0';
			this.txtSesionAprob.ReadOnly = false;
			this.txtSesionAprob.Size = new System.Drawing.Size(112, 21);
			this.txtSesionAprob.TabIndex = 43;
			this.txtSesionAprob.Valor = "";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(229, 172);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(99, 13);
			this.label11.TabIndex = 42;
			this.label11.Text = "Sesión Aprobación:";
			// 
			// txtCobrador
			// 
			this.txtCobrador.FormatearNumero = false;
			this.txtCobrador.Location = new System.Drawing.Point(334, 142);
			this.txtCobrador.Longitud = 30;
			this.txtCobrador.Multilinea = false;
			this.txtCobrador.Name = "txtCobrador";
			this.txtCobrador.Password = '\0';
			this.txtCobrador.ReadOnly = false;
			this.txtCobrador.Size = new System.Drawing.Size(112, 21);
			this.txtCobrador.TabIndex = 41;
			this.txtCobrador.Valor = "";
			this.txtCobrador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCobrador_KeyDown);
			this.txtCobrador.Leave += new System.EventHandler(this.txtCobrador_Leave);
			this.txtCobrador.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCobrador_MouseDoubleClick);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(266, 147);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(62, 13);
			this.label10.TabIndex = 40;
			this.label10.Text = "Cobrador:";
			// 
			// txtCobradorNombre
			// 
			this.txtCobradorNombre.FormatearNumero = false;
			this.txtCobradorNombre.Location = new System.Drawing.Point(448, 142);
			this.txtCobradorNombre.Longitud = 30;
			this.txtCobradorNombre.Multilinea = false;
			this.txtCobradorNombre.Name = "txtCobradorNombre";
			this.txtCobradorNombre.Password = '\0';
			this.txtCobradorNombre.ReadOnly = true;
			this.txtCobradorNombre.Size = new System.Drawing.Size(325, 21);
			this.txtCobradorNombre.TabIndex = 39;
			this.txtCobradorNombre.Valor = "";
			// 
			// txtNumColegiado
			// 
			this.txtNumColegiado.FormatearNumero = false;
			this.txtNumColegiado.Location = new System.Drawing.Point(334, 88);
			this.txtNumColegiado.Longitud = 30;
			this.txtNumColegiado.Multilinea = false;
			this.txtNumColegiado.Name = "txtNumColegiado";
			this.txtNumColegiado.Password = '\0';
			this.txtNumColegiado.ReadOnly = false;
			this.txtNumColegiado.Size = new System.Drawing.Size(112, 21);
			this.txtNumColegiado.TabIndex = 33;
			this.txtNumColegiado.Valor = "";
			this.txtNumColegiado.Visible = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(243, 119);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 13);
			this.label7.TabIndex = 32;
			this.label7.Text = "Nº Colegiado:";
			// 
			// txtNombreColegiado
			// 
			this.txtNombreColegiado.FormatearNumero = false;
			this.txtNombreColegiado.Location = new System.Drawing.Point(448, 115);
			this.txtNombreColegiado.Longitud = 30;
			this.txtNombreColegiado.Multilinea = false;
			this.txtNombreColegiado.Name = "txtNombreColegiado";
			this.txtNombreColegiado.Password = '\0';
			this.txtNombreColegiado.ReadOnly = true;
			this.txtNombreColegiado.Size = new System.Drawing.Size(325, 21);
			this.txtNombreColegiado.TabIndex = 31;
			this.txtNombreColegiado.Valor = "";
			// 
			// tpEstablecimientos
			// 
			this.tpEstablecimientos.Controls.Add(this.groupBox4);
			this.tpEstablecimientos.Controls.Add(this.groupBox3);
			this.tpEstablecimientos.Controls.Add(this.groupBox2);
			this.tpEstablecimientos.Controls.Add(this.groupBox1);
			this.tpEstablecimientos.Controls.Add(this.panel10);
			this.tpEstablecimientos.Location = new System.Drawing.Point(4, 22);
			this.tpEstablecimientos.Name = "tpEstablecimientos";
			this.tpEstablecimientos.Size = new System.Drawing.Size(1225, 525);
			this.tpEstablecimientos.TabIndex = 3;
			this.tpEstablecimientos.Text = "Establecimientos";
			this.tpEstablecimientos.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.panel5);
			this.groupBox4.Controls.Add(this.dgvVisitasFisc);
			this.groupBox4.Location = new System.Drawing.Point(833, 291);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(361, 225);
			this.groupBox4.TabIndex = 43;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Visitas Fiscalía";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.toolStrip6);
			this.panel5.Location = new System.Drawing.Point(6, 15);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(135, 28);
			this.panel5.TabIndex = 45;
			// 
			// toolStrip6
			// 
			this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoVisita,
            this.btnEliminaVisita});
			this.toolStrip6.Location = new System.Drawing.Point(0, 0);
			this.toolStrip6.Name = "toolStrip6";
			this.toolStrip6.Size = new System.Drawing.Size(135, 25);
			this.toolStrip6.TabIndex = 0;
			this.toolStrip6.Text = "toolStrip6";
			// 
			// btnNuevoVisita
			// 
			this.btnNuevoVisita.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevoVisita.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoVisita.Image")));
			this.btnNuevoVisita.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevoVisita.Name = "btnNuevoVisita";
			this.btnNuevoVisita.Size = new System.Drawing.Size(23, 22);
			this.btnNuevoVisita.Text = "Nueva Visita";
			this.btnNuevoVisita.Click += new System.EventHandler(this.btnNuevoVisita_Click);
			// 
			// btnEliminaVisita
			// 
			this.btnEliminaVisita.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminaVisita.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaVisita.Image")));
			this.btnEliminaVisita.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminaVisita.Name = "btnEliminaVisita";
			this.btnEliminaVisita.Size = new System.Drawing.Size(23, 22);
			this.btnEliminaVisita.Text = "Eliminar Visita";
			this.btnEliminaVisita.Click += new System.EventHandler(this.btnEliminaVisita_Click);
			// 
			// dgvVisitasFisc
			// 
			this.dgvVisitasFisc.AllowUserToAddRows = false;
			this.dgvVisitasFisc.AllowUserToDeleteRows = false;
			this.dgvVisitasFisc.AllowUserToResizeRows = false;
			this.dgvVisitasFisc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvVisitasFisc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvVisitasFisc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvVisitasFisc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdVisitas,
            this.colFechaFisc,
            this.colObservacionFisc});
			this.dgvVisitasFisc.Location = new System.Drawing.Point(3, 44);
			this.dgvVisitasFisc.MultiSelect = false;
			this.dgvVisitasFisc.Name = "dgvVisitasFisc";
			this.dgvVisitasFisc.RowHeadersVisible = false;
			this.dgvVisitasFisc.Size = new System.Drawing.Size(352, 175);
			this.dgvVisitasFisc.TabIndex = 0;
			this.dgvVisitasFisc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVisitasFisc_CellClick);
			this.dgvVisitasFisc.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvVisitasFisc_CurrentCellDirtyStateChanged);
			// 
			// colIdVisitas
			// 
			this.colIdVisitas.HeaderText = "Id";
			this.colIdVisitas.Name = "colIdVisitas";
			this.colIdVisitas.Visible = false;
			// 
			// colFechaFisc
			// 
			this.colFechaFisc.FillWeight = 100.2076F;
			this.colFechaFisc.HeaderText = "Fecha";
			this.colFechaFisc.Name = "colFechaFisc";
			// 
			// colObservacionFisc
			// 
			this.colObservacionFisc.HeaderText = "Observación";
			this.colObservacionFisc.Name = "colObservacionFisc";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel4);
			this.groupBox3.Controls.Add(this.dgvInformes);
			this.groupBox3.Location = new System.Drawing.Point(473, 291);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(354, 225);
			this.groupBox3.TabIndex = 42;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Informes Realizados";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.toolStrip5);
			this.panel4.Location = new System.Drawing.Point(6, 15);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(135, 28);
			this.panel4.TabIndex = 45;
			// 
			// toolStrip5
			// 
			this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoInforme,
            this.btnEliminaInforme});
			this.toolStrip5.Location = new System.Drawing.Point(0, 0);
			this.toolStrip5.Name = "toolStrip5";
			this.toolStrip5.Size = new System.Drawing.Size(135, 25);
			this.toolStrip5.TabIndex = 0;
			this.toolStrip5.Text = "toolStrip5";
			// 
			// btnNuevoInforme
			// 
			this.btnNuevoInforme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevoInforme.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoInforme.Image")));
			this.btnNuevoInforme.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevoInforme.Name = "btnNuevoInforme";
			this.btnNuevoInforme.Size = new System.Drawing.Size(23, 22);
			this.btnNuevoInforme.Text = "Nuevo Informe";
			this.btnNuevoInforme.Click += new System.EventHandler(this.btnNuevoInforme_Click);
			// 
			// btnEliminaInforme
			// 
			this.btnEliminaInforme.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminaInforme.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaInforme.Image")));
			this.btnEliminaInforme.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminaInforme.Name = "btnEliminaInforme";
			this.btnEliminaInforme.Size = new System.Drawing.Size(23, 22);
			this.btnEliminaInforme.Text = "Eliminar Informe";
			this.btnEliminaInforme.Click += new System.EventHandler(this.btnEliminaInforme_Click);
			// 
			// dgvInformes
			// 
			this.dgvInformes.AllowUserToAddRows = false;
			this.dgvInformes.AllowUserToDeleteRows = false;
			this.dgvInformes.AllowUserToResizeRows = false;
			this.dgvInformes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvInformes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvInformes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvInformes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdInforme,
            this.colFechaInf,
            this.colObservacionInf});
			this.dgvInformes.Location = new System.Drawing.Point(3, 45);
			this.dgvInformes.MultiSelect = false;
			this.dgvInformes.Name = "dgvInformes";
			this.dgvInformes.RowHeadersVisible = false;
			this.dgvInformes.Size = new System.Drawing.Size(345, 174);
			this.dgvInformes.TabIndex = 0;
			this.dgvInformes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInformes_CellClick);
			this.dgvInformes.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvInformes_CurrentCellDirtyStateChanged);
			// 
			// colIdInforme
			// 
			this.colIdInforme.HeaderText = "Id";
			this.colIdInforme.Name = "colIdInforme";
			this.colIdInforme.Visible = false;
			// 
			// colFechaInf
			// 
			this.colFechaInf.FillWeight = 48.38868F;
			this.colFechaInf.HeaderText = "Fecha";
			this.colFechaInf.Name = "colFechaInf";
			// 
			// colObservacionInf
			// 
			this.colObservacionInf.FillWeight = 142.2627F;
			this.colObservacionInf.HeaderText = "Observación";
			this.colObservacionInf.Name = "colObservacionInf";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel3);
			this.groupBox2.Controls.Add(this.dgvHorarios);
			this.groupBox2.Location = new System.Drawing.Point(11, 291);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(456, 225);
			this.groupBox2.TabIndex = 41;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Horarios";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.toolStrip4);
			this.panel3.Location = new System.Drawing.Point(6, 15);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(135, 28);
			this.panel3.TabIndex = 45;
			// 
			// toolStrip4
			// 
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoHorario,
            this.btnEliminaHorario});
			this.toolStrip4.Location = new System.Drawing.Point(0, 0);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.Size = new System.Drawing.Size(135, 25);
			this.toolStrip4.TabIndex = 0;
			this.toolStrip4.Text = "toolStrip4";
			// 
			// btnNuevoHorario
			// 
			this.btnNuevoHorario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevoHorario.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoHorario.Image")));
			this.btnNuevoHorario.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevoHorario.Name = "btnNuevoHorario";
			this.btnNuevoHorario.Size = new System.Drawing.Size(23, 22);
			this.btnNuevoHorario.Text = "Nuevo Horario";
			this.btnNuevoHorario.Click += new System.EventHandler(this.btnNuevoHorario_Click);
			// 
			// btnEliminaHorario
			// 
			this.btnEliminaHorario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminaHorario.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaHorario.Image")));
			this.btnEliminaHorario.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminaHorario.Name = "btnEliminaHorario";
			this.btnEliminaHorario.Size = new System.Drawing.Size(23, 22);
			this.btnEliminaHorario.Text = "Eliminar";
			this.btnEliminaHorario.Click += new System.EventHandler(this.btnEliminaHorario_Click);
			// 
			// dgvHorarios
			// 
			this.dgvHorarios.AllowUserToAddRows = false;
			this.dgvHorarios.AllowUserToDeleteRows = false;
			this.dgvHorarios.AllowUserToResizeRows = false;
			this.dgvHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvHorarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHorarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdHorario,
            this.colDia,
            this.colHoraInicio,
            this.colMinInicio,
            this.colTipoInicio,
            this.colHoraFin,
            this.colMinFin,
            this.colTipoFin});
			this.dgvHorarios.Location = new System.Drawing.Point(3, 44);
			this.dgvHorarios.MultiSelect = false;
			this.dgvHorarios.Name = "dgvHorarios";
			this.dgvHorarios.Size = new System.Drawing.Size(447, 175);
			this.dgvHorarios.TabIndex = 0;
			this.dgvHorarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHorarios_CellClick);
			// 
			// colIdHorario
			// 
			this.colIdHorario.HeaderText = "ID";
			this.colIdHorario.Name = "colIdHorario";
			this.colIdHorario.Visible = false;
			// 
			// colDia
			// 
			this.colDia.FillWeight = 138.3637F;
			this.colDia.HeaderText = "Día";
			this.colDia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
			this.colDia.Name = "colDia";
			this.colDia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colDia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colHoraInicio
			// 
			this.colHoraInicio.FillWeight = 90.44375F;
			this.colHoraInicio.HeaderText = "Hora Inicio";
			this.colHoraInicio.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
			this.colHoraInicio.Name = "colHoraInicio";
			this.colHoraInicio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colHoraInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colMinInicio
			// 
			this.colMinInicio.HeaderText = "Minutos Inicio";
			this.colMinInicio.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
			this.colMinInicio.Name = "colMinInicio";
			this.colMinInicio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colMinInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colTipoInicio
			// 
			this.colTipoInicio.HeaderText = "AM/PM";
			this.colTipoInicio.Items.AddRange(new object[] {
            "AM",
            "PM"});
			this.colTipoInicio.Name = "colTipoInicio";
			this.colTipoInicio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colTipoInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colHoraFin
			// 
			this.colHoraFin.FillWeight = 100.2076F;
			this.colHoraFin.HeaderText = "Hora Fin";
			this.colHoraFin.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
			this.colHoraFin.Name = "colHoraFin";
			this.colHoraFin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colHoraFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colMinFin
			// 
			this.colMinFin.HeaderText = "Minutos Fin";
			this.colMinFin.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
			this.colMinFin.Name = "colMinFin";
			this.colMinFin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colMinFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colTipoFin
			// 
			this.colTipoFin.HeaderText = "AM/PM";
			this.colTipoFin.Items.AddRange(new object[] {
            "AM",
            "PM"});
			this.colTipoFin.Name = "colTipoFin";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.dgvEstablecimientos);
			this.groupBox1.Location = new System.Drawing.Point(232, 30);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(757, 255);
			this.groupBox1.TabIndex = 40;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Establecimientos";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.toolStrip3);
			this.panel2.Location = new System.Drawing.Point(6, 14);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(135, 28);
			this.panel2.TabIndex = 44;
			// 
			// toolStrip3
			// 
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoEst,
            this.btnEliminaEst});
			this.toolStrip3.Location = new System.Drawing.Point(0, 0);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(135, 25);
			this.toolStrip3.TabIndex = 0;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// btnNuevoEst
			// 
			this.btnNuevoEst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevoEst.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoEst.Image")));
			this.btnNuevoEst.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevoEst.Name = "btnNuevoEst";
			this.btnNuevoEst.Size = new System.Drawing.Size(23, 22);
			this.btnNuevoEst.Text = "Nuevo Establecimiento";
			this.btnNuevoEst.Click += new System.EventHandler(this.btnNuevoEst_Click);
			// 
			// btnEliminaEst
			// 
			this.btnEliminaEst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminaEst.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaEst.Image")));
			this.btnEliminaEst.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminaEst.Name = "btnEliminaEst";
			this.btnEliminaEst.Size = new System.Drawing.Size(23, 22);
			this.btnEliminaEst.Text = "Eliminar Establecimiento";
			this.btnEliminaEst.Visible = false;
			this.btnEliminaEst.Click += new System.EventHandler(this.btnEliminaEst_Click);
			// 
			// dgvEstablecimientos
			// 
			this.dgvEstablecimientos.AllowUserToAddRows = false;
			this.dgvEstablecimientos.AllowUserToDeleteRows = false;
			this.dgvEstablecimientos.AllowUserToResizeRows = false;
			this.dgvEstablecimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvEstablecimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvEstablecimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEstablecimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoEstablecimiento,
            this.colNombreEstablecimiento,
            this.colSesionApEst,
            this.colFechaAprobacion,
            this.colCodigoCategoria,
            this.colCategoria,
            this.colCodigoCobrador,
            this.colCobradorRegencia,
            this.colEstado});
			this.dgvEstablecimientos.Location = new System.Drawing.Point(6, 48);
			this.dgvEstablecimientos.MultiSelect = false;
			this.dgvEstablecimientos.Name = "dgvEstablecimientos";
			this.dgvEstablecimientos.RowHeadersVisible = false;
			this.dgvEstablecimientos.Size = new System.Drawing.Size(745, 201);
			this.dgvEstablecimientos.TabIndex = 0;
			this.dgvEstablecimientos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstablecimientos_CellClick);
			this.dgvEstablecimientos.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEstablecimientos_CellMouseEnter);
			this.dgvEstablecimientos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvEstablecimientos_CurrentCellDirtyStateChanged);
			this.dgvEstablecimientos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvEstablecimientos_EditingControlShowing);
			this.dgvEstablecimientos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvEstablecimientos_MouseDoubleClick);
			// 
			// colCodigoEstablecimiento
			// 
			this.colCodigoEstablecimiento.FillWeight = 76.14214F;
			this.colCodigoEstablecimiento.HeaderText = "Código";
			this.colCodigoEstablecimiento.Name = "colCodigoEstablecimiento";
			this.colCodigoEstablecimiento.ReadOnly = true;
			// 
			// colNombreEstablecimiento
			// 
			this.colNombreEstablecimiento.FillWeight = 182.7481F;
			this.colNombreEstablecimiento.HeaderText = "Nombre";
			this.colNombreEstablecimiento.Name = "colNombreEstablecimiento";
			this.colNombreEstablecimiento.ReadOnly = true;
			// 
			// colSesionApEst
			// 
			this.colSesionApEst.FillWeight = 83.35025F;
			this.colSesionApEst.HeaderText = "Sesión Aprobación";
			this.colSesionApEst.Name = "colSesionApEst";
			// 
			// colFechaAprobacion
			// 
			this.colFechaAprobacion.FillWeight = 65.49435F;
			this.colFechaAprobacion.HeaderText = "Fecha Aprobación";
			this.colFechaAprobacion.Name = "colFechaAprobacion";
			// 
			// colCodigoCategoria
			// 
			this.colCodigoCategoria.HeaderText = "Codigo Categoria";
			this.colCodigoCategoria.Name = "colCodigoCategoria";
			this.colCodigoCategoria.Visible = false;
			// 
			// colCategoria
			// 
			this.colCategoria.HeaderText = "Categoria";
			this.colCategoria.Name = "colCategoria";
			// 
			// colCodigoCobrador
			// 
			this.colCodigoCobrador.HeaderText = "Codigo Cobrador";
			this.colCodigoCobrador.Name = "colCodigoCobrador";
			this.colCodigoCobrador.Visible = false;
			// 
			// colCobradorRegencia
			// 
			this.colCobradorRegencia.HeaderText = "Cobrador";
			this.colCobradorRegencia.Name = "colCobradorRegencia";
			// 
			// colEstado
			// 
			this.colEstado.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.colEstado.FillWeight = 92.26519F;
			this.colEstado.HeaderText = "Estado Regente";
			this.colEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo",
            "Sancionado"});
			this.colEstado.Name = "colEstado";
			// 
			// panel10
			// 
			this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel10.BackColor = System.Drawing.Color.DarkGray;
			this.panel10.Controls.Add(this.label35);
			this.panel10.Location = new System.Drawing.Point(3, 3);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(668, 21);
			this.panel10.TabIndex = 39;
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label35.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label35.Location = new System.Drawing.Point(3, 4);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(190, 14);
			this.label35.TabIndex = 0;
			this.label35.Text = "Información de Establecimientos";
			// 
			// tpLibroProtocolo
			// 
			this.tpLibroProtocolo.Controls.Add(this.groupBox6);
			this.tpLibroProtocolo.Controls.Add(this.panel8);
			this.tpLibroProtocolo.Location = new System.Drawing.Point(4, 22);
			this.tpLibroProtocolo.Name = "tpLibroProtocolo";
			this.tpLibroProtocolo.Size = new System.Drawing.Size(1225, 525);
			this.tpLibroProtocolo.TabIndex = 4;
			this.tpLibroProtocolo.Text = "Libros Protocolo";
			this.tpLibroProtocolo.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.panel9);
			this.groupBox6.Controls.Add(this.dgvProtocolos);
			this.groupBox6.Location = new System.Drawing.Point(39, 42);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(1142, 448);
			this.groupBox6.TabIndex = 46;
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
			this.dgvProtocolos.Size = new System.Drawing.Size(1133, 398);
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
			this.panel8.Controls.Add(this.label9);
			this.panel8.Location = new System.Drawing.Point(3, 3);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(668, 21);
			this.panel8.TabIndex = 45;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label9.Location = new System.Drawing.Point(3, 4);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(206, 14);
			this.label9.TabIndex = 0;
			this.label9.Text = "Información de Libros de Protocolo";
			// 
			// tpSanciones
			// 
			this.tpSanciones.Controls.Add(this.txtIdSancion);
			this.tpSanciones.Controls.Add(this.rtbObservacionSancion);
			this.tpSanciones.Controls.Add(this.label21);
			this.tpSanciones.Controls.Add(this.grbFechas);
			this.tpSanciones.Controls.Add(this.label18);
			this.tpSanciones.Controls.Add(this.txtSesionSancion);
			this.tpSanciones.Controls.Add(this.txtCategoriaSancionDesc);
			this.tpSanciones.Controls.Add(this.label17);
			this.tpSanciones.Controls.Add(this.txtCategoriaSancion);
			this.tpSanciones.Controls.Add(this.txtNumRegistroSancionDesc);
			this.tpSanciones.Controls.Add(this.label43);
			this.tpSanciones.Controls.Add(this.txtNumRegistroSancion);
			this.tpSanciones.Controls.Add(this.panel7);
			this.tpSanciones.Controls.Add(this.groupBox5);
			this.tpSanciones.Location = new System.Drawing.Point(4, 22);
			this.tpSanciones.Name = "tpSanciones";
			this.tpSanciones.Size = new System.Drawing.Size(1225, 525);
			this.tpSanciones.TabIndex = 5;
			this.tpSanciones.Text = "Sanciones";
			this.tpSanciones.UseVisualStyleBackColor = true;
			// 
			// txtIdSancion
			// 
			this.txtIdSancion.FormatearNumero = false;
			this.txtIdSancion.Location = new System.Drawing.Point(348, 99);
			this.txtIdSancion.Longitud = 10;
			this.txtIdSancion.Multilinea = false;
			this.txtIdSancion.Name = "txtIdSancion";
			this.txtIdSancion.Password = '\0';
			this.txtIdSancion.ReadOnly = false;
			this.txtIdSancion.Size = new System.Drawing.Size(75, 21);
			this.txtIdSancion.TabIndex = 290;
			this.txtIdSancion.Valor = "";
			this.txtIdSancion.Visible = false;
			// 
			// rtbObservacionSancion
			// 
			this.rtbObservacionSancion.Location = new System.Drawing.Point(806, 45);
			this.rtbObservacionSancion.Longitud = 500;
			this.rtbObservacionSancion.Mayusculas = false;
			this.rtbObservacionSancion.Name = "rtbObservacionSancion";
			this.rtbObservacionSancion.ReadOnly = false;
			this.rtbObservacionSancion.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang3082{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22621}\\viewkind4\\uc1 \r\n\\par" +
    "d\\f0\\fs17\\par\r\n}\r\n";
			this.rtbObservacionSancion.Size = new System.Drawing.Size(381, 84);
			this.rtbObservacionSancion.TabIndex = 288;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(730, 50);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(70, 13);
			this.label21.TabIndex = 289;
			this.label21.Text = "Observación:";
			// 
			// grbFechas
			// 
			this.grbFechas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grbFechas.Controls.Add(this.label55);
			this.grbFechas.Controls.Add(this.label53);
			this.grbFechas.Controls.Add(this.dtpFechaHastaSancion);
			this.grbFechas.Controls.Add(this.dtpFechaSesionSancion);
			this.grbFechas.Location = new System.Drawing.Point(-3967, 45);
			this.grbFechas.Name = "grbFechas";
			this.grbFechas.Size = new System.Drawing.Size(272, 79);
			this.grbFechas.TabIndex = 287;
			this.grbFechas.TabStop = false;
			this.grbFechas.Text = "Fechas";
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(31, 49);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(71, 13);
			this.label55.TabIndex = 283;
			this.label55.Text = "Fecha Hasta:";
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(27, 22);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(75, 13);
			this.label53.TabIndex = 282;
			this.label53.Text = "Fecha Sesión:";
			// 
			// dtpFechaHastaSancion
			// 
			this.dtpFechaHastaSancion.Checked = false;
			this.dtpFechaHastaSancion.Location = new System.Drawing.Point(108, 47);
			this.dtpFechaHastaSancion.mostrarCheckBox = false;
			this.dtpFechaHastaSancion.mostrarUpDown = false;
			this.dtpFechaHastaSancion.Name = "dtpFechaHastaSancion";
			this.dtpFechaHastaSancion.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaHastaSancion.TabIndex = 6;
			this.dtpFechaHastaSancion.Value = new System.DateTime(2018, 11, 30, 9, 46, 47, 67);
			// 
			// dtpFechaSesionSancion
			// 
			this.dtpFechaSesionSancion.Checked = true;
			this.dtpFechaSesionSancion.Location = new System.Drawing.Point(108, 19);
			this.dtpFechaSesionSancion.mostrarCheckBox = false;
			this.dtpFechaSesionSancion.mostrarUpDown = false;
			this.dtpFechaSesionSancion.Name = "dtpFechaSesionSancion";
			this.dtpFechaSesionSancion.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaSesionSancion.TabIndex = 5;
			this.dtpFechaSesionSancion.Value = new System.DateTime(2018, 11, 30, 9, 46, 47, 67);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(75, 104);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(45, 13);
			this.label18.TabIndex = 282;
			this.label18.Text = "Sesión :";
			// 
			// txtSesionSancion
			// 
			this.txtSesionSancion.FormatearNumero = false;
			this.txtSesionSancion.Location = new System.Drawing.Point(126, 99);
			this.txtSesionSancion.Longitud = 10;
			this.txtSesionSancion.Multilinea = false;
			this.txtSesionSancion.Name = "txtSesionSancion";
			this.txtSesionSancion.Password = '\0';
			this.txtSesionSancion.ReadOnly = false;
			this.txtSesionSancion.Size = new System.Drawing.Size(75, 21);
			this.txtSesionSancion.TabIndex = 281;
			this.txtSesionSancion.Valor = "";
			// 
			// txtCategoriaSancionDesc
			// 
			this.txtCategoriaSancionDesc.FormatearNumero = false;
			this.txtCategoriaSancionDesc.Location = new System.Drawing.Point(203, 72);
			this.txtCategoriaSancionDesc.Longitud = 32767;
			this.txtCategoriaSancionDesc.Multilinea = false;
			this.txtCategoriaSancionDesc.Name = "txtCategoriaSancionDesc";
			this.txtCategoriaSancionDesc.Password = '\0';
			this.txtCategoriaSancionDesc.ReadOnly = true;
			this.txtCategoriaSancionDesc.Size = new System.Drawing.Size(220, 21);
			this.txtCategoriaSancionDesc.TabIndex = 280;
			this.txtCategoriaSancionDesc.Valor = "";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(62, 76);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(58, 13);
			this.label17.TabIndex = 279;
			this.label17.Text = "Categoria :";
			// 
			// txtCategoriaSancion
			// 
			this.txtCategoriaSancion.FormatearNumero = false;
			this.txtCategoriaSancion.Location = new System.Drawing.Point(126, 72);
			this.txtCategoriaSancion.Longitud = 2;
			this.txtCategoriaSancion.Multilinea = false;
			this.txtCategoriaSancion.Name = "txtCategoriaSancion";
			this.txtCategoriaSancion.Password = '\0';
			this.txtCategoriaSancion.ReadOnly = true;
			this.txtCategoriaSancion.Size = new System.Drawing.Size(75, 21);
			this.txtCategoriaSancion.TabIndex = 278;
			this.txtCategoriaSancion.Valor = "";
			// 
			// txtNumRegistroSancionDesc
			// 
			this.txtNumRegistroSancionDesc.FormatearNumero = false;
			this.txtNumRegistroSancionDesc.Location = new System.Drawing.Point(203, 45);
			this.txtNumRegistroSancionDesc.Longitud = 32767;
			this.txtNumRegistroSancionDesc.Multilinea = false;
			this.txtNumRegistroSancionDesc.Name = "txtNumRegistroSancionDesc";
			this.txtNumRegistroSancionDesc.Password = '\0';
			this.txtNumRegistroSancionDesc.ReadOnly = true;
			this.txtNumRegistroSancionDesc.Size = new System.Drawing.Size(220, 21);
			this.txtNumRegistroSancionDesc.TabIndex = 277;
			this.txtNumRegistroSancionDesc.Valor = "";
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(43, 50);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(77, 13);
			this.label43.TabIndex = 276;
			this.label43.Text = "Num Registro :";
			// 
			// txtNumRegistroSancion
			// 
			this.txtNumRegistroSancion.FormatearNumero = false;
			this.txtNumRegistroSancion.Location = new System.Drawing.Point(126, 45);
			this.txtNumRegistroSancion.Longitud = 2;
			this.txtNumRegistroSancion.Multilinea = false;
			this.txtNumRegistroSancion.Name = "txtNumRegistroSancion";
			this.txtNumRegistroSancion.Password = '\0';
			this.txtNumRegistroSancion.ReadOnly = false;
			this.txtNumRegistroSancion.Size = new System.Drawing.Size(75, 21);
			this.txtNumRegistroSancion.TabIndex = 275;
			this.txtNumRegistroSancion.Valor = "";
			this.txtNumRegistroSancion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtNumRegistroSancion_MouseDoubleClick);
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.DarkGray;
			this.panel7.Controls.Add(this.label8);
			this.panel7.Location = new System.Drawing.Point(3, 3);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(1219, 21);
			this.panel7.TabIndex = 44;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label8.Location = new System.Drawing.Point(3, 4);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(150, 14);
			this.label8.TabIndex = 0;
			this.label8.Text = "Información de Sanciones";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.panel6);
			this.groupBox5.Controls.Add(this.dgvSanciones);
			this.groupBox5.Location = new System.Drawing.Point(45, 139);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(1142, 377);
			this.groupBox5.TabIndex = 43;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Sanciones";
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.toolStrip7);
			this.panel6.Location = new System.Drawing.Point(6, 17);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(135, 28);
			this.panel6.TabIndex = 45;
			// 
			// toolStrip7
			// 
			this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoSancion,
            this.btnBorrarSancion,
            this.btnModificarSancion,
            this.btnAjustarCol});
			this.toolStrip7.Location = new System.Drawing.Point(0, 0);
			this.toolStrip7.Name = "toolStrip7";
			this.toolStrip7.Size = new System.Drawing.Size(135, 25);
			this.toolStrip7.TabIndex = 0;
			this.toolStrip7.Text = "toolStrip7";
			// 
			// btnNuevoSancion
			// 
			this.btnNuevoSancion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevoSancion.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoSancion.Image")));
			this.btnNuevoSancion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevoSancion.Name = "btnNuevoSancion";
			this.btnNuevoSancion.Size = new System.Drawing.Size(23, 22);
			this.btnNuevoSancion.Text = "Nueva Sanción";
			this.btnNuevoSancion.Click += new System.EventHandler(this.btnNuevoSancion_Click);
			// 
			// btnBorrarSancion
			// 
			this.btnBorrarSancion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnBorrarSancion.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrarSancion.Image")));
			this.btnBorrarSancion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnBorrarSancion.Name = "btnBorrarSancion";
			this.btnBorrarSancion.Size = new System.Drawing.Size(23, 22);
			this.btnBorrarSancion.Text = "Eliminar Sanción";
			this.btnBorrarSancion.Click += new System.EventHandler(this.btnBorrarSancion_Click);
			// 
			// btnModificarSancion
			// 
			this.btnModificarSancion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnModificarSancion.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarSancion.Image")));
			this.btnModificarSancion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnModificarSancion.Name = "btnModificarSancion";
			this.btnModificarSancion.Size = new System.Drawing.Size(23, 22);
			this.btnModificarSancion.Text = "Modificar";
			this.btnModificarSancion.Click += new System.EventHandler(this.btnModificarSancion_Click);
			// 
			// btnAjustarCol
			// 
			this.btnAjustarCol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAjustarCol.Image = ((System.Drawing.Image)(resources.GetObject("btnAjustarCol.Image")));
			this.btnAjustarCol.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAjustarCol.Name = "btnAjustarCol";
			this.btnAjustarCol.Size = new System.Drawing.Size(23, 22);
			this.btnAjustarCol.Text = "Ajustar Tamaño Columnas";
			this.btnAjustarCol.Click += new System.EventHandler(this.btnAjustarCol_Click);
			// 
			// dgvSanciones
			// 
			this.dgvSanciones.AllowUserToAddRows = false;
			this.dgvSanciones.AllowUserToDeleteRows = false;
			this.dgvSanciones.AllowUserToResizeRows = false;
			this.dgvSanciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvSanciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvSanciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSanciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdSancion,
            this.colCodigoEstable,
            this.colEstable,
            this.colCodigoCategoriaS,
            this.colCategoriaS,
            this.colSesionSancion,
            this.colFechaSancion,
            this.colFechaHasta,
            this.colObservacionesSancion});
			this.dgvSanciones.Location = new System.Drawing.Point(3, 44);
			this.dgvSanciones.Name = "dgvSanciones";
			this.dgvSanciones.RowHeadersVisible = false;
			this.dgvSanciones.Size = new System.Drawing.Size(1133, 327);
			this.dgvSanciones.TabIndex = 0;
			this.dgvSanciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanciones_CellClick);
			this.dgvSanciones.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSanciones_CellMouseDoubleClick);
			this.dgvSanciones.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvSanciones_CurrentCellDirtyStateChanged);
			// 
			// colIdSancion
			// 
			this.colIdSancion.HeaderText = "Id";
			this.colIdSancion.Name = "colIdSancion";
			this.colIdSancion.Visible = false;
			// 
			// colCodigoEstable
			// 
			this.colCodigoEstable.HeaderText = "NumRegistro";
			this.colCodigoEstable.Name = "colCodigoEstable";
			// 
			// colEstable
			// 
			this.colEstable.HeaderText = "Establecimiento";
			this.colEstable.Name = "colEstable";
			this.colEstable.Visible = false;
			// 
			// colCodigoCategoriaS
			// 
			this.colCodigoCategoriaS.HeaderText = "CodCategoria";
			this.colCodigoCategoriaS.Name = "colCodigoCategoriaS";
			this.colCodigoCategoriaS.Visible = false;
			// 
			// colCategoriaS
			// 
			this.colCategoriaS.HeaderText = "Categoria";
			this.colCategoriaS.Name = "colCategoriaS";
			// 
			// colSesionSancion
			// 
			this.colSesionSancion.HeaderText = "Sesión";
			this.colSesionSancion.Name = "colSesionSancion";
			// 
			// colFechaSancion
			// 
			this.colFechaSancion.HeaderText = "Fecha";
			this.colFechaSancion.Name = "colFechaSancion";
			// 
			// colFechaHasta
			// 
			this.colFechaHasta.HeaderText = "Fecha Hasta";
			this.colFechaHasta.Name = "colFechaHasta";
			// 
			// colObservacionesSancion
			// 
			this.colObservacionesSancion.HeaderText = "Observación";
			this.colObservacionesSancion.Name = "colObservacionesSancion";
			// 
			// txtNColegiado
			// 
			this.txtNColegiado.FormatearNumero = false;
			this.txtNColegiado.Location = new System.Drawing.Point(334, 115);
			this.txtNColegiado.Longitud = 30;
			this.txtNColegiado.Multilinea = false;
			this.txtNColegiado.Name = "txtNColegiado";
			this.txtNColegiado.Password = '\0';
			this.txtNColegiado.ReadOnly = false;
			this.txtNColegiado.Size = new System.Drawing.Size(112, 21);
			this.txtNColegiado.TabIndex = 55;
			this.txtNColegiado.Valor = "";
			this.txtNColegiado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumColegiado_KeyDown);
			this.txtNColegiado.Leave += new System.EventHandler(this.txtNumColegiado_Leave);
			this.txtNColegiado.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtNumColegiado_MouseDoubleClick);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(292, 229);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(36, 13);
			this.label13.TabIndex = 57;
			this.label13.Text = "Tipo:";
			// 
			// cmbTipo
			// 
			this.cmbTipo.Habilitar = true;
			this.cmbTipo.Index = -1;
			this.cmbTipo.Location = new System.Drawing.Point(334, 225);
			this.cmbTipo.Name = "cmbTipo";
			this.cmbTipo.Size = new System.Drawing.Size(112, 22);
			this.cmbTipo.TabIndex = 56;
			this.cmbTipo.Texto = "";
			this.cmbTipo.Valor = "";
			// 
			// dtpVencimiento
			// 
			this.dtpVencimiento.Checked = true;
			this.dtpVencimiento.Location = new System.Drawing.Point(676, 317);
			this.dtpVencimiento.mostrarCheckBox = false;
			this.dtpVencimiento.mostrarUpDown = false;
			this.dtpVencimiento.Name = "dtpVencimiento";
			this.dtpVencimiento.Size = new System.Drawing.Size(96, 22);
			this.dtpVencimiento.TabIndex = 65;
			this.dtpVencimiento.Value = new System.DateTime(2019, 5, 23, 0, 0, 0, 0);
			this.dtpVencimiento.Visible = false;
			// 
			// lblVencimiento
			// 
			this.lblVencimiento.AutoSize = true;
			this.lblVencimiento.Location = new System.Drawing.Point(599, 321);
			this.lblVencimiento.Name = "lblVencimiento";
			this.lblVencimiento.Size = new System.Drawing.Size(71, 13);
			this.lblVencimiento.TabIndex = 64;
			this.lblVencimiento.Text = " Vencimiento:";
			this.lblVencimiento.Visible = false;
			// 
			// txtMonto
			// 
			this.txtMonto.FormatearNumero = false;
			this.txtMonto.Location = new System.Drawing.Point(333, 346);
			this.txtMonto.Longitud = 30;
			this.txtMonto.Multilinea = false;
			this.txtMonto.Name = "txtMonto";
			this.txtMonto.Password = '\0';
			this.txtMonto.ReadOnly = false;
			this.txtMonto.Size = new System.Drawing.Size(112, 21);
			this.txtMonto.TabIndex = 63;
			this.txtMonto.Valor = "";
			this.txtMonto.Visible = false;
			this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
			// 
			// lblMonto
			// 
			this.lblMonto.AutoSize = true;
			this.lblMonto.Location = new System.Drawing.Point(287, 351);
			this.lblMonto.Name = "lblMonto";
			this.lblMonto.Size = new System.Drawing.Size(40, 13);
			this.lblMonto.TabIndex = 62;
			this.lblMonto.Text = "Monto:";
			this.lblMonto.Visible = false;
			// 
			// dtpFecha
			// 
			this.dtpFecha.Checked = true;
			this.dtpFecha.Location = new System.Drawing.Point(497, 318);
			this.dtpFecha.mostrarCheckBox = false;
			this.dtpFecha.mostrarUpDown = false;
			this.dtpFecha.Name = "dtpFecha";
			this.dtpFecha.Size = new System.Drawing.Size(96, 22);
			this.dtpFecha.TabIndex = 61;
			this.dtpFecha.Value = new System.DateTime(2019, 5, 29, 0, 0, 0, 0);
			this.dtpFecha.Visible = false;
			// 
			// LblFecha
			// 
			this.LblFecha.AutoSize = true;
			this.LblFecha.Location = new System.Drawing.Point(451, 321);
			this.LblFecha.Name = "LblFecha";
			this.LblFecha.Size = new System.Drawing.Size(40, 13);
			this.LblFecha.TabIndex = 60;
			this.LblFecha.Text = "Fecha:";
			this.LblFecha.Visible = false;
			// 
			// txtNPoliza
			// 
			this.txtNPoliza.FormatearNumero = false;
			this.txtNPoliza.Location = new System.Drawing.Point(333, 318);
			this.txtNPoliza.Longitud = 30;
			this.txtNPoliza.Multilinea = false;
			this.txtNPoliza.Name = "txtNPoliza";
			this.txtNPoliza.Password = '\0';
			this.txtNPoliza.ReadOnly = false;
			this.txtNPoliza.Size = new System.Drawing.Size(112, 21);
			this.txtNPoliza.TabIndex = 59;
			this.txtNPoliza.Valor = "";
			this.txtNPoliza.Visible = false;
			// 
			// lblNPoliza
			// 
			this.lblNPoliza.AutoSize = true;
			this.lblNPoliza.Location = new System.Drawing.Point(249, 321);
			this.lblNPoliza.Name = "lblNPoliza";
			this.lblNPoliza.Size = new System.Drawing.Size(78, 13);
			this.lblNPoliza.TabIndex = 58;
			this.lblNPoliza.Text = "Número Póliza:";
			this.lblNPoliza.Visible = false;
			// 
			// tpHistorialRegencias
			// 
			this.tpHistorialRegencias.Controls.Add(this.dgvHistorialRegencias);
			this.tpHistorialRegencias.Controls.Add(this.panel11);
			this.tpHistorialRegencias.Location = new System.Drawing.Point(4, 22);
			this.tpHistorialRegencias.Name = "tpHistorialRegencias";
			this.tpHistorialRegencias.Padding = new System.Windows.Forms.Padding(3);
			this.tpHistorialRegencias.Size = new System.Drawing.Size(1225, 525);
			this.tpHistorialRegencias.TabIndex = 6;
			this.tpHistorialRegencias.Text = "Historial de Regencias";
			this.tpHistorialRegencias.UseVisualStyleBackColor = true;
			// 
			// dgvHistorialRegencias
			// 
			this.dgvHistorialRegencias.AllowUserToAddRows = false;
			this.dgvHistorialRegencias.AllowUserToDeleteRows = false;
			this.dgvHistorialRegencias.AllowUserToResizeRows = false;
			this.dgvHistorialRegencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvHistorialRegencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvHistorialRegencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHistorialRegencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumRegistroR,
            this.colEstablecimientoR,
            this.colCodigoCategoriaR,
            this.colCategoriaR,
            this.colSesionAprobacionR,
            this.colFechaAprobacionR,
            this.colEstadoPrevio});
			this.dgvHistorialRegencias.Location = new System.Drawing.Point(32, 45);
			this.dgvHistorialRegencias.Name = "dgvHistorialRegencias";
			this.dgvHistorialRegencias.RowHeadersVisible = false;
			this.dgvHistorialRegencias.Size = new System.Drawing.Size(607, 297);
			this.dgvHistorialRegencias.TabIndex = 46;
			// 
			// colNumRegistroR
			// 
			this.colNumRegistroR.HeaderText = "NumRegistro";
			this.colNumRegistroR.Name = "colNumRegistroR";
			// 
			// colEstablecimientoR
			// 
			this.colEstablecimientoR.HeaderText = "Establecimiento";
			this.colEstablecimientoR.Name = "colEstablecimientoR";
			this.colEstablecimientoR.Visible = false;
			// 
			// colCodigoCategoriaR
			// 
			this.colCodigoCategoriaR.HeaderText = "CodCategoria";
			this.colCodigoCategoriaR.Name = "colCodigoCategoriaR";
			this.colCodigoCategoriaR.Visible = false;
			// 
			// colCategoriaR
			// 
			this.colCategoriaR.HeaderText = "Categoría";
			this.colCategoriaR.Name = "colCategoriaR";
			// 
			// colSesionAprobacionR
			// 
			this.colSesionAprobacionR.HeaderText = "Sesión Aprobación";
			this.colSesionAprobacionR.Name = "colSesionAprobacionR";
			// 
			// colFechaAprobacionR
			// 
			this.colFechaAprobacionR.HeaderText = "Fecha Aprobación";
			this.colFechaAprobacionR.Name = "colFechaAprobacionR";
			// 
			// colEstadoPrevio
			// 
			this.colEstadoPrevio.HeaderText = "Estado ";
			this.colEstadoPrevio.Name = "colEstadoPrevio";
			// 
			// panel11
			// 
			this.panel11.BackColor = System.Drawing.Color.DarkGray;
			this.panel11.Controls.Add(this.label14);
			this.panel11.Location = new System.Drawing.Point(3, 3);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(1219, 21);
			this.panel11.TabIndex = 45;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label14.Location = new System.Drawing.Point(3, 4);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(57, 14);
			this.label14.TabIndex = 0;
			this.label14.Text = "Historial";
			// 
			// gbVidaSilvestre
			// 
			this.gbVidaSilvestre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbVidaSilvestre.Controls.Add(this.toolStrip9);
			this.gbVidaSilvestre.Controls.Add(this.dgvVidaSilvestre);
			this.gbVidaSilvestre.Location = new System.Drawing.Point(290, 382);
			this.gbVidaSilvestre.Name = "gbVidaSilvestre";
			this.gbVidaSilvestre.Size = new System.Drawing.Size(491, 162);
			this.gbVidaSilvestre.TabIndex = 312;
			this.gbVidaSilvestre.TabStop = false;
			this.gbVidaSilvestre.Text = "Agregar Vida Silvestre";
			this.gbVidaSilvestre.Visible = false;
			// 
			// toolStrip9
			// 
			this.toolStrip9.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip9.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarCampo,
            this.btnEliminarCampo});
			this.toolStrip9.Location = new System.Drawing.Point(3, 15);
			this.toolStrip9.Name = "toolStrip9";
			this.toolStrip9.Size = new System.Drawing.Size(58, 25);
			this.toolStrip9.TabIndex = 306;
			this.toolStrip9.Text = "toolStrip9";
			// 
			// btnAgregarCampo
			// 
			this.btnAgregarCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAgregarCampo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCampo.Image")));
			this.btnAgregarCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAgregarCampo.Name = "btnAgregarCampo";
			this.btnAgregarCampo.Size = new System.Drawing.Size(23, 22);
			this.btnAgregarCampo.Text = "Nuevo";
			this.btnAgregarCampo.Click += new System.EventHandler(this.btnAgregarCampo_Click);
			// 
			// btnEliminarCampo
			// 
			this.btnEliminarCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarCampo.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarCampo.Image")));
			this.btnEliminarCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarCampo.Name = "btnEliminarCampo";
			this.btnEliminarCampo.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarCampo.Text = "Eliminar";
			this.btnEliminarCampo.Click += new System.EventHandler(this.btnEliminarCampo_Click);
			// 
			// dgvVidaSilvestre
			// 
			this.dgvVidaSilvestre.AllowUserToAddRows = false;
			this.dgvVidaSilvestre.AllowUserToDeleteRows = false;
			this.dgvVidaSilvestre.AllowUserToResizeRows = false;
			this.dgvVidaSilvestre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvVidaSilvestre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvVidaSilvestre.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvVidaSilvestre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvVidaSilvestre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoSilvestre,
            this.colNombreSilvestre,
            this.colDescripcionSilvestre});
			this.dgvVidaSilvestre.Location = new System.Drawing.Point(3, 43);
			this.dgvVidaSilvestre.MultiSelect = false;
			this.dgvVidaSilvestre.Name = "dgvVidaSilvestre";
			this.dgvVidaSilvestre.RowHeadersVisible = false;
			this.dgvVidaSilvestre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvVidaSilvestre.Size = new System.Drawing.Size(485, 113);
			this.dgvVidaSilvestre.TabIndex = 310;
			this.dgvVidaSilvestre.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVidaSilvestre_CellMouseDoubleClick);
			this.dgvVidaSilvestre.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvVidaSilvestre_MouseDoubleClick);
			// 
			// colCodigoSilvestre
			// 
			this.colCodigoSilvestre.HeaderText = "Código";
			this.colCodigoSilvestre.Name = "colCodigoSilvestre";
			this.colCodigoSilvestre.ReadOnly = true;
			// 
			// colNombreSilvestre
			// 
			this.colNombreSilvestre.HeaderText = "Nombre";
			this.colNombreSilvestre.Name = "colNombreSilvestre";
			// 
			// colDescripcionSilvestre
			// 
			this.colDescripcionSilvestre.HeaderText = "Descripción";
			this.colDescripcionSilvestre.Name = "colDescripcionSilvestre";
			this.colDescripcionSilvestre.ReadOnly = true;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(247, 262);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(81, 13);
			this.label19.TabIndex = 314;
			this.label19.Text = "Observaciones:";
			// 
			// rtbObservaciones
			// 
			this.rtbObservaciones.Location = new System.Drawing.Point(334, 253);
			this.rtbObservaciones.Longitud = 2147483647;
			this.rtbObservaciones.Mayusculas = false;
			this.rtbObservaciones.Name = "rtbObservaciones";
			this.rtbObservaciones.ReadOnly = false;
			this.rtbObservaciones.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22621}\\viewkind4\\uc1 \r\n\\par" +
    "d\\f0\\fs17\\par\r\n}\r\n";
			this.rtbObservaciones.Size = new System.Drawing.Size(414, 55);
			this.rtbObservaciones.TabIndex = 313;
			// 
			// frmRegentesEdicion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1233, 664);
			this.Name = "frmRegentesEdicion";
			this.Text = "frmRegentesEdicion";
			this.Load += new System.EventHandler(this.frmRegentesEdicion_Load);
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
			this.tpEstablecimientos.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.toolStrip6.ResumeLayout(false);
			this.toolStrip6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVisitasFisc)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.toolStrip5.ResumeLayout(false);
			this.toolStrip5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvInformes)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEstablecimientos)).EndInit();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.tpLibroProtocolo.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.toolStrip8.ResumeLayout(false);
			this.toolStrip8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProtocolos)).EndInit();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.tpSanciones.ResumeLayout(false);
			this.tpSanciones.PerformLayout();
			this.grbFechas.ResumeLayout(false);
			this.grbFechas.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.toolStrip7.ResumeLayout(false);
			this.toolStrip7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSanciones)).EndInit();
			this.tpHistorialRegencias.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvHistorialRegencias)).EndInit();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			this.gbVidaSilvestre.ResumeLayout(false);
			this.gbVidaSilvestre.PerformLayout();
			this.toolStrip9.ResumeLayout(false);
			this.toolStrip9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVidaSilvestre)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tpEstablecimientos;
        private Framework.UserControls.chkSaseg chkCurso;
        private Framework.UserControls.dtpSaseg dtpPerdida;
        private System.Windows.Forms.Label label15;
        private Framework.UserControls.txtNormal txtSesionPerdida;
        private System.Windows.Forms.Label label16;
        private Framework.UserControls.dtpSaseg dtpAprobacion;
        private System.Windows.Forms.Label label12;
        private Framework.UserControls.txtNormal txtSesionAprob;
        private System.Windows.Forms.Label label11;
        private Framework.UserControls.txtNormal txtCobrador;
        private System.Windows.Forms.Label label10;
        private Framework.UserControls.txtNormal txtCobradorNombre;
        private Framework.UserControls.txtNormal txtNumColegiado;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.txtNormal txtNombreColegiado;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEstablecimientos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvHorarios;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton btnNuevoVisita;
        private System.Windows.Forms.ToolStripButton btnEliminaVisita;
        private System.Windows.Forms.DataGridView dgvVisitasFisc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton btnNuevoInforme;
        private System.Windows.Forms.ToolStripButton btnEliminaInforme;
        private System.Windows.Forms.DataGridView dgvInformes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton btnNuevoHorario;
        private System.Windows.Forms.ToolStripButton btnEliminaHorario;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnNuevoEst;
        private System.Windows.Forms.ToolStripButton btnEliminaEst;
        private System.Windows.Forms.TabPage tpLibroProtocolo;
        private System.Windows.Forms.TabPage tpSanciones;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripButton btnNuevoSancion;
        private System.Windows.Forms.ToolStripButton btnBorrarSancion;
        private System.Windows.Forms.DataGridView dgvSanciones;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton btnNuevoLibro;
        private System.Windows.Forms.ToolStripButton btnEliminarLibro;
        private System.Windows.Forms.DataGridView dgvProtocolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdInforme;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaInf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacionInf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoProtocolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLibCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaApertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacionesProtocolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdVisitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaFisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacionFisc;
        private Framework.UserControls.txtNormal txtNColegiado;
        private System.Windows.Forms.Label label13;
        private Framework.UserControls.cmbSaseg cmbTipo;
        private Framework.UserControls.dtpSaseg dtpVencimiento;
        private System.Windows.Forms.Label lblVencimiento;
        private Framework.UserControls.txtNormal txtMonto;
        private System.Windows.Forms.Label lblMonto;
        private Framework.UserControls.dtpSaseg dtpFecha;
        private System.Windows.Forms.Label LblFecha;
        private Framework.UserControls.txtNormal txtNPoliza;
        private System.Windows.Forms.Label lblNPoliza;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdHorario;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDia;
        private System.Windows.Forms.DataGridViewComboBoxColumn colHoraInicio;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMinInicio;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTipoInicio;
        private System.Windows.Forms.DataGridViewComboBoxColumn colHoraFin;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMinFin;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTipoFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoEstablecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEstablecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSesionApEst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaAprobacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCobrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCobradorRegencia;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEstado;
        private System.Windows.Forms.ToolStripButton btnAjustarCol;
        private System.Windows.Forms.TabPage tpHistorialRegencias;
        private System.Windows.Forms.DataGridView dgvHistorialRegencias;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSancion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoEstable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCategoriaS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSesionSancion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaSancion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObservacionesSancion;
        private System.Windows.Forms.Label label18;
        private Framework.UserControls.txtNormal txtSesionSancion;
        private Framework.UserControls.txtNormal txtCategoriaSancionDesc;
        private System.Windows.Forms.Label label17;
        private Framework.UserControls.txtNormal txtCategoriaSancion;
        private Framework.UserControls.txtNormal txtNumRegistroSancionDesc;
        private System.Windows.Forms.Label label43;
        private Framework.UserControls.txtNormal txtNumRegistroSancion;
        private System.Windows.Forms.GroupBox grbFechas;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label53;
        private Framework.UserControls.dtpSaseg dtpFechaHastaSancion;
        private Framework.UserControls.dtpSaseg dtpFechaSesionSancion;
        private Framework.UserControls.rtbSaseg rtbObservacionSancion;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ToolStripButton btnModificarSancion;
        private Framework.UserControls.txtNormal txtIdSancion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumRegistroR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstablecimientoR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCategoriaR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoriaR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSesionAprobacionR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaAprobacionR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoPrevio;
        private System.Windows.Forms.GroupBox gbVidaSilvestre;
        private System.Windows.Forms.ToolStrip toolStrip9;
        private System.Windows.Forms.ToolStripButton btnAgregarCampo;
        private System.Windows.Forms.ToolStripButton btnEliminarCampo;
        private System.Windows.Forms.DataGridView dgvVidaSilvestre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoSilvestre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreSilvestre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionSilvestre;
		private System.Windows.Forms.Label label19;
		private Framework.UserControls.rtbSaseg rtbObservaciones;
	}
}