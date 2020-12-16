using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Take.Chat.Model
{
    public class Message
    {
        /// <summary>
        /// The name of who is sending the message
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// The name to who is the message
        /// </summary>
        public string ToName { get; set; }

        /// <summary>
        /// The message text
        /// </summary>
        public string Text { get; set; }
    }
}
