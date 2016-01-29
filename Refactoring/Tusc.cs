using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
	public class Tusc
	{
		public static void Start(List<User> users, List<Product> products)
		{
			Output.WelcomeMessage();

			// Login
			Login:
			bool isLoggedIn = false;

			string name = Output.PromptForUserName();

			// Validate Username
			bool validUser = false; // Is valid user?
			if (!string.IsNullOrEmpty(name))
			{
				for (int i = 0; i < 5; i++)
				{
					User user = users[i];
					// Check that name matches
					if (user.Name == name)
					{
						validUser = true;
					}
				}

				// if valid user
				if (validUser)
				{
					string password = Output.PromptForPassword();

					// Validate Password
					bool validPassword = false; // Is valid password?
					for (int i = 0; i < users.Count; i++)
					{
						User user = users[i];

						// Check that name and password match
						if (user.Name == name && user.Password == password)
						{
							validPassword = true;
						}
					}

					// if valid password
					if (validPassword == true)
					{
						isLoggedIn = true;
						Output.SuccessfulLoginMessage(name);

						// Show remaining balance
						double balance = 0;
						for (int i = 0; i < users.Count; i++)
						{
							User user = users[i];

							// Check that name and password match
							if (user.Name == name && user.Password == password)
							{
								balance = user.Balance;

								// Show balance 
								Output.RemainingBalanceMessage(balance);
							}
						}

						// Show product list
						while (true)
						{
							// Prompt for user input
							Console.WriteLine();
							Console.WriteLine("What would you like to buy?");
							for (int i = 0; i < products.Count; i++)
							{
								Product product = products[i];
								Console.WriteLine(i + 1 + ": " + product.Name + " (" + product.Price.ToString("C") + ")");
							}
							Console.WriteLine(products.Count + 1 + ": Exit");

							// Prompt for user input
							Console.WriteLine("Enter a number:");
							string answer = Console.ReadLine();
							int number = Convert.ToInt32(answer);
							number = number - 1; /* Subtract 1 from number
                            num = num + 1 // Add 1 to number */

							// Check if user entered number that equals product count
							if (number == 7)
							{
								// Update balance
								foreach (var user in users)
								{
									// Check that name and password match
									if (user.Name == name && user.Password == password)
									{
										user.Balance = balance;
									}
								}

								// Write out new balance
								string json = JsonConvert.SerializeObject(users, Formatting.Indented);
								File.WriteAllText(@"Data/Users.json", json);

								// Write out new quantities
								string json2 = JsonConvert.SerializeObject(products, Formatting.Indented);
								File.WriteAllText(@"Data/Products.json", json2);


								// Prevent console from closing
								Output.PromptForExitKey();
								return;
							}
							else
							{
								Output.PuchaseIntentMessage(products[number].Name, balance);
								
								// Prompt for user input
								answer = Output.PromptForPurchaseQuantity();
								int quantity = Convert.ToInt32(answer);

								// Check if balance - quantity * price is less than 0
								if (balance - products[number].Price * quantity < 0)
								{
									Output.LowBalanceMessage();
									continue;
								}

								// Check if quantity is less than quantity
								if (products[number].Quantity <= quantity)
								{
									Output.OutOfStockMessage(products[number].Name);
									continue;
								}

								// Check if quantity is greater than zero
								if (quantity > 0)
								{
									// Balance = Balance - Price * Quantity
									balance = balance - products[number].Price * quantity;

									// Quanity = Quantity - Quantity
									products[number].Quantity = products[number].Quantity - quantity;

									Output.PurchaseCompleteMessage(quantity, products[number].Name, balance);
								}
								else
								{
									// Quantity is less than zero
									Output.PurchaseCancelledMessage();
								}
							}
						}
					}
					else
					{
						Output.InvalidPasswordMessage();
						goto Login;
					}
				}
				else
				{
					Output.InvalidUserMessage();
					goto Login;
				}
			}

			Output.PromptForExitKey();
		}
	}
}
