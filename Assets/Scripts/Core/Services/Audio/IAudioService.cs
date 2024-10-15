namespace Core.Services.Audio {
    public interface IAudioService {
        void PlayMusic(bool isGame);
        void PlaySoundByType(SoundType soundType);
    }
}