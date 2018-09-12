using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using TelecomTotalBot.Models;

namespace TelecomTotalBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            int length = (activity.Text ?? string.Empty).Length;

            if (length > 0)
            {
                Request request = new Request();
                request.Message = activity.Text.ToString();
                request.SessionId = "";



                var response = DialogFlow.DialogFlow.getDialogflow(request);

                await context.PostAsync(response);
                context.Wait(MessageReceivedAsync);
            }

            else
            {
                await context.PostAsync("Sorry, your information is not found");

                context.Wait(MessageReceivedAsync);
            }
        }
    }
}