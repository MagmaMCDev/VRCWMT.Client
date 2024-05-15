using System.Drawing;
using System.Drawing.Imaging;

namespace VRCWMT;

public class ColoredPictureBox : PictureBox
{
    private Color _overlayColor = Color.Transparent;


    public Color OverlayColor
    {
        get
        {
            return _overlayColor;
        }
        set
        {
            _overlayColor = value;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        if (Image != null)
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix();
            // Apply overlay color
            if (_overlayColor != Color.Transparent)
            {
                colorMatrix.Matrix00 = ((_overlayColor.R / 255f)*2)-1;
                colorMatrix.Matrix01 = ((_overlayColor.G / 255f) * 2) - 1;
                colorMatrix.Matrix02 = ((_overlayColor.B / 255f) * 2) - 1;
            }

            imageAttributes.SetColorMatrix(colorMatrix);

            pe.Graphics.DrawImage(
                Image,
                new Rectangle(0, 0, Width, Height),
                0, 0, Image.Width, Image.Height,
                GraphicsUnit.Pixel,
                imageAttributes);
        }
    }
}
