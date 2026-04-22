using Perform;
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
            var totHeight = Raylib.GetRenderHeight();
            var totWidth = Raylib.GetRenderWidth();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);

            // Draw background
            Raylib.DrawRectangle(1, 1, width: totWidth - 2, totHeight - 2, Color.Blue);

            // Generate cells with their address
            var cells = GenerateCells(totHeight, totWidth);

            // Draw cells with value
            DrawCells(cells);

            var textHeight = 20;
            var text = "42";
            var textWidth = Raylib.MeasureText(text, textHeight);

            Raylib.DrawText(text, totWidth / 2 - textWidth / 2, totHeight / 2 - textHeight / 2, textHeight, Color.Green);
            Raylib.DrawText($"FPS {fps};\nMicroseconds per frame: " +
                $"{frameTimeMicroseconds:F3}", 20, 20, 20, Color.White);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    private static void DrawCells(Cell[] cells)
    {
        foreach (var c in cells)
        {
            // Draw cell geometry
            Raylib.DrawRectangle(c.Xpos, c.Ypos, c.Xsize, c.Ysize, (Color)c.CellColor!);

            // Draw cell avalue
        }
    }

    private static Cell[] GenerateCells(int totHeight, int totWidth)
    {
        var widthSpan = totWidth / 3;
        var heightSpan = totHeight / 3;

        var cellWidth = widthSpan / 2;
        var cellHeight = heightSpan / 2;

        Cell[] cells = new Cell[9];
        for (int i = 0; i < cells.Length; i++)
        {
            var x = widthSpan * (i % 3);
            var y = heightSpan * (i / 3);

            // offset half span
            x = x + widthSpan / 2;
            y = y + heightSpan / 2;

            // center cells
            x = x - cellWidth / 2;
            y = y - cellHeight / 2;

            char[] columnLetters = { 'A', 'B', 'C' };

            CellAddress address = new CellAddress($"{columnLetters[i % 3]}", $"{i / 3 + 1}");

            cells[i] = new Cell(x, y, widthSpan / 2, heightSpan / 2, address, null);

        }

        return cells;
    }
}
