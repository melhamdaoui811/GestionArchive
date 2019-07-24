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
            dgvM.DataSource = null;
            var documents = new DocumentDAO().GetDocument(int.Parse(txtCNE.Text));
            dgvM.DataSource = documents;
           
        }


        private void FrmDocuments_Load(object sender, EventArgs e)
        {
           
            dgvM.DataSource = null;
            var documents = new DocumentDAO().GetDocuments();
            
            dgvM.DataSource = documents;
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeleteC_Click(object sender, EventArgs e)
        {
            var eDAO = new DocumentDAO();
            eDAO.DeleteDocument(int.Parse(dgvM.CurrentRow.Cells[0].Value.ToString()));
            dgvM.DataSource = null;
            var documents = new DocumentDAO().GetDocuments();
            foreach (var item in documents)
            {
                Console.WriteLine(item);
            }
            dgvM.DataSource = documents;
        }

        private void BtnModifierC_Click(object sender, EventArgs e)
        {
            int a = int.Parse(dgvM.CurrentRow.Cells[0].Value.ToString());
         
            try
            {

                var docDAO = new DocumentDAO();
                var document = docDAO.GetDocument(a);
                document.TypeDocument = txtPrenom.Text;
                document.FichPath = txtNom.Text;
                MessageBox.Show(document.Etudiant.NomEtudiant);
                return;
                docDAO.UpdateDocument(document);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnAddC_Click(object sender, EventArgs e)
        {
            Document doc = new Document(0, txtNom.Text,txtPrenom.Text);
            doc.Etudiant = new EtudiantDAO().GetEtudiantByCNE(txtCNE.Text).FirstOrDefault<Etudiant>();
            DocumentDAO docDAO = new DocumentDAO();
            int rs = docDAO.InsertDocument(doc);
            MessageBox.Show("COco");


          
        }
    }
}
