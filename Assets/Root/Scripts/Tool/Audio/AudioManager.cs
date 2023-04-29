using System;
using UnityEngine;

namespace PixelGame.Tool.Audio
{
    internal enum SFXAudioType
    {
        Game,
        Player,
        Enemy
    }

    internal class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [SerializeField] private AudioClip _warningSound;

        [SerializeField] private Sound[] _musicSounds;
        [SerializeField] private Sound[] _ambientSounds;
        [SerializeField] private Sound[] _gameSFXSounds;
        [SerializeField] private Sound[] _playerSFXSounds;
        [SerializeField] private Sound[] _enemySFXSounds;

        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _ambientSource;
        [SerializeField] private AudioSource _gameSFXSource;
        [SerializeField] private AudioSource _playerSFXSource;
        [SerializeField] private AudioSource _enemySFXSource;

        public AudioSource Music => _musicSource;
        public AudioSource Ambient => _ambientSource;
        public AudioSource GameSFX => _gameSFXSource;
        public AudioSource PlayerSFX => _playerSFXSource;
        public AudioSource EnemySFX => _enemySFXSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        public void PlayMusic(string name)
        {
            var audiClip = GetAudioClip(_musicSounds, name);
            _musicSource.clip = audiClip;
            _musicSource.Play();
        }

        public void PlayeAmbient(string name)
        {
            var audiClip = GetAudioClip(_ambientSounds, name);
            _ambientSource.clip = audiClip;
            _ambientSource.Play();
        }

        public void PlaySFX(SFXAudioType type, string name)
        {
            switch (type)
            {
                case SFXAudioType.Game:
                    {
                        var audiClip = GetAudioClip(_gameSFXSounds, name);
                        _gameSFXSource.clip = audiClip;
                        _gameSFXSource.Play();
                        break;
                    }
                case SFXAudioType.Player:
                    {
                        var audiClip = GetAudioClip(_playerSFXSounds, name);
                        _playerSFXSource.clip = audiClip;
                        _playerSFXSource.Play();
                        break;
                    }
                case SFXAudioType.Enemy:
                    {
                        var audiClip = GetAudioClip(_enemySFXSounds, name);
                        _enemySFXSource.clip = audiClip;
                        _enemySFXSource.Play();
                        break;
                    }
            }
        }

        private AudioClip GetAudioClip(Sound[] source, string name)
        {
            Sound sound = Array.Find(source, s => s.Name == name);
            if (sound != null) 
            {
                return sound.AudioClip;
            }
            else
            {
                Debug.Log($"Can't find {name} in audioManager!");
                return _warningSound;
            }
        }
    }
}
