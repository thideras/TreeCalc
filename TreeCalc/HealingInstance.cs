using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;
using System.Reflection;
using TreeCalc.Interfaces;

namespace TreeCalc
{
    /// <summary>
    /// Contains a single group's healing instance, so multiple can be run in parallel
    /// </summary>
    public abstract class HealingInstance
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private List<Player> players = new List<Player>();
        private List<IEffect> effects = new List<IEffect>();
        private readonly int id;
        private readonly decimal endTime;
        private decimal currentTime;

        public HealingInstance(int instanceId, decimal instanceEndTime)
        {
            id = instanceId;
            currentTime = 0m;
            endTime = instanceEndTime;
            LogDebug($"Created HealingInstance");
        }

        ~HealingInstance()
        {
            LogDebug($"Destroying HealingInstance");
        }

        public bool IsRaid { get; private set; }

        public abstract void GcdLockedLogic();      //Logic to determine an action taken for Gcd locked abilities

        public abstract void NonGcLockedLogic();    //Logic to determine an action taken for non-Gcd locked abilities

        public void NextAction()
        {
            //This will eventually determine what the next action or calculation is, depending on the effect list, GCD, etc
            //Right now, this will be very simple

            var expiredEffects = effects.Where(e => e.ExpirationTime < currentTime).ToList();
            foreach(var effect in expiredEffects)
            {
                //Ending effect (lifebloom) should be added here

                LogDebug($"Removing effect {effect.Name}:{effect.Id} from player {effect.Player.Name}");
                effects.Remove(effect);
            }

            var nextTick = effects.Where(e => e is IHot)
                                  .Select(e => e as IHot)
                                  .OrderBy(e => e.NextTickTime)
                                  .FirstOrDefault();
            if (nextTick != null)
            {
                LogDebug($"{nextTick.Name} happened on player {nextTick.Player.Name}");
                currentTime = nextTick.NextTickTime;
                nextTick.NextTickTime += nextTick.BaseTickDuration;
                return;
            }

            LogError("No action to perform");

        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
            var playerCount = players.Count;
            IsRaid = (playerCount > 5);

            LogDebug($"Adding player '{player.Name}'");
            LogDebug($"Group size: {playerCount}; IsRaid: {IsRaid}");
        }

        public void AddEffect(IEffect effect)
        {
            //This will not be public later on and probably not even in this class

            effect.ExpirationTime = currentTime + 15m; //This will be set elsewhere
            //effect.NextTickTime = 3m; //This will be set elsewhere
            effects.Add(effect);
        }

        public void AddHot(IHot hot)
        {
            //This will not likely be here or be called this in the future

            hot.ExpirationTime = currentTime + hot.BaseDuration;
            hot.NextTickTime = currentTime + hot.BaseTickDuration;
            effects.Add(hot);
        }

        private void LogDebug(string message)
        {
            _log.Debug($"I={id} - {currentTime:F2} - {message}");
        }

        private void LogError(string message)
        {
            _log.Error($"I={id} - {currentTime:F2} - {message}");
        }
    }
}