using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public enum CharacterCreationResult
    {
        Ok,
        NoReason,
        InvalidName,
        NameAlreadyExists,
        TooManyCharacters,
        NotAllowed,
        NewPlayerNotAllowed,
        RestrictedZone,
        InconsistentCommunity
    }
}
