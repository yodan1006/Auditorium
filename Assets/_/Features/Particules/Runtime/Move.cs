using System;
using UnityEngine;

namespace Particules.Runtime
{
    public class Move : MonoBehaviour
    {
        #region publics
        
        
        #endregion


        #region Unity API

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            Vector2 initialDirection = transform.right.normalized;
            _rigidbody2D.AddForce(initialDirection * _speed, ForceMode2D.Impulse);
        }

        private void Update()
        {
            //_rigidbody2D.AddForce(transform.right * _speed, ForceMode2D.Force);
            //transform.position += transform.right * _speed * Time.deltaTime;
        }

        #endregion
        
        
        #region Utils
        
        #endregion
        
        
        #region Main functions

        
        
        #endregion


        #region private

        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody2D;

        #endregion
    }
}
