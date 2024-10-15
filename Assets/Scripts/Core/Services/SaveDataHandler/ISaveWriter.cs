using Data;

namespace Core.Services.SaveDataHandler
{
    public interface ISaveWriter
    {
        void WriteSave(SaveData saveData);
    }
}