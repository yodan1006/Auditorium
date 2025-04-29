using System;
using UnityEngine;

namespace MoveObject.Runtime
{
    public class DragAndDrop : MonoBehaviour
    {
        #region publics
        
        
        #endregion


        #region Unity API

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (_isDragging)
            {
                Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                transform.position = mousePosition + _offset;
            }
        }

        private void OnMouseDown()
        {
            Debug.Log("OnMouseDown déclenché");
            _isDragging = true;
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            _offset = transform.position - mousePosition;
        }

        private void OnMouseUp()
        {
            _isDragging = false;
        }

        #endregion
        
        
        #region Utils
        
        #endregion
        
        
        #region Main functions

        
        
        #endregion


        #region private

        private Vector3 _offset;
        private bool _isDragging = false;
        private Camera _mainCamera;

        #endregion
    }
}
