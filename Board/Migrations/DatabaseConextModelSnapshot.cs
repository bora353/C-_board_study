﻿// <auto-generated />
using System;
using Board;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Board.Migrations
{
    [DbContext(typeof(DatabaseConext))]
    partial class DatabaseConextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Board.Model.Board123", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("GroupNo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PrinitNo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PrintLevel")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ReadCount")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Writer")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Board123s");
                });
#pragma warning restore 612, 618
        }
    }
}
