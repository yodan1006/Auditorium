using UnityEngine;

namespace ZoneEffect.Runtime
{
    public class ZoneAudio : MonoBehaviour
    {
        #region publics
        
        
        #endregion


        #region Unity API

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = 0;
            _audioSource.loop = true;
            _audioSource.playOnAwake = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _particuleInside++;
            UpdateAudio();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _particuleInside = Mathf.Max(0, _particuleInside - 1);
            UpdateAudio();
        }

        private void Update()
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume,Time.deltaTime * _fadeSpeed);
            
            if (_targetVolume >0f && !_audioSource.isPlaying) _audioSource.Play();
            else if (Mathf.Approximately(_targetVolume, 0f) && _audioSource.volume <= 0.01f && _audioSource.isPlaying) _audioSource.Stop();
            TargetScale();
        }

        #endregion
        
        
        #region Utils
        
        #endregion
        
        
        #region Main functions

        private void UpdateAudio()
        {
            _targetVolume = Mathf.Clamp(_particuleInside * _volumePerParticules, 0f, _maxVolume);
        }
        
        private void TargetScale()
        {
            float targetScale = _baseScale + (_targetVolume * _scaleMultiplier);
            float currentScale = _visualTarget.localScale.x;
            float newScale = Mathf.MoveTowards(currentScale, targetScale, Time.deltaTime * _speedScale);
            _visualTarget.localScale = new Vector3(newScale, newScale, 1f);
        }
        
        #endregion


        #region private

        [SerializeField] private Transform _visualTarget;
        [SerializeField] private float _baseScale = 1f;
        [SerializeField] private float _scaleMultiplier = 0.5f;
        [SerializeField] private float _speedScale = 5f;
        
        [SerializeField] private float _volumePerParticules = 0.1f;
        [SerializeField] private float _maxVolume = 1f;
        [SerializeField] private float _fadeSpeed = 1f;
        
        private AudioSource _audioSource;
        private int _particuleInside = 0;
        private float _targetVolume = 0f;

        #endregion
    }
}
