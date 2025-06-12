import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Subscription, Observable } from 'rxjs';

import { Category } from '../models/category.model';
import { CategoryUpdateRequest } from '../models/category-update-request.model';
import { CategoryService } from '../services/category-service';

@Component({
  selector: 'app-category-edit',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './category-edit.html',
  styleUrls: ['./category-edit.css']
})

export class CategoryEdit implements OnInit, OnDestroy {
  id: string | null = null;
  paramsSubscription?: Subscription;
  category$?: Observable<Category>;
  category?:Category;
  
  constructor(
    private route: ActivatedRoute,
    private cService: CategoryService,
    private router: Router
  ) {}

  
  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe(params => {
      const newId = params.get('id');
      if (newId && newId !== this.id) {
        this.id = newId;
        this.loadCategory(this.id);
      }
    });
  }

  loadCategory(id: string) {
    this.category$ =  this.cService.getCategoryById(id);
  }

  OnFormSubmit(): void {
    const categoryUpdate: CategoryUpdateRequest = {
      name: this.category?.name ?? '',
      urlHandle: this.category?.urlHandle ?? ''
    };

    if (this.id) {

      console.log('-------> ',this.id);
      console.log('------->', categoryUpdate);


      this.cService.updateCategory(this.id, categoryUpdate).subscribe({
        next: () => {
          this.router.navigateByUrl('/admin/categories');
        }
      });
    }
  }

  OnDelete(): void{
        if (this.id) {
          this.cService.deleteCategory(this.id).subscribe({
            next: () => {
              this.router.navigateByUrl('/admin/categories');
            }
      });
    }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
  }
}

