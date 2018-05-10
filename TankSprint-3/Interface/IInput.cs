using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace TankSprint_3
{
    interface IInput
    {
        Keys Left { get; }
        Keys Right { get; }
        Keys Up { get; }
        Keys Down { get; }
        Keys Shoot { get; set; }
    }

    class WASDInput : IInput
    {
        public Keys Left { get; }
        public Keys Right { get; }
        public Keys Up { get; }
        public Keys Down { get; }
        public Keys Shoot { get; set; }

        public WASDInput()
        {
            Left = Keys.A;
            Right = Keys.D;
            Up = Keys.W;
            Down = Keys.S;
            Shoot = Keys.Space;
        }
    }

    class ArrowInput : IInput
    {
        public Keys Left { get; }
        public Keys Right { get; }
        public Keys Up { get; }
        public Keys Down { get; }
        public Keys Shoot { get; set; }

        public ArrowInput()
        {
            Left = Keys.Left;
            Right = Keys.Right;
            Up = Keys.Up;
            Down = Keys.Down;
            Shoot = Keys.L;
        }
    }

}
