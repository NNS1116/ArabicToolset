using System;
using System.Reflection;

namespace ArabicTextInterfaceWithReflection
{
    class ArabicText
    {
        public string Text { get; set; }

        public ArabicText(string text)
        {
            Text = text;
        }
    }

    class Program
    {
        static ArabicText arabicText = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Arabic Text Interface with Reflection");
            Console.WriteLine("-------------------------------------");

            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Enter Arabic Text");
                Console.WriteLine("2. Reverse Arabic Text");
                Console.WriteLine("3. Count Words in Arabic Text");
                Console.WriteLine("4. Print Properties");
                Console.WriteLine("5. Exit");

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Arabic Text: ");
                        string text = Console.ReadLine();
                        arabicText = new ArabicText(text);
                        break;

                    case "2":
                        if (arabicText != null)
                        {
                            string reversedArabicText = ReverseArabicText(arabicText.Text);
                            DisplayArabicText(reversedArabicText, "Reversed Arabic Text: ");
                        }
                        else
                        {
                            Console.WriteLine("Please enter Arabic text first.");
                        }
                        break;

                    case "3":
                        if (arabicText != null)
                        {
                            int wordCount = CountArabicWords(arabicText.Text);
                            Console.WriteLine($"Number of Words in Arabic Text: {wordCount}");
                        }
                        else
                        {
                            Console.WriteLine("Please enter Arabic text first.");
                        }
                        break;

                    case "4":
                        if (arabicText != null)
                        {
                            PrintProperties(arabicText);
                        }
                        else
                        {
                            Console.WriteLine("Please enter Arabic text first.");
                        }
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void DisplayArabicText(string text, string label = "Arabic Text: ")
        {
            Console.WriteLine(label + text);
        }

        static string ReverseArabicText(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static int CountArabicWords(string text)
        {
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        static void PrintProperties(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            Console.WriteLine("Properties of ArabicText:");
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(obj)}");
            }
        }
    }
}
