﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Progra1_Bases.Models;

namespace Progra1_Bases.Migrations
{
    [DbContext(typeof(Progra1_BasesContext))]
    partial class Progra1_BasesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Progra1_Bases.Models.Doc", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre");

                    b.HasKey("ID");

                    b.ToTable("Doc");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("doc");

                    b.Property<int>("docId");

                    b.Property<string>("email");

                    b.Property<DateTime>("fechaNacimiento");

                    b.Property<string>("nombre");

                    b.HasKey("ID");

                    b.HasIndex("docId");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Cliente", b =>
                {
                    b.HasBaseType("Progra1_Bases.Models.Persona");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Progra1_Bases.Models.Persona", b =>
                {
                    b.HasOne("Progra1_Bases.Models.Doc", "Doc")
                        .WithMany("personas")
                        .HasForeignKey("docId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
