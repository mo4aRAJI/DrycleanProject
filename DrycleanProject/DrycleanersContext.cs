using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DrycleanProject;

public partial class DrycleanersContext : DbContext
{
    public DrycleanersContext()
    {
    }

    public DrycleanersContext(DbContextOptions<DrycleanersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Ordersummary> Ordersummaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DRYCLEANERS;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("addresses_pkey");

            entity.ToTable("addresses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address1)
                .HasMaxLength(150)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Passport).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.Passport).HasColumnName("passport");
            entity.Property(e => e.Discount)
                .ValueGeneratedOnAdd()
                .HasColumnName("discount");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("fullname");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(15)
                .HasColumnName("phonenumber");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Experience)
                .ValueGeneratedOnAdd()
                .HasColumnName("experience");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("fullname");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ItemId }).HasName("items_pkey");

            entity.ToTable("items");

            entity.Property(e => e.OrderId)
                .ValueGeneratedOnAdd()
                .HasColumnName("order_id");
            entity.Property(e => e.ItemId)
                .ValueGeneratedOnAdd()
                .HasColumnName("item_id");
            entity.Property(e => e.Clothtype)
                .HasMaxLength(50)
                .HasColumnName("clothtype");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.Fabrictype)
                .HasMaxLength(50)
                .HasColumnName("fabrictype");

            entity.HasOne(d => d.Order).WithMany(p => p.Items)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("items_order_id_fkey");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId)
                .ValueGeneratedOnAdd()
                .HasColumnName("address_id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("now()")
                .HasColumnName("date");
            entity.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("employee_id");
            entity.Property(e => e.Passport)
                .ValueGeneratedOnAdd()
                .HasColumnName("passport");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");

            entity.HasOne(d => d.Address).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_address_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_employee_id_fkey");

            entity.HasOne(d => d.PassportNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Passport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_passport_fkey");
        });

        modelBuilder.Entity<Ordersummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ordersummary");

            entity.Property(e => e.Адрес).HasMaxLength(150);
            entity.Property(e => e.ВидОдежды)
                .HasMaxLength(50)
                .HasColumnName("Вид одежды");
            entity.Property(e => e.ДатаПринятияЗаказа).HasColumnName("Дата принятия заказа");
            entity.Property(e => e.ИдентификаторЗаказа).HasColumnName("Идентификатор заказа");
            entity.Property(e => e.Название).HasMaxLength(50);
            entity.Property(e => e.ПаспортаКлиента).HasColumnName("№ паспорта клиента");
            entity.Property(e => e.СкидкаКлиента).HasColumnName("Скидка клиента (%)");
            entity.Property(e => e.СтажСотрудникаЛет).HasColumnName("Стаж сотрудника (лет)");
            entity.Property(e => e.СтатусЗаказа)
                .HasMaxLength(30)
                .HasColumnName("Статус заказа");
            entity.Property(e => e.СтоимостьУслугРуб).HasColumnName("Стоимость услуг (руб.)");
            entity.Property(e => e.ТелефонКлиента)
                .HasMaxLength(15)
                .HasColumnName("Телефон клиента");
            entity.Property(e => e.ТипТкани)
                .HasMaxLength(50)
                .HasColumnName("Тип ткани");
            entity.Property(e => e.ФиоКлиента)
                .HasMaxLength(50)
                .HasColumnName("ФИО клиента");
            entity.Property(e => e.ФиоСотрудника)
                .HasMaxLength(50)
                .HasColumnName("ФИО сотрудника");
            entity.Property(e => e.ЦветПредмета)
                .HasMaxLength(50)
                .HasColumnName("Цвет предмета");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
