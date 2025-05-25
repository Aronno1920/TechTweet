import { Injectable } from '@angular/core';
import { CategoryAddRequest } from '../models/category-add-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category.model';
import { environment } from '../../../../../src/environments/environment'

@Injectable({
  providedIn: 'root'
})

export class CategoryService {

  constructor(private http:HttpClient) { }

  addCategory(model:CategoryAddRequest): Observable<void>{
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Categories/Create`, model);
  }

  getAllCategories(): Observable<Category[]>{
    return this.http.get<Category[]>(`${environment.apiBaseUrl}/api/Categories/GetAll`);
  }
  
}
