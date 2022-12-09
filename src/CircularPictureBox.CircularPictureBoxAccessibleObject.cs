namespace WinformsControls;

public partial class CircularPictureBox
{
    public class CircularPictureBoxAccessibleObject : ControlAccessibleObject
    {
        public CircularPictureBoxAccessibleObject(Control owner)
            : base(owner is CircularPictureBox pictureBox ? pictureBox
            : throw new ArgumentException("Invalid control", nameof(owner)))
        {
        }
    }
}