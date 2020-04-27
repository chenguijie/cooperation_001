namespace MyProjectOAServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.class table")]
    public partial class class_table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public class_table()
        {
            commodity_list = new HashSet<commodity_list>();
        }

        public int Id { get; set; }

        [Column("Category name")]
        [Required]
        [StringLength(64)]
        public string Category_name { get; set; }

        [Column("Class description")]
        [Required]
        [StringLength(128)]
        public string Class_description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<commodity_list> commodity_list { get; set; }
    }
}
