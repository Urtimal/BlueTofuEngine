using System;
using System.Collections.Generic;
using System.Text;
using BlueTofuEngine.Core;
using BlueTofuEngine.Core.Serialization;

namespace BlueTofuEngine.World.GameType.Character.Restriction
{
    public class ActorRestrictionsInformations : NetworkType
    {
        public ActorRestrictionsInformations()
        {
            ProtocolId = 204;
        }
        
        public override void Serialize(ICustomDataWriter writer)
        {
            var box0 = new ByteBox();
            box0[0] = false; // Cant be aggressed
            box0[1] = false; // Cant be challenged
            box0[2] = false; // Cant trade
            box0[3] = false; // Cant be attacked by mutant
            box0[4] = false; // Cant run
            box0[5] = false; // Force slow walk
            box0[6] = false; // Cant minimize
            box0[7] = false; // Cant move
            writer.WriteByte(box0.Value);

            var box1 = new ByteBox();
            box1[0] = false; // Cant aggress
            box1[1] = false; // Cant challenge
            box1[2] = false; // Cant exchange
            box1[3] = false; // Cant attack
            box1[4] = false; // Cant chat
            box1[5] = false; // Cant be merchant
            box1[6] = false; // cant use object
            box1[7] = false; // Cant use tax collector
            writer.WriteByte(box1.Value);

            var box2 = new ByteBox();
            box2[0] = false; // Cant use interactive
            box2[1] = false; // Cant speak to npc
            box2[2] = false; // Cant change zone
            box2[3] = false; // Cant attack monster
            box2[4] = false; // Cant walk 8 direction
            writer.WriteByte(box2.Value);
        }
    }
}
