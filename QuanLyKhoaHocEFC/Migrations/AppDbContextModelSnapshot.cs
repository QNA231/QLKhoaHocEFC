﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKhoaHocEFC.Entities;

#nullable disable

namespace QuanLyKhoaHocEFC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuanLyKhoaHocEFC.Entities.HocVien", b =>
                {
                    b.Property<int>("HocVienId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HocVienId"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("KhoaHocId")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("QueQuan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HocVienId");

                    b.HasIndex("KhoaHocId");

                    b.ToTable("HocVien");
                });

            modelBuilder.Entity("QuanLyKhoaHocEFC.Entities.KhoaHoc", b =>
                {
                    b.Property<int>("KhoaHocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhoaHocId"));

                    b.Property<double>("HocPhi")
                        .HasColumnType("float");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenKhoaHoc")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("KhoaHocId");

                    b.ToTable("KhoaHoc");
                });

            modelBuilder.Entity("QuanLyKhoaHocEFC.Entities.NgayHoc", b =>
                {
                    b.Property<int>("NgayHocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NgayHocId"));

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KhoaHocId")
                        .HasColumnType("int");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NgayHocId");

                    b.HasIndex("KhoaHocId");

                    b.ToTable("NgayHoc");
                });

            modelBuilder.Entity("QuanLyKhoaHocEFC.Entities.HocVien", b =>
                {
                    b.HasOne("QuanLyKhoaHocEFC.Entities.KhoaHoc", "KhoaHoc")
                        .WithMany("DanhSachHocVien")
                        .HasForeignKey("KhoaHocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhoaHoc");
                });

            modelBuilder.Entity("QuanLyKhoaHocEFC.Entities.NgayHoc", b =>
                {
                    b.HasOne("QuanLyKhoaHocEFC.Entities.KhoaHoc", "KhoaHoc")
                        .WithMany("DanhSachNgayHoc")
                        .HasForeignKey("KhoaHocId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhoaHoc");
                });

            modelBuilder.Entity("QuanLyKhoaHocEFC.Entities.KhoaHoc", b =>
                {
                    b.Navigation("DanhSachHocVien");

                    b.Navigation("DanhSachNgayHoc");
                });
#pragma warning restore 612, 618
        }
    }
}
