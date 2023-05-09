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
