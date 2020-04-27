namespace MyProjectOAServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.usertable")]
    public partial class usertable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usertable()
        {
            order_form = new HashSet<order_form>();
            user_receiving_address_table = new HashSet<user_receiving_address_table>();
        }

        public int Id { get; set; }

        [Column("Account number")]
        [Required]
        [StringLength(32)]
        public string Account_number { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        [Required]
        [StringLength(32)]
        public string UserName { get; set; }

        [Column("User head")]
        [StringLength(128)]
        public string User_head { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_form> order_form { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_receiving_address_table> user_receiving_address_table { get; set; }
    }
}
