using System.Diagnostics;
using System.Speech.Synthesis;

namespace MonitorService.Alert
{
    public class SpeechAlert : IAlert
    {
        private SpeechSynthesizer reader;

        public SpeechAlert()
        {
            reader = new SpeechSynthesizer();
        }

        private int _alerts;
        public int MinErrors { get; set; }

        private int _numErrors;

        public int NumErrors
        {
            get { return _numErrors; }
            set
            {
                _numErrors = value;
                Send();
            }
        }

        public int MaxAlerts { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        public void Send()
        {
            if ((NumErrors % MinErrors == 0) && (_alerts < MaxAlerts))
            {
                _alerts++;
                Debug.WriteLine("Alert : " + _alerts.ToString());
                reader.Speak("Alert");

            }
        }
    }
}