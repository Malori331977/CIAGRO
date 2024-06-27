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
    public partial class frmCentrosAcademicosEdicion : frmEdicion
    {
        public frmCentrosAcademicosEdicion(List<string> valoresPk)
            : base(valoresPk)
        {
            InitializeComponent();
            txtCodigo.Mayusculas();
            txtCodigo.Longitud = 15;
            txtNombre.Longitud = 100;
            rtbDescripcion.Longitud = 1024;
            cargarDatos();
        }

        //private void Carreras()
        //{
        //    DataTable dtCarreras = new DataTable();
        //    Listado listP = new Listado();
        //    listP.COLUMNAS = "CodigoCarrera,NombreCarrera";
        //    listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
        //    listP.TABLA = "NV_CARRERAS";
        //    listP.ORDERBY = "order by NombreCarrera";

        //    if (Consultas.listarDatos(listP, ref dtCarreras, ref error))
        //    {
        //        if (dtCarreras.Rows.Count > 0)
        //        {
        //            clbCarreras.DataSource(dtCarreras, "CodigoCarrera", "NombreCarrera");
        //            clbCarreras.Index = -1;
        //        }
        //    }
        //    else
        //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        //private void CentrosCarreras()
        //{
        //    DataTable dtCarreras = new DataTable();
        //    Listado listP = new Listado();
        //    listP.COLUMNAS = "CodigoCarrera";
        //    listP.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
        //    listP.TABLA = "NV_CENTROS_CARRERAS";
        //    listP.FILTRO = "where CodigoCentro = '" + txtCodigo.Valor + "'";

        //    if (Consultas.listarDatos(listP, ref dtCarreras, ref error))
        //    {
        //        if (dtCarreras.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dtCarreras.Rows.Count; i++)
        //            {
        //                for (int j = 0; j < clbCarreras.Items.Count; j++)
        //                {
        //                    DataRow r = ((DataRowView)this.clbCarreras.Items[j]).Row;
        //                    if (dtCarreras.Rows[i][0].ToString() == clbCarreras.ValueMember(r))
        //                    {
        //                        clbCarreras.SetItemChecked(i, true);
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    else
        //        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}

        protected override void initInstance()
        {
            try
            {
                listar.TITULO_LISTADO = "Mantenimiento de Centros Académicos";
                lblPerfil.Text = "Perfil de Centro Académico";

                listar.COLUMNAS = "CodigoCentro,NombreCentro,DescripcionCentro";
                listar.COMPAÑIA = Consultas.sqlCon.COMPAÑIA;
                listar.TABLA = "NV_CENTROS";
                identificadorFormulario = "De Centros";
                //COLUMNAS PRIMARY KEY
                listar.COLUMNAS_PK.Add("CodigoCentro");
                listar.VALORES_PK = valoresPk;
                armarFiltroPK(valoresPk);

                insertar = Constantes.CENTROS_ACADEMICOS_INSERTAR;
                editar = Constantes.CENTROS_ACADEMICOS_EDITAR;
                borrar = Constantes.CENTROS_ACADEMICOS_BORRAR;
                seleccionar = Constantes.CENTROS_ACADEMICOS_SELECCIONAR;

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

                if (valoresPk.Count > 0)
                {
                    if (Consultas.listarDatos(listar, ref dtDatos, ref error))
                    {
                        if (dtDatos.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtDatos.Rows)
                            {
                                txtNombre.Valor = row["NombreCentro"].ToString();
                                txtCodigo.Valor = row["CodigoCentro"].ToString();
                                txtCodigo.ReadOnly = true;
                                rtbDescripcion.Text = row["DescripcionCentro"].ToString();
                                lblPerfil.Text = "Perfil de Centro Académico: " + txtNombre.Valor;
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
            parametros.Add(rtbDescripcion.Text);
            return true;
        }

        //protected override bool guardarDetalle(ref string error)
        //{
        //    bool OK = true;
        //    string sQuery = "";
        //    sQuery = "DELETE FROM NV_CENTROS_CARRERAS WHERE CodigoCentro='" + txtCodigo.Valor + "'";
        //    OK = Consultas.ejecutarSentencia(sQuery, ref error);

        //    if (OK)
        //    {
        //        sQuery = "INSERT INTO NV_CENTROS_CARRERAS (CodigoCentro,CodigoCarrera) " +
        //            "VALUES (@CodigoCentro,@CodigoCarrera)";

        //        for (int i = 0; i < clbCarreras.CheckedItems.Count; i++)
        //        {
        //            parametros.Clear();
        //            parametros.Add("@CodigoCentro," + txtCodigo.Valor);
        //            DataRow r = ((DataRowView)this.clbCarreras.CheckedItems[i]).Row;
        //            parametros.Add("@CodigoCarrera," + this.clbCarreras.ValueMember(r));

        //            OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

        //            if (!OK)
        //                break;
        //        }
        //    }

        //    return OK;
        //}

        protected override bool validarDatos(ref string error)
        {
            if (txtCodigo.Valor.Trim() == "")
            {
                error = "Debe especificar un código para el Centro Académico.";
                txtCodigo.Focus();
                return false;
            }
            if (txtNombre.Valor.Trim() == "")
            {
                error = "Debe especificar un nombre para el Centro Académico.";
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        protected override void limpiarFormulario()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.ReadOnly = false;
            rtbDescripcion.Clear();
            listar.VALORES_PK.Clear();
            lblPerfil.Text = "Perfil de Centro Académico";
        }

        protected override void deshabilitarLlave()
        {
            listar.VALORES_PK.Clear();
            listar.VALORES_PK.Add(txtCodigo.Valor);
            txtCodigo.ReadOnly = true;
            armarFiltroPK(listar.VALORES_PK);
            lblPerfil.Text = "Perfil de Centro Académico: " + txtNombre.Valor;
        }
    }
}
