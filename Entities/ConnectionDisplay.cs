using System;
using Monocle;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.FeatherHelper.Entities
{
    [CustomEntity("FeatherHelper/ConnectionDisplay")]
    public class ConnectionDisplay : Entity
    {
        private readonly Vector2[] _brotherPositions;
        private readonly Vector2[] _brotherRandomOffsets;
        private readonly VertexLight[] _brotherLights;
        
        private const float BrotherDis = 70;
        private float _animationTime;
        private const float RandomTimes = 3f;
        private readonly int _brotherCount;

        private readonly VertexLight _fatherLight;

        public ConnectionDisplay(EntityData data, Vector2 offset) : base(data.Position + offset)
        {
            Collider = new Hitbox(data.Width, data.Height);
            Depth = 8000;
            
            _brotherCount = data.Int("brotherCount");
            _brotherPositions = new Vector2[_brotherCount];
            _brotherRandomOffsets = new Vector2[_brotherCount];
            _brotherLights = new VertexLight[_brotherCount];
            
            for (var i = 0; i < _brotherCount; i++)
            {
                var brother = new Vector2(Calc.Random.Range(-1f,1f) * BrotherDis, 
                    Calc.Random.Range(-1f,1f) * BrotherDis);
                _brotherPositions[i] = brother;

                _brotherRandomOffsets[i] = new Vector2(Calc.Random.Range(0.1f, 0.9f),Calc.Random.Range(0.1f, 0.9f));
                
                Add(_brotherLights[i] = new VertexLight(brother, Color.Gold, 1f, 48, 64));
                _brotherLights[i].Visible = true;
            }
            
            Add(_fatherLight = new VertexLight(Color.Gold, 1f,48,64));
            _fatherLight.Visible = true;
        }

        public override void Render()
        {
            var firstRandom = new Vector2(
                (float)Math.Cos(_animationTime), (float)Math.Sin(_animationTime + 0.6f)) * RandomTimes;
            Draw.Circle(Position + firstRandom, 3, Color.Gold,5f, 3);

            var lastRandom = Vector2.Zero;
            
            for (var i = 0; i < _brotherCount; i++)
            {
                var secondRandom = new Vector2(
                    (float)Math.Sin(_animationTime + _brotherRandomOffsets[i].X),
                    (float)Math.Cos(_animationTime + _brotherRandomOffsets[i].Y)) * RandomTimes;

                Draw.Circle(Position + _brotherPositions[i] + secondRandom,
                    3, Color.Gold,5f, 3);
                
                if (i == 0)
                {
                    Draw.Line(Position + firstRandom, Position + _brotherPositions[0] + secondRandom, Color.Gold, 3);
                    _fatherLight.Position = firstRandom;
                }
                else
                {
                    Draw.Line(Position + _brotherPositions[i - 1] + lastRandom, Position + _brotherPositions[i] + secondRandom, Color.Gold, 3);
                }

                _brotherLights[i].Position = _brotherPositions[i] + secondRandom;
                
                lastRandom = new Vector2(secondRandom.X, secondRandom.Y);
            }
        }

        public override void Update()
        {
            _animationTime += 0.01f;
        }
    }
}
