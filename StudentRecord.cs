// Program that allows the user to store student records using a dictionary


using System;
using System.Collections.Generic;

namespace Records
{
    class StudentRecord
    {
        public static void Main(String[] args)
        {
            // map is a dictionary variable which holds the students record
            Dictionary<int, String> map = new Dictionary<int, String>();


            //1. Add a Student,2.Display Students,3. Remove a Student,4. Exit

            while (true)
            {
                Console.WriteLine("\nPlease Select the following\n");
                Console.Write("1.Add a Student\n2.Display Student\n3.Remove Student\n4.Exit\n\n");
                Console.Write("Enter your choice in numbers: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: AddStudent(map);
                            break;
                    case 2: DisplayStudent(map);
                            break;
                    case 3: RemoveStudent(map); 
                            break;
                    case 4: Console.WriteLine("Exiting the program...");
                            Environment.Exit(0);
                            break;  
                }
            }
        }


        // Adds the new student information to the record
        public static void AddStudent(Dictionary<int, String> map)
        {
            
            while(true)
            {
                Console.Write("Enter the student Id: ");
                int studentId = Convert.ToInt32(Console.ReadLine());
                if (map.ContainsKey(studentId))
                {
                    Console.WriteLine("\nThe Student already exists choose different one\n");
                    
                }
                else
                {
                    Console.Write("Enter the Student Name: ");
                    string studentName = Console.ReadLine();
                    map.Add(studentId, studentName);
                    break;
                }
            }
            
        }


        // Displays the Student Record
        public static void DisplayStudent(Dictionary<int, String> map)
        {
            if(map.Count==0)
            {
                Console.WriteLine("No Student Exists");

            }
            else
            {
                Console.WriteLine("\nDisplaying Student information\n");
                foreach(var x in map)
                {
                    Console.WriteLine($"Studnet Id: {x.Key} , Student Name: {x.Value}");

                }
            }
        }



        // Removing the student by studentId
        public static void RemoveStudent(Dictionary<int, String> map)
        {
            if (map.Count == 0)
            {
                Console.WriteLine("No Student Exists to remove.The Record is empty");

            }
            else
            {
                int studentId = Convert.ToInt32(Console.ReadLine());
                if (map.ContainsKey(studentId))
                {
                    map.Remove(studentId);
                    Console.WriteLine($"Student {studentId} was succesfully removed");
                }
                
            }
        }


    }
}