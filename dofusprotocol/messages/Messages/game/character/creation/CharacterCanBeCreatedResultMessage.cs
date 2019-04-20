﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class CharacterCanBeCreatedResultMessage : Message
    {
        public const uint Id = 6733;
        public override uint MessageId
        {
            get { return Id; }
        }

        public bool yesYouCan;

        public CharacterCanBeCreatedResultMessage()
        {
        }

        public CharacterCanBeCreatedResultMessage(bool yesYouCan = false)
        {
            this.yesYouCan = yesYouCan;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(this.yesYouCan);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.yesYouCan = reader.ReadBoolean();
        }

    }

}