using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Ciudad.prestaciones
{
    public partial class Frmtabla : Form
    {
        public Frmtabla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (usuarioEntities db = new usuarioEntities())
            {
                var r = from d in db.Db_proviincias
                        select d;
                db.SaveChanges();
            }
        }
    }
}
