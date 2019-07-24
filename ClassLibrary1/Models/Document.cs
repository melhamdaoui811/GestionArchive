using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Models {
	public class Document {
        /// <summary>
        /// Attributes
        /// </summary>
		private int idDocument;
		private string fichPath;
		private string typeDocument;

        /// <summary>
        /// Associations
        /// </summary>
		private Etudiant etudiant;

        /// <summary>
        /// Default Contructor
        /// </summary>
        /// <param name="idDocument"></param>
        public Document(int idDocument, string fichPath, string typeDocument)
        {
            this.idDocument = idDocument;
            this.fichPath = fichPath;
            this.typeDocument = typeDocument;
        }

        /// <summary>
        /// This Contructor is made to initialize all attributes and associations
        /// </summary>
        /// <param name="idDocument"></param>
        /// <param name="fichPath"></param>
        /// <param name="typeDocument"></param>
        /// <param name="etudiant"></param>
        public Document(int idDocument, string fichPath, string typeDocument, Etudiant etudiant) : this(idDocument, fichPath, typeDocument)
        {
            this.etudiant = etudiant;
        }

        public int IdDocument
        {
            get { return idDocument; }
            set { idDocument = value; }
        }

        public string FichPath
        {
            get { return fichPath; }
            set { fichPath = value; }
        }

        public string TypeDocument
        {
            get { return typeDocument; }
            set { typeDocument = value; }
        }

        [Column(Name ="IdEtudiant")]
        public Etudiant Etudiant
        {
            get { return etudiant; }
            set { etudiant = value; }
        }

        public override string ToString()
        {
            return $"Id Document : {idDocument}, fich Path {fichPath}, type Document : {typeDocument}";
        }
    }

}
