using System;
using System.Net.Http;
using System.Text;
using NBomber.Contracts.Stats;
using NBomber.CSharp;
using NBomber.Http.CSharp;

namespace EinkaufslistenApp.LoadTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7104/") 
            };

            int userCount = 5;    
            int requestsPerUser = 10;  
            TimeSpan testDuration = TimeSpan.FromSeconds(30);  

            var scenario = Scenario.Create("EinkaufslistenAPI_Lasttest", async context =>
            {
                var request = Http.CreateRequest("GET", "api/EinkaufsItems")
                                  .WithHeader("Accept", "application/json");

                var response = await Http.Send(httpClient, request);

                return response;
            })
            .WithoutWarmUp()
            .WithLoadSimulations(
                Simulation.Inject(rate: requestsPerUser, interval: TimeSpan.FromSeconds(1), during: testDuration)
            );

            NBomberRunner
                .RegisterScenarios(scenario)
                .WithReportFileName($"EinkaufslistenAPI_Test_{DateTime.Now:yyyyMMdd_HHmm}")
                .WithReportFolder("NBomberReports")
                .WithReportFormats(ReportFormat.Html)
                .Run();

            Console.ReadKey();
        }
    }
}
