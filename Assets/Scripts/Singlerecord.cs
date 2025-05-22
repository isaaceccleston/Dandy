using Godot;

public partial class Singlerecord : Control
{
    Image recordcover;
    Label title;
    Label artist;
    Label price;
    TextureRect background;
    TextureRect foreground;
    Record record;

    public override void _Ready(){
        title = GetNode<Label>("Album Info/Title");
        artist = GetNode<Label>("Album Info/Artist");
        price = GetNode<Label>("Album Info/Price");
        foreground = GetNode<TextureRect>("Album Info/Cover");
        background = GetNode<TextureRect>("CoverBG");

        title.Text = record.title;
        artist.Text = record.artist;
        price.Text = $"£{record.price}";
        recordcover = Image.LoadFromFile($"Assets/Artworks/{record.title.Replace(" ", "").Replace("/", "").ToLower()}.png");
        Texture2D covertexture = ImageTexture.CreateFromImage(recordcover);
        background.Texture = covertexture;
        foreground.Texture = covertexture;
    }

    public void Init(Record record){
        this.record = record;
    }
}
