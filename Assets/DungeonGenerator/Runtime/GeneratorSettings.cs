using UnityEngine;

namespace DungeonGenerator
{
    [System.Serializable]
    public class GeneratorSettings
    {
        [Header("Grid")]
        public Vector2Int gridSize = new Vector2Int(20, 20);

        [Header("Rooms")] 
        public int minRooms = 5;
        public int maxRooms = 10;
        public Vector2Int minRoomSize = Vector2Int.one;
        public Vector2Int maxRoomSize = new Vector2Int(3, 3);

        [Header("Connectivity")] [Range(0, 1f)]
        public float loopProbability = 0.15f;

        [Header("Reproducibility")]
        public int seed = 0;
        public bool useRandomSeed = true;
    }
}
