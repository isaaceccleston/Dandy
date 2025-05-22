// using Godot;
// using System;

// public partial class Recordbin : Control
// {
//     Main main;
//     int startIndex;
//     PackedScene binRecordScene;
//     HBoxContainer HBox;

//     public void Init(Main main, int binNo){
//         this.main = main;
//         startIndex = binNo*3;

//         HBox = GetNode<HBoxContainer>("Panel/HBox");
//         binRecordScene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/binrecord.tscn");

//         for (int i = startIndex; i < startIndex+3; i++){
//             Binrecord binRecord = (Binrecord)binRecordScene.Instantiate();
//             binRecord.Init(main.records[i]);
//             HBox.AddChild(binRecord);
//         }
//     }

//     public void closePressed(){
//         main.freeRecordBin(this);
//     }
// }


