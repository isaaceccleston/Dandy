using Godot;
using System;

public partial class Cheatui : Control
{
    Main main;
    Label balanceLabel;

    public override void _Ready()
    {
        balanceLabel = GetNode<Label>("Panel/VBoxContainer/Label");
    }

    public void Init(Main main){
        this.main = main;
    }

    public void increase_button_pressed(){
        main.adjustBalance(50);
    }
    public void decrease_button_pressed(){
        main.adjustBalance(-10);
    }

    public void view_library_pressed(){
        
    }

    public override void _Process(double delta)
    {
        balanceLabel.Text = $"Wallet\n£{main.balance}";
    }
}
