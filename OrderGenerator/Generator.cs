using OrderData.Models;
using System;
using System.Configuration;
using System.IO;
using System.Reactive.Linq;
using System.Threading;
using System.Xml.Serialization;

namespace OrderGenerator
{
    public class Generator
    {

        private string _directory = ConfigurationManager.ConnectionStrings["OrdersDir"].ConnectionString;
        private static int _delayInSeconds = 5;
        private static int _stopGeneratorAfterMiliSeconds = 60000;
        public void Start()
        {
            Console.WriteLine(_directory);
            try
            {
                if (Directory.Exists(_directory))
                {
                    Console.WriteLine("directory exists.");
                    return;
                }
                else
                {
                    // create directory
                    DirectoryInfo di = Directory.CreateDirectory(_directory);
                    Console.WriteLine(" directory created. ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The creation of directory failed: {0}", e.ToString());
            }
            finally
            {
                // elke 5 seconden trigger CreateOrder()
                Console.WriteLine("Generator stops after 1min");
                Console.WriteLine($"Interval set to {_delayInSeconds} seconds : Start");

                var timer = Observable.Interval(TimeSpan.FromSeconds(_delayInSeconds));
                timer.Subscribe(o => CreateOrder());
                Thread.Sleep(_stopGeneratorAfterMiliSeconds);
            }
        }
        private void CreateOrder()
        {
            var order = new Order()
            {
                Id = Guid.NewGuid()
            };

            var fileName = $"Order_{order.Id}.xml";
            order.FileName = fileName;

            string fileLocation = string.Concat(_directory, fileName);

            WriteToXmlFile(fileLocation, order);

            Console.WriteLine($"Order with id: {order.Id} just been created - ( {_delayInSeconds} sec pause )");
        }
        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }




    }
}
