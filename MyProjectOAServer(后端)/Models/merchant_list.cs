namespace MyProjectOAServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.merchant list")]
    public partial class merchant_list
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public merchant_list()
        {
            commodity_list = new HashSet<commodity_list>();
        }

        public int Id { get; set; }

        [Column("Name of merchant")]
        [Required]
        [StringLength(64)]
        public string Name_of_merchant { get; set; }

        [Column("Business contact number")]
        [Required]
        [StringLength(64)]
        public string Business_contact_number { get; set; }

        [Column("Shop name")]
        [Required]
        [StringLength(64)]
        public string Shop_name { get; set; }

        [Column("Shop address")]
        [Required]
        [StringLength(128)]
        public string Shop_address { get; set; }

        [Column("Longitude of store address")]
        [Required]
        [StringLength(64)]
        public string Longitude_of_store_address { get; set; }

        [Column("Store address latitude")]
        [Required]
        [StringLength(64)]
        public string Store_address_latitude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<commodity_list> commodity_list { get; set; }
    }
}
