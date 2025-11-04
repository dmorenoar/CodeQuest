using System;
using System.ComponentModel;
using System.Globalization;
using System.Timers;

public class Program
{
    public static void Main()
    {
        //Init consts
        const string InputName = "Input your wizard name";
        const string MsgWizardName = "Your wizard name is {0}";
        const string MsgWizardLevel = "Your level is {0}";

        //Option consts
        const int MinOP = 1, MaxOp = 3;
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Check the dungeon";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between {0} and {1}.";
        const string MsgExitGame = "Exiting the game ...";

        //Chapter 1 consts
        const int TrainDays = 5;
        const int LimitLevelOne = 20, LimitLevelTwo = 30, LimitLevelThree = 35, LimitLevelFour = 40;
        const string MsgDayInfo = "Dia {0} -> {1} you already meditated {2} hours and now your power is {3}!";
        const string MsgPower1 = "You can not even wield a wand";
        const string MsgPower2 = "You are still clumsy, yet you become stronger. Try again!!!";
        const string MsgPower3 = "You may be a magic winds caster, good job";
        const string MsgPower4 = "You can burn down to ashes a whole room, congrtulation!!!";
        const string MsgPower5 = "You reached the maximum power level anyone can reach, congratulations :)";


        //Chapter 2 consts
        const int MinDoor = 1, MaxDoor = 5;
        const int LastDoor = 3, MaxDoorAttemps = 3;
        const string MsgInputDoorCode = "Introduce the door code (1-5)";
        const string MsgIncorrectDoorCode = "Incorrect door code";
        const string MsgNoDoorAttemps = "The dragon has noticed you and you have been banned from server by him";
        const string MsgCorrectDoorCode = "The dragon respect you, You unlocked the door";
        const string MsgLastUnlock = "You have unlocked the final level. Get prepared for the battle";


        //Chapter 3 consts
        const int EnoughBits = 200, MaxExcavation = 5, MinBits = 5, MaxBits = 50;
        const int ProbFail = 5;
        const string MsgExcavation = "Excavation {0}: you mined {1} bits";
        const string MsgEnoughLoot = "You have enugh bits, you are rich";
        const string MsgNotEnoughLoot = "You have not enough bits, you are poor";

        int op = -1;
        string originalName = " ", fancyName= " ";
        int level = 1, power = 0;
        int doorInput = -1;

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
                Console.WriteLine(InputErrorMessage, MinOP, MaxOp);
            }
            catch (Exception)
            {
                Console.WriteLine(InputErrorMessage);
            }

            switch (op)
            {  
                case 0:
                    Console.WriteLine(MsgExitGame);
                    break;
                case 1:
                    int dayHoursTrain = rnd.Next(1, 11);

                    for (int day = 1; day <= TrainDays; day++)
                    {
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
                    int doorCode = rnd.Next(MinDoor, (MaxDoor + 1));
                    for (int door = 1; door <= LastDoor; door++)
                    {
                        int attemps = 0;
                        bool correctCode = false;
                        do
                        {
                            Console.WriteLine(MsgInputDoorCode);
                            try
                            {
                                doorInput = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine(InputErrorMessage,MinDoor,MaxDoor);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(InputErrorMessage,MinDoor,MaxDoor);
                            }

                            if (doorInput == doorCode)
                            {
                                Console.WriteLine(MsgCorrectDoorCode);
                                correctCode = true;
                            }
                            else
                            {
                                Console.WriteLine(MsgIncorrectDoorCode);
                                attemps++;
                            }
                        } while (attemps < MaxDoorAttemps && !correctCode);

                        if (!correctCode)
                        {
                            Console.WriteLine(MsgNoDoorAttemps);
                            door = LastDoor + 1;
                            op = 0;
                        }

                        if (door == LastDoor)
                        {
                            Console.WriteLine(MsgLastUnlock);
                        }
                    }
                    break;
                case 3:
                    int totalBits = 0;
                    for (int excavation = 1; excavation <= MaxExcavation; excavation++)
                    {
                        int probYouMined = rnd.Next(1, 101);
                        if (probYouMined <= ProbFail)
                            Console.WriteLine(MsgExcavation, excavation, 0);
                        else
                        {
                            int bitsMined = rnd.Next(MinBits, MaxBits);
                            totalBits += bitsMined;
                            Console.WriteLine(MsgExcavation, excavation, bitsMined);
                        }
                    }
                    if (totalBits > EnoughBits)
                        Console.WriteLine(MsgEnoughLoot);
                    else
                        Console.WriteLine(MsgNotEnoughLoot);
                    break;
            }

        } while (op != 0);
    }

}
