using System;
using System.ComponentModel;
using System.Timers;

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
        const string Error = "Error";
        const int TrainDays = 5;
        const int MaxPower = 50;
        int op = -1;
        string originalName =" ", fancyName = " ";
        bool validInput = true ;
        int level = 1, power = 0;


        Console.WriteLine(InputName);
        originalName = Console.ReadLine();


        Console.WriteLine("Your wizard name is "+ originalName);
        Console.WriteLine("Your level is "+ level);

        do
        {
            var rnd = new Random();
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);
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
                case 0:
                    Console.WriteLine("Exiting the game ...");
                    break;
                case 1:
                    int randomPower = rnd.Next(1, 11);
                    for (int day = 1; day <= TrainDays; day++)
                    {
                        int random = rnd.Next(1, 11);
                        power += random;
                        Console.WriteLine("Dia "+day+"-> "+originalName+" you already meditated 10 hours and now your power is "+power+"!");
                    }
                    if (power < 20)
                    {
                        Console.WriteLine("You are still clumsy, yet you become stronger. Try again!!!");
                        fancyName = " the Bugman";
                    }
                    else if(power < 30 && power >= 20)
                    {
                        Console.WriteLine("You may be a magic winds caster, good job");
                        fancyName = " Nullpointer";
                    }
                    else if(power > 35 && power < 40)
                    {
                        Console.WriteLine("You can burn down to ashes a whole room, congrtulation!!!");
                        fancyName = " the Burner";
                    }
                    else if(power >= 47)
                    {
                        Console.WriteLine("you reached the maximum power level anyone can reach, congratulations :)");
                        fancyName = " the gray";
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
