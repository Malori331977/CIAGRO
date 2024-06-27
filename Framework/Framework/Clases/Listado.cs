using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Listado
    {
        string columnas = "";
        string tabla = "";
        string compañia = "";
        string filtro = "";
        string orderBy = "";
        string tituloListado = "";
        string select = "";
        string tablaEliminar = "";

        bool cambiarPK = false;
        List<string> columnasPK = new List<string>();
        List<string> columnasIdentityPK = new List<string>();
        List<string> columnasAliasPK = new List<string>();
        List<string> valoresPK = new List<string>();
        List<string> columnasUILFG = new List<string>();
        List<string> columnasNumericas = new List<string>();
        List<string> columnasPKfechas = new List<string>();
        List<string> columnasOcultas = new List<string>();
        List<string> columnasFechas = new List<string>();
        List<string> columnasNumericasINT = new List<string>();
        public Listado(string cols,string tab,string cia,string filt)
        {
            columnas = cols;
            tabla = tab;
            compañia = cia;
            filtro = filt;
        }

        public Listado()
        {

        }

        public string COLUMNAS
        {
            get { return columnas; }
            set { columnas = value; }
        }

        public string TABLA
        {
            get { return tabla; }
            set { tabla = value; }
        }

        public string TABLA_ELIMINAR
        {
            get { return tablaEliminar; }
            set { tablaEliminar = value; }
        }

        public string COMPAÑIA
        {
            get { return compañia; }
            set { compañia = value; }
        }

        public string FILTRO
        {
            get { return filtro; }
            set { filtro = value; }
        }

        public string ORDERBY
        {
            get { return orderBy; }
            set { orderBy = value; }
        }

        public string TITULO_LISTADO
        {
            get { return tituloListado; }
            set { tituloListado = value; }
        }

        public string SELECT
        {
            get { return select; }
            set { select = value; }
        }

        public bool CAMBIAR_PK
        {
            get { return cambiarPK; }
            set { cambiarPK = value; }
        }

        public List<string> COLUMNAS_PK
        {
            get { return columnasPK; }
            set { columnasPK = value; }
        }
        public List<string> COLUMNAS_IDENTITY_PK
        {
            get { return columnasIdentityPK; }
            set { columnasIdentityPK = value; }
        }

        public List<string> COLUMNAS_PK_FECHAS
        {
            get { return columnasPKfechas; }
            set { columnasPKfechas = value; }
        }

        public List<string> COLUMNAS_FECHAS
        {
            get { return columnasFechas; }
            set { columnasFechas = value; }
        }

        public List<string> COLUMNAS_OCULTAS
        {
            get { return columnasOcultas; }
            set { columnasOcultas = value; }
        }

        public List<string> COLUMNAS_ALIAS_PK
        {
            get { return columnasAliasPK; }
            set { columnasAliasPK = value; }
        }

        public List<string> VALORES_PK
        {
            get { return valoresPK; }
            set { valoresPK = value; }
        }

        public List<string> COLUMNAS_UILFG
        {
            get { return columnasUILFG; }
            set { columnasUILFG = value; }
        }

        public List<string> COLUMNAS_NUMERICAS
        {
            get { return columnasNumericas; }
            set { columnasNumericas = value; }
        }

        public List<string> COLUMNAS_NUMERICAS_INT
        {
            get { return columnasNumericasINT; }
            set { columnasNumericasINT = value; }
        }
    }
}
