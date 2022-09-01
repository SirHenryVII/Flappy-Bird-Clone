using System;
using System.Collections.Generic;
using System.Text;

namespace FlappyBird
{
    abstract class Screen
    {
        public abstract void DrawScreen();
        public abstract void Update();
    }
}
