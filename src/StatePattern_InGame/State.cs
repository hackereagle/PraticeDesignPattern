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
                warrior.SetState(new );
                warrior.Move();
            }
        }
    }
}
