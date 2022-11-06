using System.Data;

namespace ChessCSV;

public class ChessPlayer
{   
    public string Rank { get; set; }
    public string Name { get; set;}
    public string Title { get; set; }
    public string Country { get; set; }
    public string Rating { get; set; }
    public string GamesNum { get; set; }
    public string YearB { get; set; }

    public ChessPlayer(string rank, string name, string title, string country, string rating, string gamesNum, string yearB)
    {
        this.Rank = rank;
        this.Name = name;
        this.Title = title;
        this.Country = country;
        this.Rating = rating;
        this.GamesNum = gamesNum;
        this.YearB = yearB;
    }
}