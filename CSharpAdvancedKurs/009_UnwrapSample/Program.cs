using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _009_UnwrapSample
{
    
    // A program whose only use is to demonstrate Unwrap.
    class Program
    {
        static void Main()
        {
            // An arbitrary threshold value.
            byte threshold = 0x40;

            // data is a Task<byte[]>
            var data = Task<byte[]>.Factory.StartNew(() =>
            {
                return GetData(); //64byte Randowm Array
            });

            // We want to return a task so that we can
            // continue from it later in the program.
            // Without Unwrap: stepTwo is a Task<Task<byte[]>>
            // With Unwrap: stepTwo is a Task<byte[]>
            var stepTwo = data.ContinueWith((antecedent) =>
            {
                //antecedent.Result zufälliges ByteArray
                return Task<byte>.Factory.StartNew(() => Compute(antecedent.Result));
            }).Unwrap();

            // Without Unwrap: antecedent.Result = Task<byte>
            // and the following method will not compile.
            // With Unwrap: antecedent.Result = byte and
            // we can work directly with the result of the Compute method.
            var lastStep = stepTwo.ContinueWith((antecedant) =>
            {
                if (antecedant.Result >= threshold)
                {
                    return Task.Factory.StartNew(() => Console.WriteLine("Program complete. Final = 0x{0:x} threshold = 0x{1:x}", stepTwo.Result, threshold));
                }
                else
                {
                    return DoSomeOtherAsyncronousWork(stepTwo.Result, threshold);
                }
            });

            lastStep.Wait();
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        #region Dummy_Methods
        private static byte[] GetData()
        {
            Random rand = new Random();
            byte[] bytes = new byte[64];
            rand.NextBytes(bytes);
            return bytes;
        }

        static Task DoSomeOtherAsyncronousWork(int i, byte b2)
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.SpinWait(500000);
                Console.WriteLine("Doing more work. Value was <= threshold");
            });
        }
        static byte Compute(byte[] data)
        {

            byte final = 0;
            foreach (byte item in data)
            {
                final ^= item;
                Console.WriteLine("{0:x}", final);
            }
            Console.WriteLine("Done computing");
            return final;
        }
        #endregion
    }
}
