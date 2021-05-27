using System;

namespace anomaly_detector_quickstart
{
    class Program
    {
        static void Main(string[] args)
        {
            //This sample assumes you have created an environment variable for your key and endpoint
            string endpoint = Environment.GetEnvironmentVariable("ANOMALY_DETECTOR_ENDPOINT");
            string key = Environment.GetEnvironmentVariable("ANOMALY_DETECTOR_KEY");
            string datapath = "request-data.csv";

            IAnomalyDetectorClient client = createClient(endpoint, key); //Anomaly Detector client

            Request request = GetSeriesFromFile(datapath); // The request payload with points from the data file

            EntireDetectSampleAsync(client, request).Wait(); // Async method for batch anomaly detection
            LastDetectSampleAsync(client, request).Wait(); // Async method for analyzing the latest data point in the set
            DetectChangePoint(client, request).Wait(); // Async method for change point detection

            Console.WriteLine("\nPress ENTER to exit.");
            Console.ReadLine();
        }
    }
}
