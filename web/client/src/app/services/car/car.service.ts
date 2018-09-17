import { Injectable } from '@angular/core';
import { CarModel } from '../../shared/models/car.model';
import { CarFilterModel } from '../../shared/models/car-filter.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from '../message-service/message.service';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class CarService {
 
  private apiUrl = 'http://localhost:55450/api/cars';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }
  
  /** GET car by id. Will 404 if id not found */
  getCar(id: number): Observable<CarModel> {
    //const url = `${this.apiUrl}/${id}`;

    //TODO: --------------
    const url = this.apiUrl;
    return this.http.get<CarModel>(url).pipe(
      tap(_ => this.log(`fetched car id=${id}`)),
      catchError(this.handleError<CarModel>(`getCar id=${id}`))
    );
  }

  /* GET cars whose name contains search term */
  getCars(filter: CarFilterModel): Observable<CarModel[]> {
    if (filter == null) {
      // if not search term, return empty car array.
      return of([]);
    }

    return this.http.post<CarModel[]>(this.apiUrl, filter, httpOptions).pipe(
      tap((car: CarModel) => this.log(`found cars matching`)),
      catchError(this.handleError<CarModel[]>('getCars', []))
    );
  }
 
  //////// Save methods //////////
 
  /** POST: add a new car to the server */
  addCar (car: CarModel): Observable<CarModel> {
    return this.http.post<CarModel>(this.apiUrl, car, httpOptions).pipe(
      tap((car: CarModel) => this.log(`added car w/ id=${car.id}`)),
      catchError(this.handleError<CarModel>('addCar'))
    );
  }
 
  /** DELETE: delete the car from the server */
  deleteCar (car: CarModel | number): Observable<CarModel> {
    const id = typeof car === 'number' ? car : car.id;
    const url = `${this.apiUrl}/${id}`;
 
    return this.http.delete<CarModel>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted car id=${id}`)),
      catchError(this.handleError<CarModel>('deleteCar'))
    );
  }
 
  /** PUT: update the car on the server */
  updateCar (car: CarModel): Observable<any> {
    return this.http.put(this.apiUrl, car, httpOptions).pipe(
      tap(_ => this.log(`updated car id=${car.id}`)),
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