namespace KOLEGIO
{
    partial class frmColegiadosEdicion
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmColegiadosEdicion));
			this.tpPlaguicidas = new System.Windows.Forms.TabPage();
			this.grbPagaCanonPlagui = new System.Windows.Forms.GroupBox();
			this.rbPagCanPlaguiNO = new Framework.UserControls.rbSaseg();
			this.rbPagCanPlaguiSI = new Framework.UserControls.rbSaseg();
			this.grbEstadoCanonPlagui = new System.Windows.Forms.GroupBox();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.rbPlaguiProcNO = new Framework.UserControls.rbSaseg();
			this.rbPlaguiProcSI = new Framework.UserControls.rbSaseg();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.rbPlaguiFacNO = new Framework.UserControls.rbSaseg();
			this.rbPlaguiFacSI = new Framework.UserControls.rbSaseg();
			this.panelPlagui = new System.Windows.Forms.Panel();
			this.panel20 = new System.Windows.Forms.Panel();
			this.toolStrip5 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoPlaguicida = new System.Windows.Forms.ToolStripButton();
			this.btnEliminaPlagui = new System.Windows.Forms.ToolStripButton();
			this.dgvInvestigacionPlaguicidas = new System.Windows.Forms.DataGridView();
			this.colCodigoCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPagaCanon = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colSesionAprobacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaAprobacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSesionRenovacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaRenovacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSesionPerdidaP = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaPerdidaP = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colActivoPlagui = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.label30 = new System.Windows.Forms.Label();
			this.tpBeneficiarios = new System.Windows.Forms.TabPage();
			this.dlvBeneficiarios = new BrightIdeasSoftware.DataListView();
			this.toolStrip11 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoBeneficiario = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarBeneficiario = new System.Windows.Forms.ToolStripButton();
			this.btnModificarBeneficiario = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnRefrescarBeneficiarios = new System.Windows.Forms.ToolStripButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label28 = new System.Windows.Forms.Label();
			this.tpEspecialidades = new System.Windows.Forms.TabPage();
			this.toolStrip8 = new System.Windows.Forms.ToolStrip();
			this.btnAgregarCampo = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarCampo = new System.Windows.Forms.ToolStripButton();
			this.dgvCamposEspecialidad = new System.Windows.Forms.DataGridView();
			this.colCodigoCampoEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreCampoEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtCampoEspecialidadN = new Framework.UserControls.txtNormal();
			this.label59 = new System.Windows.Forms.Label();
			this.txtCampoEspecialidad = new Framework.UserControls.txtNormal();
			this.toolStrip4 = new System.Windows.Forms.ToolStrip();
			this.btnAgregarEspecialidad = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarEspecialidad = new System.Windows.Forms.ToolStripButton();
			this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
			this.colCodigoEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoSesionAprob = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtEspecialidadN = new Framework.UserControls.txtNormal();
			this.label58 = new System.Windows.Forms.Label();
			this.txtEspecialidad = new Framework.UserControls.txtNormal();
			this.panel11 = new System.Windows.Forms.Panel();
			this.label56 = new System.Windows.Forms.Label();
			this.grbSesionEspecialidad = new System.Windows.Forms.GroupBox();
			this.dtpFechaSesionAprob = new Framework.UserControls.dtpSaseg();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.txtSesionAprob = new Framework.UserControls.txtNormal();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label29 = new System.Windows.Forms.Label();
			this.tpHistorial = new System.Windows.Forms.TabPage();
			this.grbHistorialSesiones = new System.Windows.Forms.GroupBox();
			this.dgvHistorialSesiones = new System.Windows.Forms.DataGridView();
			this.colCodigoSesion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaSesion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCondicionPrevia = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCondicionNueva = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel9 = new System.Windows.Forms.Panel();
			this.label34 = new System.Windows.Forms.Label();
			this.tpAlertas = new System.Windows.Forms.TabPage();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label31 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.dataGridView6 = new System.Windows.Forms.DataGridView();
			this.tpGestionCobro = new System.Windows.Forms.TabPage();
			this.grbAdelantos = new System.Windows.Forms.GroupBox();
			this.dgvGestionCobroAdel = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grbPendientes = new System.Windows.Forms.GroupBox();
			this.dgvGestionCobro = new System.Windows.Forms.DataGridView();
			this.colDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAplicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panelGestionCobro = new System.Windows.Forms.Panel();
			this.toolStrip9 = new System.Windows.Forms.ToolStrip();
			this.btnNuevaGestion = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarGestion = new System.Windows.Forms.ToolStripButton();
			this.dgvGestionCobro2 = new System.Windows.Forms.DataGridView();
			this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colMedio = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCompromiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaCompromiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colObservacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColEstado = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label32 = new System.Windows.Forms.Label();
			this.tpRevista = new System.Windows.Forms.TabPage();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.label42 = new System.Windows.Forms.Label();
			this.cmbTrabajoRevista = new Framework.UserControls.cmbSaseg();
			this.label41 = new System.Windows.Forms.Label();
			this.cmbRutaRevista = new Framework.UserControls.cmbSaseg();
			this.label39 = new System.Windows.Forms.Label();
			this.cmbTipoEntrega = new Framework.UserControls.cmbSaseg();
			this.panel8 = new System.Windows.Forms.Panel();
			this.label33 = new System.Windows.Forms.Label();
			this.lblNumColegiado = new System.Windows.Forms.Label();
			this.txtNombre = new Framework.UserControls.txtNormal();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbSexo = new Framework.UserControls.cmbSaseg();
			this.label11 = new System.Windows.Forms.Label();
			this.txtTelefono1 = new Framework.UserControls.txtNormal();
			this.label15 = new System.Windows.Forms.Label();
			this.txtTelefono2 = new Framework.UserControls.txtNormal();
			this.label18 = new System.Windows.Forms.Label();
			this.txtEmail1 = new Framework.UserControls.txtNormal();
			this.label19 = new System.Windows.Forms.Label();
			this.txtEmail2 = new Framework.UserControls.txtNormal();
			this.label20 = new System.Windows.Forms.Label();
			this.txtDistritoNombreF = new Framework.UserControls.txtNormal();
			this.txtDistrito = new Framework.UserControls.txtNormal();
			this.txtCanton = new Framework.UserControls.txtNormal();
			this.txtProvincia = new Framework.UserControls.txtNormal();
			this.label21 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.txtApartado = new Framework.UserControls.txtNormal();
			this.label24 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.tpRegencias = new System.Windows.Forms.TabPage();
			this.gbVidaSilvestreR = new System.Windows.Forms.GroupBox();
			this.toolStrip16 = new System.Windows.Forms.ToolStrip();
			this.btnAgregarSilvestre = new System.Windows.Forms.ToolStripButton();
			this.btnEliminaSilvestre = new System.Windows.Forms.ToolStripButton();
			this.dgvVidaSilvestreR = new System.Windows.Forms.DataGridView();
			this.colCodigoSilvestreR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreSilvestreR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDescripcionSilvestreR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grbEstableRegencias = new System.Windows.Forms.GroupBox();
			this.panel14 = new System.Windows.Forms.Panel();
			this.toolStrip6 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoEst = new System.Windows.Forms.ToolStripButton();
			this.btnEliminaEst = new System.Windows.Forms.ToolStripButton();
			this.dgvEstablecimientos = new System.Windows.Forms.DataGridView();
			this.colCodigoEstablecimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreEstablecimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoCobrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCobrador = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEstadoEst = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colSesionApEst = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechAproba = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtpVencimiento = new Framework.UserControls.dtpSaseg();
			this.lblVencimiento = new System.Windows.Forms.Label();
			this.txtMonto = new Framework.UserControls.txtNormal();
			this.lblMonto = new System.Windows.Forms.Label();
			this.dtpFecha = new Framework.UserControls.dtpSaseg();
			this.LblFecha = new System.Windows.Forms.Label();
			this.txtNPoliza = new Framework.UserControls.txtNormal();
			this.lblNPoliza = new System.Windows.Forms.Label();
			this.label57 = new System.Windows.Forms.Label();
			this.cmbTipoRegente = new Framework.UserControls.cmbSaseg();
			this.chkCurso = new Framework.UserControls.chkSaseg();
			this.dtpPerdida = new Framework.UserControls.dtpSaseg();
			this.label46 = new System.Windows.Forms.Label();
			this.txtSesionPerdida = new Framework.UserControls.txtNormal();
			this.label47 = new System.Windows.Forms.Label();
			this.dtpAprobacion = new Framework.UserControls.dtpSaseg();
			this.label48 = new System.Windows.Forms.Label();
			this.txtSesionAprobacion = new Framework.UserControls.txtNormal();
			this.label67 = new System.Windows.Forms.Label();
			this.txtCobradorRegente = new Framework.UserControls.txtNormal();
			this.label68 = new System.Windows.Forms.Label();
			this.txtCobradorNombre = new Framework.UserControls.txtNormal();
			this.panel10 = new System.Windows.Forms.Panel();
			this.label35 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.dtpFechaModCelular = new Framework.UserControls.dtpSaseg();
			this.dtpFechaModEmail = new Framework.UserControls.dtpSaseg();
			this.btnCambioCategoria = new System.Windows.Forms.Button();
			this.toolStrip14 = new System.Windows.Forms.ToolStrip();
			this.btnRPTFichaColegiado = new System.Windows.Forms.ToolStripButton();
			this.btnCambioCondicion = new System.Windows.Forms.Button();
			this.dtpRegresoCondicion = new Framework.UserControls.dtpSaseg();
			this.lblRegresoCondi = new System.Windows.Forms.Label();
			this.lblCodSesionIncorporacion = new System.Windows.Forms.Label();
			this.txtCodigoSesionIncorporacion = new Framework.UserControls.txtNormal();
			this.lblIdCole = new System.Windows.Forms.Label();
			this.btnQuitarImagen = new System.Windows.Forms.Button();
			this.txtIdColegiado = new Framework.UserControls.txtNormal();
			this.btnImagen = new System.Windows.Forms.Button();
			this.pcbFoto = new System.Windows.Forms.PictureBox();
			this.lbTelOficina = new System.Windows.Forms.Label();
			this.txtTelefono3 = new Framework.UserControls.txtNormal();
			this.txtEdad = new Framework.UserControls.txtNormal();
			this.label54 = new System.Windows.Forms.Label();
			this.txtDescCondicion = new Framework.UserControls.txtNormal();
			this.txtCondicion = new Framework.UserControls.txtNormal();
			this.dtpFechaIngreso = new Framework.UserControls.dtpSaseg();
			this.label14 = new System.Windows.Forms.Label();
			this.txtDescCategoria = new Framework.UserControls.txtNormal();
			this.txtCantonNombreF = new Framework.UserControls.txtNormal();
			this.txtProvinciaNombreF = new Framework.UserControls.txtNormal();
			this.txtCategoria = new Framework.UserControls.txtNormal();
			this.txtDescripcionPais = new Framework.UserControls.txtNormal();
			this.rtbDireccion = new Framework.UserControls.rtbSaseg();
			this.dtpFechaNac = new Framework.UserControls.dtpSaseg();
			this.label9 = new System.Windows.Forms.Label();
			this.txtPais = new Framework.UserControls.txtNormal();
			this.txtNumeColegiado = new Framework.UserControls.txtNormal();
			this.txtCedula = new Framework.UserControls.txtNormal();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label40 = new System.Windows.Forms.Label();
			this.txtEmpresa = new Framework.UserControls.txtNormal();
			this.label52 = new System.Windows.Forms.Label();
			this.txtEmpresaN = new Framework.UserControls.txtNormal();
			this.dgvHistorialLaboral = new System.Windows.Forms.DataGridView();
			this.colNombreEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoPuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCorreoEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEmpresaDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEmpresaHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDireccionEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.miniToolStrip = new System.Windows.Forms.ToolStrip();
			this.btnNuevaEmpresa = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarEmpresa = new System.Windows.Forms.ToolStripButton();
			this.tpLaboral = new System.Windows.Forms.TabPage();
			this.txtHistPuesto = new Framework.UserControls.txtNormal();
			this.txtDescPuesto = new Framework.UserControls.txtNormal();
			this.label86 = new System.Windows.Forms.Label();
			this.txtPuesto = new Framework.UserControls.txtNormal();
			this.rtbDireccionLaboral = new Framework.UserControls.rtbSaseg();
			this.label87 = new System.Windows.Forms.Label();
			this.txtCorreoLaboral = new Framework.UserControls.txtNormal();
			this.label85 = new System.Windows.Forms.Label();
			this.txtHistTelEmpresa = new Framework.UserControls.txtNormal();
			this.label60 = new System.Windows.Forms.Label();
			this.txtHistEmpresa = new Framework.UserControls.txtNormal();
			this.grbRangoLaboral = new System.Windows.Forms.GroupBox();
			this.label55 = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.dtpEmpresaHasta = new Framework.UserControls.dtpSaseg();
			this.dtpEmpresaDesde = new Framework.UserControls.dtpSaseg();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.btnModificarlaboral = new System.Windows.Forms.ToolStripButton();
			this.tpPlantilla = new System.Windows.Forms.TabPage();
			this.lblCantTotalPlantillaCobro = new System.Windows.Forms.Label();
			this.lblTotalPlantillaCobro = new System.Windows.Forms.Label();
			this.panel16 = new System.Windows.Forms.Panel();
			this.label65 = new System.Windows.Forms.Label();
			this.grbPlantilla = new System.Windows.Forms.GroupBox();
			this.toolStrip13 = new System.Windows.Forms.ToolStrip();
			this.btnPagoCouta = new System.Windows.Forms.ToolStripButton();
			this.chkPedConcepto = new Framework.UserControls.chkSaseg();
			this.label72 = new System.Windows.Forms.Label();
			this.txtFrecuDias = new Framework.UserControls.txtNormal();
			this.label71 = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.txtFrecuDescripcion = new Framework.UserControls.txtNormal();
			this.txtFrecu = new Framework.UserControls.txtNormal();
			this.dgvPlantilla = new System.Windows.Forms.DataGridView();
			this.colPlantilla = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCondicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colMontoArticulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtPlantillaN = new Framework.UserControls.txtNormal();
			this.label66 = new System.Windows.Forms.Label();
			this.txtPlantilla = new Framework.UserControls.txtNormal();
			this.btnAdicional = new System.Windows.Forms.ToolStripButton();
			this.btnAdicionalD = new System.Windows.Forms.ToolStripButton();
			this.tpPago_Mutualidad = new System.Windows.Forms.TabPage();
			this.grbMutualidad = new System.Windows.Forms.GroupBox();
			this.label89 = new System.Windows.Forms.Label();
			this.txtCalculoMutualidadMontoRenunciar = new Framework.UserControls.txtNormal();
			this.label88 = new System.Windows.Forms.Label();
			this.txtCalculoMutualidadMeses = new Framework.UserControls.txtNormal();
			this.txtBeneChequeNombre = new Framework.UserControls.txtNormal();
			this.txtBeneficiarioCheque = new Framework.UserControls.txtNormal();
			this.lblBenef = new System.Windows.Forms.Label();
			this.lblCheque = new System.Windows.Forms.Label();
			this.txtCheque = new Framework.UserControls.txtNormal();
			this.dtpFallecimiento = new Framework.UserControls.dtpSaseg();
			this.lblDtpFallec = new System.Windows.Forms.Label();
			this.rtbRazon = new Framework.UserControls.rtbSaseg();
			this.label36 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.chkRenuncia = new Framework.UserControls.chkSaseg();
			this.txtCalculoMutualidad = new Framework.UserControls.txtNormal();
			this.grbTituloObligatorio = new System.Windows.Forms.GroupBox();
			this.dtpFechaTitulo = new Framework.UserControls.dtpSaseg();
			this.label64 = new System.Windows.Forms.Label();
			this.label63 = new System.Windows.Forms.Label();
			this.txtCalculoTitulo = new Framework.UserControls.txtNormal();
			this.rbNoTitulo = new Framework.UserControls.rbSaseg();
			this.rbSiTitulo = new Framework.UserControls.rbSaseg();
			this.grbPagoMut = new System.Windows.Forms.GroupBox();
			this.mtbTarjeta = new System.Windows.Forms.MaskedTextBox();
			this.dtpTarjetaVencimiento = new Framework.UserControls.dtpSaseg();
			this.mtbVenciminetoTerjeta = new System.Windows.Forms.MaskedTextBox();
			this.txtDescEntidadFinanciera = new Framework.UserControls.txtNormal();
			this.lblEntidadFinan = new System.Windows.Forms.Label();
			this.txtEntidadFinanciera = new Framework.UserControls.txtNormal();
			this.chkMorosidad = new Framework.UserControls.chkSaseg();
			this.lblFormaPago = new System.Windows.Forms.Label();
			this.cmbFormaPago = new Framework.UserControls.cmbSaseg();
			this.label37 = new System.Windows.Forms.Label();
			this.txtTarjeta = new Framework.UserControls.txtNormal();
			this.label38 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.cmbTipoTarjeta = new Framework.UserControls.cmbSaseg();
			this.txtDescCobrador = new Framework.UserControls.txtNormal();
			this.lblCobrador = new System.Windows.Forms.Label();
			this.txtCobrador = new Framework.UserControls.txtNormal();
			this.toolStrip12 = new System.Windows.Forms.ToolStrip();
			this.btnRPTMutualidad = new System.Windows.Forms.ToolStripButton();
			this.grbSesionCond = new System.Windows.Forms.GroupBox();
			this.dtpFechaSesionCond = new Framework.UserControls.dtpSaseg();
			this.label61 = new System.Windows.Forms.Label();
			this.label62 = new System.Windows.Forms.Label();
			this.txtSesionCond = new Framework.UserControls.txtNormal();
			this.panel17 = new System.Windows.Forms.Panel();
			this.label73 = new System.Windows.Forms.Label();
			this.tpPeritajes = new System.Windows.Forms.TabPage();
			this.panel4 = new System.Windows.Forms.Panel();
			this.groupBox16 = new System.Windows.Forms.GroupBox();
			this.groupBox18 = new System.Windows.Forms.GroupBox();
			this.rbPerProcNO = new Framework.UserControls.rbSaseg();
			this.rbPerProcSI = new Framework.UserControls.rbSaseg();
			this.groupBox19 = new System.Windows.Forms.GroupBox();
			this.rbPerFacNO = new Framework.UserControls.rbSaseg();
			this.rbPerFacSI = new Framework.UserControls.rbSaseg();
			this.txtCobradorPeritaje = new Framework.UserControls.txtNormal();
			this.label81 = new System.Windows.Forms.Label();
			this.txtCobradorPeritajeNombre = new Framework.UserControls.txtNormal();
			this.chkCursoPeritaje = new Framework.UserControls.chkSaseg();
			this.label74 = new System.Windows.Forms.Label();
			this.rtbObservaciones = new Framework.UserControls.rtbSaseg();
			this.dtpSesionPerdidaPeritaje = new Framework.UserControls.dtpSaseg();
			this.label75 = new System.Windows.Forms.Label();
			this.txtSesionPerdidaPeritaje = new Framework.UserControls.txtNormal();
			this.label76 = new System.Windows.Forms.Label();
			this.dtpRenovacion = new Framework.UserControls.dtpSaseg();
			this.label77 = new System.Windows.Forms.Label();
			this.txtSesionRenov = new Framework.UserControls.txtNormal();
			this.label78 = new System.Windows.Forms.Label();
			this.dtpSesionAprobPeritaje = new Framework.UserControls.dtpSaseg();
			this.label79 = new System.Windows.Forms.Label();
			this.txtSesionAprobPeritaje = new Framework.UserControls.txtNormal();
			this.label80 = new System.Windows.Forms.Label();
			this.txtInstitucion = new Framework.UserControls.txtNormal();
			this.label82 = new System.Windows.Forms.Label();
			this.txtNombreInstitucion = new Framework.UserControls.txtNormal();
			this.label83 = new System.Windows.Forms.Label();
			this.cmbTipoPerito = new Framework.UserControls.cmbSaseg();
			this.panel18 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.tpViaAerea = new System.Windows.Forms.TabPage();
			this.grbPagaCanonAerea = new System.Windows.Forms.GroupBox();
			this.rbPagCanAereaNO = new Framework.UserControls.rbSaseg();
			this.rbPagCanAereaSI = new Framework.UserControls.rbSaseg();
			this.grbEstadoCanonAerea = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.rbViaProcNO = new Framework.UserControls.rbSaseg();
			this.rbViaProcSI = new Framework.UserControls.rbSaseg();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.rbViaFacNO = new Framework.UserControls.rbSaseg();
			this.rbViaFacSI = new Framework.UserControls.rbSaseg();
			this.panelAerea = new System.Windows.Forms.Panel();
			this.panel19 = new System.Windows.Forms.Panel();
			this.toolStrip10 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoAerea = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarAerea = new System.Windows.Forms.ToolStripButton();
			this.dgvViaAerea = new System.Windows.Forms.DataGridView();
			this.colCodigoAerea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreAerea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colObservacionesAerea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPagaCanonAerea = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colSesionAproAerea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaAproAerea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSesionRenovAerea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaRenovAerea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSesionPerdAerea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaPerdAerea = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colActivoViaAerea = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.panel15 = new System.Windows.Forms.Panel();
			this.label22 = new System.Windows.Forms.Label();
			this.txtCentroAcademico = new Framework.UserControls.txtNormal();
			this.label50 = new System.Windows.Forms.Label();
			this.txtCentroAcademicoN = new Framework.UserControls.txtNormal();
			this.txtTituloAcademico = new Framework.UserControls.txtNormal();
			this.label51 = new System.Windows.Forms.Label();
			this.txtTituloAcademicoN = new Framework.UserControls.txtNormal();
			this.dgvHistorialAcademico = new System.Windows.Forms.DataGridView();
			this.colCodigoCentro = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreCentro = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoGrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreGrado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCodigoEnfasis = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colEnfasis = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaGradu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip7 = new System.Windows.Forms.ToolStrip();
			this.btnNuevaFormacion = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarFormacion = new System.Windows.Forms.ToolStripButton();
			this.btnModificarAcademico = new System.Windows.Forms.ToolStripButton();
			this.txtEnfasis = new Framework.UserControls.txtNormal();
			this.label23 = new System.Windows.Forms.Label();
			this.txtEnfasisN = new Framework.UserControls.txtNormal();
			this.txtPaisTitulo = new Framework.UserControls.txtNormal();
			this.label84 = new System.Windows.Forms.Label();
			this.txtNombrePaisTitulo = new Framework.UserControls.txtNormal();
			this.gbGradoAcade = new System.Windows.Forms.GroupBox();
			this.clbGrados = new Framework.UserControls.clbSaseg();
			this.tpAcademico = new System.Windows.Forms.TabPage();
			this.lblFechaGradu = new System.Windows.Forms.Label();
			this.dtpFechaGradu = new Framework.UserControls.dtpSaseg();
			this.tpSilvestre = new System.Windows.Forms.TabPage();
			this.grbEstadoCanonSilve = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbSilveProcNO = new Framework.UserControls.rbSaseg();
			this.rbSilveProcSI = new Framework.UserControls.rbSaseg();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.rbSilveFacNO = new Framework.UserControls.rbSaseg();
			this.rbSilveFacSI = new Framework.UserControls.rbSaseg();
			this.panelSilve = new System.Windows.Forms.Panel();
			this.panel13 = new System.Windows.Forms.Panel();
			this.toolStrip15 = new System.Windows.Forms.ToolStrip();
			this.btnNuevoSilvestre = new System.Windows.Forms.ToolStripButton();
			this.btnEliminarSilvestre = new System.Windows.Forms.ToolStripButton();
			this.dgvVidaSilvestre = new System.Windows.Forms.DataGridView();
			this.colCodigoSilvestre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNombreSilvestre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPagaCanonSilve = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colSesionAprobacionSilve = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaAprobacionSilve = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSesionRenovacionSilve = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaRenovacionSilve = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSesionPerdidaSilve = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colFechaPerdidaSilve = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colObservacionesSilve = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colActivoSilvestre = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.grbPagaCanonSilve = new System.Windows.Forms.GroupBox();
			this.rbPagCanSilveNO = new Framework.UserControls.rbSaseg();
			this.rbPagCanSilveSI = new Framework.UserControls.rbSaseg();
			this.dtpFechaModDireccion = new Framework.UserControls.dtpSaseg();
			((System.ComponentModel.ISupportInitialize)(this.dtDatos)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tpBasicos.SuspendLayout();
			this.tpAdmin.SuspendLayout();
			this.panelBasicos.SuspendLayout();
			this.tpAdjuntos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flvListado)).BeginInit();
			this.tpPlaguicidas.SuspendLayout();
			this.grbPagaCanonPlagui.SuspendLayout();
			this.grbEstadoCanonPlagui.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.panelPlagui.SuspendLayout();
			this.panel20.SuspendLayout();
			this.toolStrip5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvInvestigacionPlaguicidas)).BeginInit();
			this.tpBeneficiarios.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dlvBeneficiarios)).BeginInit();
			this.toolStrip11.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tpEspecialidades.SuspendLayout();
			this.toolStrip8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCamposEspecialidad)).BeginInit();
			this.toolStrip4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
			this.panel11.SuspendLayout();
			this.grbSesionEspecialidad.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tpHistorial.SuspendLayout();
			this.grbHistorialSesiones.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHistorialSesiones)).BeginInit();
			this.panel9.SuspendLayout();
			this.tpAlertas.SuspendLayout();
			this.panel6.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
			this.tpGestionCobro.SuspendLayout();
			this.grbAdelantos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGestionCobroAdel)).BeginInit();
			this.grbPendientes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGestionCobro)).BeginInit();
			this.panelGestionCobro.SuspendLayout();
			this.toolStrip9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGestionCobro2)).BeginInit();
			this.panel7.SuspendLayout();
			this.tpRevista.SuspendLayout();
			this.panel8.SuspendLayout();
			this.tpRegencias.SuspendLayout();
			this.gbVidaSilvestreR.SuspendLayout();
			this.toolStrip16.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVidaSilvestreR)).BeginInit();
			this.grbEstableRegencias.SuspendLayout();
			this.panel14.SuspendLayout();
			this.toolStrip6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEstablecimientos)).BeginInit();
			this.panel10.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.toolStrip14.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).BeginInit();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHistorialLaboral)).BeginInit();
			this.tpLaboral.SuspendLayout();
			this.grbRangoLaboral.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.tpPlantilla.SuspendLayout();
			this.panel16.SuspendLayout();
			this.grbPlantilla.SuspendLayout();
			this.toolStrip13.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPlantilla)).BeginInit();
			this.tpPago_Mutualidad.SuspendLayout();
			this.grbMutualidad.SuspendLayout();
			this.grbTituloObligatorio.SuspendLayout();
			this.grbPagoMut.SuspendLayout();
			this.toolStrip12.SuspendLayout();
			this.grbSesionCond.SuspendLayout();
			this.panel17.SuspendLayout();
			this.tpPeritajes.SuspendLayout();
			this.panel4.SuspendLayout();
			this.groupBox16.SuspendLayout();
			this.groupBox18.SuspendLayout();
			this.groupBox19.SuspendLayout();
			this.panel18.SuspendLayout();
			this.tpViaAerea.SuspendLayout();
			this.grbPagaCanonAerea.SuspendLayout();
			this.grbEstadoCanonAerea.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.panelAerea.SuspendLayout();
			this.panel19.SuspendLayout();
			this.toolStrip10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvViaAerea)).BeginInit();
			this.panel15.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHistorialAcademico)).BeginInit();
			this.toolStrip7.SuspendLayout();
			this.gbGradoAcade.SuspendLayout();
			this.tpAcademico.SuspendLayout();
			this.tpSilvestre.SuspendLayout();
			this.grbEstadoCanonSilve.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.panelSilve.SuspendLayout();
			this.panel13.SuspendLayout();
			this.toolStrip15.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVidaSilvestre)).BeginInit();
			this.grbPagaCanonSilve.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tpPago_Mutualidad);
			this.tabControl.Controls.Add(this.tpBeneficiarios);
			this.tabControl.Controls.Add(this.tpPlantilla);
			this.tabControl.Controls.Add(this.tpAcademico);
			this.tabControl.Controls.Add(this.tpLaboral);
			this.tabControl.Controls.Add(this.tpEspecialidades);
			this.tabControl.Controls.Add(this.tpViaAerea);
			this.tabControl.Controls.Add(this.tpPlaguicidas);
			this.tabControl.Controls.Add(this.tpSilvestre);
			this.tabControl.Controls.Add(this.tpPeritajes);
			this.tabControl.Controls.Add(this.tpRegencias);
			this.tabControl.Controls.Add(this.tpHistorial);
			this.tabControl.Controls.Add(this.tpAlertas);
			this.tabControl.Controls.Add(this.tpGestionCobro);
			this.tabControl.Controls.Add(this.tpRevista);
			this.tabControl.Size = new System.Drawing.Size(1005, 592);
			this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
			this.tabControl.Controls.SetChildIndex(this.tpRevista, 0);
			this.tabControl.Controls.SetChildIndex(this.tpGestionCobro, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAlertas, 0);
			this.tabControl.Controls.SetChildIndex(this.tpHistorial, 0);
			this.tabControl.Controls.SetChildIndex(this.tpRegencias, 0);
			this.tabControl.Controls.SetChildIndex(this.tpPeritajes, 0);
			this.tabControl.Controls.SetChildIndex(this.tpSilvestre, 0);
			this.tabControl.Controls.SetChildIndex(this.tpPlaguicidas, 0);
			this.tabControl.Controls.SetChildIndex(this.tpViaAerea, 0);
			this.tabControl.Controls.SetChildIndex(this.tpEspecialidades, 0);
			this.tabControl.Controls.SetChildIndex(this.tpLaboral, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAcademico, 0);
			this.tabControl.Controls.SetChildIndex(this.tpPlantilla, 0);
			this.tabControl.Controls.SetChildIndex(this.tpBeneficiarios, 0);
			this.tabControl.Controls.SetChildIndex(this.tpPago_Mutualidad, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAdjuntos, 0);
			this.tabControl.Controls.SetChildIndex(this.tpAdmin, 0);
			this.tabControl.Controls.SetChildIndex(this.tpBasicos, 0);
			// 
			// tpBasicos
			// 
			this.tpBasicos.Controls.Add(this.groupBox11);
			this.tpBasicos.Size = new System.Drawing.Size(997, 566);
			this.tpBasicos.Controls.SetChildIndex(this.groupBox11, 0);
			this.tpBasicos.Controls.SetChildIndex(this.panelBasicos, 0);
			// 
			// tpAdmin
			// 
			this.tpAdmin.Size = new System.Drawing.Size(997, 566);
			// 
			// panelAdmin
			// 
			this.panelAdmin.Size = new System.Drawing.Size(991, 21);
			// 
			// panelBasicos
			// 
			this.panelBasicos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelBasicos.Dock = System.Windows.Forms.DockStyle.None;
			this.panelBasicos.Size = new System.Drawing.Size(991, 21);
			// 
			// tpAdjuntos
			// 
			this.tpAdjuntos.Size = new System.Drawing.Size(997, 566);
			// 
			// panelAdjuntos
			// 
			this.panelAdjuntos.Size = new System.Drawing.Size(991, 21);
			// 
			// flvListado
			// 
			this.flvListado.Size = new System.Drawing.Size(670, 293);
			// 
			// tpPlaguicidas
			// 
			this.tpPlaguicidas.Controls.Add(this.grbPagaCanonPlagui);
			this.tpPlaguicidas.Controls.Add(this.grbEstadoCanonPlagui);
			this.tpPlaguicidas.Controls.Add(this.panelPlagui);
			this.tpPlaguicidas.Location = new System.Drawing.Point(4, 22);
			this.tpPlaguicidas.Name = "tpPlaguicidas";
			this.tpPlaguicidas.Size = new System.Drawing.Size(997, 566);
			this.tpPlaguicidas.TabIndex = 4;
			this.tpPlaguicidas.Text = "Investigación de Plaguicidas";
			this.tpPlaguicidas.UseVisualStyleBackColor = true;
			// 
			// grbPagaCanonPlagui
			// 
			this.grbPagaCanonPlagui.Controls.Add(this.rbPagCanPlaguiNO);
			this.grbPagaCanonPlagui.Controls.Add(this.rbPagCanPlaguiSI);
			this.grbPagaCanonPlagui.Location = new System.Drawing.Point(12, 10);
			this.grbPagaCanonPlagui.Name = "grbPagaCanonPlagui";
			this.grbPagaCanonPlagui.Size = new System.Drawing.Size(114, 46);
			this.grbPagaCanonPlagui.TabIndex = 284;
			this.grbPagaCanonPlagui.TabStop = false;
			this.grbPagaCanonPlagui.Text = "Paga Canon";
			// 
			// rbPagCanPlaguiNO
			// 
			this.rbPagCanPlaguiNO.Checked = false;
			this.rbPagCanPlaguiNO.Location = new System.Drawing.Point(65, 20);
			this.rbPagCanPlaguiNO.Name = "rbPagCanPlaguiNO";
			this.rbPagCanPlaguiNO.Size = new System.Drawing.Size(44, 18);
			this.rbPagCanPlaguiNO.TabIndex = 0;
			this.rbPagCanPlaguiNO.Texto = "No";
			// 
			// rbPagCanPlaguiSI
			// 
			this.rbPagCanPlaguiSI.Checked = false;
			this.rbPagCanPlaguiSI.Location = new System.Drawing.Point(20, 20);
			this.rbPagCanPlaguiSI.Name = "rbPagCanPlaguiSI";
			this.rbPagCanPlaguiSI.Size = new System.Drawing.Size(44, 18);
			this.rbPagCanPlaguiSI.TabIndex = 1;
			this.rbPagCanPlaguiSI.Texto = "Si";
			// 
			// grbEstadoCanonPlagui
			// 
			this.grbEstadoCanonPlagui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grbEstadoCanonPlagui.Controls.Add(this.groupBox13);
			this.grbEstadoCanonPlagui.Controls.Add(this.groupBox14);
			this.grbEstadoCanonPlagui.Location = new System.Drawing.Point(-10300, 10);
			this.grbEstadoCanonPlagui.Name = "grbEstadoCanonPlagui";
			this.grbEstadoCanonPlagui.Size = new System.Drawing.Size(285, 87);
			this.grbEstadoCanonPlagui.TabIndex = 283;
			this.grbEstadoCanonPlagui.TabStop = false;
			this.grbEstadoCanonPlagui.Text = "Estado Canon";
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.rbPlaguiProcNO);
			this.groupBox13.Controls.Add(this.rbPlaguiProcSI);
			this.groupBox13.Location = new System.Drawing.Point(26, 17);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(113, 58);
			this.groupBox13.TabIndex = 284;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Procesado";
			// 
			// rbPlaguiProcNO
			// 
			this.rbPlaguiProcNO.Checked = true;
			this.rbPlaguiProcNO.Enabled = false;
			this.rbPlaguiProcNO.Location = new System.Drawing.Point(63, 27);
			this.rbPlaguiProcNO.Name = "rbPlaguiProcNO";
			this.rbPlaguiProcNO.Size = new System.Drawing.Size(40, 18);
			this.rbPlaguiProcNO.TabIndex = 0;
			this.rbPlaguiProcNO.Texto = "No ";
			// 
			// rbPlaguiProcSI
			// 
			this.rbPlaguiProcSI.Checked = false;
			this.rbPlaguiProcSI.Enabled = false;
			this.rbPlaguiProcSI.Location = new System.Drawing.Point(15, 27);
			this.rbPlaguiProcSI.Name = "rbPlaguiProcSI";
			this.rbPlaguiProcSI.Size = new System.Drawing.Size(42, 18);
			this.rbPlaguiProcSI.TabIndex = 1;
			this.rbPlaguiProcSI.Texto = "Si";
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.rbPlaguiFacNO);
			this.groupBox14.Controls.Add(this.rbPlaguiFacSI);
			this.groupBox14.Location = new System.Drawing.Point(145, 17);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(113, 58);
			this.groupBox14.TabIndex = 283;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Facturado";
			// 
			// rbPlaguiFacNO
			// 
			this.rbPlaguiFacNO.Checked = true;
			this.rbPlaguiFacNO.Enabled = false;
			this.rbPlaguiFacNO.Location = new System.Drawing.Point(63, 27);
			this.rbPlaguiFacNO.Name = "rbPlaguiFacNO";
			this.rbPlaguiFacNO.Size = new System.Drawing.Size(40, 18);
			this.rbPlaguiFacNO.TabIndex = 0;
			this.rbPlaguiFacNO.Texto = "No ";
			// 
			// rbPlaguiFacSI
			// 
			this.rbPlaguiFacSI.Checked = false;
			this.rbPlaguiFacSI.Enabled = false;
			this.rbPlaguiFacSI.Location = new System.Drawing.Point(15, 27);
			this.rbPlaguiFacSI.Name = "rbPlaguiFacSI";
			this.rbPlaguiFacSI.Size = new System.Drawing.Size(42, 18);
			this.rbPlaguiFacSI.TabIndex = 1;
			this.rbPlaguiFacSI.Texto = "Si";
			// 
			// panelPlagui
			// 
			this.panelPlagui.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelPlagui.Controls.Add(this.panel20);
			this.panelPlagui.Controls.Add(this.dgvInvestigacionPlaguicidas);
			this.panelPlagui.Location = new System.Drawing.Point(32, 85);
			this.panelPlagui.Name = "panelPlagui";
			this.panelPlagui.Size = new System.Drawing.Size(0, 0);
			this.panelPlagui.TabIndex = 251;
			// 
			// panel20
			// 
			this.panel20.Controls.Add(this.toolStrip5);
			this.panel20.Location = new System.Drawing.Point(4, 3);
			this.panel20.Name = "panel20";
			this.panel20.Size = new System.Drawing.Size(74, 33);
			this.panel20.TabIndex = 284;
			// 
			// toolStrip5
			// 
			this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoPlaguicida,
            this.btnEliminaPlagui});
			this.toolStrip5.Location = new System.Drawing.Point(0, 0);
			this.toolStrip5.Name = "toolStrip5";
			this.toolStrip5.Size = new System.Drawing.Size(74, 25);
			this.toolStrip5.TabIndex = 256;
			this.toolStrip5.Text = "toolStrip5";
			// 
			// btnNuevoPlaguicida
			// 
			this.btnNuevoPlaguicida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevoPlaguicida.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoPlaguicida.Image")));
			this.btnNuevoPlaguicida.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevoPlaguicida.Name = "btnNuevoPlaguicida";
			this.btnNuevoPlaguicida.Size = new System.Drawing.Size(23, 22);
			this.btnNuevoPlaguicida.Text = "Agregar Campos de Investigación";
			this.btnNuevoPlaguicida.Click += new System.EventHandler(this.btnNuevoPlaguicida_Click);
			// 
			// btnEliminaPlagui
			// 
			this.btnEliminaPlagui.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminaPlagui.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaPlagui.Image")));
			this.btnEliminaPlagui.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminaPlagui.Name = "btnEliminaPlagui";
			this.btnEliminaPlagui.Size = new System.Drawing.Size(23, 22);
			this.btnEliminaPlagui.Text = "Quitar Campo de Investigación";
			this.btnEliminaPlagui.Click += new System.EventHandler(this.btnEliminaPlagui_Click);
			// 
			// dgvInvestigacionPlaguicidas
			// 
			this.dgvInvestigacionPlaguicidas.AllowUserToAddRows = false;
			this.dgvInvestigacionPlaguicidas.AllowUserToDeleteRows = false;
			this.dgvInvestigacionPlaguicidas.AllowUserToResizeRows = false;
			this.dgvInvestigacionPlaguicidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvInvestigacionPlaguicidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvInvestigacionPlaguicidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvInvestigacionPlaguicidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoCampo,
            this.colNombreCampo,
            this.colPagaCanon,
            this.colSesionAprobacion,
            this.colFechaAprobacion,
            this.colSesionRenovacion,
            this.colFechaRenovacion,
            this.colSesionPerdidaP,
            this.colFechaPerdidaP,
            this.colObservaciones,
            this.colActivoPlagui});
			this.dgvInvestigacionPlaguicidas.Location = new System.Drawing.Point(3, 31);
			this.dgvInvestigacionPlaguicidas.Name = "dgvInvestigacionPlaguicidas";
			this.dgvInvestigacionPlaguicidas.RowHeadersVisible = false;
			this.dgvInvestigacionPlaguicidas.Size = new System.Drawing.Size(0, 0);
			this.dgvInvestigacionPlaguicidas.TabIndex = 253;
			this.dgvInvestigacionPlaguicidas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvestigacionPlaguicidas_CellClick);
			this.dgvInvestigacionPlaguicidas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvInvestigacionPlaguicidas_CurrentCellDirtyStateChanged);
			this.dgvInvestigacionPlaguicidas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvInvestigacionPlaguicidas_MouseDoubleClick);
			// 
			// colCodigoCampo
			// 
			this.colCodigoCampo.HeaderText = "Código";
			this.colCodigoCampo.Name = "colCodigoCampo";
			this.colCodigoCampo.ReadOnly = true;
			// 
			// colNombreCampo
			// 
			this.colNombreCampo.HeaderText = "Nombre";
			this.colNombreCampo.Name = "colNombreCampo";
			this.colNombreCampo.ReadOnly = true;
			// 
			// colPagaCanon
			// 
			this.colPagaCanon.HeaderText = "Paga Canon";
			this.colPagaCanon.Items.AddRange(new object[] {
            "Si",
            "No"});
			this.colPagaCanon.Name = "colPagaCanon";
			this.colPagaCanon.Visible = false;
			// 
			// colSesionAprobacion
			// 
			this.colSesionAprobacion.HeaderText = "Sesión Aprobación";
			this.colSesionAprobacion.Name = "colSesionAprobacion";
			// 
			// colFechaAprobacion
			// 
			this.colFechaAprobacion.HeaderText = "Fecha Aprobación";
			this.colFechaAprobacion.Name = "colFechaAprobacion";
			this.colFechaAprobacion.ReadOnly = true;
			// 
			// colSesionRenovacion
			// 
			this.colSesionRenovacion.HeaderText = "Sesión Renovación";
			this.colSesionRenovacion.Name = "colSesionRenovacion";
			// 
			// colFechaRenovacion
			// 
			this.colFechaRenovacion.HeaderText = "Fecha Renovación";
			this.colFechaRenovacion.Name = "colFechaRenovacion";
			this.colFechaRenovacion.ReadOnly = true;
			// 
			// colSesionPerdidaP
			// 
			this.colSesionPerdidaP.HeaderText = "Sesión Pérdida";
			this.colSesionPerdidaP.Name = "colSesionPerdidaP";
			// 
			// colFechaPerdidaP
			// 
			this.colFechaPerdidaP.HeaderText = "Fecha Pérdida";
			this.colFechaPerdidaP.Name = "colFechaPerdidaP";
			this.colFechaPerdidaP.ReadOnly = true;
			// 
			// colObservaciones
			// 
			this.colObservaciones.HeaderText = "Observaciones";
			this.colObservaciones.Name = "colObservaciones";
			// 
			// colActivoPlagui
			// 
			this.colActivoPlagui.HeaderText = "Activo";
			this.colActivoPlagui.Name = "colActivoPlagui";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label30.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label30.Location = new System.Drawing.Point(3, 4);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(162, 14);
			this.label30.TabIndex = 0;
			this.label30.Text = "Investigación de Plaguicidas";
			// 
			// tpBeneficiarios
			// 
			this.tpBeneficiarios.Controls.Add(this.dlvBeneficiarios);
			this.tpBeneficiarios.Controls.Add(this.toolStrip11);
			this.tpBeneficiarios.Controls.Add(this.panel2);
			this.tpBeneficiarios.Location = new System.Drawing.Point(4, 22);
			this.tpBeneficiarios.Name = "tpBeneficiarios";
			this.tpBeneficiarios.Size = new System.Drawing.Size(997, 566);
			this.tpBeneficiarios.TabIndex = 5;
			this.tpBeneficiarios.Text = "Beneficiarios del FMS";
			this.tpBeneficiarios.UseVisualStyleBackColor = true;
			// 
			// dlvBeneficiarios
			// 
			this.dlvBeneficiarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dlvBeneficiarios.CellEditUseWholeCell = false;
			this.dlvBeneficiarios.Cursor = System.Windows.Forms.Cursors.Default;
			this.dlvBeneficiarios.DataSource = null;
			this.dlvBeneficiarios.FullRowSelect = true;
			this.dlvBeneficiarios.GridLines = true;
			this.dlvBeneficiarios.HideSelection = false;
			this.dlvBeneficiarios.Location = new System.Drawing.Point(3, 55);
			this.dlvBeneficiarios.MenuLabelColumns = "Columnas";
			this.dlvBeneficiarios.MenuLabelGroupBy = "Agrupar Por \'{0}\'";
			this.dlvBeneficiarios.MenuLabelSelectColumns = "Columnas";
			this.dlvBeneficiarios.MenuLabelSortAscending = "Ordenar ascendente por \'{0}\'";
			this.dlvBeneficiarios.MenuLabelSortDescending = "Ordenar descendente por \'{0}\'";
			this.dlvBeneficiarios.MenuLabelTurnOffGroups = "Quitar Grupos";
			this.dlvBeneficiarios.MenuLabelUnsort = "";
			this.dlvBeneficiarios.Name = "dlvBeneficiarios";
			this.dlvBeneficiarios.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.ModelDialog;
			this.dlvBeneficiarios.ShowCommandMenuOnRightClick = true;
			this.dlvBeneficiarios.ShowGroups = false;
			this.dlvBeneficiarios.Size = new System.Drawing.Size(0, 0);
			this.dlvBeneficiarios.TabIndex = 278;
			this.dlvBeneficiarios.UseCompatibleStateImageBehavior = false;
			this.dlvBeneficiarios.UseFilterIndicator = true;
			this.dlvBeneficiarios.UseFiltering = true;
			this.dlvBeneficiarios.UseHotItem = true;
			this.dlvBeneficiarios.View = System.Windows.Forms.View.Details;
			this.dlvBeneficiarios.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dlvBeneficiarios_MouseDoubleClick);
			// 
			// toolStrip11
			// 
			this.toolStrip11.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoBeneficiario,
            this.btnEliminarBeneficiario,
            this.btnModificarBeneficiario,
            this.toolStripSeparator2,
            this.btnRefrescarBeneficiarios});
			this.toolStrip11.Location = new System.Drawing.Point(3, 27);
			this.toolStrip11.Name = "toolStrip11";
			this.toolStrip11.Size = new System.Drawing.Size(110, 25);
			this.toolStrip11.TabIndex = 277;
			this.toolStrip11.Text = "toolStrip11";
			// 
			// btnNuevoBeneficiario
			// 
			this.btnNuevoBeneficiario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevoBeneficiario.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoBeneficiario.Image")));
			this.btnNuevoBeneficiario.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevoBeneficiario.Name = "btnNuevoBeneficiario";
			this.btnNuevoBeneficiario.Size = new System.Drawing.Size(23, 22);
			this.btnNuevoBeneficiario.Text = "Nuevo";
			this.btnNuevoBeneficiario.Click += new System.EventHandler(this.btnNuevoBeneficiario_Click);
			// 
			// btnEliminarBeneficiario
			// 
			this.btnEliminarBeneficiario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarBeneficiario.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarBeneficiario.Image")));
			this.btnEliminarBeneficiario.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarBeneficiario.Name = "btnEliminarBeneficiario";
			this.btnEliminarBeneficiario.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarBeneficiario.Text = "Eliminar";
			this.btnEliminarBeneficiario.Click += new System.EventHandler(this.btnEliminarBeneficiario_Click);
			// 
			// btnModificarBeneficiario
			// 
			this.btnModificarBeneficiario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnModificarBeneficiario.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarBeneficiario.Image")));
			this.btnModificarBeneficiario.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnModificarBeneficiario.Name = "btnModificarBeneficiario";
			this.btnModificarBeneficiario.Size = new System.Drawing.Size(23, 22);
			this.btnModificarBeneficiario.Text = "Modificar";
			this.btnModificarBeneficiario.Click += new System.EventHandler(this.btnModificarBeneficiario_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btnRefrescarBeneficiarios
			// 
			this.btnRefrescarBeneficiarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRefrescarBeneficiarios.Image = ((System.Drawing.Image)(resources.GetObject("btnRefrescarBeneficiarios.Image")));
			this.btnRefrescarBeneficiarios.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRefrescarBeneficiarios.Name = "btnRefrescarBeneficiarios";
			this.btnRefrescarBeneficiarios.Size = new System.Drawing.Size(23, 22);
			this.btnRefrescarBeneficiarios.Text = "Refrescar";
			this.btnRefrescarBeneficiarios.Click += new System.EventHandler(this.btnRefrescarBeneficiarios_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.DarkGray;
			this.panel2.Controls.Add(this.label28);
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(0, 21);
			this.panel2.TabIndex = 37;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label28.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label28.Location = new System.Drawing.Point(3, 4);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(196, 14);
			this.label28.TabIndex = 0;
			this.label28.Text = "Historial de Beneficiarios del FMS";
			// 
			// tpEspecialidades
			// 
			this.tpEspecialidades.Controls.Add(this.toolStrip8);
			this.tpEspecialidades.Controls.Add(this.dgvCamposEspecialidad);
			this.tpEspecialidades.Controls.Add(this.txtCampoEspecialidadN);
			this.tpEspecialidades.Controls.Add(this.label59);
			this.tpEspecialidades.Controls.Add(this.txtCampoEspecialidad);
			this.tpEspecialidades.Controls.Add(this.toolStrip4);
			this.tpEspecialidades.Controls.Add(this.dgvEspecialidades);
			this.tpEspecialidades.Controls.Add(this.txtEspecialidadN);
			this.tpEspecialidades.Controls.Add(this.label58);
			this.tpEspecialidades.Controls.Add(this.txtEspecialidad);
			this.tpEspecialidades.Controls.Add(this.panel11);
			this.tpEspecialidades.Controls.Add(this.grbSesionEspecialidad);
			this.tpEspecialidades.Controls.Add(this.panel3);
			this.tpEspecialidades.Location = new System.Drawing.Point(4, 22);
			this.tpEspecialidades.Name = "tpEspecialidades";
			this.tpEspecialidades.Size = new System.Drawing.Size(997, 566);
			this.tpEspecialidades.TabIndex = 6;
			this.tpEspecialidades.Text = "Especialidades";
			this.tpEspecialidades.UseVisualStyleBackColor = true;
			// 
			// toolStrip8
			// 
			this.toolStrip8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.toolStrip8.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarCampo,
            this.btnEliminarCampo});
			this.toolStrip8.Location = new System.Drawing.Point(263, 340);
			this.toolStrip8.Name = "toolStrip8";
			this.toolStrip8.Size = new System.Drawing.Size(58, 25);
			this.toolStrip8.TabIndex = 300;
			this.toolStrip8.Text = "toolStrip8";
			this.toolStrip8.Visible = false;
			// 
			// btnAgregarCampo
			// 
			this.btnAgregarCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAgregarCampo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCampo.Image")));
			this.btnAgregarCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAgregarCampo.Name = "btnAgregarCampo";
			this.btnAgregarCampo.Size = new System.Drawing.Size(23, 22);
			this.btnAgregarCampo.Text = "Agregar Campo";
			this.btnAgregarCampo.Click += new System.EventHandler(this.btnAgregarCampo_Click);
			// 
			// btnEliminarCampo
			// 
			this.btnEliminarCampo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarCampo.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarCampo.Image")));
			this.btnEliminarCampo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarCampo.Name = "btnEliminarCampo";
			this.btnEliminarCampo.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarCampo.Text = "Eliminar Campo";
			this.btnEliminarCampo.Click += new System.EventHandler(this.btnEliminarCampo_Click);
			// 
			// dgvCamposEspecialidad
			// 
			this.dgvCamposEspecialidad.AllowUserToAddRows = false;
			this.dgvCamposEspecialidad.AllowUserToDeleteRows = false;
			this.dgvCamposEspecialidad.AllowUserToResizeRows = false;
			this.dgvCamposEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCamposEspecialidad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCamposEspecialidad.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvCamposEspecialidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCamposEspecialidad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoCampoEspecialidad,
            this.colNombreCampoEspecialidad});
			this.dgvCamposEspecialidad.Location = new System.Drawing.Point(263, 368);
			this.dgvCamposEspecialidad.MultiSelect = false;
			this.dgvCamposEspecialidad.Name = "dgvCamposEspecialidad";
			this.dgvCamposEspecialidad.RowHeadersVisible = false;
			this.dgvCamposEspecialidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCamposEspecialidad.Size = new System.Drawing.Size(0, 0);
			this.dgvCamposEspecialidad.TabIndex = 299;
			this.dgvCamposEspecialidad.Visible = false;
			// 
			// colCodigoCampoEspecialidad
			// 
			this.colCodigoCampoEspecialidad.HeaderText = "Código";
			this.colCodigoCampoEspecialidad.Name = "colCodigoCampoEspecialidad";
			this.colCodigoCampoEspecialidad.ReadOnly = true;
			// 
			// colNombreCampoEspecialidad
			// 
			this.colNombreCampoEspecialidad.FillWeight = 137.0558F;
			this.colNombreCampoEspecialidad.HeaderText = "Campo Especialidad";
			this.colNombreCampoEspecialidad.Name = "colNombreCampoEspecialidad";
			this.colNombreCampoEspecialidad.ReadOnly = true;
			// 
			// txtCampoEspecialidadN
			// 
			this.txtCampoEspecialidadN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCampoEspecialidadN.FormatearNumero = false;
			this.txtCampoEspecialidadN.Location = new System.Drawing.Point(443, 309);
			this.txtCampoEspecialidadN.Longitud = 32767;
			this.txtCampoEspecialidadN.Multilinea = false;
			this.txtCampoEspecialidadN.Name = "txtCampoEspecialidadN";
			this.txtCampoEspecialidadN.Password = '\0';
			this.txtCampoEspecialidadN.ReadOnly = true;
			this.txtCampoEspecialidadN.Size = new System.Drawing.Size(0, 25);
			this.txtCampoEspecialidadN.TabIndex = 290;
			this.txtCampoEspecialidadN.Valor = "";
			this.txtCampoEspecialidadN.Visible = false;
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Location = new System.Drawing.Point(263, 313);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(106, 13);
			this.label59.TabIndex = 289;
			this.label59.Text = "Campo Especialidad:";
			this.label59.Visible = false;
			// 
			// txtCampoEspecialidad
			// 
			this.txtCampoEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCampoEspecialidad.FormatearNumero = false;
			this.txtCampoEspecialidad.Location = new System.Drawing.Point(375, 309);
			this.txtCampoEspecialidad.Longitud = 30;
			this.txtCampoEspecialidad.Multilinea = false;
			this.txtCampoEspecialidad.Name = "txtCampoEspecialidad";
			this.txtCampoEspecialidad.Password = '\0';
			this.txtCampoEspecialidad.ReadOnly = false;
			this.txtCampoEspecialidad.Size = new System.Drawing.Size(0, 25);
			this.txtCampoEspecialidad.TabIndex = 288;
			this.txtCampoEspecialidad.Valor = "";
			this.txtCampoEspecialidad.Visible = false;
			this.txtCampoEspecialidad.Enter += new System.EventHandler(this.txtCampoEspecialidad_Enter);
			this.txtCampoEspecialidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCampoEspecialidad_KeyDown);
			this.txtCampoEspecialidad.Leave += new System.EventHandler(this.txtCampoEspecialidad_Leave);
			this.txtCampoEspecialidad.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCampoEspecialidad_MouseDoubleClick);
			// 
			// toolStrip4
			// 
			this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarEspecialidad,
            this.btnEliminarEspecialidad});
			this.toolStrip4.Location = new System.Drawing.Point(65, 94);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.Size = new System.Drawing.Size(58, 25);
			this.toolStrip4.TabIndex = 287;
			this.toolStrip4.Text = "toolStrip4";
			// 
			// btnAgregarEspecialidad
			// 
			this.btnAgregarEspecialidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAgregarEspecialidad.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarEspecialidad.Image")));
			this.btnAgregarEspecialidad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAgregarEspecialidad.Name = "btnAgregarEspecialidad";
			this.btnAgregarEspecialidad.Size = new System.Drawing.Size(23, 22);
			this.btnAgregarEspecialidad.Text = "Agregar Especialidad";
			this.btnAgregarEspecialidad.Click += new System.EventHandler(this.btnAgregarEspecialidad_Click);
			// 
			// btnEliminarEspecialidad
			// 
			this.btnEliminarEspecialidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarEspecialidad.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarEspecialidad.Image")));
			this.btnEliminarEspecialidad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarEspecialidad.Name = "btnEliminarEspecialidad";
			this.btnEliminarEspecialidad.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarEspecialidad.Text = "Eliminar Especialidad";
			this.btnEliminarEspecialidad.Click += new System.EventHandler(this.btnEliminarEspecialidad_Click);
			// 
			// dgvEspecialidades
			// 
			this.dgvEspecialidades.AllowUserToAddRows = false;
			this.dgvEspecialidades.AllowUserToDeleteRows = false;
			this.dgvEspecialidades.AllowUserToResizeRows = false;
			this.dgvEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvEspecialidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvEspecialidades.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvEspecialidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoEspecialidad,
            this.colNombreEspecialidad,
            this.colCodigoSesionAprob,
            this.colFechaEspecialidad});
			this.dgvEspecialidades.Location = new System.Drawing.Point(65, 122);
			this.dgvEspecialidades.MultiSelect = false;
			this.dgvEspecialidades.Name = "dgvEspecialidades";
			this.dgvEspecialidades.RowHeadersVisible = false;
			this.dgvEspecialidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvEspecialidades.Size = new System.Drawing.Size(0, 339);
			this.dgvEspecialidades.TabIndex = 286;
			// 
			// colCodigoEspecialidad
			// 
			this.colCodigoEspecialidad.HeaderText = "Código";
			this.colCodigoEspecialidad.Name = "colCodigoEspecialidad";
			this.colCodigoEspecialidad.ReadOnly = true;
			// 
			// colNombreEspecialidad
			// 
			this.colNombreEspecialidad.FillWeight = 137.0558F;
			this.colNombreEspecialidad.HeaderText = "Especialidad";
			this.colNombreEspecialidad.Name = "colNombreEspecialidad";
			this.colNombreEspecialidad.ReadOnly = true;
			// 
			// colCodigoSesionAprob
			// 
			dataGridViewCellStyle6.Format = "d";
			dataGridViewCellStyle6.NullValue = null;
			this.colCodigoSesionAprob.DefaultCellStyle = dataGridViewCellStyle6;
			this.colCodigoSesionAprob.HeaderText = "Sesión Aprobación";
			this.colCodigoSesionAprob.Name = "colCodigoSesionAprob";
			// 
			// colFechaEspecialidad
			// 
			dataGridViewCellStyle7.Format = "d";
			dataGridViewCellStyle7.NullValue = null;
			this.colFechaEspecialidad.DefaultCellStyle = dataGridViewCellStyle7;
			this.colFechaEspecialidad.HeaderText = "Fecha";
			this.colFechaEspecialidad.Name = "colFechaEspecialidad";
			// 
			// txtEspecialidadN
			// 
			this.txtEspecialidadN.FormatearNumero = false;
			this.txtEspecialidadN.Location = new System.Drawing.Point(206, 61);
			this.txtEspecialidadN.Longitud = 32767;
			this.txtEspecialidadN.Multilinea = false;
			this.txtEspecialidadN.Name = "txtEspecialidadN";
			this.txtEspecialidadN.Password = '\0';
			this.txtEspecialidadN.ReadOnly = true;
			this.txtEspecialidadN.Size = new System.Drawing.Size(285, 21);
			this.txtEspecialidadN.TabIndex = 285;
			this.txtEspecialidadN.Valor = "";
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Location = new System.Drawing.Point(72, 65);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(70, 13);
			this.label58.TabIndex = 284;
			this.label58.Text = "Especialidad:";
			// 
			// txtEspecialidad
			// 
			this.txtEspecialidad.FormatearNumero = false;
			this.txtEspecialidad.Location = new System.Drawing.Point(148, 61);
			this.txtEspecialidad.Longitud = 30;
			this.txtEspecialidad.Multilinea = false;
			this.txtEspecialidad.Name = "txtEspecialidad";
			this.txtEspecialidad.Password = '\0';
			this.txtEspecialidad.ReadOnly = false;
			this.txtEspecialidad.Size = new System.Drawing.Size(59, 21);
			this.txtEspecialidad.TabIndex = 283;
			this.txtEspecialidad.Valor = "";
			this.txtEspecialidad.Enter += new System.EventHandler(this.txtEspecialidad_Enter);
			this.txtEspecialidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEspecialidad_KeyDown);
			this.txtEspecialidad.Leave += new System.EventHandler(this.txtEspecialidad_Leave);
			this.txtEspecialidad.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtEspecialidad_MouseDoubleClick);
			// 
			// panel11
			// 
			this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel11.BackColor = System.Drawing.Color.DarkGray;
			this.panel11.Controls.Add(this.label56);
			this.panel11.Location = new System.Drawing.Point(266, 278);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(0, 25);
			this.panel11.TabIndex = 268;
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label56.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label56.Location = new System.Drawing.Point(3, 4);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(209, 14);
			this.label56.TabIndex = 0;
			this.label56.Text = "Historial de Campos de Especialidad";
			// 
			// grbSesionEspecialidad
			// 
			this.grbSesionEspecialidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grbSesionEspecialidad.Controls.Add(this.dtpFechaSesionAprob);
			this.grbSesionEspecialidad.Controls.Add(this.label25);
			this.grbSesionEspecialidad.Controls.Add(this.label26);
			this.grbSesionEspecialidad.Controls.Add(this.txtSesionAprob);
			this.grbSesionEspecialidad.Location = new System.Drawing.Point(-17904, 30);
			this.grbSesionEspecialidad.Name = "grbSesionEspecialidad";
			this.grbSesionEspecialidad.Size = new System.Drawing.Size(406, 64);
			this.grbSesionEspecialidad.TabIndex = 267;
			this.grbSesionEspecialidad.TabStop = false;
			this.grbSesionEspecialidad.Text = "Sesión Aprobación Junta";
			// 
			// dtpFechaSesionAprob
			// 
			this.dtpFechaSesionAprob.Checked = true;
			this.dtpFechaSesionAprob.Location = new System.Drawing.Point(285, 19);
			this.dtpFechaSesionAprob.mostrarCheckBox = false;
			this.dtpFechaSesionAprob.mostrarUpDown = false;
			this.dtpFechaSesionAprob.Name = "dtpFechaSesionAprob";
			this.dtpFechaSesionAprob.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaSesionAprob.TabIndex = 264;
			this.dtpFechaSesionAprob.Value = new System.DateTime(2018, 11, 30, 9, 47, 52, 584);
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(239, 24);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(40, 13);
			this.label25.TabIndex = 259;
			this.label25.Text = "Fecha:";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(6, 24);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(71, 13);
			this.label26.TabIndex = 16;
			this.label26.Text = "Sesión Junta:";
			// 
			// txtSesionAprob
			// 
			this.txtSesionAprob.FormatearNumero = false;
			this.txtSesionAprob.Location = new System.Drawing.Point(83, 19);
			this.txtSesionAprob.Longitud = 32767;
			this.txtSesionAprob.Multilinea = false;
			this.txtSesionAprob.Name = "txtSesionAprob";
			this.txtSesionAprob.Password = '\0';
			this.txtSesionAprob.ReadOnly = false;
			this.txtSesionAprob.Size = new System.Drawing.Size(137, 21);
			this.txtSesionAprob.TabIndex = 17;
			this.txtSesionAprob.Valor = "";
			// 
			// panel3
			// 
			this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel3.BackColor = System.Drawing.Color.DarkGray;
			this.panel3.Controls.Add(this.label29);
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(0, 21);
			this.panel3.TabIndex = 38;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label29.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label29.Location = new System.Drawing.Point(6, 3);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(158, 14);
			this.label29.TabIndex = 0;
			this.label29.Text = "Historial de Especialidades";
			// 
			// tpHistorial
			// 
			this.tpHistorial.Controls.Add(this.grbHistorialSesiones);
			this.tpHistorial.Controls.Add(this.panel9);
			this.tpHistorial.Location = new System.Drawing.Point(4, 22);
			this.tpHistorial.Name = "tpHistorial";
			this.tpHistorial.Size = new System.Drawing.Size(997, 566);
			this.tpHistorial.TabIndex = 8;
			this.tpHistorial.Text = "Historial";
			this.tpHistorial.UseVisualStyleBackColor = true;
			// 
			// grbHistorialSesiones
			// 
			this.grbHistorialSesiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grbHistorialSesiones.Controls.Add(this.dgvHistorialSesiones);
			this.grbHistorialSesiones.Location = new System.Drawing.Point(6, 30);
			this.grbHistorialSesiones.Name = "grbHistorialSesiones";
			this.grbHistorialSesiones.Size = new System.Drawing.Size(0, 0);
			this.grbHistorialSesiones.TabIndex = 45;
			this.grbHistorialSesiones.TabStop = false;
			// 
			// dgvHistorialSesiones
			// 
			this.dgvHistorialSesiones.AllowUserToAddRows = false;
			this.dgvHistorialSesiones.AllowUserToDeleteRows = false;
			this.dgvHistorialSesiones.AllowUserToResizeRows = false;
			this.dgvHistorialSesiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvHistorialSesiones.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvHistorialSesiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHistorialSesiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoSesion,
            this.colFechaSesion,
            this.colCondicionPrevia,
            this.colCondicionNueva});
			this.dgvHistorialSesiones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvHistorialSesiones.Location = new System.Drawing.Point(3, 16);
			this.dgvHistorialSesiones.MultiSelect = false;
			this.dgvHistorialSesiones.Name = "dgvHistorialSesiones";
			this.dgvHistorialSesiones.RowHeadersVisible = false;
			this.dgvHistorialSesiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvHistorialSesiones.Size = new System.Drawing.Size(0, 0);
			this.dgvHistorialSesiones.TabIndex = 287;
			// 
			// colCodigoSesion
			// 
			this.colCodigoSesion.HeaderText = "Código Sesión";
			this.colCodigoSesion.Name = "colCodigoSesion";
			// 
			// colFechaSesion
			// 
			this.colFechaSesion.HeaderText = "Fecha";
			this.colFechaSesion.Name = "colFechaSesion";
			// 
			// colCondicionPrevia
			// 
			this.colCondicionPrevia.FillWeight = 137.0558F;
			this.colCondicionPrevia.HeaderText = "Condición Previa";
			this.colCondicionPrevia.Name = "colCondicionPrevia";
			this.colCondicionPrevia.ReadOnly = true;
			// 
			// colCondicionNueva
			// 
			this.colCondicionNueva.HeaderText = "Condición Nueva";
			this.colCondicionNueva.Name = "colCondicionNueva";
			this.colCondicionNueva.ReadOnly = true;
			// 
			// panel9
			// 
			this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel9.BackColor = System.Drawing.Color.DarkGray;
			this.panel9.Controls.Add(this.label34);
			this.panel9.Location = new System.Drawing.Point(3, 3);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(0, 21);
			this.panel9.TabIndex = 44;
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label34.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label34.Location = new System.Drawing.Point(3, 4);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(155, 14);
			this.label34.TabIndex = 0;
			this.label34.Text = "Historial Sesiones de Junta";
			// 
			// tpAlertas
			// 
			this.tpAlertas.Controls.Add(this.panel6);
			this.tpAlertas.Controls.Add(this.groupBox8);
			this.tpAlertas.Location = new System.Drawing.Point(4, 22);
			this.tpAlertas.Name = "tpAlertas";
			this.tpAlertas.Size = new System.Drawing.Size(997, 566);
			this.tpAlertas.TabIndex = 9;
			this.tpAlertas.Text = "Alertas";
			this.tpAlertas.UseVisualStyleBackColor = true;
			// 
			// panel6
			// 
			this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel6.BackColor = System.Drawing.Color.DarkGray;
			this.panel6.Controls.Add(this.label31);
			this.panel6.Location = new System.Drawing.Point(2, 3);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(0, 21);
			this.panel6.TabIndex = 42;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label31.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label31.Location = new System.Drawing.Point(3, 4);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(47, 14);
			this.label31.TabIndex = 0;
			this.label31.Text = "Alertas";
			// 
			// groupBox8
			// 
			this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox8.Controls.Add(this.dataGridView6);
			this.groupBox8.Location = new System.Drawing.Point(2, 30);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(0, 0);
			this.groupBox8.TabIndex = 41;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Alertas para este expediente";
			// 
			// dataGridView6
			// 
			this.dataGridView6.AllowUserToAddRows = false;
			this.dataGridView6.AllowUserToDeleteRows = false;
			this.dataGridView6.AllowUserToResizeRows = false;
			this.dataGridView6.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView6.Location = new System.Drawing.Point(3, 16);
			this.dataGridView6.Name = "dataGridView6";
			this.dataGridView6.ReadOnly = true;
			this.dataGridView6.RowHeadersVisible = false;
			this.dataGridView6.Size = new System.Drawing.Size(0, 0);
			this.dataGridView6.TabIndex = 246;
			// 
			// tpGestionCobro
			// 
			this.tpGestionCobro.Controls.Add(this.grbAdelantos);
			this.tpGestionCobro.Controls.Add(this.grbPendientes);
			this.tpGestionCobro.Controls.Add(this.panelGestionCobro);
			this.tpGestionCobro.Controls.Add(this.panel7);
			this.tpGestionCobro.Location = new System.Drawing.Point(4, 22);
			this.tpGestionCobro.Name = "tpGestionCobro";
			this.tpGestionCobro.Size = new System.Drawing.Size(997, 566);
			this.tpGestionCobro.TabIndex = 10;
			this.tpGestionCobro.Text = "Gestión Cobro";
			this.tpGestionCobro.UseVisualStyleBackColor = true;
			// 
			// grbAdelantos
			// 
			this.grbAdelantos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grbAdelantos.Controls.Add(this.dgvGestionCobroAdel);
			this.grbAdelantos.Location = new System.Drawing.Point(12, -5550);
			this.grbAdelantos.Name = "grbAdelantos";
			this.grbAdelantos.Size = new System.Drawing.Size(0, 155);
			this.grbAdelantos.TabIndex = 47;
			this.grbAdelantos.TabStop = false;
			this.grbAdelantos.Text = "Adelantos";
			// 
			// dgvGestionCobroAdel
			// 
			this.dgvGestionCobroAdel.AllowUserToAddRows = false;
			this.dgvGestionCobroAdel.AllowUserToDeleteRows = false;
			this.dgvGestionCobroAdel.AllowUserToResizeRows = false;
			this.dgvGestionCobroAdel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGestionCobroAdel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGestionCobroAdel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
			this.dgvGestionCobroAdel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvGestionCobroAdel.Location = new System.Drawing.Point(3, 16);
			this.dgvGestionCobroAdel.Name = "dgvGestionCobroAdel";
			this.dgvGestionCobroAdel.ReadOnly = true;
			this.dgvGestionCobroAdel.RowHeadersVisible = false;
			this.dgvGestionCobroAdel.Size = new System.Drawing.Size(0, 136);
			this.dgvGestionCobroAdel.TabIndex = 247;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Tipo";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.HeaderText = "Establecimiento";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.HeaderText = "Categoria";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			// 
			// grbPendientes
			// 
			this.grbPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grbPendientes.Controls.Add(this.dgvGestionCobro);
			this.grbPendientes.Location = new System.Drawing.Point(12, -5389);
			this.grbPendientes.Name = "grbPendientes";
			this.grbPendientes.Size = new System.Drawing.Size(0, 178);
			this.grbPendientes.TabIndex = 46;
			this.grbPendientes.TabStop = false;
			this.grbPendientes.Text = "Facturas Pendientes";
			// 
			// dgvGestionCobro
			// 
			this.dgvGestionCobro.AllowUserToAddRows = false;
			this.dgvGestionCobro.AllowUserToDeleteRows = false;
			this.dgvGestionCobro.AllowUserToResizeRows = false;
			this.dgvGestionCobro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGestionCobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGestionCobro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDocumento,
            this.colAplicacion,
            this.colFechaDocumento,
            this.colMonto,
            this.colSaldo});
			this.dgvGestionCobro.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvGestionCobro.Location = new System.Drawing.Point(3, 16);
			this.dgvGestionCobro.Name = "dgvGestionCobro";
			this.dgvGestionCobro.ReadOnly = true;
			this.dgvGestionCobro.RowHeadersVisible = false;
			this.dgvGestionCobro.Size = new System.Drawing.Size(0, 159);
			this.dgvGestionCobro.TabIndex = 247;
			// 
			// colDocumento
			// 
			this.colDocumento.HeaderText = "Documento";
			this.colDocumento.Name = "colDocumento";
			this.colDocumento.ReadOnly = true;
			// 
			// colAplicacion
			// 
			this.colAplicacion.HeaderText = "Aplicacion";
			this.colAplicacion.Name = "colAplicacion";
			this.colAplicacion.ReadOnly = true;
			// 
			// colFechaDocumento
			// 
			this.colFechaDocumento.HeaderText = "Fecha";
			this.colFechaDocumento.Name = "colFechaDocumento";
			this.colFechaDocumento.ReadOnly = true;
			// 
			// colMonto
			// 
			this.colMonto.HeaderText = "Monto";
			this.colMonto.Name = "colMonto";
			this.colMonto.ReadOnly = true;
			// 
			// colSaldo
			// 
			this.colSaldo.HeaderText = "Saldo";
			this.colSaldo.Name = "colSaldo";
			this.colSaldo.ReadOnly = true;
			// 
			// panelGestionCobro
			// 
			this.panelGestionCobro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelGestionCobro.Controls.Add(this.toolStrip9);
			this.panelGestionCobro.Controls.Add(this.dgvGestionCobro2);
			this.panelGestionCobro.Location = new System.Drawing.Point(12, 30);
			this.panelGestionCobro.Name = "panelGestionCobro";
			this.panelGestionCobro.Size = new System.Drawing.Size(0, 185);
			this.panelGestionCobro.TabIndex = 45;
			// 
			// toolStrip9
			// 
			this.toolStrip9.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevaGestion,
            this.btnEliminarGestion});
			this.toolStrip9.Location = new System.Drawing.Point(0, 0);
			this.toolStrip9.Name = "toolStrip9";
			this.toolStrip9.Size = new System.Drawing.Size(0, 25);
			this.toolStrip9.TabIndex = 253;
			this.toolStrip9.Text = "toolStrip9";
			// 
			// btnNuevaGestion
			// 
			this.btnNuevaGestion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevaGestion.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaGestion.Image")));
			this.btnNuevaGestion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevaGestion.Name = "btnNuevaGestion";
			this.btnNuevaGestion.Size = new System.Drawing.Size(23, 20);
			this.btnNuevaGestion.Text = "Agregar Gestión de Cobro";
			this.btnNuevaGestion.Click += new System.EventHandler(this.btnNuevaGestion_Click);
			// 
			// btnEliminarGestion
			// 
			this.btnEliminarGestion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarGestion.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarGestion.Image")));
			this.btnEliminarGestion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarGestion.Name = "btnEliminarGestion";
			this.btnEliminarGestion.Size = new System.Drawing.Size(23, 20);
			this.btnEliminarGestion.Text = "Quitar Gestión de Cobro";
			this.btnEliminarGestion.Click += new System.EventHandler(this.btnEliminarGestion_Click);
			// 
			// dgvGestionCobro2
			// 
			this.dgvGestionCobro2.AllowUserToAddRows = false;
			this.dgvGestionCobro2.AllowUserToDeleteRows = false;
			this.dgvGestionCobro2.AllowUserToResizeRows = false;
			this.dgvGestionCobro2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvGestionCobro2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGestionCobro2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGestionCobro2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colMedio,
            this.colFecha,
            this.colCompromiso,
            this.colFechaCompromiso,
            this.colObservacion,
            this.ColEstado});
			this.dgvGestionCobro2.Location = new System.Drawing.Point(3, 28);
			this.dgvGestionCobro2.Name = "dgvGestionCobro2";
			this.dgvGestionCobro2.RowHeadersVisible = false;
			this.dgvGestionCobro2.Size = new System.Drawing.Size(0, 154);
			this.dgvGestionCobro2.TabIndex = 250;
			this.dgvGestionCobro2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGestionCobro2_CellClick);
			this.dgvGestionCobro2.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvGestionCobro2_CurrentCellDirtyStateChanged);
			// 
			// colId
			// 
			this.colId.HeaderText = "Id";
			this.colId.Name = "colId";
			this.colId.Visible = false;
			// 
			// colMedio
			// 
			this.colMedio.HeaderText = "Medio";
			this.colMedio.Items.AddRange(new object[] {
            "LLAMADA",
            "CORREO"});
			this.colMedio.Name = "colMedio";
			this.colMedio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colMedio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colFecha
			// 
			this.colFecha.HeaderText = "Fecha";
			this.colFecha.Name = "colFecha";
			this.colFecha.ReadOnly = true;
			// 
			// colCompromiso
			// 
			this.colCompromiso.HeaderText = "Compromiso";
			this.colCompromiso.Name = "colCompromiso";
			// 
			// colFechaCompromiso
			// 
			this.colFechaCompromiso.HeaderText = "Fecha Compromiso";
			this.colFechaCompromiso.Name = "colFechaCompromiso";
			// 
			// colObservacion
			// 
			this.colObservacion.HeaderText = "Observaciones";
			this.colObservacion.Name = "colObservacion";
			// 
			// ColEstado
			// 
			this.ColEstado.HeaderText = "Estado";
			this.ColEstado.Items.AddRange(new object[] {
            "Abierto",
            "Cerrado"});
			this.ColEstado.Name = "ColEstado";
			// 
			// panel7
			// 
			this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel7.BackColor = System.Drawing.Color.DarkGray;
			this.panel7.Controls.Add(this.label32);
			this.panel7.Location = new System.Drawing.Point(3, 3);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(0, 21);
			this.panel7.TabIndex = 43;
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label32.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label32.Location = new System.Drawing.Point(3, 4);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(102, 14);
			this.label32.TabIndex = 0;
			this.label32.Text = "Gestión de Cobro";
			// 
			// tpRevista
			// 
			this.tpRevista.Controls.Add(this.groupBox15);
			this.tpRevista.Controls.Add(this.label42);
			this.tpRevista.Controls.Add(this.cmbTrabajoRevista);
			this.tpRevista.Controls.Add(this.label41);
			this.tpRevista.Controls.Add(this.cmbRutaRevista);
			this.tpRevista.Controls.Add(this.label39);
			this.tpRevista.Controls.Add(this.cmbTipoEntrega);
			this.tpRevista.Controls.Add(this.panel8);
			this.tpRevista.Location = new System.Drawing.Point(4, 22);
			this.tpRevista.Name = "tpRevista";
			this.tpRevista.Size = new System.Drawing.Size(997, 566);
			this.tpRevista.TabIndex = 11;
			this.tpRevista.Text = "Revista";
			this.tpRevista.UseVisualStyleBackColor = true;
			// 
			// groupBox15
			// 
			this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox15.Location = new System.Drawing.Point(12, 106);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(0, 0);
			this.groupBox15.TabIndex = 51;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Dirección de Habitación";
			// 
			// label42
			// 
			this.label42.AutoSize = true;
			this.label42.Location = new System.Drawing.Point(533, 67);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(46, 13);
			this.label42.TabIndex = 50;
			this.label42.Text = "Trabajo:";
			// 
			// cmbTrabajoRevista
			// 
			this.cmbTrabajoRevista.Habilitar = true;
			this.cmbTrabajoRevista.Index = -1;
			this.cmbTrabajoRevista.Location = new System.Drawing.Point(585, 64);
			this.cmbTrabajoRevista.Name = "cmbTrabajoRevista";
			this.cmbTrabajoRevista.Size = new System.Drawing.Size(123, 22);
			this.cmbTrabajoRevista.TabIndex = 49;
			this.cmbTrabajoRevista.Texto = "";
			this.cmbTrabajoRevista.Valor = "";
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(309, 67);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(33, 13);
			this.label41.TabIndex = 48;
			this.label41.Text = "Ruta:";
			// 
			// cmbRutaRevista
			// 
			this.cmbRutaRevista.Habilitar = true;
			this.cmbRutaRevista.Index = -1;
			this.cmbRutaRevista.Location = new System.Drawing.Point(348, 64);
			this.cmbRutaRevista.Name = "cmbRutaRevista";
			this.cmbRutaRevista.Size = new System.Drawing.Size(123, 22);
			this.cmbRutaRevista.TabIndex = 47;
			this.cmbRutaRevista.Texto = "";
			this.cmbRutaRevista.Valor = "";
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(40, 67);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(86, 13);
			this.label39.TabIndex = 46;
			this.label39.Text = "Tipo de Entrega:";
			// 
			// cmbTipoEntrega
			// 
			this.cmbTipoEntrega.Habilitar = true;
			this.cmbTipoEntrega.Index = -1;
			this.cmbTipoEntrega.Location = new System.Drawing.Point(132, 64);
			this.cmbTipoEntrega.Name = "cmbTipoEntrega";
			this.cmbTipoEntrega.Size = new System.Drawing.Size(123, 22);
			this.cmbTipoEntrega.TabIndex = 45;
			this.cmbTipoEntrega.Texto = "";
			this.cmbTipoEntrega.Valor = "";
			// 
			// panel8
			// 
			this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel8.BackColor = System.Drawing.Color.DarkGray;
			this.panel8.Controls.Add(this.label33);
			this.panel8.Location = new System.Drawing.Point(3, 3);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(0, 21);
			this.panel8.TabIndex = 44;
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label33.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label33.Location = new System.Drawing.Point(3, 4);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(47, 14);
			this.label33.TabIndex = 0;
			this.label33.Text = "Revista";
			// 
			// lblNumColegiado
			// 
			this.lblNumColegiado.AutoSize = true;
			this.lblNumColegiado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNumColegiado.Location = new System.Drawing.Point(74, 28);
			this.lblNumColegiado.Name = "lblNumColegiado";
			this.lblNumColegiado.Size = new System.Drawing.Size(85, 13);
			this.lblNumColegiado.TabIndex = 4;
			this.lblNumColegiado.Text = "Nº Colegiado:";
			// 
			// txtNombre
			// 
			this.txtNombre.FormatearNumero = false;
			this.txtNombre.Location = new System.Drawing.Point(165, 51);
			this.txtNombre.Longitud = 100;
			this.txtNombre.Multilinea = false;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Password = '\0';
			this.txtNombre.ReadOnly = false;
			this.txtNombre.Size = new System.Drawing.Size(377, 21);
			this.txtNombre.TabIndex = 3;
			this.txtNombre.Valor = "";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(105, 55);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Nombre:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(96, 83);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 13);
			this.label10.TabIndex = 10;
			this.label10.Text = "Fecha Nac:";
			// 
			// cmbSexo
			// 
			this.cmbSexo.Habilitar = true;
			this.cmbSexo.Index = -1;
			this.cmbSexo.Location = new System.Drawing.Point(419, 78);
			this.cmbSexo.Name = "cmbSexo";
			this.cmbSexo.Size = new System.Drawing.Size(123, 22);
			this.cmbSexo.TabIndex = 5;
			this.cmbSexo.Texto = "";
			this.cmbSexo.Valor = "";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(368, 83);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(45, 13);
			this.label11.TabIndex = 13;
			this.label11.Text = "Genero:";
			// 
			// txtTelefono1
			// 
			this.txtTelefono1.FormatearNumero = false;
			this.txtTelefono1.Location = new System.Drawing.Point(165, 186);
			this.txtTelefono1.Longitud = 70;
			this.txtTelefono1.Multilinea = false;
			this.txtTelefono1.Name = "txtTelefono1";
			this.txtTelefono1.Password = '\0';
			this.txtTelefono1.ReadOnly = false;
			this.txtTelefono1.Size = new System.Drawing.Size(137, 21);
			this.txtTelefono1.TabIndex = 9;
			this.txtTelefono1.Valor = "";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(72, 190);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(87, 13);
			this.label15.TabIndex = 21;
			this.label15.Text = "Teléfono Celular:";
			// 
			// txtTelefono2
			// 
			this.txtTelefono2.FormatearNumero = false;
			this.txtTelefono2.Location = new System.Drawing.Point(165, 213);
			this.txtTelefono2.Longitud = 70;
			this.txtTelefono2.Multilinea = false;
			this.txtTelefono2.Name = "txtTelefono2";
			this.txtTelefono2.Password = '\0';
			this.txtTelefono2.ReadOnly = false;
			this.txtTelefono2.Size = new System.Drawing.Size(137, 21);
			this.txtTelefono2.TabIndex = 10;
			this.txtTelefono2.Valor = "";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(53, 218);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(106, 13);
			this.label18.TabIndex = 27;
			this.label18.Text = "Teléfono Habitacion:";
			// 
			// txtEmail1
			// 
			this.txtEmail1.FormatearNumero = false;
			this.txtEmail1.Location = new System.Drawing.Point(165, 132);
			this.txtEmail1.Longitud = 170;
			this.txtEmail1.Multilinea = false;
			this.txtEmail1.Name = "txtEmail1";
			this.txtEmail1.Password = '\0';
			this.txtEmail1.ReadOnly = false;
			this.txtEmail1.Size = new System.Drawing.Size(270, 21);
			this.txtEmail1.TabIndex = 7;
			this.txtEmail1.Valor = "";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(124, 136);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(35, 13);
			this.label19.TabIndex = 29;
			this.label19.Text = "Email:";
			// 
			// txtEmail2
			// 
			this.txtEmail2.FormatearNumero = false;
			this.txtEmail2.Location = new System.Drawing.Point(165, 159);
			this.txtEmail2.Longitud = 170;
			this.txtEmail2.Multilinea = false;
			this.txtEmail2.Name = "txtEmail2";
			this.txtEmail2.Password = '\0';
			this.txtEmail2.ReadOnly = false;
			this.txtEmail2.Size = new System.Drawing.Size(270, 21);
			this.txtEmail2.TabIndex = 8;
			this.txtEmail2.Valor = "";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(78, 164);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(81, 13);
			this.label20.TabIndex = 31;
			this.label20.Text = "Email Adicional:";
			// 
			// txtDistritoNombreF
			// 
			this.txtDistritoNombreF.FormatearNumero = false;
			this.txtDistritoNombreF.Location = new System.Drawing.Point(746, 417);
			this.txtDistritoNombreF.Longitud = 32767;
			this.txtDistritoNombreF.Multilinea = false;
			this.txtDistritoNombreF.Name = "txtDistritoNombreF";
			this.txtDistritoNombreF.Password = '\0';
			this.txtDistritoNombreF.ReadOnly = true;
			this.txtDistritoNombreF.Size = new System.Drawing.Size(179, 21);
			this.txtDistritoNombreF.TabIndex = 76;
			this.txtDistritoNombreF.Valor = "";
			// 
			// txtDistrito
			// 
			this.txtDistrito.FormatearNumero = false;
			this.txtDistrito.Location = new System.Drawing.Point(688, 417);
			this.txtDistrito.Longitud = 2;
			this.txtDistrito.Multilinea = false;
			this.txtDistrito.Name = "txtDistrito";
			this.txtDistrito.Password = '\0';
			this.txtDistrito.ReadOnly = false;
			this.txtDistrito.Size = new System.Drawing.Size(59, 21);
			this.txtDistrito.TabIndex = 20;
			this.txtDistrito.Valor = "";
			this.txtDistrito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDistrito_KeyDown);
			this.txtDistrito.Leave += new System.EventHandler(this.txtDistrito_Leave);
			this.txtDistrito.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtDistrito_MouseDoubleClick);
			// 
			// txtCanton
			// 
			this.txtCanton.FormatearNumero = false;
			this.txtCanton.Location = new System.Drawing.Point(688, 385);
			this.txtCanton.Longitud = 2;
			this.txtCanton.Multilinea = false;
			this.txtCanton.Name = "txtCanton";
			this.txtCanton.Password = '\0';
			this.txtCanton.ReadOnly = false;
			this.txtCanton.Size = new System.Drawing.Size(59, 21);
			this.txtCanton.TabIndex = 19;
			this.txtCanton.Valor = "";
			this.txtCanton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCanton_KeyDown);
			this.txtCanton.Leave += new System.EventHandler(this.txtCanton_Leave);
			this.txtCanton.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCanton_MouseDoubleClick);
			// 
			// txtProvincia
			// 
			this.txtProvincia.FormatearNumero = false;
			this.txtProvincia.Location = new System.Drawing.Point(688, 351);
			this.txtProvincia.Longitud = 2;
			this.txtProvincia.Multilinea = false;
			this.txtProvincia.Name = "txtProvincia";
			this.txtProvincia.Password = '\0';
			this.txtProvincia.ReadOnly = false;
			this.txtProvincia.Size = new System.Drawing.Size(59, 21);
			this.txtProvincia.TabIndex = 18;
			this.txtProvincia.Valor = "";
			this.txtProvincia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProvincia_KeyDown);
			this.txtProvincia.Leave += new System.EventHandler(this.txtProvincia_Leave);
			this.txtProvincia.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtProvincia_MouseDoubleClick);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(104, 351);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(55, 13);
			this.label21.TabIndex = 70;
			this.label21.Text = "Dirección:";
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(640, 421);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(42, 13);
			this.label45.TabIndex = 80;
			this.label45.Text = "Distrito:";
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(638, 390);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(44, 13);
			this.label44.TabIndex = 79;
			this.label44.Text = "Cantón:";
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(628, 356);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(54, 13);
			this.label43.TabIndex = 78;
			this.label43.Text = "Provincia:";
			// 
			// txtApartado
			// 
			this.txtApartado.FormatearNumero = false;
			this.txtApartado.Location = new System.Drawing.Point(165, 105);
			this.txtApartado.Longitud = 100;
			this.txtApartado.Multilinea = false;
			this.txtApartado.Name = "txtApartado";
			this.txtApartado.Password = '\0';
			this.txtApartado.ReadOnly = false;
			this.txtApartado.Size = new System.Drawing.Size(377, 21);
			this.txtApartado.TabIndex = 6;
			this.txtApartado.Valor = "";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(106, 110);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(53, 13);
			this.label24.TabIndex = 242;
			this.label24.Text = "Apartado:";
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(101, 298);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(57, 13);
			this.label27.TabIndex = 245;
			this.label27.Text = "Condición:";
			// 
			// tpRegencias
			// 
			this.tpRegencias.Controls.Add(this.gbVidaSilvestreR);
			this.tpRegencias.Controls.Add(this.grbEstableRegencias);
			this.tpRegencias.Controls.Add(this.dtpVencimiento);
			this.tpRegencias.Controls.Add(this.lblVencimiento);
			this.tpRegencias.Controls.Add(this.txtMonto);
			this.tpRegencias.Controls.Add(this.lblMonto);
			this.tpRegencias.Controls.Add(this.dtpFecha);
			this.tpRegencias.Controls.Add(this.LblFecha);
			this.tpRegencias.Controls.Add(this.txtNPoliza);
			this.tpRegencias.Controls.Add(this.lblNPoliza);
			this.tpRegencias.Controls.Add(this.label57);
			this.tpRegencias.Controls.Add(this.cmbTipoRegente);
			this.tpRegencias.Controls.Add(this.chkCurso);
			this.tpRegencias.Controls.Add(this.dtpPerdida);
			this.tpRegencias.Controls.Add(this.label46);
			this.tpRegencias.Controls.Add(this.txtSesionPerdida);
			this.tpRegencias.Controls.Add(this.label47);
			this.tpRegencias.Controls.Add(this.dtpAprobacion);
			this.tpRegencias.Controls.Add(this.label48);
			this.tpRegencias.Controls.Add(this.txtSesionAprobacion);
			this.tpRegencias.Controls.Add(this.label67);
			this.tpRegencias.Controls.Add(this.txtCobradorRegente);
			this.tpRegencias.Controls.Add(this.label68);
			this.tpRegencias.Controls.Add(this.txtCobradorNombre);
			this.tpRegencias.Controls.Add(this.panel10);
			this.tpRegencias.Location = new System.Drawing.Point(4, 22);
			this.tpRegencias.Name = "tpRegencias";
			this.tpRegencias.Size = new System.Drawing.Size(997, 566);
			this.tpRegencias.TabIndex = 12;
			this.tpRegencias.Text = "Regencias";
			this.tpRegencias.UseVisualStyleBackColor = true;
			// 
			// gbVidaSilvestreR
			// 
			this.gbVidaSilvestreR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbVidaSilvestreR.Controls.Add(this.toolStrip16);
			this.gbVidaSilvestreR.Controls.Add(this.dgvVidaSilvestreR);
			this.gbVidaSilvestreR.Location = new System.Drawing.Point(657, 105);
			this.gbVidaSilvestreR.Name = "gbVidaSilvestreR";
			this.gbVidaSilvestreR.Size = new System.Drawing.Size(0, 0);
			this.gbVidaSilvestreR.TabIndex = 313;
			this.gbVidaSilvestreR.TabStop = false;
			this.gbVidaSilvestreR.Text = "Agregar Vida Silvestre";
			// 
			// toolStrip16
			// 
			this.toolStrip16.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip16.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarSilvestre,
            this.btnEliminaSilvestre});
			this.toolStrip16.Location = new System.Drawing.Point(3, 15);
			this.toolStrip16.Name = "toolStrip16";
			this.toolStrip16.Size = new System.Drawing.Size(58, 25);
			this.toolStrip16.TabIndex = 306;
			this.toolStrip16.Text = "toolStrip16";
			// 
			// btnAgregarSilvestre
			// 
			this.btnAgregarSilvestre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAgregarSilvestre.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarSilvestre.Image")));
			this.btnAgregarSilvestre.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAgregarSilvestre.Name = "btnAgregarSilvestre";
			this.btnAgregarSilvestre.Size = new System.Drawing.Size(23, 22);
			this.btnAgregarSilvestre.Text = "Nuevo";
			this.btnAgregarSilvestre.Click += new System.EventHandler(this.btnAgregarSilvestre_Click);
			// 
			// btnEliminaSilvestre
			// 
			this.btnEliminaSilvestre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminaSilvestre.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaSilvestre.Image")));
			this.btnEliminaSilvestre.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminaSilvestre.Name = "btnEliminaSilvestre";
			this.btnEliminaSilvestre.Size = new System.Drawing.Size(23, 22);
			this.btnEliminaSilvestre.Text = "Eliminar";
			this.btnEliminaSilvestre.Click += new System.EventHandler(this.btnEliminaSilvestre_Click);
			// 
			// dgvVidaSilvestreR
			// 
			this.dgvVidaSilvestreR.AllowUserToAddRows = false;
			this.dgvVidaSilvestreR.AllowUserToDeleteRows = false;
			this.dgvVidaSilvestreR.AllowUserToResizeRows = false;
			this.dgvVidaSilvestreR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvVidaSilvestreR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvVidaSilvestreR.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvVidaSilvestreR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvVidaSilvestreR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoSilvestreR,
            this.colNombreSilvestreR,
            this.colDescripcionSilvestreR});
			this.dgvVidaSilvestreR.Location = new System.Drawing.Point(3, 43);
			this.dgvVidaSilvestreR.MultiSelect = false;
			this.dgvVidaSilvestreR.Name = "dgvVidaSilvestreR";
			this.dgvVidaSilvestreR.RowHeadersVisible = false;
			this.dgvVidaSilvestreR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvVidaSilvestreR.Size = new System.Drawing.Size(0, 0);
			this.dgvVidaSilvestreR.TabIndex = 310;
			this.dgvVidaSilvestreR.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvVidaSilvestreR_MouseDoubleClick);
			// 
			// colCodigoSilvestreR
			// 
			this.colCodigoSilvestreR.HeaderText = "Código";
			this.colCodigoSilvestreR.Name = "colCodigoSilvestreR";
			this.colCodigoSilvestreR.ReadOnly = true;
			// 
			// colNombreSilvestreR
			// 
			this.colNombreSilvestreR.HeaderText = "Nombre";
			this.colNombreSilvestreR.Name = "colNombreSilvestreR";
			// 
			// colDescripcionSilvestreR
			// 
			this.colDescripcionSilvestreR.HeaderText = "Descripción";
			this.colDescripcionSilvestreR.Name = "colDescripcionSilvestreR";
			this.colDescripcionSilvestreR.ReadOnly = true;
			// 
			// grbEstableRegencias
			// 
			this.grbEstableRegencias.Controls.Add(this.panel14);
			this.grbEstableRegencias.Controls.Add(this.dgvEstablecimientos);
			this.grbEstableRegencias.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grbEstableRegencias.Location = new System.Drawing.Point(0, 284);
			this.grbEstableRegencias.Name = "grbEstableRegencias";
			this.grbEstableRegencias.Size = new System.Drawing.Size(997, 282);
			this.grbEstableRegencias.TabIndex = 139;
			this.grbEstableRegencias.TabStop = false;
			this.grbEstableRegencias.Text = "Establecimientos";
			// 
			// panel14
			// 
			this.panel14.AutoScroll = true;
			this.panel14.Controls.Add(this.toolStrip6);
			this.panel14.Location = new System.Drawing.Point(6, 14);
			this.panel14.Name = "panel14";
			this.panel14.Size = new System.Drawing.Size(135, 28);
			this.panel14.TabIndex = 44;
			// 
			// toolStrip6
			// 
			this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoEst,
            this.btnEliminaEst});
			this.toolStrip6.Location = new System.Drawing.Point(0, 0);
			this.toolStrip6.Name = "toolStrip6";
			this.toolStrip6.Size = new System.Drawing.Size(135, 25);
			this.toolStrip6.TabIndex = 0;
			this.toolStrip6.Text = "toolStrip6";
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
            this.colCodigoCategoria,
            this.colCategoria,
            this.colCodigoCobrador,
            this.colCobrador,
            this.colEstadoEst,
            this.colSesionApEst,
            this.colFechAproba});
			this.dgvEstablecimientos.Location = new System.Drawing.Point(3, 51);
			this.dgvEstablecimientos.MultiSelect = false;
			this.dgvEstablecimientos.Name = "dgvEstablecimientos";
			this.dgvEstablecimientos.RowHeadersVisible = false;
			this.dgvEstablecimientos.Size = new System.Drawing.Size(988, 228);
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
			// colCobrador
			// 
			this.colCobrador.HeaderText = "Cobrador";
			this.colCobrador.Name = "colCobrador";
			// 
			// colEstadoEst
			// 
			this.colEstadoEst.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
			this.colEstadoEst.FillWeight = 92.26519F;
			this.colEstadoEst.HeaderText = "Estado Regente";
			this.colEstadoEst.Items.AddRange(new object[] {
            "Activo",
            "Inactivo",
            "Sancionado"});
			this.colEstadoEst.Name = "colEstadoEst";
			// 
			// colSesionApEst
			// 
			this.colSesionApEst.FillWeight = 83.35025F;
			this.colSesionApEst.HeaderText = "Sesión Aprobación";
			this.colSesionApEst.Name = "colSesionApEst";
			// 
			// colFechAproba
			// 
			this.colFechAproba.FillWeight = 65.49435F;
			this.colFechAproba.HeaderText = "Fecha Aprobación";
			this.colFechAproba.Name = "colFechAproba";
			// 
			// dtpVencimiento
			// 
			this.dtpVencimiento.Checked = true;
			this.dtpVencimiento.Enabled = false;
			this.dtpVencimiento.Location = new System.Drawing.Point(449, 168);
			this.dtpVencimiento.mostrarCheckBox = false;
			this.dtpVencimiento.mostrarUpDown = false;
			this.dtpVencimiento.Name = "dtpVencimiento";
			this.dtpVencimiento.Size = new System.Drawing.Size(96, 22);
			this.dtpVencimiento.TabIndex = 138;
			this.dtpVencimiento.Value = new System.DateTime(2019, 5, 23, 0, 0, 0, 0);
			this.dtpVencimiento.Visible = false;
			// 
			// lblVencimiento
			// 
			this.lblVencimiento.AutoSize = true;
			this.lblVencimiento.Location = new System.Drawing.Point(375, 172);
			this.lblVencimiento.Name = "lblVencimiento";
			this.lblVencimiento.Size = new System.Drawing.Size(71, 13);
			this.lblVencimiento.TabIndex = 137;
			this.lblVencimiento.Text = " Vencimiento:";
			this.lblVencimiento.Visible = false;
			// 
			// txtMonto
			// 
			this.txtMonto.FormatearNumero = true;
			this.txtMonto.Location = new System.Drawing.Point(109, 196);
			this.txtMonto.Longitud = 30;
			this.txtMonto.Multilinea = false;
			this.txtMonto.Name = "txtMonto";
			this.txtMonto.Password = '\0';
			this.txtMonto.ReadOnly = true;
			this.txtMonto.Size = new System.Drawing.Size(112, 21);
			this.txtMonto.TabIndex = 136;
			this.txtMonto.Valor = "";
			this.txtMonto.Visible = false;
			this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
			// 
			// lblMonto
			// 
			this.lblMonto.AutoSize = true;
			this.lblMonto.Location = new System.Drawing.Point(63, 200);
			this.lblMonto.Name = "lblMonto";
			this.lblMonto.Size = new System.Drawing.Size(40, 13);
			this.lblMonto.TabIndex = 135;
			this.lblMonto.Text = "Monto:";
			this.lblMonto.Visible = false;
			// 
			// dtpFecha
			// 
			this.dtpFecha.Checked = true;
			this.dtpFecha.Enabled = false;
			this.dtpFecha.Location = new System.Drawing.Point(270, 169);
			this.dtpFecha.mostrarCheckBox = false;
			this.dtpFecha.mostrarUpDown = false;
			this.dtpFecha.Name = "dtpFecha";
			this.dtpFecha.Size = new System.Drawing.Size(96, 22);
			this.dtpFecha.TabIndex = 134;
			this.dtpFecha.Value = new System.DateTime(2019, 5, 29, 0, 0, 0, 0);
			this.dtpFecha.Visible = false;
			// 
			// LblFecha
			// 
			this.LblFecha.AutoSize = true;
			this.LblFecha.Location = new System.Drawing.Point(227, 172);
			this.LblFecha.Name = "LblFecha";
			this.LblFecha.Size = new System.Drawing.Size(40, 13);
			this.LblFecha.TabIndex = 133;
			this.LblFecha.Text = "Fecha:";
			this.LblFecha.Visible = false;
			// 
			// txtNPoliza
			// 
			this.txtNPoliza.FormatearNumero = false;
			this.txtNPoliza.Location = new System.Drawing.Point(109, 169);
			this.txtNPoliza.Longitud = 30;
			this.txtNPoliza.Multilinea = false;
			this.txtNPoliza.Name = "txtNPoliza";
			this.txtNPoliza.Password = '\0';
			this.txtNPoliza.ReadOnly = true;
			this.txtNPoliza.Size = new System.Drawing.Size(112, 21);
			this.txtNPoliza.TabIndex = 132;
			this.txtNPoliza.Valor = "";
			this.txtNPoliza.Visible = false;
			// 
			// lblNPoliza
			// 
			this.lblNPoliza.AutoSize = true;
			this.lblNPoliza.Location = new System.Drawing.Point(25, 172);
			this.lblNPoliza.Name = "lblNPoliza";
			this.lblNPoliza.Size = new System.Drawing.Size(78, 13);
			this.lblNPoliza.TabIndex = 131;
			this.lblNPoliza.Text = "Número Póliza:";
			this.lblNPoliza.Visible = false;
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label57.Location = new System.Drawing.Point(67, 145);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(36, 13);
			this.label57.TabIndex = 130;
			this.label57.Text = "Tipo:";
			// 
			// cmbTipoRegente
			// 
			this.cmbTipoRegente.Enabled = false;
			this.cmbTipoRegente.Habilitar = true;
			this.cmbTipoRegente.Index = -1;
			this.cmbTipoRegente.Location = new System.Drawing.Point(109, 141);
			this.cmbTipoRegente.Name = "cmbTipoRegente";
			this.cmbTipoRegente.Size = new System.Drawing.Size(112, 22);
			this.cmbTipoRegente.TabIndex = 129;
			this.cmbTipoRegente.Texto = "";
			this.cmbTipoRegente.Valor = "";
			// 
			// chkCurso
			// 
			this.chkCurso.Checked = false;
			this.chkCurso.Location = new System.Drawing.Point(227, 141);
			this.chkCurso.Name = "chkCurso";
			this.chkCurso.Size = new System.Drawing.Size(139, 17);
			this.chkCurso.TabIndex = 127;
			this.chkCurso.Texto = "Cursos de Regencias";
			this.chkCurso.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkCurso_MouseClick);
			// 
			// dtpPerdida
			// 
			this.dtpPerdida.Checked = false;
			this.dtpPerdida.Enabled = false;
			this.dtpPerdida.Location = new System.Drawing.Point(330, 86);
			this.dtpPerdida.mostrarCheckBox = true;
			this.dtpPerdida.mostrarUpDown = false;
			this.dtpPerdida.Name = "dtpPerdida";
			this.dtpPerdida.Size = new System.Drawing.Size(96, 22);
			this.dtpPerdida.TabIndex = 126;
			this.dtpPerdida.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
			// 
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.Location = new System.Drawing.Point(245, 92);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(79, 13);
			this.label46.TabIndex = 125;
			this.label46.Text = "Fecha Pérdida:";
			// 
			// txtSesionPerdida
			// 
			this.txtSesionPerdida.FormatearNumero = false;
			this.txtSesionPerdida.Location = new System.Drawing.Point(109, 87);
			this.txtSesionPerdida.Longitud = 30;
			this.txtSesionPerdida.Multilinea = false;
			this.txtSesionPerdida.Name = "txtSesionPerdida";
			this.txtSesionPerdida.Password = '\0';
			this.txtSesionPerdida.ReadOnly = true;
			this.txtSesionPerdida.Size = new System.Drawing.Size(112, 21);
			this.txtSesionPerdida.TabIndex = 124;
			this.txtSesionPerdida.Valor = "";
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.Location = new System.Drawing.Point(22, 92);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(81, 13);
			this.label47.TabIndex = 123;
			this.label47.Text = "Sesión Pérdida:";
			// 
			// dtpAprobacion
			// 
			this.dtpAprobacion.Checked = true;
			this.dtpAprobacion.Enabled = false;
			this.dtpAprobacion.Location = new System.Drawing.Point(330, 60);
			this.dtpAprobacion.mostrarCheckBox = false;
			this.dtpAprobacion.mostrarUpDown = false;
			this.dtpAprobacion.Name = "dtpAprobacion";
			this.dtpAprobacion.Size = new System.Drawing.Size(96, 22);
			this.dtpAprobacion.TabIndex = 122;
			this.dtpAprobacion.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
			// 
			// label48
			// 
			this.label48.AutoSize = true;
			this.label48.Location = new System.Drawing.Point(227, 66);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(97, 13);
			this.label48.TabIndex = 121;
			this.label48.Text = "Fecha Aprobación:";
			// 
			// txtSesionAprobacion
			// 
			this.txtSesionAprobacion.FormatearNumero = false;
			this.txtSesionAprobacion.Location = new System.Drawing.Point(109, 60);
			this.txtSesionAprobacion.Longitud = 30;
			this.txtSesionAprobacion.Multilinea = false;
			this.txtSesionAprobacion.Name = "txtSesionAprobacion";
			this.txtSesionAprobacion.Password = '\0';
			this.txtSesionAprobacion.ReadOnly = true;
			this.txtSesionAprobacion.Size = new System.Drawing.Size(112, 21);
			this.txtSesionAprobacion.TabIndex = 120;
			this.txtSesionAprobacion.Valor = "";
			// 
			// label67
			// 
			this.label67.AutoSize = true;
			this.label67.Location = new System.Drawing.Point(4, 66);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(99, 13);
			this.label67.TabIndex = 119;
			this.label67.Text = "Sesión Aprobación:";
			// 
			// txtCobradorRegente
			// 
			this.txtCobradorRegente.FormatearNumero = false;
			this.txtCobradorRegente.Location = new System.Drawing.Point(109, 114);
			this.txtCobradorRegente.Longitud = 30;
			this.txtCobradorRegente.Multilinea = false;
			this.txtCobradorRegente.Name = "txtCobradorRegente";
			this.txtCobradorRegente.Password = '\0';
			this.txtCobradorRegente.ReadOnly = true;
			this.txtCobradorRegente.Size = new System.Drawing.Size(112, 21);
			this.txtCobradorRegente.TabIndex = 118;
			this.txtCobradorRegente.Valor = "";
			this.txtCobradorRegente.Enter += new System.EventHandler(this.txtCobradorRegente_Enter);
			this.txtCobradorRegente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCobradorRegente_KeyDown);
			this.txtCobradorRegente.Leave += new System.EventHandler(this.txtCobradorRegente_Leave);
			this.txtCobradorRegente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCobradorRegente_MouseDoubleClick);
			// 
			// label68
			// 
			this.label68.AutoSize = true;
			this.label68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label68.Location = new System.Drawing.Point(50, 119);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(53, 13);
			this.label68.TabIndex = 117;
			this.label68.Text = "Cobrador:";
			// 
			// txtCobradorNombre
			// 
			this.txtCobradorNombre.FormatearNumero = false;
			this.txtCobradorNombre.Location = new System.Drawing.Point(227, 114);
			this.txtCobradorNombre.Longitud = 30;
			this.txtCobradorNombre.Multilinea = false;
			this.txtCobradorNombre.Name = "txtCobradorNombre";
			this.txtCobradorNombre.Password = '\0';
			this.txtCobradorNombre.ReadOnly = true;
			this.txtCobradorNombre.Size = new System.Drawing.Size(300, 21);
			this.txtCobradorNombre.TabIndex = 116;
			this.txtCobradorNombre.Valor = "";
			// 
			// panel10
			// 
			this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel10.BackColor = System.Drawing.Color.DarkGray;
			this.panel10.Controls.Add(this.label35);
			this.panel10.Location = new System.Drawing.Point(3, 3);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(0, 21);
			this.panel10.TabIndex = 38;
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label35.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label35.Location = new System.Drawing.Point(3, 4);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(62, 14);
			this.label35.TabIndex = 0;
			this.label35.Text = "Regencias";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(338, 28);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(50, 13);
			this.label16.TabIndex = 257;
			this.label16.Text = "Cédula:";
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.Location = new System.Drawing.Point(103, 272);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(57, 13);
			this.label49.TabIndex = 263;
			this.label49.Text = "Categoría:";
			// 
			// groupBox11
			// 
			this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox11.Controls.Add(this.dtpFechaModDireccion);
			this.groupBox11.Controls.Add(this.dtpFechaModCelular);
			this.groupBox11.Controls.Add(this.dtpFechaModEmail);
			this.groupBox11.Controls.Add(this.btnCambioCategoria);
			this.groupBox11.Controls.Add(this.toolStrip14);
			this.groupBox11.Controls.Add(this.btnCambioCondicion);
			this.groupBox11.Controls.Add(this.dtpRegresoCondicion);
			this.groupBox11.Controls.Add(this.lblRegresoCondi);
			this.groupBox11.Controls.Add(this.lblCodSesionIncorporacion);
			this.groupBox11.Controls.Add(this.txtCodigoSesionIncorporacion);
			this.groupBox11.Controls.Add(this.lblIdCole);
			this.groupBox11.Controls.Add(this.btnQuitarImagen);
			this.groupBox11.Controls.Add(this.txtIdColegiado);
			this.groupBox11.Controls.Add(this.btnImagen);
			this.groupBox11.Controls.Add(this.pcbFoto);
			this.groupBox11.Controls.Add(this.lbTelOficina);
			this.groupBox11.Controls.Add(this.txtTelefono3);
			this.groupBox11.Controls.Add(this.txtEdad);
			this.groupBox11.Controls.Add(this.label54);
			this.groupBox11.Controls.Add(this.txtDescCondicion);
			this.groupBox11.Controls.Add(this.txtCondicion);
			this.groupBox11.Controls.Add(this.dtpFechaIngreso);
			this.groupBox11.Controls.Add(this.label14);
			this.groupBox11.Controls.Add(this.txtDescCategoria);
			this.groupBox11.Controls.Add(this.txtCantonNombreF);
			this.groupBox11.Controls.Add(this.label49);
			this.groupBox11.Controls.Add(this.txtProvinciaNombreF);
			this.groupBox11.Controls.Add(this.txtCategoria);
			this.groupBox11.Controls.Add(this.txtDescripcionPais);
			this.groupBox11.Controls.Add(this.rtbDireccion);
			this.groupBox11.Controls.Add(this.dtpFechaNac);
			this.groupBox11.Controls.Add(this.label9);
			this.groupBox11.Controls.Add(this.txtPais);
			this.groupBox11.Controls.Add(this.lblNumColegiado);
			this.groupBox11.Controls.Add(this.txtNumeColegiado);
			this.groupBox11.Controls.Add(this.label8);
			this.groupBox11.Controls.Add(this.txtNombre);
			this.groupBox11.Controls.Add(this.label10);
			this.groupBox11.Controls.Add(this.txtCedula);
			this.groupBox11.Controls.Add(this.cmbSexo);
			this.groupBox11.Controls.Add(this.label16);
			this.groupBox11.Controls.Add(this.label11);
			this.groupBox11.Controls.Add(this.label19);
			this.groupBox11.Controls.Add(this.txtEmail1);
			this.groupBox11.Controls.Add(this.label20);
			this.groupBox11.Controls.Add(this.txtTelefono2);
			this.groupBox11.Controls.Add(this.label18);
			this.groupBox11.Controls.Add(this.txtEmail2);
			this.groupBox11.Controls.Add(this.txtTelefono1);
			this.groupBox11.Controls.Add(this.label27);
			this.groupBox11.Controls.Add(this.label15);
			this.groupBox11.Controls.Add(this.label24);
			this.groupBox11.Controls.Add(this.txtApartado);
			this.groupBox11.Controls.Add(this.label21);
			this.groupBox11.Controls.Add(this.label43);
			this.groupBox11.Controls.Add(this.label44);
			this.groupBox11.Controls.Add(this.label45);
			this.groupBox11.Controls.Add(this.txtProvincia);
			this.groupBox11.Controls.Add(this.txtDistritoNombreF);
			this.groupBox11.Controls.Add(this.txtDistrito);
			this.groupBox11.Controls.Add(this.txtCanton);
			this.groupBox11.Location = new System.Drawing.Point(6, 30);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(983, 497);
			this.groupBox11.TabIndex = 264;
			this.groupBox11.TabStop = false;
			// 
			// dtpFechaModCelular
			// 
			this.dtpFechaModCelular.Checked = true;
			this.dtpFechaModCelular.Location = new System.Drawing.Point(308, 186);
			this.dtpFechaModCelular.mostrarCheckBox = false;
			this.dtpFechaModCelular.mostrarUpDown = false;
			this.dtpFechaModCelular.Name = "dtpFechaModCelular";
			this.dtpFechaModCelular.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaModCelular.TabIndex = 300;
			this.dtpFechaModCelular.Value = new System.DateTime(2018, 11, 30, 9, 46, 47, 67);
			// 
			// dtpFechaModEmail
			// 
			this.dtpFechaModEmail.Checked = true;
			this.dtpFechaModEmail.Location = new System.Drawing.Point(441, 132);
			this.dtpFechaModEmail.mostrarCheckBox = false;
			this.dtpFechaModEmail.mostrarUpDown = false;
			this.dtpFechaModEmail.Name = "dtpFechaModEmail";
			this.dtpFechaModEmail.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaModEmail.TabIndex = 299;
			this.dtpFechaModEmail.Value = new System.DateTime(2018, 11, 30, 9, 46, 47, 67);
			// 
			// btnCambioCategoria
			// 
			this.btnCambioCategoria.Location = new System.Drawing.Point(485, 267);
			this.btnCambioCategoria.Name = "btnCambioCategoria";
			this.btnCambioCategoria.Size = new System.Drawing.Size(57, 23);
			this.btnCambioCategoria.TabIndex = 298;
			this.btnCambioCategoria.Text = "Cambiar";
			this.btnCambioCategoria.UseVisualStyleBackColor = true;
			this.btnCambioCategoria.Visible = false;
			this.btnCambioCategoria.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCambioCategoria_MouseClick);
			// 
			// toolStrip14
			// 
			this.toolStrip14.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip14.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRPTFichaColegiado});
			this.toolStrip14.Location = new System.Drawing.Point(3, 10);
			this.toolStrip14.Name = "toolStrip14";
			this.toolStrip14.Size = new System.Drawing.Size(35, 25);
			this.toolStrip14.TabIndex = 297;
			this.toolStrip14.Text = "toolStrip14";
			// 
			// btnRPTFichaColegiado
			// 
			this.btnRPTFichaColegiado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRPTFichaColegiado.Image = ((System.Drawing.Image)(resources.GetObject("btnRPTFichaColegiado.Image")));
			this.btnRPTFichaColegiado.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRPTFichaColegiado.Name = "btnRPTFichaColegiado";
			this.btnRPTFichaColegiado.Size = new System.Drawing.Size(23, 22);
			this.btnRPTFichaColegiado.Text = "Ficha del Colegiado";
			this.btnRPTFichaColegiado.Click += new System.EventHandler(this.btnRPTFichaColegiado_Click);
			// 
			// btnCambioCondicion
			// 
			this.btnCambioCondicion.Location = new System.Drawing.Point(485, 295);
			this.btnCambioCondicion.Name = "btnCambioCondicion";
			this.btnCambioCondicion.Size = new System.Drawing.Size(57, 23);
			this.btnCambioCondicion.TabIndex = 286;
			this.btnCambioCondicion.Text = "Cambiar";
			this.btnCambioCondicion.UseVisualStyleBackColor = true;
			this.btnCambioCondicion.Visible = false;
			this.btnCambioCondicion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCambioCondicion_MouseClick);
			// 
			// dtpRegresoCondicion
			// 
			this.dtpRegresoCondicion.Checked = true;
			this.dtpRegresoCondicion.Location = new System.Drawing.Point(165, 323);
			this.dtpRegresoCondicion.mostrarCheckBox = false;
			this.dtpRegresoCondicion.mostrarUpDown = false;
			this.dtpRegresoCondicion.Name = "dtpRegresoCondicion";
			this.dtpRegresoCondicion.Size = new System.Drawing.Size(101, 22);
			this.dtpRegresoCondicion.TabIndex = 284;
			this.dtpRegresoCondicion.Value = new System.DateTime(2018, 11, 30, 9, 46, 47, 67);
			this.dtpRegresoCondicion.Visible = false;
			// 
			// lblRegresoCondi
			// 
			this.lblRegresoCondi.AutoSize = true;
			this.lblRegresoCondi.Location = new System.Drawing.Point(58, 325);
			this.lblRegresoCondi.Name = "lblRegresoCondi";
			this.lblRegresoCondi.Size = new System.Drawing.Size(100, 13);
			this.lblRegresoCondi.TabIndex = 285;
			this.lblRegresoCondi.Text = "Regreso Condición:";
			this.lblRegresoCondi.Visible = false;
			// 
			// lblCodSesionIncorporacion
			// 
			this.lblCodSesionIncorporacion.AutoSize = true;
			this.lblCodSesionIncorporacion.Location = new System.Drawing.Point(572, 55);
			this.lblCodSesionIncorporacion.Name = "lblCodSesionIncorporacion";
			this.lblCodSesionIncorporacion.Size = new System.Drawing.Size(110, 13);
			this.lblCodSesionIncorporacion.TabIndex = 283;
			this.lblCodSesionIncorporacion.Text = "Sesión Incorporación:";
			// 
			// txtCodigoSesionIncorporacion
			// 
			this.txtCodigoSesionIncorporacion.FormatearNumero = false;
			this.txtCodigoSesionIncorporacion.Location = new System.Drawing.Point(688, 51);
			this.txtCodigoSesionIncorporacion.Longitud = 32767;
			this.txtCodigoSesionIncorporacion.Multilinea = false;
			this.txtCodigoSesionIncorporacion.Name = "txtCodigoSesionIncorporacion";
			this.txtCodigoSesionIncorporacion.Password = '\0';
			this.txtCodigoSesionIncorporacion.ReadOnly = false;
			this.txtCodigoSesionIncorporacion.Size = new System.Drawing.Size(237, 21);
			this.txtCodigoSesionIncorporacion.TabIndex = 282;
			this.txtCodigoSesionIncorporacion.Valor = "";
			this.txtCodigoSesionIncorporacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigoSesionIncorporacion_KeyUp);
			// 
			// lblIdCole
			// 
			this.lblIdCole.AutoSize = true;
			this.lblIdCole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIdCole.Location = new System.Drawing.Point(600, 27);
			this.lblIdCole.Name = "lblIdCole";
			this.lblIdCole.Size = new System.Drawing.Size(82, 13);
			this.lblIdCole.TabIndex = 281;
			this.lblIdCole.Text = "Id Colegiado:";
			// 
			// btnQuitarImagen
			// 
			this.btnQuitarImagen.Location = new System.Drawing.Point(873, 284);
			this.btnQuitarImagen.Name = "btnQuitarImagen";
			this.btnQuitarImagen.Size = new System.Drawing.Size(52, 23);
			this.btnQuitarImagen.TabIndex = 280;
			this.btnQuitarImagen.Text = "Quitar";
			this.btnQuitarImagen.UseVisualStyleBackColor = true;
			this.btnQuitarImagen.Click += new System.EventHandler(this.btnQuitarImagen_Click);
			// 
			// txtIdColegiado
			// 
			this.txtIdColegiado.FormatearNumero = false;
			this.txtIdColegiado.Location = new System.Drawing.Point(688, 23);
			this.txtIdColegiado.Longitud = 32767;
			this.txtIdColegiado.Multilinea = false;
			this.txtIdColegiado.Name = "txtIdColegiado";
			this.txtIdColegiado.Password = '\0';
			this.txtIdColegiado.ReadOnly = true;
			this.txtIdColegiado.Size = new System.Drawing.Size(237, 21);
			this.txtIdColegiado.TabIndex = 279;
			this.txtIdColegiado.Valor = "";
			// 
			// btnImagen
			// 
			this.btnImagen.Location = new System.Drawing.Point(873, 241);
			this.btnImagen.Name = "btnImagen";
			this.btnImagen.Size = new System.Drawing.Size(52, 23);
			this.btnImagen.TabIndex = 278;
			this.btnImagen.Text = "Agregar";
			this.btnImagen.UseVisualStyleBackColor = true;
			this.btnImagen.Click += new System.EventHandler(this.btnImagen_Click);
			// 
			// pcbFoto
			// 
			this.pcbFoto.Image = global::KOLEGIO.Properties.Resources._default;
			this.pcbFoto.Location = new System.Drawing.Point(688, 107);
			this.pcbFoto.Name = "pcbFoto";
			this.pcbFoto.Size = new System.Drawing.Size(179, 204);
			this.pcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pcbFoto.TabIndex = 277;
			this.pcbFoto.TabStop = false;
			// 
			// lbTelOficina
			// 
			this.lbTelOficina.AutoSize = true;
			this.lbTelOficina.Location = new System.Drawing.Point(71, 245);
			this.lbTelOficina.Name = "lbTelOficina";
			this.lbTelOficina.Size = new System.Drawing.Size(88, 13);
			this.lbTelOficina.TabIndex = 276;
			this.lbTelOficina.Text = "Teléfono Oficina:";
			// 
			// txtTelefono3
			// 
			this.txtTelefono3.FormatearNumero = false;
			this.txtTelefono3.Location = new System.Drawing.Point(165, 240);
			this.txtTelefono3.Longitud = 70;
			this.txtTelefono3.Multilinea = false;
			this.txtTelefono3.Name = "txtTelefono3";
			this.txtTelefono3.Password = '\0';
			this.txtTelefono3.ReadOnly = false;
			this.txtTelefono3.Size = new System.Drawing.Size(137, 21);
			this.txtTelefono3.TabIndex = 275;
			this.txtTelefono3.Valor = "";
			// 
			// txtEdad
			// 
			this.txtEdad.FormatearNumero = false;
			this.txtEdad.Location = new System.Drawing.Point(313, 78);
			this.txtEdad.Longitud = 4;
			this.txtEdad.Multilinea = false;
			this.txtEdad.Name = "txtEdad";
			this.txtEdad.Password = '\0';
			this.txtEdad.ReadOnly = true;
			this.txtEdad.Size = new System.Drawing.Size(55, 21);
			this.txtEdad.TabIndex = 274;
			this.txtEdad.Valor = "";
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.Location = new System.Drawing.Point(272, 83);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(35, 13);
			this.label54.TabIndex = 273;
			this.label54.Text = "Edad:";
			// 
			// txtDescCondicion
			// 
			this.txtDescCondicion.FormatearNumero = false;
			this.txtDescCondicion.Location = new System.Drawing.Point(229, 295);
			this.txtDescCondicion.Longitud = 32767;
			this.txtDescCondicion.Multilinea = false;
			this.txtDescCondicion.Name = "txtDescCondicion";
			this.txtDescCondicion.Password = '\0';
			this.txtDescCondicion.ReadOnly = true;
			this.txtDescCondicion.Size = new System.Drawing.Size(250, 21);
			this.txtDescCondicion.TabIndex = 271;
			this.txtDescCondicion.Valor = "";
			// 
			// txtCondicion
			// 
			this.txtCondicion.FormatearNumero = false;
			this.txtCondicion.Location = new System.Drawing.Point(165, 295);
			this.txtCondicion.Longitud = 4;
			this.txtCondicion.Multilinea = false;
			this.txtCondicion.Name = "txtCondicion";
			this.txtCondicion.Password = '\0';
			this.txtCondicion.ReadOnly = false;
			this.txtCondicion.Size = new System.Drawing.Size(59, 21);
			this.txtCondicion.TabIndex = 16;
			this.txtCondicion.Valor = "";
			this.txtCondicion.Enter += new System.EventHandler(this.txtCondicion_Enter);
			this.txtCondicion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCondicion_KeyDown);
			this.txtCondicion.Leave += new System.EventHandler(this.txtCondicion_Leave);
			this.txtCondicion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCondicion_MouseDoubleClick);
			// 
			// dtpFechaIngreso
			// 
			this.dtpFechaIngreso.Checked = true;
			this.dtpFechaIngreso.Location = new System.Drawing.Point(688, 77);
			this.dtpFechaIngreso.mostrarCheckBox = false;
			this.dtpFechaIngreso.mostrarUpDown = false;
			this.dtpFechaIngreso.Name = "dtpFechaIngreso";
			this.dtpFechaIngreso.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaIngreso.TabIndex = 15;
			this.dtpFechaIngreso.Value = new System.DateTime(2018, 11, 30, 9, 46, 47, 67);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(574, 80);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(108, 13);
			this.label14.TabIndex = 268;
			this.label14.Text = "Fecha Incorporación:";
			// 
			// txtDescCategoria
			// 
			this.txtDescCategoria.FormatearNumero = false;
			this.txtDescCategoria.Location = new System.Drawing.Point(230, 267);
			this.txtDescCategoria.Longitud = 32767;
			this.txtDescCategoria.Multilinea = false;
			this.txtDescCategoria.Name = "txtDescCategoria";
			this.txtDescCategoria.Password = '\0';
			this.txtDescCategoria.ReadOnly = true;
			this.txtDescCategoria.Size = new System.Drawing.Size(249, 21);
			this.txtDescCategoria.TabIndex = 267;
			this.txtDescCategoria.Valor = "";
			// 
			// txtCantonNombreF
			// 
			this.txtCantonNombreF.FormatearNumero = false;
			this.txtCantonNombreF.Location = new System.Drawing.Point(746, 385);
			this.txtCantonNombreF.Longitud = 32767;
			this.txtCantonNombreF.Multilinea = false;
			this.txtCantonNombreF.Name = "txtCantonNombreF";
			this.txtCantonNombreF.Password = '\0';
			this.txtCantonNombreF.ReadOnly = true;
			this.txtCantonNombreF.Size = new System.Drawing.Size(179, 21);
			this.txtCantonNombreF.TabIndex = 266;
			this.txtCantonNombreF.Valor = "";
			// 
			// txtProvinciaNombreF
			// 
			this.txtProvinciaNombreF.FormatearNumero = false;
			this.txtProvinciaNombreF.Location = new System.Drawing.Point(746, 351);
			this.txtProvinciaNombreF.Longitud = 32767;
			this.txtProvinciaNombreF.Multilinea = false;
			this.txtProvinciaNombreF.Name = "txtProvinciaNombreF";
			this.txtProvinciaNombreF.Password = '\0';
			this.txtProvinciaNombreF.ReadOnly = true;
			this.txtProvinciaNombreF.Size = new System.Drawing.Size(179, 21);
			this.txtProvinciaNombreF.TabIndex = 265;
			this.txtProvinciaNombreF.Valor = "";
			// 
			// txtCategoria
			// 
			this.txtCategoria.FormatearNumero = false;
			this.txtCategoria.Location = new System.Drawing.Point(165, 267);
			this.txtCategoria.Longitud = 30;
			this.txtCategoria.Multilinea = false;
			this.txtCategoria.Name = "txtCategoria";
			this.txtCategoria.Password = '\0';
			this.txtCategoria.ReadOnly = false;
			this.txtCategoria.Size = new System.Drawing.Size(59, 21);
			this.txtCategoria.TabIndex = 11;
			this.txtCategoria.Valor = "";
			this.txtCategoria.Enter += new System.EventHandler(this.txtCategoria_Enter);
			this.txtCategoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoria_KeyDown);
			this.txtCategoria.Leave += new System.EventHandler(this.txtCategoria_Leave);
			this.txtCategoria.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCategoria_MouseDoubleClick);
			// 
			// txtDescripcionPais
			// 
			this.txtDescripcionPais.FormatearNumero = false;
			this.txtDescripcionPais.Location = new System.Drawing.Point(746, 317);
			this.txtDescripcionPais.Longitud = 32767;
			this.txtDescripcionPais.Multilinea = false;
			this.txtDescripcionPais.Name = "txtDescripcionPais";
			this.txtDescripcionPais.Password = '\0';
			this.txtDescripcionPais.ReadOnly = true;
			this.txtDescripcionPais.Size = new System.Drawing.Size(179, 21);
			this.txtDescripcionPais.TabIndex = 264;
			this.txtDescripcionPais.Valor = "";
			// 
			// rtbDireccion
			// 
			this.rtbDireccion.Location = new System.Drawing.Point(165, 351);
			this.rtbDireccion.Longitud = 500;
			this.rtbDireccion.Mayusculas = false;
			this.rtbDireccion.Name = "rtbDireccion";
			this.rtbDireccion.ReadOnly = false;
			this.rtbDireccion.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang3082{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22000}\\viewkind4\\uc1 \r\n\\par" +
    "d\\f0\\fs17\\par\r\n}\r\n";
			this.rtbDireccion.Size = new System.Drawing.Size(377, 116);
			this.rtbDireccion.TabIndex = 21;
			// 
			// dtpFechaNac
			// 
			this.dtpFechaNac.Checked = true;
			this.dtpFechaNac.Location = new System.Drawing.Point(165, 79);
			this.dtpFechaNac.mostrarCheckBox = false;
			this.dtpFechaNac.mostrarUpDown = false;
			this.dtpFechaNac.Name = "dtpFechaNac";
			this.dtpFechaNac.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaNac.TabIndex = 4;
			this.dtpFechaNac.Value = new System.DateTime(2018, 11, 30, 9, 46, 47, 67);
			this.dtpFechaNac.Leave += new System.EventHandler(this.dtpFechaNac_Leave_1);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(650, 321);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(32, 13);
			this.label9.TabIndex = 261;
			this.label9.Text = "País:";
			// 
			// txtPais
			// 
			this.txtPais.FormatearNumero = false;
			this.txtPais.Location = new System.Drawing.Point(688, 317);
			this.txtPais.Longitud = 4;
			this.txtPais.Multilinea = false;
			this.txtPais.Name = "txtPais";
			this.txtPais.Password = '\0';
			this.txtPais.ReadOnly = false;
			this.txtPais.Size = new System.Drawing.Size(59, 21);
			this.txtPais.TabIndex = 17;
			this.txtPais.Valor = "";
			this.txtPais.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPais_KeyDown);
			this.txtPais.Leave += new System.EventHandler(this.txtPais_Leave);
			this.txtPais.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPais_MouseDoubleClick);
			// 
			// txtNumeColegiado
			// 
			this.txtNumeColegiado.FormatearNumero = false;
			this.txtNumeColegiado.Location = new System.Drawing.Point(165, 24);
			this.txtNumeColegiado.Longitud = 30;
			this.txtNumeColegiado.Multilinea = false;
			this.txtNumeColegiado.Name = "txtNumeColegiado";
			this.txtNumeColegiado.Password = '\0';
			this.txtNumeColegiado.ReadOnly = false;
			this.txtNumeColegiado.Size = new System.Drawing.Size(167, 21);
			this.txtNumeColegiado.TabIndex = 1;
			this.txtNumeColegiado.Valor = "";
			// 
			// txtCedula
			// 
			this.txtCedula.FormatearNumero = false;
			this.txtCedula.Location = new System.Drawing.Point(394, 24);
			this.txtCedula.Longitud = 15;
			this.txtCedula.Multilinea = false;
			this.txtCedula.Name = "txtCedula";
			this.txtCedula.Password = '\0';
			this.txtCedula.ReadOnly = false;
			this.txtCedula.Size = new System.Drawing.Size(148, 21);
			this.txtCedula.TabIndex = 2;
			this.txtCedula.Valor = "";
			this.txtCedula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedula_KeyPress);
			this.txtCedula.Leave += new System.EventHandler(this.txtCedula_Leave);
			// 
			// panel5
			// 
			this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel5.BackColor = System.Drawing.Color.DarkGray;
			this.panel5.Controls.Add(this.label40);
			this.panel5.Location = new System.Drawing.Point(3, 3);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(0, 21);
			this.panel5.TabIndex = 36;
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label40.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label40.Location = new System.Drawing.Point(3, 4);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(103, 14);
			this.label40.TabIndex = 0;
			this.label40.Text = "Historial Laboral";
			// 
			// txtEmpresa
			// 
			this.txtEmpresa.FormatearNumero = false;
			this.txtEmpresa.Location = new System.Drawing.Point(166, 30);
			this.txtEmpresa.Longitud = 30;
			this.txtEmpresa.Multilinea = false;
			this.txtEmpresa.Name = "txtEmpresa";
			this.txtEmpresa.Password = '\0';
			this.txtEmpresa.ReadOnly = false;
			this.txtEmpresa.Size = new System.Drawing.Size(59, 21);
			this.txtEmpresa.TabIndex = 280;
			this.txtEmpresa.Valor = "";
			this.txtEmpresa.Visible = false;
			this.txtEmpresa.Enter += new System.EventHandler(this.txtEmpresa_Enter);
			this.txtEmpresa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpresa_KeyDown);
			this.txtEmpresa.Leave += new System.EventHandler(this.txtEmpresa_Leave);
			this.txtEmpresa.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtEmpresa_MouseDoubleClick);
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.Location = new System.Drawing.Point(109, 88);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(51, 13);
			this.label52.TabIndex = 281;
			this.label52.Text = "Empresa:";
			// 
			// txtEmpresaN
			// 
			this.txtEmpresaN.FormatearNumero = false;
			this.txtEmpresaN.Location = new System.Drawing.Point(224, 30);
			this.txtEmpresaN.Longitud = 32767;
			this.txtEmpresaN.Multilinea = false;
			this.txtEmpresaN.Name = "txtEmpresaN";
			this.txtEmpresaN.Password = '\0';
			this.txtEmpresaN.ReadOnly = true;
			this.txtEmpresaN.Size = new System.Drawing.Size(61, 21);
			this.txtEmpresaN.TabIndex = 282;
			this.txtEmpresaN.Valor = "";
			this.txtEmpresaN.Visible = false;
			// 
			// dgvHistorialLaboral
			// 
			this.dgvHistorialLaboral.AllowUserToAddRows = false;
			this.dgvHistorialLaboral.AllowUserToDeleteRows = false;
			this.dgvHistorialLaboral.AllowUserToResizeRows = false;
			this.dgvHistorialLaboral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvHistorialLaboral.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvHistorialLaboral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHistorialLaboral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombreEmpresa,
            this.colCodigoPuesto,
            this.colPuesto,
            this.colTelefono,
            this.colCorreoEmpresa,
            this.colEmpresaDesde,
            this.colEmpresaHasta,
            this.colDireccionEmpresa});
			this.dgvHistorialLaboral.Location = new System.Drawing.Point(53, 247);
			this.dgvHistorialLaboral.MultiSelect = false;
			this.dgvHistorialLaboral.Name = "dgvHistorialLaboral";
			this.dgvHistorialLaboral.RowHeadersVisible = false;
			this.dgvHistorialLaboral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvHistorialLaboral.Size = new System.Drawing.Size(243, 0);
			this.dgvHistorialLaboral.TabIndex = 284;
			// 
			// colNombreEmpresa
			// 
			this.colNombreEmpresa.HeaderText = "Empresa";
			this.colNombreEmpresa.Name = "colNombreEmpresa";
			this.colNombreEmpresa.ReadOnly = true;
			this.colNombreEmpresa.Width = 200;
			// 
			// colCodigoPuesto
			// 
			this.colCodigoPuesto.HeaderText = "Codigo Puesto";
			this.colCodigoPuesto.Name = "colCodigoPuesto";
			this.colCodigoPuesto.Visible = false;
			this.colCodigoPuesto.Width = 50;
			// 
			// colPuesto
			// 
			this.colPuesto.HeaderText = "Puesto";
			this.colPuesto.Name = "colPuesto";
			this.colPuesto.Width = 180;
			// 
			// colTelefono
			// 
			this.colTelefono.HeaderText = "Teléfono";
			this.colTelefono.Name = "colTelefono";
			// 
			// colCorreoEmpresa
			// 
			this.colCorreoEmpresa.HeaderText = "Correo";
			this.colCorreoEmpresa.Name = "colCorreoEmpresa";
			this.colCorreoEmpresa.Width = 250;
			// 
			// colEmpresaDesde
			// 
			dataGridViewCellStyle4.Format = "d";
			dataGridViewCellStyle4.NullValue = null;
			this.colEmpresaDesde.DefaultCellStyle = dataGridViewCellStyle4;
			this.colEmpresaDesde.HeaderText = "Desde";
			this.colEmpresaDesde.Name = "colEmpresaDesde";
			// 
			// colEmpresaHasta
			// 
			dataGridViewCellStyle5.Format = "d";
			dataGridViewCellStyle5.NullValue = null;
			this.colEmpresaHasta.DefaultCellStyle = dataGridViewCellStyle5;
			this.colEmpresaHasta.HeaderText = "Hasta";
			this.colEmpresaHasta.Name = "colEmpresaHasta";
			// 
			// colDireccionEmpresa
			// 
			this.colDireccionEmpresa.HeaderText = "Dirección";
			this.colDireccionEmpresa.Name = "colDireccionEmpresa";
			this.colDireccionEmpresa.Width = 400;
			// 
			// miniToolStrip
			// 
			this.miniToolStrip.AccessibleName = "New item selection";
			this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
			this.miniToolStrip.AutoSize = false;
			this.miniToolStrip.CanOverflow = false;
			this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.miniToolStrip.Location = new System.Drawing.Point(55, 3);
			this.miniToolStrip.Name = "miniToolStrip";
			this.miniToolStrip.Size = new System.Drawing.Size(58, 25);
			this.miniToolStrip.TabIndex = 285;
			// 
			// btnNuevaEmpresa
			// 
			this.btnNuevaEmpresa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevaEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaEmpresa.Image")));
			this.btnNuevaEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevaEmpresa.Name = "btnNuevaEmpresa";
			this.btnNuevaEmpresa.Size = new System.Drawing.Size(23, 22);
			this.btnNuevaEmpresa.Text = "Agregar Empresa";
			this.btnNuevaEmpresa.Click += new System.EventHandler(this.btnNuevaEmpresa_Click);
			// 
			// btnEliminarEmpresa
			// 
			this.btnEliminarEmpresa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarEmpresa.Image")));
			this.btnEliminarEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarEmpresa.Name = "btnEliminarEmpresa";
			this.btnEliminarEmpresa.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarEmpresa.Text = "Eliminar Empresa";
			this.btnEliminarEmpresa.Click += new System.EventHandler(this.btnEliminarEmpresa_Click);
			// 
			// tpLaboral
			// 
			this.tpLaboral.Controls.Add(this.txtHistPuesto);
			this.tpLaboral.Controls.Add(this.txtDescPuesto);
			this.tpLaboral.Controls.Add(this.label86);
			this.tpLaboral.Controls.Add(this.txtPuesto);
			this.tpLaboral.Controls.Add(this.rtbDireccionLaboral);
			this.tpLaboral.Controls.Add(this.label87);
			this.tpLaboral.Controls.Add(this.txtCorreoLaboral);
			this.tpLaboral.Controls.Add(this.label85);
			this.tpLaboral.Controls.Add(this.txtHistTelEmpresa);
			this.tpLaboral.Controls.Add(this.label60);
			this.tpLaboral.Controls.Add(this.txtHistEmpresa);
			this.tpLaboral.Controls.Add(this.grbRangoLaboral);
			this.tpLaboral.Controls.Add(this.toolStrip3);
			this.tpLaboral.Controls.Add(this.dgvHistorialLaboral);
			this.tpLaboral.Controls.Add(this.txtEmpresaN);
			this.tpLaboral.Controls.Add(this.label52);
			this.tpLaboral.Controls.Add(this.txtEmpresa);
			this.tpLaboral.Controls.Add(this.panel5);
			this.tpLaboral.Location = new System.Drawing.Point(4, 22);
			this.tpLaboral.Name = "tpLaboral";
			this.tpLaboral.Size = new System.Drawing.Size(997, 566);
			this.tpLaboral.TabIndex = 3;
			this.tpLaboral.Text = "Historial Laboral";
			this.tpLaboral.UseVisualStyleBackColor = true;
			// 
			// txtHistPuesto
			// 
			this.txtHistPuesto.FormatearNumero = false;
			this.txtHistPuesto.Location = new System.Drawing.Point(166, 59);
			this.txtHistPuesto.Longitud = 30;
			this.txtHistPuesto.Multilinea = false;
			this.txtHistPuesto.Name = "txtHistPuesto";
			this.txtHistPuesto.Password = '\0';
			this.txtHistPuesto.ReadOnly = false;
			this.txtHistPuesto.Size = new System.Drawing.Size(343, 21);
			this.txtHistPuesto.TabIndex = 300;
			this.txtHistPuesto.Valor = "";
			// 
			// txtDescPuesto
			// 
			this.txtDescPuesto.FormatearNumero = false;
			this.txtDescPuesto.Location = new System.Drawing.Point(352, 30);
			this.txtDescPuesto.Longitud = 32767;
			this.txtDescPuesto.Multilinea = false;
			this.txtDescPuesto.Name = "txtDescPuesto";
			this.txtDescPuesto.Password = '\0';
			this.txtDescPuesto.ReadOnly = true;
			this.txtDescPuesto.Size = new System.Drawing.Size(61, 21);
			this.txtDescPuesto.TabIndex = 299;
			this.txtDescPuesto.Valor = "";
			this.txtDescPuesto.Visible = false;
			// 
			// label86
			// 
			this.label86.AutoSize = true;
			this.label86.Location = new System.Drawing.Point(117, 62);
			this.label86.Name = "label86";
			this.label86.Size = new System.Drawing.Size(43, 13);
			this.label86.TabIndex = 298;
			this.label86.Text = "Puesto:";
			// 
			// txtPuesto
			// 
			this.txtPuesto.FormatearNumero = false;
			this.txtPuesto.Location = new System.Drawing.Point(294, 30);
			this.txtPuesto.Longitud = 30;
			this.txtPuesto.Multilinea = false;
			this.txtPuesto.Name = "txtPuesto";
			this.txtPuesto.Password = '\0';
			this.txtPuesto.ReadOnly = false;
			this.txtPuesto.Size = new System.Drawing.Size(59, 21);
			this.txtPuesto.TabIndex = 297;
			this.txtPuesto.Valor = "";
			this.txtPuesto.Visible = false;
			this.txtPuesto.Enter += new System.EventHandler(this.txtPuesto_Enter);
			this.txtPuesto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPuesto_KeyDown);
			this.txtPuesto.Leave += new System.EventHandler(this.txtPuesto_Leave);
			this.txtPuesto.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPuesto_MouseDoubleClick);
			// 
			// rtbDireccionLaboral
			// 
			this.rtbDireccionLaboral.Location = new System.Drawing.Point(165, 146);
			this.rtbDireccionLaboral.Longitud = 500;
			this.rtbDireccionLaboral.Mayusculas = false;
			this.rtbDireccionLaboral.Name = "rtbDireccionLaboral";
			this.rtbDireccionLaboral.ReadOnly = false;
			this.rtbDireccionLaboral.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang3082{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22000}\\viewkind4\\uc1 \r\n\\par" +
    "d\\f0\\fs17\\par\r\n}\r\n";
			this.rtbDireccionLaboral.Size = new System.Drawing.Size(343, 65);
			this.rtbDireccionLaboral.TabIndex = 296;
			// 
			// label87
			// 
			this.label87.AutoSize = true;
			this.label87.Location = new System.Drawing.Point(60, 146);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(99, 13);
			this.label87.TabIndex = 295;
			this.label87.Text = "Dirección Empresa:";
			// 
			// txtCorreoLaboral
			// 
			this.txtCorreoLaboral.FormatearNumero = false;
			this.txtCorreoLaboral.Location = new System.Drawing.Point(166, 115);
			this.txtCorreoLaboral.Longitud = 30;
			this.txtCorreoLaboral.Multilinea = false;
			this.txtCorreoLaboral.Name = "txtCorreoLaboral";
			this.txtCorreoLaboral.Password = '\0';
			this.txtCorreoLaboral.ReadOnly = false;
			this.txtCorreoLaboral.Size = new System.Drawing.Size(343, 21);
			this.txtCorreoLaboral.TabIndex = 294;
			this.txtCorreoLaboral.Valor = "";
			// 
			// label85
			// 
			this.label85.AutoSize = true;
			this.label85.Location = new System.Drawing.Point(75, 118);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(85, 13);
			this.label85.TabIndex = 293;
			this.label85.Text = "Correo Empresa:";
			// 
			// txtHistTelEmpresa
			// 
			this.txtHistTelEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHistTelEmpresa.FormatearNumero = false;
			this.txtHistTelEmpresa.Location = new System.Drawing.Point(-17637, 146);
			this.txtHistTelEmpresa.Longitud = 30;
			this.txtHistTelEmpresa.Multilinea = false;
			this.txtHistTelEmpresa.Name = "txtHistTelEmpresa";
			this.txtHistTelEmpresa.Password = '\0';
			this.txtHistTelEmpresa.ReadOnly = false;
			this.txtHistTelEmpresa.Size = new System.Drawing.Size(173, 21);
			this.txtHistTelEmpresa.TabIndex = 292;
			this.txtHistTelEmpresa.Valor = "";
			// 
			// label60
			// 
			this.label60.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label60.AutoSize = true;
			this.label60.Location = new System.Drawing.Point(-18050, 146);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(96, 13);
			this.label60.TabIndex = 291;
			this.label60.Text = "Teléfono Empresa:";
			// 
			// txtHistEmpresa
			// 
			this.txtHistEmpresa.FormatearNumero = false;
			this.txtHistEmpresa.Location = new System.Drawing.Point(166, 88);
			this.txtHistEmpresa.Longitud = 30;
			this.txtHistEmpresa.Multilinea = false;
			this.txtHistEmpresa.Name = "txtHistEmpresa";
			this.txtHistEmpresa.Password = '\0';
			this.txtHistEmpresa.ReadOnly = false;
			this.txtHistEmpresa.Size = new System.Drawing.Size(343, 21);
			this.txtHistEmpresa.TabIndex = 290;
			this.txtHistEmpresa.Valor = "";
			// 
			// grbRangoLaboral
			// 
			this.grbRangoLaboral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grbRangoLaboral.Controls.Add(this.label55);
			this.grbRangoLaboral.Controls.Add(this.label53);
			this.grbRangoLaboral.Controls.Add(this.dtpEmpresaHasta);
			this.grbRangoLaboral.Controls.Add(this.dtpEmpresaDesde);
			this.grbRangoLaboral.Location = new System.Drawing.Point(-10618, 57);
			this.grbRangoLaboral.Name = "grbRangoLaboral";
			this.grbRangoLaboral.Size = new System.Drawing.Size(272, 79);
			this.grbRangoLaboral.TabIndex = 286;
			this.grbRangoLaboral.TabStop = false;
			this.grbRangoLaboral.Text = "Rango Laboral";
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(64, 51);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(38, 13);
			this.label55.TabIndex = 283;
			this.label55.Text = "Hasta:";
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(61, 22);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(41, 13);
			this.label53.TabIndex = 282;
			this.label53.Text = "Desde:";
			// 
			// dtpEmpresaHasta
			// 
			this.dtpEmpresaHasta.Checked = false;
			this.dtpEmpresaHasta.Location = new System.Drawing.Point(108, 47);
			this.dtpEmpresaHasta.mostrarCheckBox = true;
			this.dtpEmpresaHasta.mostrarUpDown = false;
			this.dtpEmpresaHasta.Name = "dtpEmpresaHasta";
			this.dtpEmpresaHasta.Size = new System.Drawing.Size(101, 22);
			this.dtpEmpresaHasta.TabIndex = 6;
			this.dtpEmpresaHasta.Value = new System.DateTime(2018, 11, 30, 9, 46, 47, 67);
			// 
			// dtpEmpresaDesde
			// 
			this.dtpEmpresaDesde.Checked = true;
			this.dtpEmpresaDesde.Location = new System.Drawing.Point(108, 19);
			this.dtpEmpresaDesde.mostrarCheckBox = false;
			this.dtpEmpresaDesde.mostrarUpDown = false;
			this.dtpEmpresaDesde.Name = "dtpEmpresaDesde";
			this.dtpEmpresaDesde.Size = new System.Drawing.Size(101, 22);
			this.dtpEmpresaDesde.TabIndex = 5;
			this.dtpEmpresaDesde.Value = new System.DateTime(2018, 11, 30, 9, 46, 47, 67);
			// 
			// toolStrip3
			// 
			this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevaEmpresa,
            this.btnEliminarEmpresa,
            this.btnModificarlaboral});
			this.toolStrip3.Location = new System.Drawing.Point(63, 219);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Size = new System.Drawing.Size(81, 25);
			this.toolStrip3.TabIndex = 285;
			this.toolStrip3.Text = "toolStrip3";
			// 
			// btnModificarlaboral
			// 
			this.btnModificarlaboral.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnModificarlaboral.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarlaboral.Image")));
			this.btnModificarlaboral.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnModificarlaboral.Name = "btnModificarlaboral";
			this.btnModificarlaboral.Size = new System.Drawing.Size(23, 22);
			this.btnModificarlaboral.Text = "Modificar";
			this.btnModificarlaboral.Click += new System.EventHandler(this.btnModificarlaboral_Click);
			// 
			// tpPlantilla
			// 
			this.tpPlantilla.Controls.Add(this.lblCantTotalPlantillaCobro);
			this.tpPlantilla.Controls.Add(this.lblTotalPlantillaCobro);
			this.tpPlantilla.Controls.Add(this.panel16);
			this.tpPlantilla.Controls.Add(this.grbPlantilla);
			this.tpPlantilla.Location = new System.Drawing.Point(4, 22);
			this.tpPlantilla.Name = "tpPlantilla";
			this.tpPlantilla.Size = new System.Drawing.Size(997, 566);
			this.tpPlantilla.TabIndex = 3;
			this.tpPlantilla.Text = "Plantilla Cobro";
			this.tpPlantilla.UseVisualStyleBackColor = true;
			// 
			// lblCantTotalPlantillaCobro
			// 
			this.lblCantTotalPlantillaCobro.AutoSize = true;
			this.lblCantTotalPlantillaCobro.Location = new System.Drawing.Point(861, 540);
			this.lblCantTotalPlantillaCobro.Name = "lblCantTotalPlantillaCobro";
			this.lblCantTotalPlantillaCobro.Size = new System.Drawing.Size(13, 13);
			this.lblCantTotalPlantillaCobro.TabIndex = 300;
			this.lblCantTotalPlantillaCobro.Text = "0";
			// 
			// lblTotalPlantillaCobro
			// 
			this.lblTotalPlantillaCobro.AutoSize = true;
			this.lblTotalPlantillaCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalPlantillaCobro.Location = new System.Drawing.Point(827, 540);
			this.lblTotalPlantillaCobro.Name = "lblTotalPlantillaCobro";
			this.lblTotalPlantillaCobro.Size = new System.Drawing.Size(40, 13);
			this.lblTotalPlantillaCobro.TabIndex = 299;
			this.lblTotalPlantillaCobro.Text = "Total:";
			// 
			// panel16
			// 
			this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel16.BackColor = System.Drawing.Color.DarkGray;
			this.panel16.Controls.Add(this.label65);
			this.panel16.Location = new System.Drawing.Point(8, 6);
			this.panel16.Name = "panel16";
			this.panel16.Size = new System.Drawing.Size(0, 26);
			this.panel16.TabIndex = 38;
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label65.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label65.Location = new System.Drawing.Point(3, 4);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(163, 14);
			this.label65.TabIndex = 0;
			this.label65.Text = "Información Plantilla Actual";
			// 
			// grbPlantilla
			// 
			this.grbPlantilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grbPlantilla.Controls.Add(this.toolStrip13);
			this.grbPlantilla.Controls.Add(this.chkPedConcepto);
			this.grbPlantilla.Controls.Add(this.label72);
			this.grbPlantilla.Controls.Add(this.txtFrecuDias);
			this.grbPlantilla.Controls.Add(this.label71);
			this.grbPlantilla.Controls.Add(this.label70);
			this.grbPlantilla.Controls.Add(this.txtFrecuDescripcion);
			this.grbPlantilla.Controls.Add(this.txtFrecu);
			this.grbPlantilla.Controls.Add(this.dgvPlantilla);
			this.grbPlantilla.Controls.Add(this.txtPlantillaN);
			this.grbPlantilla.Controls.Add(this.label66);
			this.grbPlantilla.Controls.Add(this.txtPlantilla);
			this.grbPlantilla.Location = new System.Drawing.Point(8, 38);
			this.grbPlantilla.Name = "grbPlantilla";
			this.grbPlantilla.Size = new System.Drawing.Size(0, 0);
			this.grbPlantilla.TabIndex = 0;
			this.grbPlantilla.TabStop = false;
			// 
			// toolStrip13
			// 
			this.toolStrip13.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip13.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPagoCouta});
			this.toolStrip13.Location = new System.Drawing.Point(4, 11);
			this.toolStrip13.Name = "toolStrip13";
			this.toolStrip13.Size = new System.Drawing.Size(35, 25);
			this.toolStrip13.TabIndex = 296;
			this.toolStrip13.Text = "toolStrip13";
			// 
			// btnPagoCouta
			// 
			this.btnPagoCouta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnPagoCouta.Image = ((System.Drawing.Image)(resources.GetObject("btnPagoCouta.Image")));
			this.btnPagoCouta.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnPagoCouta.Name = "btnPagoCouta";
			this.btnPagoCouta.Size = new System.Drawing.Size(23, 22);
			this.btnPagoCouta.Text = "Pago de Couta";
			this.btnPagoCouta.Click += new System.EventHandler(this.btnPagoCouta_Click);
			// 
			// chkPedConcepto
			// 
			this.chkPedConcepto.Checked = false;
			this.chkPedConcepto.Location = new System.Drawing.Point(269, 46);
			this.chkPedConcepto.Name = "chkPedConcepto";
			this.chkPedConcepto.Size = new System.Drawing.Size(137, 17);
			this.chkPedConcepto.TabIndex = 295;
			this.chkPedConcepto.Texto = "Pedido por Concepto";
			this.chkPedConcepto.Visible = false;
			// 
			// label72
			// 
			this.label72.AutoSize = true;
			this.label72.Location = new System.Drawing.Point(785, 70);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(31, 13);
			this.label72.TabIndex = 293;
			this.label72.Text = "Dias:";
			this.label72.Visible = false;
			// 
			// txtFrecuDias
			// 
			this.txtFrecuDias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFrecuDias.FormatearNumero = false;
			this.txtFrecuDias.Location = new System.Drawing.Point(822, 66);
			this.txtFrecuDias.Longitud = 32767;
			this.txtFrecuDias.Multilinea = false;
			this.txtFrecuDias.Name = "txtFrecuDias";
			this.txtFrecuDias.Password = '\0';
			this.txtFrecuDias.ReadOnly = true;
			this.txtFrecuDias.Size = new System.Drawing.Size(0, 21);
			this.txtFrecuDias.TabIndex = 292;
			this.txtFrecuDias.Valor = "";
			this.txtFrecuDias.Visible = false;
			// 
			// label71
			// 
			this.label71.AutoSize = true;
			this.label71.Location = new System.Drawing.Point(188, 70);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(66, 13);
			this.label71.TabIndex = 291;
			this.label71.Text = "Descripcion:";
			this.label71.Visible = false;
			// 
			// label70
			// 
			this.label70.AutoSize = true;
			this.label70.Location = new System.Drawing.Point(0, 74);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(63, 13);
			this.label70.TabIndex = 290;
			this.label70.Text = "Frecuencia:";
			this.label70.Visible = false;
			// 
			// txtFrecuDescripcion
			// 
			this.txtFrecuDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFrecuDescripcion.FormatearNumero = false;
			this.txtFrecuDescripcion.Location = new System.Drawing.Point(260, 66);
			this.txtFrecuDescripcion.Longitud = 32767;
			this.txtFrecuDescripcion.Multilinea = false;
			this.txtFrecuDescripcion.Name = "txtFrecuDescripcion";
			this.txtFrecuDescripcion.Password = '\0';
			this.txtFrecuDescripcion.ReadOnly = true;
			this.txtFrecuDescripcion.Size = new System.Drawing.Size(0, 21);
			this.txtFrecuDescripcion.TabIndex = 289;
			this.txtFrecuDescripcion.Valor = "";
			this.txtFrecuDescripcion.Visible = false;
			// 
			// txtFrecu
			// 
			this.txtFrecu.FormatearNumero = false;
			this.txtFrecu.Location = new System.Drawing.Point(69, 66);
			this.txtFrecu.Longitud = 30;
			this.txtFrecu.Multilinea = false;
			this.txtFrecu.Name = "txtFrecu";
			this.txtFrecu.Password = '\0';
			this.txtFrecu.ReadOnly = true;
			this.txtFrecu.Size = new System.Drawing.Size(113, 21);
			this.txtFrecu.TabIndex = 288;
			this.txtFrecu.Valor = "";
			this.txtFrecu.Visible = false;
			// 
			// dgvPlantilla
			// 
			this.dgvPlantilla.AllowUserToAddRows = false;
			this.dgvPlantilla.AllowUserToDeleteRows = false;
			this.dgvPlantilla.AllowUserToResizeRows = false;
			this.dgvPlantilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvPlantilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvPlantilla.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvPlantilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPlantilla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlantilla,
            this.colCondicion,
            this.colCodigoArticulo,
            this.colNombreArticulo,
            this.colMontoArticulo});
			this.dgvPlantilla.Location = new System.Drawing.Point(81, 93);
			this.dgvPlantilla.MultiSelect = false;
			this.dgvPlantilla.Name = "dgvPlantilla";
			this.dgvPlantilla.RowHeadersVisible = false;
			this.dgvPlantilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvPlantilla.Size = new System.Drawing.Size(0, 0);
			this.dgvPlantilla.TabIndex = 287;
			// 
			// colPlantilla
			// 
			this.colPlantilla.HeaderText = "Plantilla";
			this.colPlantilla.Name = "colPlantilla";
			this.colPlantilla.Visible = false;
			// 
			// colCondicion
			// 
			this.colCondicion.HeaderText = "Condición";
			this.colCondicion.Name = "colCondicion";
			this.colCondicion.Visible = false;
			// 
			// colCodigoArticulo
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.colCodigoArticulo.DefaultCellStyle = dataGridViewCellStyle1;
			this.colCodigoArticulo.HeaderText = "Concepto";
			this.colCodigoArticulo.Name = "colCodigoArticulo";
			this.colCodigoArticulo.ReadOnly = true;
			// 
			// colNombreArticulo
			// 
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.colNombreArticulo.DefaultCellStyle = dataGridViewCellStyle2;
			this.colNombreArticulo.FillWeight = 137.0558F;
			this.colNombreArticulo.HeaderText = "Descripción";
			this.colNombreArticulo.Name = "colNombreArticulo";
			this.colNombreArticulo.ReadOnly = true;
			// 
			// colMontoArticulo
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle3.Format = "N2";
			this.colMontoArticulo.DefaultCellStyle = dataGridViewCellStyle3;
			this.colMontoArticulo.HeaderText = "Monto";
			this.colMontoArticulo.Name = "colMontoArticulo";
			this.colMontoArticulo.ReadOnly = true;
			// 
			// txtPlantillaN
			// 
			this.txtPlantillaN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPlantillaN.FormatearNumero = false;
			this.txtPlantillaN.Location = new System.Drawing.Point(388, 19);
			this.txtPlantillaN.Longitud = 32767;
			this.txtPlantillaN.Multilinea = false;
			this.txtPlantillaN.Name = "txtPlantillaN";
			this.txtPlantillaN.Password = '\0';
			this.txtPlantillaN.ReadOnly = true;
			this.txtPlantillaN.Size = new System.Drawing.Size(0, 21);
			this.txtPlantillaN.TabIndex = 285;
			this.txtPlantillaN.Valor = "";
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Location = new System.Drawing.Point(217, 23);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(46, 13);
			this.label66.TabIndex = 284;
			this.label66.Text = "Plantilla:";
			// 
			// txtPlantilla
			// 
			this.txtPlantilla.FormatearNumero = false;
			this.txtPlantilla.Location = new System.Drawing.Point(269, 19);
			this.txtPlantilla.Longitud = 30;
			this.txtPlantilla.Multilinea = false;
			this.txtPlantilla.Name = "txtPlantilla";
			this.txtPlantilla.Password = '\0';
			this.txtPlantilla.ReadOnly = true;
			this.txtPlantilla.Size = new System.Drawing.Size(113, 21);
			this.txtPlantilla.TabIndex = 283;
			this.txtPlantilla.Valor = "";
			this.txtPlantilla.Enter += new System.EventHandler(this.txtPlantilla_Enter);
			this.txtPlantilla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlantilla_KeyDown);
			this.txtPlantilla.Leave += new System.EventHandler(this.txtPlantilla_Leave);
			this.txtPlantilla.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPlantilla_MouseDoubleClick);
			// 
			// btnAdicional
			// 
			this.btnAdicional.Name = "btnAdicional";
			this.btnAdicional.Size = new System.Drawing.Size(23, 23);
			// 
			// btnAdicionalD
			// 
			this.btnAdicionalD.Name = "btnAdicionalD";
			this.btnAdicionalD.Size = new System.Drawing.Size(23, 23);
			// 
			// tpPago_Mutualidad
			// 
			this.tpPago_Mutualidad.Controls.Add(this.grbMutualidad);
			this.tpPago_Mutualidad.Controls.Add(this.grbTituloObligatorio);
			this.tpPago_Mutualidad.Controls.Add(this.grbPagoMut);
			this.tpPago_Mutualidad.Controls.Add(this.toolStrip12);
			this.tpPago_Mutualidad.Controls.Add(this.grbSesionCond);
			this.tpPago_Mutualidad.Location = new System.Drawing.Point(4, 22);
			this.tpPago_Mutualidad.Name = "tpPago_Mutualidad";
			this.tpPago_Mutualidad.Size = new System.Drawing.Size(997, 566);
			this.tpPago_Mutualidad.TabIndex = 13;
			this.tpPago_Mutualidad.Text = "Pago/Mutualidad";
			this.tpPago_Mutualidad.UseVisualStyleBackColor = true;
			// 
			// grbMutualidad
			// 
			this.grbMutualidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grbMutualidad.Controls.Add(this.label89);
			this.grbMutualidad.Controls.Add(this.txtCalculoMutualidadMontoRenunciar);
			this.grbMutualidad.Controls.Add(this.label88);
			this.grbMutualidad.Controls.Add(this.txtCalculoMutualidadMeses);
			this.grbMutualidad.Controls.Add(this.txtBeneChequeNombre);
			this.grbMutualidad.Controls.Add(this.txtBeneficiarioCheque);
			this.grbMutualidad.Controls.Add(this.lblBenef);
			this.grbMutualidad.Controls.Add(this.lblCheque);
			this.grbMutualidad.Controls.Add(this.txtCheque);
			this.grbMutualidad.Controls.Add(this.dtpFallecimiento);
			this.grbMutualidad.Controls.Add(this.lblDtpFallec);
			this.grbMutualidad.Controls.Add(this.rtbRazon);
			this.grbMutualidad.Controls.Add(this.label36);
			this.grbMutualidad.Controls.Add(this.label17);
			this.grbMutualidad.Controls.Add(this.label13);
			this.grbMutualidad.Controls.Add(this.chkRenuncia);
			this.grbMutualidad.Controls.Add(this.txtCalculoMutualidad);
			this.grbMutualidad.Location = new System.Drawing.Point(153, -3489);
			this.grbMutualidad.Name = "grbMutualidad";
			this.grbMutualidad.Size = new System.Drawing.Size(0, 216);
			this.grbMutualidad.TabIndex = 286;
			this.grbMutualidad.TabStop = false;
			this.grbMutualidad.Text = "Fondo de Mutualidad";
			// 
			// label89
			// 
			this.label89.AutoSize = true;
			this.label89.Location = new System.Drawing.Point(11, 91);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(101, 13);
			this.label89.TabIndex = 277;
			this.label89.Text = "Monto a Renunciar:";
			// 
			// txtCalculoMutualidadMontoRenunciar
			// 
			this.txtCalculoMutualidadMontoRenunciar.FormatearNumero = true;
			this.txtCalculoMutualidadMontoRenunciar.Location = new System.Drawing.Point(119, 87);
			this.txtCalculoMutualidadMontoRenunciar.Longitud = 32767;
			this.txtCalculoMutualidadMontoRenunciar.Multilinea = false;
			this.txtCalculoMutualidadMontoRenunciar.Name = "txtCalculoMutualidadMontoRenunciar";
			this.txtCalculoMutualidadMontoRenunciar.Password = '\0';
			this.txtCalculoMutualidadMontoRenunciar.ReadOnly = true;
			this.txtCalculoMutualidadMontoRenunciar.Size = new System.Drawing.Size(101, 21);
			this.txtCalculoMutualidadMontoRenunciar.TabIndex = 276;
			this.txtCalculoMutualidadMontoRenunciar.Valor = "";
			// 
			// label88
			// 
			this.label88.AutoSize = true;
			this.label88.Location = new System.Drawing.Point(32, 24);
			this.label88.Name = "label88";
			this.label88.Size = new System.Drawing.Size(81, 13);
			this.label88.TabIndex = 275;
			this.label88.Text = "Meses a Pagar:";
			// 
			// txtCalculoMutualidadMeses
			// 
			this.txtCalculoMutualidadMeses.FormatearNumero = true;
			this.txtCalculoMutualidadMeses.Location = new System.Drawing.Point(119, 20);
			this.txtCalculoMutualidadMeses.Longitud = 32767;
			this.txtCalculoMutualidadMeses.Multilinea = false;
			this.txtCalculoMutualidadMeses.Name = "txtCalculoMutualidadMeses";
			this.txtCalculoMutualidadMeses.Password = '\0';
			this.txtCalculoMutualidadMeses.ReadOnly = true;
			this.txtCalculoMutualidadMeses.Size = new System.Drawing.Size(101, 21);
			this.txtCalculoMutualidadMeses.TabIndex = 274;
			this.txtCalculoMutualidadMeses.Valor = "";
			// 
			// txtBeneChequeNombre
			// 
			this.txtBeneChequeNombre.FormatearNumero = false;
			this.txtBeneChequeNombre.Location = new System.Drawing.Point(226, 184);
			this.txtBeneChequeNombre.Longitud = 32767;
			this.txtBeneChequeNombre.Multilinea = false;
			this.txtBeneChequeNombre.Name = "txtBeneChequeNombre";
			this.txtBeneChequeNombre.Password = '\0';
			this.txtBeneChequeNombre.ReadOnly = true;
			this.txtBeneChequeNombre.Size = new System.Drawing.Size(236, 21);
			this.txtBeneChequeNombre.TabIndex = 273;
			this.txtBeneChequeNombre.Valor = "";
			this.txtBeneChequeNombre.Visible = false;
			// 
			// txtBeneficiarioCheque
			// 
			this.txtBeneficiarioCheque.FormatearNumero = false;
			this.txtBeneficiarioCheque.Location = new System.Drawing.Point(119, 184);
			this.txtBeneficiarioCheque.Longitud = 32767;
			this.txtBeneficiarioCheque.Multilinea = false;
			this.txtBeneficiarioCheque.Name = "txtBeneficiarioCheque";
			this.txtBeneficiarioCheque.Password = '\0';
			this.txtBeneficiarioCheque.ReadOnly = false;
			this.txtBeneficiarioCheque.Size = new System.Drawing.Size(101, 21);
			this.txtBeneficiarioCheque.TabIndex = 272;
			this.txtBeneficiarioCheque.Valor = "";
			this.txtBeneficiarioCheque.Visible = false;
			// 
			// lblBenef
			// 
			this.lblBenef.AutoSize = true;
			this.lblBenef.Location = new System.Drawing.Point(48, 189);
			this.lblBenef.Name = "lblBenef";
			this.lblBenef.Size = new System.Drawing.Size(65, 13);
			this.lblBenef.TabIndex = 270;
			this.lblBenef.Text = "Beneficiario:";
			this.lblBenef.Visible = false;
			// 
			// lblCheque
			// 
			this.lblCheque.AutoSize = true;
			this.lblCheque.Location = new System.Drawing.Point(65, 162);
			this.lblCheque.Name = "lblCheque";
			this.lblCheque.Size = new System.Drawing.Size(47, 13);
			this.lblCheque.TabIndex = 267;
			this.lblCheque.Text = "Cheque:";
			this.lblCheque.Visible = false;
			// 
			// txtCheque
			// 
			this.txtCheque.FormatearNumero = false;
			this.txtCheque.Location = new System.Drawing.Point(119, 157);
			this.txtCheque.Longitud = 32767;
			this.txtCheque.Multilinea = false;
			this.txtCheque.Name = "txtCheque";
			this.txtCheque.Password = '\0';
			this.txtCheque.ReadOnly = false;
			this.txtCheque.Size = new System.Drawing.Size(137, 21);
			this.txtCheque.TabIndex = 268;
			this.txtCheque.Valor = "";
			this.txtCheque.Visible = false;
			// 
			// dtpFallecimiento
			// 
			this.dtpFallecimiento.Checked = true;
			this.dtpFallecimiento.Location = new System.Drawing.Point(119, 129);
			this.dtpFallecimiento.mostrarCheckBox = false;
			this.dtpFallecimiento.mostrarUpDown = false;
			this.dtpFallecimiento.Name = "dtpFallecimiento";
			this.dtpFallecimiento.Size = new System.Drawing.Size(101, 22);
			this.dtpFallecimiento.TabIndex = 266;
			this.dtpFallecimiento.Value = new System.DateTime(2018, 11, 30, 9, 47, 52, 584);
			this.dtpFallecimiento.Visible = false;
			// 
			// lblDtpFallec
			// 
			this.lblDtpFallec.AutoSize = true;
			this.lblDtpFallec.Location = new System.Drawing.Point(42, 132);
			this.lblDtpFallec.Name = "lblDtpFallec";
			this.lblDtpFallec.Size = new System.Drawing.Size(71, 13);
			this.lblDtpFallec.TabIndex = 265;
			this.lblDtpFallec.Text = "Fallecimiento:";
			this.lblDtpFallec.Visible = false;
			// 
			// rtbRazon
			// 
			this.rtbRazon.BackColor = System.Drawing.Color.Gainsboro;
			this.rtbRazon.Location = new System.Drawing.Point(289, 44);
			this.rtbRazon.Longitud = 500;
			this.rtbRazon.Mayusculas = false;
			this.rtbRazon.Name = "rtbRazon";
			this.rtbRazon.ReadOnly = true;
			this.rtbRazon.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang3082{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22000}\\viewkind4\\uc1 \r\n\\par" +
    "d\\f0\\fs17\\par\r\n}\r\n";
			this.rtbRazon.Size = new System.Drawing.Size(343, 64);
			this.rtbRazon.TabIndex = 257;
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(33, 58);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(80, 13);
			this.label36.TabIndex = 256;
			this.label36.Text = "Monto a Pagar:";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(304, 44);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(0, 13);
			this.label17.TabIndex = 255;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(242, 49);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(41, 13);
			this.label13.TabIndex = 72;
			this.label13.Text = "Razón:";
			// 
			// chkRenuncia
			// 
			this.chkRenuncia.Checked = false;
			this.chkRenuncia.Location = new System.Drawing.Point(289, 20);
			this.chkRenuncia.Name = "chkRenuncia";
			this.chkRenuncia.Size = new System.Drawing.Size(165, 17);
			this.chkRenuncia.TabIndex = 1;
			this.chkRenuncia.Texto = "Renuncia al Ajuste del Fondo";
			this.chkRenuncia.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkRenuncia_MouseClick);
			// 
			// txtCalculoMutualidad
			// 
			this.txtCalculoMutualidad.FormatearNumero = true;
			this.txtCalculoMutualidad.Location = new System.Drawing.Point(119, 54);
			this.txtCalculoMutualidad.Longitud = 32767;
			this.txtCalculoMutualidad.Multilinea = false;
			this.txtCalculoMutualidad.Name = "txtCalculoMutualidad";
			this.txtCalculoMutualidad.Password = '\0';
			this.txtCalculoMutualidad.ReadOnly = true;
			this.txtCalculoMutualidad.Size = new System.Drawing.Size(101, 21);
			this.txtCalculoMutualidad.TabIndex = 0;
			this.txtCalculoMutualidad.Valor = "";
			// 
			// grbTituloObligatorio
			// 
			this.grbTituloObligatorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grbTituloObligatorio.Controls.Add(this.dtpFechaTitulo);
			this.grbTituloObligatorio.Controls.Add(this.label64);
			this.grbTituloObligatorio.Controls.Add(this.label63);
			this.grbTituloObligatorio.Controls.Add(this.txtCalculoTitulo);
			this.grbTituloObligatorio.Controls.Add(this.rbNoTitulo);
			this.grbTituloObligatorio.Controls.Add(this.rbSiTitulo);
			this.grbTituloObligatorio.Location = new System.Drawing.Point(594, -7407);
			this.grbTituloObligatorio.Name = "grbTituloObligatorio";
			this.grbTituloObligatorio.Size = new System.Drawing.Size(0, 95);
			this.grbTituloObligatorio.TabIndex = 285;
			this.grbTituloObligatorio.TabStop = false;
			this.grbTituloObligatorio.Text = "Presenta Título";
			// 
			// dtpFechaTitulo
			// 
			this.dtpFechaTitulo.Checked = true;
			this.dtpFechaTitulo.Enabled = false;
			this.dtpFechaTitulo.Location = new System.Drawing.Point(229, 57);
			this.dtpFechaTitulo.mostrarCheckBox = false;
			this.dtpFechaTitulo.mostrarUpDown = false;
			this.dtpFechaTitulo.Name = "dtpFechaTitulo";
			this.dtpFechaTitulo.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaTitulo.TabIndex = 266;
			this.dtpFechaTitulo.Value = new System.DateTime(2018, 11, 30, 9, 47, 52, 584);
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(118, 61);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(105, 13);
			this.label64.TabIndex = 265;
			this.label64.Text = "Fecha Presentación:";
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.Location = new System.Drawing.Point(143, 34);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(80, 13);
			this.label63.TabIndex = 258;
			this.label63.Text = "Monto a Pagar:";
			// 
			// txtCalculoTitulo
			// 
			this.txtCalculoTitulo.FormatearNumero = true;
			this.txtCalculoTitulo.Location = new System.Drawing.Point(229, 30);
			this.txtCalculoTitulo.Longitud = 32767;
			this.txtCalculoTitulo.Multilinea = false;
			this.txtCalculoTitulo.Name = "txtCalculoTitulo";
			this.txtCalculoTitulo.Password = '\0';
			this.txtCalculoTitulo.ReadOnly = true;
			this.txtCalculoTitulo.Size = new System.Drawing.Size(101, 21);
			this.txtCalculoTitulo.TabIndex = 257;
			this.txtCalculoTitulo.Valor = "";
			// 
			// rbNoTitulo
			// 
			this.rbNoTitulo.Checked = false;
			this.rbNoTitulo.Location = new System.Drawing.Point(84, 31);
			this.rbNoTitulo.Name = "rbNoTitulo";
			this.rbNoTitulo.Size = new System.Drawing.Size(40, 18);
			this.rbNoTitulo.TabIndex = 1;
			this.rbNoTitulo.Texto = "No";
			// 
			// rbSiTitulo
			// 
			this.rbSiTitulo.Checked = true;
			this.rbSiTitulo.Location = new System.Drawing.Point(29, 31);
			this.rbSiTitulo.Name = "rbSiTitulo";
			this.rbSiTitulo.Size = new System.Drawing.Size(40, 18);
			this.rbSiTitulo.TabIndex = 0;
			this.rbSiTitulo.Texto = "Si";
			// 
			// grbPagoMut
			// 
			this.grbPagoMut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grbPagoMut.Controls.Add(this.mtbTarjeta);
			this.grbPagoMut.Controls.Add(this.dtpTarjetaVencimiento);
			this.grbPagoMut.Controls.Add(this.mtbVenciminetoTerjeta);
			this.grbPagoMut.Controls.Add(this.txtDescEntidadFinanciera);
			this.grbPagoMut.Controls.Add(this.lblEntidadFinan);
			this.grbPagoMut.Controls.Add(this.txtEntidadFinanciera);
			this.grbPagoMut.Controls.Add(this.chkMorosidad);
			this.grbPagoMut.Controls.Add(this.lblFormaPago);
			this.grbPagoMut.Controls.Add(this.cmbFormaPago);
			this.grbPagoMut.Controls.Add(this.label37);
			this.grbPagoMut.Controls.Add(this.txtTarjeta);
			this.grbPagoMut.Controls.Add(this.label38);
			this.grbPagoMut.Controls.Add(this.label12);
			this.grbPagoMut.Controls.Add(this.cmbTipoTarjeta);
			this.grbPagoMut.Controls.Add(this.txtDescCobrador);
			this.grbPagoMut.Controls.Add(this.lblCobrador);
			this.grbPagoMut.Controls.Add(this.txtCobrador);
			this.grbPagoMut.Location = new System.Drawing.Point(21, 92);
			this.grbPagoMut.Name = "grbPagoMut";
			this.grbPagoMut.Size = new System.Drawing.Size(0, 132);
			this.grbPagoMut.TabIndex = 283;
			this.grbPagoMut.TabStop = false;
			// 
			// mtbTarjeta
			// 
			this.mtbTarjeta.Location = new System.Drawing.Point(107, 53);
			this.mtbTarjeta.Mask = "0000-0000-0000";
			this.mtbTarjeta.Name = "mtbTarjeta";
			this.mtbTarjeta.Size = new System.Drawing.Size(136, 20);
			this.mtbTarjeta.TabIndex = 287;
			this.mtbTarjeta.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtbTarjeta_KeyUp);
			// 
			// dtpTarjetaVencimiento
			// 
			this.dtpTarjetaVencimiento.Checked = false;
			this.dtpTarjetaVencimiento.Location = new System.Drawing.Point(185, 92);
			this.dtpTarjetaVencimiento.mostrarCheckBox = true;
			this.dtpTarjetaVencimiento.mostrarUpDown = true;
			this.dtpTarjetaVencimiento.Name = "dtpTarjetaVencimiento";
			this.dtpTarjetaVencimiento.Size = new System.Drawing.Size(87, 22);
			this.dtpTarjetaVencimiento.TabIndex = 285;
			this.dtpTarjetaVencimiento.Value = new System.DateTime(2019, 6, 21, 9, 59, 10, 17);
			this.dtpTarjetaVencimiento.Visible = false;
			// 
			// mtbVenciminetoTerjeta
			// 
			this.mtbVenciminetoTerjeta.Location = new System.Drawing.Point(107, 92);
			this.mtbVenciminetoTerjeta.Mask = "00/0000";
			this.mtbVenciminetoTerjeta.Name = "mtbVenciminetoTerjeta";
			this.mtbVenciminetoTerjeta.Size = new System.Drawing.Size(53, 20);
			this.mtbVenciminetoTerjeta.TabIndex = 284;
			this.mtbVenciminetoTerjeta.ValidatingType = typeof(System.DateTime);
			this.mtbVenciminetoTerjeta.Leave += new System.EventHandler(this.mtbVenciminetoTerjeta_Leave);
			// 
			// txtDescEntidadFinanciera
			// 
			this.txtDescEntidadFinanciera.FormatearNumero = false;
			this.txtDescEntidadFinanciera.Location = new System.Drawing.Point(649, 25);
			this.txtDescEntidadFinanciera.Longitud = 32767;
			this.txtDescEntidadFinanciera.Multilinea = false;
			this.txtDescEntidadFinanciera.Name = "txtDescEntidadFinanciera";
			this.txtDescEntidadFinanciera.Password = '\0';
			this.txtDescEntidadFinanciera.ReadOnly = true;
			this.txtDescEntidadFinanciera.Size = new System.Drawing.Size(179, 21);
			this.txtDescEntidadFinanciera.TabIndex = 282;
			this.txtDescEntidadFinanciera.Valor = "";
			// 
			// lblEntidadFinan
			// 
			this.lblEntidadFinan.AutoSize = true;
			this.lblEntidadFinan.Location = new System.Drawing.Point(480, 30);
			this.lblEntidadFinan.Name = "lblEntidadFinan";
			this.lblEntidadFinan.Size = new System.Drawing.Size(98, 13);
			this.lblEntidadFinan.TabIndex = 281;
			this.lblEntidadFinan.Text = "Entidad Financiera:";
			// 
			// txtEntidadFinanciera
			// 
			this.txtEntidadFinanciera.FormatearNumero = false;
			this.txtEntidadFinanciera.Location = new System.Drawing.Point(584, 26);
			this.txtEntidadFinanciera.Longitud = 4;
			this.txtEntidadFinanciera.Multilinea = false;
			this.txtEntidadFinanciera.Name = "txtEntidadFinanciera";
			this.txtEntidadFinanciera.Password = '\0';
			this.txtEntidadFinanciera.ReadOnly = false;
			this.txtEntidadFinanciera.Size = new System.Drawing.Size(59, 21);
			this.txtEntidadFinanciera.TabIndex = 280;
			this.txtEntidadFinanciera.Valor = "";
			this.txtEntidadFinanciera.Enter += new System.EventHandler(this.txtEntidadFinanciera_Enter);
			this.txtEntidadFinanciera.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEntidadFinanciera_KeyDown);
			this.txtEntidadFinanciera.Leave += new System.EventHandler(this.txtEntidadFinanciera_Leave);
			this.txtEntidadFinanciera.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtEntidadFinanciera_MouseDoubleClick);
			// 
			// chkMorosidad
			// 
			this.chkMorosidad.Checked = false;
			this.chkMorosidad.Enabled = false;
			this.chkMorosidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkMorosidad.Location = new System.Drawing.Point(330, 18);
			this.chkMorosidad.Name = "chkMorosidad";
			this.chkMorosidad.Size = new System.Drawing.Size(87, 17);
			this.chkMorosidad.TabIndex = 279;
			this.chkMorosidad.Texto = "Morosidad";
			// 
			// lblFormaPago
			// 
			this.lblFormaPago.AutoSize = true;
			this.lblFormaPago.Location = new System.Drawing.Point(19, 18);
			this.lblFormaPago.Name = "lblFormaPago";
			this.lblFormaPago.Size = new System.Drawing.Size(82, 13);
			this.lblFormaPago.TabIndex = 276;
			this.lblFormaPago.Text = "Forma de Pago:";
			// 
			// cmbFormaPago
			// 
			this.cmbFormaPago.Habilitar = true;
			this.cmbFormaPago.Index = -1;
			this.cmbFormaPago.Location = new System.Drawing.Point(107, 16);
			this.cmbFormaPago.Name = "cmbFormaPago";
			this.cmbFormaPago.Size = new System.Drawing.Size(136, 22);
			this.cmbFormaPago.TabIndex = 275;
			this.cmbFormaPago.Texto = "";
			this.cmbFormaPago.Valor = "";
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(58, 56);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(43, 13);
			this.label37.TabIndex = 252;
			this.label37.Text = "Tarjeta:";
			// 
			// txtTarjeta
			// 
			this.txtTarjeta.FormatearNumero = false;
			this.txtTarjeta.Location = new System.Drawing.Point(400, 94);
			this.txtTarjeta.Longitud = 50;
			this.txtTarjeta.Multilinea = false;
			this.txtTarjeta.Name = "txtTarjeta";
			this.txtTarjeta.Password = '\0';
			this.txtTarjeta.ReadOnly = false;
			this.txtTarjeta.Size = new System.Drawing.Size(136, 22);
			this.txtTarjeta.TabIndex = 12;
			this.txtTarjeta.Valor = "";
			this.txtTarjeta.Visible = false;
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(33, 94);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(68, 13);
			this.label38.TabIndex = 254;
			this.label38.Text = "Vencimiento:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(257, 57);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(67, 13);
			this.label12.TabIndex = 257;
			this.label12.Text = "Tipo Tarjeta:";
			// 
			// cmbTipoTarjeta
			// 
			this.cmbTipoTarjeta.Habilitar = true;
			this.cmbTipoTarjeta.Index = -1;
			this.cmbTipoTarjeta.Location = new System.Drawing.Point(330, 52);
			this.cmbTipoTarjeta.Name = "cmbTipoTarjeta";
			this.cmbTipoTarjeta.Size = new System.Drawing.Size(94, 22);
			this.cmbTipoTarjeta.TabIndex = 13;
			this.cmbTipoTarjeta.Texto = "";
			this.cmbTipoTarjeta.Valor = "";
			// 
			// txtDescCobrador
			// 
			this.txtDescCobrador.FormatearNumero = false;
			this.txtDescCobrador.Location = new System.Drawing.Point(649, 52);
			this.txtDescCobrador.Longitud = 32767;
			this.txtDescCobrador.Multilinea = false;
			this.txtDescCobrador.Name = "txtDescCobrador";
			this.txtDescCobrador.Password = '\0';
			this.txtDescCobrador.ReadOnly = true;
			this.txtDescCobrador.Size = new System.Drawing.Size(179, 21);
			this.txtDescCobrador.TabIndex = 264;
			this.txtDescCobrador.Valor = "";
			// 
			// lblCobrador
			// 
			this.lblCobrador.AutoSize = true;
			this.lblCobrador.Location = new System.Drawing.Point(525, 57);
			this.lblCobrador.Name = "lblCobrador";
			this.lblCobrador.Size = new System.Drawing.Size(53, 13);
			this.lblCobrador.TabIndex = 240;
			this.lblCobrador.Text = "Cobrador:";
			// 
			// txtCobrador
			// 
			this.txtCobrador.FormatearNumero = false;
			this.txtCobrador.Location = new System.Drawing.Point(584, 53);
			this.txtCobrador.Longitud = 4;
			this.txtCobrador.Multilinea = false;
			this.txtCobrador.Name = "txtCobrador";
			this.txtCobrador.Password = '\0';
			this.txtCobrador.ReadOnly = false;
			this.txtCobrador.Size = new System.Drawing.Size(59, 21);
			this.txtCobrador.TabIndex = 22;
			this.txtCobrador.Valor = "";
			this.txtCobrador.Enter += new System.EventHandler(this.txtCobrador_Enter);
			this.txtCobrador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCobrador_KeyDown);
			this.txtCobrador.Leave += new System.EventHandler(this.txtCobrador_Leave);
			this.txtCobrador.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCobrador_MouseDoubleClick);
			// 
			// toolStrip12
			// 
			this.toolStrip12.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip12.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRPTMutualidad});
			this.toolStrip12.Location = new System.Drawing.Point(1, 24);
			this.toolStrip12.Name = "toolStrip12";
			this.toolStrip12.Size = new System.Drawing.Size(35, 25);
			this.toolStrip12.TabIndex = 282;
			this.toolStrip12.Text = "toolStrip12";
			// 
			// btnRPTMutualidad
			// 
			this.btnRPTMutualidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnRPTMutualidad.Image = ((System.Drawing.Image)(resources.GetObject("btnRPTMutualidad.Image")));
			this.btnRPTMutualidad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRPTMutualidad.Name = "btnRPTMutualidad";
			this.btnRPTMutualidad.Size = new System.Drawing.Size(23, 22);
			this.btnRPTMutualidad.Text = "Reporte Mutualidad";
			this.btnRPTMutualidad.Click += new System.EventHandler(this.btnRPTMutualidad_Click);
			// 
			// grbSesionCond
			// 
			this.grbSesionCond.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grbSesionCond.Controls.Add(this.dtpFechaSesionCond);
			this.grbSesionCond.Controls.Add(this.label61);
			this.grbSesionCond.Controls.Add(this.label62);
			this.grbSesionCond.Controls.Add(this.txtSesionCond);
			this.grbSesionCond.Enabled = false;
			this.grbSesionCond.Location = new System.Drawing.Point(465, -7656);
			this.grbSesionCond.Name = "grbSesionCond";
			this.grbSesionCond.Size = new System.Drawing.Size(0, 66);
			this.grbSesionCond.TabIndex = 280;
			this.grbSesionCond.TabStop = false;
			this.grbSesionCond.Text = "Ultima Sesión Junta";
			this.grbSesionCond.Visible = false;
			// 
			// dtpFechaSesionCond
			// 
			this.dtpFechaSesionCond.Checked = true;
			this.dtpFechaSesionCond.Location = new System.Drawing.Point(282, 24);
			this.dtpFechaSesionCond.mostrarCheckBox = false;
			this.dtpFechaSesionCond.mostrarUpDown = false;
			this.dtpFechaSesionCond.Name = "dtpFechaSesionCond";
			this.dtpFechaSesionCond.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaSesionCond.TabIndex = 264;
			this.dtpFechaSesionCond.Value = new System.DateTime(2018, 11, 30, 9, 47, 52, 584);
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.Location = new System.Drawing.Point(236, 29);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(40, 13);
			this.label61.TabIndex = 259;
			this.label61.Text = "Fecha:";
			// 
			// label62
			// 
			this.label62.AutoSize = true;
			this.label62.Location = new System.Drawing.Point(6, 29);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(71, 13);
			this.label62.TabIndex = 16;
			this.label62.Text = "Sesión Junta:";
			// 
			// txtSesionCond
			// 
			this.txtSesionCond.FormatearNumero = false;
			this.txtSesionCond.Location = new System.Drawing.Point(82, 24);
			this.txtSesionCond.Longitud = 32767;
			this.txtSesionCond.Multilinea = false;
			this.txtSesionCond.Name = "txtSesionCond";
			this.txtSesionCond.Password = '\0';
			this.txtSesionCond.ReadOnly = false;
			this.txtSesionCond.Size = new System.Drawing.Size(137, 21);
			this.txtSesionCond.TabIndex = 17;
			this.txtSesionCond.Valor = "";
			// 
			// panel17
			// 
			this.panel17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel17.BackColor = System.Drawing.Color.DarkGray;
			this.panel17.Controls.Add(this.label73);
			this.panel17.Location = new System.Drawing.Point(7, 117);
			this.panel17.Name = "panel17";
			this.panel17.Size = new System.Drawing.Size(991, 21);
			this.panel17.TabIndex = 42;
			// 
			// label73
			// 
			this.label73.AutoSize = true;
			this.label73.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label73.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label73.Location = new System.Drawing.Point(3, 4);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(191, 14);
			this.label73.TabIndex = 0;
			this.label73.Text = "Forma de Pago y Pago Mutualidad";
			// 
			// tpPeritajes
			// 
			this.tpPeritajes.Controls.Add(this.panel4);
			this.tpPeritajes.Controls.Add(this.panel18);
			this.tpPeritajes.Location = new System.Drawing.Point(4, 22);
			this.tpPeritajes.Name = "tpPeritajes";
			this.tpPeritajes.Padding = new System.Windows.Forms.Padding(3);
			this.tpPeritajes.Size = new System.Drawing.Size(997, 566);
			this.tpPeritajes.TabIndex = 14;
			this.tpPeritajes.Text = "Peritajes";
			this.tpPeritajes.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel4.Controls.Add(this.groupBox16);
			this.panel4.Controls.Add(this.txtCobradorPeritaje);
			this.panel4.Controls.Add(this.label81);
			this.panel4.Controls.Add(this.txtCobradorPeritajeNombre);
			this.panel4.Controls.Add(this.chkCursoPeritaje);
			this.panel4.Controls.Add(this.label74);
			this.panel4.Controls.Add(this.rtbObservaciones);
			this.panel4.Controls.Add(this.dtpSesionPerdidaPeritaje);
			this.panel4.Controls.Add(this.label75);
			this.panel4.Controls.Add(this.txtSesionPerdidaPeritaje);
			this.panel4.Controls.Add(this.label76);
			this.panel4.Controls.Add(this.dtpRenovacion);
			this.panel4.Controls.Add(this.label77);
			this.panel4.Controls.Add(this.txtSesionRenov);
			this.panel4.Controls.Add(this.label78);
			this.panel4.Controls.Add(this.dtpSesionAprobPeritaje);
			this.panel4.Controls.Add(this.label79);
			this.panel4.Controls.Add(this.txtSesionAprobPeritaje);
			this.panel4.Controls.Add(this.label80);
			this.panel4.Controls.Add(this.txtInstitucion);
			this.panel4.Controls.Add(this.label82);
			this.panel4.Controls.Add(this.txtNombreInstitucion);
			this.panel4.Controls.Add(this.label83);
			this.panel4.Controls.Add(this.cmbTipoPerito);
			this.panel4.Location = new System.Drawing.Point(149, 77);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(154, 69);
			this.panel4.TabIndex = 40;
			// 
			// groupBox16
			// 
			this.groupBox16.Controls.Add(this.groupBox18);
			this.groupBox16.Controls.Add(this.groupBox19);
			this.groupBox16.Location = new System.Drawing.Point(272, 302);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new System.Drawing.Size(286, 100);
			this.groupBox16.TabIndex = 308;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "Estado Canon";
			// 
			// groupBox18
			// 
			this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox18.Controls.Add(this.rbPerProcNO);
			this.groupBox18.Controls.Add(this.rbPerProcSI);
			this.groupBox18.Location = new System.Drawing.Point(26, 17);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new System.Drawing.Size(113, 64);
			this.groupBox18.TabIndex = 284;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Procesado";
			// 
			// rbPerProcNO
			// 
			this.rbPerProcNO.Checked = true;
			this.rbPerProcNO.Enabled = false;
			this.rbPerProcNO.Location = new System.Drawing.Point(63, 27);
			this.rbPerProcNO.Name = "rbPerProcNO";
			this.rbPerProcNO.Size = new System.Drawing.Size(40, 18);
			this.rbPerProcNO.TabIndex = 0;
			this.rbPerProcNO.Texto = "No ";
			// 
			// rbPerProcSI
			// 
			this.rbPerProcSI.Checked = false;
			this.rbPerProcSI.Enabled = false;
			this.rbPerProcSI.Location = new System.Drawing.Point(15, 27);
			this.rbPerProcSI.Name = "rbPerProcSI";
			this.rbPerProcSI.Size = new System.Drawing.Size(42, 18);
			this.rbPerProcSI.TabIndex = 1;
			this.rbPerProcSI.Texto = "Si";
			// 
			// groupBox19
			// 
			this.groupBox19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox19.Controls.Add(this.rbPerFacNO);
			this.groupBox19.Controls.Add(this.rbPerFacSI);
			this.groupBox19.Location = new System.Drawing.Point(145, 17);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Size = new System.Drawing.Size(114, 64);
			this.groupBox19.TabIndex = 283;
			this.groupBox19.TabStop = false;
			this.groupBox19.Text = "Facturado";
			// 
			// rbPerFacNO
			// 
			this.rbPerFacNO.Checked = true;
			this.rbPerFacNO.Enabled = false;
			this.rbPerFacNO.Location = new System.Drawing.Point(63, 27);
			this.rbPerFacNO.Name = "rbPerFacNO";
			this.rbPerFacNO.Size = new System.Drawing.Size(40, 18);
			this.rbPerFacNO.TabIndex = 0;
			this.rbPerFacNO.Texto = "No ";
			// 
			// rbPerFacSI
			// 
			this.rbPerFacSI.Checked = false;
			this.rbPerFacSI.Enabled = false;
			this.rbPerFacSI.Location = new System.Drawing.Point(15, 27);
			this.rbPerFacSI.Name = "rbPerFacSI";
			this.rbPerFacSI.Size = new System.Drawing.Size(42, 18);
			this.rbPerFacSI.TabIndex = 1;
			this.rbPerFacSI.Texto = "Si";
			// 
			// txtCobradorPeritaje
			// 
			this.txtCobradorPeritaje.FormatearNumero = false;
			this.txtCobradorPeritaje.Location = new System.Drawing.Point(214, 186);
			this.txtCobradorPeritaje.Longitud = 30;
			this.txtCobradorPeritaje.Multilinea = false;
			this.txtCobradorPeritaje.Name = "txtCobradorPeritaje";
			this.txtCobradorPeritaje.Password = '\0';
			this.txtCobradorPeritaje.ReadOnly = true;
			this.txtCobradorPeritaje.Size = new System.Drawing.Size(112, 21);
			this.txtCobradorPeritaje.TabIndex = 307;
			this.txtCobradorPeritaje.Valor = "";
			// 
			// label81
			// 
			this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label81.Location = new System.Drawing.Point(146, 191);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(62, 13);
			this.label81.TabIndex = 306;
			this.label81.Text = "Cobrador:";
			// 
			// txtCobradorPeritajeNombre
			// 
			this.txtCobradorPeritajeNombre.FormatearNumero = false;
			this.txtCobradorPeritajeNombre.Location = new System.Drawing.Point(332, 186);
			this.txtCobradorPeritajeNombre.Longitud = 30;
			this.txtCobradorPeritajeNombre.Multilinea = false;
			this.txtCobradorPeritajeNombre.Name = "txtCobradorPeritajeNombre";
			this.txtCobradorPeritajeNombre.Password = '\0';
			this.txtCobradorPeritajeNombre.ReadOnly = true;
			this.txtCobradorPeritajeNombre.Size = new System.Drawing.Size(300, 21);
			this.txtCobradorPeritajeNombre.TabIndex = 305;
			this.txtCobradorPeritajeNombre.Valor = "";
			// 
			// chkCursoPeritaje
			// 
			this.chkCursoPeritaje.Checked = false;
			this.chkCursoPeritaje.Location = new System.Drawing.Point(214, 27);
			this.chkCursoPeritaje.Name = "chkCursoPeritaje";
			this.chkCursoPeritaje.Size = new System.Drawing.Size(151, 17);
			this.chkCursoPeritaje.TabIndex = 304;
			this.chkCursoPeritaje.Texto = "Curso Avalúos Peritaje";
			// 
			// label74
			// 
			this.label74.Location = new System.Drawing.Point(127, 217);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(81, 13);
			this.label74.TabIndex = 303;
			this.label74.Text = "Observaciones:";
			// 
			// rtbObservaciones
			// 
			this.rtbObservaciones.Location = new System.Drawing.Point(214, 217);
			this.rtbObservaciones.Longitud = 2147483647;
			this.rtbObservaciones.Mayusculas = false;
			this.rtbObservaciones.Name = "rtbObservaciones";
			this.rtbObservaciones.ReadOnly = true;
			this.rtbObservaciones.RTF = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 " +
    "Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.22000}\\viewkind4\\uc1 \r\n\\par" +
    "d\\f0\\fs17\\par\r\n}\r\n";
			this.rtbObservaciones.Size = new System.Drawing.Size(418, 66);
			this.rtbObservaciones.TabIndex = 302;
			// 
			// dtpSesionPerdidaPeritaje
			// 
			this.dtpSesionPerdidaPeritaje.Checked = false;
			this.dtpSesionPerdidaPeritaje.Enabled = false;
			this.dtpSesionPerdidaPeritaje.Location = new System.Drawing.Point(448, 158);
			this.dtpSesionPerdidaPeritaje.mostrarCheckBox = true;
			this.dtpSesionPerdidaPeritaje.mostrarUpDown = false;
			this.dtpSesionPerdidaPeritaje.Name = "dtpSesionPerdidaPeritaje";
			this.dtpSesionPerdidaPeritaje.Size = new System.Drawing.Size(96, 22);
			this.dtpSesionPerdidaPeritaje.TabIndex = 301;
			this.dtpSesionPerdidaPeritaje.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
			// 
			// label75
			// 
			this.label75.Location = new System.Drawing.Point(363, 162);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(79, 13);
			this.label75.TabIndex = 300;
			this.label75.Text = "Fecha Pérdida:";
			// 
			// txtSesionPerdidaPeritaje
			// 
			this.txtSesionPerdidaPeritaje.FormatearNumero = false;
			this.txtSesionPerdidaPeritaje.Location = new System.Drawing.Point(214, 159);
			this.txtSesionPerdidaPeritaje.Longitud = 30;
			this.txtSesionPerdidaPeritaje.Multilinea = false;
			this.txtSesionPerdidaPeritaje.Name = "txtSesionPerdidaPeritaje";
			this.txtSesionPerdidaPeritaje.Password = '\0';
			this.txtSesionPerdidaPeritaje.ReadOnly = true;
			this.txtSesionPerdidaPeritaje.Size = new System.Drawing.Size(112, 21);
			this.txtSesionPerdidaPeritaje.TabIndex = 299;
			this.txtSesionPerdidaPeritaje.Valor = "";
			// 
			// label76
			// 
			this.label76.Location = new System.Drawing.Point(127, 162);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(81, 13);
			this.label76.TabIndex = 298;
			this.label76.Text = "Sesión Pérdida:";
			// 
			// dtpRenovacion
			// 
			this.dtpRenovacion.Checked = false;
			this.dtpRenovacion.Enabled = false;
			this.dtpRenovacion.Location = new System.Drawing.Point(448, 131);
			this.dtpRenovacion.mostrarCheckBox = true;
			this.dtpRenovacion.mostrarUpDown = false;
			this.dtpRenovacion.Name = "dtpRenovacion";
			this.dtpRenovacion.Size = new System.Drawing.Size(96, 22);
			this.dtpRenovacion.TabIndex = 297;
			this.dtpRenovacion.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
			// 
			// label77
			// 
			this.label77.Location = new System.Drawing.Point(341, 135);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(101, 13);
			this.label77.TabIndex = 296;
			this.label77.Text = "Fecha Renovación:";
			// 
			// txtSesionRenov
			// 
			this.txtSesionRenov.FormatearNumero = false;
			this.txtSesionRenov.Location = new System.Drawing.Point(214, 132);
			this.txtSesionRenov.Longitud = 30;
			this.txtSesionRenov.Multilinea = false;
			this.txtSesionRenov.Name = "txtSesionRenov";
			this.txtSesionRenov.Password = '\0';
			this.txtSesionRenov.ReadOnly = true;
			this.txtSesionRenov.Size = new System.Drawing.Size(112, 21);
			this.txtSesionRenov.TabIndex = 295;
			this.txtSesionRenov.Valor = "";
			// 
			// label78
			// 
			this.label78.Location = new System.Drawing.Point(105, 135);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(103, 13);
			this.label78.TabIndex = 294;
			this.label78.Text = "Sesión Renovación:";
			// 
			// dtpSesionAprobPeritaje
			// 
			this.dtpSesionAprobPeritaje.Checked = true;
			this.dtpSesionAprobPeritaje.Enabled = false;
			this.dtpSesionAprobPeritaje.Location = new System.Drawing.Point(448, 104);
			this.dtpSesionAprobPeritaje.mostrarCheckBox = false;
			this.dtpSesionAprobPeritaje.mostrarUpDown = false;
			this.dtpSesionAprobPeritaje.Name = "dtpSesionAprobPeritaje";
			this.dtpSesionAprobPeritaje.Size = new System.Drawing.Size(96, 22);
			this.dtpSesionAprobPeritaje.TabIndex = 293;
			this.dtpSesionAprobPeritaje.Value = new System.DateTime(2019, 1, 14, 17, 12, 51, 909);
			// 
			// label79
			// 
			this.label79.Location = new System.Drawing.Point(345, 108);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(97, 13);
			this.label79.TabIndex = 292;
			this.label79.Text = "Fecha Aprobación:";
			// 
			// txtSesionAprobPeritaje
			// 
			this.txtSesionAprobPeritaje.FormatearNumero = false;
			this.txtSesionAprobPeritaje.Location = new System.Drawing.Point(214, 105);
			this.txtSesionAprobPeritaje.Longitud = 30;
			this.txtSesionAprobPeritaje.Multilinea = false;
			this.txtSesionAprobPeritaje.Name = "txtSesionAprobPeritaje";
			this.txtSesionAprobPeritaje.Password = '\0';
			this.txtSesionAprobPeritaje.ReadOnly = true;
			this.txtSesionAprobPeritaje.Size = new System.Drawing.Size(112, 21);
			this.txtSesionAprobPeritaje.TabIndex = 291;
			this.txtSesionAprobPeritaje.Valor = "";
			// 
			// label80
			// 
			this.label80.Location = new System.Drawing.Point(109, 108);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(99, 13);
			this.label80.TabIndex = 290;
			this.label80.Text = "Sesión Aprobación:";
			// 
			// txtInstitucion
			// 
			this.txtInstitucion.FormatearNumero = false;
			this.txtInstitucion.Location = new System.Drawing.Point(214, 50);
			this.txtInstitucion.Longitud = 30;
			this.txtInstitucion.Multilinea = false;
			this.txtInstitucion.Name = "txtInstitucion";
			this.txtInstitucion.Password = '\0';
			this.txtInstitucion.ReadOnly = true;
			this.txtInstitucion.Size = new System.Drawing.Size(112, 21);
			this.txtInstitucion.TabIndex = 289;
			this.txtInstitucion.Valor = "";
			// 
			// label82
			// 
			this.label82.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label82.Location = new System.Drawing.Point(138, 54);
			this.label82.Name = "label82";
			this.label82.Size = new System.Drawing.Size(70, 13);
			this.label82.TabIndex = 288;
			this.label82.Text = "Institución:";
			// 
			// txtNombreInstitucion
			// 
			this.txtNombreInstitucion.FormatearNumero = false;
			this.txtNombreInstitucion.Location = new System.Drawing.Point(328, 50);
			this.txtNombreInstitucion.Longitud = 30;
			this.txtNombreInstitucion.Multilinea = false;
			this.txtNombreInstitucion.Name = "txtNombreInstitucion";
			this.txtNombreInstitucion.Password = '\0';
			this.txtNombreInstitucion.ReadOnly = true;
			this.txtNombreInstitucion.Size = new System.Drawing.Size(304, 21);
			this.txtNombreInstitucion.TabIndex = 287;
			this.txtNombreInstitucion.Valor = "";
			// 
			// label83
			// 
			this.label83.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label83.Location = new System.Drawing.Point(172, 80);
			this.label83.Name = "label83";
			this.label83.Size = new System.Drawing.Size(36, 13);
			this.label83.TabIndex = 286;
			this.label83.Text = "Tipo:";
			// 
			// cmbTipoPerito
			// 
			this.cmbTipoPerito.Enabled = false;
			this.cmbTipoPerito.Habilitar = true;
			this.cmbTipoPerito.Index = -1;
			this.cmbTipoPerito.Location = new System.Drawing.Point(214, 77);
			this.cmbTipoPerito.Name = "cmbTipoPerito";
			this.cmbTipoPerito.Size = new System.Drawing.Size(112, 22);
			this.cmbTipoPerito.TabIndex = 285;
			this.cmbTipoPerito.Texto = "";
			this.cmbTipoPerito.Valor = "";
			// 
			// panel18
			// 
			this.panel18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel18.BackColor = System.Drawing.Color.DarkGray;
			this.panel18.Controls.Add(this.label7);
			this.panel18.Location = new System.Drawing.Point(3, 3);
			this.panel18.Name = "panel18";
			this.panel18.Size = new System.Drawing.Size(348, 21);
			this.panel18.TabIndex = 39;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label7.Location = new System.Drawing.Point(3, 4);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 14);
			this.label7.TabIndex = 0;
			this.label7.Text = "Peritajes";
			// 
			// tpViaAerea
			// 
			this.tpViaAerea.Controls.Add(this.grbPagaCanonAerea);
			this.tpViaAerea.Controls.Add(this.grbEstadoCanonAerea);
			this.tpViaAerea.Controls.Add(this.panelAerea);
			this.tpViaAerea.Location = new System.Drawing.Point(4, 22);
			this.tpViaAerea.Name = "tpViaAerea";
			this.tpViaAerea.Padding = new System.Windows.Forms.Padding(3);
			this.tpViaAerea.Size = new System.Drawing.Size(997, 566);
			this.tpViaAerea.TabIndex = 15;
			this.tpViaAerea.Text = "Autorizados a Recetar Vía Aérea";
			this.tpViaAerea.UseVisualStyleBackColor = true;
			// 
			// grbPagaCanonAerea
			// 
			this.grbPagaCanonAerea.Controls.Add(this.rbPagCanAereaNO);
			this.grbPagaCanonAerea.Controls.Add(this.rbPagCanAereaSI);
			this.grbPagaCanonAerea.Location = new System.Drawing.Point(14, 15);
			this.grbPagaCanonAerea.Name = "grbPagaCanonAerea";
			this.grbPagaCanonAerea.Size = new System.Drawing.Size(114, 46);
			this.grbPagaCanonAerea.TabIndex = 283;
			this.grbPagaCanonAerea.TabStop = false;
			this.grbPagaCanonAerea.Text = "Paga Canon";
			// 
			// rbPagCanAereaNO
			// 
			this.rbPagCanAereaNO.Checked = false;
			this.rbPagCanAereaNO.Location = new System.Drawing.Point(65, 20);
			this.rbPagCanAereaNO.Name = "rbPagCanAereaNO";
			this.rbPagCanAereaNO.Size = new System.Drawing.Size(44, 18);
			this.rbPagCanAereaNO.TabIndex = 0;
			this.rbPagCanAereaNO.Texto = "No";
			// 
			// rbPagCanAereaSI
			// 
			this.rbPagCanAereaSI.Checked = false;
			this.rbPagCanAereaSI.Location = new System.Drawing.Point(20, 20);
			this.rbPagCanAereaSI.Name = "rbPagCanAereaSI";
			this.rbPagCanAereaSI.Size = new System.Drawing.Size(44, 18);
			this.rbPagCanAereaSI.TabIndex = 1;
			this.rbPagCanAereaSI.Texto = "Si";
			// 
			// grbEstadoCanonAerea
			// 
			this.grbEstadoCanonAerea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grbEstadoCanonAerea.Controls.Add(this.groupBox6);
			this.grbEstadoCanonAerea.Controls.Add(this.groupBox5);
			this.grbEstadoCanonAerea.Location = new System.Drawing.Point(-14802, 7);
			this.grbEstadoCanonAerea.Name = "grbEstadoCanonAerea";
			this.grbEstadoCanonAerea.Size = new System.Drawing.Size(284, 87);
			this.grbEstadoCanonAerea.TabIndex = 282;
			this.grbEstadoCanonAerea.TabStop = false;
			this.grbEstadoCanonAerea.Text = "Estado Canon";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.rbViaProcNO);
			this.groupBox6.Controls.Add(this.rbViaProcSI);
			this.groupBox6.Location = new System.Drawing.Point(26, 17);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(113, 58);
			this.groupBox6.TabIndex = 284;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Procesado";
			// 
			// rbViaProcNO
			// 
			this.rbViaProcNO.Checked = true;
			this.rbViaProcNO.Enabled = false;
			this.rbViaProcNO.Location = new System.Drawing.Point(63, 27);
			this.rbViaProcNO.Name = "rbViaProcNO";
			this.rbViaProcNO.Size = new System.Drawing.Size(40, 18);
			this.rbViaProcNO.TabIndex = 0;
			this.rbViaProcNO.Texto = "No ";
			// 
			// rbViaProcSI
			// 
			this.rbViaProcSI.Checked = false;
			this.rbViaProcSI.Enabled = false;
			this.rbViaProcSI.Location = new System.Drawing.Point(15, 27);
			this.rbViaProcSI.Name = "rbViaProcSI";
			this.rbViaProcSI.Size = new System.Drawing.Size(42, 18);
			this.rbViaProcSI.TabIndex = 1;
			this.rbViaProcSI.Texto = "Si";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.rbViaFacNO);
			this.groupBox5.Controls.Add(this.rbViaFacSI);
			this.groupBox5.Location = new System.Drawing.Point(145, 17);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(113, 58);
			this.groupBox5.TabIndex = 283;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Facturado";
			// 
			// rbViaFacNO
			// 
			this.rbViaFacNO.Checked = true;
			this.rbViaFacNO.Enabled = false;
			this.rbViaFacNO.Location = new System.Drawing.Point(63, 27);
			this.rbViaFacNO.Name = "rbViaFacNO";
			this.rbViaFacNO.Size = new System.Drawing.Size(40, 18);
			this.rbViaFacNO.TabIndex = 0;
			this.rbViaFacNO.Texto = "No ";
			// 
			// rbViaFacSI
			// 
			this.rbViaFacSI.Checked = false;
			this.rbViaFacSI.Enabled = false;
			this.rbViaFacSI.Location = new System.Drawing.Point(15, 27);
			this.rbViaFacSI.Name = "rbViaFacSI";
			this.rbViaFacSI.Size = new System.Drawing.Size(42, 18);
			this.rbViaFacSI.TabIndex = 1;
			this.rbViaFacSI.Texto = "Si";
			// 
			// panelAerea
			// 
			this.panelAerea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelAerea.Controls.Add(this.panel19);
			this.panelAerea.Controls.Add(this.dgvViaAerea);
			this.panelAerea.Location = new System.Drawing.Point(12, 69);
			this.panelAerea.Name = "panelAerea";
			this.panelAerea.Size = new System.Drawing.Size(0, 0);
			this.panelAerea.TabIndex = 257;
			// 
			// panel19
			// 
			this.panel19.Controls.Add(this.toolStrip10);
			this.panel19.Location = new System.Drawing.Point(3, 3);
			this.panel19.Name = "panel19";
			this.panel19.Size = new System.Drawing.Size(113, 30);
			this.panel19.TabIndex = 283;
			// 
			// toolStrip10
			// 
			this.toolStrip10.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoAerea,
            this.btnEliminarAerea});
			this.toolStrip10.Location = new System.Drawing.Point(0, 0);
			this.toolStrip10.Name = "toolStrip10";
			this.toolStrip10.Size = new System.Drawing.Size(113, 25);
			this.toolStrip10.TabIndex = 258;
			this.toolStrip10.Text = "toolStrip10";
			// 
			// btnNuevoAerea
			// 
			this.btnNuevoAerea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevoAerea.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoAerea.Image")));
			this.btnNuevoAerea.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevoAerea.Name = "btnNuevoAerea";
			this.btnNuevoAerea.Size = new System.Drawing.Size(23, 22);
			this.btnNuevoAerea.Text = "Agregar ";
			this.btnNuevoAerea.Click += new System.EventHandler(this.btnNuevoAerea_Click);
			// 
			// btnEliminarAerea
			// 
			this.btnEliminarAerea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarAerea.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarAerea.Image")));
			this.btnEliminarAerea.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarAerea.Name = "btnEliminarAerea";
			this.btnEliminarAerea.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarAerea.Text = "Quitar ";
			this.btnEliminarAerea.Click += new System.EventHandler(this.btnEliminarAerea_Click);
			// 
			// dgvViaAerea
			// 
			this.dgvViaAerea.AllowUserToAddRows = false;
			this.dgvViaAerea.AllowUserToDeleteRows = false;
			this.dgvViaAerea.AllowUserToResizeRows = false;
			this.dgvViaAerea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvViaAerea.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvViaAerea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvViaAerea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoAerea,
            this.colNombreAerea,
            this.colObservacionesAerea,
            this.colPagaCanonAerea,
            this.colSesionAproAerea,
            this.colFechaAproAerea,
            this.colSesionRenovAerea,
            this.colFechaRenovAerea,
            this.colSesionPerdAerea,
            this.colFechaPerdAerea,
            this.colActivoViaAerea});
			this.dgvViaAerea.Location = new System.Drawing.Point(3, 31);
			this.dgvViaAerea.Name = "dgvViaAerea";
			this.dgvViaAerea.RowHeadersVisible = false;
			this.dgvViaAerea.Size = new System.Drawing.Size(0, 0);
			this.dgvViaAerea.TabIndex = 256;
			this.dgvViaAerea.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViaAerea_CellClick);
			this.dgvViaAerea.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvViaAerea_CurrentCellDirtyStateChanged);
			this.dgvViaAerea.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvViaAerea_MouseDoubleClick);
			// 
			// colCodigoAerea
			// 
			this.colCodigoAerea.HeaderText = "Código";
			this.colCodigoAerea.Name = "colCodigoAerea";
			this.colCodigoAerea.ReadOnly = true;
			// 
			// colNombreAerea
			// 
			this.colNombreAerea.HeaderText = "Nombre";
			this.colNombreAerea.Name = "colNombreAerea";
			this.colNombreAerea.ReadOnly = true;
			// 
			// colObservacionesAerea
			// 
			this.colObservacionesAerea.HeaderText = "Observaciones";
			this.colObservacionesAerea.Name = "colObservacionesAerea";
			// 
			// colPagaCanonAerea
			// 
			this.colPagaCanonAerea.HeaderText = "Paga Canon";
			this.colPagaCanonAerea.Items.AddRange(new object[] {
            "Si",
            "No"});
			this.colPagaCanonAerea.Name = "colPagaCanonAerea";
			this.colPagaCanonAerea.Visible = false;
			// 
			// colSesionAproAerea
			// 
			this.colSesionAproAerea.HeaderText = "Sesión Aprobación";
			this.colSesionAproAerea.Name = "colSesionAproAerea";
			// 
			// colFechaAproAerea
			// 
			this.colFechaAproAerea.HeaderText = "Fecha Aprobación";
			this.colFechaAproAerea.Name = "colFechaAproAerea";
			this.colFechaAproAerea.ReadOnly = true;
			// 
			// colSesionRenovAerea
			// 
			this.colSesionRenovAerea.HeaderText = "Sesión Renovación";
			this.colSesionRenovAerea.Name = "colSesionRenovAerea";
			// 
			// colFechaRenovAerea
			// 
			this.colFechaRenovAerea.HeaderText = "Fecha Renovación";
			this.colFechaRenovAerea.Name = "colFechaRenovAerea";
			this.colFechaRenovAerea.ReadOnly = true;
			// 
			// colSesionPerdAerea
			// 
			this.colSesionPerdAerea.HeaderText = "Sesión Pérdida";
			this.colSesionPerdAerea.Name = "colSesionPerdAerea";
			// 
			// colFechaPerdAerea
			// 
			this.colFechaPerdAerea.HeaderText = "Fecha Pérdida";
			this.colFechaPerdAerea.Name = "colFechaPerdAerea";
			this.colFechaPerdAerea.ReadOnly = true;
			// 
			// colActivoViaAerea
			// 
			this.colActivoViaAerea.HeaderText = "Activo";
			this.colActivoViaAerea.Name = "colActivoViaAerea";
			// 
			// panel15
			// 
			this.panel15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel15.BackColor = System.Drawing.Color.DarkGray;
			this.panel15.Controls.Add(this.label22);
			this.panel15.Location = new System.Drawing.Point(3, 3);
			this.panel15.Name = "panel15";
			this.panel15.Size = new System.Drawing.Size(0, 23);
			this.panel15.TabIndex = 37;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label22.Location = new System.Drawing.Point(3, 4);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(121, 14);
			this.label22.TabIndex = 0;
			this.label22.Text = "Historial Académico";
			// 
			// txtCentroAcademico
			// 
			this.txtCentroAcademico.FormatearNumero = false;
			this.txtCentroAcademico.Location = new System.Drawing.Point(157, 50);
			this.txtCentroAcademico.Longitud = 30;
			this.txtCentroAcademico.Multilinea = false;
			this.txtCentroAcademico.Name = "txtCentroAcademico";
			this.txtCentroAcademico.Password = '\0';
			this.txtCentroAcademico.ReadOnly = false;
			this.txtCentroAcademico.Size = new System.Drawing.Size(59, 21);
			this.txtCentroAcademico.TabIndex = 268;
			this.txtCentroAcademico.Valor = "";
			this.txtCentroAcademico.Enter += new System.EventHandler(this.txtCentroAcademico_Enter);
			this.txtCentroAcademico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCentroAcademico_KeyDown);
			this.txtCentroAcademico.Leave += new System.EventHandler(this.txtCentroAcademico_Leave);
			this.txtCentroAcademico.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCentroAcademico_MouseDoubleClick);
			// 
			// label50
			// 
			this.label50.AutoSize = true;
			this.label50.Location = new System.Drawing.Point(54, 54);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(97, 13);
			this.label50.TabIndex = 269;
			this.label50.Text = "Centro Académico:";
			// 
			// txtCentroAcademicoN
			// 
			this.txtCentroAcademicoN.FormatearNumero = false;
			this.txtCentroAcademicoN.Location = new System.Drawing.Point(215, 50);
			this.txtCentroAcademicoN.Longitud = 32767;
			this.txtCentroAcademicoN.Multilinea = false;
			this.txtCentroAcademicoN.Name = "txtCentroAcademicoN";
			this.txtCentroAcademicoN.Password = '\0';
			this.txtCentroAcademicoN.ReadOnly = true;
			this.txtCentroAcademicoN.Size = new System.Drawing.Size(285, 21);
			this.txtCentroAcademicoN.TabIndex = 270;
			this.txtCentroAcademicoN.Valor = "";
			// 
			// txtTituloAcademico
			// 
			this.txtTituloAcademico.FormatearNumero = false;
			this.txtTituloAcademico.Location = new System.Drawing.Point(157, 75);
			this.txtTituloAcademico.Longitud = 30;
			this.txtTituloAcademico.Multilinea = false;
			this.txtTituloAcademico.Name = "txtTituloAcademico";
			this.txtTituloAcademico.Password = '\0';
			this.txtTituloAcademico.ReadOnly = false;
			this.txtTituloAcademico.Size = new System.Drawing.Size(59, 21);
			this.txtTituloAcademico.TabIndex = 271;
			this.txtTituloAcademico.Valor = "";
			this.txtTituloAcademico.Enter += new System.EventHandler(this.txtTituloAcademico_Enter);
			this.txtTituloAcademico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTituloAcademico_KeyDown);
			this.txtTituloAcademico.Leave += new System.EventHandler(this.txtTituloAcademico_Leave);
			this.txtTituloAcademico.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtTituloAcademico_MouseDoubleClick);
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.Location = new System.Drawing.Point(57, 79);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(94, 13);
			this.label51.TabIndex = 272;
			this.label51.Text = "Título Académico:";
			// 
			// txtTituloAcademicoN
			// 
			this.txtTituloAcademicoN.FormatearNumero = false;
			this.txtTituloAcademicoN.Location = new System.Drawing.Point(215, 75);
			this.txtTituloAcademicoN.Longitud = 32767;
			this.txtTituloAcademicoN.Multilinea = false;
			this.txtTituloAcademicoN.Name = "txtTituloAcademicoN";
			this.txtTituloAcademicoN.Password = '\0';
			this.txtTituloAcademicoN.ReadOnly = true;
			this.txtTituloAcademicoN.Size = new System.Drawing.Size(285, 21);
			this.txtTituloAcademicoN.TabIndex = 273;
			this.txtTituloAcademicoN.Valor = "";
			// 
			// dgvHistorialAcademico
			// 
			this.dgvHistorialAcademico.AllowUserToAddRows = false;
			this.dgvHistorialAcademico.AllowUserToDeleteRows = false;
			this.dgvHistorialAcademico.AllowUserToResizeRows = false;
			this.dgvHistorialAcademico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvHistorialAcademico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvHistorialAcademico.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvHistorialAcademico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvHistorialAcademico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoCentro,
            this.colNombreCentro,
            this.colCodigoTitulo,
            this.colNombreTitulo,
            this.colCodigoGrado,
            this.colNombreGrado,
            this.colCodigoPais,
            this.colPais,
            this.colCodigoEnfasis,
            this.colEnfasis,
            this.colFechaGradu});
			this.dgvHistorialAcademico.Location = new System.Drawing.Point(50, 199);
			this.dgvHistorialAcademico.MultiSelect = false;
			this.dgvHistorialAcademico.Name = "dgvHistorialAcademico";
			this.dgvHistorialAcademico.RowHeadersVisible = false;
			this.dgvHistorialAcademico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvHistorialAcademico.Size = new System.Drawing.Size(0, 0);
			this.dgvHistorialAcademico.TabIndex = 275;
			// 
			// colCodigoCentro
			// 
			this.colCodigoCentro.HeaderText = "Codigo Centro";
			this.colCodigoCentro.Name = "colCodigoCentro";
			this.colCodigoCentro.ReadOnly = true;
			// 
			// colNombreCentro
			// 
			this.colNombreCentro.HeaderText = "Centro Academico";
			this.colNombreCentro.Name = "colNombreCentro";
			this.colNombreCentro.ReadOnly = true;
			// 
			// colCodigoTitulo
			// 
			this.colCodigoTitulo.HeaderText = "Codigo Titulo";
			this.colCodigoTitulo.Name = "colCodigoTitulo";
			this.colCodigoTitulo.ReadOnly = true;
			this.colCodigoTitulo.Visible = false;
			// 
			// colNombreTitulo
			// 
			this.colNombreTitulo.HeaderText = "Titulo Academico";
			this.colNombreTitulo.Name = "colNombreTitulo";
			this.colNombreTitulo.ReadOnly = true;
			// 
			// colCodigoGrado
			// 
			this.colCodigoGrado.HeaderText = "Codigo Grado";
			this.colCodigoGrado.Name = "colCodigoGrado";
			this.colCodigoGrado.ReadOnly = true;
			this.colCodigoGrado.Visible = false;
			// 
			// colNombreGrado
			// 
			this.colNombreGrado.HeaderText = "Grado Academico";
			this.colNombreGrado.Name = "colNombreGrado";
			this.colNombreGrado.ReadOnly = true;
			// 
			// colCodigoPais
			// 
			this.colCodigoPais.HeaderText = "CodigoPais";
			this.colCodigoPais.Name = "colCodigoPais";
			this.colCodigoPais.Visible = false;
			// 
			// colPais
			// 
			this.colPais.HeaderText = "País";
			this.colPais.Name = "colPais";
			// 
			// colCodigoEnfasis
			// 
			this.colCodigoEnfasis.HeaderText = "Codigo Énfasis";
			this.colCodigoEnfasis.Name = "colCodigoEnfasis";
			this.colCodigoEnfasis.Visible = false;
			// 
			// colEnfasis
			// 
			this.colEnfasis.HeaderText = "Énfasis";
			this.colEnfasis.Name = "colEnfasis";
			// 
			// colFechaGradu
			// 
			this.colFechaGradu.HeaderText = "Fecha Graduación";
			this.colFechaGradu.Name = "colFechaGradu";
			// 
			// toolStrip7
			// 
			this.toolStrip7.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevaFormacion,
            this.btnEliminarFormacion,
            this.btnModificarAcademico});
			this.toolStrip7.Location = new System.Drawing.Point(50, 171);
			this.toolStrip7.Name = "toolStrip7";
			this.toolStrip7.Size = new System.Drawing.Size(81, 25);
			this.toolStrip7.TabIndex = 276;
			this.toolStrip7.Text = "toolStrip7";
			// 
			// btnNuevaFormacion
			// 
			this.btnNuevaFormacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevaFormacion.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaFormacion.Image")));
			this.btnNuevaFormacion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevaFormacion.Name = "btnNuevaFormacion";
			this.btnNuevaFormacion.Size = new System.Drawing.Size(23, 22);
			this.btnNuevaFormacion.Text = "Agregar Formación";
			this.btnNuevaFormacion.Click += new System.EventHandler(this.btnNuevaFormacion_Click);
			// 
			// btnEliminarFormacion
			// 
			this.btnEliminarFormacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarFormacion.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarFormacion.Image")));
			this.btnEliminarFormacion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarFormacion.Name = "btnEliminarFormacion";
			this.btnEliminarFormacion.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarFormacion.Text = "Eliminar Formación";
			this.btnEliminarFormacion.Click += new System.EventHandler(this.btnEliminarFormacion_Click);
			// 
			// btnModificarAcademico
			// 
			this.btnModificarAcademico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnModificarAcademico.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarAcademico.Image")));
			this.btnModificarAcademico.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnModificarAcademico.Name = "btnModificarAcademico";
			this.btnModificarAcademico.Size = new System.Drawing.Size(23, 22);
			this.btnModificarAcademico.Text = "Modificar";
			this.btnModificarAcademico.Click += new System.EventHandler(this.btnModificarAcademico_Click);
			// 
			// txtEnfasis
			// 
			this.txtEnfasis.FormatearNumero = false;
			this.txtEnfasis.Location = new System.Drawing.Point(157, 102);
			this.txtEnfasis.Longitud = 30;
			this.txtEnfasis.Multilinea = false;
			this.txtEnfasis.Name = "txtEnfasis";
			this.txtEnfasis.Password = '\0';
			this.txtEnfasis.ReadOnly = false;
			this.txtEnfasis.Size = new System.Drawing.Size(59, 21);
			this.txtEnfasis.TabIndex = 279;
			this.txtEnfasis.Valor = "";
			this.txtEnfasis.Enter += new System.EventHandler(this.txtOrientacion_Enter);
			this.txtEnfasis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrientacion_KeyDown);
			this.txtEnfasis.Leave += new System.EventHandler(this.txtOrientacion_Leave);
			this.txtEnfasis.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtOrientacion_MouseDoubleClick);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(57, 106);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(96, 13);
			this.label23.TabIndex = 280;
			this.label23.Text = "Énfasis de Carrera:";
			// 
			// txtEnfasisN
			// 
			this.txtEnfasisN.FormatearNumero = false;
			this.txtEnfasisN.Location = new System.Drawing.Point(215, 102);
			this.txtEnfasisN.Longitud = 32767;
			this.txtEnfasisN.Multilinea = false;
			this.txtEnfasisN.Name = "txtEnfasisN";
			this.txtEnfasisN.Password = '\0';
			this.txtEnfasisN.ReadOnly = true;
			this.txtEnfasisN.Size = new System.Drawing.Size(285, 21);
			this.txtEnfasisN.TabIndex = 281;
			this.txtEnfasisN.Valor = "";
			// 
			// txtPaisTitulo
			// 
			this.txtPaisTitulo.FormatearNumero = false;
			this.txtPaisTitulo.Location = new System.Drawing.Point(157, 129);
			this.txtPaisTitulo.Longitud = 4;
			this.txtPaisTitulo.Multilinea = false;
			this.txtPaisTitulo.Name = "txtPaisTitulo";
			this.txtPaisTitulo.Password = '\0';
			this.txtPaisTitulo.ReadOnly = false;
			this.txtPaisTitulo.Size = new System.Drawing.Size(59, 21);
			this.txtPaisTitulo.TabIndex = 282;
			this.txtPaisTitulo.Valor = "";
			this.txtPaisTitulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaisTitulo_KeyDown);
			this.txtPaisTitulo.Leave += new System.EventHandler(this.txtPaisTitulo_Leave);
			this.txtPaisTitulo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtPaisTitulo_MouseDoubleClick);
			// 
			// label84
			// 
			this.label84.AutoSize = true;
			this.label84.Location = new System.Drawing.Point(71, 133);
			this.label84.Name = "label84";
			this.label84.Size = new System.Drawing.Size(80, 13);
			this.label84.TabIndex = 283;
			this.label84.Text = "País del Título:";
			// 
			// txtNombrePaisTitulo
			// 
			this.txtNombrePaisTitulo.FormatearNumero = false;
			this.txtNombrePaisTitulo.Location = new System.Drawing.Point(215, 129);
			this.txtNombrePaisTitulo.Longitud = 32767;
			this.txtNombrePaisTitulo.Multilinea = false;
			this.txtNombrePaisTitulo.Name = "txtNombrePaisTitulo";
			this.txtNombrePaisTitulo.Password = '\0';
			this.txtNombrePaisTitulo.ReadOnly = true;
			this.txtNombrePaisTitulo.Size = new System.Drawing.Size(285, 21);
			this.txtNombrePaisTitulo.TabIndex = 284;
			this.txtNombrePaisTitulo.Valor = "";
			// 
			// gbGradoAcade
			// 
			this.gbGradoAcade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gbGradoAcade.Controls.Add(this.clbGrados);
			this.gbGradoAcade.Location = new System.Drawing.Point(-9684, 77);
			this.gbGradoAcade.Name = "gbGradoAcade";
			this.gbGradoAcade.Size = new System.Drawing.Size(297, 79);
			this.gbGradoAcade.TabIndex = 285;
			this.gbGradoAcade.TabStop = false;
			this.gbGradoAcade.Text = "Grado Académico";
			// 
			// clbGrados
			// 
			this.clbGrados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.clbGrados.Index = -1;
			this.clbGrados.Location = new System.Drawing.Point(6, 13);
			this.clbGrados.Name = "clbGrados";
			this.clbGrados.SeleccionUnica = true;
			this.clbGrados.Size = new System.Drawing.Size(285, 60);
			this.clbGrados.TabIndex = 1;
			// 
			// tpAcademico
			// 
			this.tpAcademico.Controls.Add(this.lblFechaGradu);
			this.tpAcademico.Controls.Add(this.dtpFechaGradu);
			this.tpAcademico.Controls.Add(this.gbGradoAcade);
			this.tpAcademico.Controls.Add(this.txtNombrePaisTitulo);
			this.tpAcademico.Controls.Add(this.label84);
			this.tpAcademico.Controls.Add(this.txtPaisTitulo);
			this.tpAcademico.Controls.Add(this.txtEnfasisN);
			this.tpAcademico.Controls.Add(this.label23);
			this.tpAcademico.Controls.Add(this.txtEnfasis);
			this.tpAcademico.Controls.Add(this.toolStrip7);
			this.tpAcademico.Controls.Add(this.dgvHistorialAcademico);
			this.tpAcademico.Controls.Add(this.txtTituloAcademicoN);
			this.tpAcademico.Controls.Add(this.label51);
			this.tpAcademico.Controls.Add(this.txtTituloAcademico);
			this.tpAcademico.Controls.Add(this.txtCentroAcademicoN);
			this.tpAcademico.Controls.Add(this.label50);
			this.tpAcademico.Controls.Add(this.txtCentroAcademico);
			this.tpAcademico.Controls.Add(this.panel15);
			this.tpAcademico.Location = new System.Drawing.Point(4, 22);
			this.tpAcademico.Name = "tpAcademico";
			this.tpAcademico.Size = new System.Drawing.Size(997, 566);
			this.tpAcademico.TabIndex = 3;
			this.tpAcademico.Text = "Historial Académico";
			this.tpAcademico.UseVisualStyleBackColor = true;
			// 
			// lblFechaGradu
			// 
			this.lblFechaGradu.AutoSize = true;
			this.lblFechaGradu.Location = new System.Drawing.Point(728, 54);
			this.lblFechaGradu.Name = "lblFechaGradu";
			this.lblFechaGradu.Size = new System.Drawing.Size(113, 13);
			this.lblFechaGradu.TabIndex = 288;
			this.lblFechaGradu.Text = "Fecha de Graduación:";
			// 
			// dtpFechaGradu
			// 
			this.dtpFechaGradu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dtpFechaGradu.Checked = true;
			this.dtpFechaGradu.Location = new System.Drawing.Point(-9489, 49);
			this.dtpFechaGradu.mostrarCheckBox = false;
			this.dtpFechaGradu.mostrarUpDown = false;
			this.dtpFechaGradu.Name = "dtpFechaGradu";
			this.dtpFechaGradu.Size = new System.Drawing.Size(102, 22);
			this.dtpFechaGradu.TabIndex = 287;
			this.dtpFechaGradu.Value = new System.DateTime(2019, 6, 26, 0, 0, 0, 0);
			// 
			// tpSilvestre
			// 
			this.tpSilvestre.Controls.Add(this.grbEstadoCanonSilve);
			this.tpSilvestre.Controls.Add(this.panelSilve);
			this.tpSilvestre.Controls.Add(this.grbPagaCanonSilve);
			this.tpSilvestre.Location = new System.Drawing.Point(4, 22);
			this.tpSilvestre.Name = "tpSilvestre";
			this.tpSilvestre.Size = new System.Drawing.Size(997, 566);
			this.tpSilvestre.TabIndex = 16;
			this.tpSilvestre.Text = "Vida Silvestre";
			this.tpSilvestre.UseVisualStyleBackColor = true;
			// 
			// grbEstadoCanonSilve
			// 
			this.grbEstadoCanonSilve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grbEstadoCanonSilve.Controls.Add(this.groupBox3);
			this.grbEstadoCanonSilve.Controls.Add(this.groupBox4);
			this.grbEstadoCanonSilve.Location = new System.Drawing.Point(-10278, 7);
			this.grbEstadoCanonSilve.Name = "grbEstadoCanonSilve";
			this.grbEstadoCanonSilve.Size = new System.Drawing.Size(285, 87);
			this.grbEstadoCanonSilve.TabIndex = 287;
			this.grbEstadoCanonSilve.TabStop = false;
			this.grbEstadoCanonSilve.Text = "Estado Canon";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rbSilveProcNO);
			this.groupBox3.Controls.Add(this.rbSilveProcSI);
			this.groupBox3.Location = new System.Drawing.Point(26, 17);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(113, 58);
			this.groupBox3.TabIndex = 284;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Procesado";
			// 
			// rbSilveProcNO
			// 
			this.rbSilveProcNO.Checked = true;
			this.rbSilveProcNO.Enabled = false;
			this.rbSilveProcNO.Location = new System.Drawing.Point(63, 27);
			this.rbSilveProcNO.Name = "rbSilveProcNO";
			this.rbSilveProcNO.Size = new System.Drawing.Size(40, 18);
			this.rbSilveProcNO.TabIndex = 0;
			this.rbSilveProcNO.Texto = "No ";
			// 
			// rbSilveProcSI
			// 
			this.rbSilveProcSI.Checked = false;
			this.rbSilveProcSI.Enabled = false;
			this.rbSilveProcSI.Location = new System.Drawing.Point(15, 27);
			this.rbSilveProcSI.Name = "rbSilveProcSI";
			this.rbSilveProcSI.Size = new System.Drawing.Size(42, 18);
			this.rbSilveProcSI.TabIndex = 1;
			this.rbSilveProcSI.Texto = "Si";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.rbSilveFacNO);
			this.groupBox4.Controls.Add(this.rbSilveFacSI);
			this.groupBox4.Location = new System.Drawing.Point(145, 17);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(113, 58);
			this.groupBox4.TabIndex = 283;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Facturado";
			// 
			// rbSilveFacNO
			// 
			this.rbSilveFacNO.Checked = true;
			this.rbSilveFacNO.Enabled = false;
			this.rbSilveFacNO.Location = new System.Drawing.Point(63, 27);
			this.rbSilveFacNO.Name = "rbSilveFacNO";
			this.rbSilveFacNO.Size = new System.Drawing.Size(40, 18);
			this.rbSilveFacNO.TabIndex = 0;
			this.rbSilveFacNO.Texto = "No ";
			// 
			// rbSilveFacSI
			// 
			this.rbSilveFacSI.Checked = false;
			this.rbSilveFacSI.Enabled = false;
			this.rbSilveFacSI.Location = new System.Drawing.Point(15, 27);
			this.rbSilveFacSI.Name = "rbSilveFacSI";
			this.rbSilveFacSI.Size = new System.Drawing.Size(42, 18);
			this.rbSilveFacSI.TabIndex = 1;
			this.rbSilveFacSI.Texto = "Si";
			// 
			// panelSilve
			// 
			this.panelSilve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelSilve.Controls.Add(this.panel13);
			this.panelSilve.Controls.Add(this.dgvVidaSilvestre);
			this.panelSilve.Location = new System.Drawing.Point(12, 97);
			this.panelSilve.Name = "panelSilve";
			this.panelSilve.Size = new System.Drawing.Size(0, 0);
			this.panelSilve.TabIndex = 286;
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.toolStrip15);
			this.panel13.Location = new System.Drawing.Point(4, 3);
			this.panel13.Name = "panel13";
			this.panel13.Size = new System.Drawing.Size(74, 33);
			this.panel13.TabIndex = 284;
			// 
			// toolStrip15
			// 
			this.toolStrip15.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoSilvestre,
            this.btnEliminarSilvestre});
			this.toolStrip15.Location = new System.Drawing.Point(0, 0);
			this.toolStrip15.Name = "toolStrip15";
			this.toolStrip15.Size = new System.Drawing.Size(74, 25);
			this.toolStrip15.TabIndex = 256;
			this.toolStrip15.Text = "toolStrip15";
			// 
			// btnNuevoSilvestre
			// 
			this.btnNuevoSilvestre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnNuevoSilvestre.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoSilvestre.Image")));
			this.btnNuevoSilvestre.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevoSilvestre.Name = "btnNuevoSilvestre";
			this.btnNuevoSilvestre.Size = new System.Drawing.Size(23, 22);
			this.btnNuevoSilvestre.Text = "Agregar Campos de Investigación";
			this.btnNuevoSilvestre.Click += new System.EventHandler(this.btnNuevoSilvestre_Click);
			// 
			// btnEliminarSilvestre
			// 
			this.btnEliminarSilvestre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnEliminarSilvestre.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarSilvestre.Image")));
			this.btnEliminarSilvestre.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminarSilvestre.Name = "btnEliminarSilvestre";
			this.btnEliminarSilvestre.Size = new System.Drawing.Size(23, 22);
			this.btnEliminarSilvestre.Text = "Quitar Campo de Investigación";
			this.btnEliminarSilvestre.Click += new System.EventHandler(this.btnEliminarSilvestre_Click);
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
			this.dgvVidaSilvestre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvVidaSilvestre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodigoSilvestre,
            this.colNombreSilvestre,
            this.colPagaCanonSilve,
            this.colSesionAprobacionSilve,
            this.colFechaAprobacionSilve,
            this.colSesionRenovacionSilve,
            this.colFechaRenovacionSilve,
            this.colSesionPerdidaSilve,
            this.colFechaPerdidaSilve,
            this.colObservacionesSilve,
            this.colActivoSilvestre});
			this.dgvVidaSilvestre.Location = new System.Drawing.Point(3, 31);
			this.dgvVidaSilvestre.Name = "dgvVidaSilvestre";
			this.dgvVidaSilvestre.RowHeadersVisible = false;
			this.dgvVidaSilvestre.Size = new System.Drawing.Size(0, 0);
			this.dgvVidaSilvestre.TabIndex = 253;
			this.dgvVidaSilvestre.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVidaSilvestre_CellClick);
			this.dgvVidaSilvestre.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvVidaSilvestre_CurrentCellDirtyStateChanged);
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
			this.colNombreSilvestre.ReadOnly = true;
			// 
			// colPagaCanonSilve
			// 
			this.colPagaCanonSilve.HeaderText = "Paga Canon";
			this.colPagaCanonSilve.Items.AddRange(new object[] {
            "Si",
            "No"});
			this.colPagaCanonSilve.Name = "colPagaCanonSilve";
			this.colPagaCanonSilve.Visible = false;
			// 
			// colSesionAprobacionSilve
			// 
			this.colSesionAprobacionSilve.HeaderText = "Sesión Aprobación";
			this.colSesionAprobacionSilve.Name = "colSesionAprobacionSilve";
			// 
			// colFechaAprobacionSilve
			// 
			this.colFechaAprobacionSilve.HeaderText = "Fecha Aprobación";
			this.colFechaAprobacionSilve.Name = "colFechaAprobacionSilve";
			this.colFechaAprobacionSilve.ReadOnly = true;
			// 
			// colSesionRenovacionSilve
			// 
			this.colSesionRenovacionSilve.HeaderText = "Sesión Renovación";
			this.colSesionRenovacionSilve.Name = "colSesionRenovacionSilve";
			// 
			// colFechaRenovacionSilve
			// 
			this.colFechaRenovacionSilve.HeaderText = "Fecha Renovación";
			this.colFechaRenovacionSilve.Name = "colFechaRenovacionSilve";
			this.colFechaRenovacionSilve.ReadOnly = true;
			// 
			// colSesionPerdidaSilve
			// 
			this.colSesionPerdidaSilve.HeaderText = "Sesión Pérdida";
			this.colSesionPerdidaSilve.Name = "colSesionPerdidaSilve";
			// 
			// colFechaPerdidaSilve
			// 
			this.colFechaPerdidaSilve.HeaderText = "Fecha Pérdida";
			this.colFechaPerdidaSilve.Name = "colFechaPerdidaSilve";
			this.colFechaPerdidaSilve.ReadOnly = true;
			// 
			// colObservacionesSilve
			// 
			this.colObservacionesSilve.HeaderText = "Observaciones";
			this.colObservacionesSilve.Name = "colObservacionesSilve";
			// 
			// colActivoSilvestre
			// 
			this.colActivoSilvestre.HeaderText = "Activo";
			this.colActivoSilvestre.Name = "colActivoSilvestre";
			// 
			// grbPagaCanonSilve
			// 
			this.grbPagaCanonSilve.Controls.Add(this.rbPagCanSilveNO);
			this.grbPagaCanonSilve.Controls.Add(this.rbPagCanSilveSI);
			this.grbPagaCanonSilve.Location = new System.Drawing.Point(12, 7);
			this.grbPagaCanonSilve.Name = "grbPagaCanonSilve";
			this.grbPagaCanonSilve.Size = new System.Drawing.Size(114, 46);
			this.grbPagaCanonSilve.TabIndex = 285;
			this.grbPagaCanonSilve.TabStop = false;
			this.grbPagaCanonSilve.Text = "Paga Canon";
			// 
			// rbPagCanSilveNO
			// 
			this.rbPagCanSilveNO.Checked = false;
			this.rbPagCanSilveNO.Location = new System.Drawing.Point(65, 20);
			this.rbPagCanSilveNO.Name = "rbPagCanSilveNO";
			this.rbPagCanSilveNO.Size = new System.Drawing.Size(44, 18);
			this.rbPagCanSilveNO.TabIndex = 0;
			this.rbPagCanSilveNO.Texto = "No";
			// 
			// rbPagCanSilveSI
			// 
			this.rbPagCanSilveSI.Checked = false;
			this.rbPagCanSilveSI.Location = new System.Drawing.Point(20, 20);
			this.rbPagCanSilveSI.Name = "rbPagCanSilveSI";
			this.rbPagCanSilveSI.Size = new System.Drawing.Size(44, 18);
			this.rbPagCanSilveSI.TabIndex = 1;
			this.rbPagCanSilveSI.Texto = "Si";
			// 
			// dtpFechaModDireccion
			// 
			this.dtpFechaModDireccion.Checked = true;
			this.dtpFechaModDireccion.Location = new System.Drawing.Point(165, 469);
			this.dtpFechaModDireccion.mostrarCheckBox = false;
			this.dtpFechaModDireccion.mostrarUpDown = false;
			this.dtpFechaModDireccion.Name = "dtpFechaModDireccion";
			this.dtpFechaModDireccion.Size = new System.Drawing.Size(101, 22);
			this.dtpFechaModDireccion.TabIndex = 301;
			this.dtpFechaModDireccion.Value = new System.DateTime(2018, 11, 30, 9, 46, 47, 67);
			// 
			// frmColegiadosEdicion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1005, 686);
			this.Controls.Add(this.panel17);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmColegiadosEdicion";
			this.Text = "Colegiados";
			this.Load += new System.EventHandler(this.frmColegiadosEdicion_Load);
			this.Controls.SetChildIndex(this.panel17, 0);
			this.Controls.SetChildIndex(this.tabControl, 0);
			this.Controls.SetChildIndex(this.lblPerfil, 0);
			((System.ComponentModel.ISupportInitialize)(this.dtDatos)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tpBasicos.ResumeLayout(false);
			this.tpAdmin.ResumeLayout(false);
			this.tpAdmin.PerformLayout();
			this.panelBasicos.ResumeLayout(false);
			this.panelBasicos.PerformLayout();
			this.tpAdjuntos.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.flvListado)).EndInit();
			this.tpPlaguicidas.ResumeLayout(false);
			this.grbPagaCanonPlagui.ResumeLayout(false);
			this.grbEstadoCanonPlagui.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.panelPlagui.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.panel20.PerformLayout();
			this.toolStrip5.ResumeLayout(false);
			this.toolStrip5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvInvestigacionPlaguicidas)).EndInit();
			this.tpBeneficiarios.ResumeLayout(false);
			this.tpBeneficiarios.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dlvBeneficiarios)).EndInit();
			this.toolStrip11.ResumeLayout(false);
			this.toolStrip11.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tpEspecialidades.ResumeLayout(false);
			this.tpEspecialidades.PerformLayout();
			this.toolStrip8.ResumeLayout(false);
			this.toolStrip8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCamposEspecialidad)).EndInit();
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			this.grbSesionEspecialidad.ResumeLayout(false);
			this.grbSesionEspecialidad.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.tpHistorial.ResumeLayout(false);
			this.grbHistorialSesiones.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvHistorialSesiones)).EndInit();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.tpAlertas.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
			this.tpGestionCobro.ResumeLayout(false);
			this.grbAdelantos.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvGestionCobroAdel)).EndInit();
			this.grbPendientes.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvGestionCobro)).EndInit();
			this.panelGestionCobro.ResumeLayout(false);
			this.panelGestionCobro.PerformLayout();
			this.toolStrip9.ResumeLayout(false);
			this.toolStrip9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGestionCobro2)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.tpRevista.ResumeLayout(false);
			this.tpRevista.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.tpRegencias.ResumeLayout(false);
			this.tpRegencias.PerformLayout();
			this.gbVidaSilvestreR.ResumeLayout(false);
			this.gbVidaSilvestreR.PerformLayout();
			this.toolStrip16.ResumeLayout(false);
			this.toolStrip16.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVidaSilvestreR)).EndInit();
			this.grbEstableRegencias.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			this.toolStrip6.ResumeLayout(false);
			this.toolStrip6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvEstablecimientos)).EndInit();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.toolStrip14.ResumeLayout(false);
			this.toolStrip14.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHistorialLaboral)).EndInit();
			this.tpLaboral.ResumeLayout(false);
			this.tpLaboral.PerformLayout();
			this.grbRangoLaboral.ResumeLayout(false);
			this.grbRangoLaboral.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.tpPlantilla.ResumeLayout(false);
			this.tpPlantilla.PerformLayout();
			this.panel16.ResumeLayout(false);
			this.panel16.PerformLayout();
			this.grbPlantilla.ResumeLayout(false);
			this.grbPlantilla.PerformLayout();
			this.toolStrip13.ResumeLayout(false);
			this.toolStrip13.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPlantilla)).EndInit();
			this.tpPago_Mutualidad.ResumeLayout(false);
			this.tpPago_Mutualidad.PerformLayout();
			this.grbMutualidad.ResumeLayout(false);
			this.grbMutualidad.PerformLayout();
			this.grbTituloObligatorio.ResumeLayout(false);
			this.grbTituloObligatorio.PerformLayout();
			this.grbPagoMut.ResumeLayout(false);
			this.grbPagoMut.PerformLayout();
			this.toolStrip12.ResumeLayout(false);
			this.toolStrip12.PerformLayout();
			this.grbSesionCond.ResumeLayout(false);
			this.grbSesionCond.PerformLayout();
			this.panel17.ResumeLayout(false);
			this.panel17.PerformLayout();
			this.tpPeritajes.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.groupBox16.ResumeLayout(false);
			this.groupBox18.ResumeLayout(false);
			this.groupBox19.ResumeLayout(false);
			this.panel18.ResumeLayout(false);
			this.panel18.PerformLayout();
			this.tpViaAerea.ResumeLayout(false);
			this.grbPagaCanonAerea.ResumeLayout(false);
			this.grbEstadoCanonAerea.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.panelAerea.ResumeLayout(false);
			this.panel19.ResumeLayout(false);
			this.panel19.PerformLayout();
			this.toolStrip10.ResumeLayout(false);
			this.toolStrip10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvViaAerea)).EndInit();
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvHistorialAcademico)).EndInit();
			this.toolStrip7.ResumeLayout(false);
			this.toolStrip7.PerformLayout();
			this.gbGradoAcade.ResumeLayout(false);
			this.tpAcademico.ResumeLayout(false);
			this.tpAcademico.PerformLayout();
			this.tpSilvestre.ResumeLayout(false);
			this.grbEstadoCanonSilve.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.panelSilve.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel13.PerformLayout();
			this.toolStrip15.ResumeLayout(false);
			this.toolStrip15.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvVidaSilvestre)).EndInit();
			this.grbPagaCanonSilve.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage tpPlaguicidas;
        private System.Windows.Forms.TabPage tpBeneficiarios;
        private System.Windows.Forms.TabPage tpEspecialidades;
        private System.Windows.Forms.TabPage tpHistorial;
        private System.Windows.Forms.TabPage tpAlertas;
        private System.Windows.Forms.TabPage tpGestionCobro;
        private System.Windows.Forms.TabPage tpRevista;
        private Framework.UserControls.txtNormal txtNombre;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNumColegiado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Framework.UserControls.cmbSaseg cmbSexo;
        private Framework.UserControls.txtNormal txtTelefono2;
        private System.Windows.Forms.Label label18;
        private Framework.UserControls.txtNormal txtTelefono1;
        private System.Windows.Forms.Label label15;
        private Framework.UserControls.txtNormal txtEmail2;
        private System.Windows.Forms.Label label20;
        private Framework.UserControls.txtNormal txtEmail1;
        private System.Windows.Forms.Label label19;
        private Framework.UserControls.txtNormal txtDistritoNombreF;
        private Framework.UserControls.txtNormal txtDistrito;
        private Framework.UserControls.txtNormal txtCanton;
        private Framework.UserControls.txtNormal txtProvincia;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private Framework.UserControls.txtNormal txtApartado;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TabPage tpRegencias;
       // private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label39;
        private Framework.UserControls.cmbSaseg cmbTipoEntrega;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label label42;
        private Framework.UserControls.cmbSaseg cmbTrabajoRevista;
        private System.Windows.Forms.Label label41;
        private Framework.UserControls.cmbSaseg cmbRutaRevista;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label9;
        private Framework.UserControls.txtNormal txtPais;
        private Framework.UserControls.dtpSaseg dtpFechaNac;
        private Framework.UserControls.rtbSaseg rtbDireccion;
        private Framework.UserControls.txtNormal txtCantonNombreF;
        private Framework.UserControls.txtNormal txtProvinciaNombreF;
        private Framework.UserControls.txtNormal txtDescripcionPais;
        private Framework.UserControls.txtNormal txtDescCondicion;
        private Framework.UserControls.txtNormal txtCondicion;
        private Framework.UserControls.dtpSaseg dtpFechaIngreso;
        private System.Windows.Forms.Label label14;
        private Framework.UserControls.txtNormal txtDescCategoria;
        private Framework.UserControls.txtNormal txtCategoria;
        private Framework.UserControls.txtNormal txtNumeColegiado;
        private Framework.UserControls.txtNormal txtCedula;
        private System.Windows.Forms.GroupBox grbSesionEspecialidad;
        private Framework.UserControls.dtpSaseg dtpFechaSesionAprob;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private Framework.UserControls.txtNormal txtSesionAprob;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TabPage tpLaboral;
        private System.Windows.Forms.GroupBox grbRangoLaboral;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label53;
        private Framework.UserControls.dtpSaseg dtpEmpresaHasta;
        private Framework.UserControls.dtpSaseg dtpEmpresaDesde;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnNuevaEmpresa;
        private System.Windows.Forms.ToolStripButton btnEliminarEmpresa;
        private System.Windows.Forms.DataGridView dgvHistorialLaboral;
        private Framework.UserControls.txtNormal txtEmpresaN;
        private System.Windows.Forms.Label label52;
        private Framework.UserControls.txtNormal txtEmpresa;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private Framework.UserControls.txtNormal txtEspecialidadN;
        private System.Windows.Forms.Label label58;
        private Framework.UserControls.txtNormal txtEspecialidad;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label56;
        //private Framework.UserControls.txtNormal txtOrientacionN;
        //private System.Windows.Forms.Label label60;
        //private Framework.UserControls.txtNormal txtOrientacion;
        private Framework.UserControls.txtNormal txtCampoEspecialidadN;
        private System.Windows.Forms.Label label59;
        private Framework.UserControls.txtNormal txtCampoEspecialidad;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton btnAgregarEspecialidad;
        private System.Windows.Forms.ToolStripButton btnEliminarEspecialidad;
        private System.Windows.Forms.DataGridView dgvEspecialidades;
        //private System.Windows.Forms.ToolStrip toolStrip9;
        //private System.Windows.Forms.ToolStripButton btnAgregarOrientacion;
        //private System.Windows.Forms.ToolStripButton btnEliminarOrientacion;
        //private System.Windows.Forms.DataGridView dgvOrientaciones;
        private System.Windows.Forms.ToolStrip toolStrip8;
        private System.Windows.Forms.ToolStripButton btnAgregarCampo;
        private System.Windows.Forms.ToolStripButton btnEliminarCampo;
        private System.Windows.Forms.DataGridView dgvCamposEspecialidad;
        //private System.Windows.Forms.Panel panel12;
        //private System.Windows.Forms.Label label57;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoOrientacion;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colNombreOrientacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCampoEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCampoEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoSesionAprob;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaEspecialidad;
        private System.Windows.Forms.TabPage tpPlantilla;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.GroupBox grbPlantilla;
        private System.Windows.Forms.DataGridView dgvPlantilla;
        private System.Windows.Forms.Label label66;
        private Framework.UserControls.txtNormal txtPlantilla;
        //private System.Windows.Forms.ToolStrip toolStrip10;
        private System.Windows.Forms.ToolStripButton btnAdicional;
        private System.Windows.Forms.ToolStripButton btnAdicionalD;
        private System.Windows.Forms.GroupBox grbHistorialSesiones;
        private System.Windows.Forms.DataGridView dgvHistorialSesiones;
        protected BrightIdeasSoftware.DataListView dlvBeneficiarios;
        private System.Windows.Forms.ToolStrip toolStrip11;
        private System.Windows.Forms.ToolStripButton btnNuevoBeneficiario;
        private System.Windows.Forms.ToolStripButton btnEliminarBeneficiario;
        private System.Windows.Forms.ToolStripButton btnModificarBeneficiario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRefrescarBeneficiarios;
        private Framework.UserControls.txtNormal txtEdad;
        private Framework.UserControls.txtNormal txtPlantillaN;
        private System.Windows.Forms.Label label70;
        private Framework.UserControls.txtNormal txtFrecuDescripcion;
        private Framework.UserControls.txtNormal txtFrecu;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlantilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCondicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreArticulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoArticulo;
        private System.Windows.Forms.Label label72;
        private Framework.UserControls.txtNormal txtFrecuDias;
        private System.Windows.Forms.TabPage tpPago_Mutualidad;
        private System.Windows.Forms.GroupBox grbSesionCond;
        private Framework.UserControls.dtpSaseg dtpFechaSesionCond;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private Framework.UserControls.txtNormal txtSesionCond;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label lbTelOficina;
        private Framework.UserControls.txtNormal txtTelefono3;
        private System.Windows.Forms.PictureBox pcbFoto;
        private System.Windows.Forms.Button btnImagen;
        private Framework.UserControls.txtNormal txtIdColegiado;
        private System.Windows.Forms.Button btnQuitarImagen;
        private System.Windows.Forms.Label lblIdCole;
        private Framework.UserControls.txtNormal txtCodigoSesionIncorporacion;
        private System.Windows.Forms.Label lblCodSesionIncorporacion;
        private System.Windows.Forms.TabPage tpPeritajes;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label7;
        private Framework.UserControls.chkSaseg chkCurso;
        private Framework.UserControls.dtpSaseg dtpPerdida;
        private System.Windows.Forms.Label label46;
        private Framework.UserControls.txtNormal txtSesionPerdida;
        private System.Windows.Forms.Label label47;
        private Framework.UserControls.dtpSaseg dtpAprobacion;
        private System.Windows.Forms.Label label48;
        private Framework.UserControls.txtNormal txtSesionAprobacion;
        private System.Windows.Forms.Label label67;
        private Framework.UserControls.txtNormal txtCobradorRegente;
        private System.Windows.Forms.Label label68;
        private Framework.UserControls.txtNormal txtCobradorNombre;
        private System.Windows.Forms.Panel panelPlagui;
        private System.Windows.Forms.DataGridView dgvInvestigacionPlaguicidas;
        private System.Windows.Forms.TabPage tpViaAerea;
        private System.Windows.Forms.Panel panelAerea;
        private System.Windows.Forms.DataGridView dgvViaAerea;
        private Framework.UserControls.chkSaseg chkPedConcepto;
        private Framework.UserControls.dtpSaseg dtpVencimiento;
        private System.Windows.Forms.Label lblVencimiento;
        private Framework.UserControls.txtNormal txtMonto;
        private System.Windows.Forms.Label lblMonto;
        private Framework.UserControls.dtpSaseg dtpFecha;
        private System.Windows.Forms.Label LblFecha;
        private Framework.UserControls.txtNormal txtNPoliza;
        private System.Windows.Forms.Label lblNPoliza;
        private System.Windows.Forms.Label label57;
        private Framework.UserControls.cmbSaseg cmbTipoRegente;
        private Framework.UserControls.dtpSaseg dtpRegresoCondicion;
        private System.Windows.Forms.Label lblRegresoCondi;
        private Framework.UserControls.txtNormal txtHistTelEmpresa;
        private System.Windows.Forms.Label label60;
        private Framework.UserControls.txtNormal txtHistEmpresa;
        private System.Windows.Forms.Panel panelGestionCobro;
        private System.Windows.Forms.DataGridView dgvGestionCobro2;
        private System.Windows.Forms.ToolStrip toolStrip9;
        private System.Windows.Forms.ToolStripButton btnNuevaGestion;
        private System.Windows.Forms.ToolStripButton btnEliminarGestion;
        private System.Windows.Forms.Button btnCambioCondicion;
        private System.Windows.Forms.Label label87;
        private Framework.UserControls.txtNormal txtCorreoLaboral;
        private System.Windows.Forms.Label label85;
        private Framework.UserControls.rtbSaseg rtbDireccionLaboral;
        private Framework.UserControls.txtNormal txtDescPuesto;
        private System.Windows.Forms.Label label86;
        private Framework.UserControls.txtNormal txtPuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoPuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorreoEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpresaDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpresaHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccionEmpresa;
        private System.Windows.Forms.ToolStrip toolStrip12;
        protected System.Windows.Forms.ToolStripButton btnRPTMutualidad;
        private System.Windows.Forms.ToolStrip toolStrip13;
        protected System.Windows.Forms.ToolStripButton btnPagoCouta;
        private System.Windows.Forms.GroupBox groupBox6;
        private Framework.UserControls.rbSaseg rbViaProcNO;
        private Framework.UserControls.rbSaseg rbViaProcSI;
        private System.Windows.Forms.GroupBox grbEstadoCanonAerea;
        private System.Windows.Forms.GroupBox groupBox5;
        private Framework.UserControls.rbSaseg rbViaFacNO;
        private Framework.UserControls.rbSaseg rbViaFacSI;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.ToolStrip toolStrip10;
        private System.Windows.Forms.ToolStripButton btnNuevoAerea;
        private System.Windows.Forms.ToolStripButton btnEliminarAerea;
        private System.Windows.Forms.GroupBox grbEstadoCanonPlagui;
        private System.Windows.Forms.GroupBox groupBox13;
        private Framework.UserControls.rbSaseg rbPlaguiProcNO;
        private Framework.UserControls.rbSaseg rbPlaguiProcSI;
        private System.Windows.Forms.GroupBox groupBox14;
        private Framework.UserControls.rbSaseg rbPlaguiFacNO;
        private Framework.UserControls.rbSaseg rbPlaguiFacSI;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripButton btnNuevoPlaguicida;
        private System.Windows.Forms.ToolStripButton btnEliminaPlagui;
        private System.Windows.Forms.ToolStrip toolStrip14;
        protected System.Windows.Forms.ToolStripButton btnRPTFichaColegiado;
        private System.Windows.Forms.TabPage tpAcademico;
        private System.Windows.Forms.GroupBox gbGradoAcade;
        private Framework.UserControls.clbSaseg clbGrados;
        private Framework.UserControls.txtNormal txtNombrePaisTitulo;
        private System.Windows.Forms.Label label84;
        private Framework.UserControls.txtNormal txtPaisTitulo;
        private Framework.UserControls.txtNormal txtEnfasisN;
        private System.Windows.Forms.Label label23;
        private Framework.UserControls.txtNormal txtEnfasis;
        private System.Windows.Forms.ToolStrip toolStrip7;
        private System.Windows.Forms.ToolStripButton btnNuevaFormacion;
        private System.Windows.Forms.ToolStripButton btnEliminarFormacion;
        private System.Windows.Forms.DataGridView dgvHistorialAcademico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCentro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCentro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoGrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreGrado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoEnfasis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnfasis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaGradu;
        private Framework.UserControls.txtNormal txtTituloAcademicoN;
        private System.Windows.Forms.Label label51;
        private Framework.UserControls.txtNormal txtTituloAcademico;
        private Framework.UserControls.txtNormal txtCentroAcademicoN;
        private System.Windows.Forms.Label label50;
        private Framework.UserControls.txtNormal txtCentroAcademico;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label22;
        private Framework.UserControls.dtpSaseg dtpFechaGradu;
        private System.Windows.Forms.Label lblFechaGradu;
        private System.Windows.Forms.GroupBox grbPagoMut;
        private Framework.UserControls.dtpSaseg dtpTarjetaVencimiento;
        private System.Windows.Forms.MaskedTextBox mtbVenciminetoTerjeta;
        private Framework.UserControls.txtNormal txtDescEntidadFinanciera;
        private System.Windows.Forms.Label lblEntidadFinan;
        private Framework.UserControls.txtNormal txtEntidadFinanciera;
        private Framework.UserControls.chkSaseg chkMorosidad;
        private System.Windows.Forms.Label lblFormaPago;
        private Framework.UserControls.cmbSaseg cmbFormaPago;
        private System.Windows.Forms.Label label37;
        private Framework.UserControls.txtNormal txtTarjeta;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label12;
        private Framework.UserControls.cmbSaseg cmbTipoTarjeta;
        private Framework.UserControls.txtNormal txtDescCobrador;
        private System.Windows.Forms.Label lblCobrador;
        private Framework.UserControls.txtNormal txtCobrador;
        private System.Windows.Forms.GroupBox grbTituloObligatorio;
        private Framework.UserControls.dtpSaseg dtpFechaTitulo;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label63;
        private Framework.UserControls.txtNormal txtCalculoTitulo;
        private Framework.UserControls.rbSaseg rbNoTitulo;
        private Framework.UserControls.rbSaseg rbSiTitulo;
        private System.Windows.Forms.GroupBox grbEstableRegencias;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.ToolStrip toolStrip6;
        private System.Windows.Forms.ToolStripButton btnNuevoEst;
        private System.Windows.Forms.ToolStripButton btnEliminaEst;
        private System.Windows.Forms.DataGridView dgvEstablecimientos;
        private System.Windows.Forms.GroupBox grbPendientes;
        private System.Windows.Forms.DataGridView dgvGestionCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAplicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
        private System.Windows.Forms.GroupBox grbPagaCanonAerea;
        private Framework.UserControls.rbSaseg rbPagCanAereaNO;
        private Framework.UserControls.rbSaseg rbPagCanAereaSI;
        private System.Windows.Forms.GroupBox grbPagaCanonPlagui;
        private Framework.UserControls.rbSaseg rbPagCanPlaguiNO;
        private Framework.UserControls.rbSaseg rbPagCanPlaguiSI;
        private System.Windows.Forms.GroupBox grbMutualidad;
        private Framework.UserControls.txtNormal txtBeneChequeNombre;
        private Framework.UserControls.txtNormal txtBeneficiarioCheque;
        private System.Windows.Forms.Label lblBenef;
        private System.Windows.Forms.Label lblCheque;
        private Framework.UserControls.txtNormal txtCheque;
        private Framework.UserControls.dtpSaseg dtpFallecimiento;
        private System.Windows.Forms.Label lblDtpFallec;
        private Framework.UserControls.rtbSaseg rtbRazon;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private Framework.UserControls.chkSaseg chkRenuncia;
        private Framework.UserControls.txtNormal txtCalculoMutualidad;
        private System.Windows.Forms.Button btnCambioCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoSesion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaSesion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCondicionPrevia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCondicionNueva;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.GroupBox groupBox18;
        private Framework.UserControls.rbSaseg rbPerProcNO;
        private Framework.UserControls.rbSaseg rbPerProcSI;
        private System.Windows.Forms.GroupBox groupBox19;
        private Framework.UserControls.rbSaseg rbPerFacNO;
        private Framework.UserControls.rbSaseg rbPerFacSI;
        private Framework.UserControls.txtNormal txtCobradorPeritaje;
        private System.Windows.Forms.Label label81;
        private Framework.UserControls.txtNormal txtCobradorPeritajeNombre;
        private Framework.UserControls.chkSaseg chkCursoPeritaje;
        private System.Windows.Forms.Label label74;
        private Framework.UserControls.rtbSaseg rtbObservaciones;
        private Framework.UserControls.dtpSaseg dtpSesionPerdidaPeritaje;
        private System.Windows.Forms.Label label75;
        private Framework.UserControls.txtNormal txtSesionPerdidaPeritaje;
        private System.Windows.Forms.Label label76;
        private Framework.UserControls.dtpSaseg dtpRenovacion;
        private System.Windows.Forms.Label label77;
        private Framework.UserControls.txtNormal txtSesionRenov;
        private System.Windows.Forms.Label label78;
        private Framework.UserControls.dtpSaseg dtpSesionAprobPeritaje;
        private System.Windows.Forms.Label label79;
        private Framework.UserControls.txtNormal txtSesionAprobPeritaje;
        private System.Windows.Forms.Label label80;
        private Framework.UserControls.txtNormal txtInstitucion;
        private System.Windows.Forms.Label label82;
        private Framework.UserControls.txtNormal txtNombreInstitucion;
        private System.Windows.Forms.Label label83;
        private Framework.UserControls.cmbSaseg cmbTipoPerito;
        private System.Windows.Forms.TabPage tpSilvestre;
        private System.Windows.Forms.GroupBox grbEstadoCanonSilve;
        private System.Windows.Forms.GroupBox groupBox3;
        private Framework.UserControls.rbSaseg rbSilveProcNO;
        private Framework.UserControls.rbSaseg rbSilveProcSI;
        private System.Windows.Forms.GroupBox groupBox4;
        private Framework.UserControls.rbSaseg rbSilveFacNO;
        private Framework.UserControls.rbSaseg rbSilveFacSI;
        private System.Windows.Forms.Panel panelSilve;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.ToolStrip toolStrip15;
        private System.Windows.Forms.ToolStripButton btnNuevoSilvestre;
        private System.Windows.Forms.ToolStripButton btnEliminarSilvestre;
        private System.Windows.Forms.DataGridView dgvVidaSilvestre;
        private System.Windows.Forms.GroupBox grbPagaCanonSilve;
        private Framework.UserControls.rbSaseg rbPagCanSilveNO;
        private Framework.UserControls.rbSaseg rbPagCanSilveSI;
        private System.Windows.Forms.ToolStripButton btnModificarAcademico;
        private System.Windows.Forms.ToolStripButton btnModificarlaboral;
        private System.Windows.Forms.GroupBox grbAdelantos;
        private System.Windows.Forms.DataGridView dgvGestionCobroAdel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Framework.UserControls.txtNormal txtHistPuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoEstablecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEstablecimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCobrador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCobrador;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEstadoEst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSesionApEst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechAproba;
        private System.Windows.Forms.Label lblCantTotalPlantillaCobro;
        private System.Windows.Forms.Label lblTotalPlantillaCobro;
        private System.Windows.Forms.MaskedTextBox mtbTarjeta;
        private System.Windows.Forms.Label label89;
        private Framework.UserControls.txtNormal txtCalculoMutualidadMontoRenunciar;
        private System.Windows.Forms.Label label88;
        private Framework.UserControls.txtNormal txtCalculoMutualidadMeses;
        private System.Windows.Forms.GroupBox gbVidaSilvestreR;
        private System.Windows.Forms.ToolStrip toolStrip16;
        private System.Windows.Forms.ToolStripButton btnAgregarSilvestre;
        private System.Windows.Forms.ToolStripButton btnEliminaSilvestre;
        private System.Windows.Forms.DataGridView dgvVidaSilvestreR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoSilvestreR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreSilvestreR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcionSilvestreR;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoAerea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNombreAerea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colObservacionesAerea;
		private System.Windows.Forms.DataGridViewComboBoxColumn colPagaCanonAerea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSesionAproAerea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaAproAerea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSesionRenovAerea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaRenovAerea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSesionPerdAerea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaPerdAerea;
		private System.Windows.Forms.DataGridViewCheckBoxColumn colActivoViaAerea;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoCampo;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCampo;
		private System.Windows.Forms.DataGridViewComboBoxColumn colPagaCanon;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSesionAprobacion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaAprobacion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSesionRenovacion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaRenovacion;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSesionPerdidaP;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaPerdidaP;
		private System.Windows.Forms.DataGridViewTextBoxColumn colObservaciones;
		private System.Windows.Forms.DataGridViewCheckBoxColumn colActivoPlagui;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCodigoSilvestre;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNombreSilvestre;
		private System.Windows.Forms.DataGridViewComboBoxColumn colPagaCanonSilve;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSesionAprobacionSilve;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaAprobacionSilve;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSesionRenovacionSilve;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaRenovacionSilve;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSesionPerdidaSilve;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaPerdidaSilve;
		private System.Windows.Forms.DataGridViewTextBoxColumn colObservacionesSilve;
		private System.Windows.Forms.DataGridViewCheckBoxColumn colActivoSilvestre;
		private System.Windows.Forms.DataGridViewTextBoxColumn colId;
		private System.Windows.Forms.DataGridViewComboBoxColumn colMedio;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCompromiso;
		private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCompromiso;
		private System.Windows.Forms.DataGridViewTextBoxColumn colObservacion;
		private System.Windows.Forms.DataGridViewComboBoxColumn ColEstado;
		private Framework.UserControls.dtpSaseg dtpFechaModCelular;
		private Framework.UserControls.dtpSaseg dtpFechaModEmail;
		private Framework.UserControls.dtpSaseg dtpFechaModDireccion;
	}
}