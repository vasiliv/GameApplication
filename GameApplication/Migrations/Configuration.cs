namespace GameApplication.Migrations
{
    using GameApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameApplication.DAL.GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GameApplication.DAL.GameContext context)
        {
            var games = new List<Game>
            {
                new Game{Name="Super Mario Bros"},
                new Game{Name="Super Mario 64"},
                new Game{Name="Super Mario Galaxy"}
            };
            games.ForEach(e => context.Games.AddOrUpdate(p => p.Name, e));
            context.SaveChanges();
        }
    }
}
