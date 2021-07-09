﻿
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web2_Backend.Model;

namespace Web2_Backend.Migrations
{
    [DbContext(typeof(Web2Context))]
    partial class Web2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web2_Backend.Model.Calls", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BreakdownName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BreakdownPriority")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("Reason")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Calls");
                });

            modelBuilder.Entity("Web2_Backend.Model.Cosumer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cosumers");
                });

            modelBuilder.Entity("Web2_Backend.Model.Crew", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("Web2_Backend.Model.CrewMember", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CrewId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.HasIndex("UserId");

                    b.ToTable("CrewMembers");
                });

            modelBuilder.Entity("Web2_Backend.Model.Device", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Lng")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Web2_Backend.Model.DocumentHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("DocumentStatus")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("WorkRequestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkRequestId");

                    b.ToTable("DocumentHistories");
                });

            modelBuilder.Entity("Web2_Backend.Model.Incident", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ATA")
                        .HasColumnType("datetime2");

                    b.Property<int>("AffectedCustomers")
                        .HasColumnType("int");

                    b.Property<int>("Calls")
                        .HasColumnType("int");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ETA")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ETR")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EstimatedWorkTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IncidentDateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IncidentType")
                        .HasColumnType("int");

                    b.Property<long?>("OperaterId")
                        .HasColumnType("bigint");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("VoltegeLevel")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OperaterId");

                    b.ToTable("Incidents");
                });


            modelBuilder.Entity("Web2_Backend.Model.MultimediaAttachments", b =>

            modelBuilder.Entity("Web2_Backend.Model.Instructions", b =>

                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);


                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");


                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");


                    b.Property<long?>("WorkRequestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkRequestId");

                    b.ToTable("MultimediaAttachments");

                    b.Property<string>("Order")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instructions");

                }));

            modelBuilder.Entity("Web2_Backend.Model.SafetyDocument", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long?>("OperaterId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OperaterId");

                    b.ToTable("SafetyDocuments");
                });

            modelBuilder.Entity("Web2_Backend.Model.Solution", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConstructionType")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCase")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("Web2_Backend.Model.SwitchingPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDocument")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndOfWork")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OperaterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Point")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartOfWork")
                        .HasColumnType("datetime2");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Team")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<long?>("UserCreateId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OperaterId");

                    b.HasIndex("UserCreateId");

                    b.ToTable("SwitchingPlans");
                });

            modelBuilder.Entity("Web2_Backend.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AdminNeedApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewUserType")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Web2_Backend.Model.WorkRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int>("DocumentStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Incident")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OperaterId")
                        .HasColumnType("bigint");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Urgent")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OperaterId");

                    b.ToTable("WorkRequests");
                });

            modelBuilder.Entity("Web2_Backend.Model.WorkingPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDocument")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndOfWork")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OperaterId")
                        .HasColumnType("bigint");

                    b.Property<string>("Point")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartOfWork")
                        .HasColumnType("datetime2");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<long?>("UserCreateId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OperaterId");

                    b.HasIndex("UserCreateId");

                    b.ToTable("WorkingPlans");
                });

            modelBuilder.Entity("Web2_Backend.Model.CrewMember", b =>
                {
                    b.HasOne("Web2_Backend.Model.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId");

                    b.HasOne("Web2_Backend.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Crew");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Web2_Backend.Model.DocumentHistory", b =>
                {
                    b.HasOne("Web2_Backend.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Web2_Backend.Model.WorkRequest", "WorkRequest")
                        .WithMany()
                        .HasForeignKey("WorkRequestId");

                    b.Navigation("User");

                    b.Navigation("WorkRequest");
                });

            modelBuilder.Entity("Web2_Backend.Model.Incident", b =>
                {
                    b.HasOne("Web2_Backend.Model.User", "Operater")
                        .WithMany()
                        .HasForeignKey("OperaterId");

                    b.Navigation("Operater");
                });

            modelBuilder.Entity("Web2_Backend.Model.MultimediaAttachments", b =>
                {
                    b.HasOne("Web2_Backend.Model.WorkRequest", "WorkRequest")
                        .WithMany()
                        .HasForeignKey("WorkRequestId");

                    b.Navigation("WorkRequest");
                });

            modelBuilder.Entity("Web2_Backend.Model.SafetyDocument", b =>
                {
                    b.HasOne("Web2_Backend.Model.User", "Operater")
                        .WithMany()
                        .HasForeignKey("OperaterId");

                    b.Navigation("Operater");
                });

            modelBuilder.Entity("Web2_Backend.Model.SwitchingPlan", b =>
                {
                    b.HasOne("Web2_Backend.Model.User", "Operater")
                        .WithMany()
                        .HasForeignKey("OperaterId");

                    b.HasOne("Web2_Backend.Model.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");

                    b.Navigation("Operater");

                    b.Navigation("UserCreate");
                });

            modelBuilder.Entity("Web2_Backend.Model.WorkRequest", b =>
                {
                    b.HasOne("Web2_Backend.Model.User", "Operater")
                        .WithMany()
                        .HasForeignKey("OperaterId");

                    b.Navigation("Operater");
                });

            modelBuilder.Entity("Web2_Backend.Model.WorkingPlan", b =>
                {
                    b.HasOne("Web2_Backend.Model.User", "Operater")
                        .WithMany()
                        .HasForeignKey("OperaterId");

                    b.HasOne("Web2_Backend.Model.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");

                    b.Navigation("Operater");

                    b.Navigation("UserCreate");
                });
#pragma warning restore 612, 618
        }
    }
}
