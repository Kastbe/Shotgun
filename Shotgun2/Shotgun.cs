using Shotgun2.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Shotgun2
{
    public partial class Shotgun : Form
    {
        Player player = new Player();
        Player computer = new Player();

        public Shotgun()
        {
            InitializeComponent();
            NewGame();
        }

        private void pbShoot_Click(object sender, EventArgs e)
        {
            player.Shoot();
            AI.AiAction(computer);
            UpdateUI();
        }
        private void pbBlock_Click(object sender, EventArgs e)
        {
            player.Block();
            AI.AiAction(computer);
            UpdateUI();
        }
        private void pbLoad_Click(object sender, EventArgs e)
        {
            player.Load();
            AI.AiAction(computer);
            UpdateUI();
        }
        private void pbShotgun_Click(object sender, EventArgs e)
        {
            player.Shotgun();
            AI.AiAction(computer);
            UpdateUI();
        }
        private void llblNewGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewGame();
        }
        
        public void NewGame()
        {
            pRoundResult.Hide();

            List<Player> players = Game.NewGame();
            this.player = players[0];
            this.computer = players[1];

            lblPlayerName.Text = player.Name;
            lblComputerName.Text = computer.Name;

            UpdateUI();
        }
        public void UpdateUI()
        {
            switch (player.Action)
            {
                case "Shoot":
                    pbPlayerAction.Image = Properties.Resources.shoot;
                    break;

                case "Load":
                    pbPlayerAction.Image = Properties.Resources.load;
                    break;

                case "Block":
                    pbPlayerAction.Image = Properties.Resources.block;
                    break;

                case "Shotgun":
                    pbPlayerAction.Image = Properties.Resources.shotgun;
                    break;

                default:
                    pbPlayerAction.Image = null;
                    pbBlock.Enabled = true;
                    pbBlock.Image = Properties.Resources.block;
                    break;
            }

            if(player.Bullets == 0)
            {
                pbShoot.Image = Properties.Resources.shoot_unavailable;
                pbShoot.Enabled = false;
            }
            else
            {
                pbShoot.Image = Properties.Resources.shoot;
                pbShoot.Enabled = true;
            }

            if (player.Bullets == 3)
            {
                pbLoad.Image = Properties.Resources.load_unavailable;
                pbLoad.Enabled = false;

                pbShotgun.Image = Properties.Resources.shotgun;
                pbShotgun.Enabled = true;
            }
            else
            {
                pbLoad.Image = Properties.Resources.load;
                pbLoad.Enabled = true;

                pbShotgun.Image = Properties.Resources.shotgun_unavailable;
                pbShotgun.Enabled = false;
            }

            switch(player.Bullets)
            {
                case 1:
                    pPlayerBullet1.BackColor = Color.Coral;
                    pPlayerBullet2.BackColor = Color.Gray;
                    pPlayerBullet3.BackColor = Color.Gray;
                    break;

                case 2:
                    pPlayerBullet1.BackColor = Color.Coral;
                    pPlayerBullet2.BackColor = Color.Coral;
                    pPlayerBullet3.BackColor = Color.Gray;
                    break;

                case 3:
                    pPlayerBullet1.BackColor = Color.Coral;
                    pPlayerBullet2.BackColor = Color.Coral;
                    pPlayerBullet3.BackColor = Color.Coral;
                    break;

                default:
                    pPlayerBullet1.BackColor = Color.Gray;
                    pPlayerBullet2.BackColor = Color.Gray;
                    pPlayerBullet3.BackColor = Color.Gray;
                    break;
            }

            switch (computer.Action)
            {
                case "Shoot":
                    pbComputerAction.Image = Properties.Resources.shoot;
                    break;

                case "Load":
                    pbComputerAction.Image = Properties.Resources.load;
                    break;

                case "Block":
                    pbComputerAction.Image = Properties.Resources.block;
                    break;

                case "Shotgun":
                    pbComputerAction.Image = Properties.Resources.shotgun;
                    break;

                default:
                    pbComputerAction.Image = null;
                    break;
            }

            pComputerBullet1.BackColor = Color.Gray;
            pComputerBullet2.BackColor = Color.Gray;
            pComputerBullet3.BackColor = Color.Gray;

            if (computer.Bullets >= 1)
            {
                pComputerBullet1.BackColor = Color.Coral;
            }

            if (computer.Bullets >= 2)
            {
                pComputerBullet2.BackColor = Color.Coral;
            }

            if (computer.Bullets == 3)
            {
                pComputerBullet3.BackColor = Color.Coral;
            }

            if(Game.RoundResult(player, computer, out string winner))
            {
                pbShoot.Enabled = false;
                pbBlock.Enabled = false;
                pbLoad.Enabled = false;
                pbShotgun.Enabled = false;

                pbShoot.Image = Properties.Resources.shoot_unavailable;
                pbBlock.Image = Properties.Resources.block_unavailable;
                pbLoad.Image = Properties.Resources.load_unavailable;                
                pbShotgun.Image = Properties.Resources.shotgun_unavailable;

                pRoundResult.Show();
                lblWinner.Text = winner;
            }
        }
    }
}
