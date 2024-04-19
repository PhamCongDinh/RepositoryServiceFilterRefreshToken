import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../services/home.service';
import { Router } from '@angular/router';
import { catchError, of } from 'rxjs';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  constructor(private home: HomeService, private router: Router) { }

  ngOnInit(): void {
    this.danhsach();
  }
  films: any[] = [];
  // danhsach() {
  //   this.home.getallphim().subscribe(
  //     Response => {
  //       this.films = Response.data;
  //     },
  //     error => {
  //       if (error.status === 401) {
  //         console.error('Unauthorized error:', error);
  //         this.router.navigate(['/login']);
  //       }
  //     }
  //   )
  // }
  danhsach() {
    this.home.getallphim()
      .subscribe({
        next: (response) => {
          this.films = response.data;
        },
        error: (error) => {
          console.log(error)

        }
      });
  }
}
