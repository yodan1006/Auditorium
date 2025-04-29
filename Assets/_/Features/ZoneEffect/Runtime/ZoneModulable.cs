using System;
using UnityEngine;

namespace ZoneEffect.Runtime
{
    public class ZoneModulable : MonoBehaviour
    {
        #region publics
        
        
        #endregion


        #region Unity API

        private void Start()
        {
            _DragStartPosition = transform.localScale;
            _forceZone = GetComponent<ForceZone>();
        }

        private void Update()
        {
            if (_IsDragging) ModifiateScale();
        }
        private void OnMouseDown()
        {
            _IsDragging = true;
        }

        private void OnMouseUp()
        {
            _IsDragging = false;
        }

        #endregion
        
        
        #region Utils
        
        #endregion
        
        
        #region Main functions

        void ModifiateScale()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            
            float distance = Vector2.Distance(transform.position, mousePosition);
            float clamped = Mathf.Clamp(distance, _minRadius, _maxRadius);
            
            float scale = clamped;
            transform.localScale = new Vector3(scale, scale, 1f);

            if (_forceZone != null) _forceZone.SetMagnitude(clamped * _forceScale);
        }

        #endregion


        #region private

        [SerializeField] private float _minRadius = 1f;
        [SerializeField] private float _maxRadius = 5f;
        [SerializeField] private float _forceScale = 2f;
        
        private bool _IsDragging = false;
        private Vector2 _DragStartPosition;
        private ForceZone _forceZone;

        #endregion
    }
}
