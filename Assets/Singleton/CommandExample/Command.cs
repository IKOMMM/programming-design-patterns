using UnityEngine;
using Singleton;

namespace Singleton.CommandExample
{
    public interface ICommand
    {
        void Execute();
    }

    public class SpellCommand : ICommand 
    { 
        public void Execute() 
        {
            Debug.Log("Spell Command Executed");
        }
    }

    public class ItemCommand : ICommand
    {
        public void Execute()
        {
            Debug.Log("Item Command Executed");
        }
    }

    public class NullCommand : ICommand
    {
        public void Execute()
        {
            Debug.Log("Nothing");
        }
    }
}


