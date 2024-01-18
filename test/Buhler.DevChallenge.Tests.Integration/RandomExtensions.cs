namespace Buhler.DevChallenge.Tests.Integration;

public static class RandomExtensions
{
    public static Guid NextGuid(this Random r)
    {
        var guid = new byte[16];
        r.NextBytes(guid);

        return new Guid(guid);
    }
}
