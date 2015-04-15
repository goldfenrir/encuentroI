using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    class StateMachine
    {
        private Stack<Object> stackSM = new Stack<Object>();

        public void udpate()
        { //falta el argumento elapsedTime, cual es el tipo? -> GF:double

        }

        public void render()
        {

        }

        public void add(State state)
        {

        }

        public void pull()
        {

        }

        public Stack<Object> getState()
        {
            return stackSM;
        }

        public void setState(Stack<Object> stackSM)
        {
            this.stackSM = stackSM;
        }
    }
}
