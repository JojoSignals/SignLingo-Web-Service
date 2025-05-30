namespace Domain.Shared;

public class BaseModel
{
    public int Id { get; set; }
    public int CreatedUser { get; set; }
    public int? UpdatedUser { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsEnable { get; set; } = true;
}