// using System.Numerics;
// using System.Security.Cryptography.X509Certificates;

// public class Node{
//     public bool walkable;
//     public Godot.Vector2 worldPosition;
//     public int gCost;
//     public int hCost;
//     public int gridX;
//     public int gridY;
//     public Node parent;

//     public Node(bool _walkable, Godot.Vector2 _worldPos, int _gridx, int _gridy){
//         gridX = _gridx;
//         gridY = _gridy;
//         walkable = _walkable;
//         worldPosition = _worldPos;
//     }

//     public int fCost{
//         get{
//             return gCost + hCost;
//         }
//     }
// }