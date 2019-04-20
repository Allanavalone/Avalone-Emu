

// Generated on 02/17/2017 01:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class PartyGuestInformations
    {
        public const short Id = 374;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public long guestId;
        public long hostId;
        public string name;
        public Types.EntityLook guestLook;
        public sbyte breed;
        public bool sex;
        public PlayerStatus status;
        public IEnumerable<Types.PartyCompanionBaseInformations> companions;
        
        public PartyGuestInformations()
        {
        }
        
        public PartyGuestInformations(long guestId, long hostId, string name, Types.EntityLook guestLook, sbyte breed, bool sex, PlayerStatus status, IEnumerable<Types.PartyCompanionBaseInformations> companions)
        {
            this.guestId = guestId;
            this.hostId = hostId;
            this.name = name;
            this.guestLook = guestLook;
            this.breed = breed;
            this.sex = sex;
            this.status = status;
            this.companions = companions;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(guestId);
            writer.WriteVarLong(hostId);
            writer.WriteUTF(name);
            guestLook.Serialize(writer);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
            writer.WriteShort(status.TypeId);
            status.Serialize(writer);
            var companions_before = writer.Position;
            var companions_count = 0;
            writer.WriteShort(0);
            foreach (var entry in companions)
            {
                 entry.Serialize(writer);
                 companions_count++;
            }
            var companions_after = writer.Position;
            writer.Seek((int)companions_before);
            writer.WriteShort((short)companions_count);
            writer.Seek((int)companions_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            guestId = reader.ReadVarLong();
            if (guestId < 0 || guestId > 9007199254740990)
                throw new Exception("Forbidden value on guestId = " + guestId + ", it doesn't respect the following condition : guestId < 0 || guestId > 9007199254740990");
            hostId = reader.ReadVarLong();
            if (hostId < 0 || hostId > 9007199254740990)
                throw new Exception("Forbidden value on hostId = " + hostId + ", it doesn't respect the following condition : hostId < 0 || hostId > 9007199254740990");
            name = reader.ReadUTF();
            guestLook = new Types.EntityLook();
            guestLook.Deserialize(reader);
            breed = reader.ReadSByte();
            sex = reader.ReadBoolean();
            status = Types.ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
            status.Deserialize(reader);
            var limit = reader.ReadShort();
            var companions_ = new Types.PartyCompanionBaseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 companions_[i] = new Types.PartyCompanionBaseInformations();
                 companions_[i].Deserialize(reader);
            }
            companions = companions_;
        }
        
        
    }
    
}