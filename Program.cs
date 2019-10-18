using System;
using Microsoft.ML;
using Microsoft.Spark.Sql;
using SentimentAnalysisML.Model;

namespace SentinmentAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var spark = SparkSession
                .Builder()
                .AppName("Sentiment Analysis with Spark")
                .GetOrCreate();

            // Create initial DataFrame
            DataFrame df = spark
                .Read()
                .Option("header", true)
                .Option("inferSchema", true)
                .Csv("tweets_clean_data.csv");

            df.Show();

            df.CreateOrReplaceTempView("TweetsTextView");

            spark.Udf().Register<string, bool>("SentimentAnalysisFunc", (text) => Sentiment(text));

            var sqlDf = spark.Sql("SELECT * FROM TweetsTextView");

            spark.Stop();

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
