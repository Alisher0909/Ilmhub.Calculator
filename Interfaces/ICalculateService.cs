using Calculator.Models;

namespace Calculator.Interfaces;

public interface ICalculateService
{
    void Calculate(List<HistoryItem> history);
}