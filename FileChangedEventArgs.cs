namespace DirectoryNotifier
{
	public class FileChangedEventArgs : EventArgs
    {
        public string Message { get; }

        public FileChangedEventArgs(string message)
        {
            Message = message;
        }
    }
}

