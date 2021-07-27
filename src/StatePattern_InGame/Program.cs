using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern_InGame
{
    // This exercise refer to "七天學會設計模式" chapter 14

    public class Warrior
    {
        private int mHp;
        private State mState;
        public Warrior()
        {
            this.mHp = 100;
            this.mState = new NormalState();
        }

        public int HP { get { return this.mHp; } }

        public void Heal(int heal)
        {
            if (this.mHp != 0)
            { 
                this.mHp = this.mHp + heal;
                if (this.mHp > 100)
                    this.mHp = 100;
            }
            else
            {
                Console.WriteLine($"HP = {this.mHp}, heal invalid!");
            }
        }

        public void GetDamage(int damage)
        { 
            this.mHp = this.mHp - damage;
            if (this.mHp < 0)
                this.mHp = 0;
        }

        public void Move()
        {
            this.mState.Move(this);
        }

        public void SetState(State state)
        {
            this.mState = state;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();

            warrior.Move();

            warrior.GetDamage(30);
            warrior.Move();
            warrior.GetDamage(50);
            warrior.Move();

            warrior.Heal(120);
            warrior.Move();

            warrior.GetDamage(110);
            warrior.Move();
            warrior.Heal(20);

            Console.ReadLine();
        }
    }
}
