using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileStreamPerformanceWithNET6
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<FileStreamPerf>();

            ungeConsole.ReadKey();
        }
    }

    public class FileStreamPerf
    {
        private const int FileSize = 1_000_000; // 1 MB
        private Memory<byte> _buffer = new byte[8_000]; // 8 kB

        [GlobalSetup(Target = nameof(ReadAsync))]
        public void SetupRead() => File.WriteAllBytes("file.txt", new byte[FileSize]);

        [Benchmark]
        public async ValueTask ReadAsync()
        {
            using FileStream fileStream = new FileStream("file.txt", FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            while (await fileStream.ReadAsync(_buffer) > 0)
            {
            }
        }

        [Benchmark]
        public async ValueTask WriteAsync()
        {
            using FileStream fileStream = new FileStream("file.txt", FileMode.Create, FileAccess.Write, FileShare.Read, bufferSize: 4096, useAsync: true);
            for (int i = 0; i < FileSize / _buffer.Length; i++)
            {
                await fileStream.WriteAsync(_buffer);
            }
        }

        [GlobalCleanup]
        public void Cleanup() => File.Delete("file.txt");
    }
}
