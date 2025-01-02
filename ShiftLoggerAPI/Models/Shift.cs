namespace ShiftsLoggerAPI.Models;

public class Shift
{
    public int ShiftId { get; set; }
    //public Employee? Employee { get; set; }
    public string? EmployeeName { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }

    private int? _manualDuration;
    public int ShiftDurationHours   
    {
        get
        {
            if (_manualDuration.HasValue)
            {
                return _manualDuration.Value;
            }

            var endTime = EndDateTime;
            var startTime = StartDateTime;

            if (EndDateTime < StartDateTime)
            {
                endTime = EndDateTime.AddDays(1);
            }
            return endTime.Subtract(startTime).Hours;
        }
        set
        {
            _manualDuration = value;
        }
    }
}