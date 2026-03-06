using UnityEngine;

namespace DungeonGenerator.Data
{
    public class DungeonEdge
    {
        public string FromID { get; }
        public string ToID { get; }
        public Vector2Int Direction { get; }
        public DungeonEdgeType EdgeType { get; set; }

        public DungeonEdge(string fromID, string toID, Vector2Int direction)
        {
            FromID = fromID;
            ToID = toID;
            Direction = direction;
            EdgeType = DungeonEdgeType.Corridor;
        }

        public string GetOtherNodeID(string nodeID)
        {
            if (nodeID == FromID)
                return ToID;

            if (nodeID == ToID)
                return FromID;

            return null;
        }
    }
}
