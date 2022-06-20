using System;
using CreativeVeinStudio.Simple_FSM.Scripts.Enums;
using CreativeVeinStudio.Simple_FSM.Scripts.Interfaces;
using UnityEngine;

namespace CreativeVeinStudio.Simple_FSM.Scripts.Abstracts
{
    [System.Serializable]
    public abstract class AStateBase<T> : IStateActions<T>
    {
        public T StatesController { get; set; }

        protected AStateBase(EPriority priority)
        {
            this.Priority = priority;
        }

        [SerializeField] private EPriority priority;

        public EPriority Priority
        {
            get => priority;
            private set => priority = value;
        }

        public virtual void EnterState(in T state)
        {
            StatesController ??= state;
        }

        public virtual void EnterState(in IStateController<T> state)
        {
            EnterState((T) state);
        }

        public abstract void ExitState(in T state);

        public virtual void ExitState(in IStateController<T> state)
        {
            ExitState((T) state);
        }

        public virtual bool CanEnterState(in IStateActions<T> newState)
        {
            if (newState.Priority < this.Priority)
            {
#if UNITY_EDITOR
                Debug.LogWarning("Unable to enter ");
#endif
            }

            return newState.Priority >= this.Priority;
        }

        public abstract void Tick(in IStateController<T> state);

        public abstract void LateTick(in IStateController<T> state);

        public virtual void CollisionEnter(in GameObject obj)
        {
            // throw new NotImplementedException();
        }
    }

    [System.Serializable]
    public abstract class AStateMono<T> : MonoBehaviour, IStateActions<T>
    {
        protected T StatesController { get; private set; }

        [SerializeField] private EPriority priority;

        public EPriority Priority
        {
            get => priority;
            private set => priority = value;
        }

        public virtual void EnterState(in T state)
        {
            gameObject.SetActive(true);
            StatesController ??= state;
        }

        public virtual void EnterState(in IStateController<T> state)
        {
            EnterState((T) state);
        }

        public abstract void ExitState(in T state);

        public virtual void ExitState(in IStateController<T> state)
        {
            gameObject.SetActive(false);
            ExitState((T) state);
        }

        public virtual bool CanEnterState(in IStateActions<T> newState)
        {
            if (newState.Priority < this.Priority)
            {
#if UNITY_EDITOR
                Debug.LogWarning("Unable to enter ");
#endif
            }

            return newState.Priority >= this.Priority;
        }

        public abstract void Tick(in IStateController<T> state);

        public abstract void LateTick(in IStateController<T> state);

        public virtual void CollisionEnter(in GameObject obj)
        {
            // throw new NotImplementedException();
        }
    }
}