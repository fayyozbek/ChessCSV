using System.Globalization;
using Microsoft.Extensions.Logging;
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
        var firstTenPlayer = models.Where(models => models.YearB < 1980).Take(10);
        foreach (var player in firstTenPlayer)
        {
            logger.LogInformation(counter+"++ "+player.Rank+ " ++ "+player.Name+ " ++ "+player.Title+ " ++ "+player.Country+ " ++ "+player.Rating+ " ++ "+player.GamesNum+ " ++ "+player.YearB+" ++");
            
        }
       
        

    }
}