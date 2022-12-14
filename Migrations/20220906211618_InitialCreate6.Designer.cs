// <auto-generated />
using System;
using EF_Core_posgrest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EF_Core_posgrest.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220906211618_InitialCreate6")]
    partial class InitialCreate6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EF_Core_posgrest.DateOfVisit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdKey")
                        .HasColumnType("uuid");

                    b.Property<string>("Visit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Visiting");
                });

            modelBuilder.Entity("EF_Core_posgrest.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DataPosechenia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EF_Core_posgrest.TableOfDiscipline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DateOfVisitId")
                        .HasColumnType("uuid");

                    b.Property<string>("Discipline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdKey")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DateOfVisitId");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("EF_Core_posgrest.TableOfDiscipline", b =>
                {
                    b.HasOne("EF_Core_posgrest.DateOfVisit", "DateOfVisit")
                        .WithMany()
                        .HasForeignKey("DateOfVisitId");

                    b.Navigation("DateOfVisit");
                });
#pragma warning restore 612, 618
        }
    }
}
