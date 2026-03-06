using System.Collections.Generic;
using UnityEngine;

namespace DungeonGenerator.Data
{
    public class DungeonGraph
    {
        private readonly Dictionary<string, DungeonNode> _nodes = new Dictionary<string, DungeonNode>();
        private readonly List<DungeonEdge> _edges = new List<DungeonEdge>();
        private readonly Dictionary<Vector2Int, string> _reservedPositions = new Dictionary<Vector2Int, string>();

        public IEnumerable<DungeonNode> Nodes => _nodes.Values;
        public int NodeCount => _nodes.Count;

        public string StartNodeID { get; set; }
        public string ExitNodeID { get; set; }

        public void AddNode(DungeonNode node)
        {
            _nodes[node.ID] = node;
            ReservePosition(node.GridPosition, node.ID);
        }

        public DungeonNode GetNodeByID(string id)
        {
            _nodes.TryGetValue(id, out DungeonNode node);
            return node;
        }

        public void AddEdge(DungeonEdge edge)
        {
            if (edge == null || edge.FromID == edge.ToID)
                return;

            if (ContainsEdge(edge.FromID, edge.ToID))
                return;

            _edges.Add(edge);
        }

        public IEnumerable<DungeonEdge> GetEdgesFrom(string nodeID)
        {
            foreach (var edge in _edges)
            {
                if (edge.FromID == nodeID)
                    yield return edge;
            }
        }

        public IEnumerable<DungeonEdge> GetEdgesForNode(string nodeID)
        {
            foreach (var edge in _edges)
            {
                if (edge.FromID == nodeID || edge.ToID == nodeID)
                    yield return edge;
            }
        }

        public bool IsPositionOccupied(Vector2Int position)
        {
            return _reservedPositions.ContainsKey(position);
        }

        public bool IsPositionedOccupied(Vector2Int position)
        {
            return IsPositionOccupied(position);
        }

        public void ReservePosition(Vector2Int position, string nodeID)
        {
            _reservedPositions[position] = nodeID;
        }

        private bool ContainsEdge(string idA, string idB)
        {
            foreach (var edge in _edges)
            {
                if ((edge.FromID == idA && edge.ToID == idB) || (edge.FromID == idB && edge.ToID == idA))
                    return true;
            }

            return false;
        }
    }
}
