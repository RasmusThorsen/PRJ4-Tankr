//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;

//namespace TankSprint_3
//{
//    class Colliders
//    {
//        private Vector2 _topCollider;
//        public Vector2 TopCollider
//        {
//            get => _topCollider;
//            set => _topCollider = value;
//        }

//        private Vector2 _bottomCollider;
//        public Vector2 BottomCollider
//        {
//            get => _bottomCollider;
//            set => _bottomCollider = value;
//        }

//        private Vector2 _leftCollider;
//        public Vector2 LeftCollider
//        {
//            get => _leftCollider;
//            set => _leftCollider = value;
//        }

//        private Vector2 _rightCollider;
//        public Vector2 RightCollider
//        {
//            get => _rightCollider;
//            set => _rightCollider = value;
//        }

//        private Sprite _sprite;

//        public Colliders(Sprite sprite)
//        {
//            _sprite = sprite;
            
//            Vector2 upperLeft = new Vector2((int)-_sprite.Texture.Width/2, (int)_sprite.Texture.Height/2);
//            Vector2 upperRight = new Vector2((int)_sprite.Texture.Width/2, _sprite.Texture.Height/2);
//            Vector2 lowerLeft = new Vector2(-_sprite.Texture.Width/2, -_sprite.Texture.Height/2);
//            Vector2 lowerRight = new Vector2(_sprite.Texture.Width/2, -_sprite.Texture.Height/2);

//            TopCollider = upperRight - upperLeft;
//            LeftCollider = lowerLeft - upperLeft;
//            BottomCollider = lowerRight - lowerLeft;
//            RightCollider = upperRight - lowerRight;
//            Debug.WriteLine("Top: {0}, {1}",TopCollider.X, TopCollider.Y);
//            Debug.WriteLine("Left: {0}, {1}", LeftCollider.X, LeftCollider.Y);
//            Debug.WriteLine("Right: {0}, {1}", RightCollider.X, RightCollider.Y);
//            Debug.WriteLine("Bottom: {0}, {1}", TopCollider.X, TopCollider.Y);
//        }

//        public void UpdateBox()
//        {
//            _topCollider.X = _sprite.Position.X;
//            _topCollider.Y = _sprite.Position.Y;
//            Debug.WriteLine("Top: {0}, {1}", TopCollider.X, TopCollider.Y);
//        }

//        public bool Intersects(Colliders player, Colliders target)
//        {

//            return false;
//        }

//        public Vector2 RotatedVector2(Vector2 vector, float degrees)
//        {
//            Vector2 rotatedVector = new Vector2();
//            rotatedVector.X = vector.X * (float)Math.Cos(MathHelper.ToRadians(degrees)) -
//                              vector.Y * (float)Math.Sin(MathHelper.ToRadians(degrees));

//            rotatedVector.Y = vector.X * (float) Math.Sin(MathHelper.ToRadians(degrees)) +
//                              vector.Y * (float) Math.Cos(MathHelper.ToRadians(degrees));


//            return rotatedVector;
//        }
//    }
//}
