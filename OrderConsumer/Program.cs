using OrderData.Models;
using System;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace OrderConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsumeOrders();

            Console.ReadLine();
        }
        public static void ConsumeOrders()
        {
            string ordersDirectory = ConfigurationManager.ConnectionStrings["OrdersDir"].ConnectionString;
            if (Directory.GetFiles(ordersDirectory).Length > 0)
            {
                //  uitlezen en de xml’s deserializeren
                ReadAndDeserializeOrders(ordersDirectory);
            }
            else
            {
                // indien Directory leeg is
                Console.WriteLine("Launch OrderGenerator first");
            }

        }
        private static void ReadAndDeserializeOrders(string directory)
        {
            OrderDbContext context = new OrderDbContext();

            string[] filePaths = Directory.GetFiles(directory);
            foreach (var filePath in filePaths)
            {
                var order = GetOrderFromXml<Order>(filePath);
                order.Date = DateTime.Now; //  Tijdstip van insert in de database. 
                order.Xml = OrderToXML(order); // De xml content. 

                context.Orders.Add(order);
                context.SaveChanges();

                Console.WriteLine($"{order.FileName} has just been Inserted into the db");
            }
            Console.WriteLine("files deserialization finished & db updated");
            Console.Read();
        }
        public static Order GetOrderFromXml<Order>(string filePath) where Order : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(Order));
                reader = new StreamReader(filePath);
                return (Order)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        public static string OrderToXML(Order order)
        {
            try
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(order.GetType());
                serializer.Serialize(stringwriter, order);
                return stringwriter.ToString();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;

                return "Could not convert: " + ex.Message;
            }
        }
    }
}
