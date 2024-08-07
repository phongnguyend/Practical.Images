using SixLabors.ImageSharp.Formats.Bmp;
using SkiaSharp;
using System.Drawing;


var fileName = "C:\\Users\\Phong.NguyenDoan\\Downloads\\image_2024_08_06T07_51_43_296Z.png";

using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
{
    Bitmap imagePath = (Bitmap)System.Drawing.Image.FromStream(stream, true);
    Console.WriteLine($"Width: {imagePath.Width} Height: {imagePath.Height}");

    using (MemoryStream m = new MemoryStream())
    {
        imagePath.Save(m, imagePath.RawFormat);
        byte[] imageBytes = m.ToArray();

        var text1 = Convert.ToBase64String(imageBytes);
        var text2 = Convert.ToBase64String(File.ReadAllBytes(fileName));
    }
}

using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(fileName))
{
    Console.WriteLine($"Width: {image.Width} Height: {image.Height}");

    using (MemoryStream m = new MemoryStream())
    {
        image.Save(m, new BmpEncoder());
        byte[] imageBytes = m.ToArray();

        var text1 = Convert.ToBase64String(imageBytes);
        var text2 = Convert.ToBase64String(File.ReadAllBytes(fileName));
    }
}

using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
{
    var skBitmap = SKBitmap.Decode(stream);
    Console.WriteLine($"Width: {skBitmap.Width} Height: {skBitmap.Height}");
}