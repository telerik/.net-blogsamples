using Telerik.XamarinForms.ConversationalUI;

namespace ClientXamarin.Portable
{
    public class SimpleChatItemConverter : IChatItemConverter
    {
        public ChatItem ConvertToChatItem(object dataItem, ChatItemConverterContext context)
        {
            return (TextMessage)dataItem;
        }

        public object ConvertToDataItem(object message, ChatItemConverterContext context)
        {
            TextMessage item = new TextMessage();
            item.Text = message.ToString();
            item.Author = context.Chat.Author;
            item.Author.Avatar = string.Empty;
            return item;
        }
    }
}
