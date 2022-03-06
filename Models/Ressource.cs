using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class Ressource
    {
        
        public int ID { get; set; }
        public string NomRessource { get; set; } = "re";
        public virtual Publication Publication { get; set; }

        [ForeignKey("Publication")]
        public int PublicationID{ get; set; }


    }
}
