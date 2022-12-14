// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RehberListesiWEBAPI.Models.Context;

#nullable disable

namespace RehberListesiWEBAPI.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20221112095106_RehberDTOfirmaduzenleme")]
    partial class RehberDTOfirmaduzenleme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RehberListesiWEBAPI.Models.IletisimBilgileri", b =>
                {
                    b.Property<int>("IletisimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IletisimID"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmailAdresi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Konum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RehberID")
                        .HasColumnType("integer");

                    b.Property<string>("TelefonNumarasi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IletisimID");

                    b.HasIndex("RehberID");

                    b.ToTable("IletisimBilgileris");
                });

            modelBuilder.Entity("RehberListesiWEBAPI.Models.Rehber", b =>
                {
                    b.Property<int>("RehberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RehberID"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Firma")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RehberID");

                    b.ToTable("Rehbers");
                });

            modelBuilder.Entity("RehberListesiWEBAPI.Models.IletisimBilgileri", b =>
                {
                    b.HasOne("RehberListesiWEBAPI.Models.Rehber", null)
                        .WithMany("IletisimBilgileris")
                        .HasForeignKey("RehberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RehberListesiWEBAPI.Models.Rehber", b =>
                {
                    b.Navigation("IletisimBilgileris");
                });
#pragma warning restore 612, 618
        }
    }
}
