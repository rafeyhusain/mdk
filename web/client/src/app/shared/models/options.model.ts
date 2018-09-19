export class OptionsModel {
    Make : number;
    Model : number;
    Year : number[];
    Mileage : number[];
    Condition : number;
    Color : number;
    Transmission : number;
    DriveTrain : number;
    Location : number;
    StockId : string;
    ChassisNo : string;
    Displacement : number[];
    FuelType : number;
    Door : number;
    Grade : number;
    Featured : number;
    Image : string;
    Summary : string; 
    Images : string; 

    // calculated properties (prepared inside CarPageModel)
    Stars: any[];
}
