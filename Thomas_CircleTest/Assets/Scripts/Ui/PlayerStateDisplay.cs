using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    [RequireComponent(typeof(Text))]
    public class PlayerStateDisplay : MonoBehaviour
    {
        [SerializeField] private Text textbox;
        
        private void OnValidate() => textbox = GetComponent<Text>();

        private void Start()
        {
            PlayerStateManager.EmotionalStateChanged -= HandleEmotionalStateChanged; // Not strictly needed but good practice for static events.
            PlayerStateManager.EmotionalStateChanged += HandleEmotionalStateChanged;
        }

        private void HandleEmotionalStateChanged(object caller, string newState) => textbox.text = newState;
    }
}
