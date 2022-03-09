// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");






//Entities repräsentieren einen Datensatz in einer Tabelle

//Code First -> 
public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
}



//DB-Contrext Klasse -> Verbindung zur Datenbank + Scope auf Tabellen
public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }    //repäsentiert die Tabelle Students
    public DbSet<Course> Courses { get; set; } //repäsentiert die Tabelle Courses


    public SchoolContext()
    {

    }

    public SchoolContext(DbContextOptions<SchoolContext> options) //Wenn der Connection-String in einer Konfigurations-Datei liegt. Wird der ConnectionString von Aussen eingelesen
         :base(options) //übergeben ConnectionString an DbContext
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb);Database=UniDb;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
}