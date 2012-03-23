using System;
using System.Collections.Generic;
using System.Linq;

namespace scratch.Misc.Delegates
{
    public static class MessagePicker
    {
        private static readonly IList<MessageConfig> Configs = new List<MessageConfig>
                                                    {
                                                        new MessageConfig(Gender.Male, p => p.Name),
                                                        new MessageConfig(Gender.Female, p => p.Age.ToString())
                                                    };

        public static MessageConfig GetMessageConfig(Person person)
        {
            var config = Configs.Single(c => c.Gender == person.Gender);
            return config.Compile(person);
        }
    }

    public class MessageConfig
    {
        private readonly Func<Person, string> _messageFunc;

        public Gender Gender { get; private set; }
        public string Message { get; private set; }

        public MessageConfig(Gender gender, Func<Person, string> messageFunc)
        {
            _messageFunc = messageFunc;
            Gender = gender;
        }

        internal MessageConfig Compile(Person person)
        {
            Message = _messageFunc(person);
            return this;
        }
    }
}