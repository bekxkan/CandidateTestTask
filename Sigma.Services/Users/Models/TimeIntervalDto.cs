namespace Sigma.Services.Users.Models;

public struct TimeIntervalDto
{
    public int HourStart { get; set; }

    public int? MinuteStart { get; set; }

    public int HourEnd { get; set; }

    public int? MinuteEnd { get; set; }
}

public static class TimeIntervalDtoExtensions
{
    public static TimeSpan? GetTimeStart(this TimeIntervalDto? timeInterval) =>
        timeInterval == null
            ? null
            : TimeSpan.FromMinutes(timeInterval.Value.HourStart * 60 +
                                   timeInterval.Value.MinuteStart.GetValueOrDefault());

    public static TimeSpan? GetTimeEnd(this TimeIntervalDto? timeInterval) =>
        timeInterval == null
            ? null
            : TimeSpan.FromMinutes(timeInterval.Value.HourEnd * 60 + timeInterval.Value.MinuteEnd.GetValueOrDefault());
}
