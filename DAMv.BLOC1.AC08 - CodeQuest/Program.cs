using System;
using System.ComponentModel;
using System.Globalization;
using System.Timers;

public class Program
{
    public static void Main()
    {
        const string InputName = "Input your wizard name";
        const string MsgWizardName = "Your wizard name is {0}";
        const string MsgWizardLevel = "Your level is {0}";

        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Check the dungeon";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 3.";
        const string MsgExitGame = "Exiting the game ...";

        const string MsgDayInfo = "Dia {0} -> {1} you already meditated {2} hours and now your power is {3}!";
        const string MsgPower1 = "You can not even wield a wand";
        const string MsgPower2 = "You are still clumsy, yet you become stronger. Try again!!!";
        const string MsgPower3 = "You may be a magic winds caster, good job";
        const string MsgPower4 = "You can burn down to ashes a whole room, congrtulation!!!";
        const string MsgPower5 = "You reached the maximum power level anyone can reach, congratulations :)";

        const int TrainDays = 5;
        const int LimitLevelOne = 20, LimitLevelTwo = 30, LimitLevelThree = 35, LimitLevelFour = 40;

        int op = -1;
        string originalName = " ", fancyName= " ";
        bool validInput = true;
        int level = 1, power = 0;


        Console.WriteLine(InputName);
        originalName = Console.ReadLine();


        Console.WriteLine(MsgWizardName, originalName);
        Console.WriteLine(MsgWizardLevel, level);

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

            switch (op)
            {  
                case 0:
                    Console.WriteLine(MsgExitGame);
                    break;
                case 1:
                    for (int day = 1; day <= TrainDays; day++)
                    {

                        int dayHoursTrain = rnd.Next(1, 11);
                        power += dayHoursTrain;
                        Console.WriteLine(MsgDayInfo, day, originalName, dayHoursTrain, power);
                    }
                    if (power < LimitLevelOne)
                    {
                        Console.WriteLine(MsgPower1);
                        fancyName = " the Elantrine";
                    }
                    else if (power >= LimitLevelOne && power < LimitLevelTwo)
                    {
                        Console.WriteLine(MsgPower2);
                        fancyName = " the Bugman";
                    }
                    else if(power >= LimitLevelTwo && power < LimitLevelThree)
                    {
                        Console.WriteLine(MsgPower3);
                        fancyName = " Nullpointer";
                    }
                    else if(power >= LimitLevelThree && power < LimitLevelFour)
                    {
                        Console.WriteLine(MsgPower4);
                        fancyName = " the Burner";
                    }
                    else if(power >= LimitLevelFour)
                    {
                        Console.WriteLine(MsgPower5);
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
