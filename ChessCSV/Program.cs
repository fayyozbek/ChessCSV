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
        bool firstLineSkiped = false;
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (firstLineSkiped)
            {
                
                var values = line.Split(";");
                int rank = Int32.Parse(values[0]);
                int rating = Int32.Parse(values[4], NumberStyles.AllowThousands);
                int games = Int32.Parse(values[5], NumberStyles.AllowThousands);
                int yearB = Int32.Parse(values[6], NumberStyles.AllowThousands);
                
                ChessPlayer player = new ChessPlayer(rank, values[1], values[2], values[3], rating, games, yearB);
                models.Add(player);
            }
            else
            {
                firstLineSkiped = true;
            }
            
        }
        int counter = 1;
        for (int i = 1; i < models.Count; i++)
        {
            if (models[i].YearB <1980)
            {
                logger.LogInformation("++ "+models[i].Rank+ " ++ "+models[i].Name+ " ++ "+models[i].Title+ " ++ "+models[i].Country+ " ++ "+models[i].Rating+ " ++ "+models[i].GamesNum+ " ++ "+models[i].YearB+" ++");
                counter++;
            }

            if (counter > 10)
                i = models.Count;

        }
        

    }
}