using System.ComponentModel;

public class Record{
    public string title {get; set;}
    public string artist {get; set;}
    public int price {get; set;}
    public string artworkPath {get; set;}
    public int inStock { get; set; }

    public Record(string title, string artist, int price, string artworkPath, int inStock)
    {
        this.title = title;
        this.artist = artist;
        this.price = price;
        this.artworkPath = artworkPath;
        this.inStock = inStock; 
    }
}