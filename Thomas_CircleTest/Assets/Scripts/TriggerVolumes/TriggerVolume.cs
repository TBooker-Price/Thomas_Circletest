using Player;
using ScriptableObjectCreators;
using UnityEngine;

namespace TriggerVolumes
{
    public class TriggerVolume : MonoBehaviour
    {
        public PlayerState state;
        
        private void OnTriggerEnter(Collider other)
        {
            var playerStateController = other.GetComponent<IPlayerStateSetter>();
            playerStateController?.SetState(state);
        }
        
        private void OnTriggerExit(Collider other)
        {
            var playerState = other.GetComponent<IPlayerStateSetter>();
            playerState?.ResetStateToDefault();
        }
    }
}
