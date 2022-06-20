using CreativeVeinStudio.Simple_FSM.Scripts.Abstracts;

namespace CreativeVeinStudio.Simple_FSM.Scripts.Interfaces
{
    public interface IStateController<T>
    {
        IStateActions<T> ActiveState { get; set; }
        void ChangeState(IStateActions<T> state, bool takePriority);
    }
}