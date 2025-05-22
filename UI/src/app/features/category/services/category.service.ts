import { Injectable } from '@angular/core';
import { CategoryAddRequest } from '../models/category-add-request.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {

  constructor(private http:HttpClient) { }

  addCategory(model:CategoryAddRequest):Observable<void>{
    return this.http.post<void>('http://localhost:5187/api/Categories/Create', model);
  }
}
