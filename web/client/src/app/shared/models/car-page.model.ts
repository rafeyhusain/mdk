import { CarModel } from './car.model';

export class CarPageModel {
    Results : CarModel[];
    CurrentPage : number;
    PageCount : number;
    PageSize : number;
    RecordCount : number;
    SortBy : number;
}