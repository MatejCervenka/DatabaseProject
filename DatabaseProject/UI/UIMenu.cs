namespace DatabaseProject
{
    /// <summary>
    /// Represents a user interface menu for interacting with the database.
    /// </summary>
    public class UIMenu
    {
        private List<string> menu = new List<string>();
        private bool isFilled = false;

        /// <summary>
        /// Adds a new item to the menu.
        /// </summary>
        /// <param name="item">The item to add to the menu.</param>
        public void AddItem(string item)
        {
            menu.Add(item);
        }

        /// <summary>
        /// Fills the menu with predefined options.
        /// </summary>
        public void FillMenu()
        {
            Console.WriteLine();
            menu.Add("----------------1) Add an order");
            menu.Add("----------------2) Add a product");
            menu.Add("----------------3) Add an ordered product");
            menu.Add("----------------4) Add a supplier");
            menu.Add("----------------5) Add a customer");
            menu.Add("----------------6) Delete an order");
            menu.Add("----------------7) Delete a product");
            menu.Add("----------------8) Delete an ordered product");
            menu.Add("----------------9) Delete a supplier");
            menu.Add("----------------10) Delete a customer");
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

        /// <summary>
        /// Prints the filled menu to the console.
        /// </summary>
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
}