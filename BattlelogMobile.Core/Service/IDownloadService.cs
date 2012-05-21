namespace BattlelogMobile.Core.Service
{
    public interface IDownloadService
    {
        void ResolveUserIdAndPlatform(string url, IUserIdAndPlatformResolver userIdAndPlatformUserIdAndPlatformResolver);
        void GetFile(string url, string isolatedStorageFile);
    }
}