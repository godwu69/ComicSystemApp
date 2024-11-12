import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import {NgForOf, NgIf} from '@angular/common';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [NgForOf, FormsModule, NgIf],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  books: any[] = [];
  currentBook: any = {};
  isEditing: boolean = false;

  constructor(private router: Router, private http: HttpClient) {}

  getAllBooks() {
    this.http.get<any>('http://localhost:5235/api/comic').subscribe({
      next: (res) => {
        this.books = res.data;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  viewBook(bookId: number) {
    this.http.get<any>(`http://localhost:5235/api/comic/${bookId}`).subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  // Edit book
  editBook(bookId: number) {
    this.isEditing = true;
    this.http.get<any>(`http://localhost:5235/api/comic/${bookId}`).subscribe({
      next: (res) => {
        this.currentBook = res.data;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  saveBook() {
    if (this.isEditing) {
      this.http
        .put<any>(`http://localhost:5235/api/comic/${this.currentBook.comicBookId}`, this.currentBook)
        .subscribe({
          next: (res) => {
            console.log(res);
            this.getAllBooks();
            this.resetForm();
          },
          error: (err) => {
            console.log(err);
          },
        });
    } else {
      this.http
        .post<any>('http://localhost:5235/api/comic', this.currentBook)
        .subscribe({
          next: (res) => {
            console.log(res);
            this.getAllBooks();
            this.resetForm();
          },
          error: (err) => {
            console.log(err);
          },
        });
    }
  }

  // Delete book
  deleteBook(bookId: number) {
    this.http.delete<any>(`http://localhost:5235/api/comic/${bookId}`).subscribe({
      next: (res) => {
        console.log(res);
        this.getAllBooks();
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  resetForm() {
    this.isEditing = false;
    this.currentBook = {};
  }

  ngOnInit(): void {
    this.getAllBooks();
  }
}
