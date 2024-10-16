using Core.Services.Audio;
using UnityEngine;
using VContainer;

namespace Game.Player
{
    public class PlayerAudio
    {
        private readonly IAudioService _audioService;
        private readonly PointsController _pointsController;
        private readonly WinLoseController _winLoseController;

        [Inject]
        public PlayerAudio(IAudioService audioService, PointsController pointsController, WinLoseController winLoseController)
        {
            _audioService = audioService;
            _pointsController = pointsController;
            _winLoseController = winLoseController;
        }

        public void Init()
        {
            _pointsController.OnPointsAdd += PlayAddPointsSound;
            _pointsController.OnPointsTake += PlayTakePointsSound;
            _winLoseController.OnPlayerLose += PlayLoseSound;
            _winLoseController.OnPlayerWin += PlayWinSound;
        }

        private void PlayAddPointsSound(int points)
        {
            _audioService.PlaySoundByType(SoundType.AddPoints);
        }
        
        private void PlayTakePointsSound(int points)
        {
            _audioService.PlaySoundByType(SoundType.TakePoints);
        }

        private void PlayLoseSound()
        {
            _audioService.PlaySoundByType(SoundType.Lose);
        }

        private void PlayWinSound()
        {
            _audioService.PlaySoundByType(SoundType.Win);
        }
    }
}
