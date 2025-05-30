import { Injectable } from '@angular/core';
import { CategoryAddRequest } from '../models/category-add-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category.model';
import { environment } from '../../../../../src/environments/environment'
import { CategoryUpdateRequest } from '../models/category-update-request';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http:HttpClient) { }

  addCategory(model:CategoryAddRequest): Observable<void>{
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Categories/Create`, model);
  }

  getAllCategories(): Observable<Category[]>{
    var url = `${environment.apiBaseUrl}/api/Categories/GetAll`;
    console.log(url);
  

    return this.http.get<Category[]>(`${environment.apiBaseUrl}/api/Categories/GetAll`);
  }
  
  getCategoryById(id:string): Observable<Category>{
    return this.http.get<Category>(`${environment.apiBaseUrl}/api/Categories/GetById/${id}`);
  }

  updateCategory(id:string, updateModel:CategoryUpdateRequest): Observable<Category>{
    return this.http.put<Category>(`${environment.apiBaseUrl}/api/Categories/Update/${id}`, updateModel);
  }
}
