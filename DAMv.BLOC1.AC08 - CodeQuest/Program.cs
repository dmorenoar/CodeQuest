using System;
using System.ComponentModel;

public class Program
{
    public static void Main()
    {
        const string InputName = "Input your wizard name";
        const string InvalidName = "Invalid name, only normal characters";
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Check the dungeon";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 3.";
        const int TrainDays = 5;
        int op = 0;
        string name;
        bool validInput;
        do 
        { 
            Console.WriteLine(InputName);
            name = Console.ReadLine();


        } while(validInput!);
        

        do
        {
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);

            validInput = true;

            try
            {
                op = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }
            catch (Exception)
            {
                Console.WriteLine(InputErrorMessage);
                validInput = false;
            }

            if (validInput)
            {
                Console.WriteLine(op);
            }
            switch (op)
            {  
                case 1:
                    var rnd = new Random();
                    
                    int random = rnd.Next(1, 11);
                    for (int i = 1; i <= TrainDays; i++)
                    {
                        Console.WriteLine("Dia " + i + "->");
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine(InputErrorMessage);
                    break;
            }

        } while (op != 0);
    }

}
