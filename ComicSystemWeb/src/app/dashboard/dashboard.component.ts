import {Component, OnInit} from '@angular/core';
import {Router, RouterOutlet} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {NgForOf} from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  constructor(private router: Router, private http: HttpClient) { }

  books: any[] = [];


  getAllBooks(){
    this.http.get<any>('http://localhost:5235/api/comic').subscribe({
      next: res => {
        this.books = res.data;
      },
      error: err => {
        console.log(err);
      }
    });
  }

  viewBook(bookId: number) {
    this.http.get<any>(`http://localhost:5235/api/comic/${bookId}`).subscribe({
      next: res => {
        console.log(res);
      },
      error: err => {
        console.log(err);
      }
    });
  }

  editBook(bookId: number) {
    this.http.put<any>(`http://localhost:5235/api/comic/${bookId}`,
      {}
    ).subscribe({
      next: res => {
        console.log(res);
      },
      error: err => {
        console.log(err);
      }
    });
  }

  deleteBook(bookId: number) {
    this.http.delete<any>(`http://localhost:5235/api/comic/${bookId}`).subscribe({
      next: res => {
        console.log(res);
      },
      error: err => {
        console.log(err);
      }
    });
  }

  ngOnInit(): void {
    this.getAllBooks();
  }

}
