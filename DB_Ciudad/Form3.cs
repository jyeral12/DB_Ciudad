using DB_Ciudad.prestaciones.pero;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            using(usuarioEntities db = new usuarioEntities())
            { 
                var l = from d in db.Db_proviincias
                        select d;   
                dataGridView1.DataSource = l.ToList();  
            }
        }
        private void ojo(string busqueda = null)
        {
         using(usuarioEntities b = new usuarioEntities()) 
            {
                IQueryable<prestaciones.pero.PersonaViewmodels> oo =
               from d in b.Db_proviincias
               select new PersonaViewmodels
               {
                   ID = d.ID,
                   Nombre = d.NOMBRE,
                   Provincia = d.PROVINCIA,
                   Codigo = d.CODIGO,

               };
                if(busqueda != null)
                {
                    oo = oo.Where(d =>d.Nombre ==busqueda);
                }
                dataGridView2.DataSource =oo.ToList();  
            }
        }

        private int? GetId()
        {
            try
            {
              return  int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return  null;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (usuarioEntities db = new usuarioEntities())
            {
                int? ID= GetId();
                DialogResult rppta = MessageBox.Show("¿Desea Eliminar this Username?",
                    "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ID != null)
                {
                    Db_proviincias otabla = db.Db_proviincias.Find(ID);
                    db.Db_proviincias.Remove(otabla);
                    db.SaveChanges();
                    refrescar();
                    MessageBox.Show("Eliminado Exictosamente");
                }
               else
                {

                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Trim().Equals(""))
                ojo(textBox1.Text.Trim());
                textBox1.Clear();
        }
        private void refrescar()
        {
            using (usuarioEntities db = new usuarioEntities())
            {
                var l = from d in db.Db_proviincias
                        select d;
                dataGridView1.DataSource = l.ToList();
            }
        }
    }
}
