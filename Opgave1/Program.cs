// Variable to increment or decrement
int count = 0;

// Monitor object
object obj = new();

// Increment thread
Thread t1 = new(delegate ()
{
    while (true)
    {
        // Monitor enter
        Monitor.Enter(obj);

        // Increment count
        count += 2;

        // Print count to console
        Console.WriteLine("Thread 1: count = {0}", count);

        // Monitor exit
        Monitor.Exit(obj);

        // Sleep for a second
        Thread.Sleep(1000);
    }
});

// Decrement thread
Thread t2 = new(delegate ()
{
    while (true)
    {
        // Monitor enter
        Monitor.Enter(obj);

        // Decrement count
        count--;

        // Print count to console
        Console.WriteLine("Thread 2: count = {0}", count);

        // Monitor exit
        Monitor.Exit(obj);

        // Sleep for a second
        Thread.Sleep(1000);
    }
});

// Start both threads
t1.Start();
t2.Start();

// Join threads
t1.Join();
t2.Join();