using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CSharpPython
{
    class Program
    {
        const string _pythonScriptThatWilLGenerateAnError = "JustGarbage.py";

        const string _pythonScriptToExecute = "Python101.py";

        private static AutoResetEvent _doneHandlingSTDOUT = new AutoResetEvent(false);

        private static AutoResetEvent _doneHandlingSTERR = new AutoResetEvent(false);

        private static AutoResetEvent[] _allToWaitOn = { _doneHandlingSTDOUT, _doneHandlingSTERR };

        private static int _handleSTDOUTInvokeCount = 0;

        private static int _handleSTDERRInvokeCount = 0;

        private static void WriteProcessNameAndCommandLineArgs(Process process)
        {
            string textToWrite = process?.StartInfo?.FileName ?? "process name not available";

            if (!String.IsNullOrEmpty(process?.StartInfo?.Arguments))
            {
                textToWrite += " " + process.StartInfo.Arguments;
            }

            Console.WriteLine(textToWrite);
        }

        private static void HandleSTDERR(
                    object sendingProcess,
                    DataReceivedEventArgs stderr)
        {
            try
            {
                if (String.IsNullOrEmpty(stderr.Data))
                {
                    if (_handleSTDERRInvokeCount == 0)
                    {
                        WriteProcessNameAndCommandLineArgs((Process)sendingProcess);
                        Console.WriteLine("No error detected from the process");
                    }
                }

                else
                {
                    WriteProcessNameAndCommandLineArgs((Process)sendingProcess);
                    Console.Write("There was an error");
                    Console.WriteLine(stderr.Data);
                    _handleSTDERRInvokeCount++;
                }
            }

            finally
            {
                _doneHandlingSTERR.Set();
            }
        }

        private static void HandleSTDOUT(
                    object sendingProcess,
                    DataReceivedEventArgs stdout)
        {
            try
            {
                if (String.IsNullOrEmpty(stdout.Data))
                {
                    if (_handleSTDOUTInvokeCount == 0)
                    {
                        WriteProcessNameAndCommandLineArgs((Process)sendingProcess);
                        Console.WriteLine("No output detected from the process");
                    }
                }

                else
                {
                    WriteProcessNameAndCommandLineArgs((Process)sendingProcess);
                    Console.WriteLine(stdout.Data);
                    _handleSTDOUTInvokeCount++;
                }
            }

            finally
            {
                _doneHandlingSTDOUT.Set();
            }
        }

        private static void RunPythonScript(string script, string scriptArgs)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                Arguments = script + " " + scriptArgs,
                FileName = "python",
                UseShellExecute = false, // can only redirect STDIO when UseShellExecute=false
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.OutputDataReceived += HandleSTDOUT;
                process.ErrorDataReceived += HandleSTDERR;

                if (!process.Start())
                {
                    Console.WriteLine("Process failed to start.");

                    return;
                }

                process.BeginErrorReadLine();
                process.BeginOutputReadLine();
                process.WaitForExit();
                Console.WriteLine("Process exit code:" + process.ExitCode);
                process.Close();
            }

            WaitHandle.WaitAll(_allToWaitOn);
        }

        private static void InvokePythonScript()
        {
            RunPythonScript(_pythonScriptToExecute, "Arg0 Arg1 Arg2");
            RunPythonScript(_pythonScriptThatWilLGenerateAnError, "Arg0 Arg1 Arg2");
        }

        const string _pythonScriptToExecuteDirectly = "ProofByFile.py";

        private static void RunScriptDirectly()
        {
            string filenameToCreate = DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".txt";
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                Arguments = filenameToCreate,
                FileName = _pythonScriptToExecuteDirectly,
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();
                process.Close();
            }

            string commandLineOfExecutable = 
                Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            string fileCreatedByPython = 
                Path.Combine(commandLineOfExecutable, filenameToCreate);
            bool fileFound = false;

            for (int i = 0; i < 5; i++)
            {
                fileFound = File.Exists(fileCreatedByPython);
                if (fileFound)
                {
                    break;
                }

                Thread.Sleep(100);
            }

            if (fileFound)
            {
                Console.WriteLine("Python created file as expected.");
            }

            else
            {
                Console.WriteLine("Python did not create the file as expected.");
            }
        }

        static void Main(string[] args)
        {
            RunScriptDirectly();
            InvokePythonScript();

            return;
        }
    }
}
