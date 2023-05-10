/* 
[CityBuilder] 
[C# WPF Game] 
[Marina Pollak]
[05/09/2022] 
tutor Thomas Maggraff https://github.com/gurrenm3
*/


namespace NewFinalProject.Classes
{
    public class Wallet
    {
        public int currentAmount;

        public Wallet(int startingAmount)
        {
            Set(startingAmount);
        }

        public int GetCurrentAmount()
        {
            return currentAmount;
        }

        public bool CanPurchase(int cost)
        {
            if (currentAmount >= cost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Add(int amount)
        {
            Set(currentAmount + amount);
        }

        public void Remove(int amount)
        {
            Set(currentAmount - amount);
        }

        public void Set(int amount)
        {
            currentAmount = amount;
        }
    }
}
