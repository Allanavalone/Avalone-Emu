

// Generated on 02/17/2017 01:57:32
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class IdentificationMessage : Message
    {
        public const uint Id = 4;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool autoconnect;
        public bool useCertificate;
        public bool useLoginToken;
        public Types.VersionExtended version;
        public string lang;
        public IEnumerable<sbyte> credentials;
        public short serverId;
        public long sessionOptionalSalt;
        public IEnumerable<short> failedAttempts;
        
        public IdentificationMessage()
        {
        }
        
        public IdentificationMessage(bool autoconnect, bool useCertificate, bool useLoginToken, Types.VersionExtended version, string lang, IEnumerable<sbyte> credentials, short serverId, long sessionOptionalSalt, IEnumerable<short> failedAttempts)
        {
            this.autoconnect = autoconnect;
            this.useCertificate = useCertificate;
            this.useLoginToken = useLoginToken;
            this.version = version;
            this.lang = lang;
            this.credentials = credentials;
            this.serverId = serverId;
            this.sessionOptionalSalt = sessionOptionalSalt;
            this.failedAttempts = failedAttempts;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, autoconnect);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, useCertificate);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, useLoginToken);
            writer.WriteByte(flag1);
            version.Serialize(writer);
            writer.WriteUTF(lang);
            writer.WriteVarInt((int)credentials.Count());
            foreach (var entry in credentials)
            {
                 writer.WriteSByte(entry);
            }
            writer.WriteShort(serverId);
            writer.WriteVarLong(sessionOptionalSalt);
            var failedAttempts_before = writer.Position;
            var failedAttempts_count = 0;
            writer.WriteShort(0);
            foreach (var entry in failedAttempts)
            {
                 writer.WriteVarShort(entry);
                 failedAttempts_count++;
            }
            var failedAttempts_after = writer.Position;
            writer.Seek((int)failedAttempts_before);
            writer.WriteShort((short)failedAttempts_count);
            writer.Seek((int)failedAttempts_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            autoconnect = BooleanByteWrapper.GetFlag(flag1, 0);
            useCertificate = BooleanByteWrapper.GetFlag(flag1, 1);
            useLoginToken = BooleanByteWrapper.GetFlag(flag1, 2);
            version = new Types.VersionExtended();
            version.Deserialize(reader);
            lang = reader.ReadUTF();
            var limit = reader.ReadVarInt();
            var credentials_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 credentials_[i] = reader.ReadSByte();
            }
            credentials = credentials_;
            serverId = reader.ReadShort();
            sessionOptionalSalt = reader.ReadVarLong();
            if (sessionOptionalSalt < -9007199254740990 || sessionOptionalSalt > 9007199254740990)
                throw new Exception("Forbidden value on sessionOptionalSalt = " + sessionOptionalSalt + ", it doesn't respect the following condition : sessionOptionalSalt < -9007199254740990 || sessionOptionalSalt > 9007199254740990");
            limit = reader.ReadShort();
            var failedAttempts_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 failedAttempts_[i] = reader.ReadVarShort();
                 if (failedAttempts_[i] < 0)
                     throw new Exception("Forbidden value on failedAttempts_[i] = " + failedAttempts_[i] + ", it doesn't respect the following condition : failedAttempts_[i] < 0");
            }
            failedAttempts = failedAttempts_;
        }
        
    }
    
}