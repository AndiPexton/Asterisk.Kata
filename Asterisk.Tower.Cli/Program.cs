using System;
using Asterisk.Tower.Gateway;
using Dependency;
using Shadow.Quack;
using Shadow.Quack.Args;

namespace Asterisk.Tower.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawTowerFromConfig(Duck.Implement<ICliConfig>((ArgsProxy)args));
        }

        private static void DrawTowerFromConfig(ICliConfig config)
        {
            Shelf.ShelveInstance<IConfig>(config);
            Console.Write(string.Join('\n', config.Rows.CreateAsteriskTower()));
        }
    }
}
