﻿using System;

namespace Debtor
{
    class Program
    {
        static void Main(string[] args)
        {
            var debatorApp = new DebtorApp();
            debatorApp.IntroduceDebtorApp();
            debatorApp.AskForAction();
        }
    }
}
