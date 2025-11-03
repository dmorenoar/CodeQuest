using System;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

public class Program
{
    static void Main()
    {
        const string MenuTitle = "===================================== MAIN MENU - CODEQUEST  =====================================";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Check the dungeon";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 3.";
        const string MsgName = "Enter your name: ";
        const string LineSeparator = "=========================================================================================================";
        const string Space = "";
        const string MsgLevel1 = "You are repeating the 2nd call.\n                          Gets the level -> Raoden el Elantrí";
        const string MsgLevel2 = "You still confuse a whisk with a spoon \n                          Gets the level -> Zyn the Buguejat";
        const string MsgLevel3 = "You are a summoner of Brises Màgiques.\n                          Gets the level -> Arka Nullpointer";
        const string MsgLevel4 = "Wow! You can summon dragons without burning down the lab!\n                          Gets the level -> Elarion of the Embers";
        const string MsgLevel5 = "You have achieved the rank of Master of the Arcana!\n                          Gets the level->ITB - Wizard el Gris";
        const string MsgMeditation = @"
██╗██╗███╗░░░███╗███████╗██████╗░██╗████████╗░█████╗░████████╗██╗░█████╗░███╗░░██╗░░░░░░░░░██╗██╗
╚█║╚█║████╗░████║██╔════╝██╔══██╗██║╚══██╔══╝██╔══██╗╚══██╔══╝██║██╔══██╗████╗░██║░░░░░░░░░╚█║╚█║
░╚╝░╚╝██╔████╔██║█████╗░░██║░░██║██║░░░██║░░░███████║░░░██║░░░██║██║░░██║██╔██╗██║░░░░░░░░░░╚╝░╚╝
░░░░░░██║╚██╔╝██║██╔══╝░░██║░░██║██║░░░██║░░░██╔══██║░░░██║░░░██║██║░░██║██║╚████║░░░░░░░░░░░░░░░
░░░░░░██║░╚═╝░██║███████╗██████╔╝██║░░░██║░░░██║░░██║░░░██║░░░██║╚█████╔╝██║░╚███║██╗██╗██╗░░░░░░
░░░░░░╚═╝░░░░░╚═╝╚══════╝╚═════╝░╚═╝░░░╚═╝░░░╚═╝░░╚═╝░░░╚═╝░░░╚═╝░╚════╝░╚═╝░░╚══╝╚═╝╚═╝╚═╝░░░░░░"; 

        const string Character1Msg= @"
===================================== CHAPTER 1 - Train your wizard =====================================

                        Name : {0}                      Level : {1}

                        Power : {2}

=========================================================================================================
            ";
        const string Char1UileTraining = @"
===================================== CHAPTER 1 - Train your wizard =====================================

                        Name : {0}                       Level : {1}

                        Power : {2}

                        Day: {3}                         Hour: {4}

=========================================================================================================
            ";

        const string PowerUiLevel = @"
===================================== CHAPTER 1 - Train your wizard =====================================

                        Name : {0}                       Level : {1}

                        Power : {2}

                        Title : ";

    
        const int DaysMax = 5; 

        int op = 0;
        bool validInput;
        string inputName;
        int level = 1;
        int powerRandom;
        int powerCharacter = 0;
        int hourRandom = 0;
        bool validateName = true;
        var random = new Random();

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
                Console.WriteLine(LineSeparator);

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

            if(validInput)
            {
                switch (op)
                {
                    case 1:
                        Console.Write(MsgName);
                        inputName = Console.ReadLine();                        
                        validateName =  Regex.IsMatch(inputName, @"^[a-zA-Z]+$");

                        if (validateName)
                        {
                            Console.WriteLine(Character1Msg, inputName, level, powerCharacter);
                            for (int i = 1; i <= DaysMax; i++)
                            {
                                Console.Clear();
                                powerRandom = random.Next(1, 10);
                                hourRandom = random.Next(1, 24);
                                powerCharacter = powerCharacter + powerRandom;

                                Console.WriteLine(MsgMeditation);
                                Thread.Sleep(2400);
                                Console.WriteLine(Char1UileTraining, inputName, level, powerCharacter, i, hourRandom);
                                Thread.Sleep(2000);
                            }
                            Console.Clear();
                            if (powerCharacter < 20)
                            {
                                Console.Write(PowerUiLevel, inputName, level, powerCharacter);
                                Console.WriteLine(MsgLevel1);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);
                            }
                            if (powerCharacter >= 20 && powerCharacter < 30)
                            {
                                Console.Write(PowerUiLevel, inputName, level, powerCharacter);
                                Console.WriteLine(MsgLevel2);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);

                            }
                            else if (powerCharacter >= 30 && powerCharacter < 35)
                            {
                                Console.Write(PowerUiLevel, inputName, level, powerCharacter);
                                Console.WriteLine(MsgLevel3);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);

                            }
                            else if (powerCharacter >= 35 && powerCharacter < 40)
                            {
                                Console.Write(PowerUiLevel, inputName, level, powerCharacter);
                                Console.WriteLine(MsgLevel4);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);

                            }
                            else if (powerCharacter >= 40)
                            {
                                Console.Write(PowerUiLevel, inputName, level, powerCharacter);
                                Console.WriteLine(MsgLevel5);
                                Console.WriteLine(Space);
                                Console.WriteLine(LineSeparator);

                            }
                        }
                        else
                        {
                            Console.WriteLine("Error: Your name is not in the correct format");
                        }
                        
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }


        } while (op != 0);
    }

}
