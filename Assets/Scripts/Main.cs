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

    public override void _Ready()
    {
        rng = new Random();

        balance = 0;
        records = LoadRecords("Assets/records.txt");

        Cheatui cheatUi = GetNode<Cheatui>("CheatUI");
        cheatUi.Init(this);

        customerScene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/customer.tscn");
    }

    public void Customer()
    {
        Customer customer = (Customer)customerScene.Instantiate();
        GetNode("Tilemap").AddChild(customer);
        customer.Init(this);
        customer.PurchaseSequence();
    }

    public override void _PhysicsProcess(double delta)
    {
        if (rng.Next(gameSpeed) == 0)
        {
            Customer();
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
                     $"Assets/Artworks/{details[0].Replace(" ", "").Replace("/", "").ToLower()}.png")
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

