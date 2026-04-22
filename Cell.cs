using Raylib_cs;

namespace Perform
{
    internal class Cell
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int Xsize { get; set; }
        public int Ysize { get; set; }
        public CellAddress Address { get; set; }

        public int? Value { get; set; }
        public Color? CellColor { get; set; }

        public Cell(int xPos, int yPos, int xsize, int ysize, CellAddress address, Color? cellColor)
        {
            Xpos = xPos;
            Ypos = yPos;

            Xsize = xsize;
            Ysize = ysize;

            Address = address;

            CellColor = cellColor ?? Color.Brown;
        }


        public static void WriteInCell(Cell cell, string text, int textHeight, Color? textColor)
        {
            textColor = textColor ?? Color.Black;

            var textWidth = Raylib.MeasureText(text, textHeight);

            Raylib.DrawText(text,
                cell.Xpos / 2 - textWidth / 2,
                cell.Ypos / 2 - textHeight / 2,
                textHeight, Color.Green);
        }
    }

    internal record CellAddress(string ColumnId, string RowId);
}
