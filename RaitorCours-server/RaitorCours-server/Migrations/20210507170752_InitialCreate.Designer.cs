﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RaitorCours_server.Data;

namespace raitorcours_server.Migrations
{
    [DbContext(typeof(RaitorCoursDbContext))]
    [Migration("20210507170752_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RaitorCours_server.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("RaitorCours_server.Models.AssessmentTask", b =>
                {
                    b.Property<int>("AssessmentTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssessmentTaskName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int?>("SubthemeId")
                        .HasColumnType("int");

                    b.HasKey("AssessmentTaskId");

                    b.HasIndex("SubthemeId");

                    b.ToTable("AssessmentTasks");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorUserId")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<int?>("SubcategoryId")
                        .HasColumnType("int");

                    b.Property<int>("WeekNum")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("AuthorUserId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("RaitorCours_server.Models.CourseTask", b =>
                {
                    b.Property<int>("CourseTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubthemeSubthemeId")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseTaskId");

                    b.HasIndex("SubthemeSubthemeId");

                    b.ToTable("CourseTasks");
                });

            modelBuilder.Entity("RaitorCours_server.Models.CourseUser", b =>
                {
                    b.Property<int>("CourseUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CourseUserId");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("CourseUsers");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskAssessmentTaskId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex("TaskAssessmentTaskId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Subcategory", b =>
                {
                    b.Property<int>("SubcategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubcategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubcategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Subcategory");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Subtheme", b =>
                {
                    b.Property<int>("SubthemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("SubthemeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeekEnum")
                        .HasColumnType("int");

                    b.HasKey("SubthemeId");

                    b.HasIndex("CourseId");

                    b.ToTable("Subthemes");
                });

            modelBuilder.Entity("RaitorCours_server.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("raitorcours_server.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Answer", b =>
                {
                    b.HasOne("RaitorCours_server.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");

                    b.HasOne("RaitorCours_server.Models.User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RaitorCours_server.Models.AssessmentTask", b =>
                {
                    b.HasOne("RaitorCours_server.Models.Subtheme", "Subtheme")
                        .WithMany("AssessmentTasks")
                        .HasForeignKey("SubthemeId");

                    b.Navigation("Subtheme");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Course", b =>
                {
                    b.HasOne("RaitorCours_server.Models.User", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorUserId");

                    b.HasOne("RaitorCours_server.Models.Subcategory", "Subcategory")
                        .WithMany("Courses")
                        .HasForeignKey("SubcategoryId");

                    b.Navigation("Author");

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("RaitorCours_server.Models.CourseTask", b =>
                {
                    b.HasOne("RaitorCours_server.Models.Subtheme", "Subtheme")
                        .WithMany("CourseTasks")
                        .HasForeignKey("SubthemeSubthemeId");

                    b.Navigation("Subtheme");
                });

            modelBuilder.Entity("RaitorCours_server.Models.CourseUser", b =>
                {
                    b.HasOne("RaitorCours_server.Models.Course", "Course")
                        .WithMany("CourseOfUsers")
                        .HasForeignKey("CourseId");

                    b.HasOne("RaitorCours_server.Models.User", "User")
                        .WithMany("CourseOfUsers")
                        .HasForeignKey("UserId");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Question", b =>
                {
                    b.HasOne("RaitorCours_server.Models.AssessmentTask", "Task")
                        .WithMany("Questions")
                        .HasForeignKey("TaskAssessmentTaskId");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Subcategory", b =>
                {
                    b.HasOne("RaitorCours_server.Models.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Subtheme", b =>
                {
                    b.HasOne("RaitorCours_server.Models.Course", "Course")
                        .WithMany("Subthemes")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("RaitorCours_server.Models.User", b =>
                {
                    b.HasOne("raitorcours_server.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RaitorCours_server.Models.AssessmentTask", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Category", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Course", b =>
                {
                    b.Navigation("CourseOfUsers");

                    b.Navigation("Subthemes");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Subcategory", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("RaitorCours_server.Models.Subtheme", b =>
                {
                    b.Navigation("AssessmentTasks");

                    b.Navigation("CourseTasks");
                });

            modelBuilder.Entity("RaitorCours_server.Models.User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("CourseOfUsers");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("raitorcours_server.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}