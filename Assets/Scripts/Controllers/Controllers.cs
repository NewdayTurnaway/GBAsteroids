using System.Collections.Generic;

namespace GBAsteroids
{
    internal sealed class Controllers : IInitialization, IExecute
    {
        private readonly List<IInitialization> _initializationControllers;
        private readonly List<IExecute> _executeControllers;

        internal Controllers()
        {
            _initializationControllers = new();
            _executeControllers = new();
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IInitialization initializationControllers)
            {
                _initializationControllers.Add(initializationControllers);
            }
            if (controller is IExecute executeControllers)
            {
                _executeControllers.Add(executeControllers);
            }

            return this;
        }
        public void Initialization()
        {
            for (int i = 0; i < _initializationControllers.Count; i++)
            {
                _initializationControllers[i].Initialization();
            }
        }

        public void Execute()
        {
            for (int i = 0; i < _executeControllers.Count; i++)
            {
                _executeControllers[i].Execute();
            }
        }

    }
}