using MCS.PFS.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MCS.PFS.ViewModels
{
	public class UsingDependencyServicePageViewModel : BindableBase
	{
        public UsingDependencyServicePageViewModel(ITextToSpeech textToSpeech)
        {
            _textToSpeach = textToSpeech;
            SpeakCommand = new DelegateCommand(Speak);
        }

        //public UsingDependencyServicePageViewModel()
        //{

        //}

        private void Speak()
        {
            _textToSpeach.Speak(TextToSay);
        }

        private readonly ITextToSpeech _textToSpeach;

        private string _textToSay = "Hello from Xamarin Forms and Prism!";

        public string TextToSay
        {
            get { return _textToSay; }
            set { SetProperty(ref _textToSay, value); }
        }

        public DelegateCommand SpeakCommand { get; set; }
	}
}
