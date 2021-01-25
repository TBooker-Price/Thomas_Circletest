using UnityEngine;

namespace Movement
{
    public class KeyboardMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;

        private void Update()
        {
            var leftRightValue = Input.GetAxis("Horizontal");
            var forwardBackValue = Input.GetAxis("Vertical");

            if (leftRightValue == 0 && forwardBackValue == 0) return;
            
            var movementDirection = new Vector3(leftRightValue, 0, forwardBackValue);
            var movementVector = movementDirection * (speed * Time.deltaTime);
            
            transform.Translate(movementVector);
        }
    }
}
