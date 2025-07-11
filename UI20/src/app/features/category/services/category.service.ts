import { Injectable } from '@angular/core';
import { CategoryAddRequest } from '../models/category-add-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../../environments/environment';
import { Category } from '../models/category.model';
import { CategoryUpdateRequest } from '../models/category-update-request.model';


@Injectable({
  providedIn: 'root'
})

export class CategoryService {

  constructor(private http: HttpClient) { }

  addCategory(model: CategoryAddRequest): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Categories/Create`, model);
  }

  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${environment.apiBaseUrl}/api/Categories/GetAll`);
  }

  getCategoryById(id: string): Observable<Category> {
    return this.http.get<Category>(`${environment.apiBaseUrl}/api/Categories/GetById/${id}`);
  }

  updateCategory(id: string, updateModel: CategoryUpdateRequest): Observable<Category> {
    return this.http.put<Category>(`${environment.apiBaseUrl}/api/Categories/Update/${id}`, updateModel);
  }

  /** 
   * Soft-deletes (inactivates) the category
   * Fix: Add empty object {} as body to satisfy HttpClient.put() signature 
   **/
  
  inactiveCategory(id: string): Observable<boolean> {
    return this.http.put<boolean>(`${environment.apiBaseUrl}/api/Categories/Inactive/${id}`, {});
  }

  deleteCategory(id: string): Observable<boolean> {
    return this.http.delete<boolean>(`${environment.apiBaseUrl}/api/Categories/Delete/${id}`);
  }
}
