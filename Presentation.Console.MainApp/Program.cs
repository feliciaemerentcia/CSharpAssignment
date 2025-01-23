using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IFileService>(new FileService("contacts.json"));
serviceCollection.AddSingleton<IContactService, ContactService>();
serviceCollection.AddSingleton<MenuDialogs>();

var serviceProvider = serviceCollection.BuildServiceProvider();

MenuDialogs menuDialogs = serviceProvider.GetRequiredService<MenuDialogs>();
menuDialogs.Run();
