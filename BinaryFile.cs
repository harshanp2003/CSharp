//program to write 10MB of data to multiple files 

using System;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;



namespace BinaryData
{
    class BinaryFile
    {
        // Constants
        public const int FileSize = 10 * 1024 * 1024; // 10MB
        public const int BlockSize = 50 * 1024; // 50KB
        public const int NumFiles = 100;

        static async Task Main(string[] args)
        {
            // Measures time for single-threaded execution
            var stopwatch = Stopwatch.StartNew();
            await WriteFilesSingleThreaded();
            stopwatch.Stop();
            Console.WriteLine($"Single-threaded execution time: {stopwatch.ElapsedMilliseconds} ms\n");

            // Measure time for multi-threaded execution
            stopwatch.Restart();
            await WriteFilesMultiThreaded();
            stopwatch.Stop();
            Console.WriteLine($"Multi-threaded execution time: {stopwatch.ElapsedMilliseconds} ms\n");
        }

        // Single-threaded
        static async Task WriteFilesSingleThreaded()
        {
            for (int i = 0; i < NumFiles; i++)
            {
                string filename = $"File_{i + 1}.bin";
                await WriteFileAsync(filename);
                Console.WriteLine($"{filename} Writing Completed");
            }
        }

        // Multi-threaded
        static async Task WriteFilesMultiThreaded()
        {
            Task[] tasks = new Task[NumFiles];

            for (int i = 0; i < NumFiles; i++)
            {
                string filename = $"File_{i + 1}.bin";
                tasks[i] = WriteFileAsync(filename);
            }

            await Task.WhenAll(tasks); // Wait for all tasks to complete

            for (int i = 0; i < NumFiles; i++)
            {
                string filename = $"File_{i + 1}.bin";
                Console.WriteLine($"{filename} Writing Completed");
            }
        }

        // Write 10MB of binary data (0s and 1s) to a file in blocks of 50KB
        static async Task WriteFileAsync(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                byte[] dataBlock = new byte[BlockSize]; // 50KB block
                for (int i = 0; i < FileSize / BlockSize; i++)
                {
                    // Fill the block with alternating 0s and 1s (binary data)
                    for (int j = 0; j < BlockSize; j++)
                    {
                        // Write 0 and 1 in binary format, alternatively (0x00 for 0 and 0x01 for 1)
                        dataBlock[j] = (byte)((j % 2 == 0) ? 0x00 : 0x01);
                    }

                    // Write the block asynchronously
                    await fs.WriteAsync(dataBlock, 0, dataBlock.Length);

                }
                fs.Close();
            }
        }
    }

}
