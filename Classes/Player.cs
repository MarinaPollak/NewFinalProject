using System.Collections.Generic;
using System.Windows;

namespace NewFinalProject.Classes
{
    public class Player
    {
        // declare wallet here so we can access it in MainWindow
        public Wallet cash;
        public Wallet score;

        public List<Building> purchasedBuildings = new List<Building>();



        public Player()
        {
            int startingCash = 1_000_000;
            cash = new Wallet(startingCash);
            score = new Wallet(0);
        }

        // you can declare a variable to use inside only this method ==> public void PurchaseBuilding(Building building)
        public void PurchaseBuilding(Building building)
        {
            if (cash.CanPurchase(building.Cost))
            {
                purchasedBuildings.Add(building);
                cash.Remove(building.Cost);
                score.Add(building.Score);
            }
            else
            {
                MessageBox.Show("You cant afford this");
            }
        }
    }
}
