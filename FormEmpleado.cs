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
    }
}
