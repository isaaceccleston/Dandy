using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public partial class Main : Node
{
    public int balance {get; set;}
    public List<Record> records {get; set;}
    PackedScene customerScene;
    Random rng;
    [Export]
    int gameSpeed;
    [Export]
    bool customerSpawning;
    [Export]
    Control stockUI;
    public List<Customer> customers;

    // initial definitions
    public override void _Ready()
    {
        rng = new Random();
        balance = 0;
        records = LoadRecords("Assets/records.txt");
        Cheatui cheatUi = GetNode<Cheatui>("CheatUI");
        cheatUi.Init(this);
        customerScene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/customer.tscn");
        customers = new List<Customer>();
    }

    public void SetStock()
    {
        for (int i = 1; i <= records.Count; i++)
        {
            GetNode<TextureRect>($"StockUI/StockGrid/StockCoverImage{i}").Texture = ImageTexture.CreateFromImage(Image.LoadFromFile(records[i - 1].artworkPath));
            GetNode<Label>($"StockUI/StockGrid/StockCoverImage{i}/CountLabel").Text = $"{records[i - 1].inStock}";
        }
    }

    public void CustomerInstance()
    {
        Customer customer = (Customer)customerScene.Instantiate();
        GetNode("Tilemap").AddChild(customer);
        customers.Add(customer);
        customer.Run(this);
    }

    public override void _PhysicsProcess(double delta)
    {
        SetStock();

        if (customerSpawning && rng.Next(gameSpeed) == 0)
        {
            CustomerInstance();
        }
    }

    public List<Record> LoadRecords(string recordsPath)
    {
        records = new List<Record>();

        try
        {
            using (StreamReader sw = new StreamReader(recordsPath))
            {
                string[] lines = sw.ReadToEnd().Split('\n');
                foreach (string line in lines.SkipLast(1))
                {
                    string[] details = line.Split(";");
                    records.Add(new Record(
                     details[0],
                     details[1],
                     details[2].ToInt(),
                     $"Assets/Artworks/{details[0].Replace(" ", "").Replace("/", "").ToLower()}.png",
                     details[3].ToInt())
                     );
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine("erorr loading records\n" + e);
        }

        return records;
    }

    public void adjustBalance(int inc)
    {
        balance += inc;
    }
}

