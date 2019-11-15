namespace WelcomeMessage.Web.Api.Services
{
    public class MessageService : IMessageService
    {
        private const string OldValue = "Hello OLD";
        private const string NewValue = "Hello NEW";
        private const int VersionThreshold = 3;

        public string GetWelcomeMessage(int platformId, string platformType, int appVersion)
        {
            if (platformType == "SpecialDevice" && appVersion == 1 && (platformId == 1 || platformId == 2))
            {
                return OldValue;
            }

            var showNew = false;

            switch (platformId)
            {
                case 1:
                    showNew = true;
                    break;

                case 2:
                    showNew = true;
                    break;

                case 3:
                    return OldValue;

                case 4:
                    showNew = true;
                    break;
            }

            if (showNew)
            {
                if (appVersion < VersionThreshold)
                {
                    return OldValue;
                }
                else
                {
                    return NewValue;
                }
            }

            return null;
        }
    }

    public interface IMessageService
    {
        string GetWelcomeMessage(int platformId, string platformType, int appVersion);
    }
}
