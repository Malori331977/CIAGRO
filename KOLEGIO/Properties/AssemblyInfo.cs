using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("KOLEGIO")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("KOLEGIO")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5b188bce-3d96-4d2a-87cf-853271584609")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.38")]
[assembly: AssemblyFileVersion("1.0.0.38")]
//1.0.0.3--Arreglo consulta en el proceso de cobros de regencias
//1.0.0.4--Proceso cobros masivos cobrador(90%)
//1.0.0.5--Algunos detalles vistos en sesion 15/02/2019
//1.0.0.6--La mayoria de detalles vistos en sesion 15/02/2019
//1.0.0.7--Se arreglo la carga de campos de accion y profesionales en consultoras (Se esta trabajando en los procesos de cobros y adelantos) 
//1.0.0.8--Se terminaron los procesos de cobros y adelantos con la fecha del ultimo cobro y pedido por concepto
//1.0.0.9--Proceso de cobros masivos por cobrador depurado / Falta cargar los archivos xls sin encabezados 
//1.0.0.10--No se ha solucionado la carga de xls / Se cambio el uso del cobrador en todos los procesos 
//1.0.0.11--Se agrego el mantenimiento para tipos de regentes y peritos
//1.0.0.12--Se atendieron los detalles en verde del Doc DetallesFaltantes
//1.0.0.13--Queda faltante los puntos (22,20,11,12,13,14,9)
//1.0.0.14--Solucion error en adelanto de cobros
//1.0.0.15--Pedidos desde colegiados, cambio de condicion con acceso desde colegiados, cambios en histLaboral y academico, configurables de condicion
//1.0.0.16--Fin detalles pendientes(Levantamiento,proceso cobros,etc..), primeros reportes incorporados(Establecimientos, consultoras cerradas, ficha colegiado, etc..)
//1.0.0.17--Procesos Anuales, cambios en pedidos por IVA(Se agrego ingreso de campos impuesto1)
//1.0.0.18--Actualización de procesos de cobros, generar archivos de celulares, arreglo en informes de establecimientos
//1.0.0.19--Se añadio proceso de cambio de categoria
//1.0.0.20--Se arreglo un error en colegiados luego de hacer algunos cambios, se cambio el lbl de sesion aprobacion a sesion incorporacion
//1.0.0.21--Se agrego la suma de los arreglos de pagos en los archivos de cobro,cambio de estado a los regentes que tengan estado cierre y temporal
//1.0.0.22--Se ordeno asc los informes del establecimiento al cargar y solucionar error al hacer click y mouseDobleclick en todos los edicion con dgvs vacios 
//1.0.0.23--Se hizo el arreglo para agregar la categoriaCliente al crear el colegiado,estable o consultora al ERP
//1.0.0.24--Se quito el campo ajuste fondo de la lista beneficiarios y el grbtituloObligatorio se puso que se haga invisible si no se requiere
//1.0.0.25--Se soluciono error en consultoras al eliminar campos o colegiados y se inicio con los menus de filtros de reportes
//1.0.0.26--Cambios en el nombre del puesto que sea de 200 caracteres y se agrego check en fecha hasta de hist laboral
//1.0.0.27--Se agrego mantenimiento de vida silvestre y tab en colegiados, se agregaron primeros filtros en reportes
//1.0.0.28--Se agrego funcionalidad de modificar laboral y academico
//1.0.0.29--Se agregaron los filtros de reportes individuales, se soluciono error en ingresar regente y se empezo con la implementacion del FTP
//1.0.0.30--Inclusion de control de versiones
//1.0.0.31--Se agrego listado de adelantos gestion de cobro y se aumento el tamaño del campo empresa
//1.0.0.32--Reportes faltantes y modificacion de existentes, solucion problema con cambio de numero colegiado(se asigna en el proceso de cambio de categoria), Funcionalidad de historial de estados de regencias
//1.0.0.33--Solucion Error en historial de regencias y en cambio de estado de regencia
//1.0.0.34--Totalizar plantillas, cambios en informes, se agrego configuracion de condicion pago para canones anuales
//1.0.0.35--Se cambio la generacion de pedidos a facturas
//1.0.0.36--Se agrego bitacora de cambios
//1.0.0.37--Reportes en linea, fixes
//1.0.0.38--Fix error al abrir o modificar beneficiarios