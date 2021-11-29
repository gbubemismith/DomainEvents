using System;

namespace domainEvents.Services
{
    public class DelegateService
    {
        public delegate void DrinkingAction();

        public static void RelaxingOnTheBeach(DrinkingAction drink)
        {
            Console.WriteLine("Relaxing on the beach");
            drink();
        }
    }
}