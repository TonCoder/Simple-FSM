using CreativeVeinStudio.Simple_FSM.Scripts.Enums;
using UnityEngine;

namespace CreativeVeinStudio.Simple_FSM.Scripts.Interfaces
{
    public interface IStateActions<TM>
    {
        // Properties
        EPriority Priority { get; }

        // Functions
        void EnterState(in TM state);

        void EnterState(in IStateController<TM> state);

        void ExitState(in TM state);
        
        void ExitState(in IStateController<TM> state);

        bool CanEnterState(in IStateActions<TM> state);

        void Tick(in IStateController<TM> state);

        void LateTick(in IStateController<TM> state);

        void CollisionEnter(in GameObject obj);
    }
}