import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';

import { Category } from '../models/category.model';
import { CategoryUpdateRequest } from '../models/category-update-request';
import { CategoryService } from '../services/category-service';

@Component({
  selector: 'app-category-edit',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './category-edit.html',
  styleUrls: ['./category-edit.css'] // ✅ use 'styleUrls'
})
export class CategoryEdit implements OnInit, OnDestroy {
  id: string | null = null;
  paramsSubscription?: Subscription;
  category?: Category;

  constructor(
    private route: ActivatedRoute,
    private cService: CategoryService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if (this.id) {
          this.cService.getCategoryById(this.id).subscribe({
            next: (response) => {
              this.category = response;
            }
          });
        }
      }
    });
  }

  OnFormSubmit(): void {
    const categoryUpdate: CategoryUpdateRequest = {
      name: this.category?.name ?? '',
      urlHandle: this.category?.urlHandle ?? ''
    };

    if (this.id) {
      this.cService.updateCategory(this.id, categoryUpdate).subscribe({
        next: () => {
          this.router.navigateByUrl('/admin/categories'); // ✅ update path
        }
      });
    }
  }

  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
  }
}

