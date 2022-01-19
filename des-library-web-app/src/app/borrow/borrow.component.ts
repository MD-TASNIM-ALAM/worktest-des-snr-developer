import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../books/book';
import { BooksService } from '../books/books.service';

@Component({
  selector: 'app-borrow',
  templateUrl: './borrow.component.html',
  styleUrls: ['./borrow.component.scss']
})
export class BorrowComponent implements OnInit {
  booksService: BooksService;
  book:Book;

  constructor(private avRoute: ActivatedRoute,  private router: Router) { }

  ngOnInit(): void {
    let id = this.avRoute.snapshot.paramMap.get('id');
    this.booksService.getBook(Number(id))
        .subscribe((data) => {
            this.book = data;
        });
  }

  submit() {
    let book: Book = {
        id: this.book.id,
        name: this.book.name,
        author: this.book.author,
        language: this.book.language,
        pages: this.book.pages,
        status: 'Borrowed'
    };
    this.booksService.borrowBook(this.book.id,book)
    .subscribe((data) => {
        this.router.navigate(['/book']);
    });
  }

}
