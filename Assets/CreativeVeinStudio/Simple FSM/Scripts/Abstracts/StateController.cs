using System;
using CreativeVeinStudio.Simple_FSM.Scripts.Interfaces;
using UnityEngine;

namespace CreativeVeinStudio.Simple_FSM.Scripts.Abstracts
{
    [System.Serializable]
    public abstract class StateController<T> : MonoBehaviour, IStateController<T>
    {
        public IStateActions<T> ActiveState { get; set; }

        private void OnDisable()
        {
            ActiveState = null;
        }

        protected virtual void Start()
        {
            ActiveState.EnterState(this);
        }

        protected virtual void Update()
        {
            ActiveState.Tick(this);
        }

        protected virtual void LateUpdate()
        {
            ActiveState.LateTick(this);
        }

        public void ChangeState(IStateActions<T> state, bool takePriority = false)
        {
            // tODO refactor 
            if (takePriority)
            {
                if (!ActiveState.CanEnterState(state)) return; // Check if we can enter the new state given
            }
            
            ActiveState.ExitState(this); // Finish the previous state's action
            ActiveState = state; // Assign new state
            ActiveState.EnterState(this); // Start the new state
        }
    }
}