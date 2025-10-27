# Blokada.cs
Mobile-API for [blokada](https://play.google.com/store/apps/details?id=org.blokada.sex) an popular ad blocker and privacy app for Android and iOS

## Example
```cs
using System;
using BlokadaApi;

namespace Application
{
    internal class Program
    {
        static async Task Main()
        {
            var api = new Blokada();
            string account = await api.GetAccount();
            Console.WriteLine(account);
        }
    }
}
```
