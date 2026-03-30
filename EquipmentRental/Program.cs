using EquipmentRental.Domain;
using EquipmentRental.Services;

RentalService service = new RentalService();
string msg;

var l1 = new Laptop("Laptop 1", "Lenovo", "ThinkPad", 16);
var p1 = new Projector("Projektor 1", "Epson", "1920x1080", true);
var c1 = new Camera("Kamera 1", "Sony", 10, 24);

service.addEquipment(l1);
service.addEquipment(p1);
service.addEquipment(c1);

Console.WriteLine("\n[SPRZET - WSZYSTKO]");
foreach (var e in service.getAllEquipment())
{
    Console.WriteLine(e);
}

var s1 = new Student("Jan", "Kowalski");
var e1 = new Employee("Anna", "Nowak");

service.addUser(s1);
service.addUser(e1);

Console.WriteLine("\n[UZYTKOWNICY]");
Console.WriteLine(s1);
Console.WriteLine(e1);

Console.WriteLine("\n[POPRAWNE WYPOZYCZENIE]");
bool ok = service.rentEquipment(s1.Id, l1.Id, 7, out msg);
Console.WriteLine(msg);

Console.WriteLine("\n[NIEPOPRAWNA OPERACJA - sprzet juz wypozyczony]");
ok = service.rentEquipment(e1.Id, l1.Id, 3, out msg);
Console.WriteLine(msg);

Console.WriteLine("\n[NIEPOPRAWNA OPERACJA - przekroczenie limitu studenta]");
ok = service.rentEquipment(s1.Id, p1.Id, 5, out msg);
Console.WriteLine(msg);

ok = service.rentEquipment(s1.Id, c1.Id, 5, out msg);
Console.WriteLine(msg);

Console.WriteLine("\n[ZWROT W TERMINIE]");
var activeForStudent = service.getActiveRentalsForUser(s1.Id);
if (activeForStudent.Count > 0)
{
    int rentalId1 = activeForStudent[0].Id;
    ok = service.returnEquipment(rentalId1, DateTime.Today.AddDays(7), out msg);
    Console.WriteLine(msg);
}
else
{
    Console.WriteLine("Brak aktywnych wypozyczen studenta");
}


Console.WriteLine("\n[ZWROT OPOZNIONY Z KARA]");
ok = service.rentEquipment(e1.Id, c1.Id, 3, out msg);
Console.WriteLine(msg);

if (ok)
{
    var activeForEmp = service.getActiveRentalsForUser(e1.Id);
    if (activeForEmp.Count > 0)
    {
        int rentalId2 = activeForEmp[0].Id;

        ok = service.returnEquipment(rentalId2, DateTime.Today.AddDays(10), out msg);
        Console.WriteLine(msg);
    }
    else
    {
        Console.WriteLine("Brak aktywnych wypozyczen pracownika");
    }
}
else
{
    Console.WriteLine("Nie udalo sie utworzyc wypozyczenia dla pracownika");
}

Console.WriteLine("\n[RAPORT - DOSTEPNY SPRZET]");
foreach (var e in service.getAvailableEquipment())
{
    Console.WriteLine(e);
}

Console.WriteLine("\n[RAPORT - PRZETERMINOWANE WYPOZYCZENIA]");
foreach (var r in service.getOverdueRentals(DateTime.Today))
{
    Console.WriteLine(r);
}


Console.WriteLine("\n[PODSUMOWANIE]");
Console.WriteLine(service.getSummaryReport(DateTime.Today));
