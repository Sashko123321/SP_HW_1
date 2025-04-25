using System.Diagnostics;
using System.Text;


//1
//Thread countdownThread = new Thread(Method);
//countdownThread.Start();

//Thread.Sleep(4000); 

//Stopwatch stopwatch = new Stopwatch();
//stopwatch.Start();

//Console.WriteLine("Press any key");
//Console.ReadKey();

//stopwatch.Stop();

//Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

//void Method() 
//{
//    Thread.Sleep(1000);
//    Console.WriteLine("3");
//    Thread.Sleep(1000);
//    Console.WriteLine("2");
//    Thread.Sleep(1000);
//    Console.WriteLine("1");
//    Thread.Sleep(1000);
//    Console.WriteLine("Go...");
//}

//2

Console.Write("Enter path: ");
string filePath = Console.ReadLine();
string myPath = filePath;

void Run()
{
    Method2(myPath);
}
Thread fileReaderThread = new Thread(Run);
fileReaderThread.Start();

Console.WriteLine("Main Thread");


void Method2(string path)
{
    Console.WriteLine("Method2 Thread");
    try
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
        {
            while (!reader.EndOfStream)
            {
                char ch = (char)reader.Read();
                Console.Write(ch);
                Thread.Sleep(200);
            }
        }
        Console.WriteLine("\nENd read file");
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("File not found");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}


