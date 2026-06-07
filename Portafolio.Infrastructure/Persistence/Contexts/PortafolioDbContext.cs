using Microsoft.EntityFrameworkCore;
using Portafolio.Infrastructure.Persistence.Entities;

namespace Portafolio.Infrastructure.Persistence.Contexts;

public partial class PortafolioDbContext : DbContext
{
    public PortafolioDbContext(DbContextOptions<PortafolioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Additional> Additionals { get; set; }

    public virtual DbSet<AdditionalTechnology> AdditionalTechnologies { get; set; }

    public virtual DbSet<Condition> Conditions { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<ExperienceResponsibility> ExperienceResponsibilities { get; set; }

    public virtual DbSet<ExperienceTechnology> ExperienceTechnologies { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillCategory> SkillCategories { get; set; }

    public virtual DbSet<Summary> Summaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Additional>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("additional_pkey");

            entity.ToTable("additional");

            entity.HasIndex(e => e.Code, "additional_code_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Profile).WithMany(p => p.Additionals)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("additional_profile_id_fkey");
        });

        modelBuilder.Entity<AdditionalTechnology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("additional_technologies_pkey");

            entity.ToTable("additional_technologies");

            entity.HasIndex(e => new { e.AdditionalId, e.SkillId }, "uq_additional_technologies").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.AdditionalId).HasColumnName("additional_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");

            entity.HasOne(d => d.Additional).WithMany(p => p.AdditionalTechnologies)
                .HasForeignKey(d => d.AdditionalId)
                .HasConstraintName("additional_technologies_additional_id_fkey");

            entity.HasOne(d => d.Skill).WithMany(p => p.AdditionalTechnologies)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("additional_technologies_skill_id_fkey");
        });

        modelBuilder.Entity<Condition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("conditions_pkey");

            entity.ToTable("conditions");

            entity.HasIndex(e => e.ProfileId, "idx_conditions_profile");

            entity.HasIndex(e => new { e.ProfileId, e.Type, e.Value }, "uq_condition_typevalue").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .HasColumnName("icon");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .HasColumnName("value");

            entity.HasOne(d => d.Profile).WithMany(p => p.Conditions)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("conditions_profile_id_fkey");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contacts_pkey");

            entity.ToTable("contacts");

            entity.HasIndex(e => e.ProfileId, "idx_contacts_profile");

            entity.HasIndex(e => new { e.ProfileId, e.Type, e.Value }, "uq_contact_typevalue").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .HasColumnName("icon");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .HasColumnName("value");

            entity.HasOne(d => d.Profile).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("contacts_profile_id_fkey");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("educations_pkey");

            entity.ToTable("educations");

            entity.HasIndex(e => e.ProfileId, "idx_educations_profile");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.GraduationYear).HasColumnName("graduation_year");
            entity.Property(e => e.Institution)
                .HasMaxLength(255)
                .HasColumnName("institution");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Profile).WithMany(p => p.Educations)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("educations_profile_id_fkey");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("experiences_pkey");

            entity.ToTable("experiences");

            entity.HasIndex(e => e.Code, "experiences_code_key").IsUnique();

            entity.HasIndex(e => e.ProfileId, "idx_experiences_profile");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Profile).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("experiences_profile_id_fkey");
        });

        modelBuilder.Entity<ExperienceResponsibility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("experience_responsibilities_pkey");

            entity.ToTable("experience_responsibilities");

            entity.HasIndex(e => e.ExperienceId, "idx_experience_responsibilities_experience");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.ExperienceId).HasColumnName("experience_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Experience).WithMany(p => p.ExperienceResponsibilities)
                .HasForeignKey(d => d.ExperienceId)
                .HasConstraintName("experience_responsibilities_experience_id_fkey");
        });

        modelBuilder.Entity<ExperienceTechnology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("experience_technologies_pkey");

            entity.ToTable("experience_technologies");

            entity.HasIndex(e => e.ExperienceId, "idx_experience_technologies_experience");

            entity.HasIndex(e => e.SkillId, "idx_experience_technologies_skill");

            entity.HasIndex(e => new { e.ExperienceId, e.SkillId }, "uq_experience_technology").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ExperienceId).HasColumnName("experience_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");

            entity.HasOne(d => d.Experience).WithMany(p => p.ExperienceTechnologies)
                .HasForeignKey(d => d.ExperienceId)
                .HasConstraintName("experience_technologies_experience_id_fkey");

            entity.HasOne(d => d.Skill).WithMany(p => p.ExperienceTechnologies)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("experience_technologies_skill_id_fkey");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("languages_pkey");

            entity.ToTable("languages");

            entity.HasIndex(e => e.ProfileId, "idx_languages_profile");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Language1)
                .HasMaxLength(50)
                .HasColumnName("language");
            entity.Property(e => e.Level)
                .HasMaxLength(10)
                .HasColumnName("level");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Profile).WithMany(p => p.Languages)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("languages_profile_id_fkey");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("profiles_pkey");

            entity.ToTable("profiles");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("skill_pkey");

            entity.ToTable("skill");

            entity.HasIndex(e => e.Code, "skill_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsVisibleGral)
                .HasDefaultValue(true)
                .HasColumnName("is_visible_gral");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.SkillCategoryId).HasColumnName("skill_category_id");

            entity.HasOne(d => d.SkillCategory).WithMany(p => p.Skills)
                .HasForeignKey(d => d.SkillCategoryId)
                .HasConstraintName("skill_skill_category_id_fkey");
        });

        modelBuilder.Entity<SkillCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("skill_category_pkey");

            entity.ToTable("skill_category");

            entity.HasIndex(e => e.ProfileId, "idx_skill_category_profile");

            entity.HasIndex(e => e.Code, "skill_category_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .HasColumnName("code");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");

            entity.HasOne(d => d.Profile).WithMany(p => p.SkillCategories)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("skill_category_profile_id_fkey");
        });

        modelBuilder.Entity<Summary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("summaries_pkey");

            entity.ToTable("summaries");

            entity.HasIndex(e => e.ProfileId, "idx_summaries_profile");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Profile).WithMany(p => p.Summaries)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("summaries_profile_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
