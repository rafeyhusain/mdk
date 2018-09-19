import { Response } from '@angular/http';
import { CarModel } from './car.model';

export class CarPageModel {
    Results : CarModel[];
    CurrentPage : number;
    PageCount : number;
    PageSize : number;
    RecordCount : number;
    SortBy : number;

    prepare(carPage: CarPageModel) {
        this.Results = carPage.Results;
        this.CurrentPage = carPage.CurrentPage;
        this.PageCount = carPage.PageCount;
        this.PageSize = carPage.PageSize;
        this.SortBy = carPage.SortBy;

        this.Results.forEach(car => {
            car.Images_ = JSON.parse(car.Images);
            car.Features_ = JSON.parse(car.Features);
        });
    }
}
