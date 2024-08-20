using Kind_heart.Domain.Models;
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

        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(v => v.Surname)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(v => v.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);

        builder.Property(v => v.Experience)
            .IsRequired();

        builder.Property(v => v.AdoptedAnimalsCount)
            .IsRequired();

        builder.Property(v => v.AnimalsNeedingHomeCount)
            .IsRequired();

        builder.Property(v => v.AnimalsInCareCount)
            .IsRequired();

        builder.Property(v => v.Phone)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.HasMany(v => v.Pet)
            .WithOne()
            .HasForeignKey("volunteer_id");

        builder.OwnsOne(v => v.RequisiteDetails, vb =>
        {
            vb.ToJson();
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
            vb.ToJson();
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