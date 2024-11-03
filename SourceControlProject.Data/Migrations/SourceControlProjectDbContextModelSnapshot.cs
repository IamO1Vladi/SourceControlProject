﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SourceControlProject.Data;

#nullable disable

namespace SourceControlProject.Data.Migrations
{
    [DbContext(typeof(SourceControlProjectDbContext))]
    partial class SourceControlProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Commits.Commit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RepositoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Commits.FileModification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileDifference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommitId");

                    b.ToTable("FileModifications");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Contributor", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RepositoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RepositoryId");

                    b.HasIndex("RepositoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Issues.Issue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RepositoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RepositoryId");

                    b.HasIndex("Status");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Issues.IssueTag", b =>
                {
                    b.Property<Guid>("IssueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IssueId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("IssuesTags");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Issues.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.PullRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RepositoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("RepositoryId");

                    b.HasIndex("Status");

                    b.ToTable("PullRequests");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Repository", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.HasIndex("IsPrivate");

                    b.HasIndex("Name");

                    b.HasIndex("OwnerId");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Users.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Commits.Commit", b =>
                {
                    b.HasOne("SourceControlProject.Data.Models.Entities.Users.ApplicationUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SourceControlProject.Data.Models.Entities.Repositories.Repository", "Repository")
                        .WithMany("Commits")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Commits.FileModification", b =>
                {
                    b.HasOne("SourceControlProject.Data.Models.Entities.Repositories.Commits.Commit", "Commit")
                        .WithMany("FileModifications")
                        .HasForeignKey("CommitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commit");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Contributor", b =>
                {
                    b.HasOne("SourceControlProject.Data.Models.Entities.Repositories.Repository", "Repository")
                        .WithMany("Contributors")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SourceControlProject.Data.Models.Entities.Users.ApplicationUser", "User")
                        .WithMany("Contributions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Repository");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Issues.Issue", b =>
                {
                    b.HasOne("SourceControlProject.Data.Models.Entities.Users.ApplicationUser", "Owner")
                        .WithMany("IssuesCreated")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SourceControlProject.Data.Models.Entities.Repositories.Repository", "Repository")
                        .WithMany("Issues")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Issues.IssueTag", b =>
                {
                    b.HasOne("SourceControlProject.Data.Models.Entities.Repositories.Issues.Issue", "Issue")
                        .WithMany("Tags")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SourceControlProject.Data.Models.Entities.Repositories.Issues.Tag", "Tag")
                        .WithMany("Issues")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.PullRequest", b =>
                {
                    b.HasOne("SourceControlProject.Data.Models.Entities.Users.ApplicationUser", "Author")
                        .WithMany("PullRequests")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SourceControlProject.Data.Models.Entities.Repositories.Repository", "Repository")
                        .WithMany("PullRequests")
                        .HasForeignKey("RepositoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Repository", b =>
                {
                    b.HasOne("SourceControlProject.Data.Models.Entities.Users.ApplicationUser", "Owner")
                        .WithMany("OwnedRepositories")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Commits.Commit", b =>
                {
                    b.Navigation("FileModifications");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Issues.Issue", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Issues.Tag", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Repositories.Repository", b =>
                {
                    b.Navigation("Commits");

                    b.Navigation("Contributors");

                    b.Navigation("Issues");

                    b.Navigation("PullRequests");
                });

            modelBuilder.Entity("SourceControlProject.Data.Models.Entities.Users.ApplicationUser", b =>
                {
                    b.Navigation("Contributions");

                    b.Navigation("IssuesCreated");

                    b.Navigation("OwnedRepositories");

                    b.Navigation("PullRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
