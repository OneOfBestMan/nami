using System;
using System.Collections.Generic;

namespace jIAnSoft.Framework.Nami.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Default executor.
    /// </summary>
    public class DefaultExecutor : IExecutor
    {
        private bool _running = true;

        /// <inheritdoc />
        /// <summary>
        /// Executes all actions.
        /// </summary>
        /// <param name="toExecute"></param>
        public void Execute(IEnumerable<Action> toExecute)
        {
            foreach (var action in toExecute)
            {
                Execute(action);
            }
        }

        /// <inheritdoc />
        /// <summary>
        ///  Executes a single action. 
        /// </summary>
        /// <param name="toExecute"></param>
        public void Execute(Action toExecute)
        {
            if (_running)
            {
                toExecute();
            }
        }

        /// <summary>
        /// When disabled, actions will be ignored by executor. The executor is typically disabled at shutdown
        /// to prevent any pending actions from being executed. 
        /// </summary>
        public bool IsEnabled
        {
            get => _running;
            set => _running = value;
        }
    }
}