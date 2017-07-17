namespace WindsoulDataFile
{
    public class WindsoulFileEntry
    {
        public uint Id { get; internal set; }

        public uint Offset { get; internal set; }

        public int Size { get; internal set; }

        public uint Reserved { get; internal set; }

        public byte[] Content { get; set; }

        public WindsoulFileEntry()
        {
        }
    }
}
