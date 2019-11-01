using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoundRobinSO
{
    public partial class Form1 : Form
    {
        Competencia competencia;

        public Form1()
        {
            InitializeComponent();
            competencia = new Competencia();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numero = (int)numericUpDown1.Value;
            competencia.mostrarPartidos(competencia.calcularLiga(numero), ref textBox1);
        }
    }
}
