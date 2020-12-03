namespace CardGames
{
    public class BuffCounter
    {
        public ushort Count { get; set; }
        public bool HasBuff => Count != 0;
    }
}