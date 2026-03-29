namespace EquipmentRental.Domain;

public class Camera : Equipment
{
    public string brand { get; }
    public int zoom  { get; }
    public int megapixels { get; }

    public Camera(string name, string brand, int zoom, int megapixels) : base(name)
    {
        this.brand = brand;
        this.zoom = zoom;
        this.megapixels = megapixels;
    }

    public override string ToString()
    {
        return base.ToString()  + " | Marka: " + brand + " | Zoom: " + zoom + " | Megapiksele: " + megapixels;
    }
}