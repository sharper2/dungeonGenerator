using UnityEngine;

namespace DungeonGenerator.Data
{
    public class DungeonNode
    {
        public string ID { get; }
        public Vector2Int GridPosition { get; }
        public Vector2Int Size { get; set; }
        public int Depth { get; set; }
        public DungeonNodeType NodeType { get; set; }

        public DungeonNode(string id, Vector2Int gridPosition)
        {
            ID = id;
            GridPosition = gridPosition;
            Size = Vector2Int.one;
            Depth = -1;
            NodeType = DungeonNodeType.Room;
        }
    }
}
