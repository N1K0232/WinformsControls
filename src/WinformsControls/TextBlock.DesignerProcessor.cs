using System.Runtime.InteropServices;

namespace WinformsControls;

public partial class TextBlock
{
    private const int WM_NCPAINT = 0x85;
    private const uint RDW_INVALIDATE = 0x1;
    private const uint RDW_IUPDATENOW = 0x100;
    private const uint RDW_FRAME = 0x400;

    [LibraryImport("user32.dll")]
    private static partial IntPtr GetWindowDC(IntPtr hWnd);

    [LibraryImport("user32.dll")]
    private static partial IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool RedrawWindow(IntPtr hWnd, IntPtr lprc, IntPtr hrgn, uint flags);
}