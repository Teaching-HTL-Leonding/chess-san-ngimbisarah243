PrintMoves(args);


void PrintMoves(string[] input)
{
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == "0-0") Console.WriteLine("Kigssinde castling");
        else if (input[i] == "0-0-0") Console.WriteLine("Queensinde castling");
        else if (args[i].Length == 2 || args[i].Length == 3)
        {
            Console.Write(Characters(input[i][0]));
            Console.Write(" moves to ");
            Console.WriteLine(input[i][0] == Char.ToUpper(input[i][0]) ? input[i].Substring(1) : args[i]);

            if (Char.IsAsciiLetterUpper(input[i][^1]))
            {
                Console.WriteLine($"and is prmoted to {Characters(input[i][^1])}");
            }
        }
        else
        {
            Console.Write(Characters(input[i][0]));

            if (input[i][1] == 'x')
            {
                if (Characters(input[i][0]) == "Pawn")
                {
                    Console.Write($" on the {input[i][0]}-file");
                }
                if (i + 1 < input.Length && input[i + 1] == "e.p.")
                {
                    Console.WriteLine($" captures a piece en passant and goes to {input[i].Substring(2)}");
                }
                else Console.WriteLine($" captures the piece on {input[i].Substring(2, 2)}");
            }
            else
            {
                if (Char.IsDigit(input[i][1])) Console.Write($"on the {input[i][1]}-rank ");
                else if (Char.IsLetter(input[i][1]))
                {
                    Console.WriteLine(Char.IsDigit(input[i][2]) ? $"on {input[i].Substring(1, 2)}" : $"on the {input[i][1]}-file");
                }

                Console.WriteLine($" moves to {input[^2]}{input[^1]}");
            }

        }
        if (input[i][^1] == '+') Console.WriteLine(" and places opponents King in check");
        else if (input[i][^1] == '#') { Console.WriteLine(", checkmate"); break; }
    }
}
Console.WriteLine();
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Goodbye!!");
Console.ResetColor();


string Characters(char letter)
{
    return letter switch
    {
        'B' => "Bishop",
        'N' => "Knight",
        'Q' => "Queen",
        'R' => "Rook",
        'K' => "King",
        _ => "Pawn"
    };
}