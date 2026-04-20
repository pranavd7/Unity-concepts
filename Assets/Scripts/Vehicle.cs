namespace VehicleSystem
{
    public abstract class Vehicle
    {
        protected float speed;
        protected int wheels;
        protected bool needsFuel;

        public Vehicle(float speed, int wheels, bool needsFuel)
        {
            this.speed = speed;
            this.wheels = wheels;
        }

        public void Move()
        {
        }

        public void Move(int speed)
        {
            
        }

        public void Move(int speed, int wheels)
        {
            
        }
        
        public abstract void StartEngine();
    }
}