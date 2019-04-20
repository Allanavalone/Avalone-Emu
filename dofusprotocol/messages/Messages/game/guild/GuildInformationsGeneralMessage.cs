

// Generated on 02/17/2017 01:58:09
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GuildInformationsGeneralMessage : Message
    {
        public const uint Id = 5557;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool abandonnedPaddock;
        public sbyte level;
        public long expLevelFloor;
        public long experience;
        public long expNextLevelFloor;
        public int creationDate;
        public short nbTotalMembers;
        public short nbConnectedMembers;
        
        public GuildInformationsGeneralMessage()
        {
        }
        
        public GuildInformationsGeneralMessage(bool abandonnedPaddock, sbyte level, long expLevelFloor, long experience, long expNextLevelFloor, int creationDate, short nbTotalMembers, short nbConnectedMembers)
        {
            this.abandonnedPaddock = abandonnedPaddock;
            this.level = level;
            this.expLevelFloor = expLevelFloor;
            this.experience = experience;
            this.expNextLevelFloor = expNextLevelFloor;
            this.creationDate = creationDate;
            this.nbTotalMembers = nbTotalMembers;
            this.nbConnectedMembers = nbConnectedMembers;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(abandonnedPaddock);
            writer.WriteSByte(level);
            writer.WriteVarLong(expLevelFloor);
            writer.WriteVarLong(experience);
            writer.WriteVarLong(expNextLevelFloor);
            writer.WriteInt(creationDate);
            writer.WriteVarShort(nbTotalMembers);
            writer.WriteVarShort(nbConnectedMembers);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            abandonnedPaddock = reader.ReadBoolean();
            level = reader.ReadSByte();
            if (level < 0 || level > 255)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 255");
            expLevelFloor = reader.ReadVarLong();
            if (expLevelFloor < 0 || expLevelFloor > 9007199254740990)
                throw new Exception("Forbidden value on expLevelFloor = " + expLevelFloor + ", it doesn't respect the following condition : expLevelFloor < 0 || expLevelFloor > 9007199254740990");
            experience = reader.ReadVarLong();
            if (experience < 0 || experience > 9007199254740990)
                throw new Exception("Forbidden value on experience = " + experience + ", it doesn't respect the following condition : experience < 0 || experience > 9007199254740990");
            expNextLevelFloor = reader.ReadVarLong();
            if (expNextLevelFloor < 0 || expNextLevelFloor > 9007199254740990)
                throw new Exception("Forbidden value on expNextLevelFloor = " + expNextLevelFloor + ", it doesn't respect the following condition : expNextLevelFloor < 0 || expNextLevelFloor > 9007199254740990");
            creationDate = reader.ReadInt();
            if (creationDate < 0)
                throw new Exception("Forbidden value on creationDate = " + creationDate + ", it doesn't respect the following condition : creationDate < 0");
            nbTotalMembers = reader.ReadVarShort();
            if (nbTotalMembers < 0)
                throw new Exception("Forbidden value on nbTotalMembers = " + nbTotalMembers + ", it doesn't respect the following condition : nbTotalMembers < 0");
            nbConnectedMembers = reader.ReadVarShort();
            if (nbConnectedMembers < 0)
                throw new Exception("Forbidden value on nbConnectedMembers = " + nbConnectedMembers + ", it doesn't respect the following condition : nbConnectedMembers < 0");
        }
        
    }
    
}