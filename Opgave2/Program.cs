// Count how many symbols we have printed so far
int count = 0;

// Monitor object
object obj = new();

Thread t1 = new(delegate ()
{
    while (true)
    {
        lock (obj) // Remove for opgave 2, keep in for 3 :-)
        {
            // Do this 60 times
            for (int i = 0; i < 60; i++)
            {
                // Print a symbol
                Console.Write("*");

                // Increment the count
                count++;
            }

            // Write total count
            Console.WriteLine(" {0}", count);

            // Just sleep so the console doesn't get flooded
            Thread.Sleep(200);
        }
    }
});

Thread t2 = new(delegate ()
{
    while (true)
    { 
        lock (obj) // Remove for opgave 2, keep in for 3 :-)
        {
            // Do this 60 times
            for (int i = 0; i < 60; i++)
            {
                // Print a symbol
                Console.Write("#");

                // Increment the count
                count++;
            }

            // Write total count
            Console.WriteLine(" {0}", count);

            // Just sleep so the console doesn't get flooded
            Thread.Sleep(200);
        }
    }
});

// Start the threads
t1.Start();
t2.Start();

// Join threads
t1.Join();
t2.Join();