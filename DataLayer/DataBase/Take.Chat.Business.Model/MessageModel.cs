namespace Take.Chat.Business.Model
{
    /// <summary>
    /// In this class we can have more properties to do any business logic, but it is not the case.
    /// </summary>
    public class MessageModel
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
