using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Ciudad
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(usuarioEntities db = new usuarioEntities())
            {
                DialogResult rppta = MessageBox.Show("¿Desea Guardar Usuario?",
                    "!! Menssage !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Db_proviincias oprovincia = new Db_proviincias();
                oprovincia.NOMBRE = textBox1.Text;
                oprovincia.PROVINCIA= textBox2.Text;
                oprovincia.CODIGO = textBox3.Text;  
                db.Db_proviincias.Add(oprovincia);
                db.SaveChanges();
                MessageBox.Show("!!!! Guardado Exictosamente !!!!");
                li();
            }
            
        }

        private void li()
        {
           // textBox1.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            li();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        // private void label3_Clickbject sender, EventArgs e)
        //{

        //}
    }
}
