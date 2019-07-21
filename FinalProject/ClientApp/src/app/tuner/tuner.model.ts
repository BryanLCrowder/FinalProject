
export class Tuner {
  public Id: string;
  public Manufacturer: string;
  public Model: string;
  public SubModel: string;
  public Color: string;
  public Picture: string;
  public Vin: string;
  public Year: number;
  public Children: string;



  constructor(Id: string, Manufacturer: string, Model: string, SubModel: string, Color: string, Picture: string, Vin: string, Year: number, Children: string) {
    this.Id = Id;
    this.Manufacturer = Manufacturer;
    this.Model = Model;
    this.SubModel = SubModel;
    this.Color = Color;
    this.Picture = Picture;
    this.Vin = Vin;
    this.Year = Year;
    this.Children = Children;
  }
}
