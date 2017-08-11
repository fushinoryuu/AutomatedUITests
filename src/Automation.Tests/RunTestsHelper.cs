using System.Diagnostics;

namespace Automation.Tests
{
    public class RunTestsHelper
    {
        public static int RunNunitTests(string arguments, ProcessWindowStyle showWindow)
        {
            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = @"C:\AutomatedUiTests",
                WindowStyle = showWindow,
                FileName = @"C:\AutomatedUiTests\packages\NUnit.ConsoleRunner\tools\nunit3-console.exe",
                UseShellExecute = false,
                Arguments = arguments
            };

            var process = new Process
            {
                StartInfo = startInfo
            };

            process.Start();

            return process.Id;
        }

        public static void StopNunitTests(int processId)
        {
            if (processId == 0)
                return;

            var process = Process.GetProcessById(processId);
            process.Kill();
        }
    }
}