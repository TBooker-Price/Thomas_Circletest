using System;
using ScriptableObjectCreators;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class PlayerStateManager : MonoBehaviour, IPlayerStateSetter
    {
        public static event EventHandler<string> EmotionalStateChanged;

        [SerializeField] private PlayerState defaultState;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private MeshFilter meshFilter;
        
        // Using a property is overkill (we don't really need to store the state etc.) but would probably make sense in a real game.
        private string _emotionalState; 
        private string EmotionalState
        {
            get => _emotionalState;
            set
            {
                _emotionalState = value;
                EmotionalStateChanged?.Invoke(this, value);
            }
        }

        private void OnValidate()
        {
            if (defaultState == null)
            {
                throw new MissingReferenceException(
                    $"{nameof(PlayerStateManager)} component is missing a default {nameof(PlayerState)} value for {nameof(defaultState)}.");
            }

            meshRenderer = GetComponent<MeshRenderer>();
            meshFilter = GetComponent<MeshFilter>();
        }

        private void Start() => ResetStateToDefault();

        public void ResetStateToDefault() => SetState(defaultState);

        public void SetState(PlayerState state)
        {
            if (state == null)
            {
                Debug.LogWarning($"Trying to set player state, but {nameof(PlayerState)} was null.");
                return;
            }
            
            SetEmotionalState(state.emotionalState);
            SetScale(state.scale);
            SetModel(state.model);
            SetMaterial(state.material);
        }
        
        private void SetEmotionalState(string emotionalState) => EmotionalState = emotionalState;

        private void SetScale(Vector3 scale) => transform.localScale = scale;
        
        private void SetMaterial(Material material)
        {
            if (material == default) return;
            meshRenderer.material = material;
        }

        private void SetModel(Mesh model)
        {
            if (model == default) return;
            meshFilter.mesh = model;
        }
    }
}
