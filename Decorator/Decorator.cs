using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Decorator
    {
        public interface IDataSource
        {
            void WriteData(string data);
            string ReadData();
        }

        public class FileDataSource : IDataSource
        {
            private readonly string _fileName;

            public FileDataSource(string fileName)
            {
                _fileName = fileName;
            }

            public void WriteData(string data)
            {
                File.WriteAllText(_fileName, data);
            }

            public string ReadData()
            {
                return File.ReadAllText(_fileName);
            }
        }

        public abstract class DataSourceDecorator : IDataSource
        {
            protected IDataSource wrappee;

            protected DataSourceDecorator(IDataSource dataSource)
            {
                wrappee = dataSource;
            }

            public virtual void WriteData(string data)
            {
                wrappee.WriteData(data);
            }

            public virtual string ReadData()
            {
                return wrappee.ReadData();
            }
        }

        public class LoggingDecorator : DataSourceDecorator
        {
            public LoggingDecorator(IDataSource dataSource) : base(dataSource) { }

            public override void WriteData(string data)
            {
                Console.WriteLine("LoggingDecorator: Writing data");
                base.WriteData(data);
                Console.WriteLine("LoggingDecorator: Data written");
            }

            public override string ReadData()
            {
                Console.WriteLine("LoggingDecorator: Reading data");
                string result = base.ReadData();
                Console.WriteLine("LoggingDecorator: Data read");
                return result;
            }
        }

        public class EncryptionDecorator : DataSourceDecorator
        {
            public EncryptionDecorator(IDataSource dataSource) : base(dataSource) { }

            public override void WriteData(string data)
            {
                string encodedData = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
                base.WriteData(encodedData);
            }

            public override string ReadData()
            {
                string data = base.ReadData();
                return Encoding.UTF8.GetString(Convert.FromBase64String(data));
            }
        }

        public class CompressionDecorator : DataSourceDecorator
        {
            public CompressionDecorator(IDataSource dataSource) : base(dataSource) { }

            public override void WriteData(string data)
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                using var compressedStream = new MemoryStream();
                using (var gZipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                {
                    gZipStream.Write(dataBytes, 0, dataBytes.Length);
                }

                byte[] compressedData = compressedStream.ToArray();
                base.WriteData(Convert.ToBase64String(compressedData));
            }

            public override string ReadData()
            {
                string compressedData = base.ReadData();
                byte[] dataBytes = Convert.FromBase64String(compressedData);

                using var decompressedStream = new MemoryStream();
                using var compressedStream = new MemoryStream(dataBytes);
                using (var gZipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    gZipStream.CopyTo(decompressedStream);
                }

                byte[] decompressedData = decompressedStream.ToArray();
                return Encoding.UTF8.GetString(decompressedData);
            }
        }
        public class Program
        {
            public static void Main()
            {
                Run();
            }

            static void Run()
            {
                IDataSource dataSource = new FileDataSource("salary.dat");
                dataSource = new CompressionDecorator(dataSource);
                dataSource = new EncryptionDecorator(dataSource);
                dataSource = new LoggingDecorator(dataSource);

                // This will be compressed, encrypted and logged.
                dataSource.WriteData("123456");

                // To read it back, it will be decrypted, decompressed and logged.
                Console.WriteLine(dataSource.ReadData());

                // Now let's see the raw data from the file.
                var rawDataSource = new FileDataSource("salary.dat");
                Console.WriteLine("Raw data from file:");
                Console.WriteLine(rawDataSource.ReadData());
            }
        }


    }
}
