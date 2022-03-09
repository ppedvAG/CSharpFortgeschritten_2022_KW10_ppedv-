
#nullable disable

PersonRecord personRecord1 = new PersonRecord(1, "Sub", "Herman");
PersonRecord personRecord2 = new PersonRecord(1, "Sub", "Herman");

PersonClass personClass1 = new PersonClass(2, "Sub", "Herman");
PersonClass personClass2 = new PersonClass(2, "Sub", "Herman");


// == Operator 
if (personRecord1 == personRecord2)
{
    Console.WriteLine("gleich");
}
else
{
    Console.WriteLine("ungleich");
}

if (personClass1 == personClass2)
{
    Console.WriteLine("gleich");
}
else
{
    Console.WriteLine("ungleich");
}


//Equals
if (personRecord1.Equals(personRecord2))
{
    Console.WriteLine("gleich");
}
else
{
    Console.WriteLine("ungleich");
}

if (personClass1.Equals(personClass2))
{
    Console.WriteLine("gleich");
}
else
{
    Console.WriteLine("ungleich");
}


//ToString
Console.WriteLine("ToString() - Beispiel");
Console.WriteLine(personRecord1.ToString());


var result = personRecord1;
Console.WriteLine(result.Id);
Console.WriteLine(result.Vorname);
Console.WriteLine(result.Nachname);

public record PersonRecord(int Id, string Vorname, string Nachname);

public record EmployeeRecord : PersonRecord
{
    public decimal Gehalt { get; set; }

    public EmployeeRecord(int Id, string Vorname, string Nachname,  decimal Gehalt)
        :base(Id, Vorname, Nachname)
       //Aufruf des Konstruktor der Basisklasse
    {
        this.Gehalt = Gehalt;
    }
}



public record Animal
{
    public int Id { get; set; }
    public string Name { get; init; }

    //Auch hier werden die Methoden zusätzlich hinzugefügt

    public void Info()
    {

    }
}

public record Dog : Animal
{

    public void MakeWuffWuff()
    {

    }
}

public class PersonClass
{
    public int Id { get; init; }
    public string Vorname { get; init; }
    public string Nachname { get; init; }

    public PersonClass(int id, string vorname, string nachname )
    {
        this.Id = id;
        this.Vorname = vorname;
        this.Nachname = nachname;
    }
}