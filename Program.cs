namespace DirectoryNotifier
{
    public class Program
    {
        static readonly Dictionary<string, Consumer> consumers = new();

        public static void Main(string[] args)
        {
            using (DirectoryNotifier notifier = new("/Users/sharati/Projects/"))
            {
                PrintHelpMenu();
                try
                {
                    var running = true;
                    while (running)
                    {
                        var input = Console.ReadKey(true).KeyChar;
                        switch (input)
                        {
                            case 'a':
                                AddConsumer(notifier);
                                break;
                            case 'd':
                                RemoveConsumer();
                                break;
                            case 'h':
                                PrintHelpMenu();
                                break;
                            case 'q':
                                QuitProgram();
                                running = false;
                                break;
                            default:
                                Console.WriteLine("Invalid option. Press 'h' for help.");
                                break;
                        }
                    }
                }
                finally
                {
                    if (consumers.Count > 0)
                    {
                        QuitProgram();
                    }
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


        static void AddConsumer(DirectoryNotifier notifier)
        {
            Console.WriteLine("Enter a name for the new consumer:");
            string name = Console.ReadLine();

            if (!consumers.ContainsKey(name))
            {
                var consumer = new Consumer(name, notifier);
                consumers[name] = consumer;
                Console.WriteLine($"Added consumer '{name}'.");
            }
            else
            {
                Console.WriteLine($"A consumer with the name '{name}' already exists.");
            }
        }

        static void RemoveConsumer()
        {
            Console.WriteLine("Enter the name of the consumer to remove:");
            string name = Console.ReadLine();

            if (consumers.ContainsKey(name))
            {
                consumers[name].Dispose();
                consumers.Remove(name);
                Console.WriteLine($"Removed consumer '{name}'.");
            }
            else
            {
                Console.WriteLine($"No consumer found with the name '{name}'.");
            }
        }

        static void PrintHelpMenu()
        {
            Console.WriteLine("Help Menu:");
            Console.WriteLine("'a' - Add a new consumer");
            Console.WriteLine("'d' - Delete the most recent consumer");
            Console.WriteLine("'h' - Print this help menu");
            Console.WriteLine("'q' - Quit the program");
        }

        static void QuitProgram()
        {
            Console.WriteLine("Exiting program...");

            // Dispose of all consumers
            foreach (var consumer in consumers.Values)
            {
                consumer.Dispose();
            }

            consumers.Clear();
            Console.WriteLine("All consumers unsubscribed. Goodbye!");
        }
    }
}