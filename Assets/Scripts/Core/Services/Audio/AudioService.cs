using Configs;
using Core.Services.SaveDataHandler;
using UnityEngine;
using VContainer;

namespace Core.Services.Audio
{
    public sealed class AudioService : IAudioService
    {
        private readonly AudioSource _musicSource;
        private readonly AudioSource _soundSource;

        private readonly AudioConfig _audioConfig;

        [Inject]
        public AudioService(GameConfigs gameConfigs, AudioSources audioSources)
        {
            _musicSource = audioSources.MusicSource;
            _soundSource = audioSources.SoundSource;
            _audioConfig = gameConfigs.AudioConfig;
        }

        public void PlayMusic(bool isGame)
        {
            _musicSource.clip = isGame ? _audioConfig.GameMusicClip : _audioConfig.MenuMusicClip;
            _musicSource.Play();
        }

        public void PlaySoundByType(SoundType soundType)
        {
            var audioClip = _audioConfig.GetSoundClipByName(soundType);

            if ( audioClip == null )
            {
                Debug.LogError($"There are no audio clip with {soundType} type");
            }

            _soundSource.PlayOneShot(audioClip);
        }
    }
}