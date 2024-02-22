using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Urls.Add("http://*:5274");

app.MapGet("/", () => "Hello World!");

app.MapGet("/prime", () =>
{
    var primeNumbers = new ConcurrentBag<int>();

    var rand = new Random();

    Parallel.ForEach(Enumerable.Range(1, rand.Next(1000, 2000)), num =>
    {
        if (IsPrime(num))
            primeNumbers.Add(num);
    });

    return $"Found {primeNumbers.Count} prime numbers.";
});

app.Run();
return;

bool IsPrime(int number)
{
    if (number <= 1) return false;
    for (var i = 2; i * i <= number; i++)
    {
        if (number % i == 0)
            return false;
    }
    return true;
}
