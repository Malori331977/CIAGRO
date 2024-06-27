using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOLEGIO
{
	public partial class frmCursosEdicion : frmEdicion
	{
        public frmCursosEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 15;
            txtNombre.Longitud = 150;
            txtMonto.Right();

            listaTipos();
            if (cmbTipo.Count > 0)
                cmbTipo.Index = 0;

            cargarDatos();
        }


        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Cursos";
                lblPerfil.Text = "Perfil de Cursos";

                listar.COLUMNAS = "Codigo,Nombre,Tipo,Nivel,Estado,Modalidad,DuracionHoras,Fecha,Monto";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_CURSOS";
                identificadorFormulario = "De Cursos";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("Codigo");
                listar.COLUMNAS_PK_FECHAS.Add("Fecha");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.CURSOS_INSERTAR;
                editar = Constantes.CURSOS_EDITAR;
                borrar = Constantes.CURSOS_BORRAR;
                seleccionar = Constantes.CURSOS_SELECCIONAR;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inicializando la instancia.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void cargarDatos()
        {
            try
            {
                tabControl.TabPages.Remove(tpAdjuntos);
                tabControl.TabPages.Remove(tpAdmin);
                tabControl.TabPages.Add(tpAdmin);


                //cmbTipo.agregarItems("Aprovechamiento");
                //cmbTipo.agregarItems("Asistencia");
                //cmbTipo.Index = 0;


                cmbNivel.agregarItems("Congreso");
                cmbNivel.agregarItems("Seminario");
                cmbNivel.agregarItems("Taller");
                cmbNivel.agregarItems("Curso");
                cmbNivel.agregarItems("Conferencia");
                cmbNivel.Index = 0;


                cmbEstado.agregarItems("Aprobado");
                cmbEstado.agregarItems("Reprobado");
                cmbEstado.agregarItems("Pendiente");
                cmbEstado.Index = 0;


                cmbModalidad.agregarItems("Presencial");
                cmbModalidad.agregarItems("Virtual");
                cmbModalidad.agregarItems("Mixto");
                cmbModalidad.Index = 0;


                if (valoresPk.Count > 0)
                {
                    if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                    {
                        if (dtDatos.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtDatos.Rows)
                            {
                                txtNombre.Valor = row["Nombre"].ToString();
                                txtCodigo.Valor = row["Codigo"].ToString();
                                txtCodigo.ReadOnly = true;

                                //if (row["Tipo"].ToString() == "AP")
                                //    cmbTipo.Index = 0;
                                //else
                                //    cmbTipo.Index = 1;
                                cmbTipo.Valor = row["Tipo"].ToString();

                                if (row["Nivel"].ToString() == "CO")
                                    cmbNivel.Index = 0;
                                else if (row["Nivel"].ToString() == "SE")
                                    cmbNivel.Index = 1;
                                else if (row["Nivel"].ToString() == "TA")
                                    cmbNivel.Index = 2;
                                else if (row["Nivel"].ToString() == "CU")
                                    cmbNivel.Index = 3;
                                else
                                    cmbNivel.Index = 4;

                                if (row["Estado"].ToString() == "A")
                                    cmbEstado.Index = 0;
                                else if (row["Estado"].ToString() == "R")
                                    cmbEstado.Index = 1;
                                else
                                    cmbEstado.Index = 2;

                                if (row["Modalidad"].ToString() == "P")
                                    cmbModalidad.Index = 0;
                                else if (row["Modalidad"].ToString() == "V")
                                    cmbModalidad.Index = 1;
                                else
                                    cmbModalidad.Index = 2;
                                
                                numDuracion.Value = decimal.Parse(row["DuracionHoras"].ToString());
                                if (!string.IsNullOrEmpty(row["Fecha"].ToString()))
                                    dtpFecha.Value = DateTime.Parse(row["Fecha"].ToString());

                                if (!string.IsNullOrEmpty(row["Monto"].ToString()))
								{

                                    txtMonto.Valor = decimal.Parse(row["Monto"].ToString()).ToString("N2");
                                }
                                    

                                lblPerfil.Text = "Perfil de Curso: " + txtNombre.Valor;
                            }
                        }
                    }
                    else
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool llenarParametros()
        {
            parametros.Clear();
            parametros.Add(txtCodigo.Valor);
            parametros.Add(txtNombre.Valor);

            //if (cmbTipo.Valor == "Aprovechamiento")
            //    parametros.Add("AP");
            //else
            //    parametros.Add("AS");
            if (!cmbTipo.Valor.Equals(""))
                parametros.Add(cmbTipo.Valor);
            else
                parametros.Add("null");

            if (cmbNivel.Valor == "Congreso")
                parametros.Add("CO");
            else if (cmbNivel.Valor == "Seminario")
                parametros.Add("SE");
            else if (cmbNivel.Valor == "Taller")
                parametros.Add("TA");
            else if (cmbNivel.Valor == "Curso")
                parametros.Add("CU");
            else
                parametros.Add("CO");
            
            parametros.Add(cmbEstado.Texto[0] + "");
            parametros.Add(cmbModalidad.Texto[0] + "");
            parametros.Add(numDuracion.Value.ToString());
            if (!dtpFecha.Equals(""))
                parametros.Add(dtpFecha.Value.ToString("yyyy-MM-dd"));
            else
                parametros.Add("null");

            if (!txtMonto.Valor.Equals(""))
                parametros.Add(decimal.Parse(txtMonto.Valor).ToString());
            else
                parametros.Add("null");

            return true;
        }

        protected override bool validarDatos(ref string error)
        {
			if (txtCodigo.Valor.Trim() == "")
			{
				error = "Debe especificar un código para el Curso.";
				txtCodigo.Focus();
				return false;
			}

			if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para el Curso.";
                txtNombre.Focus();
                return false;
            }

            if (numDuracion.Value <= 0)
            {
                error = "Debe especificar una duración para el Curso.";
                numDuracion.Focus();
                return false;
            }

            return true;
        }

        protected override void limpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.ReadOnly = false;
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Curso";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            listar.VALORES_PK.Add(dtpFecha.Value.ToString("yyyy-MM-dd"));
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Curso: " + txtNombre.Valor;
        }

        private void listaTipos()
        {
            DataTable dtTpos = new DataTable();
            Listado listA = new Listado();
            listA.COLUMNAS = "CodigoTipo,NombreTipo";
            listA.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
            listA.TABLA = "NV_TIPOS";
            listA.FILTRO = "where Diferenciador = 'C'";
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

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
