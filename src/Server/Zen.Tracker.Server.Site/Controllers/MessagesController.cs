﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;

namespace Zen.Tracker.Server.Site.Controllers
{
    /// <summary>
    /// <c>Messages</c> endpoint deals with reception of messages from client
    /// and passing on to bot framework.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [BotAuthentication]
    [Route("api/messages")]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
            if (activity.Type == ActivityTypes.Message)
            {
                // calculate something for us to return
                int length = (activity.Text ?? string.Empty).Length;

                // return our reply to the user
                var reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");
                await connector.Conversations.ReplyToActivityAsync(reply).ConfigureAwait(true);
            }
            else
            {
                var reply = HandleSystemMessage(activity);
                if (reply != null)
                {
                    await connector.Conversations.ReplyToActivityAsync(reply).ConfigureAwait(true);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}