using ApiAiSDK;
using ApiAiSDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelecomTotalBot.Models;

namespace TelecomTotalBot.DialogFlow
{
    public class DialogFlow
    {
        public static string accessToken = "836cf41d982540da93365f62a482933b";
        public static string getDialogflow(Request request)
        {

            var config = new AIConfiguration(accessToken, SupportedLanguage.English);
            var dataService = new AIDataService(config);
            var aiRequest = new AIRequest(request.Message);
            var aiResponse = dataService.Request(aiRequest);

            var dialogflowresult = aiResponse.Result.Fulfillment.Speech;
            return dialogflowresult;
        }
    }
}