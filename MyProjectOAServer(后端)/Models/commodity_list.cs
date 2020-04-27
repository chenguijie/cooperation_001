namespace MyProjectOAServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.commodity list")]
    public partial class commodity_list
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public commodity_list()
        {
            order_details = new HashSet<order_details>();
        }

        public int Id { get; set; }

        [Column("Merchant Id")]
        public int Merchant_Id { get; set; }

        public int categoryId { get; set; }

        [Column("Trade name")]
        [Required]
        [StringLength(64)]
        public string Trade_name { get; set; }

        [Column("Commodity pictures")]
        [StringLength(128)]
        public string Commodity_pictures { get; set; }

        [Column("Commodity Description")]
        [StringLength(128)]
        public string Commodity_Description { get; set; }

        [Column("item pricing")]
        public int item_pricing { get; set; }

        [Column("Merchandise discount")]
        public int Merchandise_discount { get; set; }

        [Column("Commodity inventory")]
        public int Commodity_inventory { get; set; }

        [Column("Order quantity")]
        public int Order_quantity { get; set; }

        public virtual class_table class_table { get; set; }

        public virtual merchant_list merchant_list { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_details> order_details { get; set; }
    }
}
