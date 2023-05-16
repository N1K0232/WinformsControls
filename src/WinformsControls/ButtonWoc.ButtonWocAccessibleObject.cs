namespace WinformsControls;

public partial class ButtonWoc
{
    public class ButtonWocAccessibleObject : ButtonBaseAccessibleObject
    {
        private readonly ButtonWoc _owner;

        public ButtonWocAccessibleObject(Control owner)
            : base(owner is ButtonWoc button ? button
            : throw new ArgumentException("Invalid control", nameof(owner)))
        {
            _owner = button;
        }
    }
}