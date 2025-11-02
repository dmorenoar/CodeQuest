using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest
{
    public class TrainWizard
    {
        public static void Train()
        {
            const string InputNameMsg = "What is your name?";
            const string StartOfDayMsg = "Day {0}: {1], you have already medited {2} hours and your power is now {3} points!";
            //currentDay, name, trainingHours, powerLevel
            const string RankOne = "You repeat 2nd call";
            const string RankTwo = "You still mistake the wand for a spoon";
            const string RankThree = "You are a Magic Breeze Summoner.";
            const string RankFour = "Wow! You can summon dragons without burning the lab down!";
            const string RankFive = "You accomplished Arcane Master rank!";
            const string TitleMsg = "Your title is {0}";
            const int MinHours = 1;
            const int MaxHours = 5;
            const int MinPower = 1;
            const int MaxPower = 10;
            bool validInput = true;
            string name = "";
            int mageLevel = 1;
            int currentDay = 1;
            int trainingHours = 0;
            int powerLevel = 0;
            string[] possibleTitles = ["Raoden el Elantrí", "Zyn el Buguejat", "Arka Nullpointer", "Elarion de les Brases", "ITB-Wizard el Gris"];
            string title = "";

            Random meditationHours = new Random();
            Random powerLevelGain = new Random();

            do
            {
                Console.WriteLine(InputNameMsg);
                try
                {
                    name = Console.ReadLine();
                }
                catch (NullReferenceException)
                {
                    validInput = false;
                }
            } while (!validInput);
            for (currentDay = 1; currentDay<5; currentDay++)
            {
                Console.WriteLine(StartOfDayMsg, currentDay, name, trainingHours, powerLevel);
                
                trainingHours += meditationHours.Next(MinHours, MaxHours);
                powerLevel += powerLevelGain.Next(MinPower, MaxPower);
                switch (powerLevel)
                {
                    case <20:
                          Console.WriteLine(RankOne);
                          title = possibleTitles[0];
                          Console.WriteLine(TitleMsg, title);
                          break;
                    case < 30:
                          Console.WriteLine(RankTwo);
                          title = possibleTitles[1];
                          Console.WriteLine(TitleMsg, title);
                          break;
                    case < 35:
                        Console.WriteLine(RankThree);
                        title = possibleTitles[2];
                        Console.WriteLine(TitleMsg, title);
                        break;
                    case < 40:
                        Console.WriteLine(RankFour);
                        title = possibleTitles[3];
                        Console.WriteLine(TitleMsg, title);
                        break;
                    case > 40:
                        Console.WriteLine(RankFive);
                        title = possibleTitles[3];
                        Console.WriteLine(TitleMsg, title);
                        break;

                }
            }

            
/* > 20
Missatge-> “Encara confons la vareta amb una cullera” 
Obté el nivell->Zyn el Buguejat
< 30
Missatge-> “Ets un Invocador de Brises Màgiques.” 
Obté el nivell->Arka Nullpointer
> 35 - < 40
Missatge-> ““Uau! Pots invocar dracs sense cremar el laboratori!” 
Obté el nivell->Elarion de les Brases
≥ 47
Missatge-> “Has assolit el rang de Mestre dels Arcans!”
Obté el nivell->ITB - Wizard el Gris*/

        }
    }
}
