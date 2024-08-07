﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWorld
{
    public class AgentRunner<TSensors> where TSensors : ISensorReading, new()
    {
        public IEnvironment<TSensors> environment;
        
        public List<IAgent<TSensors>> agents;

        public AgentRunner(IEnvironment<TSensors> env, IAgent<TSensors> agent)
        {
            environment = env;
            agents = new List<IAgent<TSensors>>();
            agents.Add(agent);
            env.AddAgent(0, agent.CurrentGameState);
        }

        public void DoTurn()
        { 
            for (int i = 0;i < agents.Count;i++)
            {
                var successors = environment.GetActions(i);
                var move = agents[i].Move(successors);
                agents[i].CurrentGameState = environment.MakeMove(move, i);
            }
        }

        public void PlayerTurn(Akshun<TSensors> move)
        { 
            var newState = environment.MakeMove(move, 0);
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].CurrentGameState = newState;
            }
        }

        public List<Akshun<TSensors>> GetActions(TSensors state)
        {
            return environment.GetActions(state);
        }
    }
}