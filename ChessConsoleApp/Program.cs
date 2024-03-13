using ChessBoard;

namespace ChessConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position P;

            P = new(3, 4);

            Console.WriteLine("Posicao " + P);
        }
    }
}