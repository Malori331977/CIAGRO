using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOLEGIO
{
    /// <summary>
    /// Utilidades comunes para un datagridview control 
    /// </summary>
    class DataGridViewUtilidades
    {

        #region miembros

        private DataGridView _dgv;
        private List<String> _columnasMayuscula;
        private List<String> _lstColumnasOblitagatorias;

        #endregion

        #region Propiedades

        public List<String> ListaColumnasOblitarias
        {
            set { this._lstColumnasOblitagatorias = value; }
        }

        public DataGridView Dgv
        {
            get { return _dgv; }
            set { _dgv = value; }
        }

        #endregion

        #region Constructores

        public DataGridViewUtilidades()
        {
            
        }        

        /// <summary>
        /// Grid a exteneder
        /// </summary>
        /// <param name="dgv">DataGrid a exteneder funcionalidad</param>
        /// <param name="columnasMayuscula">Nombre de las columnas a convertir en mayuscula</param>
        public DataGridViewUtilidades(ref DataGridView dgv,List<String> columnasMayuscula)
        {
            this._dgv = new DataGridView();
            this._dgv = dgv;
            this._columnasMayuscula = columnasMayuscula;
            this._dgv.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
        }        
        #endregion

        #region Metodos

        /// <summary>
        /// verifica si un valor existe en toda las filas de una columna
        /// </summary>
        /// <param name="valor">String a consultar</param>
        /// <param name="columna">Columna en la que desea buscar el registro</param>
        /// <param name="dgv">DataGridView a buscar</param>
        public Boolean ConsultaValorColumna(String valor,String columna, ref DataGridView dgv)
        {
            foreach (DataGridViewRow gr in dgv.Rows)
            {
                if (gr.Cells[columna].Value.ToString() == valor.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// verifica si un valor existe en toda las filas de una columna, si TRUE entonces reemplazar
        /// </summary>
        /// <param name="valor">String a consultar</param>
        /// <param name="columna">Columna en la que desea buscar el registro</param>
        /// <param name="nuevoValor">Valor a asignar en celda (x,y) encotrada</param>
        /// <param name="columnaReemplazar">Valor a asignar en celda de la columna (columnaReemplazar) [opcional]</param>
        /// <param name="dgv">DataGridView a buscar</param>
        public Boolean ConsultaValorColumnaReemplaza(String valor, String columna, String nuevoValor,String columnaReemplazar, ref DataGridView dgv)
        {
            foreach (DataGridViewRow gr in dgv.Rows)
            {
                if (gr.Cells[columna].Value.ToString() == valor.Trim())
                {
                    if (columnaReemplazar == "")
                    {
                        gr.Cells[columna].Value = nuevoValor;
                        return true;
                    }
                    else
                    {
                        gr.Cells[columnaReemplazar].ReadOnly = false;
                        gr.Cells[columnaReemplazar].Value = nuevoValor;
                        gr.Cells[columnaReemplazar].ReadOnly = true;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Elimina la linea o lineas seleccionadas de un grid
        /// </summary>
        public void EliminarLineasSeleccionadas()
        {

            /*El grid debe tener lineas*/
            if (this._dgv.Rows.Count > 0)
            {
                /*Verifica si desea eliminar una linea o una seleccion de lineas*/

                DataGridViewSelectedRowCollection Seleccionados = this._dgv.SelectedRows;
                foreach (DataGridViewRow item in Seleccionados)
                {
                  
                }

            }
            else
            {
                MessageBox.Show("No existen líneas para eliminar", "Información a usuario", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }


        public Boolean ValidaColumnasObligatorias(ref String msgVerificacion)
        {
            msgVerificacion = "";
            Boolean _continuar = false;


            /*Si valores null en cualquier columna entonces pasar a "" */
            foreach (DataGridViewColumn columnHeader in this._dgv.Columns)
            {
                foreach (DataGridViewRow gr in this._dgv.Rows)
                {
                    gr.Cells[columnHeader.Name].Value = gr.Cells[columnHeader.Name].Value == null ? "" :
                                                        gr.Cells[columnHeader.Name].Value;
                }
            }

            foreach(var linea in this._lstColumnasOblitagatorias)
            {

                //verifica si la el name de la columna existe en la lista string que se indico como columna obligatoria
                foreach (DataGridViewColumn  columnHeader in this._dgv.Columns)
                {
                    if (columnHeader.Name == linea)
                    {
                        /*Se valida que la columan obligatoria no este en blanco, esto debido a que el primer form
                         elimina todos los null y deja una cadena vacida en su lugar en la celda*/
                        foreach (DataGridViewRow gr in this._dgv.Rows)
                        {
                            /*si es la celda es null se sobre entiende que no se digito nada*/
                            if (gr.Cells[columnHeader.Name].Value =="")
                            {
                                msgVerificacion += "\nColumna: " + columnHeader.HeaderText + 
                                                    "   Fila : " + (gr.Index + 1).ToString() + "";
                                _continuar = true;
                            }
                        }
                    }
                }
            }
            return _continuar;
        }


        /// <summary>
        /// Finaliza el modo edicion de una celda, invoca su metodo para salir de edicion y pasar los cambios 
        /// fisicos al grid en cuestion
        /// </summary>
        /// <param name="dtg">DataGridView Control</param>
        public void CellEndEdit(ref DataGridView dtg)
        {
            if (dtg.Rows.Count > 0)
                dtg.EndEdit();
        }

       
        /// <summary>
        /// Convierte el contenido de una celda a MAYUSCULA
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">Paramentro tipo evento</param>
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            this._dgv = (DataGridView)sender;
            if (e.Control is TextBox)
            {
                //Asigna todas las columnas en estado Normal.
                foreach (var col in this._columnasMayuscula)
                {
                   ((TextBox)e.Control).CharacterCasing = CharacterCasing.Normal;
                }

                //Se recorre todas las columnas que se desean covertir en mayuscula
                foreach (var col in this._columnasMayuscula)
                {
                    if (this._dgv.CurrentCell.OwningColumn.Name.Equals(col))
                    {
                        ((TextBox)e.Control).CharacterCasing = CharacterCasing.Upper;
                        break;
                    }
                }

            }
        }

        /// <summary>
        /// JVG
        /// </summary>
        /// <param name="columnaBusqueda">Columna la cual se debe evitar valores duplicados</param>
        /// <param name="valorBusqueda">Valor a localizar en la columna</param>
        /// <returns></returns>
        public Boolean EvitaRegistroDuplicado(String columnaBusqueda, String valorBusqueda)
        {
            try
            {
                IEnumerable<DataGridViewRow> rows =
                                             from DataGridViewRow row in this._dgv.Rows
                                             where row.Cells[columnaBusqueda].Value != null && row.Cells[columnaBusqueda].Value.ToString().Equals(valorBusqueda)
                                             select row;
                if (!rows.Any())
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw new Exception("No es posible evaluar datos duplicados en la cuadrícula.");
            }
           
            return false;
        }

        /// <summary>
        /// JVG
        /// Evita que existan lineas en blanco en la cuadricula
        /// </summary>
        /// <param name="columnaBusqueda">Columna utilizada como punto de referencia para ubicar regitros null o en blanco</param>
        /// <returns>Boolean</returns>
        public Boolean EvitaFilaAnteriorVacia(String columnaBusqueda,String valorEsperado="")
        {
            try
            {
                if (this._dgv.Rows.Count == 0)
                {
                    return true;
                }
                else if (this._dgv.Rows.Count > 0)
                {
                    //Verifica si la celda de línea anterior a ultima linea del grid, tiene un dato, en la columna que se recibe como parametro
                    //de lo contrario notificar al usuario que no es posible continuar agregando lineas
                    if (this._dgv.Rows[this._dgv.Rows.Count - 1].Cells[columnaBusqueda].Value == null || this._dgv.Rows[this._dgv.Rows.Count - 1].Cells[columnaBusqueda].Value.ToString()=="")
                    {
                        return false;
                    }
                    else
                    { 
                        if(valorEsperado!="")
                        {
                            /*Verifica si de la celda anterior a la actaul de una determinada columnas cumple el valor esperado por el usuario*/
                            var valorFilaColumna = this._dgv.Rows[this._dgv.Rows.Count - 1].Cells[columnaBusqueda].Value.ToString();
                            switch (valorEsperado)
                            {
                                case "numero":
                                    if (!Utilitario.EsNumeroMayorCero(valorFilaColumna))
                                    {
                                        return false;
                                    }
                                    break;

                                case "fecha":
                                    if (!Utilitario.EsFecha(valorFilaColumna))
                                    {
                                        return false;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No es posible validar líneas en blanco en este momento\nPor favor verifique:" + ex.Message);
            }
        
            return true;
        }

        public Boolean EvitaFilaAnteriorVaciaBlancoNull(String columnaBusqueda, String valorEsperado = "")
        {
            try
            {
                if (this._dgv.Rows.Count == 0)
                {
                    return true;
                }
                else if (this._dgv.Rows.Count > 0)
                {
                    //Verifica si la celda de línea anterior a ultima linea del grid, tiene un dato, en la columna que se recibe como parametro
                    //de lo contrario notificar al usuario que no es posible continuar agregando lineas
                    if (this._dgv.Rows[this._dgv.Rows.Count - 1].Cells[columnaBusqueda].Value == null ||
                        this._dgv.Rows[this._dgv.Rows.Count - 1].Cells[columnaBusqueda].Value.ToString()=="")
                    {
                        return false;
                    }
                    else
                    {
                        if (valorEsperado != "")
                        {
                            /*Verifica si de la celda anterior a la actaul de una determinada columnas cumple el valor esperado por el usuario*/
                            var valorFilaColumna = this._dgv.Rows[this._dgv.Rows.Count - 1].Cells[columnaBusqueda].Value.ToString();
                            switch (valorEsperado)
                            {
                                case "numero":
                                    if (!Utilitario.EsNumeroMayorCero(valorFilaColumna))
                                    {
                                        return false;
                                    }
                                    break;

                                case "fecha":
                                    if (!Utilitario.EsFecha(valorFilaColumna))
                                    {
                                        return false;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No es posible validar líneas en blanco en este momento\nPor favor verifique:" + ex.Message);
            }

            return true;
        }

        /// <summary>
        /// JVG
        /// Verifica si lo digita por el usuario cumple con la mascara de celda esperada
        /// </summary>
        /// <param name="sender">objeto que disparo el evento</param>
        /// <param name="e">variable con propiedades de evento</param>
        public void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }

        #endregion

    }
}
