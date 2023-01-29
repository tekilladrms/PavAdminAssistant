using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShiftService.Domain.Entities;

namespace ShiftService.Persistence.Configurations;

public class ShiftConfiguraion : IEntityTypeConfiguration<Shift>
{
    public void Configure(EntityTypeBuilder<Shift> builder)
    {
        builder.ToTable("Shifts");
        builder.HasKey(shift => shift.Guid);
        builder.Property(shift => shift.Guid).ValueGeneratedNever();
        builder.Property(shift => shift.Date).ValueGeneratedNever();

        builder.OwnsOne(shift => shift.ShiftTime).Property(prop => prop.Start).HasColumnName("StartShift");
        builder.OwnsOne(shift => shift.ShiftTime).Property(prop => prop.End).HasColumnName("EndShift");

    }
}
