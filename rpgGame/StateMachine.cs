using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace rpgGame
{
    [Serializable()]
    class StateMachine : ISerializable
    {
        private Stack<State> stackSM = new Stack<State>();

         public StateMachine(SerializationInfo info, StreamingContext ctxt)
        {
            stackSM = (Stack<State>)info.GetValue("StateMachineStack", typeof(Stack<State>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("StateMachineStack", stackSM);
        }

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
