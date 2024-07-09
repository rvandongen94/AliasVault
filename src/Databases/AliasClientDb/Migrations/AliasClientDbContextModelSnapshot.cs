﻿// <auto-generated />
using System;
using AliasClientDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AliasClientDb.Migrations
{
    [DbContext(typeof(AliasClientDbContext))]
    partial class AliasClientDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("AliasClientDb.Alias", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressCity")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("AddressCountry")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("AddressState")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("AddressStreet")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("AddressZipCode")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("BankAccountIBAN")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailPrefix")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Gender")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Hobbies")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("NickName")
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("PhoneMobile")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Aliases");
                });

            modelBuilder.Entity("AliasClientDb.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Blob")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CredentialId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CredentialId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("AliasClientDb.Credential", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AliasId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AliasId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("AliasClientDb.Password", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CredentialId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CredentialId");

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("AliasClientDb.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("AliasClientDb.Attachment", b =>
                {
                    b.HasOne("AliasClientDb.Credential", "Credential")
                        .WithMany("Attachments")
                        .HasForeignKey("CredentialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credential");
                });

            modelBuilder.Entity("AliasClientDb.Credential", b =>
                {
                    b.HasOne("AliasClientDb.Alias", "Alias")
                        .WithMany("Credentials")
                        .HasForeignKey("AliasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AliasClientDb.Service", "Service")
                        .WithMany("Credentials")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alias");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("AliasClientDb.Password", b =>
                {
                    b.HasOne("AliasClientDb.Credential", "Credential")
                        .WithMany("Passwords")
                        .HasForeignKey("CredentialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credential");
                });

            modelBuilder.Entity("AliasClientDb.Alias", b =>
                {
                    b.Navigation("Credentials");
                });

            modelBuilder.Entity("AliasClientDb.Credential", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Passwords");
                });

            modelBuilder.Entity("AliasClientDb.Service", b =>
                {
                    b.Navigation("Credentials");
                });
#pragma warning restore 612, 618
        }
    }
}
