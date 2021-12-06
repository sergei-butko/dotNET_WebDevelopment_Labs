using System;
using Library_Lab1_MyStack;

namespace Program_Lab1
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~ Lab_1. Variant_1. Stack implementation ~~~~~~~~~~~~~~~~~~~~~");
            
            //var stack = new MyStack<Student>();
            var stack = new MyStack<string>();
            stack.StackPushEvent += OutputMessage;
            stack.StackPopEvent += OutputMessage;
            stack.StackPeekEvent += OutputMessage;
            
            bool alive = true;
            while (alive)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1. Add element [Push(elem)]\t \t 2. Remove last element [Pop(elem)]");
                Console.WriteLine("3. Show last element [Peek(elem)]\t 4. Show full stack\t 5. Close Program");

                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Choose What to Do: ");
                    int command = Convert.ToInt32(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            // Console.Write("\nEnter student's name: ");
                            // string name = Console.ReadLine();
                            // Console.Write("Enter student's surname: ");
                            // string surname = Console.ReadLine();
                            // Console.Write("Enter student's age: ");
                            // int age = Convert.ToInt32(Console.ReadLine());
                            // Console.Write("Enter student's university: ");
                            // string university = Console.ReadLine();
                            // stack.Push(new Student(name, surname, age, university));
                            // stack.Peek().Display();
                            
                            Console.Write("\nEnter string: ");
                            string newString = Console.ReadLine();
                            stack.Push(newString);
                            break;
                        case 2:
                            stack.Pop();
                            break;
                        case 3:
                            stack.Peek();
                            break;
                        case 4:
                            if (!stack.IsEmpty)
                            {
                                Console.WriteLine();
                                foreach (var elem in stack)
                                {
                                    Console.Write($"{elem}\n");
                                    // elem.Display();
                                }
                            }
                            else
                            {
                                throw new Exception("Stack is empty!");
                            }
                            break;
                        case 5:
                            alive = false;
                            Environment.Exit(0);
                            break;
                        default:
                            throw new Exception("No such command was found!");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
            
            Console.ReadKey();
        }
        
        private static void OutputMessage(object e, EventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Event: {args}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}