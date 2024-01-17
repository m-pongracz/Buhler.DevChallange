namespace Buhler.DevChallenge.Domain.Settings;

public class DbConnectionSettings
{
    public const string SectionName = "Database";
    
    public bool UseInMemoryDatabase { get; set; }
    
    public string ConnectionString { get; set; } = null!;
}