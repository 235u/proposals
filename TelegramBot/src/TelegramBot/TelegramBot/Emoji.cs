using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramBot
{
    // See: https://unicode.org/emoji/charts/full-emoji-list.html
    public class Emoji
    {
        private Emoji()
        {
        }

        public Emoji(string group, string subgroup, int code, string name)
        {
            Group = group;
            Subgroup = subgroup;
            Code = char.ConvertFromUtf32(code);
            Name = name;
        }

        public string Group { get; set; }

        public string Subgroup { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }

    public class EmojiCollection : KeyedCollection<string, Emoji>
    {
        public static EmojiCollection Create()
        {
            return new EmojiCollection()
            {
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F600, "grinning face"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F603, "grinning face with big eyes"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F604, "grinning face with smiling eyes"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F601, "beaming face with smiling eyes"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F606, "grinning squinting face"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F605, "grinning face with sweat"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F923, "rolling on the floor laughing"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F602, "slightly smiling face"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F642, "face with tears of joy"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F643, "upside-down face"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F609, "winking face"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F60A, "smiling face with smiling eyes"),
                new Emoji("Smileys & Emotion", "face-smiling", 0x1F607, "smiling face with halo"),

                new Emoji("Smileys & Emotion", "face-affection", 0x1F970, "smiling face with hearts"),
                new Emoji("Smileys & Emotion", "face-affection", 0x1F60D, "smiling face with heart-eyes"),
                new Emoji("Smileys & Emotion", "face-affection", 0x1F929, "star-struck"),
                new Emoji("Smileys & Emotion", "face-affection", 0x1F618, "face blowing a kiss"),
                new Emoji("Smileys & Emotion", "face-affection", 0x1F617, "kissing face"),
                new Emoji("Smileys & Emotion", "face-affection", 0x1F61A, "kissing face with closed eyes"),
                new Emoji("Smileys & Emotion", "face-affection", 0x1F619, "kissing face with smiling eyes"),

                new Emoji("Smileys & Emotion", "face-tongue", 0x1F60B, "face savoring food"),
                new Emoji("Smileys & Emotion", "face-tongue", 0x1F61B, "face with tongue"),
                new Emoji("Smileys & Emotion", "face-tongue", 0x1F61C, "winking face with tongue"),
                new Emoji("Smileys & Emotion", "face-tongue", 0x1F92A, "zany face"),
                new Emoji("Smileys & Emotion", "face-tongue", 0x1F61D, "squinting face with tongue"),
                new Emoji("Smileys & Emotion", "face-tongue", 0x1F911, "money-mouth face")
            };
        }

        protected override string GetKeyForItem(Emoji item)
        {
            return item.Code;
        }
    }
}
