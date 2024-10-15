using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace Core.Services.PlatformInfo
{
    public class MockPlatformInfoProvider : IPlatformInfoProvider
    {
        public DeviceType GetDeviceType() =>
            Application.platform switch
            {
                RuntimePlatform.Android => DeviceType.Mobile,
                RuntimePlatform.IPhonePlayer => DeviceType.Mobile,
                RuntimePlatform.WindowsPlayer => DeviceType.Desktop,
                _ => DeviceType.Desktop
            };
    }
}