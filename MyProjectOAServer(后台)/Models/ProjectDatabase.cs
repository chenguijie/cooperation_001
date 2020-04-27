namespace MyProjectOAServer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectDatabase : DbContext
    {
        public ProjectDatabase()
            : base("name=ProjectDatabase")
        {
        }

        public virtual DbSet<class_table> class_table { get; set; }
        public virtual DbSet<commodity_list> commodity_list { get; set; }
        public virtual DbSet<merchant_list> merchant_list { get; set; }
        public virtual DbSet<order_details> order_details { get; set; }
        public virtual DbSet<order_form> order_form { get; set; }
        public virtual DbSet<riding_a_watch> riding_a_watch { get; set; }
        public virtual DbSet<user_receiving_address_table> user_receiving_address_table { get; set; }
        public virtual DbSet<usertable> usertable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<class_table>()
                .Property(e => e.Category_name)
                .IsUnicode(false);

            modelBuilder.Entity<class_table>()
                .Property(e => e.Class_description)
                .IsUnicode(false);

            modelBuilder.Entity<class_table>()
                .HasMany(e => e.commodity_list)
                .WithRequired(e => e.class_table)
                .HasForeignKey(e => e.categoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<commodity_list>()
                .Property(e => e.Trade_name)
                .IsUnicode(false);

            modelBuilder.Entity<commodity_list>()
                .Property(e => e.Commodity_pictures)
                .IsUnicode(false);

            modelBuilder.Entity<commodity_list>()
                .Property(e => e.Commodity_Description)
                .IsUnicode(false);

            modelBuilder.Entity<commodity_list>()
                .HasMany(e => e.order_details)
                .WithRequired(e => e.commodity_list)
                .HasForeignKey(e => e.Commodity_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<merchant_list>()
                .Property(e => e.Name_of_merchant)
                .IsUnicode(false);

            modelBuilder.Entity<merchant_list>()
                .Property(e => e.Business_contact_number)
                .IsUnicode(false);

            modelBuilder.Entity<merchant_list>()
                .Property(e => e.Shop_name)
                .IsUnicode(false);

            modelBuilder.Entity<merchant_list>()
                .Property(e => e.Shop_address)
                .IsUnicode(false);

            modelBuilder.Entity<merchant_list>()
                .Property(e => e.Longitude_of_store_address)
                .IsUnicode(false);

            modelBuilder.Entity<merchant_list>()
                .Property(e => e.Store_address_latitude)
                .IsUnicode(false);

            modelBuilder.Entity<merchant_list>()
                .HasMany(e => e.commodity_list)
                .WithRequired(e => e.merchant_list)
                .HasForeignKey(e => e.Merchant_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order_form>()
                .Property(e => e.Order_time)
                .IsUnicode(false);

            modelBuilder.Entity<order_form>()
                .Property(e => e.Delivery_time)
                .IsUnicode(false);

            modelBuilder.Entity<order_form>()
                .Property(e => e.Service_time)
                .IsUnicode(false);

            modelBuilder.Entity<order_form>()
                .Property(e => e.Name_of_shipper)
                .IsUnicode(false);

            modelBuilder.Entity<order_form>()
                .Property(e => e.Contact_number)
                .IsUnicode(false);

            modelBuilder.Entity<order_form>()
                .Property(e => e.Receiving_address)
                .IsUnicode(false);

            modelBuilder.Entity<order_form>()
                .Property(e => e.Longitude_of_receiving_address)
                .IsUnicode(false);

            modelBuilder.Entity<order_form>()
                .Property(e => e.Receiving_address_latitude)
                .IsUnicode(false);

            modelBuilder.Entity<order_form>()
                .HasMany(e => e.order_details)
                .WithRequired(e => e.order_form)
                .HasForeignKey(e => e.OrderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<riding_a_watch>()
                .Property(e => e.Name_of_rider)
                .IsUnicode(false);

            modelBuilder.Entity<riding_a_watch>()
                .Property(e => e.Date_of_birth)
                .IsUnicode(false);

            modelBuilder.Entity<riding_a_watch>()
                .Property(e => e.Date_of_entry)
                .IsUnicode(false);

            modelBuilder.Entity<riding_a_watch>()
                .Property(e => e.Rider_address)
                .IsUnicode(false);

            modelBuilder.Entity<riding_a_watch>()
                .Property(e => e.Rider_contact_number)
                .IsUnicode(false);

            modelBuilder.Entity<riding_a_watch>()
                .Property(e => e.Photos_of_riders)
                .IsUnicode(false);

            modelBuilder.Entity<riding_a_watch>()
                .Property(e => e.Rider_ID_number)
                .IsUnicode(false);

            modelBuilder.Entity<riding_a_watch>()
                .Property(e => e.Rider_income)
                .IsUnicode(false);

            modelBuilder.Entity<riding_a_watch>()
                .HasMany(e => e.order_form)
                .WithRequired(e => e.riding_a_watch)
                .HasForeignKey(e => e.RiderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user_receiving_address_table>()
                .Property(e => e.Name_of_shipper)
                .IsUnicode(false);

            modelBuilder.Entity<user_receiving_address_table>()
                .Property(e => e.Receiving_address)
                .IsUnicode(false);

            modelBuilder.Entity<user_receiving_address_table>()
                .Property(e => e.Longitude_of_receiving_address)
                .IsUnicode(false);

            modelBuilder.Entity<user_receiving_address_table>()
                .Property(e => e.Receiving_address_latitude)
                .IsUnicode(false);

            modelBuilder.Entity<usertable>()
                .Property(e => e.Account_number)
                .IsUnicode(false);

            modelBuilder.Entity<usertable>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<usertable>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<usertable>()
                .Property(e => e.User_head)
                .IsUnicode(false);

            modelBuilder.Entity<usertable>()
                .HasMany(e => e.order_form)
                .WithRequired(e => e.usertable)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usertable>()
                .HasMany(e => e.user_receiving_address_table)
                .WithRequired(e => e.usertable)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
