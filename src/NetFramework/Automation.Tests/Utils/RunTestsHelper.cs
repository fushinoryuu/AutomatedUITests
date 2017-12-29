using System.Diagnostics;

namespace Automation.Tests.Utils
{
    public class RunTestsHelper
    {
        public static int RunNunitTests(string arguments, ProcessWindowStyle showWindow)
        {
            // If you move or rename the root directory 'SeleniumAutomationToolbox', please update these paths
            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = @"C:\SeleniumAutomationToolbox",
                WindowStyle = showWindow,
                FileName = @"C:\SeleniumAutomationToolbox\src\NetFramework\packages\NUnit.ConsoleRunner.3.7.0\tools\nunit3-console.exe",
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