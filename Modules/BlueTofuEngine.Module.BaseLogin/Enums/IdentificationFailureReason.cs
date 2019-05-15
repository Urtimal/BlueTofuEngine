using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    public enum IdentificationFailureReason
    {
        BadVersion = 1,
        WrongCredentials,
        Banned,
        Kicked,
        InMaintenance,
        TooManyOnIp,
        TimeOut,
        BadIpRange,
        CredentialsReset,
        EmailUnvalidated,
        OtpTimeout,
        Locked,
        ServiceUnavailable = 53,
        ExternalAccountLinkRefused = 61,
        ExternalAccountAlreadyLinked = 62,
        UnknownAuthError = 99
    }
}
