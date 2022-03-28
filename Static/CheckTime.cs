using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
public class CheckTime : Singleton<CheckTime>
{
    DateTimeOffset? DT = DateTimeOffset.MinValue;
    public async Task<DateTimeOffset> GetTime()
    {
        DT = await GetCurrentTime();
        return DT.Value;
    }

    private static async Task<DateTimeOffset?> GetCurrentTime()
    {
        var sites = new string[]
        {
            "http://www.microsoft.com",
            "http://www.google.com",
            "https://nist.time.gov"
        };

        foreach (var site in sites)
        {
            try
            {
                var dt = await Task.Run(() =>
                {
                    var dt = GetTimeFromSite(site);
                    if (dt != null)
                    {
                        return dt;
                    }
                    return DateTimeOffset.MinValue;
                });
                return dt;
            }
            catch
            {
                continue;
            }
        }
        return DateTimeOffset.MinValue;
    }

    private static DateTimeOffset? GetTimeFromSite(string site)
    {
        var req = WebRequest.Create(site);
        var resp = req.GetResponse();
        string currTime = resp.Headers["date"];
        var dt = DateTimeOffset.ParseExact(currTime,
            "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
            CultureInfo.InvariantCulture.DateTimeFormat,
            DateTimeStyles.AssumeUniversal);
        return dt;
    }
}
