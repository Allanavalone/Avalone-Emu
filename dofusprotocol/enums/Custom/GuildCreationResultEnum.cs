﻿using System;
using System.Collections.Generic;

namespace Stump.DofusProtocol.Enums.Custom
{
    public enum GuildCreationResultEnum
    {
        GUILD_CREATE_OK = 1,
        GUILD_CREATE_ERROR_NAME_INVALID = 2,
        GUILD_CREATE_ERROR_ALREADY_IN_GUILD = 3,
        GUILD_CREATE_ERROR_NAME_ALREADY_EXISTS = 4,
        GUILD_CREATE_ERROR_EMBLEM_ALREADY_EXISTS = 5,
        GUILD_CREATE_ERROR_LEAVE = 6,
        GUILD_CREATE_ERROR_CANCEL = 7,
        GUILD_CREATE_ERROR_REQUIREMENT_UNMET = 8,
        GUILD_CREATE_ERROR_EMBLEM_INVALID = 9,
    }
}
