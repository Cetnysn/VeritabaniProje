﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VeritabanıProje.Models;

namespace VeritabanıProje.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("VeritabanıProje.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Fuar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("aktif")
                        .HasColumnType("bit");

                    b.Property<string>("isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("sektorId")
                        .HasColumnType("int");

                    b.Property<string>("sektor_adı")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("sektorId");

                    b.ToTable("fuars");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Sektor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("isim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sektors");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Sirket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("fuar_Id")
                        .HasColumnType("int");

                    b.Property<string>("fuar_isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("onay")
                        .HasColumnType("bit");

                    b.Property<int>("salon_no")
                        .HasColumnType("int");

                    b.Property<int?>("sektor_Id")
                        .HasColumnType("int");

                    b.Property<string>("sektor_adı")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stand_no")
                        .HasColumnType("int");

                    b.Property<string>("yetkili")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("yetkiliMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("yetkiliTel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("fuar_Id");

                    b.HasIndex("sektor_Id");

                    b.ToTable("sirkets");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Stand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("fuar_Id")
                        .HasColumnType("int");

                    b.Property<string>("fuar_isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("salon_no")
                        .HasColumnType("int");

                    b.Property<int?>("sirket_Id")
                        .HasColumnType("int");

                    b.Property<string>("sirket_isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stand_no")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("fuar_Id");

                    b.HasIndex("sirket_Id");

                    b.ToTable("stands");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Ziyaretci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("fuarId")
                        .HasColumnType("int");

                    b.Property<string>("fuar_adı")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("isim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("fuarId");

                    b.ToTable("ziyaretcis");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Fuar", b =>
                {
                    b.HasOne("VeritabanıProje.Models.Sektor", "sektor")
                        .WithMany("fuar")
                        .HasForeignKey("sektorId");

                    b.Navigation("sektor");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Sirket", b =>
                {
                    b.HasOne("VeritabanıProje.Models.Fuar", "fuar_")
                        .WithMany()
                        .HasForeignKey("fuar_Id");

                    b.HasOne("VeritabanıProje.Models.Sektor", "sektor_")
                        .WithMany("sirket")
                        .HasForeignKey("sektor_Id");

                    b.Navigation("fuar_");

                    b.Navigation("sektor_");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Stand", b =>
                {
                    b.HasOne("VeritabanıProje.Models.Fuar", "fuar_")
                        .WithMany("standlar")
                        .HasForeignKey("fuar_Id");

                    b.HasOne("VeritabanıProje.Models.Sirket", "sirket_")
                        .WithMany()
                        .HasForeignKey("sirket_Id");

                    b.Navigation("fuar_");

                    b.Navigation("sirket_");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Ziyaretci", b =>
                {
                    b.HasOne("VeritabanıProje.Models.Fuar", "fuar")
                        .WithMany("ziyaretci")
                        .HasForeignKey("fuarId");

                    b.Navigation("fuar");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Fuar", b =>
                {
                    b.Navigation("standlar");

                    b.Navigation("ziyaretci");
                });

            modelBuilder.Entity("VeritabanıProje.Models.Sektor", b =>
                {
                    b.Navigation("fuar");

                    b.Navigation("sirket");
                });
#pragma warning restore 612, 618
        }
    }
}
