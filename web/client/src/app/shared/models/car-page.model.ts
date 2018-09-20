import { Response } from '@angular/http';
import { CarModel } from './car.model';

export class CarPageModel {
    Results : CarModel[];
    CurrentPage : number;
    PageCount : number;
    PageSize : number;
    RecordCount : number;
    SortBy : number;

    prepare(model: CarPageModel) {
        this.Results = model.Results;
        this.CurrentPage = model.CurrentPage;
        this.PageCount = model.PageCount;
        this.PageSize = model.PageSize;
        this.SortBy = model.SortBy;

        this.Results.forEach(car => {
            car.Images_ = JSON.parse(car.Images);
            car.Features_ = JSON.parse(car.Features);
        });
    }
}
