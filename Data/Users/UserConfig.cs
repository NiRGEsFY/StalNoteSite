namespace StalNoteSite;

public class UserConfig
{
    public int Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public bool ShowGraph { get; set; }
    public bool ShowArt { get; set; }
}
