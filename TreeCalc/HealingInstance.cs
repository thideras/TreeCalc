using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;
using System.Reflection;

namespace TreeCalc
{
    /// <summary>
    /// Contains a single group's healing instance, so multiple can be run in parallel
    /// </summary>
    public class HealingInstance
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private List<Player> players = new List<Player>();
        private readonly int id;

        public HealingInstance(int instanceId)
        {
            id = instanceId;
            _log.Debug($"Created HealingInstance id={id}");
        }

        ~HealingInstance()
        {
            _log.Debug($"Destroying HealingInstance id={id}");
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
            _log.Debug($"Group size: {players.Count}");
        }


    }
}