////Steht als Main

//Console.WriteLine("Hello World");


////Re




////ExtendedPropertyPatterns
//PersonModel person = new();


//if(person is { FirstName : "Kevin"})
//{
//    Console.WriteLine("Hello Kevin");
//}

//if (person is { HomeAddress.City: "Berlin" })
//{
//    Console.WriteLine("You are in Berlin");
//}

//if (person is { FirstName: "Kevin", LastName: "Winter", HomeAddress.Country: "Germany", HomeAddress.City: "Berlin" })
//{

//}






////Interpolated String Handler
//Console.WriteLine("Hello, World!");
//int abc = 123;

//string.Format($"harry weinfuhrt {abc} ");


////Record Struct (Verhält sich weiterhin wie ein nirmales Struct (nur kompakter)) 
//public record struct Point1
//{
//    public double X { get; init; }
//    public double Y { get; init; }
//    public double Z { get; init; }
//}

//public class KlasssStehtImmerUnterhalb
//{

//}




//class PersonModel
//{
//    public string FirstName { get; set; } = "Kevin";
//    public string LastName { get; set; } = "Winter";

//    public AddressModel HomeAddress { get; set; } = new AddressModel();
//}

//class AddressModel
//{
//    public string City { get; set; } = "Berlin";
//    public string Country { get; set; } = "Germany";
//}