export class OptionsModel {
    Make : number;
    Model : number;
    Year : number[];
    Mileage : number[];
    Condition : number;
    ExteriorColor : number;
    InteriorColor : number;
    Transmission : number;
    Engine : number;
    DriveTrain : number;
    Location : number;
    StockId : string;
    ChassisNo : string;
    Displacement : number[];
    Steering : number;
    FuelType : number;
    Door : number;
    Grade : number;
    Featured : number;
    Image : string;
    Summary : string; 
    Images : string; 
    GeneralInformation : string;
    VechileOverview : string;
    Options : string;
    Features : string;

    // calculated properties (prepared inside CarPageModel)
    Stars: any[];
}
