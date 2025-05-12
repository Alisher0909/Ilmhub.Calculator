using Calculator.Models;
using Calculator.Services;

var calculateService = new CalculateService();
var historyService = new HistoryService();
var displayService = new DisplayService();

displayService.Print("Welcome to Calculator!\nAvailabe commands: calculate, history, clear, exit, cls");

List<HistoryItem> history = [];
historyService.LoadHistory("history.json", history);

while (true)
{
    var input = displayService.ReadInput("Enter command (calculate, history, clear, exit, cls): ");

    if (input == "exit")
        break;

    else if (input == "cls")
        Console.Clear();

    else if (input == "history") 
        historyService.ShowHistory(history);

    else if (input == "clear")
        historyService.ClearHistory(history);
        
    else if (input == "calculate")
         calculateService.Calculate(history);

    else
        Console.WriteLine("This command is not available");
}

historyService.SaveHistory(history, "history.json");
Console.WriteLine("Good bye");