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
            var isWorking = false;

            ApiController.callApi("OdczytanyKodKarty", isWorking);

            string GetCardId(Data106kbpsTypeA card) => Convert.ToHexString(card.NfcId);

            GpioController gpioController = new GpioController();
            int pinReset = 21;

            int LED_PIN_first = 18;
            int LED_PIN_startWork = 19;
            int LED_PIN_endWork = 20;

            gpioController.OpenPin(LED_PIN_first, PinMode.Output);
            gpioController.OpenPin(LED_PIN_startWork, PinMode.Output);
            gpioController.OpenPin(LED_PIN_endWork, PinMode.Output);

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
                                var cardId = GetCardId(card);
                                Console.WriteLine(cardId);

                                //migniecie led przy odczycie karty
                                gpioController.Write(LED_PIN_first, true);
                                Thread.Sleep(1000);
                                gpioController.Write(LED_PIN_first, false);

                                if(!isWorking){
                                    isWorking = !isWorking;
                                    //zaczecie pracy dioda
                                    gpioController.Write(LED_PIN_startWork, true);
                                    Thread.Sleep(1000);
                                    gpioController.Write(LED_PIN_startWork, false);
                                    //ApiController.callApi(cardId, isWorking);

                                }else{
                                    isWorking = !isWorking;
                                    //zakonczenie pracy
                                    gpioController.Write(LED_PIN_endWork, true);
                                    Thread.Sleep(1000);
                                    gpioController.Write(LED_PIN_endWork, false);
                                    //ApiController.callApi(cardId, isWorking);
                                }
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


