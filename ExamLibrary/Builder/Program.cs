// Instantiate builder and director
using Builder;

IFestivalBuilder lollapalooza = new LollapaloozaBuilder();
IFestivalBuilder roskilde = new RoskildeFestivalBuilder();

BuilderDirector director = new BuilderDirector(lollapalooza);

// Build first festival
director.ConstructFestival();
Festival festival = lollapalooza.GetFestival();
festival.ShowAllElements();

Console.WriteLine("\n-------------------\n");

// Build second festival
director = new BuilderDirector(roskilde);
director.ConstructFestival();
festival = roskilde.GetFestival();
festival.ShowAllElements();

Console.ReadKey();
