import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  constructor(private http: HttpClient) { }

  getCategories(){
    return this.http.get(`${environment.apiBaseUrl}/Category`);
  }

  getCategoryService(categoryId: number){
    return this.http.get(`${environment.apiBaseUrl}/Category/${categoryId}/Services`);
  }
}
