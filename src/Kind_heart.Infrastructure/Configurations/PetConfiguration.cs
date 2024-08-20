using Kind_heart.Domain.Models;
using Kind_heart.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kind_heart.Infrastructure.Configurations;

public class PetConfiguration: IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(p => p.Specie)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        
        builder.Property(p => p.Breed)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(p => p.Color)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
        
        builder.Property(p => p.Health)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        
        builder.Property(p => p.Address)
            .IsRequired()
            .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
        
        builder.Property(p => p.Phone)
            .IsRequired()
            .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);

        builder.Property(p => p.Weight)
            .IsRequired();
        
        builder.Property(p => p.Height)
            .IsRequired();
        
        builder.Property(p => p.Castrated)
            .IsRequired();
        
        builder.Property(p => p.Vaccinated)
            .IsRequired();
        
        builder.Property(p => p.Birthday)
            .IsRequired();
        
        builder.Property(p => p.CreatedDate)
            .IsRequired();

        builder.Property(p => p.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasDefaultValue(HelpStatus.NeedsHelp); 
        
        builder.OwnsOne(p => p.RequisiteDetails, pb =>
        {
            pb.ToJson();
            pb.OwnsMany(r => r.Requisites, rb =>
            {
                rb.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                rb.Property(r => r.Description)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_HIGH_TEXT_LENGTH);
            });
        });
        
        builder.OwnsOne(p => p.PetPhotoDetails, pb =>
        {
            pb.ToJson();
            pb.OwnsMany(pph => pph.PetPhotos, pphb =>
            {
                pphb.Property(r => r.Path)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_LOW_TEXT_LENGTH);
                pphb.Property(r => r.IsMainPhoto)
                    .IsRequired();
            });
        });











    }
}