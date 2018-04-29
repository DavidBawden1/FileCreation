using GenericFileCreator.FileCreation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GenericFileCreator.Input
{
    public class Input
    {
        string filePath;

        public void WelcomeUser()
        {
            Console.WriteLine("Hello and welcome to the File creator!\n");
        }

        public void FilePathInput()
        {
            Console.WriteLine("What is the full file path you would like to create?");
            filePath = Console.ReadLine();

            while (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("You must supply a file path");
                filePath = Console.ReadLine();
            }

            CreateDirectoryIfNotExists();
            CreateFile();
        }

        private void CreateFile()
        {
            try
            {
                if (FileCreator.CreateFile(filePath))
                {
                    Console.WriteLine($"File {filePath} created!");
                    filePath = string.Empty;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured. {e}\nPlease supply a valid filePath this time! ");
                filePath = string.Empty;
            }
        }

        private void CreateDirectoryIfNotExists()
        {
            string directoryName = string.Empty;
            try
            {
                directoryName = Path.GetDirectoryName(filePath);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Failed retrieving the directory from the supplied path! {e}");
            }

            if (!Directory.Exists(directoryName))
            {
                Console.WriteLine($"The directory {Path.GetDirectoryName(filePath)} doesn't exist! Attempting to create the directory");
                try
                {
                    FileCreator.CreateDirectory(filePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Attempt failed! {e}");
                }
            }
        }
    }
}
