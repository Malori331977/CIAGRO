using Framework;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KOLEGIO.Edicion
{
    public partial class frmSuspension: Form
    {
        private string IdColegiado;
        private string Usu;
        public frmSuspension(string Colegiado, string usuario)
        {
            IdColegiado = Colegiado;
            InitializeComponent();

            dtpFechaInicial.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
            Usu = usuario;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSuspension_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar_Click(sender, e);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<string> parametros = new List<string>();
            bool OK = true;
            string error = "";
            if (txtTipoSuspension.Valor.Trim().Equals(""))
            {
                MessageBox.Show("El tipo de suspensión es un campo requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTipoSuspension.Focus();
                return;
            }
            if (txtNumeroResolución.Valor.Trim().Equals(""))
            {
                MessageBox.Show("El número de resolución es un campo requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNumeroResolución.Focus();
                return;
            }


            try
            {
                string sQuery = "INSERT INTO " + Consultas.sqlCon.COMPAÑIA + ".NV_COLEGIADO_SUSPENSIONES (IdColegiado, TipoSuspension, NumeroResolucion, FechaInicio, FechaFinal, UsuarioCreacionAdmin, FechaCreacionAdmin) " +
                    "VALUES (@IdColegiado, @TipoSuspension, @NumeroResolucion, @FechaInicio, @FechaFinal, @UsuarioCreacionAdmin, @FechaCreacionAdmin)";

                parametros.Clear();
                parametros.Add("@IdColegiado," + IdColegiado);
                parametros.Add("@TipoSuspension," + txtTipoSuspension.Valor.ToString());
                parametros.Add("@NumeroResolucion," + txtNumeroResolución.Valor.ToString());
                parametros.Add("@FechaInicio," + dtpFechaInicial.Value.ToString("yyyy-MM-dd"));
                parametros.Add("@FechaFinal," + dtpFechaFinal.Value.ToString("yyyy-MM-dd"));
                parametros.Add("@UsuarioCreacionAdmin," + Usu);
                parametros.Add("@FechaCreacionAdmin," + DateTime.Now.ToString("yyyy-MM-dd"));


                OK = Consultas.ejecutarSentenciaParametros(sQuery, parametros, ref error);

                if (OK)
                    Close();
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
