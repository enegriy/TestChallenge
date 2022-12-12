using System;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var device = new Device("1.0.5", new System.Collections.Generic.List<Device>());
            var device1 = new Device("1.0.5", new System.Collections.Generic.List<Device>());
            var device2 = new Device("1.0.4", new System.Collections.Generic.List<Device>() { device, device1 });
            var device3 = new Device("1.0.3", new System.Collections.Generic.List<Device>() { device2 });

            var solver = new Solver();
            solver.FindDistinctVersions(device3);

            OftenItemArray oftenItemArray = new OftenItemArray();
            var result = oftenItemArray.FindSorted(new int[] { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 }, new int[] { 2, 2, 10, 10, 10, 10, 10, 10 });
            Console.WriteLine(result);

            RomeDigit arabicDigit = new RomeDigit();
            Console.WriteLine(arabicDigit.ConvertToInt("XII"));
            Console.WriteLine(arabicDigit.ConvertToInt("IV"));
            Console.WriteLine(arabicDigit.ConvertToInt("IX"));
            Console.WriteLine(arabicDigit.ConvertToInt("XXVIII"));
        }

        private static async void ShowTextAsync()
        {
            /* CODE */
            await System.Threading.Tasks.Task.Delay(1000);
            Console.WriteLine("Hello");
        }
    }

    interface IHandler<TRequest, TResponse>
    {
        TResponse Handle(TRequest request);
    }

    abstract class HandlerBehevior<TRequest, TResponse>
    {
        private readonly IHandler<TRequest, TResponse> _handler;

        public HandlerBehevior(IHandler<TRequest, TResponse> handler)
        {
            _handler = handler;
        }

        public TResponse Next(TRequest request)
        {
            if (request != null)
                return _handler.Handle(request);
            return default(TResponse);
        }
    }

    class LoggindBehevior<TRequest, TResponse> : HandlerBehevior<TRequest, TResponse>, IHandler<TRequest, TResponse>
    {
        public LoggindBehevior(IHandler<TRequest, TResponse> handler) : base(handler)
        {
        }

        public TResponse Handle(TRequest request)
        {
            Console.WriteLine("HandleLoggind.Handle");
            Console.WriteLine("Start logging");
            var response = Next(request);
            Console.WriteLine("Stop logging");
            return response;
        }
    }

    class ExceptionBehevior<TRequest, TResponse> : HandlerBehevior<TRequest, TResponse>, IHandler<TRequest, TResponse>
    {
        public ExceptionBehevior(IHandler<TRequest, TResponse> handler) : base(handler)
        {
        }

        public TResponse Handle(TRequest request)
        {
            try
            {
                Console.WriteLine("HandleException.Handle");
                return Next(request);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }

            return default(TResponse);
        }
    }

    class WriteTextBehevior<TRequest, TResponse> : HandlerBehevior<TRequest, TResponse>, IHandler<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        public WriteTextBehevior(IHandler<TRequest, TResponse> handler) : base(handler)
        {
        }

        public TResponse Handle(TRequest request)
        {
            Console.WriteLine("HandleWriteText.Handle");
            return request.ToString() + " + was into handler" as TResponse;
        }
    }

}
