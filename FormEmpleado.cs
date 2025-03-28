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
    public partial class FormEmpleado : Form
    {
        List <Empleado> empleados = new List<Empleado>();
        public FormEmpleado()
        {
            InitializeComponent();
        }

        private void buttonFAsistencia_Click(object sender, EventArgs e)
        {
            FormAsistencia formasistencia = new FormAsistencia();
            formasistencia.ShowDialog();
            ;
        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void Mostrar()
        {
            EmpleadoArchivo empleadoArchivo = new EmpleadoArchivo();
            empleados = empleadoArchivo.Leer("../../Empleados.json");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = empleados;
            dataGridView1.Refresh();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            empleado.noEmpleado = Convert.ToInt16(numericUpDown1.Value);
            empleado.nombre = textBox1.Text;
            empleado.sueldo = Convert.ToDecimal(maskedTextBox1.Text);
            empleados.Add(empleado);

            EmpleadoArchivo empleadoArchivo = new EmpleadoArchivo();
            empleadoArchivo.Guardar("../../Empleados.json", empleados);//Funcion guardar de clase EmpleadoArchivo
            Mostrar();

        }
    }
}
