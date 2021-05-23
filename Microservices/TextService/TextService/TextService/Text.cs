using System;

namespace TextService.TextService
{
    public class Text
    {
        public Text(string content, string textName, Guid id)
        {
            Content = content;
            TextName = textName;
            Id = id;
        }

        public Guid Id { get; }

        public string TextName { get; }

        public string Content { get; }
    }
}