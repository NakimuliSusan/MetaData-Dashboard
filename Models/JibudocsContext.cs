using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MetaData_ScraperDashboardAPI.Models;
//Jibudocs context db provides context for interacting with database jibu docs to query data 
public partial class JibudocsContext : DbContext
{
    public JibudocsContext()
    {
    }

    public JibudocsContext(DbContextOptions<JibudocsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DefaultConfig> DefaultConfigs { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Run> Runs { get; set; }

    public virtual DbSet<RunLog> RunLogs { get; set; }

    public virtual DbSet<ScraperBlobStore> ScraperBlobStores { get; set; }

    public virtual DbSet<ScrapersDocument> ScrapersDocuments { get; set; }

    public virtual DbSet<ScrapersDocument1> ScrapersDocuments1 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:ScraperDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DefaultConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("default_config_pkey");

            entity.ToTable("default_config", "scrapers");

            entity.Property(e => e.Id)
                .HasColumnType("character varying")
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .HasColumnType("character varying")
                .HasColumnName("action");
            entity.Property(e => e.Config)
                .HasColumnType("json")
                .HasColumnName("config");
            entity.Property(e => e.Target)
                .HasColumnType("character varying")
                .HasColumnName("target");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("documents_pkey");

            entity.ToTable("documents", "scrapers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("json")
                .HasColumnName("data");
            entity.Property(e => e.IngestedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ingested_at");
            entity.Property(e => e.Scraper)
                .HasColumnType("character varying")
                .HasColumnName("scraper");
            entity.Property(e => e.Timestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timestamp");
            entity.Property(e => e.Url)
                .HasColumnType("character varying")
                .HasColumnName("url");
            entity.Property(e => e.Version)
                .HasColumnType("character varying")
                .HasColumnName("version");
        });

        modelBuilder.Entity<Run>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("runs_pkey");

            entity.ToTable("runs", "scrapers");

            entity.Property(e => e.Id)
                .HasColumnType("character varying")
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .HasColumnType("character varying")
                .HasColumnName("action");
            entity.Property(e => e.Config)
                .HasColumnType("json")
                .HasColumnName("config");
            entity.Property(e => e.EndTimeUtc)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_time_utc");
            entity.Property(e => e.StartTimeUtc)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time_utc");
            entity.Property(e => e.Target)
                .HasColumnType("character varying")
                .HasColumnName("target");
        });

        modelBuilder.Entity<RunLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("run_logs_pkey");

            entity.ToTable("run_logs", "scrapers");

            entity.HasIndex(e => e.TimestampUtc, "ix_scrapers_run_logs_timestamp_utc");

            entity.Property(e => e.LogId)
                .HasColumnType("character varying")
                .HasColumnName("log_id");
            entity.Property(e => e.Data)
                .HasColumnType("json")
                .HasColumnName("data");
            entity.Property(e => e.LogLevel)
                .HasColumnType("character varying")
                .HasColumnName("log_level");
            entity.Property(e => e.Message)
                .HasColumnType("character varying")
                .HasColumnName("message");
            entity.Property(e => e.RunId)
                .HasColumnType("character varying")
                .HasColumnName("run_id");
            entity.Property(e => e.TimestampUtc)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timestamp_utc");

            entity.HasOne(d => d.Run).WithMany(p => p.RunLogs)
                .HasForeignKey(d => d.RunId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("run_logs_run_id_fkey");
        });

        modelBuilder.Entity<ScraperBlobStore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scraper_blob_store_pkey");

            entity.ToTable("scraper_blob_store", "scrapers");

            entity.HasIndex(e => e.DocumentId, "ix_scrapers_scraper_blob_store_document_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.FileContentType)
                .HasColumnType("character varying")
                .HasColumnName("file_content_type");
            entity.Property(e => e.SourceFile).HasColumnName("source_file");
            entity.Property(e => e.Timestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timestamp");

            entity.HasOne(d => d.Document).WithMany(p => p.ScraperBlobStores)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("scraper_blob_store_document_id_fkey");
        });

        modelBuilder.Entity<ScrapersDocument>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scrapers.documents_pkey");

            entity.ToTable("scrapers.documents");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("json")
                .HasColumnName("data");
            entity.Property(e => e.IngestedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ingested_at");
            entity.Property(e => e.Scraper)
                .HasColumnType("character varying")
                .HasColumnName("scraper");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            entity.Property(e => e.Url)
                .HasColumnType("character varying")
                .HasColumnName("url");
            entity.Property(e => e.Version)
                .HasColumnType("character varying")
                .HasColumnName("version");
        });

        modelBuilder.Entity<ScrapersDocument1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("scrapers.documents_pkey");

            entity.ToTable("scrapers.documents", "scrapers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("json")
                .HasColumnName("data");
            entity.Property(e => e.IngestedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ingested_at");
            entity.Property(e => e.Scraper)
                .HasColumnType("character varying")
                .HasColumnName("scraper");
            entity.Property(e => e.Timestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("timestamp");
            entity.Property(e => e.Url)
                .HasColumnType("character varying")
                .HasColumnName("url");
            entity.Property(e => e.Version)
                .HasColumnType("character varying")
                .HasColumnName("version");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
