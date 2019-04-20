

// Generated on 02/17/2017 01:57:52
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MapComplementaryInformationsDataMessage : Message
    {
        public const uint Id = 226;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short subAreaId;
        public int mapId;
        public IEnumerable<HouseInformations> houses;
        public IEnumerable<GameRolePlayActorInformations> actors;
        public IEnumerable<InteractiveElement> interactiveElements;
        public IEnumerable<Types.StatedElement> statedElements;
        public IEnumerable<Types.MapObstacle> obstacles;
        public IEnumerable<Types.FightCommonInformations> fights;
        public bool hasAggressiveMonsters;
        public Types.FightStartingPositions fightStartPositions;
        
        public MapComplementaryInformationsDataMessage()
        {
        }
        
        public MapComplementaryInformationsDataMessage(short subAreaId, int mapId, IEnumerable<HouseInformations> houses, IEnumerable<GameRolePlayActorInformations> actors, IEnumerable<InteractiveElement> interactiveElements, IEnumerable<Types.StatedElement> statedElements, IEnumerable<Types.MapObstacle> obstacles, IEnumerable<Types.FightCommonInformations> fights, bool hasAggressiveMonsters, Types.FightStartingPositions fightStartPositions)
        {
            this.subAreaId = subAreaId;
            this.mapId = mapId;
            this.houses = houses;
            this.actors = actors;
            this.interactiveElements = interactiveElements;
            this.statedElements = statedElements;
            this.obstacles = obstacles;
            this.fights = fights;
            this.hasAggressiveMonsters = hasAggressiveMonsters;
            this.fightStartPositions = fightStartPositions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(subAreaId);
            writer.WriteInt(mapId);
            var houses_before = writer.Position;
            var houses_count = 0;
            writer.WriteShort(0);
            foreach (var entry in houses)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 houses_count++;
            }
            var houses_after = writer.Position;
            writer.Seek((int)houses_before);
            writer.WriteShort((short)houses_count);
            writer.Seek((int)houses_after);

            var actors_before = writer.Position;
            var actors_count = 0;
            writer.WriteShort(0);
            foreach (var entry in actors)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 actors_count++;
            }
            var actors_after = writer.Position;
            writer.Seek((int)actors_before);
            writer.WriteShort((short)actors_count);
            writer.Seek((int)actors_after);

            var interactiveElements_before = writer.Position;
            var interactiveElements_count = 0;
            writer.WriteShort(0);
            foreach (var entry in interactiveElements)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 interactiveElements_count++;
            }
            var interactiveElements_after = writer.Position;
            writer.Seek((int)interactiveElements_before);
            writer.WriteShort((short)interactiveElements_count);
            writer.Seek((int)interactiveElements_after);

            var statedElements_before = writer.Position;
            var statedElements_count = 0;
            writer.WriteShort(0);
            foreach (var entry in statedElements)
            {
                 entry.Serialize(writer);
                 statedElements_count++;
            }
            var statedElements_after = writer.Position;
            writer.Seek((int)statedElements_before);
            writer.WriteShort((short)statedElements_count);
            writer.Seek((int)statedElements_after);

            var obstacles_before = writer.Position;
            var obstacles_count = 0;
            writer.WriteShort(0);
            foreach (var entry in obstacles)
            {
                 entry.Serialize(writer);
                 obstacles_count++;
            }
            var obstacles_after = writer.Position;
            writer.Seek((int)obstacles_before);
            writer.WriteShort((short)obstacles_count);
            writer.Seek((int)obstacles_after);

            var fights_before = writer.Position;
            var fights_count = 0;
            writer.WriteShort(0);
            foreach (var entry in fights)
            {
                 entry.Serialize(writer);
                 fights_count++;
            }
            var fights_after = writer.Position;
            writer.Seek((int)fights_before);
            writer.WriteShort((short)fights_count);
            writer.Seek((int)fights_after);

            writer.WriteBoolean(hasAggressiveMonsters);
            fightStartPositions.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            subAreaId = reader.ReadVarShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
            var limit = reader.ReadShort();
            var houses_ = new HouseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 houses_[i] = Types.ProtocolTypeManager.GetInstance<HouseInformations>(reader.ReadShort());
                 houses_[i].Deserialize(reader);
            }
            houses = houses_;
            limit = reader.ReadShort();
            var actors_ = new GameRolePlayActorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 actors_[i] = Types.ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
                 actors_[i].Deserialize(reader);
            }
            actors = actors_;
            limit = reader.ReadShort();
            var interactiveElements_ = new InteractiveElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 interactiveElements_[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadShort());
                 interactiveElements_[i].Deserialize(reader);
            }
            interactiveElements = interactiveElements_;
            limit = reader.ReadShort();
            var statedElements_ = new Types.StatedElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 statedElements_[i] = new Types.StatedElement();
                 statedElements_[i].Deserialize(reader);
            }
            statedElements = statedElements_;
            limit = reader.ReadShort();
            var obstacles_ = new Types.MapObstacle[limit];
            for (int i = 0; i < limit; i++)
            {
                 obstacles_[i] = new Types.MapObstacle();
                 obstacles_[i].Deserialize(reader);
            }
            obstacles = obstacles_;
            limit = reader.ReadShort();
            var fights_ = new Types.FightCommonInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fights_[i] = new Types.FightCommonInformations();
                 fights_[i].Deserialize(reader);
            }
            fights = fights_;
            hasAggressiveMonsters = reader.ReadBoolean();
            fightStartPositions = new Types.FightStartingPositions();
            fightStartPositions.Deserialize(reader);
        }
        
    }
    
}