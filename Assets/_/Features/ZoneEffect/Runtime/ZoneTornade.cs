using System;
using UnityEngine;

namespace ZoneEffect.Runtime
{
    public class ZoneTornade : MonoBehaviour
    {
        #region Publics

        

        #endregion


        #region Unity Api

        private void Start()
        {
            zoneModulable  = GetComponent<ZoneModulable>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 lol = (Vector2)transform.position - rb.position;
                Vector2 tangabtial = Vector2.Perpendicular(lol).normalized;
                
                Vector2 force = lol.normalized * _pullForce + tangabtial * _rotateForce ;
                rb.AddForce(force);
            }
        }

        #endregion


        #region Utils

        

        #endregion


        #region Main Methode

        

        #endregion
        
        
        #region Privates
        
        private ZoneModulable zoneModulable;
        [SerializeField]private float _pullForce;
        [SerializeField]private float _rotateForce;

        #endregion
    }
}
