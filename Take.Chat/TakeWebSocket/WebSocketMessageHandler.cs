using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Take.Chat.Business.Contract;
using Take.Chat.Converters;

namespace Take.Chat.TakeWebSocket
{
    public class WebSocketMessageHandler : SocketHandler
    {
        IMessageManager _messageManager;

        public WebSocketMessageHandler(ConnectionManager connections, IMessageManager manager) : base(connections)
        {
            _messageManager = manager;
        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);
        }

        public override async Task Receive(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            var messageModel = message.ToModel();

            // Insert all the messages to the database
            _messageManager.InsertMessage(messageModel);

            // Send the message to all clients connected
            await SendMessageToAll(message.ToClientMessage());
        }
    }
}
