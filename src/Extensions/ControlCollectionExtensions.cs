using ControlCollection = System.Windows.Forms.Control.ControlCollection;

namespace WinformsControls.Extensions;

public static class ControlCollectionExtensions
{
    /// <summary>
    /// removes all the controls from the specified collection
    /// </summary>
    /// <param name="controls">the collection of controls</param>
    public static void RemoveRange(this ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            controls.Remove(control);
            if (!control.IsDisposed)
            {
                control.Dispose();
            }
        }
    }

    /// <summary>
    /// removes a collection of controls
    /// </summary>
    /// <param name="controls">the collection</param>
    /// <param name="items">the list of items</param>
    public static void RemoveRange(this ControlCollection controls, IEnumerable<Control> items)
    {
        foreach (Control item in controls)
        {
            controls.Remove(item);
            if (!item.IsDisposed)
            {
                item.Dispose();
            }
        }
    }
}