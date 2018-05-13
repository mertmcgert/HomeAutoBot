using StreamDeckSharp;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using HidLibrary;
using System.Threading;

namespace HomeAutobot.StreamDeckHelper
{
    public class StreamDeckHelper
    {
        public static void DrawText(string text, int sdPos)
        {
            using(var deck = StreamDeck.OpenDevice())
            {
                var key = KeyBitmap.FromGraphics(g =>
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                    //Fill background black
                    g.FillRectangle(Brushes.Black, 0, 0, deck.IconSize, deck.IconSize);

                    //Write text to graphics
                    var f = new Font("Arial", 24);
                    g.DrawString(text, f, Brushes.White, new PointF(12, 20));
                });
                deck.SetKeyBitmap(sdPos, key);
                Thread.Sleep(500);
            } 
        }
    }
}
