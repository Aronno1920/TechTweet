import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../../../src/environments/environment';
import { BlogPostAdd } from '../models/blog-post-add.model';
import { BlogPost } from '../models/blog-post.model';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  createPost(data: BlogPostAdd): Observable<BlogPost>{
    return this.http.post<BlogPost>(`${environment.apiBaseUrl}/api/Posts/Create`, data);
  }
}
