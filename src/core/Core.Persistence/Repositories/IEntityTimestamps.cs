namespace Core.Persistence.Repositories;

public interface IEntityTimestamps
{
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedTDate { get; set; }
}