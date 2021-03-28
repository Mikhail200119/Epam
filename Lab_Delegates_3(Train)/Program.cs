using System;

/*2. Создать приложение, в котором генератор события “снабжает” событие следующей информацией: название поезда,
 * станция назначения, станция отправления и время в пути. Приемник события распечатывает эту информацию.
*/

namespace Lab_Delegates_3_Train_
{
    public delegate void TrainDelegate();

    class Train
    {
        public string Name { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public string ArrivalTime { get; set; }

        public Train(string Name, string Destination, string Departure, string ArrivalTime)
        {
            this.Name = Name;
            this.Destination = Destination;
            this.Departure = Departure;
            this.ArrivalTime = ArrivalTime;
        }

        public void GetTrainName() => Console.Write($"Поезд с названием {Name} ");

        public void GetTrainDestination() => Console.Write($"прибывает на станцию \"{Destination}\" ");

        public void GetTrainDeparture() => Console.Write($"из станции \"{Departure}\" ");

        public void GetTrainArrivalTime() => Console.WriteLine($"в \"{ArrivalTime}\"");
    }

    class EventGenerator
    {
        public event TrainDelegate TrainEventGenerator = null;

        public void Generate(Train train)
        {
            TrainEventGenerator += train.GetTrainName;
            TrainEventGenerator += train.GetTrainDestination;
            TrainEventGenerator += train.GetTrainDeparture;
            TrainEventGenerator += train.GetTrainArrivalTime;
            TrainEventGenerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Train A = new Train("Train_1", "Brest", "Minsk", "15:46");
            EventGenerator Event = new EventGenerator();
            Event.Generate(A);
            Train B = new Train("Train_2", "Baranovichi", "Brest", "18:10");
            EventGenerator Event2 = new EventGenerator();
            Event2.Generate(B);
        }
    }
}
