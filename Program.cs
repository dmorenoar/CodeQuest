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

        const string Character2Msg = @"
================================================== CHAPTER 2 - Check the dungeon ===========================================
    
        You have entered the dungeon. Three doors block your path, and only by correctly deciphering
        their codes will you be able to escape alive; if you fail, Dragon Ramon will expel you from
        the server.

============================================================================================================================
            ";
        const string Character2Doors = @"
================================================== CHAPTER 2 - Check the dungeon ===========================================

          ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▒▓▒▓▓▒▓▒▓▒▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▒▓▒▓▓▒▓▒▓▒▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▒▓▒▓▓▒▓▒▓▒▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▒▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▒▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▒▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓1▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓2▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓3▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒
          ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒     ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒

=============================================================================================================================
";
        const string Character2Game = @"
================================================== CHAPTER 2 - Check the dungeon ===========================================

                                                ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒        
                                                ▒▒▒▒▒▒▒▓▓▓▓▒▓▒▓▓▒▓▒▓▒▓▓▓▓▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▓▓▓▒▓▓▒▒▒▒▒▒▒         
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒         
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓{0}▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒         
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓██▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▓▓▓▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒          
                                                ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒     

        Attemps : {1}

        Enter the correct code to unlock the door: ";

        const string MsgErrorName = "Error: Your name is not in the correct format.";
        const string FinalDoor = @"
=============================================================================================================================

                                            You have unlocked the final level. 
                        
                                                    Prepare for battle!.

=============================================================================================================================";
        const string MsgOkDragon = "        The dragon respects you. You've unlocked the next level.!";
        const string MsgKoDragon = "        The dragon has detected your presence and has expelled you from the server.!";
        const string MsgErrorNumber = "        Error : You have entered an incorrect number.!";
        const string MsgFinalOkChapter2 = @"       
=============================================================================================================================

                                    You have failed to decipher the dungeon's codes.

                                       The dragon's roar echoes in the darkness...

                                             Your adventure ends here.

=============================================================================================================================
";
        const string MsgFinalKoChapter2 = @"       
=============================================================================================================================

                                      You have managed to decipher the dungeon codes.

                                            You have escaped safe and sound. 

                                                Your adventure continues.
 
=============================================================================================================================
";
        const string Chapter3Msg = @"
==================================================== CHAPTER 3 - Loot the mine  =============================================

                         __    __     __     __  __      ______     __   __     _____     ______    
                        /\  -./  \   /\ \   /\ -.\  \   /\  __ \   /\  -.\ \   /\  _ -.  /\  __ \   
                        \ \ \-./\ \  \ \ \  \ \ \-.  \  \ \  __ \  \ \ \-.  \  \ \ \/\ \ \ \ \/\ \  
                         \ \_\ \ \_\  \ \_\  \ \_\\ \_\  \ \_\ \_\  \ \_\\\ _\  \ \____-  \ \_____\ 
                          \/_/  \/_/   \/_/   \/_/ \/_/   \/_/\/_/   \/_/ \/_/   \/____/   \/_____/ 
                                                                            
                                                                            "; 
        const string Chapter3MineMsg = @"
==================================================== CHAPTER 3 - Loot the mine  =============================================

                                                                
                                                                    ██▓█  █                          
                                                        ██▓█▓▓▓▓▓▓████ ▒███  █                        
                                                       ██▒    ░░░▒▒▒░▒      █▓█▒                       
                                                     ██████████████▓█ ░░░ █░░░▒▓█▓█                   
                                                                  ▒    ░██▓▒░░░░▒▓▓█                
                                                                  ▓███▒█   ░████▓▒░░▒█              
                                                                  █▒▒▒▓           ██▒▓▒            
                                                                 ▒█▒▒▓█              █▓           
                                                                  ▓▒▒▒                          
                                                                 █░▒▓█                              
                                                                ░▓░▒█                                                              
                                                               ▓▓▓▓█                          
                                                              ░█   █                            
                                                              █░░░▓█                                                    
                                                            ░█░░ ▓▒                                            
                                                            ▓   ▓█                        
                                                            ░████░                          

                No.Excavation : {0}

                Mined bitcoins: +{1}

                Total bitcoins: {2}

=============================================================================================================================";
        const string Chapter3MsgBadLuck = @"
=============================================================================================================================

                                            Today is not your lucky day.

                                                 You found 0 bits.

=============================================================================================================================
";
        const string Chapter3MsgOk = @"
=============================================================================================================================


                                   You've unlocked the gold GPU! Your spells now run at 120 FPS!
                                                

=============================================================================================================================
";
        const string Chapter3MsgKo = @"
=============================================================================================================================


                            Your magic card is still integrated. It's time to defeat another dragon!
                                                

=============================================================================================================================
";
        const string MsgOpIncorrect = "Select the correct option.";


        const int DaysMax = 5; 

        int op = 0;
        int doorRandom;
        bool validInput;
        int inputNum = 0;
        string inputName;
        int level = 1;
        int powerRandom;
        int powerCharacter = 0;
        int hourRandom = 0;
        bool validateName = true;
        int bitcoinCharacter = 0;
        int bitcoinsRandom;

        var random = new Random();
        

        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
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
                            Console.WriteLine(MsgErrorName);
                            Thread.Sleep(1500);
                        }

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(Character2Msg);
                        Console.WriteLine(Character2Doors);
                        for (int i = 1; i < 3+1 ; i++)
                        {
                            bool chapter2Validate = true;

                            if (i == 3 && chapter2Validate)
                            {
                                Console.WriteLine(FinalDoor);
                            }
                            doorRandom = random.Next(1, 5);
                            
                            for (int j = 0; j < 3; j++)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;

                                Console.Write(Character2Game, i,3-j);
                                bool numValidate = int.TryParse(Console.ReadLine(), out inputNum);
                                if (numValidate)
                                {
                                    if (inputNum == doorRandom)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(Space);
                                        Console.WriteLine(MsgOkDragon);
                                        j = 4;
                                        chapter2Validate = true;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(Space);
                                        Console.WriteLine(MsgKoDragon);
                                        chapter2Validate = false;
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(MsgErrorNumber);
                                }
                                
                            }
                            if (!chapter2Validate)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(LineSeparator);
                                Console.WriteLine(MsgFinalOkChapter2);
                                i = 4;
                                Console.WriteLine(LineSeparator);
                            }
                            if(chapter2Validate && i == 3)
                            {
                                Console.WriteLine(MsgFinalKoChapter2);
                            }
                            Thread.Sleep(3500);

                        }
                        break;
                    case 3:
                        Console.Clear();

                        Console.WriteLine(Chapter3Msg);

                        for (int i = 1;  i < 5+1; i++)
                        {

                            bitcoinsRandom = random.Next(0, 50);
                           
                            if (bitcoinsRandom < 5)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                bitcoinsRandom = 0;
                                Console.WriteLine(Chapter3MsgBadLuck);
                            }
                            Console.ForegroundColor = ConsoleColor.Gray;
                            bitcoinCharacter = bitcoinCharacter + bitcoinsRandom;
                            Console.WriteLine(Chapter3MineMsg, i,bitcoinsRandom , bitcoinCharacter);
                            Thread.Sleep(3500);
                            Console.Clear();


                        }
                        if (bitcoinCharacter > 200)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(Chapter3MsgOk);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(Chapter3MsgKo);
                        }
                        Thread.Sleep(4500);
                        break;
                    default:

                        Console.WriteLine(MsgOpIncorrect);
                        Thread.Sleep(1500);

                        break;                
                }
            }

        } while (op != 0);
    }

}
