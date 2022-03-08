using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class Avertissement
    {
        public int ID { get; set; }
        public virtual NetAtlasUser NetAtlasUser { get; set; }
        [ForeignKey("NetAtlasUser")]
        public string NetAtlasUserID { get; set; }
    }
}
