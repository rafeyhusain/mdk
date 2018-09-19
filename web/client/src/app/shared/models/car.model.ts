export class CarModel {
    CarId : number;
    Caption : string;
    Price : number;
    PriceOriginal : number;
    Make : number;
    Model : number;
    Year : number;
    Month : number;
    Mileage : number;
    Color : number;
    Transmission : number;
    Location : number;
    StockId : string;
    ChassisNo : string;
    Displacement : number;
    Steering : number;
    FuelType : number;
    Door : number;
    Grade : number;
    Featured : number;
    Features : string;
    Images : string; 

    // calculated properties (see car-page.model prepare())
    Features_ : string[]; 
    Images_ : string[]; 
}