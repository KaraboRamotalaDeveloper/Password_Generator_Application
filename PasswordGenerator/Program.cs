using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PasswordGenerator
{
  internal class Program
  {
    // PasswordGenerator class
    class PasswordGenerator
    {
      // Declare the number of items variable
      private int numItems;

      // Get number of items method
      public void GetNumItems()
      {
        // Ask the user for the number of items to create
        Console.Write("Enter the number of items to create: ");
        string input = Console.ReadLine();

        // Validate the input (validation)
        while (!int.TryParse(input, out numItems) || numItems <= 0)
        {
          Console.WriteLine("\nInvalid input. Please enter a positive integer.");
          Console.Write("Enter the number of items to create: ");
          input = Console.ReadLine();
        }
      }

      // Generate password method
      public string GeneratePassword(string fullName)
      {
        // Declare varaibles to be used like the list of characters for all the vowels
        // The password
        // Number of eliminated letters
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 't' };
        string password = "";
        int eliminatedLetters = 0;

        // Foreach loop to enumerate through the string and perform the appropriate operations
        foreach (char c in fullName)
        {
          if (Array.IndexOf(vowels, Char.ToLower(c)) != -1)
          {
            if (Char.ToLower(c) == 'a' || Char.ToLower(c) == 'e' || Char.ToLower(c) == 't')
              eliminatedLetters++;
            else
              password += new string(c, 2);
          }
          else if (c == ' ')
            password += "S&?";
          else
            password += c;
        }

        password += eliminatedLetters;
        return password;
      }

      // Create Password method
      public void CreatePasswords()
      {
        // Get the number of items from the user (Call method)
        GetNumItems();

        // Create passwords for each item
        for (int i = 0; i < numItems; i++)
        {
          // Ask the user for the full name
          Console.Write("\nEnter the full name: ");
          string fullName = Console.ReadLine();

          // Generate the password
          string password = GeneratePassword(fullName);
          Console.WriteLine("Generated password: " + password);
        }
      }

      static void Main(string[] args)
      {
        // Create an instance of the PasswordGenerator class
        PasswordGenerator generator = new PasswordGenerator();

        // Call the CreatePasswords method to start the password generation process
        generator.CreatePasswords();

        // Print end program message
        Console.WriteLine("\nThank you for using the Password Generator!");

        // Wait for the user to enter a key before closing the application
        Console.ReadKey();
      }
    }
  }
}
