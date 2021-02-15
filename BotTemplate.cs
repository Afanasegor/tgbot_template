using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ConsoleBot
{
    class Program
    {
    	string token = " // -- // -- // -- // "

        private static readonly TelegramBotClient bot = new TelegramBotClient(token);
        
        static void Main(string[] args)
        {
            bot.OnMessage += Bot_OnMessage;
            bot.SetWebhookAsync("");

            var me = bot.GetMeAsync().Result;
            Console.Title = me.Username;

            bot.StartReceiving();
            Console.ReadLine();
            bot.StopReceiving();
        }

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Message msg = e.Message;

            if (msg == null)
            {
                return;
            }

            if (msg.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {               
                await bot.SendTextMessageAsync(msg.Chat.Id, msg.From.FirstName + " ");
            }
        }
    }
}
