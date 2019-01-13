using System;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace GenericFileCreator.FileCreation
{
    public static class FileCreator
    {
        internal static bool CreateFile(string inputFilePath)
        {
            string fullPath = Path.GetFullPath(inputFilePath);
            if(string.IsNullOrEmpty(fullPath)) throw new ArgumentException("The filepath cannot be null or empty.");

            string directoryName = string.Empty;          

            if (File.Exists(inputFilePath)) throw new IOException($"The file {fullPath} already exists.");

            using (var stream = File.Create(fullPath))
            {
                try
                {
                    Byte[] content = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes("Sample text: You have created a file");
                    stream.WriteAsync(content, 0, content.Length);
                    return true;
                }
                catch (IOException)
                {
                    throw new IOException($"Failed to create file {inputFilePath}");
                }
            }
        }

        internal static bool CreateDirectory(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("The filepath cannot be null or empty.");
            try
            {
                Directory.CreateDirectory(filePath);
                return true;
            }
            catch(IOException e)
            {
                throw new Exception($"Failed to create the directory(s) in {filePath} {e}");
            }
        }

        internal static bool CreateFile(string filename, DateTime lastRunDateTime)
        {
            string inputFilepath = Path.Combine(Environment.CurrentDirectory, filename);
            inputFilepath = Path.GetFullPath(inputFilepath);
            if (string.IsNullOrEmpty(inputFilepath)) throw new ArgumentException("The filepath cannot be null or empty.");

            string directoryName = string.Empty;

            if (File.Exists(inputFilepath)) throw new IOException($"The file {inputFilepath} already exists.");

            using (var stream = File.Create(inputFilepath))
            {
                try
                {
                    Byte[] content = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes($"{lastRunDateTime}");
                    stream.WriteAsync(content, 0, content.Length);
                    return true;
                }
                catch (IOException)
                {
                    throw new IOException($"Failed to create file {inputFilepath}");
                }
            }
        }
    }
}
