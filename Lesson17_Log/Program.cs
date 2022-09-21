using Serilog;

namespace Lesson17_Log;

#nullable disable



// Serilog
// NLog
// log4net



class Program
{
    static void Main()
    {
        string format = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message} {Exception} {ThreadId} {MachineName} {NewLine}";


        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(outputTemplate: format)
            .WriteTo.File("myLog.txt", outputTemplate: format)
            .Enrich.WithThreadId()
            .Enrich.WithMachineName()
            .CreateLogger();


        Log.Information("InfoLogMessage");
        Log.Warning("InfoWarningMessage");
        Log.Error("InfoErrorMessage");
        Log.Fatal(new NullReferenceException("ex message"), "InfoFatalMessage");


        Thread thread = new Thread(() =>
        {
            Log.Warning("InfoWarningOtherThreadMessage");
        });

        thread.Start();
    }
}