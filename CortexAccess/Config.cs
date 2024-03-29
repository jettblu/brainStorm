﻿

namespace BrainStorm.CortexAccess
{
    static class Config
    {
        /*
         * To get a client id and a client secret, you must connect to your Emotiv
         * account on emotiv.com and create a Cortex app.
         * https://www.emotiv.com/my-account/cortex-apps/
         */
        public static string AppClientId = Properties.Settings.Default.EmotivID;
        public static string AppClientSecret = Properties.Settings.Default.EmotivSecret;

    }

    public static class WarningCode
    {
        public const int StreamStop = 0;
        public const int SessionAutoClosed = 1;
        public const int UserLogin = 2;
        public const int UserLogout = 3;
        public const int ExtenderExportSuccess = 4;
        public const int ExtenderExportFailed = 5;
        public const int UserNotAcceptLicense = 6;
        public const int UserNotHaveAccessRight = 7;
        public const int UserRequestAccessRight = 8;
        public const int AccessRightGranted = 9;
        public const int AccessRightRejected = 10;
        public const int CannotDetectOSUSerInfo = 11;
        public const int CannotDetectOSUSername = 12;
        public const int ProfileLoaded = 13;
        public const int ProfileUnloaded = 14;
        public const int CortexAutoUnloadProfile = 15;
        public const int UserLoginOnAnotherOsUser = 16;
        public const int EULAAccepted = 17;
        public const int StreamWritingClosed = 18;
        public const int HeadsetConnected = 104;
    }
}
