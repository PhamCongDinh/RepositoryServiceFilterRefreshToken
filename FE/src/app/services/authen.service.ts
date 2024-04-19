import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenService {

  constructor(private http: HttpClient) { }
  private apiUrl = "http://localhost:5218/api/Authens";

  login(data: any): Observable<any> {
    const url = `${this.apiUrl}/testlog`;
    return this.http.post(url, data);
  }

  refreshToken(data: any): Observable<any> {
    const url = `${this.apiUrl}/refresh`;
    return this.http.post(url, data);
  }
  register(data: any): Observable<any> {
    const url = `${this.apiUrl}/Register`;
    return this.http.post(url, data);
  }
}
