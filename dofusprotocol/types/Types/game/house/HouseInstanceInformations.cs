using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class HouseInstanceInformations
    {
        public const short Id = 511;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int instanceId;
        public bool secondHand;
        public bool isLocked;
        public string ownerName;
        public long price;
        public bool isSaleLocked;

        public HouseInstanceInformations()
        {
        }
        
        public HouseInstanceInformations(int instanceId, bool secondHand, bool isLocked, string ownerName, long price, bool isSaleLocked)
        {
            this.instanceId = instanceId;
            this.secondHand = secondHand;
            this.isLocked = isLocked;
            this.ownerName = ownerName;
            this.price = price;
            this.isSaleLocked = isSaleLocked;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, secondHand);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, isLocked);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, isSaleLocked);
            writer.WriteByte(flag1);
            writer.WriteInt(instanceId);
            writer.WriteUTF(ownerName);
            writer.WriteVarLong(price);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            byte flag1 = reader.ReadByte();
            secondHand = BooleanByteWrapper.GetFlag(flag1, 0);
            isLocked = BooleanByteWrapper.GetFlag(flag1, 1);
            isSaleLocked = BooleanByteWrapper.GetFlag(flag1, 2);
            instanceId = reader.ReadInt();
            if (instanceId < 0)
                throw new Exception("Forbidden value on instanceId = " + instanceId + ", it doesn't respect the following condition : instanceId < 0");
            ownerName = reader.ReadUTF();
            price = reader.ReadVarLong();
            if (this.price < -9007199254740992 || this.price > 9007199254740992)
                throw new Exception("Forbidden value on price = " + price + ", it doesn't respect the following condition : price < -9007199254740992 || price > 9007199254740992");

        }
    }
}