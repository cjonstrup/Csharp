using System;

namespace ConsoleApplication1.Provider.SmsService.Mobility
{
    public class MobilityProviderMock : ISms
    {
        public void Send(string msg)
        {
            Console.WriteLine("Mock sms");
        }
    }
}
