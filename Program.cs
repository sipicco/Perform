using Raylib_cs;

class Program
{
    static String[] cells = {
            "42", "4", "3",
            "A", "F", "x",
            "42", "4", "3",
        };

    static void Main()
    {

        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
        Raylib.InitWindow(800, 450, "Red Rectangle");

        while (!Raylib.WindowShouldClose())
        {
            var frameTimeMicroseconds = Raylib.GetFrameTime() / 1e6;
            var fps = Raylib.GetFPS();
            var height = Raylib.GetRenderHeight();
            var width = Raylib.GetRenderWidth();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            Raylib.DrawRectangle(1, 1, width: width - 2, height - 2, Color.Blue);


            Raylib.DrawRectangle(width / 2 - 100, height / 2 - 75, width: 200, 150, Color.Red);


            var textHeight = 20;
            var text = "42";
            var textWidth = Raylib.MeasureText(text, textHeight);

            Raylib.DrawText(text, width / 2 - textWidth / 2, height / 2 - textHeight / 2, textHeight, Color.Green);
            Raylib.DrawText($"FPS {fps};\nMicroseconds per frame: {frameTimeMicroseconds:F3}", 20, 20, 20, Color.White);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
