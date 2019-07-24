using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ClassLibrary;
using Models;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace DAO
{
    public class EtudiantDAO
    {
        private SqlConnection connection;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public EtudiantDAO()
        {
            connection = Singleton.GetInstance().GetConnection();
        }

        /// <summary>
        /// This Function return an etudiant by idEtudiant
        /// </summary>
        /// <param name="idEtudiant"></param>
        /// <returns></returns>
        public Etudiant GetEtudiant(int idEtudiant)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var etudiant = db.Query("Etudiant").Where("IdEtudiant", idEtudiant).FirstOrDefault<Etudiant>();
                return etudiant;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etudiant DAO Get Etudiant : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get Etudiant by IdDocument
        /// </summary>
        /// <param name="IdEtudiant"></param>
        /// <returns></returns>
        public Etudiant GetEtudiantByIdDocuments(int IdDocument)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var etudiant = db.Query("Etudiant").Join("Document", "Etudiant.IdEtudiant", "Document.IdDocument")
                    .Where("Document.IdDocument", IdDocument).FirstOrDefault<Etudiant>();
                return etudiant;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etudiant DAO Get Etudiant : " + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// This Function return an etudiant by CNI
        /// </summary>
        /// <param name="CNI"></param>
        /// <returns></returns>
        public IEnumerable<Etudiant> GetEtudiantByCNI(string CNI)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var etudiant = db.Query("Etudiant").Where("Cni", CNI).Get<Etudiant>();
                return etudiant;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etudiant DAO Get Etudiant : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// This Function return an etudiant by CNE
        /// </summary>
        /// <param name="CNI"></param>
        /// <returns></returns>
        public IEnumerable<Etudiant> GetEtudiantByCNE(string CNE)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var etudiant = db.Query("Etudiant").Where("Cne", CNE).Get<Etudiant>();
                return etudiant;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etudiant DAO Get Etudiant : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// This Function return an etudiant by Massar
        /// </summary>
        /// <param name="CNI"></param>
        /// <returns></returns>
        public IEnumerable<Etudiant> GetEtudiantByMassar(string Massar)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var etudiant = db.Query("Etudiant").Where("Massar", Massar).Get<Etudiant>();
                return etudiant;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etudiant DAO Get Etudiant : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// This Function return all Etudiants
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Etudiant> GetEtudiants()
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var etudiants = db.Query("Etudiant").Get<Etudiant>();
                if (etudiants.Count() == 0)
                    return null;
                return etudiants;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etudiant DAO Get Etudiants : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// This function returns the number of lines are affected by update statement
        /// </summary>
        /// <param name="etudiant"></param>
        /// <returns></returns>
        public int UpdateEtudiant(Etudiant etudiant) 
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var rs = db.Query("Etudiant").Where("IdEtudiant", etudiant.IdEtudiant).Update(new
                {
                    etudiant.NomEtudiant,
                    etudiant.NomEtudiantArabe,
                    etudiant.PrenomEtudiant,
                    etudiant.PrenomEtudiantArabe,
                    etudiant.Cne,
                    etudiant.Cni,
                    etudiant.Massar,
                    etudiant.DateDeNaissance,
                    etudiant.DateInscription,
                    etudiant.LieuDeNaissance,
                    etudiant.LieuDeNaissanceArabe,
                    etudiant.Adresse,
                    etudiant.AdresseArabe,
                    etudiant.NumInsricption
                });
                return rs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etudiant DAO Update : " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This function returns the number of lines are affected by delete statement
        /// </summary>
        /// <param name="idEtudiant"></param>
        /// <returns></returns>
        public int DeleteEtudiant(int idEtudiant)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var rs = db.Query("Etudiant").Where("IdEtudiant", idEtudiant).Delete();
                return rs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etudiant DAO Delete : " + ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// This function returns the number of lines are affected by insert statement
        /// </summary>
        /// <param name="etudiant"></param>
        /// <returns></returns>
        public int InsertEtudiant(Etudiant etudiant)
        {
            try
            {
                SqlServerCompiler compiler = new SqlServerCompiler();
                var db = new QueryFactory(connection, compiler);
                var rs = db.Query("Etudiant").Insert(new
                {
                    etudiant.NomEtudiant,
                    etudiant.NomEtudiantArabe,
                    etudiant.PrenomEtudiant,
                    etudiant.PrenomEtudiantArabe,
                    etudiant.Cne,
                    etudiant.Cni,
                    etudiant.Massar,
                    etudiant.DateDeNaissance,
                    etudiant.DateInscription,
                    etudiant.LieuDeNaissance,
                    etudiant.LieuDeNaissanceArabe,
                    etudiant.Adresse,
                    etudiant.AdresseArabe,
                    etudiant.NumInsricption
                });
                return rs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Etudiant DAO Insert : " + ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
