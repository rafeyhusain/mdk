import { SimpleModel } from "./simple.model";
import { ModelModel } from "./model.model";

export class CarFilterListModel {
    Make : SimpleModel[];
    Model : ModelModel[];
    Price : number[] = [1500, 9900000];
    Year : number[] = [1991, 2016];
    Displacement : SimpleModel[];
    Color : SimpleModel[];
    FuelType : SimpleModel[];
    Door : SimpleModel[];
    Grade : SimpleModel[];
    StockId : string;
    ChassisNo : string;
}
