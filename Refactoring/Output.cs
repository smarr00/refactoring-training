using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
	public static class Output
	{
		internal static void WelcomeMessage()
		{
			Console.WriteLine("Welcome to TUSC");
			Console.WriteLine("---------------");
		}

		internal static string PromptForUserName()
		{
			Console.WriteLine();
			Console.WriteLine("Enter Username:");
			return Console.ReadLine();
		}

		internal static void InvalidPasswordMessage()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine();
			Console.WriteLine("You entered an invalid password.");
			Console.ResetColor();
		}

		internal static void InvalidUserMessage()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine();
			Console.WriteLine("You entered an invalid user.");
			Console.ResetColor();
		}

		internal static void PromptForExitKey()
		{
			Console.WriteLine();
			Console.WriteLine("Press Enter key to exit");
			Console.ReadLine();
		}

		internal static string PromptForPassword()
		{
			Console.WriteLine("Enter Password:");
			return Console.ReadLine();
		}

		internal static void SuccessfulLoginMessage(string name)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine();
			Console.WriteLine("Login successful! Welcome " + name + "!");
			Console.ResetColor();
		}

		internal static void RemainingBalanceMessage(double balance)
		{
			Console.WriteLine();
			Console.WriteLine("Your balance is " + balance.ToString("C"));
		}

		internal static string PromptForPurchaseQuantity()
		{
			Console.WriteLine("Enter amount to purchase:");
			return Console.ReadLine();
		}

		internal static void LowBalanceMessage()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine();
			Console.WriteLine("You do not have enough money to buy that.");
			Console.ResetColor();
		}

		internal static void OutOfStockMessage(string name)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine();
			Console.WriteLine("Sorry, " + name + " is out of stock");
			Console.ResetColor();
		}

		internal static void PurchaseCancelledMessage()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine();
			Console.WriteLine("Purchase cancelled");
			Console.ResetColor();
		}

		internal static void PurchaseCompleteMessage(int quantity, string name, double balance)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("You bought " + quantity + " " + name);
			Console.WriteLine("Your new balance is " + balance.ToString("C"));
			Console.ResetColor();
		}

		internal static void PuchaseIntentMessage(string name, double balance)
		{
			Console.WriteLine();
			Console.WriteLine("You want to buy: " + name);
			Console.WriteLine("Your balance is " + balance.ToString("C"));
		}
	}
}
