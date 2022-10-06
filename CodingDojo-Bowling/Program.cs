

using CodingDojo_Bowling;

Console.WriteLine("Ecrire un table de score : (X pour strike, / pour spare, - pour rien)");
Console.WriteLine("Exemple : 6/ 4/ X -5 -- -/ 32 7- X 5/2");
string? scores = Console.ReadLine();
if (scores != null)
{
    BowlingGame game = new BowlingGame(scores);
    Console.WriteLine("\nScore : " + game.Result);
}
