using System.ComponentModel.DataAnnotations.Schema;

namespace NetAtlas.Models
{
    public class DemandeDAmis
    {
       
        
        public int  ID { get; set; }

        
        public string Amis1ID{ get; set; }
        public string  Amis2ID { get; set; }

        public string Statut { get; set; }

      
    }
}