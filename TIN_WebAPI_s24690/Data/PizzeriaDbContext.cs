using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TIN_WebAPI_s24690.Models;

namespace TIN_WebAPI_s24690.Data;

public partial class PizzeriaDbContext : DbContext
{
    public PizzeriaDbContext()
    {
    }

    public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adres> Adres { get; set; }

    public virtual DbSet<Dodatek> Dodateks { get; set; }

    public virtual DbSet<DodatekTlumaczenie> DodatekTlumaczenies { get; set; }

    public virtual DbSet<Jezyk> Jezyks { get; set; }

    public virtual DbSet<Napoj> Napojs { get; set; }

    public virtual DbSet<NapojTlumaczenie> NapojTlumaczenies { get; set; }

    public virtual DbSet<Osoba> Osobas { get; set; }

    public virtual DbSet<Pizza> Pizzas { get; set; }

    public virtual DbSet<PizzaSkladnik> PizzaSkladniks { get; set; }

    public virtual DbSet<PizzaTlumaczenie> PizzaTlumaczenies { get; set; }

    public virtual DbSet<Rola> Rolas { get; set; }

    public virtual DbSet<Skladnik> Skladniks { get; set; }

    public virtual DbSet<SkladnikTlumaczenie> SkladnikTlumaczenies { get; set; }

    public virtual DbSet<Uprawnienie> Uprawnienies { get; set; }

    public virtual DbSet<Uzytkownik> Uzytkowniks { get; set; }

    public virtual DbSet<Zamowienie> Zamowienies { get; set; }

    public virtual DbSet<ZamowienieDodatek> ZamowienieDodateks { get; set; }

    public virtual DbSet<ZamowienieNapoj> ZamowienieNapojs { get; set; }

    public virtual DbSet<ZamowieniePizza> ZamowieniePizzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=P@ssw0rd;database=mysql", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Adres>(entity =>
        {
            entity.HasKey(e => e.IdAdres).HasName("PRIMARY");

            entity.Property(e => e.IdAdres)
                .ValueGeneratedNever()
                .HasColumnName("id_adres");
            entity.Property(e => e.Kraj)
                .HasMaxLength(50)
                .HasColumnName("kraj");
            entity.Property(e => e.Miasto)
                .HasMaxLength(50)
                .HasColumnName("miasto");
            entity.Property(e => e.NrMieszkania).HasColumnName("nr_mieszkania");
            entity.Property(e => e.NrUlicy).HasColumnName("nr_ulicy");
            entity.Property(e => e.Ulica)
                .HasMaxLength(50)
                .HasColumnName("ulica");
        });

        modelBuilder.Entity<Dodatek>(entity =>
        {
            entity.HasKey(e => e.IdDodatek).HasName("PRIMARY");

            entity.ToTable("Dodatek");

            entity.Property(e => e.IdDodatek)
                .ValueGeneratedNever()
                .HasColumnName("id_dodatek");
            entity.Property(e => e.Cena)
                .HasColumnType("double(6,2)")
                .HasColumnName("cena");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .HasColumnName("nazwa")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<DodatekTlumaczenie>(entity =>
        {
            entity.HasKey(e => new { e.IdDodatek, e.IdJezyk })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("Dodatek_tlumaczenie");

            entity.HasIndex(e => e.IdJezyk, "Dodatek_tlumaczenie_Jezyk");

            entity.Property(e => e.IdDodatek).HasColumnName("id_dodatek");
            entity.Property(e => e.IdJezyk).HasColumnName("id_jezyk");
            entity.Property(e => e.Tlumaczenie)
                .HasMaxLength(50)
                .HasColumnName("tlumaczenie");

            entity.HasOne(d => d.IdDodatekNavigation).WithMany(p => p.DodatekTlumaczenies)
                .HasForeignKey(d => d.IdDodatek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dodatek_tlumaczenie_Dodatek");

            entity.HasOne(d => d.IdJezykNavigation).WithMany(p => p.DodatekTlumaczenies)
                .HasForeignKey(d => d.IdJezyk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dodatek_tlumaczenie_Jezyk");
        });

        modelBuilder.Entity<Jezyk>(entity =>
        {
            entity.HasKey(e => e.IdJezyk).HasName("PRIMARY");

            entity.ToTable("Jezyk");

            entity.Property(e => e.IdJezyk)
                .ValueGeneratedNever()
                .HasColumnName("id_jezyk");
            entity.Property(e => e.Kod)
                .HasMaxLength(3)
                .HasColumnName("kod");
        });

        modelBuilder.Entity<Napoj>(entity =>
        {
            entity.HasKey(e => e.IdNapoj).HasName("PRIMARY");

            entity.ToTable("Napoj");

            entity.Property(e => e.IdNapoj)
                .ValueGeneratedNever()
                .HasColumnName("id_napoj");
            entity.Property(e => e.Cena)
                .HasColumnType("double(6,2)")
                .HasColumnName("cena");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<NapojTlumaczenie>(entity =>
        {
            entity.HasKey(e => new { e.IdJezyk, e.IdNapoj })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("Napoj_tlumaczenie");

            entity.HasIndex(e => e.IdNapoj, "Napoj_tlumaczenie_Napoj");

            entity.Property(e => e.IdJezyk).HasColumnName("id_jezyk");
            entity.Property(e => e.IdNapoj).HasColumnName("id_napoj");
            entity.Property(e => e.Tlumaczenie)
                .HasMaxLength(50)
                .HasColumnName("tlumaczenie");

            entity.HasOne(d => d.IdJezykNavigation).WithMany(p => p.NapojTlumaczenies)
                .HasForeignKey(d => d.IdJezyk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Napoj_tlumaczenie_Jezyk");

            entity.HasOne(d => d.IdNapojNavigation).WithMany(p => p.NapojTlumaczenies)
                .HasForeignKey(d => d.IdNapoj)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Napoj_tlumaczenie_Napoj");
        });

        modelBuilder.Entity<Osoba>(entity =>
        {
            entity.HasKey(e => e.IdOsoba).HasName("PRIMARY");

            entity.ToTable("Osoba");

            entity.HasIndex(e => e.IdAdres, "Osoba_Adres");

            entity.HasIndex(e => e.IdRola, "Osoba_Rola");

            entity.HasIndex(e => e.IdUzytkownik, "Osoba_Uzytkownik");

            entity.Property(e => e.IdOsoba)
                .ValueGeneratedNever()
                .HasColumnName("id_osoba");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.IdAdres).HasColumnName("id_adres");
            entity.Property(e => e.IdRola).HasColumnName("id_rola");
            entity.Property(e => e.IdUzytkownik).HasColumnName("id_uzytkownik");
            entity.Property(e => e.Imie)
                .HasMaxLength(50)
                .HasColumnName("imie");
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(50)
                .HasColumnName("nazwisko");
            entity.Property(e => e.NrTelefonu)
                .HasMaxLength(12)
                .HasColumnName("nr_telefonu");

            entity.HasOne(d => d.IdAdresesNavigation).WithMany(p => p.Osobas)
                .HasForeignKey(d => d.IdAdres)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Osoba_Adres");

            entity.HasOne(d => d.IdRolaNavigation).WithMany(p => p.Osobas)
                .HasForeignKey(d => d.IdRola)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Osoba_Rola");

            entity.HasOne(d => d.IdUzytkownikNavigation).WithMany(p => p.Osobas)
                .HasForeignKey(d => d.IdUzytkownik)
                .HasConstraintName("Osoba_Uzytkownik");
        });

        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.HasKey(e => e.IdPizza).HasName("PRIMARY");

            entity.ToTable("Pizza");

            entity.Property(e => e.IdPizza)
                .ValueGeneratedNever()
                .HasColumnName("id_pizza");
            entity.Property(e => e.Cena)
                .HasColumnType("double(6,2)")
                .HasColumnName("cena");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<PizzaSkladnik>(entity =>
        {
            entity.HasKey(e => e.IdPizzaSkladnik).HasName("PRIMARY");

            entity.ToTable("Pizza_skladnik");

            entity.HasIndex(e => e.IdPizza, "Pizza_skladnik_Pizza");

            entity.HasIndex(e => e.IdSkladnik, "Pizza_skladnik_Skladnik");

            entity.Property(e => e.IdPizzaSkladnik)
                .ValueGeneratedNever()
                .HasColumnName("id_pizza_skladnik");
            entity.Property(e => e.IdPizza).HasColumnName("id_pizza");
            entity.Property(e => e.IdSkladnik).HasColumnName("id_skladnik");

            entity.HasOne(d => d.IdPizzaNavigation).WithMany(p => p.PizzaSkladniks)
                .HasForeignKey(d => d.IdPizza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pizza_skladnik_Pizza");

            entity.HasOne(d => d.IdSkladnikNavigation).WithMany(p => p.PizzaSkladniks)
                .HasForeignKey(d => d.IdSkladnik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pizza_skladnik_Skladnik");
        });

        modelBuilder.Entity<PizzaTlumaczenie>(entity =>
        {
            entity.HasKey(e => new { e.IdJezyk, e.IdPizza })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("Pizza_tlumaczenie");

            entity.HasIndex(e => e.IdPizza, "Pizza_tlumaczenie_Pizza");

            entity.Property(e => e.IdJezyk).HasColumnName("id_jezyk");
            entity.Property(e => e.IdPizza).HasColumnName("id_pizza");
            entity.Property(e => e.Tlumaczenie)
                .HasMaxLength(50)
                .HasColumnName("tlumaczenie");

            entity.HasOne(d => d.IdJezykNavigation).WithMany(p => p.PizzaTlumaczenies)
                .HasForeignKey(d => d.IdJezyk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pizza_tlumaczenie_Jezyk");

            entity.HasOne(d => d.IdPizzaNavigation).WithMany(p => p.PizzaTlumaczenies)
                .HasForeignKey(d => d.IdPizza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pizza_tlumaczenie_Pizza");
        });

        modelBuilder.Entity<Rola>(entity =>
        {
            entity.HasKey(e => e.IdRola).HasName("PRIMARY");

            entity.ToTable("Rola");

            entity.Property(e => e.IdRola)
                .ValueGeneratedNever()
                .HasColumnName("id_rola");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(30)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Skladnik>(entity =>
        {
            entity.HasKey(e => e.IdSkladnik).HasName("PRIMARY");

            entity.ToTable("Skladnik");

            entity.Property(e => e.IdSkladnik)
                .ValueGeneratedNever()
                .HasColumnName("id_skladnik");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<SkladnikTlumaczenie>(entity =>
        {
            entity.HasKey(e => new { e.IdJezyk, e.IdSkladnik })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("Skladnik_tlumaczenie");

            entity.HasIndex(e => e.IdSkladnik, "Skladnik_tlumaczenie_Skladnik");

            entity.Property(e => e.IdJezyk).HasColumnName("id_jezyk");
            entity.Property(e => e.IdSkladnik).HasColumnName("id_skladnik");
            entity.Property(e => e.Tlumaczenie)
                .HasMaxLength(50)
                .HasColumnName("tlumaczenie");

            entity.HasOne(d => d.IdJezykNavigation).WithMany(p => p.SkladnikTlumaczenies)
                .HasForeignKey(d => d.IdJezyk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Skladnik_tlumaczenie_Jezyk");

            entity.HasOne(d => d.IdSkladnikNavigation).WithMany(p => p.SkladnikTlumaczenies)
                .HasForeignKey(d => d.IdSkladnik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Skladnik_tlumaczenie_Skladnik");
        });

        modelBuilder.Entity<Uprawnienie>(entity =>
        {
            entity.HasKey(e => e.IdUprawnienie).HasName("PRIMARY");

            entity.ToTable("Uprawnienie");

            entity.Property(e => e.IdUprawnienie)
                .ValueGeneratedNever()
                .HasColumnName("id_uprawnienie");
            entity.Property(e => e.Opis)
                .HasMaxLength(200)
                .HasColumnName("opis");
        });

        modelBuilder.Entity<Uzytkownik>(entity =>
        {
            entity.HasKey(e => e.IdUzytkownik).HasName("PRIMARY");

            entity.ToTable("Uzytkownik");

            entity.Property(e => e.IdUzytkownik)
                .ValueGeneratedNever()
                .HasColumnName("id_uzytkownik");
            entity.Property(e => e.DataUtworzeniaKonta).HasColumnName("data_utworzenia_konta");
            entity.Property(e => e.HasloHash)
                .HasMaxLength(50)
                .HasColumnName("haslo_hash");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
        });

        modelBuilder.Entity<Zamowienie>(entity =>
        {
            entity.HasKey(e => e.IdZamowienie).HasName("PRIMARY");

            entity.ToTable("Zamowienie");

            entity.HasIndex(e => e.IdOsoba, "Zamowienie_Osoba");

            entity.Property(e => e.IdZamowienie)
                .ValueGeneratedNever()
                .HasColumnName("id_zamowienie");
            entity.Property(e => e.DataZlozenia)
                .HasColumnType("timestamp")
                .HasColumnName("data_zlozenia");
            entity.Property(e => e.IdOsoba).HasColumnName("id_osoba");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.IdOsobaNavigation).WithMany(p => p.Zamowienies)
                .HasForeignKey(d => d.IdOsoba)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Zamowienie_Osoba");
        });

        modelBuilder.Entity<ZamowienieDodatek>(entity =>
        {
            entity.HasKey(e => new { e.IdZamowienie, e.IdDodatek })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("Zamowienie_dodatek");

            entity.HasIndex(e => e.IdDodatek, "Zamowienie_dodatek_Dodatek");

            entity.Property(e => e.IdZamowienie).HasColumnName("id_zamowienie");
            entity.Property(e => e.IdDodatek).HasColumnName("id_dodatek");
            entity.Property(e => e.Ilosc).HasColumnName("ilosc");

            entity.HasOne(d => d.IdDodatekNavigation).WithMany(p => p.ZamowienieDodateks)
                .HasForeignKey(d => d.IdDodatek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Zamowienie_dodatek_Dodatek");

            entity.HasOne(d => d.IdZamowienieNavigation).WithMany(p => p.ZamowienieDodateks)
                .HasForeignKey(d => d.IdZamowienie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Zamowienie_dodatek_Zamowienie");
        });

        modelBuilder.Entity<ZamowienieNapoj>(entity =>
        {
            entity.HasKey(e => new { e.IdZamowienie, e.IdNapoj })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("Zamowienie_napoj");

            entity.HasIndex(e => e.IdNapoj, "Zamowienie_napoj_Napoj");

            entity.Property(e => e.IdZamowienie).HasColumnName("id_zamowienie");
            entity.Property(e => e.IdNapoj).HasColumnName("id_napoj");
            entity.Property(e => e.Ilosc).HasColumnName("ilosc");

            entity.HasOne(d => d.IdNapojNavigation).WithMany(p => p.ZamowienieNapojs)
                .HasForeignKey(d => d.IdNapoj)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Zamowienie_napoj_Napoj");

            entity.HasOne(d => d.IdZamowienieNavigation).WithMany(p => p.ZamowienieNapojs)
                .HasForeignKey(d => d.IdZamowienie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Zamowienie_napoj_Zamowienie");
        });

        modelBuilder.Entity<ZamowieniePizza>(entity =>
        {
            entity.HasKey(e => new { e.IdZamowienie, e.IdPizza })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("Zamowienie_pizza");

            entity.HasIndex(e => e.IdPizza, "Zamowienie_pizza_Pizza");

            entity.Property(e => e.IdZamowienie).HasColumnName("id_zamowienie");
            entity.Property(e => e.IdPizza).HasColumnName("id_pizza");
            entity.Property(e => e.Ilosc).HasColumnName("ilosc");

            entity.HasOne(d => d.IdPizzaNavigation).WithMany(p => p.ZamowieniePizzas)
                .HasForeignKey(d => d.IdPizza)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Zamowienie_pizza_Pizza");

            entity.HasOne(d => d.IdZamowienieNavigation).WithMany(p => p.ZamowieniePizzas)
                .HasForeignKey(d => d.IdZamowienie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Zamowienie_pizza_Zamowienie");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
