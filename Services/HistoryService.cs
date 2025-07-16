using System.Text.Json;
using Calculator.Interfaces;
using Calculator.Models;

namespace Calculator.Services;

public class HistoryService : IHistoryService
{
    public void ClearHistory(List<HistoryItem> history)
    {
        if (history.Count == 0)
        {
            Console.WriteLine("There is nothing to delete!");
            return;
        }

        var displayService = new DisplayService();

        while (true)
        {
            ShowHistory(history);
            string input = displayService.ReadInput("if you want to clear all type “all”, to go back  “cancel”, choose id to remove single element");

            if (input == "all")
            {
                history.Clear();
                displayService.Print("cleared");
                return;
            }
            else if (input == "cancel")
                return;

            else if (int.TryParse(input, out int id))
            {
                var allIds = history.Select(x => x.Id).ToList();

                if (allIds.Contains(id))
                {
                    var index = allIds.IndexOf(id);
                    history.Remove(history[index]);
                    Console.WriteLine($"{id} - id removed");
                    return;
                }
            }
            else
            {
                Console.WriteLine("This command is not available");
            }
        }
    }

    public void LoadHistory(string path, List<HistoryItem> history)
    {
        var json = File.ReadAllText(path); ;
        var loadedHistory = JsonSerializer.Deserialize<List<HistoryItem>>(json);

        if (loadedHistory != null)
        {
            history.AddRange(loadedHistory);
            Console.WriteLine("load history: " + history.Count);
        }

        else
            Console.WriteLine($"History {history.Count} is empty");
    }

    public void SaveHistory(List<HistoryItem> history, string path)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        string json = JsonSerializer.Serialize(history, options);

        File.WriteAllText(path, json);
    }

    public void ShowHistory(List<HistoryItem> history)
    {
        var displayService = new DisplayService();

        if (history.Count == 0)
            Console.WriteLine("History is empty!!!");

        else
            displayService.PrintHistory(history);
    }
}