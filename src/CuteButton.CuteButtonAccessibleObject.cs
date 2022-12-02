namespace WinformsControls;

public partial class CuteButton : Button
{
    public sealed class CuteButtonAccessibleObject : ButtonBaseAccessibleObject
    {
        private readonly CuteButton _owner;

        public CuteButtonAccessibleObject(CuteButton owner) : base(owner)
        {
            _owner = owner;
        }
    }
}