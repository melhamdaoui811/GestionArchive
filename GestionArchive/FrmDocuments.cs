using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAO;

namespace GestionArchive
{
    public partial class FrmDocuments : Form
    {
        public FrmDocuments()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }


        private void FrmDocuments_Load(object sender, EventArgs e)
        {
            dgvM.DataSource = null;
            var documents = new DocumentDAO().GetDocuments();
            foreach (var item in documents)
            {
                Console.WriteLine(item);
            }
            dgvM.DataSource = documents;
        }
    }
}
