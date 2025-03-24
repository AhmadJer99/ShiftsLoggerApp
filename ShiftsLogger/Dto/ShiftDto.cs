namespace ShiftsLoggerUI.Dto;

public class ShiftDto
{
    public int EmpId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int ShiftDurationHours { get; set; }
}

