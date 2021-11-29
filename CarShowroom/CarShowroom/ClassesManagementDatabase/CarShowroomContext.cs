using System;
using CarShowroom.ClassesManagementDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarShowroom
{
    public partial class CarShowroomContext : DbContext
    {
        private const string _connect = "Host=localhost;Port=5432;Database=carshowroom;Username=postgres;Password=srKUW2001";
        public CarShowroomContext()
        {
        }

        public CarShowroomContext(DbContextOptions<CarShowroomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Eventslog> Eventslogs { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<TypeAccessory> TypeAccessories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connect);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Accessory>(entity =>
            {
                entity.ToTable("accessories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.NameAccessory)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name_accessory");

                entity.Property(e => e.Price).HasColumnName("price");


                entity.Property(e => e.TypeAccessoryId).HasColumnName("type_accessory_id");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Accessories)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("accessories_car_id_fkey");

                entity.HasOne(d => d.TypeAccessory)
                    .WithMany(p => p.Accessories)
                    .HasForeignKey(d => d.TypeAccessoryId)
                    .HasConstraintName("accessories_type_accessory_id_fkey");
            });

            modelBuilder.Entity<Eventslog>(entity =>
            {
                entity.ToTable("eventslog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .HasColumnName("type");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Event).HasColumnName("event");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Eventslogs)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("eventslog_employee_id_fkey");

            });

            modelBuilder.Entity<Bid>(entity =>
            {
                entity.ToTable("bid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .HasColumnName("type");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("bid_employee_id_fkey");

            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.HasIndex(e => e.Vin, "car_vin_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(100)
                    .HasColumnName("color");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasMaxLength(17)
                    .HasColumnName("vin");

                entity.Property(e => e.Mileage)
                    .HasMaxLength(500)
                    .HasColumnName("mileage");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("car_contract_id_fkey");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("car_equipment_id_fkey");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");

               // entity.HasIndex(e => e.PaymentId, "contract_payment_id_key")
                 //   .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");


                entity.Property(e => e.DateSale).HasColumnName("date_sale");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");


                entity.Property(e => e.CountMonthInstallment).HasColumnName("count_month_installment");

                entity.Property(e => e.InitialDonatMoney).HasColumnName("initial_donat_money");

                entity.Property(e => e.MonthlyPay).HasColumnName("monthly_pay");

                entity.Property(e => e.PayMethod)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pay_method");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("contract_customer_id_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("contract_employee_id_fkey");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fio");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Departament)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("departament");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fio");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("equipment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fuel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fuel");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.NameEquipment)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name_equipment");

                entity.Property(e => e.TypeDrive)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("type_drive");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("equipment_model_id_fkey");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Carbrand)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("carbrand");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("model");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.NameModel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name_model");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("model_manufacturer_id_fkey");
            });

            modelBuilder.Entity<TypeAccessory>(entity =>
            {
                entity.ToTable("type_accessory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameTypeAccessory)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name_type_accessory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
