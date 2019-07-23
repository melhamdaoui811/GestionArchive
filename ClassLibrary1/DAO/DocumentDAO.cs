using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using Models;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace DAO
{
    public class DocumentDAO
    {
        private SqlConnection connection;

        public DocumentDAO()
        {
            connection = Singleton.GetInstance().GetConnection();
        }

        public Document GetDocument(int idDocument)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var document = db.Query("Document").Where("IdDocument", idDocument).FirstOrDefault<Document>();
                return document;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Document DAO Get Document : " + ex.Message);
                return null;
            }
        }

        public IEnumerable<Document> GetDocuments()
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var documents = db.Query("Document").Select("IdDocument", "FichPath", "TypeDocument").Get<Document>();
                if (documents.Count() == 0)
                    return null;
                return documents;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Document DAO Get Documents : " + ex.Message);
                return null;
            }
        }

        public int UpdateDocument(Document document)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var rs = db.Query("Document").Where("IdDocument", document.IdDocument).Update(new
                {
                    document.FichPath,
                    document.TypeDocument,
                    document.Etudiant.IdEtudiant
                });
                return rs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Document DAO Update : " + ex.Message);
                return 0;
            }
        }

        public int DeleteDocument(int idDocument)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var rs = db.Query("Document").Where("IdDocument", idDocument).Delete();
                return rs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Document DAO Delete : " + ex.Message);
                return 0;
            }
        }

        public int InsertDocument(Document document)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var rs = db.Query("Document").Insert(new
                {
                    document.FichPath,
                    document.TypeDocument,
                    document.Etudiant.IdEtudiant
                });
                return rs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Document DAO Insert : " + ex.Message);
                return 0;
            }
        }
    }
}
