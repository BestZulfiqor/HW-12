using Domain;

// Task 1
var orders = new List<Order>
{
    new Order { Id = 1, CustomerName = "Иван", OrderDate = new DateTime(2024, 1, 15), Amount = 1200.50m, Category = "Электроника" },
    new Order { Id = 2, CustomerName = "Мария", OrderDate = new DateTime(2024, 1, 15), Amount = 850.75m, Category = "Книги" },
    new Order { Id = 3, CustomerName = "Иван", OrderDate = new DateTime(2024, 1, 16), Amount = 2100.00m, Category = "Электроника" },
    new Order { Id = 4, CustomerName = "Анна", OrderDate = new DateTime(2024, 1, 16), Amount = 450.30m, Category = "Книги" }
};

// Query 
var orderius = (
    from order in orders
    group order by new { order.Category, order.OrderDate } into g
    select new
    {
        g.Key.Category,
        g.Key.OrderDate,
        Sum = g.Sum(j => j.Amount)
    }
).OrderBy(n => n.Sum).ToList();

// Method 

var orderius2 = orders.GroupBy(o => new { o.Category, o.OrderDate }).Select(n => new
{
    n.Key.Category,
    n.Key.OrderDate,
    Sum = n.Sum(n => n.Amount)
}).OrderByDescending(n => n.Sum).ToList();

foreach (var item in orderius2)
{
    System.Console.WriteLine(item.Category + " " + item.OrderDate + " " + item.Sum);
}

// Task 2
var students = new List<Student>
{
    new Student { Id = 1, Name = "Иван Петров", GroupId = 1 },
    new Student { Id = 2, Name = "Мария Иванова", GroupId = 2 },
    new Student { Id = 3, Name = "Петр Сидоров", GroupId = 1 }
};

var groups = new List<Group>
{
    new Group { Id = 1, Name = "ПО-42" },
    new Group { Id = 2, Name = "ИС-41" }
};

var grades = new List<Grade>
{
    new Grade { StudentId = 1, Subject = "Математика", Score = 5 },
    new Grade { StudentId = 1, Subject = "Физика", Score = 4 },
    new Grade { StudentId = 2, Subject = "Математика", Score = 5 },
    new Grade { StudentId = 3, Subject = "Физика", Score = 3 }
};

// Query
var studentus = (
    from student in students
    join group1 in groups on student.GroupId equals group1.Id
    join grade in grades on student.Id equals grade.StudentId
    group new { student, group1, grade } by new { student.Id, student.Name, GroupName = group1.Name } into g
    select new
    {
        StudentId = g.Key.Id,
        StudentName = g.Key.Name,
        GroupName = g.Key.GroupName,
        AvgGrade = g.Average(n => n.grade.Score)
    }
).ToList();

foreach (var item in studentus)
{
    System.Console.WriteLine(item.StudentId + " " +item.StudentName + " " + item.GroupName + " " + item.AvgGrade);
}