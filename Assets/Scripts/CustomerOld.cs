// using System.Collections.Generic;
// using System.Diagnostics;
// using Godot;
// using Godot.Collections;

// public partial class Customer : CharacterBody2D
// {
//     [Export]
//     public Node2D tilemap;
//     public TileMapLayer tilemaplayer;
//     [Export]
//     Vector2I targetPositionGlobal;

//     public override void _Ready()
//     {

//         Debug.WriteLine("Customer found");
//         // tilemap = GetNode<Node2D>("Tilemap");
//         tilemaplayer = tilemap.GetChild<TileMapLayer>(5);

//         Node[,] grid = getArrayFromTilemap(tilemaplayer);

//         Node startNode = new Node(true, Position, tilemaplayer.LocalToMap(Position).X, tilemaplayer.LocalToMap(Position).Y );
//         Node targetNode = new Node(true, targetPositionGlobal, tilemaplayer.LocalToMap(targetPositionGlobal).X, tilemaplayer.LocalToMap(targetPositionGlobal).Y);

//         Debug.WriteLine(startNode.gridX + "," + startNode.gridY);
//         Debug.WriteLine(targetNode.gridX + "," + targetNode.gridY);

//         List<Node> openSet = new List<Node>();
//         HashSet<Node> closedSet = new HashSet<Node>();
//         openSet.Add(startNode);

//         while(openSet.Count > 0){
//             Node currentNode = openSet[0];
//             for (int i = 1; i < openSet.Count; i++)
//             {
//                 if(openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost){
//                     currentNode = openSet[i];
//                 }
//             }

//             openSet.Remove(currentNode);
//             closedSet.Add(currentNode);

//             if(currentNode == targetNode){
//                 RetracePath(startNode,targetNode);
//                 return;
//             }

//             foreach(Node neighbour in GetNeighbours(grid, currentNode)){
//                 if(!neighbour.walkable || closedSet.Contains(neighbour)){
//                     continue;
//                 }

//                 int newMovementCostToNeighbour = currentNode.gCost + getDistance(currentNode, neighbour);
//                 if(newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)){
//                     neighbour.gCost = newMovementCostToNeighbour;
//                     neighbour.hCost = getDistance(neighbour, targetNode);
//                     neighbour.parent = currentNode;

//                     if(!openSet.Contains(neighbour)){
//                         openSet.Add(neighbour);
//                     }
//                 }
//             }
//         }
//     }

//     public void RetracePath(Node startNode, Node endNode){
//         List<Node> path = new List<Node>();
//         Node currentNode = endNode;

//         while(currentNode != startNode){
//             path.Add(currentNode);
//             currentNode = currentNode.parent;
//         }

//         path.Reverse();
//     }

//     public int getDistance(Node nodeA, Node nodeB){
//         int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
//         int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

//         if(dstX > dstY){
//             return 14*dstY + 10*(dstX-dstY);
//         }
//         return 14*dstX + 10*(dstY-dstX);
//     }

//     public Node[,] getArrayFromTilemap(TileMapLayer tilemap){
//         Array<Vector2I> blockedCells = tilemap.GetUsedCells();
//         Node[,] roomGrid = new Node[20,11];
        
//         for (int i = 0; i < 20; i++)
//         {
//             for (int j = 0; j < 11; j++)
//             {
//                 if(blockedCells.Contains(new Vector2I(i,j))){
//                     roomGrid[i,j] = new Node(false, tilemaplayer.MapToLocal(new Vector2I(i,j)), i, j);
//                 }
//                 else{
//                     roomGrid[i,j] = new Node(true, tilemaplayer.MapToLocal(new Vector2I(i,j)), i ,j);
//                 }
//             }
//         }

//         return roomGrid;
//     }

//     public List<Node> GetNeighbours(Node[,] grid, Node node){
//         List<Node> neighbours = new List<Node>();

//         for(int x = -1; x <= 1; x++){
//             for(int y = -1; y <= 1; y++){
//                 if(x == 0 & y == 0){
//                     continue;
//                 }

//                 int checkX = node.gridX + x;
//                 int checkY = node.gridY + y;

//                 if(checkX >= 0 && checkX < 20){
//                     if(checkY >= 0 && checkY < 11){
//                         neighbours.Add(grid[checkX,checkY]);
//                     }  
//                 }
//             }
//         }

//         return neighbours;
//     }



// }