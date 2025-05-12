namespace Calculator.Models;

public class HistoryItem
{
    public int Id { get; set; }
    public string? Expression { get; set; }
    public string? Result { get; set; } 
    public DateTime CreatedAt { get; set; }

    public override string ToString()
        => $"{Result!} | {CreatedAt.ToString("HH:mm:ss")}";
}