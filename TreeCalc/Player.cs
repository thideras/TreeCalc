using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeCalc.Interfaces;

using log4net;
using System.Reflection;

namespace TreeCalc
{
    public class Player
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string Name { get; private set; }

        public Player(string playerName)
        {
            Name = playerName;

            _log.Debug($"Added player {playerName}");
        }
    }
}