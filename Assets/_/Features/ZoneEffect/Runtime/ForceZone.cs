using UnityEngine;

namespace ZoneEffect.Runtime
{
    public class ForceZone : MonoBehaviour
    {
        #region publics
        
        
        #endregion


        #region Unity API

        private void OnTriggerStay2D(Collider2D other2D)
        {
            Rigidbody2D rb = other2D.attachedRigidbody;
            float maxSpeed = 5f;
            if (rb != null)
            {
                Vector2 direction = _directionTransform.up;
                rb.AddForce(direction * _forceMagnitude, ForceMode2D.Force);
                if (rb.linearVelocity.magnitude > maxSpeed)
                {
                    rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
                }
            }
        }

        #endregion
        
        
        #region Utils

        public void SetMagnitude(float value)
        {
            _forceMagnitude = value;
        }
        
        #endregion
        
        
        #region Main functions

        
        
        #endregion


        #region private
        
        [SerializeField] float _forceMagnitude = 5f;
        [SerializeField] Transform _directionTransform;

        #endregion
    }
}
