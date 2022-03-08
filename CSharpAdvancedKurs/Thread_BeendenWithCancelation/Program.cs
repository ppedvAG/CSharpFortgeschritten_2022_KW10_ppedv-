using System;
using System.Threading;

namespace Thread_BeendenWithCancelation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                CancellationToken cancellationToken = cancellationTokenSource.Token;

                ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwas);
                Thread thread = new Thread(parameterizedThreadStart);
                thread.Start(cancellationToken);


                Thread.Sleep(3000);
                cancellationTokenSource.Cancel();
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Fehlermeldung: " + ex.ToString());
            }

            Console.ReadLine();
        }

        private static void MachEtwas(object param)
        {
            if (param is CancellationToken cancellationToken)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested(); //Alternative zu Break
                    }

                    Console.WriteLine("zzzzZZZZZzzzzZZZZzzzzzZZZZ");
                    Thread.Sleep(200); //0,2 Sek pro Loop Interval warten 
                }
            }

           
        }
    }
}
