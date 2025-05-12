using System.Data;
using Calculator.Interfaces;
using Calculator.Models;

namespace Calculator.Services;

public class CalculateService : ICalculateService
{
    public void Calculate(List<HistoryItem> history)
    {
        var displayService = new DisplayService();

        var historyService = new HistoryService();

        while(true)
        {
            var dataTable = new DataTable();
        
            var expression = displayService.ReadInput("Enter expression or cancel: ");

            if (expression == "cancel")
                return;

            try
            {
                var result = Convert.ToDouble(dataTable.Compute(expression, null));

                string stringResult = $"{expression} = {result}";
                
                HistoryItem historyItem = new()
                {
                    Id = history.Count == 0 ? 1 : history.Last().Id + 1,
                    Expression = expression,
                    Result = stringResult,
                    CreatedAt = DateTime.Now
                };

                history.Add(historyItem); // " 5 + 3 = 8 "

                displayService.Print(stringResult);
            }
            catch (Exception)
            {
                displayService.Print("You did not entered expression");
            }
        }
    }
}