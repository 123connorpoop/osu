// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace osu.Game.Screens.Play.HUD
{
    public class GameplayLeaderboard : FillFlowContainer<GameplayLeaderboardScore>
    {
        public GameplayLeaderboard()
        {
            AutoSizeAxes = Axes.Both;

            Direction = FillDirection.Vertical;

            Spacing = new Vector2(2.5f);

            LayoutDuration = 250;
            LayoutEasing = Easing.OutQuint;
        }

        public override void Add(GameplayLeaderboardScore drawable)
        {
            base.Add(drawable);
            drawable?.TotalScore.BindValueChanged(_ => updateScores(), true);
        }

        private void updateScores()
        {
            var orderedByScore = this.OrderByDescending(i => i.TotalScore.Value).ToList();

            for (int i = 0; i < Count; i++)
            {
                SetLayoutPosition(orderedByScore[i], i);
                orderedByScore[i].ScorePosition = i + 1;
            }
        }
    }
}
