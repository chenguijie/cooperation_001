namespace MyProjectOAServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.order form")]
    public partial class order_form
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order_form()
        {
            order_details = new HashSet<order_details>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int RiderId { get; set; }

        [Column("Order time")]
        [Required]
        [StringLength(64)]
        public string Order_time { get; set; }

        [Column("Delivery time")]
        [Required]
        [StringLength(64)]
        public string Delivery_time { get; set; }

        [Column("Service time")]
        [Required]
        [StringLength(64)]
        public string Service_time { get; set; }

        [Column("Name of shipper")]
        [Required]
        [StringLength(32)]
        public string Name_of_shipper { get; set; }

        [Column("Contact number")]
        [Required]
        [StringLength(64)]
        public string Contact_number { get; set; }

        [Column("Receiving address")]
        [Required]
        [StringLength(128)]
        public string Receiving_address { get; set; }

        [Column("Longitude of receiving address")]
        [Required]
        [StringLength(64)]
        public string Longitude_of_receiving_address { get; set; }

        [Column("Receiving address latitude")]
        [Required]
        [StringLength(64)]
        public string Receiving_address_latitude { get; set; }

        [Column("Red envelope deduction")]
        public int? Red_envelope_deduction { get; set; }

        [Column("Total order consumption")]
        public int Total_order_consumption { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_details> order_details { get; set; }

        public virtual riding_a_watch riding_a_watch { get; set; }

        public virtual usertable usertable { get; set; }
    }
}
