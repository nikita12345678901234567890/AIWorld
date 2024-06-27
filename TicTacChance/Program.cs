﻿using AIWorld;

namespace TicTacChance
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ToDo: when removing pity turns die, fix
            var env = new TicTacEnvironment();
            var runner = new AgentRunner<TicTacState>(env, new ExpectiMax<TicTacState>(env.GetSuccessors, new TicTacState()));
            while (!runner.agents[0].CurrentGameState.IsTerminal)
            {
                runner.DoTurn();
                Console.WriteLine($"{Convert(runner.agents[0].CurrentGameState.Grid[0, 0])}|{Convert(runner.agents[0].CurrentGameState.Grid[0, 1])}|{Convert(runner.agents[0].CurrentGameState.Grid[0, 2])}");
                Console.WriteLine($"{Convert(runner.agents[0].CurrentGameState.Grid[1, 0])}|{Convert(runner.agents[0].CurrentGameState.Grid[1, 1])}|{Convert(runner.agents[0].CurrentGameState.Grid[1, 2])}");
                Console.WriteLine($"{Convert(runner.agents[0].CurrentGameState.Grid[2, 0])}|{Convert(runner.agents[0].CurrentGameState.Grid[2, 1])}|{Convert(runner.agents[0].CurrentGameState.Grid[2, 2])}");
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                runner.PlayerTurn(new TicTacState(runner.agents[0].CurrentGameState.Grid, false, false, runner.agents[0].CurrentGameState.Missed, (x, y)));
            }
        }

        static int Convert(bool? bol)
        {
            if (bol == true) return 1;
            else if (bol == false) return 2;
            return 0;
        }
    }
}