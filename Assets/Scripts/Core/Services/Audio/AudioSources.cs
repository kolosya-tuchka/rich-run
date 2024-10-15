using UnityEngine;

namespace Core.Services.Audio
{
    public class AudioSources
    {
        public AudioSource MusicSource, SoundSource;

        public AudioSources(AudioSource musicSource, AudioSource soundSource)
        {
            MusicSource = musicSource;
            SoundSource = soundSource;
        }
    }
}