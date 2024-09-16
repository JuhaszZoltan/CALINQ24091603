using CALINQ24091603;
using System.Net.WebSockets;

#region list of pets
List<Pet> pets = [
    new Pet() //01
    {
        Name = "Mr. Wick",
        Speaces = "hamster",
        Sex = true,
        BirthDate = new(2022, 05, 07),
    },
    new Pet() //02
    {
        Name = "Lenin",
        Speaces = "cat",
        Sex = true,
        BirthDate = new(2020, 05, 17),
    },
    new Pet() //03
    {
        Name = "Amy",
        Speaces = "dog",
        Sex = false,
        BirthDate = new(2019, 05, 23),
    },
    new Pet() //04
    {
        Name = "Roblox",
        Speaces = "dog",
        Sex = true,
        BirthDate = new(2018, 10, 22),
    },
    new Pet() //05
    {
        Name = "Teréz",
        Speaces = "cat",
        Sex = false,
        BirthDate = new(2023, 09, 01),
    },
    new Pet() //06
    {
        Name = "Feri",
        Speaces = "crocodile",
        Sex = false,
        BirthDate = new(1985, 09, 11),
    },
    new Pet() //07
    {
        Name = "Thomas Edison",
        Speaces = "dog",
        Sex = true,
        BirthDate = new(2004, 06, 11),
    },
];
#endregion

/* """ismert""" nevezetes algoritmusok / programozási tételek
 * sorozatszámítás -> összegzés => átlagszámítás
 * megszámlálás
 * szélsőérték meghatározás (min, max)
 * [lineáris] keresés
 * eldöntés
 * kiválasztás
 * -------------------
 * [másolás]
 * kiválogatás
 * szétválogatás
 * [bármilyen] redezés
 * halmaztételek (unió, metszet, diferenciál) 
*/

Console.WriteLine($"állatkák száma: {pets.Count} darab");

var lSum = pets.Sum(pet => pet.Age);
Console.WriteLine($"állatkák összéletkora: {lSum} év");

var lAvg = pets.Average(pet => pet.Age);
Console.WriteLine($"állatkák átlagéletkora: {lAvg:0.00} év");

var lCnt01 = pets.Count(p => p.Speaces == "cat");
Console.WriteLine($"cicák száma: {lCnt01} darab");

var lCnt02 = pets.Count(p => p.Speaces == "dog" && p.Sex);
Console.WriteLine($"fiú kutyusok számas: {lCnt02} darab");

var lMin = pets.Min(p => p.BirthDate);
Console.WriteLine($"a legöregebb állatka szülinapja: {lMin:MMMM dd.}");

var lMaxBy = pets.MaxBy(p => p.Name);
Console.WriteLine($"névsorban utcsó állatka: {lMaxBy}");

var lFrst = pets.First(p => p.Speaces == "dog");
Console.WriteLine($"listában első kutyus: {lFrst}");
//ha van találat -> rendre ELSŐ matching element
//ha nincs találat -> 'sequence contains no matching element' exc

var lLst = pets.Last(p => p.BirthDate.Year < 2000);
Console.WriteLine($"a listában utolsó 2000 előtt született állatka: {lLst}");
//ha van találat -> rendre UTOLSÓ matching element
//ha nincs találat -> 'sequence contains no matching element' exc

var lSng = pets.Single(p => p.Speaces == "hamster");
Console.WriteLine($"az egyetlen höri: {lSng}");
//ha EGYETLEN találat van -> "A" matching element
//ha TÖBB találat is *lenne* -> 'sequence contains more than one matching element' exc
//ha egyáltalán NINCS -> 'sequence contains no matching element' exc

var lFrstOD = pets.FirstOrDefault(p => p.Speaces == "unicorn");
Console.WriteLine($"listában első unikornis null-e?: {lFrstOD is null}");
//ha van találat -> rendre ELSŐ matching element
//ha nincs találat -> "default" értéket ad vissza, ami:
//   referencia típusok (minden ami "class") esetén null
//   érték típusok (minden ami "struct") esetén *általában* zéró

var lLstOD = pets.LastOrDefault(p => p.BirthDate.Year < 2000);
Console.WriteLine($"a listában utolsó 2000 előtt született állatka: {lLstOD}");
//ha van találat -> rendre UTOLSÓ matching element
//ha nincs találat -> "default" értéket ad vissza, ami:
//   referencia típusok (minden ami "class") esetén null
//   érték típusok (minden ami "struct") esetén *általában* zéró

var lSngOD = pets.SingleOrDefault(p => p.Speaces == "hamster");
Console.WriteLine($"az egyetlen höri: {lSngOD}");
//ha EGYETLEN találat van -> "A" matching element
//ha TÖBB találat is *lenne* -> 'sequence contains more than one matching element' exc
//ha nincs találat -> "default" értéket ad vissza, ami:
//   referencia típusok (minden ami "class") esetén null
//   érték típusok (minden ami "struct") esetén *általában* zéró

//int[] numbers = [11, 26, 32, 7, 11, 40, 8, 1243];
//var numRes = numbers.FirstOrDefault(x => x % 2810 == 0);
//Console.WriteLine(numRes);

//find <-- first or default
//findall <-- where
//indexof ::: ez a collection.generic-ben van, nem LINQ

int firstUnicornIndex = pets.IndexOf(lFrstOD);
Console.WriteLine($"első unikornis indexe: {firstUnicornIndex}");
//ha nincs benne a keresett elem a kollekcióban,
//akkor --> -1


int lastBirthbefore2000Index = pets.IndexOf(lLst);
Console.WriteLine($"utcsó <2000res születésű állatka indexe: {lastBirthbefore2000Index}");
//ha benne van --> index