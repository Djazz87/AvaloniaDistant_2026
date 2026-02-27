using System;

namespace AvaloniaDistant.Models;

public class IllnessRecordDTO
{
    public string FullName { get; set; }      
    public string Department { get; set; }   
    public DateTime StartDate { get; set; }  
    public DateTime EndDate { get; set; }
    public int Days { get; set; }
    public string Illness { get; set; }
}