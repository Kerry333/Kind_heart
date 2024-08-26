using Kind_heart.Domain.Models;
using Kind_heart.Domain.Models.Volunteer;
using Kind_heart.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kind_heart.Infrastructure.Configurations;

public class VolunteerConfiguration: IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        builder.HasKey(v => v.Id);
        
        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));
        
        builder.ComplexProperty(v => v.FullName, fb =>
        {
            fb.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("first_name");
            fb.Property(f => f.MiddleName)
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("middle_name");
            fb.Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("last_name");
        });
        
        builder.ComplexProperty(v => v.Description, db =>
        {
            db.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH)
                .HasColumnName("description");
        });

        builder.ComplexProperty(v => v.Experience, exb =>
        {
            exb.Property(n => n.Value)
                .IsRequired()
                .HasColumnName("experience");
        });
        
        builder.ComplexProperty(v => v.Phone, pb =>
        {
            pb.Property(n => n.Value)
                .IsRequired()
                .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH)
                .HasColumnName("phone");
        });
        
        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");

        builder.OwnsOne(v => v.RequisiteDetails, vb =>
        {
            vb.ToJson("requisite_details");
            vb.OwnsMany(r => r.Requisites, rb =>
            {
                rb.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                rb.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
            });
        });

        builder.OwnsOne(v => v.SocialNetworkDetails, vb =>
        {
            vb.ToJson("social_network_details");
            vb.OwnsMany(sn => sn.SocialNetworks, snb =>
            {
                snb.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

                snb.Property(s => s.Path)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
            });

        });

    }
}