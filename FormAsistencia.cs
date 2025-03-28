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
    public partial class FormAsistencia : Form
    {
        List<Asistencia> asistencias=new List<Asistencia>(); // lista de asistencias clase

        public FormAsistencia()
        {
            InitializeComponent();
        }
        
        private void Mostrar()
        {
            AsistenciaArchivo asistenciaArchivo = new AsistenciaArchivo();
            asistencias = asistenciaArchivo.Leer("../../Asistencias.json");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = asistencias;
            dataGridView1.Refresh();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAsistencia_Load(object sender, EventArgs e)
        {
            List<Empleado> empleados = new List<Empleado>();
            EmpleadoArchivo empleadoArchivo = new EmpleadoArchivo();
            empleados = empleadoArchivo.Leer("../../Empleados.json");
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "noEmpleado";
            comboBox1.DataSource = empleados;
        }
    }
}
