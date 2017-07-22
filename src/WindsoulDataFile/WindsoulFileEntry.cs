namespace WindsoulDataFile
{
    public class WindsoulFileEntry
    {
        public uint Id { get; internal set; }

        public uint Offset { get; internal set; }

        public int Size { get; internal set; }

        public uint Reserved { get; internal set; }

        public byte[] Content { get; set; }

        public WindsoulFileEntry(uint id, uint offset, int size, uint reserved)
            : this(id, offset, size, reserved, null)
        {
        }

        public WindsoulFileEntry(uint id, uint offset, int size, uint reserved, byte[] content)
        {
            this.Id = id;
            this.Offset = offset;
            this.Size = size;
            this.Reserved = reserved;
            this.Content = content;
        }
    }
}
