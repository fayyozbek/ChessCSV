using System.Data;

namespace ChessCSV;

public class ChessPlayer
{   
    public int Rank { get; set; }
    public string Name { get; set;}
    public string Title { get; set; }
    public string Country { get; set; }
    public int Rating { get; set; }
    public int GamesNum { get; set; }
    public int YearB { get; set; }

    public ChessPlayer(int rank, string name, string title, string country, int rating, int gamesNum, int yearB)
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