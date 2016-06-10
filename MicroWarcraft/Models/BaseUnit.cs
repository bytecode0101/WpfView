namespace MyWarcraft.Models
{
    public class BaseUnit
    {

        private int unitCost;
        private int unitHealth;
        private int unitSpeed;
        private int unitDamage;
        private int position;

        public void attack()
        {
        }

        public void dismiss()
        {
            throw new System.NotImplementedException();
        }

        public void guard()
        {
            throw new System.NotImplementedException();
        }

        public void move()
        {
            throw new System.NotImplementedException();
        }

        public void stop()
        {
            throw new System.NotImplementedException();
        }
    }
}