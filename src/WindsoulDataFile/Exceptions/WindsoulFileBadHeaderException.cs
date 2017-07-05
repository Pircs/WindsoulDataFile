namespace WindsoulDataFile.Exceptions
{
    public class WindsoulFileBadHeaderException : WindsoulFileException
    {
        public WindsoulFileBadHeaderException()
            : base()
        {
        }

        public WindsoulFileBadHeaderException(uint header)
            : base($"Bad Windsoul Data File header : 0x{header.ToString("X8")}")
        {
        }
    }
}
