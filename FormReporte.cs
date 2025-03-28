using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Empleados
{
    public partial class FormReporte : Form
    {
        List<reporteSueldo> reporteSueldos = new List<reporteSueldo>();
        List<Empleado> empleados = new List<Empleado>();
        List<Asistencia> asistencias = new List<Asistencia>();
        public FormReporte()
        {
            InitializeComponent();
        }

        private void cargarEmpleados()
        {
            EmpleadoArchivo empleadoArchivo = new EmpleadoArchivo();
            empleados = empleadoArchivo.Leer("../../Empleados.json");
        }

        private void cargarAsistencias()
        {
            AsistenciaArchivo asistenciaArchivo = new AsistenciaArchivo();
            asistencias = asistenciaArchivo.Leer("../../Asistencias.json");
        }


        private void buttonRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            cargarAsistencias();
            cargarEmpleados();
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            foreach (var empleado in empleados)
            {
                foreach (var asistencia in asistencias)
                {
                    if (empleado.noEmpleado == asistencia.noEmpleado)
                    {
                        reporteSueldo reportesueldo = new reporteSueldo();
                        reportesueldo.Nombre= empleado.nombre;
                        reportesueldo.SueldoTotal = empleado.sueldo * asistencia.HoraMes;
                        reportesueldo.Mes = asistencia.mes.ToString();
                        reporteSueldos.Add(reportesueldo);
                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reporteSueldos;
            dataGridView1.Refresh();
        }
    }
}
