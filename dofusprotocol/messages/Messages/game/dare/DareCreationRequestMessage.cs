

// Generated on 02/17/2017 01:58:06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class DareCreationRequestMessage : Message
    {
        public const uint Id = 6665;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool isPrivate;
        public bool isForGuild;
        public bool isForAlliance;
        public bool needNotifications;
        public long subscriptionFee;
        public long jackpot;
        public short maxCountWinners;
        public uint delayBeforeStart;
        public uint duration;
        public IEnumerable<Types.DareCriteria> criterions;
        
        public DareCreationRequestMessage()
        {
        }
        
        public DareCreationRequestMessage(bool isPrivate, bool isForGuild, bool isForAlliance, bool needNotifications, long subscriptionFee, long jackpot, short maxCountWinners, uint delayBeforeStart, uint duration, IEnumerable<Types.DareCriteria> criterions)
        {
            this.isPrivate = isPrivate;
            this.isForGuild = isForGuild;
            this.isForAlliance = isForAlliance;
            this.needNotifications = needNotifications;
            this.subscriptionFee = subscriptionFee;
            this.jackpot = jackpot;
            this.maxCountWinners = maxCountWinners;
            this.delayBeforeStart = delayBeforeStart;
            this.duration = duration;
            this.criterions = criterions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, isPrivate);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isForGuild);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, isForAlliance);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, needNotifications);
            writer.WriteByte(flag1);
            writer.WriteVarLong(subscriptionFee);
            writer.WriteVarLong(jackpot);
            writer.WriteShort(maxCountWinners);
            writer.WriteUInt(delayBeforeStart);
            writer.WriteUInt(duration);
            var criterions_before = writer.Position;
            var criterions_count = 0;
            writer.WriteShort(0);
            foreach (var entry in criterions)
            {
                 entry.Serialize(writer);
                 criterions_count++;
            }
            var criterions_after = writer.Position;
            writer.Seek((int)criterions_before);
            writer.WriteShort((short)criterions_count);
            writer.Seek((int)criterions_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            isPrivate = BooleanByteWrapper.GetFlag(flag1, 0);
            isForGuild = BooleanByteWrapper.GetFlag(flag1, 1);
            isForAlliance = BooleanByteWrapper.GetFlag(flag1, 2);
            needNotifications = BooleanByteWrapper.GetFlag(flag1, 3);
            subscriptionFee = reader.ReadVarLong();
            if (subscriptionFee < 0 || subscriptionFee > 9007199254740990)
                throw new Exception("Forbidden value on subscriptionFee = " + subscriptionFee + ", it doesn't respect the following condition : subscriptionFee < 0 || subscriptionFee > 9007199254740990");
            jackpot = reader.ReadVarLong();
            if (jackpot < 0 || jackpot > 9007199254740990)
                throw new Exception("Forbidden value on jackpot = " + jackpot + ", it doesn't respect the following condition : jackpot < 0 || jackpot > 9007199254740990");
            maxCountWinners = reader.ReadShort();
            if (maxCountWinners < 0 || maxCountWinners > 65535)
                throw new Exception("Forbidden value on maxCountWinners = " + maxCountWinners + ", it doesn't respect the following condition : maxCountWinners < 0 || maxCountWinners > 65535");
            delayBeforeStart = reader.ReadUInt();
            if (delayBeforeStart < 0 || delayBeforeStart > 4294967295)
                throw new Exception("Forbidden value on delayBeforeStart = " + delayBeforeStart + ", it doesn't respect the following condition : delayBeforeStart < 0 || delayBeforeStart > 4294967295");
            duration = reader.ReadUInt();
            if (duration < 0 || duration > 4294967295)
                throw new Exception("Forbidden value on duration = " + duration + ", it doesn't respect the following condition : duration < 0 || duration > 4294967295");
            var limit = reader.ReadShort();
            var criterions_ = new Types.DareCriteria[limit];
            for (int i = 0; i < limit; i++)
            {
                 criterions_[i] = new Types.DareCriteria();
                 criterions_[i].Deserialize(reader);
            }
            criterions = criterions_;
        }
        
    }
    
}