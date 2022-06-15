// See https://aka.ms/new-console-template for more information
using Exercice.Exercice1;

Multiple3Or5Service Multiple3Or5Service = new();

Console.WriteLine("Somatório dos múltiplos de 3 e 5 abaixo de 100: " + Multiple3Or5Service.Run(100));
Console.WriteLine("Somatório dos múltiplos de 3 e 5 abaixo de 1000: " + Multiple3Or5Service.Run(1000));


Multiple3Or5And7Service multiple3Or5And7Service = new();
Console.WriteLine("Somatório dos múltiplos de (3 ou 5) e 7 abaixo de 1000: " + multiple3Or5And7Service.Run(1000));

