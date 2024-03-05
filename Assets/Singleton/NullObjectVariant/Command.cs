using UnityEngine;

namespace Singleton.NullObjectVariant
{
    /// <summary>
    /// Example basic command pattern
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }

    public abstract class Command : ICommand
    {
        public virtual void Execute()
        {
            Debug.Log("Command Executed " + GetType().Name);
        }
    }

    public class SpellCommand : Command { }

    public class ItemCommand : Command { }

    public class NullCommand : Command 
    {
        public override void Execute()
        {
            Debug.Log("Doing Nothing");
        }
    }

    public class CommandFactory: GenericVariant<CommandFactory> 
    {
        /// <summary>
        /// Pass type, makes new one, pass new one back
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Create<T>() where T: ICommand, new()
        {
            return new T();
        }
    }
}


