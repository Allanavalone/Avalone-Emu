

// Generated on 02/17/2017 01:57:40
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class KohUpdateMessage : Message
    {
        public const uint Id = 6439;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.AllianceInformations> alliances;
        public IEnumerable<short> allianceNbMembers;
        public IEnumerable<int> allianceRoundWeigth;
        public IEnumerable<sbyte> allianceMatchScore;
        public Types.BasicAllianceInformations allianceMapWinner;
        public int allianceMapWinnerScore;
        public int allianceMapMyAllianceScore;
        public double nextTickTime;
        
        public KohUpdateMessage()
        {
        }
        
        public KohUpdateMessage(IEnumerable<Types.AllianceInformations> alliances, IEnumerable<short> allianceNbMembers, IEnumerable<int> allianceRoundWeigth, IEnumerable<sbyte> allianceMatchScore, Types.BasicAllianceInformations allianceMapWinner, int allianceMapWinnerScore, int allianceMapMyAllianceScore, double nextTickTime)
        {
            this.alliances = alliances;
            this.allianceNbMembers = allianceNbMembers;
            this.allianceRoundWeigth = allianceRoundWeigth;
            this.allianceMatchScore = allianceMatchScore;
            this.allianceMapWinner = allianceMapWinner;
            this.allianceMapWinnerScore = allianceMapWinnerScore;
            this.allianceMapMyAllianceScore = allianceMapMyAllianceScore;
            this.nextTickTime = nextTickTime;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var alliances_before = writer.Position;
            var alliances_count = 0;
            writer.WriteShort(0);
            foreach (var entry in alliances)
            {
                 entry.Serialize(writer);
                 alliances_count++;
            }
            var alliances_after = writer.Position;
            writer.Seek((int)alliances_before);
            writer.WriteShort((short)alliances_count);
            writer.Seek((int)alliances_after);

            var allianceNbMembers_before = writer.Position;
            var allianceNbMembers_count = 0;
            writer.WriteShort(0);
            foreach (var entry in allianceNbMembers)
            {
                 writer.WriteVarShort(entry);
                 allianceNbMembers_count++;
            }
            var allianceNbMembers_after = writer.Position;
            writer.Seek((int)allianceNbMembers_before);
            writer.WriteShort((short)allianceNbMembers_count);
            writer.Seek((int)allianceNbMembers_after);

            var allianceRoundWeigth_before = writer.Position;
            var allianceRoundWeigth_count = 0;
            writer.WriteShort(0);
            foreach (var entry in allianceRoundWeigth)
            {
                 writer.WriteVarInt(entry);
                 allianceRoundWeigth_count++;
            }
            var allianceRoundWeigth_after = writer.Position;
            writer.Seek((int)allianceRoundWeigth_before);
            writer.WriteShort((short)allianceRoundWeigth_count);
            writer.Seek((int)allianceRoundWeigth_after);

            var allianceMatchScore_before = writer.Position;
            var allianceMatchScore_count = 0;
            writer.WriteShort(0);
            foreach (var entry in allianceMatchScore)
            {
                 writer.WriteSByte(entry);
                 allianceMatchScore_count++;
            }
            var allianceMatchScore_after = writer.Position;
            writer.Seek((int)allianceMatchScore_before);
            writer.WriteShort((short)allianceMatchScore_count);
            writer.Seek((int)allianceMatchScore_after);

            allianceMapWinner.Serialize(writer);
            writer.WriteVarInt(allianceMapWinnerScore);
            writer.WriteVarInt(allianceMapMyAllianceScore);
            writer.WriteDouble(nextTickTime);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var alliances_ = new Types.AllianceInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 alliances_[i] = new Types.AllianceInformations();
                 alliances_[i].Deserialize(reader);
            }
            alliances = alliances_;
            limit = reader.ReadShort();
            var allianceNbMembers_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 allianceNbMembers_[i] = reader.ReadVarShort();
                 if (allianceNbMembers_[i] < 0)
                     throw new Exception("Forbidden value on allianceNbMembers_[i] = " + allianceNbMembers_[i] + ", it doesn't respect the following condition : allianceNbMembers_[i] < 0");
            }
            allianceNbMembers = allianceNbMembers_;
            limit = reader.ReadShort();
            var allianceRoundWeigth_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 allianceRoundWeigth_[i] = reader.ReadVarInt();
                 if (allianceRoundWeigth_[i] < 0)
                     throw new Exception("Forbidden value on allianceRoundWeigth_[i] = " + allianceRoundWeigth_[i] + ", it doesn't respect the following condition : allianceRoundWeigth_[i] < 0");
            }
            allianceRoundWeigth = allianceRoundWeigth_;
            limit = reader.ReadShort();
            var allianceMatchScore_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 allianceMatchScore_[i] = reader.ReadSByte();
                 if (allianceMatchScore_[i] < 0)
                     throw new Exception("Forbidden value on allianceMatchScore_[i] = " + allianceMatchScore_[i] + ", it doesn't respect the following condition : allianceMatchScore_[i] < 0");
            }
            allianceMatchScore = allianceMatchScore_;
            allianceMapWinner = new Types.BasicAllianceInformations();
            allianceMapWinner.Deserialize(reader);
            allianceMapWinnerScore = reader.ReadVarInt();
            if (allianceMapWinnerScore < 0)
                throw new Exception("Forbidden value on allianceMapWinnerScore = " + allianceMapWinnerScore + ", it doesn't respect the following condition : allianceMapWinnerScore < 0");
            allianceMapMyAllianceScore = reader.ReadVarInt();
            if (allianceMapMyAllianceScore < 0)
                throw new Exception("Forbidden value on allianceMapMyAllianceScore = " + allianceMapMyAllianceScore + ", it doesn't respect the following condition : allianceMapMyAllianceScore < 0");
            nextTickTime = reader.ReadDouble();
            if (nextTickTime < 0 || nextTickTime > 9007199254740990)
                throw new Exception("Forbidden value on nextTickTime = " + nextTickTime + ", it doesn't respect the following condition : nextTickTime < 0 || nextTickTime > 9007199254740990");
        }
        
    }
    
}