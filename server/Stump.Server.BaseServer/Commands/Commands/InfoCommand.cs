using System;
using Stump.DofusProtocol.Enums;

namespace Stump.Server.BaseServer.Commands.Commands
{
    public class InfoCommand : SubCommandContainer
    {
        public InfoCommand()
        {
            Aliases = new[] { "info" };
            RequiredRole = RoleEnum.Moderator;
            Description = "Donne des informations sur le serveur";
        }

        public override void Execute(TriggerBase trigger)
        {
            if (trigger.Args.HasNext)
                base.Execute(trigger);
            else
                trigger.Reply("Temps sur Avalone : " + trigger.Bold("{0}") + "<br/> Joueurs en ligne sur Avalone: " + trigger.Bold("{1}"), ServerBase.InstanceAsBase.UpTime.ToString(@"dd\.hh\:mm\:ss"), ServerBase.InstanceAsBase.ClientManager.Count);
        }
    }
}