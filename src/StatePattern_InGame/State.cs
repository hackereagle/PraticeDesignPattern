using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern_InGame
{
    /// <summary>
    /// State changed by HP
    /// </summary>
    public interface State
    {
        /// <summary>
        /// Different state responds different behavir, which relate warrior. 
        /// So need pass warrior into State.
        /// </summary>
        /// <param name="warrior"></param>
        void Move(Warrior warrior);
    }

    public class NormalState : State
    {
        public void Move(Warrior warrior)
        {
            if (warrior.HP > 70)
            {
                Console.WriteLine($"HP = {warrior.HP}, Normal State.");
            }
            else
            {
                warrior.SetState(new FuryState());
                warrior.Move();
            }
        }
    }

    public class FuryState : State
    {
        public void Move(Warrior warrior)
        {
            int hp = warrior.HP;
            if (hp > 70)
            {
                warrior.SetState(new NormalState());
                warrior.Move();
            }
            else if (hp <= 30)
            {
                warrior.SetState(new DesperateState());
                warrior.Move();
            }
            else
            {
                Console.WriteLine($"HP = {warrior.HP}, furry state so attack add 30%!");
            }

        }
    }

    public class DesperateState : State
    {
        public void Move(Warrior warrior)
        {
            int hp = warrior.HP;
            if (hp == 0)
            {
                warrior.SetState(new UnableState());
                warrior.Move();
            }
            else if (hp > 30)
            {
                warrior.SetState(new FuryState());
                warrior.Move();
            }
            else
            {
                Console.WriteLine($"HP = {hp}, do-or-die defenders, attack increase 30% and defense increase 50%");
            }
        }
    }

    public class UnableState : State
    {
        public void Move(Warrior warrior)
        {
            Console.WriteLine($"HP = {warrior.HP}, could not fight!");
        }
    }
}
