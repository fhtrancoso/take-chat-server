namespace Take.Chat.Repository.Model
{
    public class Message
    {
        public int Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Text { get; set; }
    }
}
