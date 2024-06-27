namespace KOLEGIO
{
    partial class frmMenu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
			this.netBarMenu = new NetBarControl.NetBarControl();
			this.gColegiados = new NetBarControl.NetBarGroup();
			this.btnColegiados = new NetBarControl.NetBarItem();
			this.btnTipoProductos = new NetBarControl.NetBarItem();
			this.btnTiposCombos = new NetBarControl.NetBarItem();
			this.gConsultoras = new NetBarControl.NetBarItem();
			this.gPeritajes = new NetBarControl.NetBarItem();
			this.gRegencias = new NetBarControl.NetBarItem();
			this.gRecaudadores = new NetBarControl.NetBarItem();
			this.gRegActividades = new NetBarControl.NetBarItem();
			this.gRegCursos = new NetBarControl.NetBarItem();
			this.gMantenimientos = new NetBarControl.NetBarGroup();
			this.gCentrosAcademicos = new NetBarControl.NetBarItem();
			this.gCarreras = new NetBarControl.NetBarItem();
			this.gGrados = new NetBarControl.NetBarItem();
			this.gOrientaciones = new NetBarControl.NetBarItem();
			this.gEspecialidades = new NetBarControl.NetBarItem();
			this.gCamposEspecialidad = new NetBarControl.NetBarItem();
			this.gCondiciones = new NetBarControl.NetBarItem();
			this.gMachotes = new NetBarControl.NetBarItem();
			this.gEmpresas = new NetBarControl.NetBarItem();
			this.gEstados = new NetBarControl.NetBarItem();
			this.gTipos = new NetBarControl.NetBarItem();
			this.gCategorias = new NetBarControl.NetBarItem();
			this.gCamposInvestigacion = new NetBarControl.NetBarItem();
			this.gCultivos = new NetBarControl.NetBarItem();
			this.gVidaSilvestre = new NetBarControl.NetBarItem();
			this.gCamposAccion = new NetBarControl.NetBarItem();
			this.gFrecuencias = new NetBarControl.NetBarItem();
			this.gFormas = new NetBarControl.NetBarItem();
			this.gPaises = new NetBarControl.NetBarItem();
			this.gPuestosTrabajo = new NetBarControl.NetBarItem();
			this.gZonas = new NetBarControl.NetBarItem();
			this.gPlantillasCobradores = new NetBarControl.NetBarItem();
			this.gActividades = new NetBarControl.NetBarItem();
			this.gCursos = new NetBarControl.NetBarItem();
			this.gProcesos = new NetBarControl.NetBarGroup();
			this.btnIngresoColegiados = new NetBarControl.NetBarItem();
			this.btnCobroRegencias = new NetBarControl.NetBarItem();
			this.btnProcesoAdelantoPagos = new NetBarControl.NetBarItem();
			this.btnProcesoAdelantoPagosRegencia = new NetBarControl.NetBarItem();
			this.btnProcesoCobrosAnuales = new NetBarControl.NetBarItem();
			this.btnLevantamientoCondicion = new NetBarControl.NetBarItem();
			this.btnCambioCondicion = new NetBarControl.NetBarItem();
			this.btnProcesoPlantillaCobradores = new NetBarControl.NetBarItem();
			this.btnProcesoFacturarCobrador = new NetBarControl.NetBarItem();
			this.btnGeneCelularesCobro = new NetBarControl.NetBarItem();
			this.btnCambioUltimoCobro = new NetBarControl.NetBarItem();
			this.gReportes = new NetBarControl.NetBarGroup();
			this.rptColegiados = new NetBarControl.NetBarItem();
			this.rptEstablecimientos = new NetBarControl.NetBarItem();
			this.rptRegEstablecimiento = new NetBarControl.NetBarItem();
			this.rptEstadoEstablecimiento = new NetBarControl.NetBarItem();
			this.rptConsultoras = new NetBarControl.NetBarItem();
			this.rptPlaguicidasAereas = new NetBarControl.NetBarItem();
			this.rptRegentes = new NetBarControl.NetBarItem();
			this.rptPeritos = new NetBarControl.NetBarItem();
			this.rptInformesRegencias = new NetBarControl.NetBarItem();
			this.rptCatEstablecimientos = new NetBarControl.NetBarItem();
			this.rptRegEstableDeudores = new NetBarControl.NetBarItem();
			this.rptConsultorasCerradas = new NetBarControl.NetBarItem();
			this.rptColegiadoCondicion = new NetBarControl.NetBarItem();
			this.rtpHaciendaColegiados = new NetBarControl.NetBarItem();
			this.rptActividades = new NetBarControl.NetBarItem();
			this.rptBitacora = new NetBarControl.NetBarItem();
			this.gAdministracion = new NetBarControl.NetBarGroup();
			this.btnGlobales = new NetBarControl.NetBarItem();
			this.btnActualizarSistema = new NetBarControl.NetBarItem();
			this.btnControlVersiones = new NetBarControl.NetBarItem();
			this.gSeguridad = new NetBarControl.NetBarGroup();
			this.btnUsuarios = new NetBarControl.NetBarItem();
			this.btnCambioClave = new NetBarControl.NetBarItem();
			this.SuspendLayout();
			// 
			// netBarMenu
			// 
			this.netBarMenu.ActiveGroup = this.gColegiados;
			this.netBarMenu.CaptionFont = new System.Drawing.Font("Candara", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.netBarMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.netBarMenu.Groups.AddRange(new NetBarControl.NetBarGroup[] {
            this.gColegiados,
            this.gMantenimientos,
            this.gProcesos,
            this.gReportes,
            this.gAdministracion,
            this.gSeguridad});
			this.netBarMenu.GroupsFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.netBarMenu.Location = new System.Drawing.Point(0, 0);
			this.netBarMenu.Name = "netBarMenu";
			this.netBarMenu.Size = new System.Drawing.Size(359, 694);
			this.netBarMenu.TabIndex = 2;
			// 
			// gColegiados
			// 
			this.gColegiados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gColegiados.Items.AddRange(new NetBarControl.NetBarItem[] {
            this.btnColegiados,
            this.btnTipoProductos,
            this.btnTiposCombos,
            this.gConsultoras,
            this.gPeritajes,
            this.gRegencias,
            this.gRecaudadores,
            this.gRegActividades,
            this.gRegCursos});
			this.gColegiados.Name = "gColegiados";
			this.gColegiados.SmallImage = ((System.Drawing.Image)(resources.GetObject("gColegiados.SmallImage")));
			this.gColegiados.Style = NetBarControl.NetBarGroupStyle.DescriptionItemList;
			this.gColegiados.Text = "Registros";
			// 
			// btnColegiados
			// 
			this.btnColegiados.Description.Text = "Catálogo de Registros del Colegio";
			this.btnColegiados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnColegiados.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnColegiados.LargeImage")));
			this.btnColegiados.Name = "btnColegiados";
			this.btnColegiados.Tag = "";
			this.btnColegiados.Text = "Colegiados";
			this.btnColegiados.ItemClick += new System.EventHandler(this.btnColegiados_ItemClick);
			// 
			// btnTipoProductos
			// 
			this.btnTipoProductos.Description.Text = "Catálogo de Pagos Colegiaturas";
			this.btnTipoProductos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTipoProductos.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTipoProductos.LargeImage")));
			this.btnTipoProductos.Name = "btnTipoProductos";
			this.btnTipoProductos.Text = "Pago Colegiaturas";
			this.btnTipoProductos.ItemClick += new System.EventHandler(this.btnTipoProductos_ItemClick);
			// 
			// btnTiposCombos
			// 
			this.btnTiposCombos.Description.Text = "Catálogo de Establecimientos";
			this.btnTiposCombos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTiposCombos.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTiposCombos.LargeImage")));
			this.btnTiposCombos.Name = "btnTiposCombos";
			this.btnTiposCombos.Text = "Establecimientos";
			this.btnTiposCombos.ItemClick += new System.EventHandler(this.btnTiposCombos_ItemClick);
			// 
			// gConsultoras
			// 
			this.gConsultoras.Description.Text = "Catálogo de Compañias Consultoras";
			this.gConsultoras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gConsultoras.LargeImage = ((System.Drawing.Image)(resources.GetObject("gConsultoras.LargeImage")));
			this.gConsultoras.Name = "gConsultoras";
			this.gConsultoras.Text = "Compañias Consultoras";
			this.gConsultoras.ItemClick += new System.EventHandler(this.gConsultoras_ItemClick);
			// 
			// gPeritajes
			// 
			this.gPeritajes.Description.Text = "Catálogo de Peritajes";
			this.gPeritajes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gPeritajes.LargeImage = ((System.Drawing.Image)(resources.GetObject("gPeritajes.LargeImage")));
			this.gPeritajes.Name = "gPeritajes";
			this.gPeritajes.Text = "Peritajes";
			this.gPeritajes.ItemClick += new System.EventHandler(this.gPeritajes_ItemClick);
			// 
			// gRegencias
			// 
			this.gRegencias.Description.Text = "Catálogo de Regencias";
			this.gRegencias.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gRegencias.LargeImage = ((System.Drawing.Image)(resources.GetObject("gRegencias.LargeImage")));
			this.gRegencias.Name = "gRegencias";
			this.gRegencias.Text = "Regencias";
			this.gRegencias.ItemClick += new System.EventHandler(this.gRegencias_ItemClick);
			// 
			// gRecaudadores
			// 
			this.gRecaudadores.Description.Text = "Catálogo de Recaudadores";
			this.gRecaudadores.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gRecaudadores.LargeImage = ((System.Drawing.Image)(resources.GetObject("gRecaudadores.LargeImage")));
			this.gRecaudadores.Name = "gRecaudadores";
			this.gRecaudadores.Text = "Recaudadores";
			// 
			// gRegActividades
			// 
			this.gRegActividades.Description.Text = "Resgistro de actividades";
			this.gRegActividades.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.gRegActividades.LargeImage = ((System.Drawing.Image)(resources.GetObject("gRegActividades.LargeImage")));
			this.gRegActividades.Name = "gRegActividades";
			this.gRegActividades.Text = "Actividades";
			this.gRegActividades.ItemClick += new System.EventHandler(this.gRegActividades_ItemClick);
			// 
			// gRegCursos
			// 
			this.gRegCursos.Description.Text = "Registro de cursos";
			this.gRegCursos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.gRegCursos.LargeImage = global::KOLEGIO.Properties.Resources.lessons_icon;
			this.gRegCursos.Name = "gRegCursos";
			this.gRegCursos.Text = "Cursos";
			this.gRegCursos.ItemClick += new System.EventHandler(this.gRegCursos_ItemClick);
			// 
			// gMantenimientos
			// 
			this.gMantenimientos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gMantenimientos.Items.AddRange(new NetBarControl.NetBarItem[] {
            this.gCentrosAcademicos,
            this.gCarreras,
            this.gGrados,
            this.gOrientaciones,
            this.gEspecialidades,
            this.gCamposEspecialidad,
            this.gCondiciones,
            this.gMachotes,
            this.gEmpresas,
            this.gEstados,
            this.gTipos,
            this.gCategorias,
            this.gCamposInvestigacion,
            this.gCultivos,
            this.gVidaSilvestre,
            this.gCamposAccion,
            this.gFrecuencias,
            this.gFormas,
            this.gPaises,
            this.gPuestosTrabajo,
            this.gZonas,
            this.gPlantillasCobradores,
            this.gActividades,
            this.gCursos});
			this.gMantenimientos.Name = "gMantenimientos";
			this.gMantenimientos.SmallImage = ((System.Drawing.Image)(resources.GetObject("gMantenimientos.SmallImage")));
			this.gMantenimientos.Style = NetBarControl.NetBarGroupStyle.DescriptionItemList;
			this.gMantenimientos.Text = "Mantenimientos";
			// 
			// gCentrosAcademicos
			// 
			this.gCentrosAcademicos.Description.Text = "Mantenimiento de Centros Académicos";
			this.gCentrosAcademicos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gCentrosAcademicos.LargeImage = ((System.Drawing.Image)(resources.GetObject("gCentrosAcademicos.LargeImage")));
			this.gCentrosAcademicos.Name = "gCentrosAcademicos";
			this.gCentrosAcademicos.Text = "Centros Académicos";
			this.gCentrosAcademicos.ItemClick += new System.EventHandler(this.gCentrosAcademicos_ItemClick);
			// 
			// gCarreras
			// 
			this.gCarreras.Description.Text = "Mantenimiento de Títulos Académicos";
			this.gCarreras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gCarreras.LargeImage = ((System.Drawing.Image)(resources.GetObject("gCarreras.LargeImage")));
			this.gCarreras.Name = "gCarreras";
			this.gCarreras.Text = "Títulos Académicos";
			this.gCarreras.ItemClick += new System.EventHandler(this.gCarreras_ItemClick);
			// 
			// gGrados
			// 
			this.gGrados.Description.Text = "Mantenimiento de Grados Académicos";
			this.gGrados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gGrados.LargeImage = ((System.Drawing.Image)(resources.GetObject("gGrados.LargeImage")));
			this.gGrados.Name = "gGrados";
			this.gGrados.Text = "Grados Académicos";
			this.gGrados.ItemClick += new System.EventHandler(this.gGrados_ItemClick);
			// 
			// gOrientaciones
			// 
			this.gOrientaciones.Description.Text = "Mantenimiento de Énfasis";
			this.gOrientaciones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gOrientaciones.LargeImage = ((System.Drawing.Image)(resources.GetObject("gOrientaciones.LargeImage")));
			this.gOrientaciones.Name = "gOrientaciones";
			this.gOrientaciones.Text = "Énfasis";
			this.gOrientaciones.ItemClick += new System.EventHandler(this.gOrientaciones_ItemClick);
			// 
			// gEspecialidades
			// 
			this.gEspecialidades.Description.Text = "Mantenimiento de Especialidades";
			this.gEspecialidades.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gEspecialidades.LargeImage = ((System.Drawing.Image)(resources.GetObject("gEspecialidades.LargeImage")));
			this.gEspecialidades.Name = "gEspecialidades";
			this.gEspecialidades.Text = "Especialidades";
			this.gEspecialidades.ItemClick += new System.EventHandler(this.gEspecialidades_ItemClick);
			// 
			// gCamposEspecialidad
			// 
			this.gCamposEspecialidad.Description.Text = "Mantenimiento de Campos de Especialidad";
			this.gCamposEspecialidad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gCamposEspecialidad.LargeImage = ((System.Drawing.Image)(resources.GetObject("gCamposEspecialidad.LargeImage")));
			this.gCamposEspecialidad.Name = "gCamposEspecialidad";
			this.gCamposEspecialidad.Text = "Campos de Especialidad";
			this.gCamposEspecialidad.ItemClick += new System.EventHandler(this.gCamposEspecialidad_ItemClick);
			// 
			// gCondiciones
			// 
			this.gCondiciones.Description.Text = "Mantenimiento de Condiciones Colegiado";
			this.gCondiciones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gCondiciones.LargeImage = ((System.Drawing.Image)(resources.GetObject("gCondiciones.LargeImage")));
			this.gCondiciones.Name = "gCondiciones";
			this.gCondiciones.Text = "Condiciones Colegiado";
			this.gCondiciones.ItemClick += new System.EventHandler(this.gCondiciones_ItemClick);
			// 
			// gMachotes
			// 
			this.gMachotes.Description.Text = "Catálogo de Plantillas de Cobro";
			this.gMachotes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gMachotes.LargeImage = ((System.Drawing.Image)(resources.GetObject("gMachotes.LargeImage")));
			this.gMachotes.Name = "gMachotes";
			this.gMachotes.Text = "Plantillas";
			this.gMachotes.ItemClick += new System.EventHandler(this.gMachotes_ItemClick);
			// 
			// gEmpresas
			// 
			this.gEmpresas.Description.Text = "Mantenimiento de Empresas";
			this.gEmpresas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gEmpresas.LargeImage = ((System.Drawing.Image)(resources.GetObject("gEmpresas.LargeImage")));
			this.gEmpresas.Name = "gEmpresas";
			this.gEmpresas.Text = "Empresas";
			this.gEmpresas.ItemClick += new System.EventHandler(this.gEmpresas_ItemClick);
			// 
			// gEstados
			// 
			this.gEstados.Description.Text = "Mantenimiento de Estados Establecimientos/Consultoras";
			this.gEstados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gEstados.LargeImage = ((System.Drawing.Image)(resources.GetObject("gEstados.LargeImage")));
			this.gEstados.Name = "gEstados";
			this.gEstados.Text = "Estados Establecimientos/Consultoras";
			this.gEstados.ItemClick += new System.EventHandler(this.gEstados_ItemClick);
			// 
			// gTipos
			// 
			this.gTipos.Description.Text = "Mantenimiento de Tipos";
			this.gTipos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gTipos.LargeImage = ((System.Drawing.Image)(resources.GetObject("gTipos.LargeImage")));
			this.gTipos.Name = "gTipos";
			this.gTipos.Text = "Tipos";
			this.gTipos.ItemClick += new System.EventHandler(this.gTipos_ItemClick);
			// 
			// gCategorias
			// 
			this.gCategorias.Description.Text = "Mantenimiento de Categorías Regentes";
			this.gCategorias.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gCategorias.LargeImage = ((System.Drawing.Image)(resources.GetObject("gCategorias.LargeImage")));
			this.gCategorias.Name = "gCategorias";
			this.gCategorias.Text = "Categorías Regentes";
			this.gCategorias.ItemClick += new System.EventHandler(this.gCategorias_ItemClick);
			// 
			// gCamposInvestigacion
			// 
			this.gCamposInvestigacion.Description.Text = "Mantenimiento Campos de Investigación en Plaguicidas";
			this.gCamposInvestigacion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gCamposInvestigacion.LargeImage = ((System.Drawing.Image)(resources.GetObject("gCamposInvestigacion.LargeImage")));
			this.gCamposInvestigacion.Name = "gCamposInvestigacion";
			this.gCamposInvestigacion.Text = "Campos de Investigación";
			this.gCamposInvestigacion.ItemClick += new System.EventHandler(this.gCamposInvestigacion_ItemClick);
			// 
			// gCultivos
			// 
			this.gCultivos.Description.Text = "Mantenimiento de Cultivos para Recetas Vía Aérea";
			this.gCultivos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gCultivos.LargeImage = ((System.Drawing.Image)(resources.GetObject("gCultivos.LargeImage")));
			this.gCultivos.Name = "gCultivos";
			this.gCultivos.Text = "Cultivos para Recetas";
			this.gCultivos.ItemClick += new System.EventHandler(this.gCultivos_ItemClick);
			// 
			// gVidaSilvestre
			// 
			this.gVidaSilvestre.Description.Text = "Mantenimiento de Vida Silvestre";
			this.gVidaSilvestre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gVidaSilvestre.LargeImage = ((System.Drawing.Image)(resources.GetObject("gVidaSilvestre.LargeImage")));
			this.gVidaSilvestre.Name = "gVidaSilvestre";
			this.gVidaSilvestre.Text = "Vida Silvestre";
			this.gVidaSilvestre.ItemClick += new System.EventHandler(this.gVidaSilvestre_ItemClick);
			// 
			// gCamposAccion
			// 
			this.gCamposAccion.Description.Text = "Mantenimiento de Campos de Acción (CIAS Consultoras)";
			this.gCamposAccion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gCamposAccion.LargeImage = ((System.Drawing.Image)(resources.GetObject("gCamposAccion.LargeImage")));
			this.gCamposAccion.Name = "gCamposAccion";
			this.gCamposAccion.Text = "Campos de Acción";
			this.gCamposAccion.ItemClick += new System.EventHandler(this.gCamposAccion_ItemClick);
			// 
			// gFrecuencias
			// 
			this.gFrecuencias.Description.Text = "Mantenimiento de Frecuencias de Pago";
			this.gFrecuencias.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gFrecuencias.LargeImage = ((System.Drawing.Image)(resources.GetObject("gFrecuencias.LargeImage")));
			this.gFrecuencias.Name = "gFrecuencias";
			this.gFrecuencias.Text = "Frecuencias de Pago";
			this.gFrecuencias.Visible = false;
			this.gFrecuencias.ItemClick += new System.EventHandler(this.gFrecuencias_ItemClick);
			// 
			// gFormas
			// 
			this.gFormas.Description.Text = "Mantenimiento de Formas de Pago";
			this.gFormas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gFormas.LargeImage = ((System.Drawing.Image)(resources.GetObject("gFormas.LargeImage")));
			this.gFormas.Name = "gFormas";
			this.gFormas.Text = "Formas de Pago";
			this.gFormas.ItemClick += new System.EventHandler(this.gFormas_ItemClick);
			// 
			// gPaises
			// 
			this.gPaises.Description.Text = "Mantenimiento de Países";
			this.gPaises.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gPaises.LargeImage = ((System.Drawing.Image)(resources.GetObject("gPaises.LargeImage")));
			this.gPaises.Name = "gPaises";
			this.gPaises.Text = "Países";
			this.gPaises.Visible = false;
			this.gPaises.ItemClick += new System.EventHandler(this.gPaises_ItemClick);
			// 
			// gPuestosTrabajo
			// 
			this.gPuestosTrabajo.Description.Text = "Mantenimiento de Puestos de Trabajo";
			this.gPuestosTrabajo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gPuestosTrabajo.LargeImage = ((System.Drawing.Image)(resources.GetObject("gPuestosTrabajo.LargeImage")));
			this.gPuestosTrabajo.Name = "gPuestosTrabajo";
			this.gPuestosTrabajo.Text = "Puestos de Trabajo";
			this.gPuestosTrabajo.ItemClick += new System.EventHandler(this.gPuestosTrabajo_ItemClick);
			// 
			// gZonas
			// 
			this.gZonas.Description.Text = "Mantenimiento de Zonas de Cobro";
			this.gZonas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gZonas.LargeImage = ((System.Drawing.Image)(resources.GetObject("gZonas.LargeImage")));
			this.gZonas.Name = "gZonas";
			this.gZonas.Text = "Zonas de Cobro";
			this.gZonas.Visible = false;
			this.gZonas.ItemClick += new System.EventHandler(this.gZonas_ItemClick);
			// 
			// gPlantillasCobradores
			// 
			this.gPlantillasCobradores.Description.Text = "Mantenimiento de Plantillas de Cobradores";
			this.gPlantillasCobradores.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.gPlantillasCobradores.LargeImage = ((System.Drawing.Image)(resources.GetObject("gPlantillasCobradores.LargeImage")));
			this.gPlantillasCobradores.Name = "gPlantillasCobradores";
			this.gPlantillasCobradores.Text = "Plantillas Cobradores";
			this.gPlantillasCobradores.ItemClick += new System.EventHandler(this.gPlantillasCobradores_ItemClick);
			// 
			// gActividades
			// 
			this.gActividades.Description.Text = "Mantenimiento de Actividades para bitácora";
			this.gActividades.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.gActividades.LargeImage = ((System.Drawing.Image)(resources.GetObject("gActividades.LargeImage")));
			this.gActividades.Name = "gActividades";
			this.gActividades.Text = "Actividades";
			this.gActividades.ItemClick += new System.EventHandler(this.gActividades_ItemClick);
			// 
			// gCursos
			// 
			this.gCursos.Description.Text = "Mantenimiento de Cursos";
			this.gCursos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.gCursos.LargeImage = global::KOLEGIO.Properties.Resources.Test_paper_icon;
			this.gCursos.Name = "gCursos";
			this.gCursos.Text = "Cursos";
			this.gCursos.ItemClick += new System.EventHandler(this.gCursos_ItemClick);
			// 
			// gProcesos
			// 
			this.gProcesos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gProcesos.Items.AddRange(new NetBarControl.NetBarItem[] {
            this.btnIngresoColegiados,
            this.btnCobroRegencias,
            this.btnProcesoAdelantoPagos,
            this.btnProcesoAdelantoPagosRegencia,
            this.btnProcesoCobrosAnuales,
            this.btnLevantamientoCondicion,
            this.btnCambioCondicion,
            this.btnProcesoPlantillaCobradores,
            this.btnProcesoFacturarCobrador,
            this.btnGeneCelularesCobro,
            this.btnCambioUltimoCobro});
			this.gProcesos.Name = "gProcesos";
			this.gProcesos.SmallImage = ((System.Drawing.Image)(resources.GetObject("gProcesos.SmallImage")));
			this.gProcesos.Style = NetBarControl.NetBarGroupStyle.DescriptionItemList;
			this.gProcesos.Text = "Procesos";
			// 
			// btnIngresoColegiados
			// 
			this.btnIngresoColegiados.Description.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnIngresoColegiados.Description.Text = "Proceso de Cobros a Colegiados";
			this.btnIngresoColegiados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnIngresoColegiados.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnIngresoColegiados.LargeImage")));
			this.btnIngresoColegiados.Name = "btnIngresoColegiados";
			this.btnIngresoColegiados.Text = "Generación de Colegiaturas";
			this.btnIngresoColegiados.ItemClick += new System.EventHandler(this.btnIngresoColegiados_ItemClick);
			// 
			// btnCobroRegencias
			// 
			this.btnCobroRegencias.Description.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCobroRegencias.Description.Text = "Proceso de Cobros a Regentes";
			this.btnCobroRegencias.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCobroRegencias.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCobroRegencias.LargeImage")));
			this.btnCobroRegencias.Name = "btnCobroRegencias";
			this.btnCobroRegencias.Text = "Generación de Regencias";
			this.btnCobroRegencias.ItemClick += new System.EventHandler(this.btnCobroRegencias_ItemClick);
			// 
			// btnProcesoAdelantoPagos
			// 
			this.btnProcesoAdelantoPagos.Description.Text = "Realizar Pagos Adelantados por Colegiaturas";
			this.btnProcesoAdelantoPagos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProcesoAdelantoPagos.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProcesoAdelantoPagos.LargeImage")));
			this.btnProcesoAdelantoPagos.Name = "btnProcesoAdelantoPagos";
			this.btnProcesoAdelantoPagos.Text = "Adelanto de Pagos por Colegiatura";
			this.btnProcesoAdelantoPagos.ItemClick += new System.EventHandler(this.btnProcesoAdelantoPagos_ItemClick);
			// 
			// btnProcesoAdelantoPagosRegencia
			// 
			this.btnProcesoAdelantoPagosRegencia.Description.Text = "Realizar Pagos Adelantados por Regencias";
			this.btnProcesoAdelantoPagosRegencia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProcesoAdelantoPagosRegencia.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProcesoAdelantoPagosRegencia.LargeImage")));
			this.btnProcesoAdelantoPagosRegencia.Name = "btnProcesoAdelantoPagosRegencia";
			this.btnProcesoAdelantoPagosRegencia.Text = "Adelanto de Pagos por Regencia";
			this.btnProcesoAdelantoPagosRegencia.ItemClick += new System.EventHandler(this.btnProcesoAdelantoPagosRegencia_ItemClick);
			// 
			// btnProcesoCobrosAnuales
			// 
			this.btnProcesoCobrosAnuales.Description.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProcesoCobrosAnuales.Description.Text = "Proceso de cobro de canones(Plaguicidas,Peritajes,Vía Aírea,Consultoras,Estableci" +
    "mientos)";
			this.btnProcesoCobrosAnuales.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProcesoCobrosAnuales.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProcesoCobrosAnuales.LargeImage")));
			this.btnProcesoCobrosAnuales.Name = "btnProcesoCobrosAnuales";
			this.btnProcesoCobrosAnuales.Text = "Cobros Canones Anuales";
			this.btnProcesoCobrosAnuales.ItemClick += new System.EventHandler(this.btnProcesoCobrosAnuales_ItemClick);
			// 
			// btnLevantamientoCondicion
			// 
			this.btnLevantamientoCondicion.Description.Text = "Realizar Pedido de levantamiento de condición";
			this.btnLevantamientoCondicion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLevantamientoCondicion.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLevantamientoCondicion.LargeImage")));
			this.btnLevantamientoCondicion.Name = "btnLevantamientoCondicion";
			this.btnLevantamientoCondicion.Text = "Levantamiento de Condición por Colegiatura";
			this.btnLevantamientoCondicion.ItemClick += new System.EventHandler(this.btnLevantamientoCondicion_ItemClick);
			// 
			// btnCambioCondicion
			// 
			this.btnCambioCondicion.Description.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCambioCondicion.Description.Text = "Proceso de Cambio de Condición";
			this.btnCambioCondicion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCambioCondicion.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCambioCondicion.LargeImage")));
			this.btnCambioCondicion.Name = "btnCambioCondicion";
			this.btnCambioCondicion.Text = "Cambio de Condición";
			this.btnCambioCondicion.ItemClick += new System.EventHandler(this.btnCambioCondicion_ItemClick);
			// 
			// btnProcesoPlantillaCobradores
			// 
			this.btnProcesoPlantillaCobradores.Description.Text = "Generar Archivos de Plantillas de Cobradores";
			this.btnProcesoPlantillaCobradores.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProcesoPlantillaCobradores.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProcesoPlantillaCobradores.LargeImage")));
			this.btnProcesoPlantillaCobradores.Name = "btnProcesoPlantillaCobradores";
			this.btnProcesoPlantillaCobradores.Text = "Proceso Plantillas Cobradores";
			this.btnProcesoPlantillaCobradores.ItemClick += new System.EventHandler(this.btnProcesoPlantillaCobradores_ItemClick);
			// 
			// btnProcesoFacturarCobrador
			// 
			this.btnProcesoFacturarCobrador.Description.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProcesoFacturarCobrador.Description.Text = "Proceso de Facturacion Masivo por Cobrador";
			this.btnProcesoFacturarCobrador.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnProcesoFacturarCobrador.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnProcesoFacturarCobrador.LargeImage")));
			this.btnProcesoFacturarCobrador.Name = "btnProcesoFacturarCobrador";
			this.btnProcesoFacturarCobrador.Text = "Proceso de Cobros Masivo por Cobrador";
			this.btnProcesoFacturarCobrador.ItemClick += new System.EventHandler(this.btnProcesoFacturarCobrador_ItemClick);
			// 
			// btnGeneCelularesCobro
			// 
			this.btnGeneCelularesCobro.Description.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGeneCelularesCobro.Description.Text = "Proceso de generación de archivo de colegiados con pendientes";
			this.btnGeneCelularesCobro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGeneCelularesCobro.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGeneCelularesCobro.LargeImage")));
			this.btnGeneCelularesCobro.Name = "btnGeneCelularesCobro";
			this.btnGeneCelularesCobro.Text = "Generar Reporte Morosidad";
			this.btnGeneCelularesCobro.ItemClick += new System.EventHandler(this.btnGeneCelularesCobro_ItemClick);
			// 
			// btnCambioUltimoCobro
			// 
			this.btnCambioUltimoCobro.Description.Text = "Proceso para el cambio del ultimo cobro";
			this.btnCambioUltimoCobro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCambioUltimoCobro.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCambioUltimoCobro.LargeImage")));
			this.btnCambioUltimoCobro.Name = "btnCambioUltimoCobro";
			this.btnCambioUltimoCobro.Text = "Cambio Último Cobro";
			this.btnCambioUltimoCobro.ItemClick += new System.EventHandler(this.btnCambioUltimoCobro_ItemClick);
			// 
			// gReportes
			// 
			this.gReportes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gReportes.Items.AddRange(new NetBarControl.NetBarItem[] {
            this.rptColegiados,
            this.rptEstablecimientos,
            this.rptRegEstablecimiento,
            this.rptEstadoEstablecimiento,
            this.rptConsultoras,
            this.rptPlaguicidasAereas,
            this.rptRegentes,
            this.rptPeritos,
            this.rptInformesRegencias,
            this.rptCatEstablecimientos,
            this.rptRegEstableDeudores,
            this.rptConsultorasCerradas,
            this.rptColegiadoCondicion,
            this.rtpHaciendaColegiados,
            this.rptActividades,
            this.rptBitacora});
			this.gReportes.Name = "gReportes";
			this.gReportes.SmallImage = ((System.Drawing.Image)(resources.GetObject("gReportes.SmallImage")));
			this.gReportes.Style = NetBarControl.NetBarGroupStyle.DescriptionItemList;
			this.gReportes.Text = "Reportes";
			// 
			// rptColegiados
			// 
			this.rptColegiados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rptColegiados.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptColegiados.LargeImage")));
			this.rptColegiados.Name = "rptColegiados";
			this.rptColegiados.Text = "Colegiados";
			this.rptColegiados.ItemClick += new System.EventHandler(this.rptColegiados_ItemClick);
			// 
			// rptEstablecimientos
			// 
			this.rptEstablecimientos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rptEstablecimientos.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptEstablecimientos.LargeImage")));
			this.rptEstablecimientos.Name = "rptEstablecimientos";
			this.rptEstablecimientos.Text = "Establecimientos";
			this.rptEstablecimientos.ItemClick += new System.EventHandler(this.rptEstablecimientos_ItemClick);
			// 
			// rptRegEstablecimiento
			// 
			this.rptRegEstablecimiento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rptRegEstablecimiento.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptRegEstablecimiento.LargeImage")));
			this.rptRegEstablecimiento.Name = "rptRegEstablecimiento";
			this.rptRegEstablecimiento.Text = "Regentes por Establecimientos";
			this.rptRegEstablecimiento.ItemClick += new System.EventHandler(this.rptRegEstablecimiento_ItemClick);
			// 
			// rptEstadoEstablecimiento
			// 
			this.rptEstadoEstablecimiento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rptEstadoEstablecimiento.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptEstadoEstablecimiento.LargeImage")));
			this.rptEstadoEstablecimiento.Name = "rptEstadoEstablecimiento";
			this.rptEstadoEstablecimiento.Text = "Estados de Establecimientos";
			this.rptEstadoEstablecimiento.ItemClick += new System.EventHandler(this.rptEstadoEstablecimiento_ItemClick);
			// 
			// rptConsultoras
			// 
			this.rptConsultoras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rptConsultoras.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptConsultoras.LargeImage")));
			this.rptConsultoras.Name = "rptConsultoras";
			this.rptConsultoras.Text = "Consultoras";
			this.rptConsultoras.ItemClick += new System.EventHandler(this.rptConsultoras_ItemClick);
			// 
			// rptPlaguicidasAereas
			// 
			this.rptPlaguicidasAereas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rptPlaguicidasAereas.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptPlaguicidasAereas.LargeImage")));
			this.rptPlaguicidasAereas.Name = "rptPlaguicidasAereas";
			this.rptPlaguicidasAereas.Text = "Plaguicidas y Aereas";
			this.rptPlaguicidasAereas.ItemClick += new System.EventHandler(this.rptPlaguicidasAereas_ItemClick);
			// 
			// rptRegentes
			// 
			this.rptRegentes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rptRegentes.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptRegentes.LargeImage")));
			this.rptRegentes.Name = "rptRegentes";
			this.rptRegentes.Text = "Regentes";
			this.rptRegentes.ItemClick += new System.EventHandler(this.rptRegentes_ItemClick);
			// 
			// rptPeritos
			// 
			this.rptPeritos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rptPeritos.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptPeritos.LargeImage")));
			this.rptPeritos.Name = "rptPeritos";
			this.rptPeritos.Text = "Peritos";
			this.rptPeritos.ItemClick += new System.EventHandler(this.rptPeritos_ItemClick);
			// 
			// rptInformesRegencias
			// 
			this.rptInformesRegencias.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rptInformesRegencias.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptInformesRegencias.LargeImage")));
			this.rptInformesRegencias.Name = "rptInformesRegencias";
			this.rptInformesRegencias.Text = "InformesRegencias";
			this.rptInformesRegencias.ItemClick += new System.EventHandler(this.rptInformesRegencias_ItemClick);
			// 
			// rptCatEstablecimientos
			// 
			this.rptCatEstablecimientos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rptCatEstablecimientos.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptCatEstablecimientos.LargeImage")));
			this.rptCatEstablecimientos.Name = "rptCatEstablecimientos";
			this.rptCatEstablecimientos.Text = "Categorias de Establecimientos";
			this.rptCatEstablecimientos.ItemClick += new System.EventHandler(this.rptCatEstablecimientos_ItemClick);
			// 
			// rptRegEstableDeudores
			// 
			this.rptRegEstableDeudores.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rptRegEstableDeudores.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptRegEstableDeudores.LargeImage")));
			this.rptRegEstableDeudores.Name = "rptRegEstableDeudores";
			this.rptRegEstableDeudores.Text = "Regentes Deudores por Establecimientos";
			this.rptRegEstableDeudores.ItemClick += new System.EventHandler(this.rptRegEstableDeudores_ItemClick);
			// 
			// rptConsultorasCerradas
			// 
			this.rptConsultorasCerradas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rptConsultorasCerradas.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptConsultorasCerradas.LargeImage")));
			this.rptConsultorasCerradas.Name = "rptConsultorasCerradas";
			this.rptConsultorasCerradas.Text = "Consultoras Cerradas";
			this.rptConsultorasCerradas.ItemClick += new System.EventHandler(this.rptConsultorasCerradas_ItemClick);
			// 
			// rptColegiadoCondicion
			// 
			this.rptColegiadoCondicion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rptColegiadoCondicion.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptColegiadoCondicion.LargeImage")));
			this.rptColegiadoCondicion.Name = "rptColegiadoCondicion";
			this.rptColegiadoCondicion.Text = "Colegiados por Condición";
			this.rptColegiadoCondicion.ItemClick += new System.EventHandler(this.rptColegiadoCondicion_ItemClick);
			// 
			// rtpHaciendaColegiados
			// 
			this.rtpHaciendaColegiados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rtpHaciendaColegiados.LargeImage = ((System.Drawing.Image)(resources.GetObject("rtpHaciendaColegiados.LargeImage")));
			this.rtpHaciendaColegiados.Name = "rtpHaciendaColegiados";
			this.rtpHaciendaColegiados.Text = "Colegiados para Hacienda";
			this.rtpHaciendaColegiados.ItemClick += new System.EventHandler(this.rtpHaciendaColegiados_ItemClick);
			// 
			// rptActividades
			// 
			this.rptActividades.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rptActividades.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptActividades.LargeImage")));
			this.rptActividades.Name = "rptActividades";
			this.rptActividades.Text = "Actividades";
			this.rptActividades.ItemClick += new System.EventHandler(this.rptActividades_ItemClick);
			// 
			// rptBitacora
			// 
			this.rptBitacora.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.rptBitacora.LargeImage = ((System.Drawing.Image)(resources.GetObject("rptBitacora.LargeImage")));
			this.rptBitacora.Name = "rptBitacora";
			this.rptBitacora.Text = "Bitacora";
			this.rptBitacora.ItemClick += new System.EventHandler(this.rptBitacora_ItemClick);
			// 
			// gAdministracion
			// 
			this.gAdministracion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gAdministracion.Items.AddRange(new NetBarControl.NetBarItem[] {
            this.btnGlobales,
            this.btnActualizarSistema,
            this.btnControlVersiones});
			this.gAdministracion.Name = "gAdministracion";
			this.gAdministracion.SmallImage = ((System.Drawing.Image)(resources.GetObject("gAdministracion.SmallImage")));
			this.gAdministracion.Style = NetBarControl.NetBarGroupStyle.DescriptionItemList;
			this.gAdministracion.Text = "Administración";
			// 
			// btnGlobales
			// 
			this.btnGlobales.Description.Text = "Configuración de Parámetros Globales";
			this.btnGlobales.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGlobales.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGlobales.LargeImage")));
			this.btnGlobales.Name = "btnGlobales";
			this.btnGlobales.Text = "Configuración";
			this.btnGlobales.ItemClick += new System.EventHandler(this.btnGlobales_ItemClick);
			// 
			// btnActualizarSistema
			// 
			this.btnActualizarSistema.Description.Text = "Proceso de Actualización del Sistema";
			this.btnActualizarSistema.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnActualizarSistema.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnActualizarSistema.LargeImage")));
			this.btnActualizarSistema.Name = "btnActualizarSistema";
			this.btnActualizarSistema.Text = "Actualizar Sistema";
			this.btnActualizarSistema.ItemClick += new System.EventHandler(this.btnActualizarSistema_ItemClick);
			// 
			// btnControlVersiones
			// 
			this.btnControlVersiones.Description.Text = "Listado de Versiones del Sistema";
			this.btnControlVersiones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnControlVersiones.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnControlVersiones.LargeImage")));
			this.btnControlVersiones.Name = "btnControlVersiones";
			this.btnControlVersiones.Text = "Control de Versiones";
			this.btnControlVersiones.ItemClick += new System.EventHandler(this.btnControlVersiones_ItemClick);
			// 
			// gSeguridad
			// 
			this.gSeguridad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.gSeguridad.Items.AddRange(new NetBarControl.NetBarItem[] {
            this.btnUsuarios,
            this.btnCambioClave});
			this.gSeguridad.Name = "gSeguridad";
			this.gSeguridad.SmallImage = ((System.Drawing.Image)(resources.GetObject("gSeguridad.SmallImage")));
			this.gSeguridad.Style = NetBarControl.NetBarGroupStyle.DescriptionItemList;
			this.gSeguridad.Text = "Seguridad";
			// 
			// btnUsuarios
			// 
			this.btnUsuarios.Description.Text = "Mantenimiento de Usuarios";
			this.btnUsuarios.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnUsuarios.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.LargeImage")));
			this.btnUsuarios.Name = "btnUsuarios";
			this.btnUsuarios.Text = "Usuarios";
			this.btnUsuarios.ItemClick += new System.EventHandler(this.btnUsuarios_ItemClick);
			// 
			// btnCambioClave
			// 
			this.btnCambioClave.Description.Text = "Cambiar Clave de Usuario";
			this.btnCambioClave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCambioClave.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCambioClave.LargeImage")));
			this.btnCambioClave.Name = "btnCambioClave";
			this.btnCambioClave.Text = "Cambio Clave";
			this.btnCambioClave.ItemClick += new System.EventHandler(this.btnCambioClave_ItemClick);
			// 
			// frmMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(359, 694);
			this.Controls.Add(this.netBarMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMenu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "KOLEGIO";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
			this.Load += new System.EventHandler(this.frmMenu_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private NetBarControl.NetBarControl netBarMenu;
        private NetBarControl.NetBarGroup gColegiados;
        private NetBarControl.NetBarItem btnColegiados;
        private NetBarControl.NetBarItem btnTipoProductos;
        private NetBarControl.NetBarItem btnTiposCombos;
        private NetBarControl.NetBarGroup gSeguridad;
        private NetBarControl.NetBarItem btnUsuarios;
        private NetBarControl.NetBarItem btnCambioClave;
        private NetBarControl.NetBarGroup gMantenimientos;
        private NetBarControl.NetBarItem gCentrosAcademicos;
        private NetBarControl.NetBarItem gEmpresas;
        private NetBarControl.NetBarItem gPaises;
        private NetBarControl.NetBarItem gPuestosTrabajo;
        private NetBarControl.NetBarItem gEstados;
        private NetBarControl.NetBarItem gTipos;
        private NetBarControl.NetBarItem gCarreras;
        private NetBarControl.NetBarGroup gAdministracion;
        private NetBarControl.NetBarItem gCategorias;
        private NetBarControl.NetBarItem gMachotes;
        private NetBarControl.NetBarItem gPeritajes;
        private NetBarControl.NetBarItem gRegencias;
        private NetBarControl.NetBarItem gRecaudadores;
        private NetBarControl.NetBarItem gGrados;
        private NetBarControl.NetBarItem gCondiciones;
        private NetBarControl.NetBarItem gCamposInvestigacion;
        private NetBarControl.NetBarItem gCultivos; 
        private NetBarControl.NetBarItem gVidaSilvestre;
        private NetBarControl.NetBarItem gCamposAccion;
        private NetBarControl.NetBarItem gOrientaciones;
        private NetBarControl.NetBarItem gEspecialidades;
        private NetBarControl.NetBarItem gCamposEspecialidad;
        private NetBarControl.NetBarItem gZonas;
        private NetBarControl.NetBarItem gFrecuencias;
        private NetBarControl.NetBarItem gFormas;
        private NetBarControl.NetBarGroup gProcesos;
        private NetBarControl.NetBarItem btnIngresoColegiados;
        private NetBarControl.NetBarGroup gReportes;
        private NetBarControl.NetBarItem btnGlobales;
        private NetBarControl.NetBarItem gPlantillasCobradores;
        private NetBarControl.NetBarItem btnProcesoPlantillaCobradores;
        private NetBarControl.NetBarItem btnProcesoAdelantoPagos;
        private NetBarControl.NetBarItem btnProcesoAdelantoPagosRegencia;
        private NetBarControl.NetBarItem btnCobroRegencias;
        private NetBarControl.NetBarItem gConsultoras;
        private NetBarControl.NetBarItem btnCambioCondicion;
        private NetBarControl.NetBarItem btnProcesoFacturarCobrador;
        private NetBarControl.NetBarItem btnLevantamientoCondicion;
        private NetBarControl.NetBarItem rptRegEstablecimiento;
        private NetBarControl.NetBarItem rptRegEstableDeudores;
        private NetBarControl.NetBarItem rptConsultorasCerradas;
        private NetBarControl.NetBarItem rptEstadoEstablecimiento;
        private NetBarControl.NetBarItem rptColegiadoCondicion;
        private NetBarControl.NetBarItem rptCatEstablecimientos;
        public NetBarControl.NetBarItem btnProcesoCobrosAnuales;
        private NetBarControl.NetBarItem btnGeneCelularesCobro;
        private NetBarControl.NetBarItem rptColegiados;
        private NetBarControl.NetBarItem rptEstablecimientos;
        private NetBarControl.NetBarItem rptConsultoras;
        private NetBarControl.NetBarItem btnActualizarSistema;
        private NetBarControl.NetBarItem btnControlVersiones;
        private NetBarControl.NetBarItem netBarItem1;
        private NetBarControl.NetBarItem rptPlaguicidasAereas;
        private NetBarControl.NetBarItem rptPeritos;
		private NetBarControl.NetBarItem rptRegentes;
		private NetBarControl.NetBarItem rptInformesRegencias;
        private NetBarControl.NetBarItem btnCambioUltimoCobro;
        private NetBarControl.NetBarItem rtpHaciendaColegiados;
		private NetBarControl.NetBarItem gActividades;
		private NetBarControl.NetBarItem gRegActividades;
		private NetBarControl.NetBarItem rptActividades;
		private NetBarControl.NetBarItem gCursos;
		private NetBarControl.NetBarItem gRegCursos;
		private NetBarControl.NetBarItem rptBitacora;
	}
}

