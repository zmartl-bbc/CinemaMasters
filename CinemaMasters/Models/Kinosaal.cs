//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaMasters.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kinosaal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kinosaal()
        {
            this.FilmHasKinosaal = new HashSet<FilmHasKinosaal>();
            this.Reihe = new HashSet<Reihe>();
        }
    
        public int Id { get; set; }
        public int AnzahlReihe { get; set; }
        public int AnzahlPlaetze { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FilmHasKinosaal> FilmHasKinosaal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reihe> Reihe { get; set; }
    }
}
