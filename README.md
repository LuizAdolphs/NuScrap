# NuScrap

Simple unofficial lib to retrieve data from Nubank made in .NET standart 2.0

Using example:

```csharp
using System;
using NuScrap;

namespace NuScrapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = NuScrap.Context.Create("11digitvalidCPF","password");

            var account = context.Account;

            Console.WriteLine($"Available balance: {account.AvailableBalance}”);
        }
    }
}

```