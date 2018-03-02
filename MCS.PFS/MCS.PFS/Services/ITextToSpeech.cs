using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.PFS.Services
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
