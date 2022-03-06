using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class Publication
    {
        public int ID { get; set; }
       // public virtual NetAtlasUser Membre { get; set; }
      
        public  string MembreID { get; set; }
      //  [DataType(DataType.Date)]
      //  [DisplayFormat(DataFormatString = "{0:dd - MM - yyyy)}", ApplyFormatInEditMode = true)]
     //   public DateTime DatePublication { get; set; }=DateTime.Now; 
        public virtual ICollection<Ressource> Ressources { get;}
       
        public string statut { get; set; } = "EnAttente";
        public enum Statuts
        {
            EnAttente,Accepté,Signalé,
        }
    }
}
