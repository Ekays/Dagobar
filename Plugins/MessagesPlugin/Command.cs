using System;

namespace MessagesPlugin
{
    public struct Command
    {
        public string Name      { get; set; }
        public string Text      { get; set; }
        public int Interval     { get; set; }
    }
}
