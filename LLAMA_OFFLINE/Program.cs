using System.Diagnostics;
using System.Text;

class Program
{
    static async Task Main()
    {
        string llamaExe = "llama-run.exe";
        string modelFile = "tinyllama-1.1b-chat-v1.0.Q4_K_M.gguf";

        while (true)
        {
            Console.Write("Let's go: ");
            string prompt = Console.ReadLine();

            var psi = new ProcessStartInfo
            {
                FileName = llamaExe,
                Arguments = $"\"{modelFile}\" \"{prompt}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8
            };

            using var process = Process.Start(psi);
            string output = await process.StandardOutput.ReadToEndAsync();
            string errors = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();
            Console.WriteLine("✅ Output:\n");
            Console.WriteLine(output);
        }
    }
}
