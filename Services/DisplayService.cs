using Calculator.Models;
using Calculator.Interfaces;

namespace Calculator.Services;

public class DisplayService : IDisplayService
{
    public void Print(string message)
        => Console.WriteLine(message);

    public string ReadInput(string message)
    {
        Print(message);
        return ReadInput();   
    }

    public string ReadInput()
        => Console.ReadLine()!.Trim().ToLower();

    public void PrintHistory(List<HistoryItem> history)
    {
        if (history.Count == 0)
        {
            Print("History is empty");
            return;
        }
        
        for (int i = 0; i < history.Count; i++)
            Print($"({history[i].Id}). {history[i]}");
    }
}