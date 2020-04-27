namespace MyProjectOAServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.order details")]
    public partial class order_details
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [Column("Commodity Id")]
        public int Commodity_Id { get; set; }

        [Column("item pricing")]
        public int item_pricing { get; set; }

        [Column("Quantity of commodities")]
        public int Quantity_of_commodities { get; set; }

        [Column("Merchandise discount")]
        public int Merchandise_discount { get; set; }

        public virtual commodity_list commodity_list { get; set; }

        public virtual order_form order_form { get; set; }
    }
}
