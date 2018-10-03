import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

import { MessageService } from '../message/message.service';

import { CarModel } from '../../shared/models/car.model';
import { CarPageModel } from '../../shared/models/car-page.model';
import { CarFilterModel } from '../../shared/models/car-filter.model';
import { OptionsModel } from '../../shared/models/options.model';

const httpOptions = {
  headers: new HttpHeaders({ })
};

@Injectable({ providedIn: 'root' })
export class CarService {
 
  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }
  
  /** GET car by id. Will 404 if id not found */
  getCar(id: number): Observable<CarModel> {
    const url = `${ environment.apiUrl }/api/cars/${id}`;

    var options = { headers : new HttpHeaders({'No-Auth':'True'})};

    return this.http.get<CarModel>(url, options).pipe(
      tap(_ => this.messageService.log(`fetched car id=${id}`)),
      catchError(this.messageService.error<CarModel>(`getCar id=${id}`))
    );
  }

  /* GET cars which match to search filter */
  getCars(filter: CarFilterModel): Observable<CarPageModel> {
    const url = `${ environment.apiUrl }/api/cars/search`;

    if (filter == null) {
      return null;
    }

    var options = { headers : new HttpHeaders({'No-Auth':'True', 'Content-Type': 'application/json'}) };
    
    return this.http.post<CarPageModel>(url, filter, options).pipe(
      tap((result: CarPageModel) => {
        let model = new CarPageModel(); // result is just raw data without functions
        model.prepare(result);
        result = model;
      }),
      catchError(this.messageService.error<CarPageModel>('getCars'))
    );
  }

  getOptions(): Observable<OptionsModel> {
    const url = `${ environment.apiUrl }/api/options`;

    var options = { headers : new HttpHeaders({'No-Auth':'True'}) };

    return this.http.get<CarModel>(url, options).pipe(
      tap((result: OptionsModel) => {
        let model = new OptionsModel(); // result is just raw data without functions
        model.prepare(result);
        result = model;
      }),
      catchError(this.messageService.error<CarModel>(`getOptions`))
    );
  }

  /** POST: add a new car to the server */
  addCar (car: CarModel): Observable<CarModel> {
    return this.http.post<CarModel>( environment.apiUrl , car, httpOptions).pipe(
      tap((car: CarModel) => this.messageService.log(`added car w/ id=${car.CarId}`)),
      catchError(this.messageService.error<CarModel>('addCar'))
    );
  }
 
  /** DELETE: delete the car from the server */
  deleteCar (car: CarModel | number): Observable<CarModel> {
    const id = typeof car === 'number' ? car : car.CarId;
    const url = `${ environment.apiUrl }/${id}`;
 
    return this.http.delete<CarModel>(url, httpOptions).pipe(
      tap(_ => this.messageService.log(`deleted car id=${id}`)),
      catchError(this.messageService.error<CarModel>('deleteCar'))
    );
  }
 
  /** PUT: update the car on the server */
  updateCar (car: CarModel): Observable<any> {
    return this.http.put( environment.apiUrl , car, httpOptions).pipe(
      tap(_ => this.messageService.log(`updated car id=${car.CarId}`)),
      catchError(this.messageService.error<any>('updateCar'))
    );
  }
}