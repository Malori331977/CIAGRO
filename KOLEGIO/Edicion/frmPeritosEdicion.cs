using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Framework;

namespace KOLEGIO
{
    public partial class frmPeritosEdicion : frmEdicion
    {
        private FuncsInternas fInternas;
        string Nconsecutivo = "";
        private DateTimePicker dtp = new DateTimePicker();

        public frmPeritosEdicion(List<string> valoresPk, string NColegiado = "")
            : base(valoresPk)
        {
            this.fInternas = new FuncsInternas();
            Nconsecutivo = NColegiado;
            armarFiltroPK(valoresPk);
            InitializeComponent();
            listaTipos();
            if (cmbTipo.Count > 0)
                cmbTipo.Index = 0;
            cargarDatos();

            if (fInternas.registroDeshabilitado(txtNumColegiado.Valor, ref error))
            {
                btnGuardar.Visible = false;
                btnGuardarSalir.Visible = false;
                toolStripSeparator4.Visible = false;
            }
        }

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Administración de Peritos";
                lblPerfil.Text = "Perfil de Perito";

                listar.COLUMNAS = "IdColegiado,Tipo,CodigoEmpresa,Cobrador,CursoAvaluosPeritaje,NumSesionAprobacion," +
                    "FechaSesionAprobacion,NumSesionRenovacion,FechaSesionRenovacion,NumSesionPerdida,FechaSesionPerdida,Observaciones";

                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_PERITOS";

                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("IdColegiado");
                listar.VALORES_PK = valoresPk;

                identificadorFormulario = "De Peritos";

                insertar = Constantes.PERITAJES_INSERTAR;
                editar = Constantes.PERITAJES_EDITAR;
                borrar = Constantes.PERITAJES_BORRAR;
                seleccionar = Constantes.PERITAJES_SELECCIONAR;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inicializando la instancia del formulario.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDatosDesdeColegiado(string NumeroColegiado)
        {
            DataTable dtTTs = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "*";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_COLEGIADO";
            listA.FILTRO = "where NumeroColegiado = '" + NumeroColegiado + "'";

            if (Consultas.listarDatos(listA, ref dtTTs, ref error))
            {
                if (dtTTs.Rows.Count > 0)
                {
                    txtNColegiado.Valor = NumeroColegiado;
                    txtNumColegiado.Valor = dtTTs.Rows[0]["IdColegiado"].ToString();
                    buscaColegiado(txtNumColegiado.Valor);
                    txtNColegiado.ReadOnly = true;
                    txtCobrador.ReadOnly = true;
                }
                else
                {
                    txtNColegiado.Clear();
                    txtNumColegiado.Clear();
                    txtCobrador.Clear();
                    txtCobradorNombre.Clear();
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected override void cargarDatos()
        {
            tabControl.TabPages.Remove(tpAdjuntos);
            tabControl.TabPages.Add(tpAdjuntos);
            tabControl.TabPages.Remove(tpAdmin);
            tabControl.TabPages.Add(tpAdmin);

            //cmbTipo.agregarItems("Forestal");
            //cmbTipo.agregarItems("Agropecuario");
            //cmbTipo.Index = 0;

            if (valoresPk.Count > 0 )
            {
                if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                {
                    if (dtDatos.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtDatos.Rows)
                        {
                            txtNColegiado.Valor = Nconsecutivo;
                            txtNumColegiado.Valor = row["IdColegiado"].ToString();
                            buscaColegiado(row["IdColegiado"].ToString());
                            //if (row["Tipo"].ToString() == "F")
                            //    cmbTipo.Index = 0;
                            //else
                            //    cmbTipo.Index = 1;

                            cmbTipo.Valor = row["Tipo"].ToString();

                            txtInstitucion.Valor = row["CodigoEmpresa"].ToString();
                            buscaInstitucion(txtInstitucion.Valor);

                            txtCobrador.Valor = row["Cobrador"].ToString();
                            buscaCobrador(txtCobrador.Valor);
                            if (row["CursoAvaluosPeritaje"].ToString() == "S")
                                chkCurso.Checked = true;
                            else
                                chkCurso.Checked = false;

                            txtSesionAprob.Valor = row["NumSesionAprobacion"].ToString();
                            if (row["FechaSesionAprobacion"].ToString() != "")
                                dtpAprobacion.Value = DateTime.Parse(row["FechaSesionAprobacion"].ToString());

                            txtSesionRenov.Valor = row["NumSesionRenovacion"].ToString();
                            if (row["FechaSesionRenovacion"].ToString() != "")
                            {
                                dtpRenovacion.Checked = true;
                                dtpRenovacion.Value = DateTime.Parse(row["FechaSesionRenovacion"].ToString());
                            }
                        
                            txtSesionPerdida.Valor = row["NumSesionPerdida"].ToString();
                            if (row["FechaSesionPerdida"].ToString() != "")
                            {
                                dtpPerdida.Checked = true;
                                dtpPerdida.Value = DateTime.Parse(row["FechaSesionPerdida"].ToString());
                            }

                            rtbObservaciones.Text = row["Observaciones"].ToString();

                        }
                        cargarProtocolos();
                        deshabilitarLlave();
                    }
                }
            }
            else
            {
                cargarDatosDesdeColegiado(Nconsecutivo);
            }
        }

        private void cargarProtocolos()
        {

            string sQuery = "SELECT Codigo,Libro,Folio,Asiento,LibCol,FechaApertura,FechaCierre,Observaciones FROM "
                + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS_LIB_PROTOCOLOS WHERE NumeroColegiado='" + txtNumColegiado.Valor + "'" +
                "order by Codigo";
            DataTable dtProtocolos = new DataTable();

            if (Consultas.fillDataTable(sQuery, ref dtProtocolos, ref error))
            {
                dgvProtocolos.Rows.Clear();
                foreach (DataRow row in dtProtocolos.Rows)
                {
                    dgvProtocolos.Rows.Add(row["Codigo"].ToString(),
                        row["Libro"].ToString(), row["Folio"].ToString(), row["Asiento"].ToString(),
                        row["LibCol"].ToString(), row["FechaApertura"].ToString() != "" ? DateTime.Parse(row["FechaApertura"].ToString()).ToString("dd/MM/yyyy") : "",
                        row["FechaCierre"].ToString() != "" ? DateTime.Parse(row["FechaCierre"].ToString()).ToString("dd/MM/yyyy") : "", row["Observaciones"].ToString());
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool guardarLibrosProtocolos(ref string error)
        {
            Listado list = new Listado();
            list.COLUMNAS = "NumeroColegiado,Codigo,Libro,Folio,Asiento,LibCol,FechaApertura,FechaCierre,Observaciones";
            list.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            list.TABLA = "NV_PERITOS_LIB_PROTOCOLOS";
            bool lbOk = true;
            try
            {
                string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA + ".NV_PERITOS_LIB_PROTOCOLOS WHERE NumeroColegiado='" + txtNumColegiado.Valor + "'";

                lbOk = Consultas.ejecutarSentencia(sQuery, ref error);

                if (lbOk)
                {
                    foreach (DataGridViewRow row in dgvProtocolos.Rows)
                    {
                        parametros.Clear();
                        list.COLUMNAS_PK.Clear();
                        list.COLUMNAS_PK.Add("NumeroColegiado");
                        list.COLUMNAS_PK.Add("Codigo");
                        parametros.Add(txtNumColegiado.Valor);
                        parametros.Add(row.Cells["colCodigoProtocolo"].Value.ToString());
                        parametros.Add(row.Cells["colLibro"].Value.ToString());
                        parametros.Add(row.Cells["colFolio"].Value.ToString());
                        parametros.Add(row.Cells["colAsiento"].Value.ToString());
                        parametros.Add(row.Cells["colLibCol"].Value.ToString());
                        if (!row.Cells["colFechaApertura"].Value.ToString().Equals(""))
                            parametros.Add(DateTime.Parse(row.Cells["colFechaApertura"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
                        else
                            parametros.Add("null");

                        if (!row.Cells["colFechaCierre"].Value.ToString().Equals(""))
                            parametros.Add(DateTime.Parse(row.Cells["colFechaCierre"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));
                        else
                            parametros.Add("null");
                        //parametros.Add(DateTime.Parse(row.Cells["colFechaCierre"].Value.ToString()).ToString("yyyy-MM-ddTHH:mm:ss"));

                        parametros.Add(row.Cells["colObservacionesProtocolo"].Value.ToString());


                        lbOk = Consultas.insertar(parametros, list, identificadorFormulario, ref error);

                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return lbOk;
        }

        protected override bool guardarDetalle(ref string error)
        {
            bool lbOk = true;
            
            lbOk = guardarLibrosProtocolos(ref error);
            
            return lbOk;
        }

        private void frmPeritosEdicion_Load(object sender, EventArgs e)
        {

        }

        private void listaColegiados()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "IdColegiado, NumeroColegiado as Colegiado, Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO";
            listP.COLUMNAS_PK.Add("IdColegiado");
            listP.COLUMNAS_OCULTAS.Add("IdColegiado");

            listP.ORDERBY = "order by IdColegiado";
            listP.TITULO_LISTADO = "Colegiados";
            frmF1 f1Colegiado = new frmF1(listP);
            f1Colegiado.ShowDialog();
            if (f1Colegiado.item != null)
            {
                txtNumColegiado.Valor = f1Colegiado.item.SubItems[0].Text;
                txtNColegiado.Valor = f1Colegiado.item.SubItems[1].Text;
                txtNombreColegiado.Valor = f1Colegiado.item.SubItems[2].Text;
            }
            buscaColegiado(txtNumColegiado.Valor);
        }

        private void listaInstituciones()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "CodigoEmpresa as Institución,NombreEmpresa as Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_EMPRESAS";
            listP.ORDERBY = "order by CodigoEmpresa";
            listP.TITULO_LISTADO = "Instituciones";
            frmF1 f1Institucion = new frmF1(listP);
            f1Institucion.ShowDialog();
            if (f1Institucion.item != null)
            {
                txtInstitucion.Valor = f1Institucion.item.SubItems[0].Text;
                txtNombreInstitucion.Valor = f1Institucion.item.SubItems[1].Text;
            }
        }

        private void listaTipos()
        {
            DataTable dtTpos = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoTipo,NombreTipo";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_TIPOS";
            listA.FILTRO = "where Diferenciador = 'P'";
            listA.ORDERBY = "order by CodigoTipo";

            if (Consultas.listarDatos(listA, ref dtTpos, ref error))
            {
                if (dtTpos.Rows.Count > 0)
                {
                    cmbTipo.DataSource(dtTpos, "CodigoTipo", "NombreTipo");
                    cmbTipo.Valor = "";
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void listaCobradores()
        {
            Listado listP = new Listado();
            listP.COLUMNAS = "Cobrador,Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "COBRADOR";
            listP.ORDERBY = "order by Cobrador";
            listP.TITULO_LISTADO = "Cobradores";
            frmF1 f1Cobrador = new frmF1(listP);
            f1Cobrador.ShowDialog();
            if (f1Cobrador.item != null)
            {
                txtCobrador.Valor = f1Cobrador.item.SubItems[0].Text;
                txtCobradorNombre.Valor = f1Cobrador.item.SubItems[1].Text;
            }
        }

        protected override bool validarDatos(ref string errores)
        {
            if (txtNumColegiado.Valor == "")
            {
                errores = "Debe seleccionar un Colegiado.";
                txtNumColegiado.Focus();
                return false;
            }

            if (txtInstitucion.Valor == "")
            {
                errores = "Debe seleccionar una Institución.";
                txtInstitucion.Focus();
                return false;
            }

            if (txtCobrador.Valor == "")
            {
                errores = "Debe seleccionar un Cobrador.";
                txtCobrador.Focus();
                return false;
            }

            if (chkCurso.Checked == false)
            {
                errores = "No se puede registrar perito sin tener los cursos de avalúos de peritaje.";
                chkCurso.Focus();
                return false;
            }

            foreach (DataGridViewRow row in dgvProtocolos.Rows)
            {
                if (row.Cells["colLibro"].Value.ToString() == "")
                {
                    errores = "Debe definir el libro en la fila " + (row.Index + 1) + " de la sección de Libros Protocolo.";
                    return false;
                }

                if (row.Cells["colFechaApertura"].Value.ToString() == "")
                {
                    errores = "Debe definir la fecha de apertura en la fila " + (row.Index + 1) + " de la sección de Libros Protocolo.";
                    return false;
                }

                //if (row.Cells["colFechaCierre"].Value.ToString() == "")
                //{
                //    errores = "Debe definir la fecha de cierre en la fila " + (row.Index + 1) + " de la sección de Libros Protocolo.";
                //    return false;
                //}

            }

            return true;
        }

        protected override bool llenarParametros()
        {
            parametros.Clear();
            parametros.Add(txtNumColegiado.Valor.Trim());
            //parametros.Add(cmbTipo.Texto[0] + "");
            parametros.Add(cmbTipo.Valor);
            parametros.Add(txtInstitucion.Valor.Trim());
            parametros.Add(txtCobrador.Valor.Trim());
            if (chkCurso.Checked)
                parametros.Add("S");
            else
                parametros.Add("N");

            if (txtSesionAprob.Valor.Trim() != "")
            {
                parametros.Add(txtSesionAprob.Valor.Trim());
                parametros.Add(dtpAprobacion.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            else
            {
                parametros.Add("null");
                parametros.Add("null");
            }

            if (txtSesionRenov.Valor.Trim() != "")
                parametros.Add(txtSesionRenov.Valor.Trim());
            else
                parametros.Add("null");

            if (dtpRenovacion.Checked)
                parametros.Add(dtpRenovacion.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            if (txtSesionPerdida.Valor.Trim() != "")
                parametros.Add(txtSesionPerdida.Valor.Trim());
            else
                parametros.Add("null");

            if (dtpPerdida.Checked)
                parametros.Add(dtpPerdida.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            else
                parametros.Add("null");

            parametros.Add(rtbObservaciones.Text);
            return true;
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtNumColegiado.Valor);
            txtNumColegiado.ReadOnly = true;
            txtNColegiado.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Perito: " + txtNombreColegiado.Valor;
        }

        private void txtNumColegiado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaColegiados();
        }

        private void txtNumColegiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaColegiados();
        }

        private void txtNumColegiado_Leave(object sender, EventArgs e)
        {
            buscaColegiadoLeave(txtNColegiado.Valor);
        }

        private void txtInstitucion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaInstituciones();
        }

        private void txtInstitucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaInstituciones();
        }

        private void txtInstitucion_Leave(object sender, EventArgs e)
        {
            buscaInstitucion(txtInstitucion.Valor);
        }

        private void txtCobrador_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listaCobradores();
        }

        private void txtCobrador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.F1)
                listaCobradores();
        }

        private void buscaColegiadoLeave(string codigo)
        {

            if (txtNColegiado.Valor.Trim() == "")
            {
                txtNombreColegiado.Clear();
                return;
            }

            DataTable dtColegiado = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "IdColegiado,Nombre,Cobrador";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO";
            listP.FILTRO = "where NumeroColegiado = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
            {
                if (dtColegiado.Rows.Count > 0)
                {
                    txtNumColegiado.Valor = dtColegiado.Rows[0]["IdColegiado"].ToString();
                    txtNombreColegiado.Valor = dtColegiado.Rows[0]["Nombre"].ToString();
                    txtCobrador.Valor = dtColegiado.Rows[0]["Cobrador"].ToString();
                    buscaCobrador(txtCobrador.Valor);
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El Número de colegiado digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumColegiado.Clear();
                        txtNColegiado.Clear();
                        txtNombreColegiado.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void buscaColegiado(string codigo)
        {

            if (txtNumColegiado.Valor.Trim() == "")
            {
                txtNombreColegiado.Clear();
                return;
            }

            DataTable dtColegiado = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "IdColegiado,Nombre,Cobrador";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_COLEGIADO";
            listP.FILTRO = "where IdColegiado = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtColegiado, ref error))
            {
                if (dtColegiado.Rows.Count > 0)
                {
                    txtNombreColegiado.Valor = dtColegiado.Rows[0]["Nombre"].ToString();
                    //txtCobrador.Valor = dtColegiado.Rows[0]["Cobrador"].ToString();
                    //buscaCobrador(txtCobrador.Valor);
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El Número de colegiado digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumColegiado.Clear();
                        txtNColegiado.Clear();
                        txtNombreColegiado.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void buscaInstitucion(string codigo)
        {

            if (txtInstitucion.Valor.Trim() == "")
            {
                txtNombreInstitucion.Clear();
                return;
            }

            DataTable dtInstitucion = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "CodigoEmpresa,NombreEmpresa";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "NV_EMPRESAS";
            listP.FILTRO = "where CodigoEmpresa = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtInstitucion, ref error))
            {
                if (dtInstitucion.Rows.Count > 0)
                {
                    txtNombreInstitucion.Valor = dtInstitucion.Rows[0]["NombreEmpresa"].ToString();
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El código de institución digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtInstitucion.Clear();
                        txtNombreInstitucion.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void buscaCobrador(string codigo)
        {

            if (txtCobrador.Valor.Trim() == "")
            {
                txtCobradorNombre.Clear();
                return;
            }

            DataTable dtCobrador = new DataTable();
            Listado listP = new Listado();
            listP.COLUMNAS = "Cobrador,Nombre";
            listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listP.TABLA = "COBRADOR";
            listP.FILTRO = "where Cobrador = '" + codigo + "'";

            if (Consultas.listarDatos(listP, ref dtCobrador, ref error))
            {
                if (dtCobrador.Rows.Count > 0)
                {
                    txtCobradorNombre.Valor = dtCobrador.Rows[0]["Nombre"].ToString();
                }
                else
                {
                    if (codigo != "")
                    {
                        MessageBox.Show("El código de cobrador digitado no existe.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCobrador.Clear();
                        txtCobradorNombre.Clear();
                    }
                }
            }
            else
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtCobrador_Leave(object sender, EventArgs e)
        {
            buscaCobrador(txtCobrador.Valor);
        }

        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            dgvProtocolos.CurrentCell.Value = dtp.Text.ToString();
        }

        void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        protected override void limpiarFormulario()
        {
            txtNumColegiado.Clear();
            txtNColegiado.Clear();
            txtNColegiado.ReadOnly = false;
            txtNombreColegiado.Clear();
            txtInstitucion.Clear();
            txtNombreInstitucion.Clear();
            chkCurso.Checked = false;
            txtCobrador.Clear();
            txtCobradorNombre.Clear();
            txtSesionAprob.Clear();
            txtSesionPerdida.Clear();
            txtSesionRenov.Clear();
            dtpAprobacion.Value = DateTime.Now;
            dtpPerdida.Value = DateTime.Now;
            dtpRenovacion.Value = DateTime.Now;
            rtbObservaciones.Clear();
            cmbTipo.Valor = "";
            dgvProtocolos.Rows.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Colegiado";
        }

        private void btnNuevoLibro_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PERITAJES_EDITAR))
            {
                int contFechaCierre = 0;


                foreach (DataGridViewRow row in dgvProtocolos.Rows)
                {
                    if (row.Cells["colFechaCierre"].Value.ToString() == "")
                    {
                        contFechaCierre++;
                    }
                }

                if (contFechaCierre == 0)
                {
                    dgvProtocolos.Rows.Add(dgvProtocolos.RowCount + 1, "", "", "", "", "", "", "", "");
                    btnGuardar.Enabled = true;
                    btnGuardarSalir.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Debe indicar una fecha de cierre para un nuevo registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                contFechaCierre = 0;
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void btnEliminarLibro_Click(object sender, EventArgs e)
        {
            if (Consultas.tienePrivilegios(Consultas.Usuario, Constantes.PERITAJES_BORRAR))
            {
                if (dgvProtocolos.RowCount == 0)
                    return;

                if (MessageBox.Show("¿Está seguro que desea borrar este registro?", "Validación", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    bool OK = true;
                    string sQuery = "DELETE FROM " + Consultas.sqlCon.COMPAÑIA +
                        ".NV_PERITOS_LIB_PROTOCOLOS where NumeroColegiado='"
                        + txtNumColegiado.Valor +
                        "' and Codigo='" +
                        dgvProtocolos.CurrentCell.OwningRow.Cells["colCodigoProtocolo"].Value.ToString() + "'";

                    OK = Consultas.ejecutarSentencia(sQuery, ref error);
                    dgvProtocolos.Rows.Remove(dgvProtocolos.CurrentCell.OwningRow);
                }
            }
            else
                MessageBox.Show("No tiene privilegios suficientes para acceder a esta opción.", "KOLEGIO Privilegios", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            
        }

        private void dgvProtocolos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProtocolos.Rows.Count > 0)
            {
                dtp.Visible = false;
                if(e.RowIndex != -1)
                {
                    if ((dgvProtocolos.CurrentCell.OwningColumn.Name == "colFechaApertura" ||
                    dgvProtocolos.CurrentCell.OwningColumn.Name == "colFechaCierre"))
                    {
                        dtp = new DateTimePicker();
                        dgvProtocolos.Controls.Add(dtp);
                        dtp.Format = DateTimePickerFormat.Custom;
                        dtp.CustomFormat = "dd/MM/yyyy";
                        Rectangle Rectangle = dgvProtocolos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
                        dtp.Location = new Point(Rectangle.X, Rectangle.Y);

                        dtp.CloseUp += new EventHandler(dtp_CloseUp);
                        dtp.TextChanged += new EventHandler(dtp_OnTextChange);
                        dtp.LostFocus += new EventHandler(dtp_CloseUp);

                        if (dgvProtocolos.CurrentCell.OwningColumn.Name == "colFechaApertura" && dgvProtocolos.Rows[e.RowIndex].Cells["colFechaApertura"].Value.ToString() != string.Empty)
                            dtp.Value = DateTime.Parse(dgvProtocolos.Rows[e.RowIndex].Cells["colFechaApertura"].Value.ToString());

                        if (dgvProtocolos.CurrentCell.OwningColumn.Name == "colFechaCierre" && dgvProtocolos.Rows[e.RowIndex].Cells["colFechaCierre"].Value.ToString() != string.Empty)
                            dtp.Value = DateTime.Parse(dgvProtocolos.Rows[e.RowIndex].Cells["colFechaCierre"].Value.ToString());

                        dtp.Visible = true;
                    }
                }
            }
                
            btnGuardar.Enabled = true;
            btnGuardarSalir.Enabled = true;
        }

        private void dgvProtocolos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvProtocolos.IsCurrentCellDirty)
            {
                dgvProtocolos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
