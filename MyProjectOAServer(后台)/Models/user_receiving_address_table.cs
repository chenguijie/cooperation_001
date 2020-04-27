namespace MyProjectOAServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.user receiving address table")]
    public partial class user_receiving_address_table
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Column("Name of shipper")]
        [Required]
        [StringLength(32)]
        public string Name_of_shipper { get; set; }

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

        public virtual usertable usertable { get; set; }
    }
}
