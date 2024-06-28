﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWorld
{
    public class AgentRunner<T> where T : IGameState
    {
        public IEnvironment<T> environment;
        
        public List<IAgent<T>> agents;

        public AgentRunner(IEnvironment<T> env, IAgent<T> agent)
        {
            environment = env;
            agents = new List<IAgent<T>>();
            agents.Add(agent);
        }

        public void DoTurn()
        { 
            for (int i = 0;i < agents.Count;i++)
            {
                var successors = environment.GetActions(agents[i].CurrentGameState);
                var move = agents[i].Move(successors);
                agents[i].CurrentGameState = environment.MakeMove(move, agents[i].CurrentGameState);
            }
        }

        public void PlayerTurn(Akshun<T> move)
        { 
            var newState = environment.MakeMove(move, agents[0].CurrentGameState);
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].CurrentGameState = newState;
            }
        }
    }
}