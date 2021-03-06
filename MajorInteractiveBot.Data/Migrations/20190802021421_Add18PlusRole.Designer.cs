﻿// <auto-generated />
using MajorInteractiveBot.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MajorInteractiveBot.Data.Migrations
{
    [DbContext(typeof(MajorContext))]
    [Migration("20190802021421_Add18PlusRole")]
    partial class Add18PlusRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MajorInteractiveBot.Data.Models.AssignableRole", b =>
                {
                    b.Property<decimal>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<bool>("Require18Plus");

                    b.HasKey("RoleId");

                    b.ToTable("AssignableRoles");
                });

            modelBuilder.Entity("MajorInteractiveBot.Data.Models.CommandChannel", b =>
                {
                    b.Property<decimal>("ChannelId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<decimal>("GuildId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.HasKey("ChannelId");

                    b.ToTable("CommandChannels");
                });

            modelBuilder.Entity("MajorInteractiveBot.Data.Models.Guild", b =>
                {
                    b.Property<decimal>("GuildId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<decimal>("AdultRole")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<decimal>("BotManager")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<string>("CommandPrefix");

                    b.Property<bool>("GreetUser");

                    b.Property<decimal>("GreetingChannel")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<string>("GreetingMessage");

                    b.HasKey("GuildId");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("MajorInteractiveBot.Data.Models.Module", b =>
                {
                    b.Property<decimal>("GuildId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<string>("ModuleName");

                    b.HasKey("GuildId", "ModuleName");

                    b.ToTable("DisabledModules");
                });

            modelBuilder.Entity("MajorInteractiveBot.Data.Models.RoleCategory", b =>
                {
                    b.Property<decimal>("CategoryRole")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<decimal>("GuildId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.HasKey("CategoryRole");

                    b.ToTable("RoleCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
