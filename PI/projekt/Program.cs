using System;
using System.Threading;
using System.Threading.Tasks;
using System.Device.Gpio;
using System.Device.Spi;
using Iot.Device.Mfrc522;
using Iot.Device.Rfid;


namespace projekt
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string GetCardId(Data106kbpsTypeA card) => Convert.ToHexString(card.NfcId);


            GpioController gpioController = new GpioController();
            int pinReset = 21;

            const int LED_PIN_RED = 18;
            //const int LED_PIN_YELLOW = 37;
            //const int LED_PIN_GREEN = 37;

            gpioController.OpenPin(LED_PIN_RED, PinMode.Output);
            //gpioController.OpenPin(LED_PIN_YELLOW, PinMode.Output);
            //gpioController.OpenPin(LED_PIN_GREEN, PinMode.Output);
            

            SpiConnectionSettings connection = new(0, 0);
            connection.ClockFrequency = 10_000_000;

            var source = new CancellationTokenSource();
            var token = source.Token;

            var task = Task.Run(() => ReadData(token), token);

            Console.WriteLine("Any key to close.");
            Console.ReadKey();

            source.Cancel();

            await task;

            void ReadData(CancellationToken cancellationToken)
            {
                Console.WriteLine("Task run.");
                var active = true;

                do
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        active = false;
                    }

                    try
                    {
                        using (SpiDevice spi = SpiDevice.Create(connection))
                        using (MfRc522 mfrc522 = new(spi, pinReset, gpioController, false))
                        {

                            Data106kbpsTypeA card;
                            var res = mfrc522.ListenToCardIso14443TypeA(out card, TimeSpan.FromSeconds(2));

                            if (res)
                            {

                                gpioController.Write(LED_PIN_RED, PinValue.High);
                                //gpioController.Write(LED_PIN_YELLOW, PinValue.High);
                               // gpioController.Write(LED_PIN_GREEN, PinValue.High);

                                var cardId = GetCardId(card);
                                Console.WriteLine(cardId);

                                 //Send API Request. Method return true if work started and false if work ended
                                var isWorking = ApiController.callApi(cardId);

                                //migniecie led przy odczycie karty
                                //gpioController.Write(LED_PIN_first, true);
                                //Thread.Sleep(1000);
                                //gpioController.Write(LED_PIN_first, false);

                                /*
                                if(!isWorking){
                                    isWorking = !isWorking;
                                    //zaczecie pracy dioda
                                    gpioController.Write(LED_PIN_startWork, true);
                                    Thread.Sleep(1000);
                                    gpioController.Write(LED_PIN_startWork, false);

                                }else{
                                    isWorking = !isWorking;
                                    //zakonczenie pracy
                                    gpioController.Write(LED_PIN_endWork, true);
                                    Thread.Sleep(1000);
                                    gpioController.Write(LED_PIN_endWork, false);
                                }
                                */
                            }
                        }

                        Thread.Sleep(1000);
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                } while (active);

                Console.WriteLine("Task done.");
            }
        }
    }
}