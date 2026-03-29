namespace EquipmentRental.Domain;

public class Projector : Equipment
{
    public string brand { get; }
    public string resolution  {get; }
    public bool hasHDMI { get;  }
    public Projector (string name, string brand, string resolution, bool HDMI) : base(name)
    {
        this.brand = brand;
        this.resolution = resolution;
        this.hasHDMI = HDMI;
    }

    public override string ToString()
    {
        return base.ToString() + " | " + brand + " | " +   resolution + " | HDMI: " + hasHDMI;
    }
}