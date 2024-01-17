namespace Buhler.DevChallenge.Persistence;

public class UnsavedContext
{
    private readonly DevChallengeDbContext _context;

    public UnsavedContext(DevChallengeDbContext context)
    {
        _context = context;
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}