using System;
using System.Collections;

public interface IDiscountHandler
{
    IDiscountHandler NextHandler { get; set; }
    double ApplyDiscount(double originalPrice);
}

public class SeniorDiscountHandler : IDiscountHandler
{
    public IDiscountHandler NextHandler { get; set; }

    public double ApplyDiscount(double originalPrice)
    {
        double discountedPrice = originalPrice * 0.9;
        Console.WriteLine($"Senior Discount Applied: {discountedPrice}");
        return discountedPrice;
    }
}

public class MemberDiscountHandler : IDiscountHandler
{
    public IDiscountHandler NextHandler { get; set; }

    public double ApplyDiscount(double originalPrice)
    {
        double discountedPrice = originalPrice * 0.8;
        Console.WriteLine($"Member Discount Applied: {discountedPrice}");
        return discountedPrice;
    }
}

public class VIPDiscountHandler : IDiscountHandler
{
    public IDiscountHandler NextHandler { get; set; }

    public double ApplyDiscount(double originalPrice)
    {
        double discountedPrice = originalPrice * 0.7;
        Console.WriteLine($"VIP Discount Applied: {discountedPrice}");
        return discountedPrice;
    }
}

public class DiscountClient
{
    private IDiscountHandler discountHandlerChain;

    public DiscountClient(IDiscountHandler discountHandlerChain)
    {
        this.discountHandlerChain = discountHandlerChain;
    }

    public void ProcessDiscounts(IEnumerable<double> prices)
    {
        foreach (var price in prices)
        {
            double discountedPrice = discountHandlerChain.ApplyDiscount(price);
            Console.WriteLine($"Final Price: {discountedPrice}");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        IDiscountHandler seniorDiscountHandler = new SeniorDiscountHandler();
        IDiscountHandler memberDiscountHandler = new MemberDiscountHandler();
        IDiscountHandler vipDiscountHandler = new VIPDiscountHandler();

        seniorDiscountHandler.NextHandler = memberDiscountHandler;
        memberDiscountHandler.NextHandler = vipDiscountHandler;

        DiscountClient client = new DiscountClient(seniorDiscountHandler);

        List<double> prices = new List<double> { 100, 150, 200 };

        client.ProcessDiscounts(prices);
    }
}
