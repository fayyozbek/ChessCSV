using System.Globalization;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
namespace ChessCSV;
 using System.IO;


class Program {
   // private readonly  ILogger 
    static void Main(string[] arg)
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        ILogger logger = loggerFactory.CreateLogger<Program>();
        var reader = new StreamReader("/home/fayyozbek/Top100ChessPlayers.csv");
        List<ChessPlayer> models=new List<ChessPlayer>(); 
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(";");
            ChessPlayer player = new ChessPlayer(values[0], values[1], values[2], values[3], values[4], values[5],
                values[6]);
            models.Add(player);
        }
        int counter = 1;
        for (int i = 1; i < models.Count; i++)
        {
            if (Int32.Parse(models[i].YearB, NumberStyles.AllowThousands) <1980)
            {
                logger.LogInformation("++ "+models[i].Rank+ " ++ "+models[i].Name+ " ++ "+models[i].Title+ " ++ "+models[i].Country+ " ++ "+models[i].Rating+ " ++ "+models[i].GamesNum+ " ++ "+models[i].YearB+" ++");
                counter++;
            }

            if (counter > 10)
                i = models.Count;

        }
        

    }
}