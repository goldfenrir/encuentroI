using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    class StateMachine
    {
        private Stack<State> stackSM = new Stack<State>();

        public StateMachine()
        {
        }

        public void AddState(State state)
        {
            stackSM.Push(state);
        }

        public State PopState()
        {
            return stackSM.Pop();
        }

        public State PeekState()
        {
            return stackSM.Peek();
        }

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

        public Stack<State> getState()
        {
            return stackSM;
        }

        public void setState(Stack<State> stackSM)
        {
            this.stackSM = stackSM;
        }
    }
}
