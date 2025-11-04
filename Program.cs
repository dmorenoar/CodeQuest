using System;
using System.Globalization;
public class Program
{
    static void Main()
    {
        const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Check the dungeon";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a number between 0 and 3.";

        const string NameWizard = "Introduce the name of your wizard";
        const string daysMSG = "Day --> {0}, {1}  you have meditated for {2} hours and your power is {3} points";
        const string MessageOneLevel = "You repeat in the 2nd call";
        const string MessageTwoLevel = "You still confuse the rod with a spoon";
        const string MessageThreeLevel = "You are a Summoner of Magical Breezes";
        const string MessageFourLevel = "Wow! You can summon dragons without burning down the lab!";
        const string MessageFiveLevel = "You have reached the rank of Arcane Master!";

        const string MessageInicial = "Your magician must demonstrate his training and enter the Dungeon of the Dragon RAMón the Mighty, where each door is protected by a digital access code.";

        const string MessageExit = "The dragon has detected your presence and has expelled you from the server!";
        const string MessageSuccesful = "The dragon respects you. You have unlocked the next level!";
        const string MessageLastDoor = "You have unlocked the final level. Prepare for battle!";

        const string MessageInicialTwo = "Introduce a number in the interval of 1 and 5";
        const string MessageDoors = "Door {0}, Introduce the correct code between 1 and 5, you have {1} attemps";
        const string MessageError = "Incorrect code, please try again";
        const string MessageFail = "Incorrect number, plese try again";

        int op = 0;
        bool validInput;

        string name = "";
        int inicial_level = 1;
        int days = 5;
        var random = new Random();
        int hours_level = 0;
        string levelText = "";

        const int doors = 3;
        const int attemps = 3;

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
                case 0:
                    Console.WriteLine("Exit the game");
                    break;
                case 1:
                    Console.WriteLine(NameWizard);
                    name = Console.ReadLine();

                    for (int i = 1; i <= days; i++)
                    {
                        int pointsDays = random.Next(1, 11);
                        inicial_level += pointsDays;
                        int hoursdays = random.Next(1, 25);
                        hours_level += hoursdays;
                        Console.WriteLine(daysMSG, i, name, hours_level, inicial_level);
                    }
                    switch (inicial_level)
                    {
                        case < 20:
                            Console.WriteLine(MessageOneLevel);
                            levelText = "Raoden el Elantri";
                            break;
                        case > 20 and < 30:
                            Console.WriteLine(MessageTwoLevel);
                            levelText = "Zyn el Buguejat";
                            break;
                        case > 30 and < 35:
                            Console.WriteLine(MessageThreeLevel);
                            levelText = "Arka Nullpointer";
                            break;
                        case > 35 and < 40:
                            Console.WriteLine(MessageFourLevel);
                            levelText = "Elarion de les Brases";
                            break;
                        case > 40:
                            Console.WriteLine(MessageFiveLevel);
                            levelText = "ITB-Wizard el Gris";
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine(MessageInicial);
                    bool expelled = false;

                    for (int i = 1; i <= doors && !expelled; i++)
                    {
                        int doorstwo = random.Next(1, 6);
                        bool openDoor = false;
                        Console.WriteLine(MessageDoors, i, attemps);

                        for (int j = 1; j <= attemps && !openDoor; j++)
                        {
                            Console.WriteLine(MessageInicialTwo);
                            int usernum = 0;

                            try
                            {
                                usernum = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine(MessageFail);
                            }

                            if (usernum == doorstwo)
                            {
                                openDoor = true;

                                if (i == doors)
                                {
                                    Console.WriteLine(MessageLastDoor);
                                }
                                else
                                {
                                    Console.WriteLine(MessageSuccesful);
                                }
                            }
                            else
                            {
                                Console.WriteLine(MessageError);

                                if (j == attemps)
                                {
                                    expelled = true;
                                    Console.WriteLine(MessageExit);
                                }
                            }
                        }
                    }

                    break;
            }

        } while (op != 0);
    }
}
