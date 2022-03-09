using System.Dynamic;

dynamic myObj = new ExpandoObject();

myObj.Id = 123;
myObj.Name = "Gustav Gans";
myObj.Title = "Glückspilz";
myObj.Feierabend = true;


if (myObj.Feierabend)
{
    Console.WriteLine("Feierabend!");
}