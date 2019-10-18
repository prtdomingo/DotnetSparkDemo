using System;
using Microsoft.Spark.Sql;

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

            spark.Stop();

            // Count words
        }
    }
}
