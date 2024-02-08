using System.Diagnostics;
using System.Reflection;

namespace Tehnopoint
{
    internal class TestStarter
    {
        public void StartTest(int taskNumber)
        {
            var testDataFiles = Directory.GetFiles($@"Task{taskNumber}\TestData", "*.");
            var typeName = $"Tehnopoint.Task{taskNumber}.Solution";
            var type = Assembly.GetExecutingAssembly().GetType(typeName);
            var methodInfo = type.GetMethod("Test");
            var instance = Activator.CreateInstance(type);
            var defaultOut = Console.Out;
            var sw = new Stopwatch();
            long allms = 0;
            for (int i = 0; i < testDataFiles.Length; i++)
            {
                var reader = File.OpenText(testDataFiles[i]);
                var writer = new StringWriter();
                Console.SetIn(reader);
                Console.SetOut(writer);
                sw.Reset();
                sw.Start();
                methodInfo!.Invoke(instance, null);
                sw.Stop();
                Console.SetOut(defaultOut);
                var result = Compare(File.ReadAllText(testDataFiles[i] + ".a"), writer.ToString());
                if (result)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Result: {result} {sw.ElapsedMilliseconds}ms Test: {testDataFiles[i]}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Result: {result} {sw.ElapsedMilliseconds}ms Test: {testDataFiles[i]}");
                }
                Console.ResetColor();
                allms += sw.ElapsedMilliseconds;
            }
            Console.WriteLine($"Result: {allms}ms");
        }
        private bool Compare(string answer, string result)
        {
            var answerReader = new StringReader(answer);
            var resultReader = new StringReader(result);
            bool isValid = true;
            string? answerLine;
            while ((answerLine = answerReader.ReadLine()) != null)
            {
                string? resultLine = resultReader.ReadLine();
                if (answerLine != resultLine)
                {
                    isValid = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Answer: {answerLine} | Result: {resultLine}");
                    Console.ResetColor();
                }
            }
            answerReader.Dispose();
            resultReader.Dispose();
            return isValid;
        }
    }
}
