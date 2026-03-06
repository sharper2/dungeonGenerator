namespace DungeonGenerator.Data
{
    public static class NodeIDFactory
    {
        private static int _counter = 0;

        public static string Next() => $"node{_counter++}";

        public static void Reset() => _counter = 0;
    }
}