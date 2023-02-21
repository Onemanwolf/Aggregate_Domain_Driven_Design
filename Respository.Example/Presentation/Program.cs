using System.Net.Mime;
using Application;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using Presentation.Service;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Application started");

await Host.CreateDefaultBuilder(args)
.ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<ConsoleHostedService>()
                .AddSingleton<IAuctionService, AuctionService>();

            })
            .RunConsoleAsync();