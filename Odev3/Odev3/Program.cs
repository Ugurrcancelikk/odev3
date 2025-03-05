namespace Odev3;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }

    public Employee(int id, string name, decimal salary, string department)
    {
        Id = id;
        Name = name;
        Salary = salary;
        Department = department;
    }

    public virtual decimal CalculateBonus()
    {
        return 0; 
    }
}

class Manager : Employee
{
    public int TeamSize { get; set; }

    public Manager(int id, string name, decimal salary, string department, int teamSize)
        : base(id, name, salary, department)
    {
        TeamSize = teamSize;
    }

    public override decimal CalculateBonus()
    {
        return Salary * 0.20m; 
    }
}

class Developer : Employee
{
    public string About { get; set; }

    public Developer(int id, string name, decimal salary, string department, string about)
        : base(id, name, salary, department)
    {
        About = about;
    }

   
    public override decimal CalculateBonus()
    {
        return Salary * 0.10m; 
    }
}

class BankAccount
{
    public string AccountHolder { get; set; }
    public decimal Balance { get; set; }

    public BankAccount(string accountHolder, decimal balance)
    {
        AccountHolder = accountHolder;
        Balance = balance;
    }

    // Virtual metod
    public virtual decimal CalculateInterest()
    {
        return 0; // Alt sınıflar bunu override edecek
    }
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(string accountHolder, decimal balance) 
        : base(accountHolder, balance) { }

    // Override edilmiş metod
    public override decimal CalculateInterest()
    {
        return Balance * 0.05m; // Vadeli hesap faiz oranı %5
    }
}

class CheckingAccount : BankAccount
{
    public CheckingAccount(string accountHolder, decimal balance) 
        : base(accountHolder, balance) { }

    // Override edilmiş metod
    public override decimal CalculateInterest()
    {
        Console.WriteLine("Checking accounts do not earn interest.");
        return 0;
    }
}

class Program
{
    static void Main()
    {
        //Employee Problem
        Console.WriteLine("=====Employee Problem=====");
        Manager manager = new Manager(1, "Ahmet", 10000, "IT", 5);
        Developer developer = new Developer(2, "Mehmet", 8000, "Software", "C# Developer");

        Console.WriteLine($"{manager.Name}, maaşı: {manager.Salary}, primi: {manager.CalculateBonus()} TL");
        Console.WriteLine($"{developer.Name}, maaşı: {developer.Salary}, primi: {developer.CalculateBonus()} TL");
        
        
        
        //Bank Problem
        Console.WriteLine("=====Bank Problem=====");
        SavingsAccount savings = new SavingsAccount("Ali", 10000);
        CheckingAccount checking = new CheckingAccount("Veli", 5000);

        Console.WriteLine($"{savings.AccountHolder}, hesap bakiyesi: {savings.Balance}, faiz kazancı: {savings.CalculateInterest()} TL");
        checking.CalculateInterest();
    }
}