﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacrementPlanner.Models;

namespace SacrementPlanner.Migrations
{
    [DbContext(typeof(BulletinContext))]
    partial class BulletinContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SacrementPlanner.Models.Bishopric", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Bishoprics");
                });

            modelBuilder.Entity("SacrementPlanner.Models.Planner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BishopricId");

                    b.Property<string>("ClosingSong");

                    b.Property<string>("IntermediateSong");

                    b.Property<string>("OpeningSong");

                    b.Property<DateTime>("SacramentDate");

                    b.Property<string>("SacramentSong");

                    b.HasKey("ID");

                    b.HasIndex("BishopricId");

                    b.ToTable("Planner");
                });

            modelBuilder.Entity("SacrementPlanner.Models.Speakers", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("PlannerId");

                    b.Property<string>("Topic");

                    b.HasKey("ID");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("SacrementPlanner.Models.Planner", b =>
                {
                    b.HasOne("SacrementPlanner.Models.Bishopric", "Bishopric")
                        .WithMany()
                        .HasForeignKey("BishopricId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
