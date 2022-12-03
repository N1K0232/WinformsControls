namespace WinformsControls;

public partial class RoundButton
{
    public class RoundButtonAccessibleObject : ButtonBaseAccessibleObject
    {
        public RoundButtonAccessibleObject(Control owner)
            : base(owner is RoundButton button ? button
            : throw new ArgumentException("invalid control", nameof(owner)))
        {
        }
    }
}