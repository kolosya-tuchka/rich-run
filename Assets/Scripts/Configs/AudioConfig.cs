using System;
using System.Collections.Generic;
using Core.Services.Audio;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class SoundClipInfo
    {
        public SoundType SoundType;
        public AudioClip AudioClip;
    }

    [CreateAssetMenu(fileName = nameof(AudioConfig), menuName = "Configs/" + nameof(AudioConfig))]
    public class AudioConfig : ScriptableObject
    {
        public List<SoundClipInfo> SoundClipInfos;
        public AudioClip MenuMusicClip, GameMusicClip;

        public AudioClip GetSoundClipByName(SoundType soundType)
        {
            foreach (var soundClipInfo in SoundClipInfos)
            {
                if ( soundClipInfo.SoundType == soundType )
                {
                    return soundClipInfo.AudioClip;
                }
            }

            return null;
        }
    }
}