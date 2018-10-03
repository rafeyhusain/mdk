import { SimpleModel } from "./simple.model";
import { ModelModel } from "./model.model";

export class OptionsModel {
    Makes : any[];
    Models : any[];
    Colors : any[];
    FuelTypes : any[];
    Grades : any[];
    Doors : any[];
    Years : number[] = [1991, 2016];
    Displacements : number[] = [200, 9000];
    Price : number[] = [1500, 99000000];

    constructor() { }

    prepare(model: OptionsModel) {
        this.Makes = model.Makes;
        this.Models = model.Models;
        this.Colors = model.Colors;
        this.FuelTypes = model.FuelTypes;
        this.Grades = model.Grades;
        this.Doors = model.Doors;
    }
}
