using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOLEGIO.Clases
{
    public class Regimen
    {
        public int codigo;
        public string descripcion;

    }

    public class Situacion
    {
        public string moroso;
        public string omiso;
        public string estado;
        public string administracionTributaria;

    }

    public class Actividad
    {
        public string estado;
        public string tipo;
        public int codigo;
        public string descripcion;

    }

    public class PerfilHacienda
    {
        public string nombre;
        public string tipoIdentificacion;
        public Regimen regimen;
        public Situacion situacion;
        public List<Actividad> actividades;

    }
}
