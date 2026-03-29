namespace EquipmentRental.Domain;

public class Laptop : Equipment
{
    public string brand { get; }
    public string model { get; }
    public int RAM { get; set; }
    

    public Laptop(string name, string brand, string model, int ram) : base(name)
    {
        this.brand = brand;
        this.model = model;
        RAM = ram;
    }

    public override string ToString()
    {
        return base.ToString() + " | Marka: " + brand + " | Model: " +  model+ " " + RAM + "GB";
    }
}