namespace WorkSchedule.DataAccessLayer.Entities;

public class RefreshToken : BaseEntity<int>
{
    public string Token { get; set; } = null!;
    public long ExpireAtUnixTimeSecUtc { get; set; }
    public bool IsValid { get; set; }
    public virtual User User { get; set; } = null!;
    public int UserId { get; set; }
}