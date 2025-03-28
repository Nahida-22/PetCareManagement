﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PawfectCareLtd.Data;

#nullable disable

namespace PawfectCareLtd.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PawfectCareLtd.Models.Appointment", b =>
                {
                    b.Property<string>("AppointmentID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("ApptDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PetID")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VetID")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("AppointmentID");

                    b.HasIndex("LocationID");

                    b.HasIndex("PetID");

                    b.HasIndex("VetID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Location", b =>
                {
                    b.Property<string>("LocationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Medication", b =>
                {
                    b.Property<string>("MedicationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.Property<string>("SupplierID")
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MedicationID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Order", b =>
                {
                    b.Property<string>("OrderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MedicationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("MedicationID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Owner", b =>
                {
                    b.Property<string>("OwnerID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OwnerID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Pet", b =>
                {
                    b.Property<string>("PetID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OwnerID")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PetType")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("PetID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Prescription", b =>
                {
                    b.Property<string>("PrescriptionID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PetID")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("VetID")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("PrescriptionID");

                    b.HasIndex("PetID");

                    b.HasIndex("VetID");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.PrescriptionMedication", b =>
                {
                    b.Property<string>("PrescriptionID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("MedicationID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PrescriptionID", "MedicationID");

                    b.HasIndex("MedicationID");

                    b.ToTable("PrescriptionMedication");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Supplier", b =>
                {
                    b.Property<string>("SupplierID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Vet", b =>
                {
                    b.Property<string>("VetID")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasAnnotation("Relational:JsonPropertyName", "vetID");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasAnnotation("Relational:JsonPropertyName", "address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasAnnotation("Relational:JsonPropertyName", "phoneNo");

                    b.Property<string>("Specialisation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "specialisation");

                    b.Property<string>("VetName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "vetName");

                    b.HasKey("VetID");

                    b.ToTable("Vet");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Appointment", b =>
                {
                    b.HasOne("PawfectCareLtd.Models.Location", "Location")
                        .WithMany("Appointments")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawfectCareLtd.Models.Pet", "Pet")
                        .WithMany("Appointments")
                        .HasForeignKey("PetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawfectCareLtd.Models.Vet", "Vet")
                        .WithMany("Appointments")
                        .HasForeignKey("VetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Pet");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Medication", b =>
                {
                    b.HasOne("PawfectCareLtd.Models.Supplier", "Supplier")
                        .WithMany("Medications")
                        .HasForeignKey("SupplierID");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Order", b =>
                {
                    b.HasOne("PawfectCareLtd.Models.Medication", "Medication")
                        .WithMany("Orders")
                        .HasForeignKey("MedicationID");

                    b.Navigation("Medication");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Pet", b =>
                {
                    b.HasOne("PawfectCareLtd.Models.Owner", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Prescription", b =>
                {
                    b.HasOne("PawfectCareLtd.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetID");

                    b.HasOne("PawfectCareLtd.Models.Vet", "Vet")
                        .WithMany()
                        .HasForeignKey("VetID");

                    b.Navigation("Pet");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.PrescriptionMedication", b =>
                {
                    b.HasOne("PawfectCareLtd.Models.Medication", "Medication")
                        .WithMany("PrescriptionMedications")
                        .HasForeignKey("MedicationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawfectCareLtd.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionMedications")
                        .HasForeignKey("PrescriptionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medication");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Location", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Medication", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("PrescriptionMedications");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Owner", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Pet", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedications");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Supplier", b =>
                {
                    b.Navigation("Medications");
                });

            modelBuilder.Entity("PawfectCareLtd.Models.Vet", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
