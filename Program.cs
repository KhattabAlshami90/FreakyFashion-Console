using FreakyFashion.Models;
using System.Drawing;


 Dictionary<string, Product> productsList = new();
 List<Category> categoriesList = new();

bool applicationRunning = true;
bool invalidSelection = true;


ConsoleKeyInfo userInput;

Product product = new();
Category category = new("e");

string categoryName;
ConsoleKeyInfo makeSureUserInput;
bool isAccessGranted = false;
bool isSure=false;

while (applicationRunning) 
{
    Logo.ClearScreen();
    Console.CursorVisible = false;

    Console.WriteLine($"1. Logga in");
    Console.WriteLine($"2. Avsluta");

    do
    {
        userInput = Console.ReadKey(true);

        invalidSelection = !(
            userInput.Key == ConsoleKey.D1 ||
            userInput.Key == ConsoleKey.NumPad1 ||
            userInput.Key == ConsoleKey.D2 ||
            userInput.Key == ConsoleKey.NumPad2
           
            );

    } while (invalidSelection);
    switch (userInput.Key)
    {
        case ConsoleKey.D1:
        case ConsoleKey.NumPad1:
            Logo.ClearScreen();
            break;

            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
            applicationRunning = false;
            break;
    }
    invalidSelection=true;

    while (!isAccessGranted&&applicationRunning) 
    {
        Console.CursorVisible = true;
        Console.Write("Användarnamn: ");
        string userName = Console.ReadLine();
        Console.Write("Lösenord: ");
        string passWord = Console.ReadLine();
        if (userName == "khattab" && passWord == "123")
        {
            isAccessGranted = true;
            ConfirmMsg("Välkommen khattab");
        }
        else
        {
            ErrorMsg("Ogiltiga uppgifter, försök igen");
            Logo.ClearScreen();
        }
    }




    while (isAccessGranted) 
    {
        Logo.ClearScreen();
        Console.CursorVisible = false;

        Console.WriteLine($"1. Ny produkt");
        Console.WriteLine($"2. Sök produkt");  //Huvud meny (Main)
        Console.WriteLine($"3. Ny kategori");
        Console.WriteLine($"4. Lägg till produkt till kategori");
        Console.WriteLine($"5. Lista kategorier");
        Console.WriteLine($"6. Logga ut");

        invalidSelection = true;

        do
        {
            userInput = Console.ReadKey(true);

            invalidSelection = !(
                userInput.Key == ConsoleKey.D1 ||
                userInput.Key == ConsoleKey.NumPad1 ||
                userInput.Key == ConsoleKey.D2 ||
                userInput.Key == ConsoleKey.NumPad2 ||
                userInput.Key == ConsoleKey.D3 ||
                userInput.Key == ConsoleKey.NumPad3 ||
                userInput.Key == ConsoleKey.D4 ||
                userInput.Key == ConsoleKey.NumPad4 ||
                userInput.Key == ConsoleKey.D5 ||
                userInput.Key == ConsoleKey.NumPad5 ||
                userInput.Key == ConsoleKey.D6 ||
                userInput.Key == ConsoleKey.NumPad6
                );

        } while (invalidSelection);
        Console.CursorVisible = true; ;

        switch (userInput.Key)

        {
            case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                {
                    string itemNumber;
                    string itemName;
                    string itemDescription;
                    string itemPhoto;
                    decimal itemprice;
                    bool isDecimal;

                    do
                    {
                        Logo.ClearScreen();

                        do
                        {
                            Console.Write("Artikelnummer: ");
                            itemNumber = Console.ReadLine().ToLower();
                            if (itemNumber == String.Empty)
                            {
                                ErrorMsg("Artikelnummer ska inte vara tomt...");

                                Logo.ClearScreen();
                            }
                        } while (itemNumber == String.Empty);

                        Console.Write($"         Name: ");
                        itemName = Console.ReadLine();
                        Console.Write($"  Beskrivning: ");
                        itemDescription = Console.ReadLine();
                        Console.Write($"    Bild (URL):");
                        itemPhoto = Console.ReadLine();

                        do
                        {
                            Console.Write("          Pris:");
                            isDecimal = decimal.TryParse(Console.ReadLine(), out itemprice);


                            if (!isDecimal)

                            {
                                Console.WriteLine();
                                ErrorMsg("Priset ska vara ett nummer....");
                            }
                        } while (!isDecimal);
                        Logo.ClearScreen();



                        Console.Write($"Artikelnummer: ");
                        Console.WriteLine(itemNumber);
                        Console.Write($"         Name: ");
                        Console.WriteLine(itemName);
                        Console.Write("  Beskrivning: ");
                        Console.WriteLine(itemDescription);
                        Console.Write($"   Bild (URL): ");
                        Console.WriteLine(itemPhoto);
                        Console.Write($"         pris: ");
                        Console.WriteLine(itemprice);
                        Console.WriteLine();
                        Console.WriteLine("stämmer detta? (j)a (n)ej");

                        isSure = MakeSure();

                        if (!isSure)
                        {
                            Console.WriteLine();
                            ErrorMsg("Du får försöka igen . . .");
                            Console.CursorVisible = true;
                        }
                        if (isSure)
                        {
                            break;
                        }
                    } while (!isSure);

                    bool isAlready = false;

                    if (productsList.ContainsKey(itemNumber))
                    {
                        isAlready = true;

                    }

                    if (isAlready)
                    {
                        Console.WriteLine();
                        ErrorMsg("Artikelnummer redan registrerat . . .");

                        break;
                    }

                    product = new Product
                    {
                        Number = itemNumber,
                        Name = itemName,
                        Description = itemDescription,
                        Photo = itemPhoto,
                        Price = itemprice
                    };
                    productsList.Add(itemNumber,product);

                    Console.WriteLine();
                    ConfirmMsg("Produkt registrerad . . .");
                    break;
                }

            case ConsoleKey.D2:
            case ConsoleKey.NumPad2:
                {
                    Logo.ClearScreen();

                    Console.Write("Ange produkt: ");
                    string sProduct = Console.ReadLine().ToLower();
                    bool isFound = false;

                    if (productsList.ContainsKey(sProduct))
                    {
                        isFound = true;
                        product = productsList[sProduct];
                    }

                    if (!isFound)
                    {
                        Console.WriteLine();
                        ErrorMsg("Ingen produkt hittades . . .");
                        break;
                    }

                    if (isFound)
                    {
                        bool confirmNo = false;

                        do
                        {
                            do
                            {
                                confirmNo = false;

                                WriteProduct(product);
                                Console.WriteLine("(R)adera");

                                do
                                {
                                    userInput = Console.ReadKey(true);
                                } while (userInput.Key != ConsoleKey.R &&
                                userInput.Key != ConsoleKey.Escape);

                                if (userInput.Key == ConsoleKey.R)
                                {
                                    WriteProduct(product);
                                    Console.WriteLine("Radera produkt? (Ja) (N)ej");

                                    isSure = MakeSure();


                                    if (!isSure)
                                    {
                                        confirmNo = true;
                                        break;
                                    }

                                    if (isSure)
                                    {
                                        confirmNo = false;
                                        foreach (var c in categoriesList)
                                        {
                                            foreach (var p in c.GetCategoriesProducts().ToList())
                                            {
                                                if (p.Number == product.Number)
                                                {
                                                   c.RemoveProduct(p);
                                                }

                                            }

                                        }
                                        productsList.Remove(sProduct);
                                        ConfirmMsg("Produkt raderad...");
                                    }
                                }
                            } while (confirmNo);

                        } while (userInput.Key != ConsoleKey.Escape && confirmNo);
                    }
                    break;
                }

            case ConsoleKey.D3:
            case ConsoleKey.NumPad3:
                {

                    do
                    {
                        Logo.ClearScreen();
                        Console.Write("Namn: ");
                        categoryName = Console.ReadLine();
                        Logo.ClearScreen();
                        Console.WriteLine("Namn: " + categoryName);
                        Console.CursorVisible = false;
                        Console.WriteLine("Är detta korrekt? (J)a (N)ej");

                        
                       isSure = MakeSure();

                        if (!isSure) { 
                          ErrorMsg("Du får försöka igen . . .");
                       
                        }


                        if (isSure)
                        {
                            break;
                        }
                       

                    } while (!isSure);

                    bool isCategoryAlready = false;

                    foreach (var cat in categoriesList)
                    {
                        if (cat.Name == categoryName)
                        {
                            isCategoryAlready = true;
                        }
                    }

                    if (isCategoryAlready)
                    {
                        Console.WriteLine();
                        ErrorMsg($"kategori redan registrerat . . .");
                        break;
                    }
                    
                    category = new(categoryName)
                    {
                        Name = categoryName
                    };
                   


                    
                    categoriesList.Add(category);
                    Console.WriteLine();
                    ConfirmMsg("Kategori skapad . . .");
                    break;
                }

            case ConsoleKey.D4:
            case ConsoleKey.NumPad4:
                {
                   //1
                    break;
                }



            case ConsoleKey.D5:
            case ConsoleKey.NumPad5:

                

                {
                    //2

                    break;
                }
            case ConsoleKey.D6:
            case ConsoleKey.NumPad6:
                {
                    isAccessGranted = false;
                    break;
                }
        }
    } 
} 
static void ConfirmMsg(string msg)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(msg);
    Console.ForegroundColor = ConsoleColor.White;
    Thread.Sleep(2000);
}
static void ErrorMsg(string msg)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(msg);
    Console.ForegroundColor = ConsoleColor.White;
    Thread.Sleep(2000);
}
static void WriteProduct(Product product)
{
    Logo.ClearScreen();
    Console.WriteLine();
    Console.WriteLine("Produkten hittades: ");
    Console.WriteLine();

    Console.Write("             Artikelnummer: ");
    Console.WriteLine(product.Number);
    Console.Write("                      Name: ");
    Console.WriteLine(product.Name);
    Console.Write("               Beskrivning: ");
    Console.WriteLine(product.Description);
    Console.Write("                Bild (URL): ");
    Console.WriteLine(product.Photo);
    Console.Write("                      Pris: ");
    Console.WriteLine(product.Price.ToString());
    Console.CursorVisible = false;
    Console.WriteLine();
}

static bool MakeSure()
{
    Console.CursorVisible = false;
    ConsoleKeyInfo makeSureUserInput;
    bool isSure;

    do
    {
        makeSureUserInput = Console.ReadKey(true);
    } while (makeSureUserInput.Key != ConsoleKey.J && makeSureUserInput.Key != ConsoleKey.N);

    if (makeSureUserInput.Key == ConsoleKey.N)
        isSure = false;
    else
        isSure = true;

    return isSure;
}






