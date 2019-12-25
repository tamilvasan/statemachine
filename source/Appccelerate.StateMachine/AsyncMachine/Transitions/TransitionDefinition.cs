//-------------------------------------------------------------------------------
// <copyright file="TransitionDefinition.cs" company="Appccelerate">
//   Copyright (c) 2008-2019 Appccelerate
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Appccelerate.StateMachine.AsyncMachine.Transitions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using ActionHolders;
    using GuardHolders;
    using States;

    public class TransitionDefinition<TState, TEvent> : ITransitionDefinition<TState, TEvent>
        where TState : IComparable
        where TEvent : IComparable
    {
        public TransitionDefinition(
            IStateDefinition<TState, TEvent> source,
            TEvent @event,
            IStateDefinition<TState, TEvent>? target,
            IGuardHolder? guard,
            IEnumerable<IActionHolder> actions)
        {
            this.Source = source;
            this.Event = @event;
            this.Target = target;
            this.Guard = guard;
            this.Actions = actions;
        }

        public IStateDefinition<TState, TEvent> Source { get; set; }

        public TEvent Event { get; }

        public IStateDefinition<TState, TEvent>? Target { get; }

        public IGuardHolder? Guard { get; }

        public IEnumerable<IActionHolder> Actions { get; }

        public bool IsInternalTransition => this.Target == null;

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Transition from state {0} to state {1}.", this.Source, this.Target);
        }
    }
}