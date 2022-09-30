using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

using (EcommerceContext db = new EcommerceContext())
{
    // Create

    Product newProduct = new Product { Name = "Panino", Description = "Un panino ripieno di prosciutto", Price = 4.99 };
    db.Add(newProduct);

    Customer newCustomer = new Customer { Name = "Mara", Surname = "Maionchi", Email = "maramare@mail.it" };
    db.Add(newCustomer);

    db.SaveChanges();
    // Read
    Console.WriteLine("Recupero lista di Products");
    List<Product> products = db.Products.OrderBy(product => product.Name).ToList<Product>();
    foreach (Product product in products)
    {
        Console.WriteLine(product.Name + " " + product.Description + " ------> " + product.Price);
    }

    Console.WriteLine();

    Console.WriteLine("Recupero lista di Customers");
    List<Customer> customers = db.Customers.OrderBy(customer => customer.Name).ToList<Customer>();
    foreach (Customer customer in customers)
    {
        Console.WriteLine(customer.Name + " " + customer.Surname + " ------> " + customer.Email);
    }

    //// Update
    //newCustomer.Name = "Veronica";
    //db.SaveChanges();

    //// Delete
    //db.Remove(customer);
    //db.SaveChanges();
}

public class EcommerceContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-ecommerce;Integrated Security=True;Pooling=False");
    }
}
