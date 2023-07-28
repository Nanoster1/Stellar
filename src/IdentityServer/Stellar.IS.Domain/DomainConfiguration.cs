using System.Globalization;

namespace Stellar.IS.Domain;

public static class DomainConfiguration
{
    public static CultureInfo CultureInfo { get; private set; } = CultureInfo.InvariantCulture;
    public static TimeSpan TimeOffset { get; private set; } = TimeSpan.Zero;

    public static void SetDomainConfiguration(
        CultureInfo cultureInfo,
        TimeSpan timeOffset)
    {
        CultureInfo = cultureInfo;
        TimeOffset = timeOffset;
    }
}