using UnityEngine;

namespace ScriptableObjectCreators
{
    [CreateAssetMenu(fileName = "new PlayerStateSetter", menuName = "PlayerStatSetter")]   
    public class PlayerState : ScriptableObject
    {
        [TextArea]
        public string emotionalState;

        public Mesh model;
        
        public Material material;
        
        public Vector3 scale = Vector3.one;
    }
}
