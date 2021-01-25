using ScriptableObjectCreators;

namespace Player
{
    public interface IPlayerStateSetter
    {
        void ResetStateToDefault();

        void SetState(PlayerState state);
    }
}