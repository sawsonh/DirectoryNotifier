namespace DirectoryNotifier
{
    public class Consumer : IDisposable
    {
        private readonly string _uniqueId;
        private readonly DirectoryNotifier _notifier;

        public Consumer(string uniqueId, DirectoryNotifier notifier)
        {
            _uniqueId = uniqueId;
            _notifier = notifier;
            _notifier.FileChanged += OnFileChanged;

            Console.WriteLine($"Consumer {_uniqueId} subscribed to notifications.");
        }

        public void Dispose()
        {
            _notifier.FileChanged -= OnFileChanged;
            Console.WriteLine($"Consumer {_uniqueId} unsubscribed from notifications.");
        }

        private void OnFileChanged(object sender, FileChangedEventArgs e)
        {
            Console.WriteLine($"Consumer {_uniqueId} received notification: {e.Message}");
        }
    }
}

