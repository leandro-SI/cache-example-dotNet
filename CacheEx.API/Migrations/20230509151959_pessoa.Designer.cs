﻿// <auto-generated />
using CacheEx.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CacheEx.API.Migrations
{
    [DbContext(typeof(CacheContext))]
    [Migration("20230509151959_pessoa")]
    partial class pessoa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CacheEx.API.Entities.Pessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Idade = 32,
                            Nome = "Leandro",
                            Sobrenome = "Cesar"
                        },
                        new
                        {
                            Id = 2L,
                            Idade = 67,
                            Nome = "Silvio",
                            Sobrenome = "Cesar"
                        },
                        new
                        {
                            Id = 3L,
                            Idade = 50,
                            Nome = "Luciana",
                            Sobrenome = "Santos"
                        },
                        new
                        {
                            Id = 4L,
                            Idade = 27,
                            Nome = "Dayanne",
                            Sobrenome = "Santos"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
