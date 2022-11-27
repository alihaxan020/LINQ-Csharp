namespace LinqPractice
{
    public class Public
    {
        public static void Main()
        {
            List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // query syntax
            IEnumerable<int> querySyntax = from obj in list where obj % 2 != 0 select obj;
            foreach (var item in querySyntax)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------");
            //method syntax
            IEnumerable<int> methodSyntax = list.Where(x => x % 2 == 0);
            foreach (var item in methodSyntax)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------");
            // mixed syntax
            var mixedSyntax = (from obj in list select obj).Max();
            Console.WriteLine("Max value= {0}", mixedSyntax);
            // List of Employee class

            List<Employee> employees = new ()
            {
            new Employee(){Id=1,Name="Usman", Email="usman@gmail.com"},
            new Employee(){Id=2, Name="Umer", Email="umer@gmail.com"},
            new Employee(){Id=3, Name="Ali", Email="ali@gmail.com"},
            new Employee(){Id=4, Name="Hassan", Email="hassan@gmail.com"},
            };
            Console.WriteLine("-------IEnummerable (LINQ)--------");
            IEnumerable<Employee> employee = from emp in employees where emp.Id == 3 select emp;
            // Generic List
            foreach (var item in employee)
            {
                Console.WriteLine("Id = "+item.Id+" Name = "+item.Name);
            }
            // Iquerable, It is a child class of IEnummerable
            Console.WriteLine("-------IQuerable (LINQ)--------");
            IQueryable<Employee> employeesQ = employees.AsQueryable().Where(x=>x.Id == 4);
            foreach (var item in employeesQ)
            {
                Console.WriteLine("Id = " + item.Id + " Name = " + item.Name);
            }
            Console.WriteLine("-------Projection Operations (LINQ)--------");

            // Get all the data from data source using query syntax and convert into list
            var basicquery = (from emp in employees select emp).ToList();

            // Get all the data from data source using method syntax and convert into list
            var basicMethod = employees.Select(x => x);
            var basicMethod1 = employees.ToList();
            foreach (var item in basicMethod1)
            {
                Console.WriteLine($"Id = {item.Id}, Name = {item.Name}, Email= {item.Email}");
            }

            Console.WriteLine("-------Getting Some properties ( Operations)--------");
            // query syntax
            var basicPropQuery = (from emp in employees select emp.Id).ToList();
            // method syntax
            var basicPropMethod = employees.Select(emp => emp.Name).ToList();

            // select  required properties from data source
            var selectQuery = (from emp in employees
                               select new Employee()
                               {
                                   Id = emp.Id,
                                   Email = emp.Email,
                               }).ToList();
            // LINQ projection anonymous type (query syntax)
            var selectQueryAnonymous = (from emp in employees
                               select new 
                               {
                                   CustomId = emp.Id,
                                   CustomEmail = emp.Email,
                                   CustomName = emp.Name,
                               }).ToList();

            // LINQ projection anonymous type (method syntax)
            var selectMethodAnonymous = employees.Select(emp=> new
            {
                CustomId = emp.Id,
                CustomEmail = emp.Email,
                CustomName = emp.Name,
            }).ToList();
            // LINQ projection anonymous type (method syntax) with index
            var selectMethodIndexAnonymous = employees.Select((emp, index) => new
            {
                Index = index,
                FullName = emp.Name,
            }).ToList();

            // select required properties from data source and convert into other class type (query syntax)
            var selectQueryOtherType = (from emp in employees
                               select new Student()
                               {
                                   StudentId = emp.Id,
                                   StEmail = emp.Email,
                               }).ToList();
            // select required properties from data source and convert into other class type (method syntax)
            var selectMethodOtherType = employees.Select(emp => new Student
            {
                StudentId = emp.Id,
                StEmail = emp.Email,
                FullName=emp.Name,
            }).ToList();
        }
    }
}