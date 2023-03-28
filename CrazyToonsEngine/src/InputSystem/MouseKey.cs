namespace CrazyToonsEngine.src.InputSystem
{
    public struct MouseKey
    {
        public int index;
        public bool pressed;
        public bool down;
        public bool released;

        public MouseKey(int index)
        {
            this.index = index;
            pressed = false;
            down = false;
            released = false;
        }
    }

}
