var output = new List<LogRecord>();

List<string> paths = Directory.EnumerateFiles(@"./", "*.txt").ToList();
foreach (string filePath in paths)
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var logRecord = new LogRecord(line);
            if (logRecord.level == "INFO")
            {
                output.Add(logRecord);
            }
        }
    }
}

output.ForEach(Console.WriteLine);


class LogRecord
{
    public LogRecord(string line)
    {
        string[] arr = line.Split('\t');
        date = DateTime.Parse(arr[0]);
        level = arr[1];
        message = arr[2];
    }
    public DateTime date { get; set; }
    public string message { get; set; }
    public string level { get; set; }

    public override string ToString()
    {
        return date + " " + message;
    }
}

