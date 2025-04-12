// Task 1
using Domain;

var numbers = new List<int> { 1, 5, 8, 12, 3, 9, 4, 7, 11, 2, 6, 10 };
// Ожидаемый результат: 2, 4, 6, 8, 10, 12

// // Method
// var nums = numbers.Where(n => n% 2 == 0).Order();

// Query
// var nums =
//     from n in numbers
//     where n % 2 == 0
//     orderby n
//     select n; 
// foreach (var item in nums)
// {
//     System.Console.Write(item + " ");
// }

// Task 2
var words = new List<string> {
    "apple", "banana", "orange", "grape", "kiwi",
    "pear", "pineapple", "mango", "lemon"
};
// Ожидаемый результат: "banana", "orange", "pineapple"

// Method
var fiveWords = words.Where(n => n.Length > 5).ToList();

// Query 
var fiveWords2 =
    (from word in words
     where word.Length > 5
     select word).ToList();
foreach (var item in fiveWords)
{
    System.Console.Write(item + " ");
}


// Task 3

var students = new List<Student>
{
    new Student { Name = "Анна", Grade = 5 },
    new Student { Name = "Иван", Grade = 4 },
    new Student { Name = "Мария", Grade = 5 },
    new Student { Name = "Петр", Grade = 3 }
};

// Method
var avg = students.Average(n => n.Grade);

// Query
var avg2 = (
    from average in students
    select average).Average(n => n.Grade);

System.Console.WriteLine(avg);

// Task 4
var products = new List<Product>
{
    new Product { Name = "Яблоко", Price = 50, Category = "Фрукты" },
    new Product { Name = "Молоко", Price = 80, Category = "Молочные" },
    new Product { Name = "Хлеб", Price = 30, Category = "Выпечка" },
    new Product { Name = "Банан", Price = 70, Category = "Фрукты" },
    new Product { Name = "Сыр", Price = 120, Category = "Молочные" }
};

// Query
var statProduct = (
    from product in products
    group product by product.Category into g
    select new
    {
        Category = g.Key,
        AveragePrice = g.Average(n => n.Price)
    }
).ToList();

// Method

var statProduct2 = products.GroupBy(n => n.Category).Select(p => new
{
    Category = p.Key,
    AveragePrice = p.Average(n => n.Price)
}).ToList();

foreach (var item in statProduct2)
{
    System.Console.WriteLine(item.Category + " " + item.AveragePrice);
}

// Task 5
var orders = new List<Order>
{
    new Order { CustomerName = "Иван", Amount = 1000 },
    new Order { CustomerName = "Мария", Amount = 1500 },
    new Order { CustomerName = "Иван", Amount = 800 },
    new Order { CustomerName = "Анна", Amount = 2000 },
    new Order { CustomerName = "Мария", Amount = 500 }
};

// Query 

var orderius = (
    from order in orders
    group order by order.CustomerName into g
    select new
    {
        CustomerName = g.Key,
        SumOrder = g.Sum(n => n.Amount)
    }
).ToList();

// Method

var orderius2 = orders.GroupBy(n => n.CustomerName).Select(n => new
{
    CustomerName = n.Key,
    SumOrder = n.Sum(n => n.Amount)
}).ToList();

foreach (var item in orderius2)
{
    System.Console.WriteLine(item.CustomerName + ": " + item.SumOrder);
}

// Task 6

var books = new List<Book>
{
    new Book { Title = "Книга 1", Genre = "Фантастика", Pages = 400 },
    new Book { Title = "Книга 2", Genre = "Детектив", Pages = 300 },
    new Book { Title = "Книга 3", Genre = "Фантастика", Pages = 350 },
    new Book { Title = "Книга 4", Genre = "Детектив", Pages = 450 }
};

// Query
var statBook = (
    from book in books
    group book by book.Genre into g
    let maxPages = g.Max(n => n.Pages)
    select new
    {
        Genre = g.Key,
        Title = g.First(n => n.Pages == maxPages).Title,
        Pages = maxPages
    }
).ToList();

// Method

var statBook2 = books.GroupBy(n => n.Genre).Select(b => new
{
    Genre = b.Key,
    b.First(n => n.Pages == b.Max(b => b.Pages)).Title,
    Pages = b.Max(n => n.Pages)
}).ToList();

foreach (var item in statBook2)
{
    System.Console.WriteLine(item.Genre + ": " + item.Title + " " + item.Pages);
}

// Task 7
var grades = new List<int> { 5, 4, 5, 3, 4, 5, 3, 4, 5, 2 };

// Query 
var gradesCount = (
    from grade in grades
    group grade by grade into g
    select new
    {
        g.Key,
        Count = g.Count()
    }
).ToList();

// Method
var gradesCount2 = grades.GroupBy(n => n).Select(n => new
{
    n.Key,
    Count = n.Count()
}).ToList();

foreach (var item in gradesCount2)
{
    System.Console.WriteLine(item.Key + ": " + item.Count);
}

// Task 8

var cities = new List<City>
{
    new City { Name = "Москва", Population = 12000000 },
    new City { Name = "Новосибирск", Population = 1500000 },
    new City { Name = "Краснодар", Population = 800000 },
    new City { Name = "Екатеринбург", Population = 1400000 },
    new City { Name = "Томск", Population = 500000 }
};

// Query 
var citues = (
    from city in cities
    where city.Population > 1000000
    orderby city.Population descending
    select city
).ToList();

// Method
var citues2 = cities.Where(n => n.Population > 1000000).OrderByDescending(n => n.Population).ToList();

foreach (var item in citues2)
{
    System.Console.WriteLine(item.Name + " " + item.Population);
}

// Task 9
var employees = new List<Employee>
{
    new Employee { Department = "IT", Salary = 60000 },
    new Employee { Department = "HR", Salary = 45000 },
    new Employee { Department = "IT", Salary = 70000 },
    new Employee { Department = "HR", Salary = 40000 },
    new Employee { Department = "IT", Salary = 65000 }
};


// Query
var employius = (
    from employee in employees
    group employee by employee.Department into g
    select new
    {
        Department = g.Key,
        Salarniy = g.Average(n => n.Salary)
    }
).ToList();

// Method
var employius2 = employees.GroupBy(n => n.Department).Select(n => new
{
    Department = n.Key,
    Salarniy = n.Average(n => n.Salary)
}).ToList();


foreach (var item in employius2)
{
    System.Console.WriteLine(item.Department + ": " + item.Salarniy);
}


// Task 10
var movies = new List<Movie>
{
    new Movie { Title = "Фильм 1", Rating = 8.5 },
    new Movie { Title = "Фильм 2", Rating = 7.8 },
    new Movie { Title = "Фильм 3", Rating = 6.9 },
    new Movie { Title = "Фильм 4", Rating = 8.2 },
    new Movie { Title = "Фильм 5", Rating = 9.0 }
};

// Query
var movius = (
    from movie in movies
    where movie.Rating > 8
    orderby movie.Rating descending
    select movie
).ToList();

// Method
var movius2 = movies
.Where(n => n.Rating > 8)
.OrderByDescending(n => n.Rating).ToList();

foreach (var item in movius2)
{
    System.Console.WriteLine(item.Title + " " + item.Rating);
}