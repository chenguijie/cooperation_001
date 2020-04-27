namespace MyProjectOAServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.riding a watch")]
    public partial class riding_a_watch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public riding_a_watch()
        {
            order_form = new HashSet<order_form>();
        }

        public int Id { get; set; }

        [Column("Name of rider")]
        [Required]
        [StringLength(32)]
        public string Name_of_rider { get; set; }

        [Column("Date of birth")]
        [Required]
        [StringLength(64)]
        public string Date_of_birth { get; set; }

        [Column("Date of entry")]
        [Required]
        [StringLength(64)]
        public string Date_of_entry { get; set; }

        [Column("Rider address")]
        [Required]
        [StringLength(128)]
        public string Rider_address { get; set; }

        [Column("Rider contact number")]
        [Required]
        [StringLength(64)]
        public string Rider_contact_number { get; set; }

        [Column("Photos of riders")]
        [StringLength(128)]
        public string Photos_of_riders { get; set; }

        [Column("Rider ID number")]
        [Required]
        [StringLength(64)]
        public string Rider_ID_number { get; set; }

        [Column("Rider income")]
        [Required]
        [StringLength(32)]
        public string Rider_income { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_form> order_form { get; set; }
    }
}
