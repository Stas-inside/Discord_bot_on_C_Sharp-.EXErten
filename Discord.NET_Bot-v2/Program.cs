﻿using System;
using System.Threading.Tasks;
using System.Threading;

using Discord;
using Discord.WebSocket;

// Class

namespace Discord.NET_Bot_v2
{
  class Program
  {
    // Example calss
    DiscordSocketClient client;

    static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

    // Main
    public async Task MainAsync()
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("\n       +++++++++++++++++++++++++++++++++++");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("       +         Created by Stas         +");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("       +++++++++++++++++++++++++++++++++++\n\n");
      Console.ResetColor();

      client = new DiscordSocketClient();
      client.MessageReceived += CommandsHandler;
      client.Log += Log;

      var token = "***";

      await client.LoginAsync(TokenType.Bot, token);
      await client.StartAsync();

      await client.SetGameAsync("#help");

      Console.ReadLine();

    }

    public Task Log(LogMessage msg)
    {
      Console.WriteLine(msg.ToString());
      return Task.CompletedTask;
    }

    Int64 Points = 0;
    Random rand = new Random();

    public Task CommandsHandler(SocketMessage msg)
    {

      if (!msg.Author.IsBot)
      {
        switch (msg.Content)
        {
          case "#help":
            {
              msg.Channel.SendMessageAsync($"=========================\n| !qq\n| !rand\n| !p\n| (Бесполезное XD) ping\n=========================");
              break;
            }
          case "#giveRole":
            {
              //var user = msg.User;
              //var role = msg.Guild.Roles.FirstOrDefault(x => x.Name == "RoleName");
              //await(user as IGuildUser).AddRoleAsync(role);
              break;
            }
          case "!qq":
            {
              int state = rand.Next(0, 2);       // 10

              switch (state)
              {
                case 0:
                  {
                    msg.Channel.SendMessageAsync($"Привет, { msg.Author}");
                    //msg.AddReactionAsync(new Emoji("✅"));
                    break;
                  }
                case 1:
                  {
                    msg.Channel.SendMessageAsync($"Хайё, { msg.Author}");
                    break;
                  }
              }
              break;
            }
          case "!rand":
            {
              for (int i = 0; i < 10; i++)
              {
                msg.Channel.SendMessageAsync($"Выпало число {rand.Next(0, 5)}");     // From 0 to 3 (0 1 2)
                Thread.Sleep(100);
              }
              break;
            }
          case "ping":
            {
              msg.Channel.SendMessageAsync("pong");
              break;
            }
          case "!p":
            {
              Points++;
              msg.Channel.SendMessageAsync($"Твои очки {System.Convert.ToString(Points)}");
              break;
            }
        }
      }


      return Task.CompletedTask;
    }
  }
}
