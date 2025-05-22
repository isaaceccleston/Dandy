using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Godot;

public partial class Customer : CharacterBody2D
{
    [Export]
    public Node2D tilemap;
    public TileMapLayer tilemaplayer;
    [Export]
    public Vector2I browsePosition;
    [Export]
    public Vector2I tillPosition;
    [Export]
    public Vector2I doorInPosition;
    [Export]
    public Vector2I doorOutPosition;
    public Main main;

    public Sprite2D recordSprite;
    public Record chosenRecord;

    public void Init(Main _main)
    {
        this.main = _main;
        tilemap = (Node2D)GetParent();
        tilemaplayer = tilemap.GetChild<TileMapLayer>(5);
        recordSprite = GetChild<Sprite2D>(2);
    }

    public async void PurchaseSequence()
    {
        Random rng = new Random();

        //start at door
        MoveTo(doorInPosition);
        await WaitSeconds(3);

        //start browsing
        MoveTo(browsePosition);
        await WaitSeconds(3);
        chosenRecord = main.records[rng.Next(main.records.Count)];
        recordSprite.Texture = ImageTexture.CreateFromImage(Image.LoadFromFile($"Assets/Artworks/{chosenRecord.title.Replace(" ", "").Replace("/", "").ToLower()}.png"));
        recordSprite.Visible = true;
        await WaitSeconds(2); 

        //move to till
        MoveTo(tillPosition);
        main.adjustBalance(chosenRecord.price);
        await WaitSeconds(3);

        //move to door
        MoveTo(doorOutPosition);
        await WaitSeconds(1);

        //destroyed
        this.Free();
    }

     public void MoveTo(Vector2I newPosMap)
    {
        Position = tilemaplayer.MapToLocal(newPosMap);
    }

    public async Task WaitSeconds(int seconds)
    {
        await ToSignal(GetTree().CreateTimer(seconds), SceneTreeTimer.SignalName.Timeout);
    }

}