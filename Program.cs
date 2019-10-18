using System;
using Microsoft.Spark.Sql;
using SentimentAnalysisML.Model;

namespace SentinmentAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            //var spark = SparkSession
            //    .Builder()
            //    .AppName("Sentiment Analysis with Spark")
            //    .GetOrCreate();

            //// Create initial DataFrame
            //DataFrame df = spark
            //    .Read()
            //    .Option("header", true)
            //    .Option("inferSchema", true)
            //    .Csv("tweets_clean_data.csv");

            //df.Show();

            //df.CreateOrReplaceTempView("TweetsTextView");

            //spark.Stop();

            // Count words

            Console.WriteLine(Sentiment("== OK! ==  IM GOING TO VANDALIZE WILD ONES WIKI THEN!!!"));

            Console.ReadLine();
        }

        public static bool Sentiment(string text)
        {
            ModelInput modelInput = new ModelInput
            {
                SentimentText = text
            };

            ModelOutput result = ConsumeModel.Predict(modelInput);
            return result.Prediction;
        }
    }
}
