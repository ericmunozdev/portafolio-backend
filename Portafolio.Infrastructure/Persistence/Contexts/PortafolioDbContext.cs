using Microsoft.EntityFrameworkCore;
using Portafolio.Infrastructure.Persistence.Entities;

namespace Portafolio.Infrastructure.Persistence.Contexts;

public partial class PortafolioDbContext : DbContext
{
    public PortafolioDbContext(DbContextOptions<PortafolioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalSkill> AdditionalSkills { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<ExperienceSkill> ExperienceSkills { get; set; }

    public virtual DbSet<Other> Others { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectSkill> ProjectSkills { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillsCategory> SkillsCategories { get; set; }

    public virtual DbSet<TypeContact> TypeContacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<AdditionalSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("additional_skills_pkey");

            entity.ToTable("additional_skills");

            entity.HasIndex(e => e.SkillId, "idx_additional_skills_skill_id");

            entity.HasIndex(e => new { e.ProfileId, e.SkillId }, "uq_additional_skill").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Profile).WithMany(p => p.AdditionalSkills)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("additional_skills_profile_id_fkey");

            entity.HasOne(d => d.Skill).WithMany(p => p.AdditionalSkills)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("additional_skills_skill_id_fkey");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contacts_pkey");

            entity.ToTable("contacts");

            entity.HasIndex(e => e.TypeContactId, "idx_contacts_type_contact_id");

            entity.HasIndex(e => new { e.ProfileId, e.TypeContactId, e.Value }, "uq_contact_typevalue").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(50)
                .HasColumnName("display_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Position)
                .HasDefaultValue((short)1)
                .HasColumnName("position");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.TypeContactId).HasColumnName("type_contact_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .HasColumnName("value");

            entity.HasOne(d => d.Profile).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("contacts_profile_id_fkey");

            entity.HasOne(d => d.TypeContact).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.TypeContactId)
                .HasConstraintName("contacts_type_contact_id_fkey");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("educations_pkey");

            entity.ToTable("educations");

            entity.HasIndex(e => e.ProfileId, "idx_educations_profile_id");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.GraduationYear).HasColumnName("graduation_year");
            entity.Property(e => e.Institution)
                .HasMaxLength(100)
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

            entity.HasIndex(e => e.ProfileId, "idx_experiences_profile_id");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Collapse)
                .HasDefaultValue(false)
                .HasColumnName("collapse");
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
            entity.Property(e => e.Responsibility).HasColumnName("responsibility");
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

        modelBuilder.Entity<ExperienceSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("experience_skills_pkey");

            entity.ToTable("experience_skills");

            entity.HasIndex(e => e.SkillId, "idx_experience_skills_skill_id");

            entity.HasIndex(e => new { e.ExperienceId, e.SkillId }, "uq_experience_skill").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ExperienceId).HasColumnName("experience_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MonthsExperience).HasColumnName("months_experience");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");

            entity.HasOne(d => d.Experience).WithMany(p => p.ExperienceSkills)
                .HasForeignKey(d => d.ExperienceId)
                .HasConstraintName("experience_skills_experience_id_fkey");

            entity.HasOne(d => d.Skill).WithMany(p => p.ExperienceSkills)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("experience_skills_skill_id_fkey");
        });

        modelBuilder.Entity<Other>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("others_pkey");

            entity.ToTable("others");

            entity.HasIndex(e => e.ProfileId, "idx_others_profile_id");

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
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.Text)
                .HasMaxLength(50)
                .HasColumnName("text");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Profile).WithMany(p => p.Others)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("others_profile_id_fkey");
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
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Presentation).HasColumnName("presentation");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebTitle)
                .HasMaxLength(255)
                .HasColumnName("web_title");
            entity.Property(e => e.WorkPosition)
                .HasMaxLength(255)
                .HasColumnName("work_position");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("projects_pkey");

            entity.ToTable("projects");

            entity.HasIndex(e => e.ProfileId, "idx_projects_profile_id");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
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

            entity.HasOne(d => d.Profile).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("projects_profile_id_fkey");
        });

        modelBuilder.Entity<ProjectSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_skills_pkey");

            entity.ToTable("project_skills");

            entity.HasIndex(e => e.SkillId, "idx_project_skills_skill_id");

            entity.HasIndex(e => new { e.ProjectId, e.SkillId }, "uq_project_skill").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.MonthsExperience).HasColumnName("months_experience");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.SkillId).HasColumnName("skill_id");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectSkills)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("project_skills_project_id_fkey");

            entity.HasOne(d => d.Skill).WithMany(p => p.ProjectSkills)
                .HasForeignKey(d => d.SkillId)
                .HasConstraintName("project_skills_skill_id_fkey");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("skills_pkey");

            entity.ToTable("skills");

            entity.HasIndex(e => e.FatherId, "idx_skills_father_id");

            entity.HasIndex(e => e.ProfileId, "idx_skills_profile_id");

            entity.HasIndex(e => new { e.SkillCategoryId, e.FatherId, e.Name }, "uq_skill_name").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.FatherId).HasColumnName("father_id");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.SkillCategoryId).HasColumnName("skill_category_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Father).WithMany(p => p.InverseFather)
                .HasForeignKey(d => d.FatherId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("skills_father_id_fkey");

            entity.HasOne(d => d.Profile).WithMany(p => p.Skills)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("skills_profile_id_fkey");

            entity.HasOne(d => d.SkillCategory).WithMany(p => p.Skills)
                .HasForeignKey(d => d.SkillCategoryId)
                .HasConstraintName("skills_skill_category_id_fkey");
        });

        modelBuilder.Entity<SkillsCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("skills_categories_pkey");

            entity.ToTable("skills_categories");

            entity.HasIndex(e => new { e.ProfileId, e.Name }, "uq_skill_category_name").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Profile).WithMany(p => p.SkillsCategories)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("skills_categories_profile_id_fkey");
        });

        modelBuilder.Entity<TypeContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_contacts_pkey");

            entity.ToTable("type_contacts");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
