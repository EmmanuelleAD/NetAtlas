using Microsoft.AspNetCore.Identity;

namespace NetAtlas.Models

{
    public enum Statuts { EnAttente,Rejeté,Accepté}
    public class NetAtlasUser:IdentityUser
    {
        public string Nom { get; set; }
        public string Prenoms { get; set; }
        public string Statuts { get; set; } = "EnAttente"; 
        public  virtual ICollection <DemandeDAmis> ListeDemandes{ get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
