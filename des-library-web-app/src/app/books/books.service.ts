import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs';
import {Book} from './book';

@Injectable()
export class BooksService {
  apiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    this.apiUrl = 'https://localhost:5000/book';
   }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.apiUrl);
  }
  getBook(id:number): Observable<Book> {
    return this.http.get<Book>(this.apiUrl + id);
  }
  borrowBook(id:number, book:Book): Observable<Book[]> {
    return this.http.put<Book[]>(this.apiUrl  +id, JSON.stringify(book), this.httpOptions);
  }
}
