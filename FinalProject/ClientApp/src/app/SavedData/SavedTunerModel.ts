export class Tuner {
  public id: string;
  public manufacturer: string;
  public model: string;
  public subModel: string;
  public color: string;
  public picture: string;
  public vin: string;
  public year: number;
  public children: string;



  constructor(id: string, manufacturer: string, model: string, subModel: string, color: string, picture: string, vin: string, year: number, children: string) {
    this.id = id;
    this.manufacturer = manufacturer;
    this.model = model;
    this.subModel = subModel;
    this.color = color;
    this.picture = picture;
    this.vin = vin;
    this.year = year;
    this.children = children;
  }
}
