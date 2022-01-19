import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../books/book';
import { BooksService } from '../books/books.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  constructor() {
  }

  ngOnInit(): void {
  }
}
