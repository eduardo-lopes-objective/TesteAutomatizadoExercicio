// See https://aka.ms/new-console-template for more information
using Exercice.Exercice1;
using Exercice.Exercice2.Business;
using System;

Multiple3Or5Service Multiple3Or5Service = new();

Console.WriteLine("Somatório dos múltiplos de 3 e 5 abaixo de 100: " + Multiple3Or5Service.Run(100));
Console.WriteLine("Somatório dos múltiplos de 3 e 5 abaixo de 1000: " + Multiple3Or5Service.Run(1000));


Multiple3Or5And7Service multiple3Or5And7Service = new();
Console.WriteLine("Somatório dos múltiplos de (3 ou 5) e 7 abaixo de 1000: " + multiple3Or5And7Service.Run(1000));

Console.WriteLine("---------------------------------------------------------------");
Console.WriteLine("Digite um número para determinar se é um número feliz:");
var userInput = Console.ReadLine();

if (!string.IsNullOrEmpty(userInput))
{
    DetermineIsHappyNumber determineIsHappyNumber = new();
    var isHappy = determineIsHappyNumber.Check(Convert.ToInt32(userInput));
    Console.WriteLine(isHappy ? "É um número feliz" : "Não é um número feliz");
}