using System;
public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;
    private double v;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance) 
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance, double v) : this(cardNum, pin, firstName, lastName, balance)
    {
        this.v = v;
    }

    public String getNum()
{
    return cardNum;
}
public int getPin()
{
    return pin;
}
public String getfirstName()
{
    return firstName;
}
public String getlastName()
{
    return lastName;
}
public double getBalance()
{
    return balance;
}
public void setNum(String newCardNum)
{
    cardNum = newCardNum;
}
public void setPin(int newPin)
{
    pin = newPin;
}
public void setFirstName(String newFirstName)
{
    firstName = newFirstName;
}
public void setLastName(String newLastName)
{
        lastName = newLastName;
}
public void setBalance(double newBalance)
{
    balance = newBalance;
}
public static void Main(String[] args)
{
    void printOptions()
    {
        Console.WriteLine("Please choose an option...");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Show Balance");
        Console.WriteLine("4. Exit");
    }
    void deposit(cardHolder currentUser)
    {
        Console.WriteLine("How much would you like to deposit?");
        double deposit = Double.Parse(Console.ReadLine());
        currentUser.setBalance(deposit);
        Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());

    }
    void withdraw(cardHolder currentUser) 
    {
        Console.WriteLine("Withdraw Amount$?");
        double withdraw = Double.Parse(Console.ReadLine());
        //Check if the user has enough money
        if(currentUser.getBalance() > withdraw)
        {
            Console.WriteLine("Insufficient balance :(");
        }
        else
        {
            currentUser.setBalance(currentUser.getBalance() - withdraw);
            Console.WriteLine("Thanks for banking with us :)");
        }
    }
    void balance(cardHolder currentUser)
    {
        Console.WriteLine("Current balance: " + currentUser.getBalance());
    }
    List<cardHolder> cardHolders = new List<cardHolder>();
    cardHolders.Add(new cardHolder("4927 6859 2010 7362", 1234, "Emily", "Johnson", 624.42));
    cardHolders.Add(new cardHolder("8134 9562 3781 2405", 0909, "Liam", "Williams", 1,024.26));
    cardHolders.Add(new cardHolder("6250 1398 7246 5079", 5678, "Ava", "Davis", 578.78));
    cardHolders.Add(new cardHolder("3698 5021 8173 9642", 9012, "Noah", "Martinez", 762.94));
    cardHolders.Add(new cardHolder("1502 6847 9321 5860", 3456, "Sophia", "Anderson", 922.96));

    //Prompt user
    Console.WriteLine("Welcome to AiryATM");
    Console.WriteLine("Please insert your debit card ");
    String debitCardNum = "";
    cardHolder currentUser;

    while(true)
    {
        try
        {
            debitCardNum = Console.ReadLine();
            //Check against our database
            currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
            if (currentUser != null) { break; }
            else { Console.WriteLine("Card not recognized. Please try again.");}
        }
        catch {Console.WriteLine("Card not recognized. Please try again.");}
    }
    Console.WriteLine("Please enter your pin: ");
    int userPin = 0;
    while (true)
    {
        try
        {
            userPin = int.Parse(Console.ReadLine());
            
            if (currentUser.getPin() == userPin) { break; }
            else {Console.WriteLine("Incorrect pin. Please try again.");}
        }
        catch {Console.WriteLine("Incorrect pin. Please try again.");}
    }
    Console.WriteLine("Welcome " + currentUser.getfirstName() + " :)");
    int option = 0;
    do
    {
        printOptions();
        try
        {
            option = int.Parse(Console.ReadLine());
        }
        catch { }
        if(option == 1) { deposit(currentUser);}
        else if(option == 2) {withdraw(currentUser);}
        else if(option == 3) {balance(currentUser);}
        else if(option == 4) {break;}
        else { option = 0; }
    }
    while (option != 4);
    Console.WriteLine("Thank you! Have a nice day! :)");
}
}