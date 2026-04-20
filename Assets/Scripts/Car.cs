using System;

namespace VehicleSystem
{
    public class Car : Vehicle
    {
        private IntArrayStack stack;
        
        public Car(float speed, int wheels, bool needsFuel) : base(speed, wheels, needsFuel)
        {
            stack = new IntArrayStack(10);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
        }

        public void PlaySong()
        {
            int songId = stack.Peek();
        }

        public void NextSong()
        {
            stack.Pop();
            int songId = stack.Peek();
        }

        public void PreviousSong()
        {
            
        }

        public new void Move()
        {
            speed = 10;
            wheels = 2;

            base.Move();
        }

        public override void StartEngine()
        {
            
        }
    }
}

