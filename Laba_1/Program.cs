using Laba_1;

Console.WriteLine("0 - Text words counter,  1 - Calculator");
Console.WriteLine("Choose case: ");
var cases = new Menu(Convert.ToInt32(Console.ReadLine()));
cases.MenuChoise();
