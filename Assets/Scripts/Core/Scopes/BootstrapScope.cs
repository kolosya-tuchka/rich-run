using Configs;
using Core.Services.Audio;
using Core.Services.Input;
using Core.Services.PlatformInfo;
using Core.Services.SaveDataHandler;
using Core.Services.SaveLoad;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using DeviceType = Core.Services.PlatformInfo.DeviceType;

namespace Core.Scopes
{
    public class BootstrapScope : LifetimeScope
    {
        [SerializeField] private GameConfigs gameConfigs;
        
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource soundSource;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register(_ => gameConfigs, Lifetime.Singleton);
            builder.Register<MockPlatformInfoProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register(container =>
            {
                var platformInfoProvider = container.Resolve<IPlatformInfoProvider>();
                return GetInputService(platformInfoProvider);
            }, Lifetime.Singleton);
            builder.Register<SaveDataHandler>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerPrefsJsonSaveLoadService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<AudioService>(Lifetime.Singleton).AsImplementedInterfaces()
                .WithParameter(_ => new AudioSources(musicSource, soundSource));
            
            builder.RegisterEntryPoint<GameStarter>();
        }
        
        private IInputService GetInputService(IPlatformInfoProvider platformInfoProvider)
        {
            var deviceType = platformInfoProvider.GetDeviceType();
            return deviceType switch
            {
                DeviceType.Desktop => new DesktopInputService(),
                DeviceType.Mobile => new MobileInputService(),
                _ => new MobileInputService()
            };
        }
    }
}