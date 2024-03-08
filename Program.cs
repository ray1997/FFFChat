using CsvHelper.Configuration;
using FFFChat.Model;
using System.Diagnostics;
using System.Globalization;

var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
{
    Delimiter = ",",
    PrepareHeaderForMatch = header => header.Header.ToLower(),
    MissingFieldFound = null,
    BadDataFound = null
};

using var csv = new CsvHelper.CsvReader(new StreamReader("F:\\FFF\\chat.csv", System.Text.Encoding.UTF8), config);
csv.Context.RegisterClassMap<MessageMapper>();
csv.Context.Configuration.HeaderValidated = null;
var records = csv.GetRecords<Message>();
var messages = records.ToList<Message>();

//Filter to just friday

//var filtered = messages.Where(msg => msg.Date.DayOfWeek == DayOfWeek.Friday &&
//msg.Date.TimeOfDay >= TimeSpan.FromHours(17.5) &&
//msg.Date.TimeOfDay <= TimeSpan.FromHours(19.5));
//Until 28 October 2023: No Daylight Time Saving: FFF Released on 06:00
//After 28 Oct 2023: DTS FFF Released 07:00
var inb4DST = messages.Where(msg => msg.Date.DayOfWeek == DayOfWeek.Friday &&
msg.Date.Month < 10 && msg.Date.Day < 28 &&
msg.Date.TimeOfDay >= TimeSpan.FromHours(17.45) &&
msg.Date.TimeOfDay <= TimeSpan.FromHours(18.55));
var DST = messages.Where(msg => msg.Date.DayOfWeek == DayOfWeek.Friday &&
msg.Date.Month >= 10 && msg.Date.Day >= 28 &&
msg.Date.TimeOfDay >= TimeSpan.FromHours(18.45) &&
msg.Date.TimeOfDay <= TimeSpan.FromHours(19.55));


Dictionary<int, int> messagePer5MinAll = [];
int at0 = 0;

//Before DST
foreach (var message in inb4DST)
{
    if (message.Date.Hour == 18 && message.Date.Minute == 0)
        at0++;
    int relateToFFF = (message.Date.TimeOfDay - TimeSpan.FromHours(18)).Minutes;
    int key = (message.Date.Hour * 100) + message.Date.Minute;
    if (key <= 1730 && key >= 1830)
    {
        continue;
    }
    int actualKey = relateToFFF - (relateToFFF % 5);
    if (messagePer5MinAll.ContainsKey(actualKey))
    {
        messagePer5MinAll[actualKey]++;
    }
    else
    {
        messagePer5MinAll.Add(actualKey, 1);
    }
}

//DST
foreach (var message in DST)
{
    if (message.Date.Hour == 19 && message.Date.Minute == 0)
        at0++;
    int relateToFFF = (message.Date.TimeOfDay - TimeSpan.FromHours(19)).Minutes;
    int key = (message.Date.Hour * 100) + message.Date.Minute;
    if (key <= 1830 && key >= 1930)
    {
        continue;
    }
    if (relateToFFF < 0)
    {
        Debug.Write(relateToFFF);
    }
    int actualKey = relateToFFF - (relateToFFF % 5);
    if (messagePer5MinAll.ContainsKey(actualKey))
    {
        messagePer5MinAll[actualKey]++;
    }
    else
    {
        messagePer5MinAll.Add(actualKey, 1);
    }
}
//Counting// Find the maximum message count
int maxCount = messagePer5MinAll.Values.Max();

// Adjustable width parameter for the bars
int barWidth = 50; // Default width

// Output the graph
foreach (var kvp in messagePer5MinAll.OrderBy(x => x.Key))
{
    int percentage = (int)Math.Round((double)kvp.Value / maxCount * barWidth);
    string bar = new string('#', percentage) + new string('-', barWidth - percentage); // Bar length is adjustable
    if (kvp.Key >= 0)
        Console.WriteLine($"{kvp.Key:000} {bar} {kvp.Value}");
    else
        Console.WriteLine($"{kvp.Key:00} {bar} {kvp.Value}");

}

Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine($"At exact time FFF announce, there's {at0} message(s)");
Console.WriteLine($"Or around {at0 / 27}, every Friday");
