using Godot;
using System;
using System.Diagnostics;

public partial class Binrecord : VBoxContainer
{
    Record record;
    TextureRect artworkRect;
    Label titleLabel;
    Label artistLabel;
    Label priceLabel;
    public void Init(Record record){
        this.record = record;
        artworkRect = GetNode<TextureRect>("artworkrect");
        titleLabel = GetNode<Label>("titlelabel");
        artistLabel = GetNode<Label>("artistlabel");
        priceLabel = GetNode<Label>("pricelabel");
    }

    public override void _Process(double delta)
    {
        artworkRect.Texture = ImageTexture.CreateFromImage(Image.LoadFromFile(record.artworkPath));
        titleLabel.Text = record.title;
        artistLabel.Text = record.artist;
        priceLabel.Text = $"£{record.price.ToString()}";
    }
}
