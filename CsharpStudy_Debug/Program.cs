﻿namespace CsharpStudy_Debug;

class Program
{
    static void Main(string[] args)
    {
        var controller = new YukymController();

        Console.WriteLine($"GetTyA() 결과: {controller.GetTyA()}");       // 8월 : 경오4국
        Console.WriteLine($"GetTyB() 결과: {controller.GetTyB()}");       // 10시 : 갑자5국 
    }
}