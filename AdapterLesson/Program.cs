using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            MercedesSedan g = new MercedesSedan();
            VolvoTrack track = new VolvoTrack();

            Console.WriteLine("Mercedes");
            g.Run();
            g.Drive();

            Console.WriteLine("Volvo");
            track.Run();
            track.Ship();
            track.Drive();

        

            Console.WriteLine("Sedan Adapter (Convert Sedan to Track)");
            ITrack trAdapter = new SedanAdapter(g);
            trAdapter.Run();
            trAdapter.Drive();
            trAdapter.Ship();


            Console.WriteLine("Track Adapter (Track to Sedan)");

            ISedan sdAdapter = new TrackAdapter(track);
            sdAdapter.Run();
            sdAdapter.Drive();

          

            Console.ReadKey();
        }
    }

    interface ITrack
    {
        void Run();
        void Ship();
        void Drive();
    }

    interface ISedan
    {
        void Run();
        void Drive();
    }
    class MercedesSedan : ISedan
    {
        public void Drive()
        {
            Console.WriteLine(" driving mercedese sedan  "); 
        }

        public void Run()
        {
            Console.WriteLine("Runing  mercedes sedan. . . . ");
        }
    }

    class VolvoTrack : ITrack
    {
        public void Drive()
        {
            Console.WriteLine("Volvo Track Driving");
        }

        public void Run()
        {
            Console.WriteLine("Volvo Track Run run");

        }

        public void Ship()
        {
            Console.WriteLine("Volvo Track Load load");
        }
    }


    class SedanAdapter : ITrack
    {
        ISedan g;

        public SedanAdapter(ISedan g)
        {
            this.g = g;
        }
        public void Drive()
        {
            g.Drive();
        }

        public void Run()
        {
            g.Run();
        }

        public void Ship()
        {
            Console.WriteLine("Shipment not implemented in mercedes sedan"); 
        }
    }

    class TrackAdapter : ISedan
    {
        ITrack track;

        public TrackAdapter(ITrack track)
        {
            this.track = track;
        }
        public void Drive()
        {
            track.Drive(); 
        }

        public void Run()
        {
            track.Run();

        }
    
    }



}
