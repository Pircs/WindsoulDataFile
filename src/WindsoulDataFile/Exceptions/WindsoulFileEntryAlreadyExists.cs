namespace WindsoulDataFile.Exceptions
{
    public class WindsoulFileEntryAlreadyExists : WindsoulFileException
    {
        public WindsoulFileEntryAlreadyExists(string fileName) 
            : base($"A file entry with the name '{fileName}' already exists.")
        {
        }
    }
}
