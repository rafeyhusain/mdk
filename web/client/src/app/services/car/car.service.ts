import { Injectable } from '@angular/core';
import { CarModel } from '../../shared/models/car.model';
import { CarPageModel } from '../../shared/models/car-page.model';
import { CarFilterModel } from '../../shared/models/car-filter.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from '../message/message.service';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class CarService {
 
  private baseUrl = 'http://localhost:55450';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }
  
  /** GET car by id. Will 404 if id not found */
  getCar(id: number): Observable<CarModel> {
    const url = `${this.baseUrl}/api/cars/${id}`;

    return this.http.get<CarModel>(url).pipe(
      tap(_ => this.log(`fetched car id=${id}`)),
      catchError(this.handleError<CarModel>(`getCar id=${id}`))
    );
  }

  /* GET cars which match to search filter */
  getCars(filter: CarFilterModel): Observable<CarPageModel> {
    if (filter == null) {
      return null;
    }

    const url = `${this.baseUrl}/api/cars/search`;

    return this.http.post<CarPageModel>(url, filter, httpOptions).pipe(
      tap((result: CarPageModel) => {
        console.log(`Cars :`, result);
        let carPage = new CarPageModel(); // result is just raw data without functions
        carPage.prepare(result);
        result = carPage;
      }),
      catchError(this.handleError<CarPageModel>('Error'))
    );
  }
 
  //////// Save methods //////////
 
  /** POST: add a new car to the server */
  addCar (car: CarModel): Observable<CarModel> {
    return this.http.post<CarModel>(this.baseUrl, car, httpOptions).pipe(
      tap((car: CarModel) => this.log(`added car w/ id=${car.CarId}`)),
      catchError(this.handleError<CarModel>('addCar'))
    );
  }
 
  /** DELETE: delete the car from the server */
  deleteCar (car: CarModel | number): Observable<CarModel> {
    const id = typeof car === 'number' ? car : car.CarId;
    const url = `${this.baseUrl}/${id}`;
 
    return this.http.delete<CarModel>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted car id=${id}`)),
      catchError(this.handleError<CarModel>('deleteCar'))
    );
  }
 
  /** PUT: update the car on the server */
  updateCar (car: CarModel): Observable<any> {
    return this.http.put(this.baseUrl, car, httpOptions).pipe(
      tap(_ => this.log(`updated car id=${car.CarId}`)),
      catchError(this.handleError<any>('updateCar'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
 
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
 
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
 
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
 
  /** Log a CarService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`CarService: ${message}`);
  }
}