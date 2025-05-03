using Calculator.Models;

namespace Calculator.Interfaces;

public interface IDisplayService
{
    void Print(string message);
    string ReadInput(string message);
    string ReadInput();
    void PrintHistory(List<HistoryItem> history);
}