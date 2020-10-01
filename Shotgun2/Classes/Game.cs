using System.Collections.Generic;

namespace Shotgun2.Classes
{
    public static class Game
    {
        public static List<Player> NewGame()
        {
            List<Player> players = new List<Player>();

            Player player = new Player("Player");
            players.Add(player);

            Player computer = new Player("Computer");
            players.Add(computer);

            return players;
        }
        public static bool RoundResult(Player player, Player computer, out string winner)
        {
            bool roundResult = false;
            winner = null;

            if (player.Action == "Shotgun" && computer.Action != "Shotgun")
            {
                roundResult = true;
                winner = player.Name;
            }
            else if (computer.Action == "Shotgun" && player.Action != "Shotgun")
            {
                roundResult = true;
                winner = computer.Name;
            }
            else if (player.Action == "Shoot" && (computer.Action != "Block" && computer.Action != "Shoot"))
            {
                roundResult = true;
                winner = winner = player.Name;
            }
            else if (computer.Action == "Shoot" && (player.Action != "Block" && player.Action != "Shoot"))
            {
                roundResult = true;
                winner = computer.Name;
            }

            return roundResult;
        }
    }
}
