namespace DatabaseProject;

public class UIMenu
{
    public List<string> menu = new List<string>();
    bool isFilled = false;
    public void AddItem(string item)
    {
        menu.Add(item);
    }
    public void FillMenu()
    {
        Console.WriteLine();
        menu.Add("----------------1) Add an order");
        menu.Add("----------------2) Add a product");
        menu.Add("----------------3) Add a order product");
        menu.Add("----------------4) Add a supplier");
        menu.Add("----------------5) Add a customer");
        menu.Add("----------------6) Delete order");
        menu.Add("----------------7) Delete product");
        menu.Add("----------------8) Delete ordered product");
        menu.Add("----------------9) Delete supplier");
        menu.Add("----------------10) Delete customer");
        menu.Add("----------------11) List all orders");
        menu.Add("----------------12) List all products");
        menu.Add("----------------13) List all ordered products");
        menu.Add("----------------14) List all suppliers");
        menu.Add("----------------15) List all customers");
        menu.Add("----------------16) Delete all orders");
        menu.Add("----------------17) Delete all products");
        menu.Add("----------------18) Delete all ordered products");
        menu.Add("----------------19) Delete all suppliers");
        menu.Add("----------------20) Delete all customers");
        menu.Add("----------------21) Quit");
    }

    public void Print()
    {
        if (!isFilled)
        {
            FillMenu();
            isFilled = true;
        }

        foreach (string item in menu)
        {
            Console.WriteLine(item);
        }
    }
}