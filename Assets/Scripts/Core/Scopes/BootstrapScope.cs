﻿using Configs;
using Core.SceneManagement;
using Core.Services.Audio;
using Core.Services.GameFactory;
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

        [SerializeField] private CoroutineRunner coroutineRunner;
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
            builder.Register<SceneLoader>(Lifetime.Singleton);
            builder.Register<StateMachine.StateMachine>(Lifetime.Singleton);
            builder.Register<GameFactory>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register(_ => coroutineRunner, Lifetime.Singleton).AsImplementedInterfaces();
            
            DontDestroyOnLoad(gameObject);
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