using System;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.FeatherHelper.Entities
{
    [CustomEntity("FeatherHelper/FeatherFilter")]
    public class FeatherFilter : Entity
    {
        private float _colorLerp;

        public FeatherFilter(EntityData data, Vector2 offset) : base(data.Position + offset)
        {
            Depth = 5000;
            Collider = new Hitbox(data.Width, data.Height);
            Add(new PlayerCollider(OnPlayer));
        }

        public override void Render()
        {
            Draw.Rect(Position, Width,Height, Color.Lerp(Color.DarkOliveGreen, Color.ForestGreen,
                (float)(Math.Sin(_colorLerp) + 1) / 2));
            Draw.HollowRect(Collider, Color.White);
        }

        public override void Update()
        {
            _colorLerp += 0.05f;
        }

        private void OnPlayer(Player player)
        {
            if (player.StateMachine.State != 19)
            {
                player.Die(Vector2.Zero);
            }
        }
    }
}