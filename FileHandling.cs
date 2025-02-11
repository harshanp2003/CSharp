 //C# program that asks the user to enter multiple lines of text (until they type "STOP").


using System;
using System.IO;

namespace FileInfo
{
    class FileHandling
    {
       public static void Main(String[] args)
       {
            int i, j;
            string text,fileName="output.txt";
            Console.WriteLine("Enter the filename");
           

            using (FileStream fs = File.Create(fileName))
            {
                // Obtain the full path of the file
                string fullPath = Path.GetFullPath(fileName);
                Console.WriteLine($"\nThe full path of the file is: {fullPath}\n");
            }



            List<string> texts = new List<string>();

            Console.WriteLine("start Entering the text");


            // Taking input , the list of texts line by line until STOP is entered by the user
            while(true)
            {
                text = Console.ReadLine();
                if(!(text.Equals("STOP") || (text.Equals("stop"))))
                {
                  
                   texts.Add(text);
                }
                else
                {
                    File.WriteAllLines(fileName, texts);
                    Console.WriteLine("\nText has ben saved succesfully");
                    break;
                }
            }



            // Accessing the Contents of the File
            try
            {
                
                Console.WriteLine("\nEnter the filename");
                fileName=Console.ReadLine();
                string[] lines = File.ReadAllLines(fileName);  // Read all lines from the file

                // Checks if file is empty
                try
                {
                    if (lines.Length==0)
                    {
                        throw new Exception("\nThe file is empty.");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\nProgram Terminated...");
                }

                Console.WriteLine("\nTexts inside the files are");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);  // Prints each line
                }
            }
            catch (FileNotFoundException ex)
            {
                // Handling the FileNotFoundException
                Console.WriteLine($"\nError: {ex.Message}");
                Console.WriteLine($"File: {ex.FileName}"); // Returns the name of the file that caused the exception
            }

        }

    }
}
