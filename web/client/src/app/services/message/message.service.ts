import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor() { }

  messages: string[] = [];

  error<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      this.err(`[LOGGER] ${operation} failed: ${error.message}`);
 
      return of(result as T);
    };
  }
 
  log(message: string) {
    console.log(message);
    this.messages.push(message);
  }
 
  err(message: string) {
    console.error(message);
    //this.messages.push(message);
  }

  clear() {
    this.messages = [];
  }
}
