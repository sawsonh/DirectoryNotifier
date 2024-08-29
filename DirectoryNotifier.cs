namespace DirectoryNotifier
{
	public class DirectoryNotifier : IDisposable
    {
        private FileSystemWatcher _watcher;

		// consumers subscribe to this
        public event EventHandler<FileChangedEventArgs> FileChanged;

        public DirectoryNotifier(string pathToMonitor)
		{
            _watcher = new FileSystemWatcher(pathToMonitor)
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size
            };

            // Subscribe to the events
            _watcher.Created += OnFileCreated;
            _watcher.Deleted += OnFileDeleted;

            _watcher.EnableRaisingEvents = true;
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            NotifySubscribers($"{e.Name} was created.");
        }

        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            NotifySubscribers($"{e.Name} was deleted.");
        }

        private void NotifySubscribers(string message)
        {
            // Raise the event to notify subscribers
            FileChanged?.Invoke(this, new FileChangedEventArgs(message));
        }

        public void Dispose()
        {
            if (_watcher != null)
            {
                _watcher.Created -= OnFileCreated;
                _watcher.Deleted -= OnFileDeleted;
                _watcher.Dispose();
                _watcher = null;
                Console.WriteLine("DirectoryNotifier disposed.");
            }
        }
    }
}

