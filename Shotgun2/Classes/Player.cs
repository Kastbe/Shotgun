
namespace Shotgun2.Classes
{
    public class Player
    {
        public string Name { get; set; }
        public int Bullets { get; set; }
        public string Action { get; set; }

        public Player()
        {

        }
        public Player(string name)
        {
            this.Name = name;
            this.Bullets = 1;
            this.Action = null;
        }

        public void Shoot()
        {
            if(this.Bullets != 0)
            {
                this.Action = "Shoot";
                this.Bullets -= 1;
            }         
        }
        public void Block()
        {
            this.Action = "Block";
        }
        public void Load()
        {
            if(this.Bullets != 3)
            {
                this.Action = "Load";
                this.Bullets += 1;
            }
        }
        public void Shotgun()
        {
            this.Action = "Shotgun";
            this.Bullets = 2;
        }
    }
}
