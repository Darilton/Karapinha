import { Injectable } from '@angular/core';
import { Service } from '../model/service.model';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  constructor(private http: HttpClient) { }

  updateServices(): Observable<Service[]> {
    return this.http.get<Service[]>(`${environment.apiBaseUrl}/Service`);
  }
}
