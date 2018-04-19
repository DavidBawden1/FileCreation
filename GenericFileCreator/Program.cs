using System;
namespace GenericFileCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                var inputs = new Input.Input();
                inputs.WelcomeUser();
                inputs.FilePathInput();
            }
        }
    }
}
