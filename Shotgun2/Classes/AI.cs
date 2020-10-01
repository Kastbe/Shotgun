using Shotgun2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shotgun2
{
    public static class AI
    {
        public static void AiAction(Player computer)
        {
            List<string> AiChoices = new List<string>();

            if(computer.Bullets == 3)
            {
                AiChoices.Add("Shotgun");
            }
            else
            {
                if (computer.Bullets > 0)
                {
                    AiChoices.Add("Shoot");
                }

                AiChoices.Add("Load");
                AiChoices.Add("Block");
            }

            Random rnd = new Random();

            int computerAction = rnd.Next(0, AiChoices.Count());

            switch(AiChoices[computerAction])
            {
                case "Shoot":
                    computer.Shoot();
                    break;

                case "Block":
                    computer.Block();
                    break;

                case "Load":
                    computer.Load();
                    break;

                case "Shotgun":
                    computer.Shotgun();
                    break;
            }
        }
    }
}
